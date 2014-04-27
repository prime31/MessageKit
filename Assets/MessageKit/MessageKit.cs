using UnityEngine;
using System;
using System.Collections.Generic;


public static class MessageKit
{
	private static Dictionary<int,List<Action>> _messageTable = new Dictionary<int,List<Action>>();


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
