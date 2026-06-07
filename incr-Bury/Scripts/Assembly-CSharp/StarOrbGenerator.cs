using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarOrbGenerator : MonoBehaviour
{
	public class OrbSpawnTiming
	{
		public float time;

		public OrbSpawnTiming(float _time)
		{
			time = _time;
		}
	}

	[SerializeField]
	private Transform spawnPoint;

	public List<OrbSpawnTiming> spawnTimingsList = new List<OrbSpawnTiming>();

	private const float SPAWNTIME_ENDOFROUND_BUFFERRANGE = 20f;

	[SerializeField]
	private Vector2 orbSpawnForce_MinMax;

	[Header("UI")]
	[SerializeField]
	private TMP_Text chanceDisplayText;

	private void Start()
	{
	}

	private void Update()
	{
		_ = GameManager.Singleton.gameState;
		_ = 1;
	}

	public void CalculateOrbSpawnTimesThisRound(int _amt)
	{
		spawnTimingsList.Clear();
		for (int i = 0; i < _amt; i++)
		{
			OrbSpawnTiming item = new OrbSpawnTiming(Random.Range(2f, PlayerStats.Singleton.roundTimerLength - 20f));
			spawnTimingsList.Add(item);
		}
	}

	private void HandleAllOrbTimers()
	{
		if (spawnTimingsList.Count <= 0)
		{
			return;
		}
		for (int num = spawnTimingsList.Count - 1; num >= 0; num--)
		{
			spawnTimingsList[num].time -= Time.deltaTime;
			if (spawnTimingsList[num].time <= 0f)
			{
				AnomalousMaterial_Manager.Singleton.SpawnAnomalousMaterial(StarOrbsToSpawnWhenDeposited.One, _increaseRollChance: false, spawnPoint.position, 0.2f, Random.Range(orbSpawnForce_MinMax.x, orbSpawnForce_MinMax.y), _fromMilestone: false, spawnPoint.transform);
				spawnTimingsList.RemoveAt(num);
			}
		}
	}
}
