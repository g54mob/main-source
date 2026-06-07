using System;
using Models;
using UnityEngine;

namespace Factory.FieldData
{
	[Serializable]
	public class SerializableStructureContext
	{
		[SerializeField]
		private Vector2Int addr;

		public double createTime;

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

		public SerializableStructureContext(Structure str)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
