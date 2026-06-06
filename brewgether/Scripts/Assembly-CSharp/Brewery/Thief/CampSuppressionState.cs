using System;
using Unity.Netcode;

namespace Brewery.Thief
{
	[Serializable]
	public struct CampSuppressionState : INetworkSerializable
	{
		public bool isSuppressed;

		public int suppressionEndDayIndex;

		public bool playersHaveLeft;

		public int suppressionStartDayIndex;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public static CampSuppressionState CreateSuppressed(int currentDayIndex, int suppressionDays)
		{
			return default(CampSuppressionState);
		}

		public static CampSuppressionState CreateDefault()
		{
			return default(CampSuppressionState);
		}

		public bool HasSuppressionEnded(int currentDayIndex)
		{
			return false;
		}

		public int GetRemainingDays(int currentDayIndex)
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
