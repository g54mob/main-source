using System;
using UnityEngine;

public class VoidBoxSpawnManager : MonoBehaviour
{
	public static VoidBoxSpawnManager Singleton;

	[SerializeField]
	private GameObject voidBoxDiggable_Prefab;

	[SerializeField]
	private GameObject spawned_voidBoxDiggable;

	[Header("Spawn Params")]
	[SerializeField]
	private float startingSpawnRadius;

	[SerializeField]
	private float radiusPerNumSpawned;

	[Header("Spawn Timers")]
	[SerializeField]
	private float timeBetweenNewDiggableSpawn;

	private float timeBetweenNewDiggableSpawn_Curr;

	private bool hasSpawnedThisRound;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Singleton = this;
		timeBetweenNewDiggableSpawn_Curr = timeBetweenNewDiggableSpawn;
	}

	private void Update()
	{
		if (GameManager.Singleton.gameState == GameManager.GameState.Playing)
		{
			HandleSpawnTimers();
		}
	}

	private void HandleSpawningVoidBoxDiggables()
	{
		if (spawned_voidBoxDiggable == null)
		{
			if (!PlayerStats.Singleton.wasPreviousVoidBoxDugUp)
			{
				spawned_voidBoxDiggable = UnityEngine.Object.Instantiate(voidBoxDiggable_Prefab, PlayerStats.Singleton.voidBoxPositionThisRound, Quaternion.identity);
				PlayerStats.Singleton.wasPreviousVoidBoxDugUp = false;
			}
			else
			{
				float radius = CalculateDiggableRadiusFromSpawnCount();
				Vector3 startingHolePosition = GameManager.Singleton.GetStartingHolePosition();
				startingHolePosition.y = 1.23f;
				Vector3 vector = startingHolePosition + RandomPointOnCircle(radius);
				spawned_voidBoxDiggable = UnityEngine.Object.Instantiate(voidBoxDiggable_Prefab, vector, Quaternion.identity);
				PlayerStats.Singleton.voidBoxPositionThisRound = vector;
				PlayerStats.Singleton.wasPreviousVoidBoxDugUp = false;
			}
			hasSpawnedThisRound = true;
		}
	}

	private float CalculateDiggableRadiusFromSpawnCount()
	{
		return startingSpawnRadius + (float)PlayerStats.Singleton.numOfVoidBoxesDepositedInHole * radiusPerNumSpawned;
	}

	public static Vector3 RandomPointOnCircle(float radius)
	{
		float f = UnityEngine.Random.Range(0f, MathF.PI * 2f);
		float x = Mathf.Cos(f) * radius;
		float z = Mathf.Sin(f) * radius;
		return new Vector3(x, 0f, z);
	}

	public void SpawnedVoidBoxDiggable_OnDigUp()
	{
		PlayerStats.Singleton.numOfVoidBoxSpawnsTotal++;
		spawned_voidBoxDiggable = null;
		timeBetweenNewDiggableSpawn_Curr = timeBetweenNewDiggableSpawn;
		PlayerStats.Singleton.wasPreviousVoidBoxDugUp = true;
	}

	private void HandleSpawnTimers()
	{
		if (hasSpawnedThisRound)
		{
			return;
		}
		if (timeBetweenNewDiggableSpawn_Curr > 0f)
		{
			timeBetweenNewDiggableSpawn_Curr -= Time.deltaTime;
			return;
		}
		timeBetweenNewDiggableSpawn_Curr = 0f;
		if (spawned_voidBoxDiggable == null)
		{
			HandleSpawningVoidBoxDiggables();
		}
	}
}
