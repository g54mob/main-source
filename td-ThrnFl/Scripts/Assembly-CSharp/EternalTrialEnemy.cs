using System;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

[Serializable]
public class EternalTrialEnemy
{
	public enum EGroup
	{
		BreadAndButter = 0,
		Flavour = 1,
		Flying = 2
	}

	public GameObject enemyPrefab;

	public float difficultyValue = 1f;

	public float minDefenseInvestment;

	private float difficultyValueTemp = 1f;

	private List<EnemySpawnLine> tempSpawnLineList = new List<EnemySpawnLine>();

	private List<float> tempSpawnLineSpawnDuration = new List<float>();

	private List<float> tempSpawnLineTargetDifficulty = new List<float>();

	private List<float> tempSpawnLineActualDifficulty = new List<float>();

	private float tempTargetDifficulty;

	private float tempActualDifficulty;

	private List<int> tempSpawnAmount = new List<int>();

	private List<int> tempDropGold = new List<int>();

	public EGroup group;

	public float DifficultyValueTemp
	{
		get
		{
			return difficultyValueTemp;
		}
		set
		{
			difficultyValueTemp = value;
		}
	}

	public List<EnemySpawnLine> TempSpawnLineList => tempSpawnLineList;

	public List<float> TempSpawnLineSpawnDuration => tempSpawnLineSpawnDuration;

	public List<float> TempSpawnLineTargetDifficulty => tempSpawnLineTargetDifficulty;

	public List<float> TempSpawnLineActualDifficulty => tempSpawnLineActualDifficulty;

	public float TempTargetDifficulty
	{
		get
		{
			return tempTargetDifficulty;
		}
		set
		{
			tempTargetDifficulty = value;
		}
	}

	public float TempActualDifficulty
	{
		get
		{
			return tempActualDifficulty;
		}
		set
		{
			tempActualDifficulty = value;
		}
	}

	public List<int> TempSpawnAmount => tempSpawnAmount;

	public List<int> TempDropGold => tempDropGold;

	public int desiredGroupSize => 5;

	public bool flying => enemyPrefab.GetComponentInChildren<TaggedObject>().Tags.Contains(TagManager.ETag.Flying);

	public bool smallGround
	{
		get
		{
			if (!enemyPrefab.GetComponentInChildren<Seeker>().graphMask.Contains(0))
			{
				return enemyPrefab.GetComponentInChildren<Seeker>().graphMask.Contains(1);
			}
			return true;
		}
	}

	public bool bigGround => enemyPrefab.GetComponentInChildren<Seeker>().graphMask.Contains(2);
}
