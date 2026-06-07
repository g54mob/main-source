using System;
using System.Collections.Generic;

namespace LibTessDotNet
{
	public class DefaultPool : IPool
	{
		private IDictionary<Type, ITypePool> _register;

		public override void Register<T>(ITypePool typePool)
		{
			if (_register == null)
			{
				_register = new Dictionary<Type, ITypePool>();
			}
			_register[typeof(T)] = typePool;
		}

		public override T Get<T>()
		{
			T val = null;
			ITypePool value;
			if (_register.TryGetValue(typeof(T), out value))
			{
				val = value.Get() as T;
			}
			if (val == null)
			{
				val = new T();
			}
			val.Init(this);
			return val;
		}

		public override void Return<T>(T obj)
		{
			if (obj != null)
			{
				obj.Reset(this);
				ITypePool value;
				if (_register.TryGetValue(typeof(T), out value))
				{
					value.Return(obj);
				}
			}
		}
	}
}
