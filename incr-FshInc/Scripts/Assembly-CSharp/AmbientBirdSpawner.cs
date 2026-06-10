using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientBirdSpawner : MonoBehaviour
{
	[Serializable]
	public class BirdEntry
	{
		public GameObject prefab;

		[Range(0f, 1f)]
		public float weight = 1f;
	}

	public enum SpawnFrequency
	{
		Rare = 0,
		Occasional = 1,
		Frequent = 2,
		DebugSpam = 3
	}

	[Header("Birds")]
	[Tooltip("Bird prefabs that can appear in this zone.")]
	public List<BirdEntry> birds = new List<BirdEntry>();

	[Header("Frequency")]
	[Tooltip("How often birds appear. None = disabled, Rare = ~1 per level, Occasional = 2-3, Frequent = many.")]
	public SpawnFrequency frequency = SpawnFrequency.Occasional;

	[Header("Directions")]
	public bool fromRight = true;

	public bool fromLeft = true;

	[Header("Flocks")]
	[Tooltip("Can birds appear in V-formation flocks?")]
	public bool allowFlocks;

	[Tooltip("Number of birds in a flock.")]
	[Range(3f, 9f)]
	public int flockSize = 5;

	private int spawnCount;

	private float initialDelayMin;

	private float initialDelayMax;

	private float repeatMin;

	private float repeatMax;

	private int maxSpawns;

	private float spawnChance;

	private float flockChance;

	private void OnEnable()
	{
		spawnCount = 0;
		ApplyFrequencyPreset();
		if (!(UnityEngine.Random.value > spawnChance) && birds != null && birds.Count != 0)
		{
			StartCoroutine(SpawnLoop());
		}
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	private void ApplyFrequencyPreset()
	{
		switch (frequency)
		{
		case SpawnFrequency.Rare:
			spawnChance = 0.3f;
			initialDelayMin = 5f;
			initialDelayMax = 45f;
			repeatMin = 60f;
			repeatMax = 120f;
			maxSpawns = 1;
			flockChance = (allowFlocks ? 0.15f : 0f);
			break;
		case SpawnFrequency.Occasional:
			spawnChance = 0.5f;
			initialDelayMin = 3f;
			initialDelayMax = 30f;
			repeatMin = 25f;
			repeatMax = 60f;
			maxSpawns = 3;
			flockChance = (allowFlocks ? 0.25f : 0f);
			break;
		case SpawnFrequency.Frequent:
			spawnChance = 0.8f;
			initialDelayMin = 1f;
			initialDelayMax = 10f;
			repeatMin = 10f;
			repeatMax = 35f;
			maxSpawns = 6;
			flockChance = (allowFlocks ? 0.35f : 0f);
			break;
		case SpawnFrequency.DebugSpam:
			spawnChance = 1f;
			initialDelayMin = 0.5f;
			initialDelayMax = 1f;
			repeatMin = 2f;
			repeatMax = 4f;
			maxSpawns = 999;
			flockChance = (allowFlocks ? 0.5f : 0f);
			break;
		}
	}

	private IEnumerator SpawnLoop()
	{
		yield return new WaitForSeconds(UnityEngine.Random.Range(initialDelayMin, initialDelayMax));
		while (spawnCount < maxSpawns)
		{
			if (UnityEngine.Random.value <= flockChance)
			{
				SpawnFlock();
			}
			else
			{
				SpawnBird();
			}
			spawnCount++;
			yield return new WaitForSeconds(UnityEngine.Random.Range(repeatMin, repeatMax));
		}
	}

	private void SpawnBird()
	{
		GameObject gameObject = PickWeightedBird();
		if (!(gameObject == null))
		{
			Camera main = Camera.main;
			if (!(main == null))
			{
				FlyDirection direction = PickDirection();
				Vector3 spawnPosition = GetSpawnPosition(main, direction);
				SpawnSingleBird(gameObject, spawnPosition, direction);
			}
		}
	}

	private void SpawnFlock()
	{
		GameObject gameObject = PickWeightedBird();
		if (gameObject == null)
		{
			return;
		}
		Camera main = Camera.main;
		if (!(main == null))
		{
			FlyDirection flyDirection = PickDirection();
			Vector3 spawnPosition = GetSpawnPosition(main, flyDirection);
			SpawnSingleBird(gameObject, spawnPosition, flyDirection);
			Vector3 vector;
			Vector3 vector2;
			switch (flyDirection)
			{
			case FlyDirection.Rightward:
				vector = Vector3.left;
				vector2 = Vector3.up;
				break;
			case FlyDirection.Downward:
				vector = Vector3.up;
				vector2 = Vector3.right;
				break;
			case FlyDirection.Upward:
				vector = Vector3.down;
				vector2 = Vector3.right;
				break;
			default:
				vector = Vector3.right;
				vector2 = Vector3.up;
				break;
			}
			float num = 0.8f;
			int num2 = flockSize - 1;
			for (int i = 0; i < num2; i++)
			{
				int num3 = i / 2 + 1;
				float num4 = ((i % 2 == 0) ? 1f : (-1f));
				Vector3 vector3 = vector * ((float)num3 * num) + vector2 * (num4 * (float)num3 * num * 0.6f) + new Vector3(UnityEngine.Random.Range(-0.15f, 0.15f), UnityEngine.Random.Range(-0.15f, 0.15f), 0f);
				SpawnSingleBird(gameObject, spawnPosition + vector3, flyDirection);
			}
		}
	}

	private void SpawnSingleBird(GameObject prefab, Vector3 position, FlyDirection direction)
	{
		BirdFlyby component = UnityEngine.Object.Instantiate(prefab, position, Quaternion.identity).GetComponent<BirdFlyby>();
		if (component != null)
		{
			component.SetDirection(direction);
		}
	}

	private GameObject PickWeightedBird()
	{
		float num = 0f;
		foreach (BirdEntry bird in birds)
		{
			if (bird.prefab != null)
			{
				num += bird.weight;
			}
		}
		if (num <= 0f)
		{
			return null;
		}
		float num2 = UnityEngine.Random.Range(0f, num);
		float num3 = 0f;
		foreach (BirdEntry bird2 in birds)
		{
			if (!(bird2.prefab == null))
			{
				num3 += bird2.weight;
				if (num2 <= num3)
				{
					return bird2.prefab;
				}
			}
		}
		return birds[0].prefab;
	}

	private FlyDirection PickDirection()
	{
		List<FlyDirection> list = new List<FlyDirection>(2);
		if (fromRight)
		{
			list.Add(FlyDirection.Leftward);
		}
		if (fromLeft)
		{
			list.Add(FlyDirection.Rightward);
		}
		if (list.Count == 0)
		{
			list.Add(FlyDirection.Leftward);
		}
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	private Vector3 GetSpawnPosition(Camera cam, FlyDirection direction)
	{
		float x = ((direction == FlyDirection.Rightward) ? (-0.25f) : 1.25f);
		float y = UnityEngine.Random.Range(0.55f, 0.92f);
		Vector3 result = cam.ViewportToWorldPoint(new Vector3(x, y, Mathf.Abs(cam.transform.position.z)));
		result.z = 0f;
		return result;
	}
}
