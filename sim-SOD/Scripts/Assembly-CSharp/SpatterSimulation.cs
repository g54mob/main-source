using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

[Serializable]
public class SpatterSimulation
{
	public enum EraseMode
	{
		neverOrManual = 0,
		onceExecutedAndOutOfBuildingPlusDespawnTime = 1,
		onceExecutedAndOutOfAddressPlusDespawnTime = 2,
		useDespawnTime = 3,
		useDespawnTimeOnceExecuted = 4,
		quickDespawn = 5
	}

	public enum ForceType
	{
		bulletForward = 0,
		bulletBack = 1,
		punch = 2
	}

	[Serializable]
	public class DecalSpawnData
	{
		public ParentID parentID;

		public int transformParentID;

		public string subObjectName;

		public Vector3 worldPos;

		public Vector3 worldEuler;

		public Vector3 size;

		public DecalMaterialType materialType;

		[NonSerialized]
		public DecalProjector spawnedProjector;

		[NonSerialized]
		public Interactable i;

		[NonSerialized]
		public SpatterSimulation sim;

		private const int INITIAL_POOL_SIZE = 30;

		private const float RECYCLED_Y_POSITION = -1000f;

		[NonSerialized]
		private static Queue<DecalProjector> decalPool;

		public void SpawnOnTransform(Transform spawnTransform)
		{
		}

		public static void InitialisePool()
		{
		}

		public static DecalProjector GetNewDecalProjector()
		{
			return null;
		}

		public static void RecycleDecalProjector(DecalProjector decalProjector)
		{
		}
	}

	public enum DecalMaterialType
	{
		light = 0,
		medium = 1,
		heavy = 2
	}

	public enum ParentID
	{
		room = 0,
		human = 1,
		interactable = 2,
		door = 3
	}

	[Header("Serialized References")]
	public Vector3 worldOrigin;

	public Vector3 worldTarget;

	public Vector3Int nodeCoord;

	public string presetStr;

	public int roomID;

	public EraseMode eraseMode;

	public ForceType force;

	public float spatterCountMultiplier;

	public float createdAt;

	public bool isExecuted;

	public float executedAt;

	public float eraseModeTimeStamp;

	public bool stickToActors;

	public List<DecalSpawnData> decalsSpawned;

	[NonSerialized]
	[Header("Non-Serialized References")]
	public NewRoom room;

	[NonSerialized]
	public SpatterPatternPreset preset;

	[NonSerialized]
	public static int spawnedProjectorsCount;

	public SpatterSimulation(Human newHuman, Vector3 newLocalPosition, Vector3 newDirection, SpatterPatternPreset spatter, EraseMode newEraseMode, float newSpatterCountMultiplier = 1f, bool newStickToActors = true)
	{
	}

	public SpatterSimulation(Vector3 newWorldPosition, Vector3 newWorldTarget, SpatterPatternPreset spatter, EraseMode newEraseMode, float newSpatterCountMultiplier = 1f, bool newStickToActors = true)
	{
	}

	public void Execute()
	{
	}

	public void Remove()
	{
	}

	public void LoadFromSerializedData()
	{
	}

	public void UpdateSpawning()
	{
	}
}
