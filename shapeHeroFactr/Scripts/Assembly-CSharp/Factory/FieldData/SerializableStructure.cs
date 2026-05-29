using System;
using Models;
using UnityEngine;

namespace Factory.FieldData
{
	[Serializable]
	public class SerializableStructure
	{
		public string eMachine;

		[SerializeField]
		private Vector2Int addr;

		public string partsName;

		public string rot;

		[SerializeField]
		private Vector2Int structureGroupID;

		public StructureAddition structureAddition;

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

		public StructureAddr? StructureGroupID
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SerializableStructure(Structure str)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
