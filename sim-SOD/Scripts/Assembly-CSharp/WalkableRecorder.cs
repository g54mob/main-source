using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class WalkableRecorder : MonoBehaviour
{
	[Serializable]
	public class TileSetup
	{
		public Vector2 offset;

		public Transform trans;
	}

	[Header("Assign")]
	public FurniturePreset furniture;

	public FurnitureClass furnitureClass;

	public Transform furnitureParent;

	[Header("Components")]
	public Transform furnitureAnchor;

	public Transform walkableNodeParent;

	public GameObject walkableObject;

	public List<TileSetup> tiles;

	public Transform blockingParent;

	public Material nonBlockedMaterial;

	public Material blockedMaterial;

	public List<DebugBlockingSelector> blockedDisplay;

	public List<Transform> walkableDisplay;

	public List<SubObjectPlacement> subObjectDisplay;

	[Header("Load Subobjects")]
	public GameObject subObjectPrefab;

	private Vector2[] offsetArrayX8;

	[Button("Load Furniture Object", EButtonEnableMode.Always)]
	public void LoadFurniture()
	{
	}

	[Button("Load Class from Furniture Preset", EButtonEnableMode.Always)]
	public void LoadClass()
	{
	}

	[Button("Load Walkable Nodespace Area", EButtonEnableMode.Always)]
	public void LoadWalkable()
	{
	}

	[Button("Automatic Walkable Nodespace Area Generation", EButtonEnableMode.Always)]
	public void AutomaticWalkable()
	{
	}

	[Button("Save Walkable Nodespace Area", EButtonEnableMode.Always)]
	public void RecordWalkable()
	{
	}

	[Button("Clear Walkable Nodepace Display", EButtonEnableMode.Always)]
	public void ClearWalkable()
	{
	}

	public float RoundToPlaces(float input, int decimals)
	{
		return 0f;
	}

	[Button("Load Sub Object Placement Configuration", EButtonEnableMode.Always)]
	public void LoadSubObjectSetup()
	{
	}

	[Button("Spawn Random Sub Object Examples", EButtonEnableMode.Always)]
	public void SpawnRandomSubObjects()
	{
	}

	[Button("Clear Random Sub Object Examples", EButtonEnableMode.Always)]
	public void ClearRandomSubObjects()
	{
	}

	[Button("Save Sub Object Placement Configuration", EButtonEnableMode.Always)]
	public void RecordSubObjectPlacements()
	{
	}

	[Button("Clear Sub Object Placement Display", EButtonEnableMode.Always)]
	public void ClearSubObjectDisplay()
	{
	}

	public Transform SearchForTransform(Transform parent, string search)
	{
		return null;
	}

	[Button("Load Blocked Area", EButtonEnableMode.Always)]
	public void LoadBlockedArea()
	{
	}

	[Button("Save Blocked Area", EButtonEnableMode.Always)]
	public void SaveBlockedArea()
	{
	}

	[Button("Clear Blocked Display", EButtonEnableMode.Always)]
	public void ClearBlockedDisplay()
	{
	}

	[Button("Save All", EButtonEnableMode.Always)]
	public void SaveAll()
	{
	}

	[Button("Clear All", EButtonEnableMode.Always)]
	public void ClearAll()
	{
	}
}
