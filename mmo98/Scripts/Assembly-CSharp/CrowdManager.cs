using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using ZLinq;

public class CrowdManager : MonoBehaviour
{
	private class CharacterInstance
	{
		public GameObject Root;

		public NavMeshAgent Agent;

		public SimpleWanderer Wanderer;
	}

	private const string NavMeshAreaName = "Walkable";

	[Header("Character Settings")]
	[SerializeField]
	private GameObject[] characterPrefabs;

	[SerializeField]
	private Transform spawnCenter;

	[SerializeField]
	private float spawnRadius = 10f;

	[SerializeField]
	private int spawnAttempts = 20;

	[SerializeField]
	private float navMeshSampleDistance = 2f;

	[Header("Population Settings")]
	[SerializeField]
	private float playerCountPercentage = 0.1f;

	[SerializeField]
	private float updateInterval = 1f;

	[SerializeField]
	private int maxPopulation = 200;

	[Header("Animator Settings")]
	[SerializeField]
	private RuntimeAnimatorController animatorController;

	private int _navMeshAreaMask;

	private int _lastTargetPopulation;

	private ObjectPool<CharacterInstance> _characterPool;

	private Transform _characterParent;

	private void Awake()
	{
		_navMeshAreaMask |= 1 << NavMesh.GetAreaFromName("Walkable");
		_characterParent = new GameObject("Characters").transform;
		_characterParent.SetParent(base.transform);
		_characterPool = new ObjectPool<CharacterInstance>(CreateCharacter, RentCharacter, ReturnCharacter, DestroyCharacter);
	}

	private void Start()
	{
		UpdatePopulationFromPlayerCount();
		UniTaskUtility.Interval(updateInterval, UpdatePopulationFromPlayerCount, this.GetCancellationTokenOnDestroy()).Forget();
	}

	private void UpdatePopulationFromPlayerCount()
	{
		int num = CalculateTargetPopulation();
		if (num != _lastTargetPopulation)
		{
			_lastTargetPopulation = num;
			SetPopulation(num);
		}
	}

	private int CalculateTargetPopulation()
	{
		return Mathf.Clamp(Mathf.RoundToInt((float)(Database.State.Resources.Players.Value * ((double)playerCountPercentage / 100.0))), 0, maxPopulation);
	}

	private void SetPopulation(int targetCount)
	{
		int num = Mathf.Clamp(targetCount, 0, maxPopulation) - _characterPool.RentedCount;
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				_characterPool.Rent();
			}
		}
		else if (num < 0)
		{
			for (int j = 0; j < Math.Abs(num); j++)
			{
				_characterPool.Return(_characterPool.Rented.AsValueEnumerable().Random());
			}
		}
	}

	private CharacterInstance CreateCharacter()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(characterPrefabs.AsValueEnumerable().Random(), _characterParent);
		gameObject.SetActive(value: false);
		if (!gameObject.TryGetComponent<NavMeshAgent>(out var component))
		{
			component = gameObject.AddComponent<NavMeshAgent>();
			component.radius = 0.5f;
			component.height = 2f;
			component.areaMask = _navMeshAreaMask;
			component.obstacleAvoidanceType = ObstacleAvoidanceType.LowQualityObstacleAvoidance;
		}
		if (!gameObject.TryGetComponent<SimpleWanderer>(out var component2))
		{
			component2 = gameObject.AddComponent<SimpleWanderer>();
		}
		gameObject.GetComponent<Animator>().runtimeAnimatorController = animatorController;
		return new CharacterInstance
		{
			Root = gameObject,
			Agent = component,
			Wanderer = component2
		};
	}

	private void RentCharacter(CharacterInstance character)
	{
		Vector3 vector = RandomSpawnPosition();
		character.Root.transform.position = vector;
		character.Root.transform.rotation = Quaternion.Euler(0f, BiteRandom.NextFloat(0f, 360f), 0f);
		character.Agent.enabled = true;
		character.Agent.Warp(vector);
		character.Root.SetActive(value: true);
		character.Wanderer.Initialize(spawnCenter.position);
	}

	private void ReturnCharacter(CharacterInstance character)
	{
		if (character.Agent.isOnNavMesh)
		{
			character.Agent.ResetPath();
		}
		character.Agent.enabled = false;
		character.Root.SetActive(value: false);
	}

	private void DestroyCharacter(CharacterInstance character)
	{
		UnityEngine.Object.Destroy(character.Root);
	}

	private Vector3 RandomSpawnPosition()
	{
		for (int i = 0; i < spawnAttempts; i++)
		{
			Vector2 vector = BiteRandom.NextVector2InsideCircle() * spawnRadius;
			if (NavMesh.SamplePosition(spawnCenter.position + new Vector3(vector.x, 0f, vector.y), out var hit, navMeshSampleDistance, _navMeshAreaMask))
			{
				return hit.position;
			}
		}
		Debug.LogWarning("CrowdManager: Could not find valid spawn position on configured NavMesh areas.");
		return spawnCenter.position;
	}
}
