using UnityEngine;
using System.Collections;


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
			Profiler.BeginSample( "MessageKit Add" );
			MessageKit.addObserver( MessageTypes.stuffHappened, stuffHappened );
			Profiler.EndSample();
		}


		if( GUILayout.Button( "Fire (no params)" ) )
		{
			Profiler.BeginSample( "MessageKit Post" );
			MessageKit.post( MessageTypes.stuffHappened );
			Profiler.EndSample();
		}


		if( GUILayout.Button( "Remove Observer (no params)" ) )
		{
			Profiler.BeginSample( "MessageKit Remove" );
			MessageKit.removeObserver( MessageTypes.stuffHappened, stuffHappened );
			Profiler.EndSample();
		}


		GUILayout.Space( 50 );

		if( GUILayout.Button( "Add Observer (two params)" ) )
		{
			Profiler.BeginSample( "MessageKit Add" );
			MessageKit<string,GameObject>.addObserver( MessageTypes.twoParamsEvent, twoParamsEvent );
			Profiler.EndSample();
		}


		if( GUILayout.Button( "Fire (two params)" ) )
		{
			Profiler.BeginSample( "MessageKit Post" );
			MessageKit<string,GameObject>.post( MessageTypes.twoParamsEvent, "string param", gameObject );
			Profiler.EndSample();
		}


		if( GUILayout.Button( "Remove Observer (two params)" ) )
		{
			Profiler.BeginSample( "MessageKit Remove" );
			MessageKit<string,GameObject>.removeObserver( MessageTypes.twoParamsEvent, twoParamsEvent );
			Profiler.EndSample();
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
