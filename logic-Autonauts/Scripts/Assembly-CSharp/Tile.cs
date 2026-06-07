using System.Collections.Generic;
using UnityEngine;

public class Tile
{
	public enum TileType
	{
		Empty = 0,
		Soil = 1,
		SoilTilled = 2,
		SoilHole = 3,
		SoilUsed = 4,
		SoilDung = 5,
		WaterShallow = 6,
		WaterDeep = 7,
		SeaWaterShallow = 8,
		SeaWaterDeep = 9,
		Sand = 10,
		Dredged = 11,
		Swamp = 12,
		IronHidden = 13,
		IronSoil = 14,
		IronSoil2 = 15,
		Iron = 16,
		IronUsed = 17,
		ClayHidden = 18,
		ClaySoil = 19,
		Clay = 20,
		ClayUsed = 21,
		CoalHidden = 22,
		CoalSoil = 23,
		CoalSoil2 = 24,
		CoalSoil3 = 25,
		Coal = 26,
		CoalUsed = 27,
		StoneHidden = 28,
		StoneSoil = 29,
		Stone = 30,
		StoneUsed = 31,
		Raised = 32,
		Building = 33,
		Trees = 34,
		CropWheat = 35,
		CropCotton = 36,
		Weeds = 37,
		Grass = 38,
		Decoration1 = 39,
		Decoration2 = 40,
		Decoration3 = 41,
		Decoration4 = 42,
		Decoration5 = 43,
		Decoration6 = 44,
		Decoration7 = 45,
		Decoration8 = 46,
		Decoration9 = 47,
		Decoration10 = 48,
		Decoration11 = 49,
		Decoration12 = 50,
		Decoration13 = 51,
		Decoration14 = 52,
		Decoration15 = 53,
		Decoration16 = 54,
		Decoration17 = 55,
		Decoration18 = 56,
		Decoration19 = 57,
		Decoration20 = 58,
		Decoration21 = 59,
		Decoration22 = 60,
		Decoration23 = 61,
		Decoration24 = 62,
		Decoration25 = 63,
		Decoration26 = 64,
		Decoration27 = 65,
		Decoration28 = 66,
		Decoration29 = 67,
		Decoration30 = 68,
		Decoration31 = 69,
		Decoration32 = 70,
		Total = 71
	}

	public static float m_Size = 3f;

	public static TileInfo[] m_TileInfo = new TileInfo[71]
	{
		new TileInfo(false, false, 0, "TileEmpty", 0f, "", new Color32(129, 216, 0, byte.MaxValue), false, 0, 0f, 240),
		new TileInfo(false, false, 6, "TileSoil", 0.05f, "IconTileSoil", new Color32(188, 129, 28, byte.MaxValue), false, 0, 0f, 248),
		new TileInfo(false, false, 4, "TileSoilTilled", 0f, "IconTileSoilTilled", new Color32(120, 60, 13, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 7, "TileSoilHole", 0f, "IconTileSoilHole", new Color32(181, 93, 23, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 8, "TileSoilUsed", 0f, "IconTileSoil", new Color32(207, 104, 27, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 20, "TileSoilDung", 0f, "IconTileSoil", new Color32(149, 127, 8, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 9, "TileWaterShallow", 0.05f, "IconWater", new Color32(192, 212, byte.MaxValue, byte.MaxValue), false, 0, 0f, 232),
		new TileInfo(false, true, 10, "TileWaterDeep", 0.05f, "IconWater", new Color32(70, 78, byte.MaxValue, byte.MaxValue), false, 0, 0f, 236),
		new TileInfo(false, false, 11, "TileSeaWaterShallow", 0.05f, "IconSeaWater", new Color32(155, byte.MaxValue, byte.MaxValue, byte.MaxValue), false, 0, 0f, 208),
		new TileInfo(false, true, 12, "TileSeaWaterDeep", 0.05f, "IconSeaWater", new Color32(27, 245, 180, byte.MaxValue), false, 0, 0f, 212),
		new TileInfo(false, false, 13, "TileSand", 0.05f, "IconSand", new Color32(byte.MaxValue, 246, 48, byte.MaxValue), false, 0, 0f, 244),
		new TileInfo(false, false, 16, "TileDredged", 0.05f, "IconTileDredged", new Color32(150, 128, 37, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 17, "TileSwamp", 0.2f, "IconTileSwamp", new Color32(127, 235, 150, byte.MaxValue), false, 0, 0f, 228),
		new TileInfo(false, false, 19, "TileIronHidden", 0f, "IconTileIronSoil", new Color32(129, 216, 0, byte.MaxValue), true, 0, 0f, 0),
		new TileInfo(false, false, 29, "TileIronSoil", 0f, "IconTileIronSoil", new Color32(154, 146, 121, byte.MaxValue), true, 0, 0f, 176),
		new TileInfo(false, false, 30, "TileIronSoil2", 0f, "IconTileIronSoil", new Color32(154, 146, 121, byte.MaxValue), true, 0, 0f, 180),
		new TileInfo(false, false, 31, "TileIron", 0f, "IconTileIronSoil", new Color32(154, 146, 121, byte.MaxValue), false, 20, 600f, 184),
		new TileInfo(false, false, 1, "TileIronUsed", 0f, "IconTileIronSoil", new Color32(149, 167, 170, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 19, "TileClayHidden", 0f, "IconTileClaySoil", new Color32(129, 216, 0, byte.MaxValue), true, 0, 0f, 0),
		new TileInfo(false, false, 14, "TileClaySoil", 0f, "IconTileClaySoil", new Color32(216, 83, 17, byte.MaxValue), true, 0, 0f, 252),
		new TileInfo(false, false, 15, "TileClay", 0.05f, "IconTileClaySoil", new Color32(216, 83, 17, byte.MaxValue), false, 20, 600f, 224),
		new TileInfo(false, false, 1, "TileClayUsed", 0.05f, "IconTileClaySoil", new Color32(246, 115, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 19, "TileCoalHidden", 0f, "IconTileCoalSoil", new Color32(129, 216, 0, byte.MaxValue), true, 0, 0f, 0),
		new TileInfo(false, false, 25, "TileCoalSoil", 0f, "IconTileCoalSoil", new Color32(32, 32, 32, byte.MaxValue), true, 0, 0f, 192),
		new TileInfo(false, false, 26, "TileCoalSoil2", 0f, "IconTileCoalSoil", new Color32(32, 32, 32, byte.MaxValue), true, 0, 0f, 196),
		new TileInfo(false, false, 27, "TileCoalSoil3", 0f, "IconTileCoalSoil", new Color32(32, 32, 32, byte.MaxValue), true, 0, 0f, 200),
		new TileInfo(false, false, 28, "TileCoal", 0f, "IconTileCoalSoil", new Color32(32, 32, 32, byte.MaxValue), false, 100, 600f, 204),
		new TileInfo(false, false, 1, "TileCoalUsed", 0f, "IconTileCoalSoil", new Color32(32, 32, 32, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 19, "TileStoneHidden", 0f, "IconTileStoneSoil", new Color32(129, 216, 0, byte.MaxValue), true, 0, 0f, 0),
		new TileInfo(false, false, 23, "TileStoneSoil", 0f, "IconTileStoneSoil", new Color32(147, 127, 101, byte.MaxValue), true, 0, 0f, 216),
		new TileInfo(false, false, 24, "TileStone", 0f, "IconTileStoneSoil", new Color32(147, 127, 101, byte.MaxValue), false, 20, 600f, 220),
		new TileInfo(false, false, 1, "TileStoneUsed", 0f, "IconTileStoneSoil", new Color32(149, 167, 170, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 1, "TileRaised", 0f, "", new Color32(33, 32, 32, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 22, "TileBuilding", 0f, "", new Color32(32, 32, 32, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 6, "TileTrees", 0f, "", new Color32(181, 93, 23, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(true, false, 2, "TileCropWheat", 0f, "", new Color32(211, 161, 100, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(true, false, 2, "TileCropCotton", 0f, "", new Color32(211, 160, 100, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 1, "TileWeeds", 0f, "", new Color32(149, 127, 8, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 5, "TileGrass", 0f, "", new Color32(147, 235, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 32, "TileDecoration1", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 33, "TileDecoration2", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 34, "TileDecoration3", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 35, "TileDecoration4", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 36, "TileDecoration5", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 37, "TileDecoration6", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 38, "TileDecoration7", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 39, "TileDecoration8", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 40, "TileDecoration9", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 41, "TileDecoration10", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 42, "TileDecoration11", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 43, "TileDecoration12", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 44, "TileDecoration13", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 45, "TileDecoration14", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 46, "TileDecoration15", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 47, "TileDecoration16", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 48, "TileDecoration17", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 49, "TileDecoration18", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 50, "TileDecoration19", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 51, "TileDecoration20", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 52, "TileDecoration21", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 53, "TileDecoration22", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 54, "TileDecoration23", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 55, "TileDecoration24", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 56, "TileDecoration25", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 57, "TileDecoration26", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 58, "TileDecoration27", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 59, "TileDecoration28", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 60, "TileDecoration29", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 61, "TileDecoration30", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 62, "TileDecoration31", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0),
		new TileInfo(false, false, 63, "TileDecoration32", 0f, "", new Color32(0, 0, 0, byte.MaxValue), false, 0, 0f, 0)
	};

	public TileType m_TileType;

	public float m_Timer;

	public Building m_Building;

	public Building m_BuildingFootprint;

	public Building m_Floor;

	public Farmer m_Farmer;

	public BaseClass m_AssociatedObject;

	public TileCoordObject m_MiscObject;

	public bool m_Checked;

	public WalledArea m_WalledArea;

	public static float m_WeededDelay = 200f;

	public static float m_GrassGrowingDelay = 5f;

	private static Dictionary<string, TileType> m_NamesToTypes;

	public static Dictionary<TileType, int> m_HiddenTypes;

	public static Dictionary<TileType, int> m_StoneTypes;

	public static Dictionary<TileType, int> m_ClayTypes;

	public static Dictionary<TileType, int> m_IronTypes;

	public static Dictionary<TileType, int> m_CoalTypes;

	public static void Init()
	{
		m_NamesToTypes = new Dictionary<string, TileType>();
		for (int i = 0; i < 71; i++)
		{
			TileType value = (TileType)i;
			m_NamesToTypes.Add(m_TileInfo[i].m_Name, value);
		}
		m_HiddenTypes = new Dictionary<TileType, int>();
		m_HiddenTypes.Add(TileType.ClayHidden, 0);
		m_HiddenTypes.Add(TileType.CoalHidden, 0);
		m_HiddenTypes.Add(TileType.IronHidden, 0);
		m_StoneTypes = new Dictionary<TileType, int>();
		m_StoneTypes.Add(TileType.StoneSoil, 0);
		m_StoneTypes.Add(TileType.Stone, 0);
		m_ClayTypes = new Dictionary<TileType, int>();
		m_ClayTypes.Add(TileType.ClaySoil, 0);
		m_ClayTypes.Add(TileType.Clay, 0);
		m_IronTypes = new Dictionary<TileType, int>();
		m_IronTypes.Add(TileType.IronSoil, 0);
		m_IronTypes.Add(TileType.IronSoil2, 0);
		m_IronTypes.Add(TileType.Iron, 0);
		m_CoalTypes = new Dictionary<TileType, int>();
		m_CoalTypes.Add(TileType.CoalSoil, 0);
		m_CoalTypes.Add(TileType.CoalSoil2, 0);
		m_CoalTypes.Add(TileType.CoalSoil3, 0);
		m_CoalTypes.Add(TileType.Coal, 0);
	}

	public static bool GetIsSolid(TileType NewType)
	{
		return m_TileInfo[(int)NewType].m_Solid;
	}

	public bool GetContainsObject()
	{
		if ((bool)m_Building || (bool)m_BuildingFootprint || (bool)m_Floor || (bool)m_AssociatedObject || (bool)m_MiscObject)
		{
			return true;
		}
		return false;
	}

	public static TileType GetTypeFromName(string Name)
	{
		if (Name == "")
		{
			return TileType.Total;
		}
		return m_NamesToTypes[Name];
	}

	public static string GetNameFromType(TileType NewType)
	{
		return m_TileInfo[(int)NewType].m_Name;
	}

	public static Sprite GetIcon(TileType NewType)
	{
		switch (NewType)
		{
		case TileType.Total:
			return null;
		case TileType.Empty:
			return (Sprite)Resources.Load("Textures/Hud/GenIcons/GenIconTurf", typeof(Sprite));
		default:
			return (Sprite)Resources.Load("Textures/Hud/Icons/" + m_TileInfo[(int)NewType].m_IconName, typeof(Sprite));
		}
	}
}
