using System.Collections.Generic;
using UnityEngine;

public class DiagnosticsDamageTaken : MonoBehaviour
{
	private readonly bool ENABLED;

	private readonly bool ENABLE_ENEMY_KILLED_DURATION;

	private Dictionary<string, int> damagePerEnemy;

	private Character activeEnemy;

	private int activeEnemyStartTime;

	public static DiagnosticsDamageTaken singleton { get; private set; }

	public void PrintAndReset()
	{
	}

	private void OnCharacterGoingToTakeDamage(Character c, Damage dmg)
	{
	}

	private void OnCharacterDied(Character c, Character.DeathReason reason, Damage damage)
	{
	}

	private void OnCharacterTookDamage(Character c, Damage dmg)
	{
		if (c == GameStates.Singleton.hero)
		{
			Debug.Log("Player took " + dmg.amount + " damage from " + dmg.Owner);
			string id = dmg.Owner.id;
			if (damagePerEnemy.ContainsKey(id))
			{
				damagePerEnemy[id] += dmg.amount;
			}
			else
			{
				damagePerEnemy.Add(id, dmg.amount);
			}
		}
		if (ENABLE_ENEMY_KILLED_DURATION)
		{
			_ = dmg.Owner == GameStates.Singleton.hero;
		}
	}

	public void ClearDamagePerEnemy()
	{
		damagePerEnemy = new Dictionary<string, int>();
	}

	public void PrintDamagePerEnemy()
	{
		foreach (KeyValuePair<string, int> item in damagePerEnemy)
		{
			Debug.Log("Total damage dealt by " + item.Key + " = " + item.Value);
		}
	}

	private void Awake()
	{
		singleton = this;
	}
}
