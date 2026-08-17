using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Game.Combat.EnemySpecialAttacks;

public class EnemyAttackEffectPrefab : MonoBehaviour
{
	public EEnemyAttack eAttack;

	public float aliveTime = 1f;

	private float returnTime;

	private void OnEnable()
	{
		float num = MyTime.time + aliveTime;
		returnTime = num;
	}

	private void Update()
	{
		if (MyTime.time > returnTime)
		{
			PoolManager.Instance.ReturnEnemyAttackFx(this);
		}
	}
}
