using System;
using Unity.Collections;
using Unity.Netcode;

namespace Port
{
	[Serializable]
	public struct DockedShipState : INetworkSerializable, IEquatable<DockedShipState>
	{
		public int ShipId;

		public int DockIndex;

		public FixedString64Bytes ShipName;

		public int ArrivalDay;

		public float ArrivalHour;

		public int StayDuration;

		public float DepartureHour;

		public bool HasDeparted;

		public int DepartureDay => 0;

		public bool ShouldDepart(int currentDay, float currentNormalizedTime)
		{
			return false;
		}

		public bool DepartsToday(int currentDay)
		{
			return false;
		}

		public bool DepartsTomorrow(int currentDay)
		{
			return false;
		}

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public bool Equals(DockedShipState other)
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

		public static bool operator ==(DockedShipState left, DockedShipState right)
		{
			return false;
		}

		public static bool operator !=(DockedShipState left, DockedShipState right)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
