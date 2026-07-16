using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Nuke : MonoBehaviour
{
	private float timer;

	[SerializeField]
	private float timeToBoom = 2f;

	[SerializeField]
	private AnimationCurve speedCurve;

	public float Heal { get; set; }

	public float Damage { get; set; }

	public event Action Destroyed;

	private void Update()
	{
		timer += Time.deltaTime;
		if (timer >= timeToBoom)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		float time = timer / timeToBoom;
		float num = speedCurve.Evaluate(time);
		base.transform.Translate(Vector3.right * num * Time.deltaTime);
	}

	private void OnDestroy()
	{
		DoDamage();
		DoHeal();
		TrackManager.Instance.DestroyObstacle();
		CombatManager.Instance.DestroyProjectiles();
		this.Destroyed?.Invoke();
		this.Destroyed = null;
	}

	private void DoDamage()
	{
		List<EnemyBase> list = EnemyManager.Instance.Enemies.Where((EnemyBase e) => !e.HealthComponent.IsImmune).ToList();
		float num = Damage;
		while (!(num <= 0f) && list.Count != 0)
		{
			for (int num2 = 0; num2 < list.Count; num2++)
			{
				Health healthComponent = list[num2].HealthComponent;
				float num3 = Mathf.Min(Mathf.Min(1f, num), healthComponent.HealthCurrent);
				healthComponent.ChangeHealthWithInfo(new HealthChangeInfo(this, healthComponent, 0f - num3, isPercent: false, null, canRes: false, ignoreArmor: true, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.AoE));
				num -= num3;
				if (healthComponent.HealthCurrent <= 0f)
				{
					list.Remove(list[num2]);
				}
			}
		}
	}

	private void DoHeal()
	{
		List<Health> list = (from m in Train.Instance.Modules
			where m
			select m.HealthComponent).ToList();
		list.Add(Train.Instance.HealthComponent);
		float num = Heal;
		while (!(num <= 0f) && list.Count != 0)
		{
			for (int num2 = 0; num2 < list.Count; num2++)
			{
				Health health = list[num2];
				float num3 = Mathf.Min(Mathf.Min(1f, num), health.HealthMissing);
				health.ChangeHealthWithInfo(new HealthChangeInfo(this, health, num3, isPercent: false, null, canRes: true, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.AoE));
				num -= num3;
				if (health.HealthMissing == 0f)
				{
					list.Remove(health);
				}
			}
		}
	}
}
