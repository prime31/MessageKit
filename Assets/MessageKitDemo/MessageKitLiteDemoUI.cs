using UnityEngine;
using System.Collections;
using Prime31.MessageKitLite;



// define your messageTypes (which are ints) preferably as const so they can be easily referenced
// and will benefit from code completion
public class LiteMessageTypes
{
	public const int noParamMessage = 0;
	public const int gameObjectParamMessage = 1;
}


public class MessageKitLiteDemoUI : MonoBehaviour, MessageReceiver, MessageReceiver<GameObject>
{
	void OnGUI()
	{
		if( GUILayout.Button( "Add Observer (no params)" ) )
		{
			MessageKitLite.addObserver( LiteMessageTypes.noParamMessage, this );
		}


		if( GUILayout.Button( "Fire (no params)" ) )
		{
			MessageKitLite.post( LiteMessageTypes.noParamMessage );
		}


		if( GUILayout.Button( "Remove Observer (no params)" ) )
		{
			MessageKitLite.removeObserver( LiteMessageTypes.noParamMessage, this );
		}


		GUILayout.Space( 50 );

		if( GUILayout.Button( "Add Observer (GameObject param)" ) )
		{
			MessageKitLite<GameObject>.addObserver( LiteMessageTypes.gameObjectParamMessage, this );
		}


		if( GUILayout.Button( "Fire (GameObject param)" ) )
		{
			MessageKitLite<GameObject>.post( LiteMessageTypes.gameObjectParamMessage, gameObject );
		}


		if( GUILayout.Button( "Remove Observer (GameObject param)" ) )
		{
			MessageKitLite<GameObject>.removeObserver( LiteMessageTypes.gameObjectParamMessage, this );
		}
	}


	public void onMessageReceived( int messageType )
	{
		Debug.Log( "onMessageReceived: " + messageType );
	}


	public void onMessageReceived( int messageType, GameObject param )
	{
		Debug.Log( "onMessageReceived: " + param.name );
	}

}
