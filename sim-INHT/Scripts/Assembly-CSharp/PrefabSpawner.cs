using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
	[Header("Prefab Settings")]
	[Tooltip("Pool of prefabs to choose from. One is picked at random each time Spawn() is called.\nNull entries in the list are skipped automatically.")]
	[SerializeField]
	private GameObject[] prefabs;

	[Tooltip("Where the prefab will be spawned.\n• None / Self  →  uses this GameObject's position and rotation.\n• Assign any Transform to override the spawn location.")]
	[SerializeField]
	private Transform spawnPoint;

	[Tooltip("Optional parent Transform assigned to the spawned instance.\nLeave empty to spawn at the scene root.")]
	[SerializeField]
	private Transform spawnParent;

	[Header("Behaviour")]
	[Tooltip("When enabled, the spawned instance inherits the spawn point's world position and rotation even if it is re-parented (worldPositionStays = true). When disabled, the local-space position/rotation is preserved instead.")]
	[SerializeField]
	private bool worldPositionStays;

	[Tooltip("Maximum number of instances this spawner may create during its lifetime.\nSet to 0 for unlimited spawns.")]
	[SerializeField]
	private int maxSpawnCount;

	private int _spawnedCount;

	public int SpawnedCount => 0;

	public void Spawn()
	{
	}

	public void ResetSpawnCount()
	{
	}
}
