using System;
using Unity.Collections;
using Unity.Netcode;

namespace Brewery.Buffs
{
	[Serializable]
	public struct ActiveBuff : INetworkSerializable, IEquatable<ActiveBuff>
	{
		public BuffType type;

		public FixedString64Bytes catalystId;

		public float potency;

		public float remainingTime;

		public float totalDuration;

		public float NormalizedTimeRemaining => 0f;

		public bool IsExpired => false;

		public string CatalystIdString => null;

		public static ActiveBuff FromEffect(CatalystEffectData effect)
		{
			return default(ActiveBuff);
		}

		public ActiveBuff WithRefreshedDuration()
		{
			return default(ActiveBuff);
		}

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public bool Equals(ActiveBuff other)
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

		public static bool operator ==(ActiveBuff left, ActiveBuff right)
		{
			return false;
		}

		public static bool operator !=(ActiveBuff left, ActiveBuff right)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
