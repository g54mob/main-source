using System.Collections.Generic;
using UnityEngine;

public class TheSpanSector : GalaxySector
{
	public GameObject galaxySystemPrefab;

	private static int SYSTEM_COUNT;

	private static int SECTION_COUNT;

	private static List<string> planetNames;

	public override void Awake()
	{
	}

	private float GetMinDist(Vector4 start, Vector4[] points, int skip)
	{
		return 0f;
	}

	public override void Show(bool zoomToLast)
	{
	}

	public static string GetName(string planetGUID)
	{
		return null;
	}

	public static int GetCompleteCount()
	{
		return 0;
	}
}
