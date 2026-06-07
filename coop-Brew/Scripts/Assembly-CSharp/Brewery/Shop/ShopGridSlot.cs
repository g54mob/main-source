using System;
using Unity.Collections;
using Unity.Netcode;

namespace Brewery.Shop
{
	[Serializable]
	public struct ShopGridSlot : INetworkSerializable, IEquatable<ShopGridSlot>
	{
		public FixedString64Bytes itemId;

		public int quantity;

		public bool IsEmpty => false;

		public static ShopGridSlot Empty => default(ShopGridSlot);

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public bool Equals(ShopGridSlot other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
