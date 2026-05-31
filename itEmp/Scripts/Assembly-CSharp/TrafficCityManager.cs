using System.Collections.Generic;
using UnityEngine;

public class TrafficCityManager : MonoBehaviour
{
	public static bool EditorMode;

	private static Dictionary<int, TrafficCityPoint> pointById;

	[ContextMenu("Re-initialize")]
	public void ReInit()
	{
	}

	public static void BuildPointDictionary()
	{
	}

	public static TrafficCityPoint FindPointById(int id)
	{
		return null;
	}
}
