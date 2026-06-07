using System;
using Brewery.Core;
using Unity.Collections;
using Unity.Netcode;

namespace Brewery.Employee
{
	[Serializable]
	public struct CatalystAssignment : INetworkSerializable, IEquatable<CatalystAssignment>
	{
		public BaseType baseType;

		public FixedString32Bytes catalyst1Id;

		public FixedString32Bytes catalyst2Id;

		public FixedString32Bytes catalyst3Id;

		public bool isActive;

		public int CatalystCount => 0;

		public CatalystAssignment(BaseType baseType, string cat1, string cat2, string cat3)
		{
			this.baseType = default(BaseType);
			catalyst1Id = default(FixedString32Bytes);
			catalyst2Id = default(FixedString32Bytes);
			catalyst3Id = default(FixedString32Bytes);
			isActive = false;
		}

		public bool IsSameRecipe(CatalystAssignment other)
		{
			return false;
		}

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public bool Equals(CatalystAssignment other)
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
