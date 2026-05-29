using System;
using Models;
using UnityEngine;

namespace Factory.FieldData
{
	public static class AddrExtension
	{
		public static readonly Vector2Int TreatNullAddr;

		public static bool AddrIsNull(this Vector2Int self)
		{
			return false;
		}

		public static Structure GetStructure(this StructureAddr self)
		{
			return null;
		}

		public static Structure GetStructure(this StructureAddr? self)
		{
			return null;
		}

		[Obsolete]
		public static StructureAddr[] AroundAddrs(this StructureAddr addr)
		{
			return null;
		}

		public static StructureAddr[] AroundAddrs2(this StructureAddr addr)
		{
			return null;
		}

		public static bool IsNeighbor(this StructureAddr self, StructureAddr other)
		{
			return false;
		}

		public static StructureAddr? ToNullableStructureAddr(this Vector2Int self)
		{
			return null;
		}

		public static Vector2Int ToVector2Int(this StructureAddr? self)
		{
			return default(Vector2Int);
		}
	}
}
