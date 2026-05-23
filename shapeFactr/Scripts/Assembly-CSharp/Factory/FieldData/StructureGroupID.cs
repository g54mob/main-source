using System;
using Models;
using UnityEngine;

namespace Factory.FieldData
{
	public struct StructureGroupID : IEquatable<StructureGroupID>
	{
		private readonly StructureAddr addr;

		public StructureAddr TypicalAddr => default(StructureAddr);

		public StructureGroupID(StructureAddr addr)
		{
			this.addr = default(StructureAddr);
		}

		[Obsolete]
		public StructureGroupID(Structure[] structures)
		{
			addr = default(StructureAddr);
		}

		public StructureGroupID(RectInt rectInt)
		{
			addr = default(StructureAddr);
		}

		public bool Equals(StructureGroupID other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
