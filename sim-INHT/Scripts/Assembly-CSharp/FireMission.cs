using System;
using System.Collections.Generic;
using SleepyNodes;
using UnityEngine;

[DisallowMultipleComponent]
public class FireMission : MonoBehaviour
{
	[Header("Identity & Randomization")]
	public bool useFixedSeed;

	public int fixedSeed;

	[Header("Coordinate Root")]
	public RectTransform coordinateRoot;

	public EntityLocation POI_Prefab;

	[Header("Grid Settings")]
	public float cellWidth;

	public float cellHeight;

	public bool yIncreasesUp;

	public float distanceToKmScale;

	[Header("Options")]
	public bool clearSpawnedMarkers;

	public bool DebugLogs;

	[Header("Fallback Behavior")]
	public bool selectOnlyActivePoints;

	public bool useAlternateTextWhenNoActive;

	public string altTextNoActiveTarget;

	public string altTextNoActiveEnemy;

	public string altTextNoActiveAlly;

	public string altTextNoActiveOptionalTarget;

	[Header("Runtime Data")]
	public int seed;

	public Dictionary<string, MapEntity> Entities;

	public static FireMission Instance { get; private set; }

	private void OnValidate()
	{
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDestroy()
	{
	}

	public void GenerateMission()
	{
	}

	public Vector3[] GetGridBounds()
	{
		return null;
	}

	public Vector2 ToLocalSpace(Vector3 worldPos)
	{
		return default(Vector2);
	}

	public MapEntity CreateMapEntity(string id, string name, Vector3 worldPos, EntityRoles role, int health, int armour, int stars, MapEntityStates startingState, string icon)
	{
		return null;
	}

	public void MoveMapEntity(MapEntity entity, Vector3 worldPos)
	{
	}

	public void RegisterMapEntity(MapEntity entity)
	{
	}

	private void SpawnRuntimeObjectForEntity(MapEntity entity)
	{
	}

	public string GetNoActiveAlternateTextForRoles(HashSet<EntityRoles> roles)
	{
		return null;
	}

	public void ProcessNotification(string notifID)
	{
	}

	public void ProcessEvent(EventNode.EventData evt)
	{
	}

	public void SetEntityState(MapEntity entity, MapEntityStates newState)
	{
	}

	private void AutoAssignCoordinateRootIfNeeded()
	{
	}

	private void ClearSpawnedMarkersIfNeeded()
	{
	}

	internal Vector2 SampleAreaPosition(RectTransform zone, System.Random rng)
	{
		return default(Vector2);
	}

	internal Vector3 RandomPointWorldInside(RectTransform zone, System.Random rng)
	{
		return default(Vector3);
	}

	public void PositionInRootSpace(GameObject go, Vector2 rootLocalPos)
	{
	}
}
