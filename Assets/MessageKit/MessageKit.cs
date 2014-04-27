using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;



namespace Prime31.MessageKit
{
	class MessageKitManager : MonoBehaviour
	{
		// we store a list of any MessageKits that got created so that we can clear them out when a level loads
		private List<IDictionary> _messageKitInstances = new List<IDictionary>();


		private static MessageKitManager _instance;
		public static MessageKitManager instance
		{
			get
			{
				if( !_instance )
				{
					_instance = FindObjectOfType( typeof( MessageKitManager ) ) as MessageKitManager;

					if( !_instance )
					{
						var obj = new GameObject( "MessageKitManager" );
						obj.hideFlags = HideFlags.HideAndDontSave;
						DontDestroyOnLoad( obj );
						_instance = obj.AddComponent<MessageKitManager>();
					}
				}

				return _instance;
			}
		}


		public void registerMessageKitInstance( IDictionary messageKitInstance )
		{
			_messageKitInstances.Add( messageKitInstance );
		}


		void OnLevelWasLoaded( int level )
		{
			for( var i = 0; i <= _messageKitInstances.Count; i++ )
				_messageKitInstances[i].Clear();
		}

	}


	public static class MessageKit
	{
		private static Dictionary<int,List<Action>> _messageTable = new Dictionary<int,List<Action>>();

		static MessageKit()
		{
			MessageKitManager.instance.registerMessageKitInstance( _messageTable );
		}


		public static void addObserver( int messageType, Action handler )
		{
			if( !_messageTable.ContainsKey( messageType ) )
				_messageTable.Add( messageType, new List<Action>() );

			var list = _messageTable[messageType];
			if( !list.Contains( handler ) )
				_messageTable[messageType].Add( handler );
		}


		public static void removeObserver( int messageType, Action handler )
		{
			if( _messageTable.ContainsKey( messageType ) )
			{
				var list = _messageTable[messageType];
				if( list.Contains( handler ) )
					list.Remove( handler );
			}
		}


		public static void post( int messageType )
		{
			if( _messageTable.ContainsKey( messageType ) )
			{
				var list = _messageTable[messageType];
				for( var i = 0; i < list.Count; i++ )
					list[i]();
			}
		}

	}


	public static class MessageKit<U>
	{
		private static Dictionary<int,List<Action<U>>> _messageTable = new Dictionary<int,List<Action<U>>>();


		static MessageKit()
		{
			MessageKitManager.instance.registerMessageKitInstance( _messageTable );
		}


		public static void addObserver( int messageType, Action<U> handler )
		{
			if( !_messageTable.ContainsKey( messageType ) )
				_messageTable.Add( messageType, new List<Action<U>>() );

			var list = _messageTable[messageType];
			if( !list.Contains( handler ) )
				_messageTable[messageType].Add( handler );
		}


		public static void removeObserver( int messageType, Action<U> handler )
		{
			if( _messageTable.ContainsKey( messageType ) )
			{
				var list = _messageTable[messageType];
				if( list.Contains( handler ) )
					list.Remove( handler );
			}
		}


		public static void post( int messageType, U param )
		{
			if( _messageTable.ContainsKey( messageType ) )
			{
				var list = _messageTable[messageType];
				for( var i = 0; i < list.Count; i++ )
					list[i]( param );
			}
		}

	}


	public static class MessageKit<U,V>
	{
		private static Dictionary<int,List<Action<U,V>>> _messageTable = new Dictionary<int,List<Action<U,V>>>();


		static MessageKit()
		{
			MessageKitManager.instance.registerMessageKitInstance( _messageTable );
		}


		public static void addObserver( int messageType, Action<U,V> handler )
		{
			if( !_messageTable.ContainsKey( messageType ) )
				_messageTable.Add( messageType, new List<Action<U,V>>() );

			var list = _messageTable[messageType];
			if( !list.Contains( handler ) )
				_messageTable[messageType].Add( handler );
		}


		public static void removeObserver( int messageType, Action<U,V> handler )
		{
			if( _messageTable.ContainsKey( messageType ) )
			{
				var list = _messageTable[messageType];
				if( list.Contains( handler ) )
					list.Remove( handler );
			}
		}


		public static void post( int messageType, U firstParam, V secondParam )
		{
			if( _messageTable.ContainsKey( messageType ) )
			{
				var list = _messageTable[messageType];
				for( var i = 0; i < list.Count; i++ )
					list[i]( firstParam, secondParam );
			}
		}

	}
}
