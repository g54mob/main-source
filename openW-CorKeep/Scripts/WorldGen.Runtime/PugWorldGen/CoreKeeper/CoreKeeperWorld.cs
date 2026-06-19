using UnityEngine;

namespace PugWorldGen.CoreKeeper
{
	[CreateAssetMenu(menuName = "Pug/World Gen/CoreKeeper/World", fileName = "CoreKeeper World", order = 2)]
	public class CoreKeeperWorld : PugWorld
	{
		private static readonly TileType[] s_tileTypes = new TileType[21]
		{
			TileType.None,
			TileType.Pit,
			TileType.Water,
			TileType.Dirt,
			TileType.Turf,
			TileType.Clay,
			TileType.Stone,
			TileType.Sand,
			TileType.Forest,
			TileType.Desert,
			TileType.Sea,
			TileType.Resource,
			TileType.Crystal,
			TileType.Passage,
			TileType.ExplosiveWall,
			TileType.Excavation,
			TileType.ExcavationReinforced,
			TileType.ExcavationBorder,
			TileType.ExcavationVoid,
			TileType.ExcavationLava,
			TileType.ExcavationLavaBorder
		};

		private static readonly Biome[] s_biomes = new Biome[10]
		{
			Biome.None,
			Biome.Dirt,
			Biome.Clay,
			Biome.Stone,
			Biome.Forest,
			Biome.Desert,
			Biome.Sea,
			Biome.Crystal,
			Biome.Passage,
			Biome.Excavation
		};

		public static int tileTypeCount => 21;

		public static int biomeCount => 10;

		public static TileType GetTileType(int index)
		{
			return s_tileTypes[index];
		}

		public static bool TryGetTileType(int index, out TileType tileType)
		{
			if (index < tileTypeCount)
			{
				tileType = s_tileTypes[index];
				return true;
			}
			tileType = TileType.None;
			return false;
		}

		public static Biome GetBiome(int index)
		{
			return s_biomes[index];
		}

		public static bool TryGetBiome(int index, out Biome biome)
		{
			if (index < biomeCount)
			{
				biome = s_biomes[index];
				return true;
			}
			biome = Biome.None;
			return false;
		}

		public static bool TryGetTileType(Color32 color, out TileType tileType)
		{
			tileType = TileType.None;
			switch (color.HashRGB())
			{
			case 2039583:
				tileType = TileType.Pit;
				return true;
			case 8469790:
				tileType = TileType.Water;
				return true;
			case 2574689:
				tileType = TileType.Dirt;
				return true;
			case 5334854:
				tileType = TileType.Turf;
				return true;
			case 3564737:
				tileType = TileType.Clay;
				return true;
			case 8218441:
				tileType = TileType.Stone;
				return true;
			case 3837868:
				tileType = TileType.Sand;
				return true;
			case 1803030:
				tileType = TileType.Forest;
				return true;
			case 8954563:
				tileType = TileType.Desert;
				return true;
			case 12698090:
				tileType = TileType.Sea;
				return true;
			case 5726445:
				tileType = TileType.Resource;
				return true;
			case 15589207:
				tileType = TileType.Crystal;
				return true;
			case 5992796:
				tileType = TileType.Passage;
				return true;
			case 1579227:
				tileType = TileType.ExplosiveWall;
				return true;
			case 4217722:
				tileType = TileType.Excavation;
				return true;
			case 3034181:
				tileType = TileType.ExcavationReinforced;
				return true;
			case 3946519:
				tileType = TileType.ExcavationBorder;
				return true;
			case 16711845:
				tileType = TileType.ExcavationVoid;
				return true;
			case 26367:
				tileType = TileType.ExcavationLava;
				return true;
			case 1650511:
				tileType = TileType.ExcavationLavaBorder;
				return true;
			default:
				return false;
			}
		}

		protected override float GetTileSizeInternal()
		{
			return 1f;
		}

		protected override Color GetExplorerBackgroundColorInternal()
		{
			return new Color(0.5019608f, 0.5019608f, 0.5019608f);
		}
	}
}
