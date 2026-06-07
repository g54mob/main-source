using System;
using Unity.Collections;
using Unity.Netcode;

namespace Brewery.Employee
{
	[Serializable]
	public struct EmployeeSlot : INetworkSerializable, IEquatable<EmployeeSlot>
	{
		public bool isHired;

		public bool hasQuit;

		private FixedString64Bytes employeeNameFixed;

		public int shiftStartHour;

		public int shiftEndHour;

		public float hireCost;

		public float dailySalary;

		public float movementSpeed;

		public float servingTime;

		public ulong employeeNPCNetworkId;

		public ulong assignedBarNetworkId;

		public int daysUnpaid;

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

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public bool Equals(EmployeeSlot other)
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
