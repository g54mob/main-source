using System;
using System.Collections.Generic;
using Libs;
using Models;
using ScriptableObjects.ScriptableObjectScripts.Tile;
using UnityEngine;

namespace Factory.FieldData
{
	public class StructurePack
	{
		public readonly Structure[] Structures;

		public readonly eMachine MachineID;

		public readonly MstMachineDataEntities MstMachineData;

		public StructurePack(TileDetailPack tileDetailPack, StructureAddition addition, Vector2IntBundle addr, StructureAddr? offset = null, Version saveMapVersion = null)
		{
		}

		public RectInt GetAddrRect()
		{
			return default(RectInt);
		}

		public List<StructureAddr> GetAddrs()
		{
			return null;
		}

		public void AddAdditionMinion(int minionNum)
		{
		}

		public bool IsEmpty()
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
