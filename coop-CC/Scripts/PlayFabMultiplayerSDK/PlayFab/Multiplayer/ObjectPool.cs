using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace PlayFab.Multiplayer
{
	public class ObjectPool
	{
		internal class Pool
		{
			internal int Limit { get; set; }

			internal ConstructorInfo Ctor { get; set; }

			internal List<object> Objects { get; set; }

			internal Pool(int limit, ConstructorInfo ctor)
			{
				Limit = limit;
				Ctor = ctor;
				Objects = new List<object>();
			}
		}

		private static object[] ctorParamList0Element;

		private static object[] ctorParamList1Element;

		private static object[] ctorParamList2Element;

		private Dictionary<Type, Pool> pools;

		static ObjectPool()
		{
			ctorParamList0Element = new object[0];
			ctorParamList1Element = new object[1];
			ctorParamList2Element = new object[2];
		}

		public ObjectPool()
		{
			pools = new Dictionary<Type, Pool>();
		}

		public void AddEntry<T>(int maxLimit, Type[] ctorTypes)
		{
			Type typeFromHandle = typeof(T);
			ConstructorInfo constructor = typeFromHandle.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, ctorTypes, null);
			if (constructor != null)
			{
				pools[typeFromHandle] = new Pool(maxLimit, constructor);
			}
			else
			{
				Debugger.Break();
			}
		}

		public T Retrieve<T>()
		{
			return Retrieve<T>(ctorParamList0Element);
		}

		public T Retrieve<T>(object param)
		{
			ctorParamList1Element[0] = param;
			return Retrieve<T>(ctorParamList1Element);
		}

		public T Retrieve<T>(object param0, object param1)
		{
			ctorParamList2Element[0] = param0;
			ctorParamList2Element[1] = param1;
			return Retrieve<T>(ctorParamList2Element);
		}

		public T Retrieve<T>(object[] ctorParams)
		{
			Type typeFromHandle = typeof(T);
			object obj = null;
			if (pools.ContainsKey(typeFromHandle))
			{
				Pool pool = pools[typeFromHandle];
				ConstructorInfo ctor = pool.Ctor;
				int count = pool.Objects.Count;
				if (count > 0)
				{
					obj = pool.Objects[count - 1];
					pool.Objects.RemoveAt(count - 1);
					ctor.Invoke(obj, ctorParams);
				}
				else
				{
					obj = ctor.Invoke(ctorParams);
				}
			}
			else
			{
				Debugger.Break();
			}
			return (T)obj;
		}

		public void Return(object o)
		{
			Type type = o.GetType();
			if (pools.ContainsKey(type) && pools[type].Objects.Count < pools[type].Limit)
			{
				Pool pool = pools[type];
				if (pool.Objects.Count < pool.Limit)
				{
					pools[type].Objects.Add(o);
				}
			}
		}
	}
}
