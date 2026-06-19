using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using PugTilemap;
using PugWorldGen.CoreKeeper;
using UnityEngine;

namespace WorldGen
{
	[CreateAssetMenu(menuName = "Pug/World Gen/CoreKeeper/Tile Type Mapping", fileName = "TileTypeMapping", order = 4)]
	public class TileTypeMapping : ScriptableObject
	{
		public enum FlagState
		{
			Any = 0,
			True = 1,
			False = 2
		}

		public enum ResourceIndex
		{
			Any = 0,
			None = 1,
			Resource1 = 2,
			Resource2 = 3,
			Resource3 = 4,
			Resource4 = 5,
			Resource5 = 6
		}

		[Serializable]
		public struct MappingResult
		{
			public PugTilemap.TileType tileType;

			public Tileset tileset;
		}

		[Serializable]
		public struct MappingRule
		{
			public PugWorldGen.CoreKeeper.Biome biome;

			public PugWorldGen.CoreKeeper.TileType proceduralTileType;

			public FlagState floorFlag;

			public FlagState roofHoleFlag;

			public FlagState greatWallFlag;

			public ResourceIndex resourceIndex;

			public MappingResult outputTile;
		}

		[ArrayElementTitle("tileTypeMappingRules")]
		public List<MappingRule> mapping;
	}
}
