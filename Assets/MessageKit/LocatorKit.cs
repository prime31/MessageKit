using System;
using System.Collections.Generic;
using UnityEngine;


// based on the handy Frictionless simple DI ServiceFactory
public class LocatorKit
{
	private static Dictionary<Type,Type> _singletons = new Dictionary<Type,Type>();
	private static Dictionary<Type,object> _singletonInstances = new Dictionary<Type,object>();


	public static void reset()
	{
		_singletons.Clear();
		_singletonInstances.Clear();
	}
	

	public static void registerSingleton<TConcrete>()
	{
		_singletons[typeof( TConcrete )] = typeof( TConcrete );
	}
	

	public static void registerSingleton<TInterface,TConcrete>()
	{
		_singletons[typeof( TInterface )] = typeof( TConcrete );
	}
	
	
	public static void registerSingleton<TConcrete>( TConcrete instance )
	{
		_singletons[typeof( TConcrete )] = typeof( TConcrete );
		_singletonInstances[typeof( TConcrete )] = instance;
	}
	

	public static T resolve<T>() where T : class
	{
		Type concreteType = null;
		var requestedType = typeof( T );
		
		if( _singletons.TryGetValue( requestedType, out concreteType ) )
		{
			object requestedObject = null;
			if( !_singletonInstances.TryGetValue( requestedType, out requestedObject ) )
			{
				if( concreteType.IsSubclassOf( typeof( MonoBehaviour ) ) )
				{
					var singletonGameObject = new GameObject( requestedType.ToString() );
					requestedObject = singletonGameObject.AddComponent( concreteType );
				}
				else
				{
					requestedObject = concreteType.GetConstructor( Type.EmptyTypes ).Invoke( new object[] { } );
				}
				
				_singletonInstances[requestedType] = requestedObject;
			}
			
			return (T)requestedObject;
		}

		return null;
	}
}