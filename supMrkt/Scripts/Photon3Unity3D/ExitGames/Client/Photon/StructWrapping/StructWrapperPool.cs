using System;
using System.Collections.Generic;

namespace ExitGames.Client.Photon.StructWrapping
{
	public class StructWrapperPool
	{
		public static WrappedType GetWrappedType(Type type)
		{
			return default(WrappedType);
		}
	}
	public class StructWrapperPool<T> : StructWrapperPool
	{
		public const int GROWBY = 4;

		public readonly Type tType;

		public readonly WrappedType wType;

		public Stack<StructWrapper<T>> pool;

		public readonly bool isStaticPool;

		public int Count => 0;

		public StructWrapperPool(bool isStaticPool)
		{
		}

		public StructWrapper<T> Acquire()
		{
			return null;
		}

		public StructWrapper<T> Acquire(T value)
		{
			return null;
		}

		internal void Release(StructWrapper<T> obj)
		{
		}
	}
}
