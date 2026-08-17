using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory.Stats;
using UnityEngine;
using Utility;

namespace Assets.Scripts.Game.Combat.EnemySpecialAttacks;

[Serializable]
public class EnemySpecialAttack : IComparer<EnemySpecialAttack>
{
	public bool isEnabled = true;

	public int priority;

	public string attackName;

	public GameObject attackPrefab;

	public float attackChargeTime = 1f;

	public float attackRadius = 4f;

	public float attackCooldown = 5f;

	public float attackCooldownMax;

	public float initialCooldown;

	public float duration;

	public float nextSpecialAttackCooldown = 3f;

	public float triggerDistance = 5f;

	public float endLag = 1f;

	public float damageMultiplier = 1f;

	public float GetDamage(Enemy enemy)
	{
		float damage = EnemyStats.GetDamage(enemy);
		return damage * damageMultiplier;
	}

	public unsafe int Compare(EnemySpecialAttack x, EnemySpecialAttack y)
	{
		//IL_00b3: Expected I4, but got I8
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected I4, but got Unknown
		//IL_00d5: Expected I4, but got O
		//IL_00a0: Expected I4, but got I8
		int num2;
		if (x != y)
		{
			if (y == null)
			{
				return 1;
			}
			if (x == null)
			{
				return -1;
			}
			int num = x + 20;
			num2 = ((int*)num)->CompareTo(y.priority);
			if (num2 == 0)
			{
				if (MyRandom.random != null)
				{
					return MyRandom.random.Next(-1, 2);
				}
				NullReferenceException ex = new NullReferenceException();
				return (int)ex;
			}
		}
		else
		{
			num2 = 0;
		}
		return num2;
	}
}
