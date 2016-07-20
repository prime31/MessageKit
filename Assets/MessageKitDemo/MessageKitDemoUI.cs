using UnityEngine;
using System.Collections;
using Prime31.MessageKit;


// define your messageTypes (which are ints) preferably as const so they can be easily referenced
// and will benefit from code completion
public class MessageTypes
{
	public const int stuffHappened = 0;
	public const int otherStuffHappened = 1;
	public const int twoParamsEvent = 2;
}


public class MessageKitDemoUI : MonoBehaviour
{
	void OnGUI()
	{
		if( GUILayout.Button( "Add Observer (no params)" ) )
		{
			MessageKit.addObserver( MessageTypes.stuffHappened, stuffHappened );
		}


		if( GUILayout.Button( "Fire (no params)" ) )
		{
			MessageKit.post( MessageTypes.stuffHappened );
		}


		if( GUILayout.Button( "Remove Observer (no params)" ) )
		{
			MessageKit.removeObserver( MessageTypes.stuffHappened, stuffHappened );
		}

		if ( GUILayout.Button( "Debug.Log Observer (no params)" ) )
		{
			MessageKit.LogObservers( MessageTypes.stuffHappened );
		}

		GUILayout.Space( 50 );

		if( GUILayout.Button( "Add Observer (two params)" ) )
		{
			MessageKit<string,GameObject>.addObserver( MessageTypes.twoParamsEvent, twoParamsEvent );
		}


		if( GUILayout.Button( "Fire (two params)" ) )
		{
			MessageKit<string,GameObject>.post( MessageTypes.twoParamsEvent, "string param", gameObject );
		}


		if( GUILayout.Button( "Remove Observer (two params)" ) )
		{
			MessageKit<string,GameObject>.removeObserver( MessageTypes.twoParamsEvent, twoParamsEvent );
		}

		if( GUILayout.Button( "Debug.Log Observer (two params)" ) )
		{
			MessageKit<string, GameObject>.logObservers( MessageTypes.twoParamsEvent );
		}
	}


	void stuffHappened()
	{
		Debug.Log( "stuffHappened fired" );
	}


	void twoParamsEvent( string firstParam, GameObject secondParam )
	{
		Debug.Log( "twoParamsEvent: firstParam: " + firstParam + ", secondParam: " + secondParam );
	}

}
