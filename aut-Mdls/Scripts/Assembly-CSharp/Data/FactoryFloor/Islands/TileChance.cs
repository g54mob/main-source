using System;
using Data.Operator;
using UnityEngine;

namespace Data.FactoryFloor.Islands
{
	[Serializable]
	public class TileChance
	{
		[Range(0.01f, 1f)]
		public float Chance = 1f;

		public FactoryObjectData Tile;
	}
}
