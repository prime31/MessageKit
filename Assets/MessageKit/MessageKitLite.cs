using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


namespace Prime31.MessageKitLite
{
	public interface MessageReceiver
	{
	}

	public interface MessageReceiver<T> : MessageReceiver
	{
		void onMessageReceived( T message );
	}

	public interface MessageReceiver<T,U> : MessageReceiver
	{
		void onMessageReceived( T message, U other );
	}


	/// <summary>
	/// this is a slightly different take on what constitutes a message and a message receiver. Messages are defined by their Type
	/// and all message receivers must implement the MessageReceiver<T> interface.
	/// 
	/// Advantages: no Actions need to be created at runtime
	/// 
	/// Disadvantages: all listeners must implement an interface for each message type they want to observer
	///                you can't have two different messages with the same type (might not really be a disadvantage to many folks)
	/// </summary>
	public static class MessageKitLite
	{
		private static Dictionary<Type,List<MessageReceiver>> _messageTable = new Dictionary<Type,List<MessageReceiver>>();


		public static void addObserver<T>( MessageReceiver<T> observer )
		{
			var type = typeof( T );
			List<MessageReceiver> list = null;
			if( !_messageTable.TryGetValue( type, out list ) )
			{
				list = new List<MessageReceiver>();
				_messageTable.Add( type, list );
			}

			if( !list.Contains( observer ) )
				_messageTable[type].Add( observer );
		}


		public static void removeObserver<T>( MessageReceiver<T> observer )
		{
			var type = typeof( T );
			List<MessageReceiver> list = null;
			if( _messageTable.TryGetValue( type, out list ) )
			{
				if( list.Contains( observer ) )
					list.Remove( observer );
			}
		}


		public static void post<T>( T message )
		{
			var type = typeof( T );
			List<MessageReceiver> list = null;
			if( _messageTable.TryGetValue( type, out list ) )
			{
				for( var i = list.Count - 1; i >= 0; i-- )
					( list[i] as MessageReceiver<T> ).onMessageReceived( message );
			}
		}


		public static void clearObservers<T>()
		{
			var type = typeof( T );
			if( _messageTable.ContainsKey( type ) )
				_messageTable.Remove( type );
		}


		public static void clearAllObservers()
		{
			_messageTable.Clear();
		}
	}
}