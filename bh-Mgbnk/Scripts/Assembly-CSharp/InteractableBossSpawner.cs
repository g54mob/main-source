using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Enemies;
using UnityEngine;

public class InteractableBossSpawner : BaseInteractable
{
	public GameObject minimapIcon;

	private List<Enemy> bossEnemies;

	public static Action A_BossSpawned;

	public static Action<bool> A_BossDefeated;

	public static Action<int> A_NumBossesDefeated;

	public GameObject preventObjectsSpawningHere;

	public GameObject portal;

	private int numBossesDefeated;

	public GameObject bossCurseFx;

	private void Awake()
	{
	}

	private new void OnDestroy()
	{
	}

	private new void Start()
	{
	}

	private void OnEnemyReleasedFromPool(Enemy enemy)
	{
	}

	private bool CanSpawnPortal()
	{
		return false;
	}

	public override bool Interact()
	{
		return false;
	}

	private void OnInteractable(BaseInteractable interactable, bool success)
	{
	}

	public override string GetInteractString()
	{
		return null;
	}
}
