using System.Collections.Generic;
using UnityEngine;

public class GameMap
{
	public class MapInhibitor
	{
		public int gameSpaceX;

		public int gameSpaceY;

		public MapInhibitor(int gameSpaceX, int gameSpaceY)
		{
		}
	}

	public class MapEmitter
	{
		public int gameSpaceX;

		public int gameSpaceY;

		public int baseAmt;

		public int productionInterval;

		public MapEmitter(int gameSpaceX, int gameSpaceY, int baseAmt, int productionInterval)
		{
		}
	}

	public class MapRunnerNest
	{
		public int gameSpaceX;

		public int gameSpaceY;

		public MapRunnerNest(int gameSpaceX, int gameSpaceY)
		{
		}
	}

	public class MapBlobNest
	{
		public int gameSpaceX;

		public int gameSpaceY;

		public int orientation;

		public MapBlobNest(int gameSpaceX, int gameSpaceY, int orientation)
		{
		}
	}

	public class MapAirSac
	{
		public int gameSpaceX;

		public int gameSpaceY;

		public MapAirSac(int gameSpaceX, int gameSpaceY)
		{
		}
	}

	public class MapStash
	{
		public int gameSpaceX;

		public int gameSpaceY;

		public MapStash(int gameSpaceX, int gameSpaceY)
		{
		}
	}

	public class MapSporeTower
	{
		public int gameSpaceX;

		public int gameSpaceY;

		public int initialDelay;

		public int waveInterval;

		public int waveCount;

		public int sporePayload;

		public MapSporeTower(int gameSpaceX, int gameSpaceY, int initialDelay, int waveInterval, int waveCount, int sporePayload)
		{
		}
	}

	public class MapAirExclusionTower
	{
		public int gameSpaceX;

		public int gameSpaceY;

		public int range;

		public MapAirExclusionTower(int gameSpaceX, int gameSpaceY, int range)
		{
		}
	}

	public class MapOreDeposit
	{
		public int gameSpaceX;

		public int gameSpaceY;

		public float productionRate;

		public MapOreDeposit(int gameSpaceX, int gameSpaceY, float productionRate)
		{
		}
	}

	public class MapGreenar
	{
		public int gameSpaceX;

		public int gameSpaceY;

		public MapGreenar(int gameSpaceX, int gameSpaceY)
		{
		}
	}

	public class MapTotem
	{
		public int gameSpaceX;

		public int gameSpaceY;

		public MapTotem(int gameSpaceX, int gameSpaceY)
		{
		}
	}

	public class MapERN
	{
		public int gameSpaceX;

		public int gameSpaceY;

		public bool buried;

		public MapERN(int gameSpaceX, int gameSpaceY, bool buried)
		{
		}
	}

	public class MapResourcePack
	{
		public int gameSpaceX;

		public int gameSpaceY;

		public MapResourcePack(int gameSpaceX, int gameSpaceY)
		{
		}
	}

	public class MapFlipBreeder
	{
		public int gameSpaceX;

		public int gameSpaceY;

		public MapFlipBreeder(int gameSpaceX, int gameSpaceY)
		{
		}
	}

	public int GAMESPACE_WIDTH;

	public int GAMESPACE_HEIGHT;

	public byte[] terrain;

	public int[] terrainTextures;

	public int[] terrainBrightness;

	public bool[] digitalisGrowth;

	public byte[] eco;

	public bool[] occupied;

	public List<MapInhibitor> inhibitors;

	public List<MapEmitter> emitters;

	public List<MapRunnerNest> runnerNests;

	public List<MapBlobNest> blobNests;

	public List<MapAirSac> airSacs;

	public List<MapStash> stashes;

	public List<MapSporeTower> sporeTowers;

	public List<MapAirExclusionTower> airExclusionTowers;

	public List<MapOreDeposit> oreDeposits;

	public List<MapGreenar> greenar;

	public List<MapTotem> totems;

	public List<MapERN> erns;

	public List<MapResourcePack> resourcePacks;

	public List<MapFlipBreeder> flipBreeders;

	public void Load()
	{
	}

	public void Save()
	{
	}

	public static void Finish()
	{
	}

	public Texture2D GeneratePreviewTexture(bool includeEnemies, FilterMode fm = FilterMode.Point)
	{
		return null;
	}
}
