using System;
using Factory.Mech;
using Models;
using UnityEngine;

namespace Factory.FieldData
{
	[Serializable]
	public class SerializableMechBase
	{
		[SerializeField]
		private Vector2Int addr;

		public int[] intArray;

		public double[] doubleArray;

		public StructureAddr Addr
		{
			get
			{
				return default(StructureAddr);
			}
			set
			{
			}
		}

		public SerializableMechBase(MechBase mb)
		{
		}

		public static void Restore(SerializableMechBase from, MechBase to)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
