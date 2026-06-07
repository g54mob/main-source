using System.Collections.Generic;
using UnityEngine;

public class AnomalousMaterial_Manager : MonoBehaviour
{
	public static AnomalousMaterial_Manager Singleton;

	[SerializeField]
	private GameObject anomalousMaterial_Prefab;

	[SerializeField]
	private int failedRolls;

	public int calculatedMaxRollValue;

	[SerializeField]
	private int rollMax_Base;

	private float percentageIncreasePerOrb = 1.7f;

	[SerializeField]
	private int rollMax_Ceiling;

	private const int STARORBS_INCREASEPERDROP = 30;

	private const int STARORBS_CEILINGPERDROP = 10000;

	private int numOfDropsToBeAtCeiling;

	[Header("Spawn Area")]
	[SerializeField]
	private Vector2 spawnArea_X;

	[SerializeField]
	private Vector2 spawnArea_Y;

	[SerializeField]
	private Vector2 spawnArea_Z;

	[SerializeField]
	private Transform starOrbSpawnPoint;

	[Header("Star Orb Scaling")]
	[SerializeField]
	private List<float> starOrbScales;

	[SerializeField]
	private List<Mesh> starOrbMeshes;

	[Header("Misc. Spawning")]
	public List<StarOrbsToSpawnWhenDeposited> starOrbsWeDidntDepositLastRound_Queue = new List<StarOrbsToSpawnWhenDeposited>();

	[SerializeField]
	private float lastRoundOrbsQueue_SpawnInterval;

	private float lastRoundOrbsQueue_SpawnInterval_Curr;

	private int queueIndex;

	[SerializeField]
	private Transform starPipeSpawnPoint;

	public const float STARORB_SPAWNFORCE_FROMHOLE = 2f;

	public const float STARORB_SPAWNFORCE_FROMPIPE = 3f;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}

	private void Start()
	{
		CalculateRollTarget();
		numOfDropsToBeAtCeiling = 333;
		lastRoundOrbsQueue_SpawnInterval_Curr = lastRoundOrbsQueue_SpawnInterval;
	}

	private void Update()
	{
		if (GameManager.Singleton.gameState == GameManager.GameState.Playing)
		{
			HandleSpawningLastRoundsOrbsQueue();
		}
	}

	public void RollForAnomalousMaterialDrop()
	{
		if (PlayerStats.Singleton.starOrbGen_IsUnlocked)
		{
			if (Random.Range(0, PlayerStats.Singleton.starOrbGen_Rando_Limit_Curr) <= PlayerStats.Singleton.starOrgGen_Rando_CurrentRoll_Floor)
			{
				SpawnAnomalousMaterial(StarOrbsToSpawnWhenDeposited.One, _increaseRollChance: true, starPipeSpawnPoint.position, 0.5f, 3f, _fromMilestone: true, starPipeSpawnPoint);
				PlayerStats.Singleton.starOrgGen_Rando_CurrentRoll_Floor = 0;
				PlayerStats.Singleton.starOrbGen_Rando_Level++;
				CalculateRollTarget();
			}
			else
			{
				PlayerStats.Singleton.starOrgGen_Rando_CurrentRoll_Floor++;
			}
		}
	}

	public void CalculateRollTarget()
	{
		if (PlayerStats.Singleton.starOrbGen_IsUnlocked)
		{
			PlayerStats.Singleton.starOrbGen_Rando_Limit_Curr = Mathf.Clamp(PlayerStats.Singleton.starOrbGen_Rando_Limit_Min + PlayerStats.Singleton.starOrbGen_Rando_Level * PlayerStats.Singleton.starOrbGen_Rando_IncreasePerLevel, PlayerStats.Singleton.starOrbGen_Rando_Limit_Min, PlayerStats.Singleton.starOrbGen_Rando_Limit_Max);
		}
	}

	public void SpawnAnomalousMaterial(StarOrbsToSpawnWhenDeposited _starOrbWorth, bool _increaseRollChance, Vector3 _position, float _randomSpawnForceXZ, float _spawnforce, bool _fromMilestone, Transform _emitterTransform = null)
	{
		if (_starOrbWorth != StarOrbsToSpawnWhenDeposited.None)
		{
			Rigidbody component = Object.Instantiate(anomalousMaterial_Prefab, _position, Quaternion.identity).GetComponent<Rigidbody>();
			PickUppable component2 = component.gameObject.GetComponent<PickUppable>();
			component2.SetNumOfOrbsToSpawnAtDeposited(_starOrbWorth);
			component2.transform.localScale = Vector3.one * starOrbScales[(int)_starOrbWorth];
			component2.starOrb_Star_MeshFilter.mesh = starOrbMeshes[(int)_starOrbWorth];
			component2.starOrbFromMilestone = _fromMilestone;
			if (_starOrbWorth > StarOrbsToSpawnWhenDeposited.TwentyFive)
			{
				component2.canBeKicked = true;
				component2.canPickUp = false;
			}
			else
			{
				component2.canBeKicked = true;
				component2.canPickUp = true;
			}
			if (_emitterTransform == null)
			{
				component.AddForce(new Vector3(Random.Range(0f - _randomSpawnForceXZ, _randomSpawnForceXZ), _spawnforce, Random.Range(0f - _randomSpawnForceXZ, _randomSpawnForceXZ)), ForceMode.VelocityChange);
			}
			else
			{
				float num = 10f;
				Quaternion quaternion = Quaternion.Euler(Random.Range(0f - num, num), Random.Range(0f - num, num), 0f);
				component.AddForce(quaternion * _emitterTransform.forward * _spawnforce, ForceMode.VelocityChange);
			}
			component.AddTorque(new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f)), ForceMode.VelocityChange);
			if (_fromMilestone)
			{
				PlayerStats.Singleton.AddSpawnedButNotDepositedStarOrb((int)_starOrbWorth);
			}
			AudioManager.Singleton.PlayStarPipeSpawnOrbSFX(component2.transform.position);
		}
	}

	public void SetupStarOrbsQueueNotDepositedLastRound()
	{
		int num = 0;
		foreach (int item in PlayerStats.Singleton.starOrbTypes_SpawnedButNotDeposited)
		{
			for (int i = 0; i < item; i++)
			{
				starOrbsWeDidntDepositLastRound_Queue.Add((StarOrbsToSpawnWhenDeposited)num);
			}
			num++;
		}
		queueIndex = 0;
		for (int j = 0; j < PlayerStats.Singleton.starOrbTypes_SpawnedButNotDeposited.Count; j++)
		{
			PlayerStats.Singleton.starOrbTypes_SpawnedButNotDeposited[j] = 0;
		}
	}

	private void HandleSpawningLastRoundsOrbsQueue()
	{
		if (!GameManager.Singleton.hasTimerElapsed_IsNighttime && starOrbsWeDidntDepositLastRound_Queue.Count > 0 && starOrbsWeDidntDepositLastRound_Queue.Count > 0 && GameManager.Singleton.gameState == GameManager.GameState.Playing)
		{
			if (lastRoundOrbsQueue_SpawnInterval_Curr > 0f)
			{
				lastRoundOrbsQueue_SpawnInterval_Curr -= Time.deltaTime;
				return;
			}
			SpawnAnomalousMaterial(starOrbsWeDidntDepositLastRound_Queue[0], _increaseRollChance: false, GameManager.Singleton.GetStarOrbSpawnPosition(), 0.25f, 2f, _fromMilestone: true);
			queueIndex++;
			lastRoundOrbsQueue_SpawnInterval_Curr = lastRoundOrbsQueue_SpawnInterval;
			starOrbsWeDidntDepositLastRound_Queue.RemoveAt(0);
		}
	}

	public void AddRemainingUnspawnedOrbsInQueueToSpawnsOrbsForSaving()
	{
		foreach (StarOrbsToSpawnWhenDeposited item in starOrbsWeDidntDepositLastRound_Queue)
		{
			PlayerStats.Singleton.AddSpawnedButNotDepositedStarOrb((int)item);
		}
	}
}
