using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class FurnitureClusterEditor : MonoBehaviour
{
	[Header("Current")]
	public FurnitureCluster cluster;

	public List<FurnitureCluster.FurnitureClusterRule> clusterElements;

	[Header("Components")]
	public Transform furnitureParent;

	public List<WalkableRecorder.TileSetup> tiles;

	public List<ClusterEditorFurniture> spawnedFurniture;

	[Button(null, EButtonEnableMode.Always)]
	public void ScanTilesForFurniture()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void SpawnAlternateFurniture()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void LoadCluster()
	{
	}

	private Vector2 RotateVector2CW(Vector2 v, float degrees)
	{
		return default(Vector2);
	}

	private FurniturePreset GetRandomFurnitureForElement(FurnitureCluster.FurnitureClusterRule inputElement)
	{
		return null;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void SaveToCluster()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ClearAllFurniture()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ClearClusterList()
	{
	}

	private int GetAngleForFurnitureFacing(FurnitureCluster.FurnitureFacing facing)
	{
		return 0;
	}

	private FurnitureCluster.FurnitureFacing GetFacingForFurnitureAngle(float angle)
	{
		return default(FurnitureCluster.FurnitureFacing);
	}
}
