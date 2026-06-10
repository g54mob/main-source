using System;
using System.Collections.Generic;
using UnityEngine;

public class NewWall
{
	[Serializable]
	public class FrontageSetting
	{
		public WallFrontagePreset preset;

		public Toolbox.MaterialKey matKey;

		public bool colors;

		public Vector3 offset;

		[NonSerialized]
		public List<Interactable> createdInteractables;

		[NonSerialized]
		public Transform mainTransform;
	}

	[Header("Transform")]
	public Vector3 position;

	public Vector3 localEulerAngles;

	public GameObject physicalObject;

	[Header("Location")]
	public NewNode node;

	[Space(5f)]
	public Vector2 wallOffset;

	public bool isExterior;

	public bool separateWall;

	[Header("Details")]
	public int id;

	public bool preventEntrance;

	[Header("Door Config")]
	public bool foundDoorMaterialKey;

	public Toolbox.MaterialKey doorMatKey;

	public float baseDoorStrength;

	public float currentDoorStrength;

	public float baseLockStrength;

	public float currentLockStrength;

	[Header("Wall Pair")]
	public DoorPairPreset preset;

	public NewWall otherWall;

	public NewWall parentWall;

	public NewWall childWall;

	public List<FrontageSetting> frontagePresets;

	[NonSerialized]
	public int otherWallID;

	[NonSerialized]
	public int parentWallID;

	[NonSerialized]
	public int childWallID;

	[Header("Spawned Objects")]
	public bool optimizationOverride;

	public bool optimizationAnchor;

	public int nonOptimizedSegment;

	public GameObject spawnedWall;

	public GameObject wallPrefabRef;

	public GameObject spawnedCorner;

	public GameObject spawnedCoving;

	public GameObject spawnedCornerCoving;

	public GameObject cornerPrefabRef;

	public GameObject spawnedSteps;

	public GameObject editorTrigger;

	public bool isShortWall;

	private GameObject blueprint;

	[NonSerialized]
	public Interactable lightswitchInteractable;

	public NewDoor door;

	public List<GameObject> spawnedFrontage;

	[Header("Lights")]
	public NewRoom containsLightswitch;

	[Header("Windows")]
	public int windowUVHorizonalPosition;

	public BuildingPreset.WindowUVBlock windowUV;

	[Header("Furniture")]
	public bool placedWallFurn;

	public void Setup(DoorPairPreset newPreset, NewNode newNode, Vector2 newOffset, bool newIsExterior)
	{
	}

	public void Load(CitySaveData.WallCitySave data, NewNode newNode)
	{
	}

	public void SetDoorStrength(float newVal)
	{
	}

	public void SetLockStrengthBase(float newVal)
	{
	}

	public void ResetLockStrength()
	{
	}

	public void SetDoorStrengthBase(float newVal)
	{
	}

	public void ResetDoorStrength()
	{
	}

	public void SetCurrentLockStrength(float newVal)
	{
	}

	public void SpawnWall(bool prepForCombinedMeshes)
	{
	}

	public void RemoveWall()
	{
	}

	private void UpdateSegmentData()
	{
	}

	public void SpawnCorner(bool prepForCombinedMeshes)
	{
	}

	public void SpawnFrontage(bool overrideWithKey = false, Toolbox.MaterialKey keyOverride = null)
	{
	}

	public void RemoveFrontage()
	{
	}

	public void SetDoorPairPreset(DoorPairPreset newPreset, bool enableUpdate = true, bool newIsDivider = false, bool setPair = true)
	{
	}

	public void SelectFrontage()
	{
	}

	public void SetWallMaterial(MaterialGroupPreset newMat, Toolbox.MaterialKey newKey)
	{
	}

	public void SetAsLightswitch(NewRoom newRoom, bool createInteractable = true)
	{
	}

	public CitySaveData.WallCitySave GenerateSaveData()
	{
		return null;
	}
}
