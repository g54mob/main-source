using System.Collections.Generic;
using UnityEngine;

public class Monster_CaptainBot : Monster_Basic
{
	public enum eMoveState
	{
		NONE = 0,
		HAS_SOLDIER = 1,
		NO_SOLDIER = 2
	}

	[SerializeField]
	private int soldierCount;

	private eMoveState moveState;

	private Monster_Basic captain;

	private List<Monster_SoldierBot> list_Soldiers;

	private List<Vector3Int> list_RecentPath;

	private Vector3Int curGridPosition;

	private bool isHardModeActive;

	private int finalSoldierCount;

	private float gridDetectInterval;

	private float gridDetectTimer;

	private float monsterDetectInterval;

	private float monsterDetectTimer;

	private int createdSoldierCount;

	protected override void SpawnProc()
	{
	}

	protected override void HitProc(int damage, eDamageType damageType, bool doTriggerHitReaction, bool isFromTower)
	{
	}

	protected override void UpdateProc(float deltaTime)
	{
	}

	private void OnSoldierKilled(AMonsterBase monster)
	{
	}

	protected override void DespawnProc()
	{
	}
}
