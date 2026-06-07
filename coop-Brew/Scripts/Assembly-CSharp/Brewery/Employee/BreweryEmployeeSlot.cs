using System;
using Brewery.Core;
using Unity.Collections;
using Unity.Netcode;

namespace Brewery.Employee
{
	[Serializable]
	public struct BreweryEmployeeSlot : INetworkSerializable, IEquatable<BreweryEmployeeSlot>
	{
		public bool isHired;

		public bool isOnStrike;

		private FixedString64Bytes employeeNameFixed;

		public float hireCost;

		public float dailySalary;

		public float movementSpeed;

		public float workEfficiency;

		public int profileIndex;

		public ulong employeeNPCNetworkId;

		public int daysUnpaid;

		public int daysSinceLastPayment;

		public int beerLevel;

		public int wineLevel;

		public int spiritsLevel;

		public byte personalityType;

		public ushort experiencePoints;

		public byte masteryLevel;

		public byte equippedPerks;

		public string employeeName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float TotalOwed => 0f;

		public BeverageType Specialization => default(BeverageType);

		public BreweryEmployeePersonality Personality
		{
			get
			{
				return default(BreweryEmployeePersonality);
			}
			set
			{
			}
		}

		public bool IsTrackLocked(int trackIndex)
		{
			return false;
		}

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public bool Equals(BreweryEmployeeSlot other)
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
