using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemyset", menuName = "SimpleSiege/Eternal Trial Enemyset")]
public class EternalTrialEnemySet : ScriptableObject
{
	public List<EternalTrialEnemy> enemies;

	public List<EternalTrialEnemy> ListAllFlying()
	{
		List<EternalTrialEnemy> list = new List<EternalTrialEnemy>();
		foreach (EternalTrialEnemy enemy in enemies)
		{
			if (enemy.flying)
			{
				list.Add(enemy);
			}
		}
		return list;
	}

	public List<EternalTrialEnemy> ListAllGroundSmall()
	{
		List<EternalTrialEnemy> list = new List<EternalTrialEnemy>();
		foreach (EternalTrialEnemy enemy in enemies)
		{
			if (enemy.smallGround)
			{
				list.Add(enemy);
			}
		}
		return list;
	}

	public List<EternalTrialEnemy> ListAllGroundBig()
	{
		List<EternalTrialEnemy> list = new List<EternalTrialEnemy>();
		foreach (EternalTrialEnemy enemy in enemies)
		{
			if (enemy.bigGround)
			{
				list.Add(enemy);
			}
		}
		return list;
	}
}
