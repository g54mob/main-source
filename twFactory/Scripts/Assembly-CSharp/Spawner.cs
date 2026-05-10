using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, ISavable
{
	public delegate void OnSpawn(GameObject spawnedGameObject);

	public delegate void SpawnerDestroyedDelegate(Spawner spawner);

	[SerializeField]
	private SpawnerConfig config;

	protected List<GameObject> spawnedObjects;

	[Savable("spawnedObjectsAmount", true, false)]
	protected int spawnedObjectsAmount;

	[Savable("firstActivation", true, false)]
	protected bool firstActivation = true;

	[Savable("currentTotalObjectsToSpawn", true, false)]
	protected int currentTotalObjectsToSpawn = -1;

	[Savable("activationTime", true, false)]
	private float activationTime;

	[Savable("uptime", true, false)]
	private float uptime;

	[Savable("currentObjectsPerSpawn", true, false)]
	private int currentObjectsPerSpawn = -1;

	[Savable("currentSpawnTime", true, false)]
	private float currentSpawnTime = -1f;

	[Savable("savedSpawnTimeStartTime", true, false)]
	private float savedSpawnTimeStartTime = -1f;

	[Savable("savedAlreadySpawnedObjectsPerSpawn", true, false)]
	private int savedAlreadySpawnedObjectsPerSpawn;

	[Savable("savedInBetweenTimeStartTime", true, false)]
	private float savedInBetweenTimeStartTime = -1f;

	private SpawnerPosition spawnerPosition;

	private Coroutine spawnCoroutine;

	private Coroutine checkDurationCoroutine;

	public SpawnerConfig Config
	{
		get
		{
			return config;
		}
		set
		{
			config = value;
		}
	}

	public event OnSpawn onSpawn;

	public event SpawnerDestroyedDelegate OnSpawnerDestroyed;

	protected virtual void Awake()
	{
		spawnedObjects = new List<GameObject>();
		spawnerPosition = GetComponent<SpawnerPosition>();
		ResetSpawner();
	}

	protected virtual void Start()
	{
		if ((bool)Config && Config.ActivateOnStart)
		{
			StartSpawner();
		}
	}

	public void StartSpawner()
	{
		activationTime = Time.time;
		this.StartCoroutineCheckingVar(SpawnCoroutine(), ref spawnCoroutine, stopCoroutineIfRunning: true);
		if (Config.Duration > 0f)
		{
			this.StartCoroutineCheckingVar(CheckDurationCorutine(), ref checkDurationCoroutine);
		}
	}

	public void StopSpawner()
	{
		this.StopCoroutineCheckingVar(ref spawnCoroutine);
		this.StopCoroutineCheckingVar(ref checkDurationCoroutine);
		ResetSpawner();
	}

	public void PauseSpawner()
	{
		this.StopCoroutineCheckingVar(ref spawnCoroutine);
		this.StopCoroutineCheckingVar(ref checkDurationCoroutine);
		uptime += Time.time - activationTime;
	}

	protected virtual void ResetSpawner()
	{
		firstActivation = true;
		activationTime = -1f;
		uptime = 0f;
		spawnedObjectsAmount = 0;
		currentTotalObjectsToSpawn = -1;
	}

	public virtual GameObject SpawnObject()
	{
		GameObject gameObject;
		if ((bool)spawnerPosition)
		{
			SpawnerPosition.SpawnTransform spawnPosition = spawnerPosition.GetSpawnPosition();
			gameObject = SpawnObjectWithSpawnTransform(spawnPosition);
		}
		else
		{
			gameObject = SpawnObjectWithPosition(base.transform.position, base.transform.rotation);
		}
		this.onSpawn?.Invoke(gameObject);
		return gameObject;
	}

	private IEnumerator SpawnCoroutine()
	{
		WaitForSeconds inBetweenWFS = new WaitForSeconds(config.InBetweenSpawnsTime);
		yield return null;
		OnSpawnerActivated();
		if (firstActivation && Config.StartDelay > 0f && Config.StartDelay > uptime)
		{
			yield return new WaitForSeconds(Config.StartDelay - uptime);
		}
		if (currentTotalObjectsToSpawn < 0)
		{
			currentTotalObjectsToSpawn = Config.TotalObjectsToSpawn.Value;
		}
		while (spawnedObjectsAmount < currentTotalObjectsToSpawn || currentTotalObjectsToSpawn <= 0)
		{
			if (currentObjectsPerSpawn < 0)
			{
				currentObjectsPerSpawn = Config.ObjectsPerSpawn.Value;
			}
			if (Config.SpawnTime.Value > 0f && (!Config.IgnoreFirstSpawnTime || !firstActivation))
			{
				if (currentSpawnTime < 0f)
				{
					currentSpawnTime = Config.SpawnTime.Value;
				}
				if (savedSpawnTimeStartTime >= 0f)
				{
					LTFunctionLibrary.GetTimeManager().GetTimeSeconds();
					yield return new WaitForSeconds(currentSpawnTime - ((float)LTFunctionLibrary.GetTimeManager().GetTimeSeconds() - savedSpawnTimeStartTime));
				}
				else
				{
					savedSpawnTimeStartTime = (float)LTFunctionLibrary.GetTimeManager().GetTimeSeconds();
					yield return new WaitForSeconds(currentSpawnTime);
				}
			}
			else
			{
				yield return null;
			}
			if (currentTotalObjectsToSpawn > 0)
			{
				currentObjectsPerSpawn = Mathf.Min(currentObjectsPerSpawn, currentTotalObjectsToSpawn - spawnedObjectsAmount);
			}
			for (int i = savedAlreadySpawnedObjectsPerSpawn; i < currentObjectsPerSpawn; i++)
			{
				if (savedInBetweenTimeStartTime >= 0f)
				{
					yield return new WaitForSeconds(config.InBetweenSpawnsTime - ((float)LTFunctionLibrary.GetTimeManager().GetTimeSeconds() - savedInBetweenTimeStartTime));
				}
				SpawnObject();
				savedInBetweenTimeStartTime = -1f;
				savedAlreadySpawnedObjectsPerSpawn++;
				spawnedObjectsAmount++;
				if (i < currentObjectsPerSpawn - 1 && config.InBetweenSpawnsTime > 0f)
				{
					savedInBetweenTimeStartTime = (float)LTFunctionLibrary.GetTimeManager().GetTimeSeconds();
					yield return inBetweenWFS;
				}
			}
			currentSpawnTime = -1f;
			savedSpawnTimeStartTime = -1f;
			currentObjectsPerSpawn = -1;
			savedAlreadySpawnedObjectsPerSpawn = 0;
			firstActivation = false;
		}
		if (Config.AutoDestroy && spawnedObjectsAmount == currentTotalObjectsToSpawn)
		{
			DestroySpawner();
		}
		PauseSpawner();
		spawnCoroutine = null;
	}

	private IEnumerator CheckDurationCorutine()
	{
		yield return new WaitForSeconds(Config.Duration - uptime);
		uptime = Config.Duration;
		if (config.AutoDestroy)
		{
			DestroySpawner();
		}
		else
		{
			PauseSpawner();
		}
		checkDurationCoroutine = null;
	}

	protected virtual void OnSpawnerActivated()
	{
	}

	protected virtual GameObject SpawnObjectWithPosition(Vector3 spawnPosition, Quaternion spawnRotation)
	{
		GameObject gameObject = Object.Instantiate(Config.ObjectToSpawn.gameObject, spawnPosition, spawnRotation, base.transform);
		spawnedObjects.Add(gameObject);
		if ((bool)Config.SpawnVFX)
		{
			Object.Instantiate(Config.SpawnVFX, spawnPosition, spawnRotation);
		}
		return gameObject;
	}

	protected virtual GameObject SpawnObjectWithSpawnTransform(SpawnerPosition.SpawnTransform spawnTransform)
	{
		return SpawnObjectWithPosition(spawnTransform.position, spawnTransform.rotation);
	}

	public bool IsSpawning()
	{
		return spawnCoroutine != null;
	}

	public bool HasEndedSpawning()
	{
		if (currentTotalObjectsToSpawn <= 0 || spawnedObjectsAmount < currentTotalObjectsToSpawn)
		{
			if (config.Duration > 0f)
			{
				return uptime >= config.Duration;
			}
			return false;
		}
		return true;
	}

	protected virtual void DestroySpawner()
	{
		this.OnSpawnerDestroyed?.Invoke(this);
		Object.Destroy(base.gameObject);
	}

	private void OnDrawGizmosSelected()
	{
		if ((bool)GetComponent<SpawnerPosition>())
		{
			return;
		}
		GameObject objectToSpawn = GetComponent<Spawner>().Config.ObjectToSpawn;
		if (!objectToSpawn)
		{
			return;
		}
		Gizmos.color = Color.grey;
		if ((bool)objectToSpawn)
		{
			foreach (Mesh mesh in FunctionLibrary.GetMeshes(objectToSpawn))
			{
				Gizmos.DrawMesh(mesh, base.transform.position);
			}
			return;
		}
		Gizmos.DrawWireSphere(base.transform.position + base.transform.up * 0.5f, 0.5f);
	}

	public void OnSave()
	{
		uptime += Time.time - activationTime;
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
	}
}
