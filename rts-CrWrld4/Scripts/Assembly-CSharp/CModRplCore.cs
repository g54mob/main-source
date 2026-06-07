using System.Collections.Generic;
using UnityEngine;
using mattmc3.dotmore.Collections.Generic;

public class CModRplCore : RplCore
{
	private bool refreshTerrain;

	private EditTerrainRangeIndicator editTerrainRangeIndicator;

	public int maxLastCommandCount;

	public int lastCommandCount;

	public int minLastCommandCount;

	public ConsoleScriptRow consoleScriptRow;

	private static bool[] stargs;

	public CModRplCore(CModUnitManager baseUnit, string scriptName)
		: base(null, null)
	{
	}

	public override void CommandsFinished(int commandCount)
	{
	}

	public override void HandleUnitCommands(Command command)
	{
	}

	private void DeleteMCSEntry(int missionID)
	{
	}

	private Data GetMCSEntriesList()
	{
		return null;
	}

	private (int, string) GetEntryFromMetaData(string guid, List<ColonySector.MapEntry> metaData)
	{
		return default((int, string));
	}

	private List<ColonySector.MapEntry> GetLastMetaData()
	{
		return null;
	}

	private bool[] FloodFillTerrain(int startCell, int minTerrainHeight, int maxTerrainHeight, int fillLimit, out List<Data> list)
	{
		list = null;
		return null;
	}

	private bool CheckTerrainCell(byte[] terrain, int cell, int minTerrainHeight, int maxTerrainHeight)
	{
		return false;
	}

	private void RefreshEditTerrainRangeIndicator(int radius, bool square, bool squareWhenZero, Vector3 pos)
	{
	}

	private void CreateEditTerrainRangeIndicator()
	{
	}

	public void DestroyEditTerrainRangeIndicator()
	{
	}

	private Vector3 RandomPointInRange(Vector3 position, Vector3 normal, float radius)
	{
		return default(Vector3);
	}

	private static void SetPixelsRaw(int x, int y, int bwidth, int bheight, List<Data> block, Texture2D tex)
	{
	}

	private static void SetRectPixelsRaw(int x, int y, int width, int height, Color color, Texture2D tex)
	{
	}

	private static void ClearPixels(Color color, Texture2D tex)
	{
	}

	public static UnitManager GetNearestSpecialTarget(Vector4 specialTarget, float RNG, Vector3 startPos, bool checkIsBuilding)
	{
		return null;
	}

	public static List<Data> GetSpecialTargets(Vector4 specialTarget, float RNG, Vector3 startPos, bool checkIsBuilding)
	{
		return null;
	}

	private CMod GetCModFromName(string s)
	{
		return null;
	}

	private UnitManager CreateUnit(string s0, Vector3 pos, OrderedDictionary2<string, Data> initParams)
	{
		return null;
	}

	public static GameObject CreateEffect(string effectName, Vector3 pos, Vector3 scale)
	{
		return null;
	}

	private List<Data> GetUnitsByType(string unitType, int buildState)
	{
		return null;
	}

	private List<Data> GetUnitsInRange(string unitType, Vector3 startPos, float range, bool isSquare, bool is3D, bool requiresLOS, int enemyState, int buildState, int imperviousState)
	{
		return null;
	}

	private List<Data> GetUnitsInRange(Vector3 startPos, float range, bool isSquare, bool is3D, bool requiresLOS, int enemyState, int buildState, int imperviousState)
	{
		return null;
	}
}
