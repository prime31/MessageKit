// uncomment this line to enable the MessageKitManager. It provides a single clearAllMessageTables method that
// will clear every single observer that was ever added
//#define ENABLE_MESSAGE_KIT_MANAGER

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace Prime31.MessageKit
{
	/// <summary>
	/// think of MessageKit as a safe, fast replacement for SendMessage. Decoupled messages identified by an int. It is recommended to define
	/// your messages as const so they can be easily referenced and identified when you read your code (see the demo scene for an example)
	/// </summary>
	public static class MessageKit
	{
		private static Dictionary<int, List<Action>> _messageTable = new Dictionary<int, List<Action>>();


#if ENABLE_MESSAGE_KIT_MANAGER
		static MessageKit()
		{
			MessageKitManager.registerMessageKitInstance( _messageTable );
		}
#endif


		public static void addObserver( int messageType, Action handler )
		{
			List<Action> list = null;
			if( !_messageTable.TryGetValue( messageType, out list ) )
			{
				list = new List<Action>();
				_messageTable.Add( messageType, list );
			}

			if( !list.Contains( handler ) )
				_messageTable[messageType].Add( handler );
		}


		public static void removeObserver( int messageType, Action handler )
		{
			List<Action> list = null;
			if( _messageTable.TryGetValue( messageType, out list ) )
			{
				if( list.Contains( handler ) )
					list.Remove( handler );
			}
		}


		public static void post( int messageType )
		{
			List<Action> list = null;
			if( _messageTable.TryGetValue( messageType, out list ) )
			{
				for( var i = list.Count - 1; i >= 0; i-- )
					list[i]();
			}
		}


		public static void clearMessageTable( int messageType )
		{
			if( _messageTable.ContainsKey( messageType ) )
				_messageTable.Remove( messageType );
		}


		public static void clearMessageTable()
		{
			_messageTable.Clear();
		}

		public static void LogObservers( int messageType )
		{
			if( _messageTable.ContainsKey( messageType ) == false || _messageTable[messageType].Count == 0 )
			{
				Debug.Log( "MessageType: " + messageType + " has no observers" );
				return;
			}

			var sb = new StringBuilder();
			sb.AppendLine( "MessageType: " + messageType + " has " + _messageTable[messageType].Count + " Observers" );

			for( var i = 0; i < _messageTable[messageType].Count; i++ )
			{
				Action action = _messageTable[messageType][i];
				sb.AppendLine( "Target: " + action.Target + "\t Method: " + action.Method );
			}

			Debug.Log( sb.ToString() );
		}
	}


	public static class MessageKit<U>
	{
		private static Dictionary<int, List<Action<U>>> _messageTable = new Dictionary<int, List<Action<U>>>();


#if ENABLE_MESSAGE_KIT_MANAGER
		static MessageKit()
		{
			MessageKitManager.registerMessageKitInstance( _messageTable );
		}
#endif


		public static void addObserver( int messageType, Action<U> handler )
		{
			List<Action<U>> list = null;
			if( !_messageTable.TryGetValue( messageType, out list ) )
			{
				list = new List<Action<U>>();
				_messageTable.Add( messageType, list );
			}

			if( !list.Contains( handler ) )
				_messageTable[messageType].Add( handler );
		}


		public static void removeObserver( int messageType, Action<U> handler )
		{
			List<Action<U>> list = null;
			if( _messageTable.TryGetValue( messageType, out list ) )
			{
				if( list.Contains( handler ) )
					list.Remove( handler );
			}
		}


		public static void post( int messageType, U param )
		{
			List<Action<U>> list = null;
			if( _messageTable.TryGetValue( messageType, out list ) )
			{
				for( var i = list.Count - 1; i >= 0; i-- )
					list[i]( param );
			}
		}


		public static void clearMessageTable( int messageType )
		{
			if( _messageTable.ContainsKey( messageType ) )
				_messageTable.Remove( messageType );
		}


		public static void clearMessageTable()
		{
			_messageTable.Clear();
		}


		public static void logObservers( int messageType )
		{
			if( _messageTable.ContainsKey( messageType ) == false || _messageTable[messageType].Count == 0 )
			{
				Debug.Log( "MessageType: " + messageType + " has no observers" );
				return;
			}

			var sb = new StringBuilder();
			sb.AppendLine( "MessageType: " + messageType + " has " + _messageTable[messageType].Count + " Observers" );

			for( var i = 0; i < _messageTable[messageType].Count; i++ )
			{
				var action = _messageTable[messageType][i];
				sb.AppendLine( "Target: " + action.Target + "\t Method: " + action.Method );
			}

			Debug.Log( sb.ToString() );
		}
	}


	public static class MessageKit<U, V>
	{
		private static Dictionary<int, List<Action<U, V>>> _messageTable = new Dictionary<int, List<Action<U, V>>>();


#if ENABLE_MESSAGE_KIT_MANAGER
		static MessageKit()
		{
			MessageKitManager.registerMessageKitInstance( _messageTable );
		}
#endif


		public static void addObserver( int messageType, Action<U, V> handler )
		{
			List<Action<U, V>> list = null;
			if( !_messageTable.TryGetValue( messageType, out list ) )
			{
				list = new List<Action<U, V>>();
				_messageTable.Add( messageType, list );
			}

			if( !list.Contains( handler ) )
				_messageTable[messageType].Add( handler );
		}


		public static void removeObserver( int messageType, Action<U, V> handler )
		{
			List<Action<U, V>> list = null;
			if( _messageTable.TryGetValue( messageType, out list ) )
			{
				if( list.Contains( handler ) )
					list.Remove( handler );
			}
		}


		public static void post( int messageType, U firstParam, V secondParam )
		{
			List<Action<U, V>> list = null;
			if( _messageTable.TryGetValue( messageType, out list ) )
			{
				for( var i = list.Count - 1; i >= 0; i-- )
					list[i]( firstParam, secondParam );
			}
		}


		public static void clearMessageTable( int messageType )
		{
			if( _messageTable.ContainsKey( messageType ) )
				_messageTable.Remove( messageType );
		}


		public static void clearMessageTable()
		{
			_messageTable.Clear();
		}


		public static void logObservers( int messageType )
		{
			if( _messageTable.ContainsKey( messageType ) == false || _messageTable[messageType].Count == 0 )
			{
				Debug.Log( "MessageType: " + messageType + " has no observers" );
				return;
			}

			var sb = new StringBuilder();
			sb.AppendLine( "MessageType: " + messageType + " has " + _messageTable[messageType].Count + " Observers" );

			for( var i = 0; i < _messageTable[messageType].Count; i++ )
			{
				Action<U, V> action = _messageTable[messageType][i];
				sb.AppendLine( "Target: " + action.Target + "\t Method: " + action.Method );
			}

			Debug.Log( sb.ToString() );
		}
	}


#if ENABLE_MESSAGE_KIT_MANAGER
	public static class MessageKitManager
	{
		// we store a list of any MessageKits that got created so that we can clear them out when a level loads
		private static List<IDictionary> _messageKitMessageTables = new List<IDictionary>();


		public static void registerMessageKitInstance( IDictionary messageKitMessageTable )
		{
			_messageKitMessageTables.Add( messageKitMessageTable );
		}


		public static void clearAllMessageTables()
		{
			for( var i = 0; i < _messageKitMessageTables.Count; i++ )
				_messageKitMessageTables[i].Clear();
		}
	}
#endif
}
