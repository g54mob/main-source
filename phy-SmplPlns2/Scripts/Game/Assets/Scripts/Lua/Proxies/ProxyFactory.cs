using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Jundroo.Common.Expressions;

namespace Assets.Scripts.Lua.Proxies
{
	public class ProxyFactory
	{
		private readonly Dictionary<Type, Func<object, object>> _factoryMethods = new Dictionary<Type, Func<object, object>>();

		private readonly ConcurrentDictionary<object, WeakReference<object>> _proxyCache = new ConcurrentDictionary<object, WeakReference<object>>();

		private Context _expressionContext;

		private LuaScript _luaScript;

		public ProxyFactory(LuaScript luaScript, Context expressionContext)
		{
			_expressionContext = expressionContext;
			_luaScript = luaScript;
		}

		public TProxy GetOrCreateProxy<TProxy>(object underlyingObj) where TProxy : class
		{
			if (underlyingObj == null)
			{
				return null;
			}
			if (_proxyCache.TryGetValue(underlyingObj, out var value) && value.TryGetTarget(out var target))
			{
				return target as TProxy;
			}
			object obj = (GetFactoryMethodForType(underlyingObj.GetType()) ?? throw new InvalidOperationException($"No proxy factory registered for type {underlyingObj.GetType()} or its base types."))(underlyingObj);
			_proxyCache[underlyingObj] = new WeakReference<object>(obj);
			return obj as TProxy;
		}

		public void Register<TUnderlying, TProxy>(Func<TUnderlying, TProxy> factoryMethod) where TProxy : class
		{
			_expressionContext?.AllowMemberAccessForType<TProxy>(MemberAccessPermissionFlags.AllowPublic | MemberAccessPermissionFlags.AllowProperties | MemberAccessPermissionFlags.AllowMethods);
			_luaScript.RegisterType<TProxy>();
			_factoryMethods[typeof(TUnderlying)] = (object obj) => factoryMethod((TUnderlying)obj);
		}

		private Func<object, object> GetFactoryMethodForType(Type type)
		{
			while (type != null)
			{
				if (_factoryMethods.TryGetValue(type, out var value))
				{
					return value;
				}
				type = type.BaseType;
			}
			return null;
		}
	}
}
