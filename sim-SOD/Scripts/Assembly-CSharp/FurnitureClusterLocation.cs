using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FurnitureClusterLocation : IComparable<FurnitureClusterLocation>
{
	public enum RemoveInteractablesOption
	{
		keep = 0,
		remove = 1,
		moveToStorage = 2
	}

	[Header("Cluster Setup")]
	public Dictionary<NewNode, List<FurnitureLocation>> clusterObjectMap;

	[NonSerialized]
	public List<FurnitureLocation> clusterList;

	public FurnitureCluster cluster;

	public NewNode anchorNode;

	public int angle;

	public float ranking;

	[Header("In-Game")]
	public bool loadedGeometry;

	public FurnitureClusterLocation(NewNode newAnchor, FurnitureCluster newPreset, int newAngle, float newRank)
	{
	}

	public void LoadFurnitureToWorld(bool forceSpawnImmediate = false)
	{
	}

	public void UnloadFurniture(bool removeIntegratedInteractables, RemoveInteractablesOption removeSpawnedInteractables)
	{
	}

	public void DeleteCluster(bool removeIntegratedInteractables, RemoveInteractablesOption removeSpawnedInteractables)
	{
	}

	public void DeleteFurniture(int deleteID, bool removeIntegratedInteractables, RemoveInteractablesOption removeSpawnedInteractables)
	{
	}

	public int CompareTo(FurnitureClusterLocation otherObject)
	{
		return 0;
	}

	public CitySaveData.FurnitureClusterCitySave GenerateSaveData()
	{
		return null;
	}
}
