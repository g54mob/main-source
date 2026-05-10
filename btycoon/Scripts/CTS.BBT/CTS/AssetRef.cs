using System;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public struct AssetRef<T> : IEquatable<AssetRef<T>> where T : UnityEngine.Object
	{
		public T Asset { get; private set; }

		public AssetRef(T obj)
		{
			Asset = obj;
		}

		public static implicit operator AssetRef<T>(T obj)
		{
			return new AssetRef<T>(obj);
		}

		public bool Equals(AssetRef<T> other)
		{
			return Asset == other.Asset;
		}

		public override bool Equals(object obj)
		{
			if (obj is AssetRef<T> other)
			{
				return Equals(other);
			}
			return ((ValueType)this).Equals(obj);
		}

		public override int GetHashCode()
		{
			if ((object)Asset != null)
			{
				return Asset.GetHashCode();
			}
			return 0;
		}
	}
}
