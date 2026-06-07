using System;
using System.Collections.Generic;
using DV.Items;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Junctions/JunctionGeneratedDataRuntime")]
public class JunctionGeneratedDataRuntime : ScriptableObject
{
	[Serializable]
	public struct DataCoord
	{
		public Junction.JunctionData data;

		public Vector2Int coord;
	}

	[Serializable]
	public struct JunctionPageData
	{
		public int pageNumber;

		public string categoryId;

		public List<DataCoord> junctionDataCoords;

		public JunctionPageData CreateCopy()
		{
			return new JunctionPageData
			{
				pageNumber = pageNumber,
				categoryId = categoryId,
				junctionDataCoords = new List<DataCoord>(junctionDataCoords)
			};
		}
	}

	public Junction.JunctionData[] junctionData;

	public JunctionPageData[] junctionPageDataWorld;

	public JunctionPageData[] junctionPageDataStations;

	public Vector2Int junctionWorldGridSize;

	public Vector2Int junctionStationGridSize;

	public bool dataDirty = true;

	public void UpdateData(Junction.JunctionData[] data)
	{
		if (Application.isPlaying || !Application.isEditor)
		{
			throw new OperationCanceledException("JunctionGeneratedDataRuntime: Cannot update junction data in play mode or outside of the editor.");
		}
	}

	public void SaveRuntimePageData(JunctionPageData[] worldPageData, JunctionPageData[] stationPageData)
	{
		if (Application.isPlaying || !Application.isEditor)
		{
			throw new OperationCanceledException("JunctionGeneratedDataRuntime: Cannot save junction data in play mode or outside of the editor.");
		}
	}

	public JunctionPageData[] GetPageData(JunctionMap.JunctionMapType junctionMapType)
	{
		switch (junctionMapType)
		{
		case JunctionMap.JunctionMapType.World:
		{
			JunctionPageData[] array3 = new JunctionPageData[junctionPageDataWorld.Length];
			for (int l = 0; l < junctionPageDataWorld.Length; l++)
			{
				array3[l] = junctionPageDataWorld[l].CreateCopy();
			}
			return array3;
		}
		case JunctionMap.JunctionMapType.Station:
		{
			JunctionPageData[] array2 = new JunctionPageData[junctionPageDataStations.Length];
			for (int k = 0; k < junctionPageDataStations.Length; k++)
			{
				array2[k] = junctionPageDataStations[k].CreateCopy();
			}
			return array2;
		}
		case JunctionMap.JunctionMapType.All:
		{
			JunctionPageData[] array = new JunctionPageData[junctionPageDataWorld.Length + junctionPageDataStations.Length];
			for (int i = 0; i < junctionPageDataWorld.Length; i++)
			{
				array[i] = junctionPageDataWorld[i].CreateCopy();
			}
			for (int j = 0; j < junctionPageDataStations.Length; j++)
			{
				array[junctionPageDataWorld.Length + j] = junctionPageDataStations[j].CreateCopy();
			}
			return array;
		}
		default:
			Debug.LogError(string.Format("{0}: Requested page data for unhandled map type: {1}.", "JunctionGeneratedDataRuntime", junctionMapType));
			return null;
		}
	}

	public Vector2Int GetMapGridSize(JunctionMap.JunctionMapType junctionMapType)
	{
		switch (junctionMapType)
		{
		case JunctionMap.JunctionMapType.Station:
			return junctionStationGridSize;
		case JunctionMap.JunctionMapType.World:
			return junctionWorldGridSize;
		default:
			Debug.LogError(string.Format("{0}: Requested grid size for unhandled map type: {1}.", "JunctionGeneratedDataRuntime", junctionMapType));
			return Vector2Int.zero;
		}
	}
}
