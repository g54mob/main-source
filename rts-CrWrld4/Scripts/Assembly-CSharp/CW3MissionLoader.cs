using System.Collections.Generic;
using System.Xml;

public class CW3MissionLoader
{
	public class CW3EmitterData
	{
		public int cellX;

		public int cellY;

		public int amt;

		public int interval;
	}

	public class CW3OreDepositData
	{
		public int cellX;

		public int cellY;
	}

	public class CW3TotemData
	{
		public int cellX;

		public int cellY;
	}

	public class CW3SporeTowerData
	{
		public int cellX;

		public int cellY;
	}

	public class CW3RunnerNestData
	{
		public int cellX;

		public int cellY;
	}

	public class CW3AETowerData
	{
		public int cellX;

		public int cellY;
	}

	public static int[] terrain;

	public static int[] digitalisData;

	public static bool[] digitalisGrowthData;

	public static int gsw;

	public static int gsh;

	public static List<CW3EmitterData> emitters;

	public static List<CW3OreDepositData> oreDeposits;

	public static List<CW3TotemData> totems;

	public static List<CW3SporeTowerData> sporeTowers;

	public static List<CW3RunnerNestData> runnerNests;

	public static List<CW3AETowerData> aeTowers;

	public static void Clear()
	{
	}

	public static void LoadMission(string fileName, bool calculateGUID = true)
	{
	}

	public static void LoadMission(byte[] compressedData, bool calculateGUID = true)
	{
	}

	private static void TerrainReadXML(XmlNode node)
	{
	}

	public static byte[] ReadData(string dataName, bool compressed = true)
	{
		return null;
	}

	public static byte[] ReadData(string dataName, bool compressed, bool encrypted)
	{
		return null;
	}
}
