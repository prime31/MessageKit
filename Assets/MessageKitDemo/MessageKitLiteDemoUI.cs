using UnityEngine;
using System.Collections;
using Prime31.MessageKitLite;



public class MessageKitLiteDemoUI : MonoBehaviour, MessageReceiver<int>, MessageReceiver<GameObject>
{
	void OnGUI()
	{
		if( GUILayout.Button( "Add Observer (int param)" ) )
		{
			MessageKitLite.addObserver<int>( this );
		}


		if( GUILayout.Button( "Fire (int param)" ) )
		{
			MessageKitLite.post( 4 );
		}


		if( GUILayout.Button( "Remove Observer (int param)" ) )
		{
			MessageKitLite.removeObserver<int>( this );
		}


		GUILayout.Space( 50 );

		if( GUILayout.Button( "Add Observer (GameObject param)" ) )
		{
			MessageKitLite.addObserver<GameObject>( this );
		}


		if( GUILayout.Button( "Fire (GameObject param)" ) )
		{
			MessageKitLite.post( gameObject );
		}


		if( GUILayout.Button( "Remove Observer (GameObject param)" ) )
		{
			MessageKitLite.removeObserver<GameObject>( this );
		}
	}


	public void onMessageReceived( int message )
	{
		Debug.Log( "onMessageReceived: " + message );
	}


	public void onMessageReceived( GameObject message )
	{
		Debug.Log( "onMessageReceived: " + message );
	}

}
