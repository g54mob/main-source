using System;
using System.Collections.Generic;

namespace ExitGames.Client.Photon.StructWrapping
{
	public class StructWrapperPools
	{
		public static readonly StructWrapper<byte>[] mappedByteWrappers;

		public static readonly StructWrapper<bool>[] mappedBoolWrappers;

		private readonly Dictionary<Type, StructWrapperPool> pools;

		private readonly List<IDisposable> used;

		private StructWrapperPool<T> GetPoolForType<T>()
		{
			return null;
		}

		public StructWrapper<byte> Acquire(byte value)
		{
			return null;
		}

		public StructWrapper<bool> Acquire(bool value)
		{
			return null;
		}

		public StructWrapper<T> Acquire<T>(T value)
		{
			return null;
		}

		public void Clear()
		{
		}
	}
}
