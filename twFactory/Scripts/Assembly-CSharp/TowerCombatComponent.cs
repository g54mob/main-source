using System;
using UnityEngine;

public class TowerCombatComponent : CombatComponent
{
	[SerializeField]
	private EDamageMultiplier healthMultiplier = EDamageMultiplier.Normal;

	[SerializeField]
	private EDamageMultiplier armorMultiplier = EDamageMultiplier.Normal;

	[SerializeField]
	private EDamageMultiplier shieldMultiplier = EDamageMultiplier.Normal;

	[SerializeField]
	private Enemy.EEnemyType validEnemyTypes;

	[SerializeField]
	private bool startWithKeepTarget;

	[SerializeField]
	[Tooltip("Máximo ángulo al que puede estar apuntando la torre con respecto al target para disparar")]
	private float maxAngleToAttack = 15f;

	[SerializeField]
	private Transform shootTransform;

	[SerializeField]
	private Transform auxPitchAimTransform;

	private AbilityManager abilityManager;

	private Tower tower;

	public Transform ShootTransform => shootTransform;

	public EDamageMultiplier HealthMultiplier
	{
		get
		{
			return healthMultiplier;
		}
		set
		{
			healthMultiplier = value;
		}
	}

	public EDamageMultiplier ArmorMultiplier
	{
		get
		{
			return armorMultiplier;
		}
		set
		{
			armorMultiplier = value;
		}
	}

	public EDamageMultiplier ShieldMultiplier
	{
		get
		{
			return shieldMultiplier;
		}
		set
		{
			shieldMultiplier = value;
		}
	}

	public Enemy.EEnemyType ValidEnemyTypes => validEnemyTypes;

	public bool StartWithKeepTarget => startWithKeepTarget;

	public event Action<Enemy, Tower, FDamageData, Vector3, bool, object> onPreDamageEnemy;

	public event Action<Enemy, Tower, FDamageData, Vector3, bool, object, FDamageReport> onDamageEnemy;

	protected override void Awake()
	{
		base.Awake();
		abilityManager = GetComponent<AbilityManager>();
		tower = GetComponent<Tower>();
	}

	private void OnDisable()
	{
		Die();
	}

	public void Attack(CombatComponent target)
	{
		if (!base.AimTransform || Vector2.Angle(base.AimTransform.forward.XZ(), (target.transform.position - base.transform.position).XZ()) <= maxAngleToAttack)
		{
			abilityManager.UseAutoAttackAbility(target);
		}
	}

	public bool CanTargetEnemy(Enemy enemy)
	{
		if ((enemy.EnemyType & ValidEnemyTypes) > (Enemy.EEnemyType)0)
		{
			return enemy.CombatComponent.IsTargetable();
		}
		return false;
	}

	public virtual void DoDamageToEnemy(Enemy enemy, FDamageData damageData, Vector3 damagePosition, bool isMainDamage, object auxData = null)
	{
		this.onPreDamageEnemy?.Invoke(enemy, tower, damageData, damagePosition, isMainDamage, auxData);
		FDamageReport arg = null;
		if ((bool)enemy)
		{
			arg = enemy.CombatComponent.DoDamage(base.gameObject, damageData);
		}
		this.onDamageEnemy?.Invoke(enemy, tower, damageData, damagePosition, isMainDamage, auxData, arg);
	}

	public override void Aim(GameObject aimTarget)
	{
		if ((bool)base.AimTransform)
		{
			Aim(aimTarget.transform.position - base.AimTransform.position);
		}
		if ((bool)auxPitchAimTransform)
		{
			Vector3 vector = aimTarget.transform.position - auxPitchAimTransform.position;
			Vector3 normalized = vector.normalized;
			normalized.y = 0f;
			float angle = Vector3.SignedAngle(vector.normalized, normalized, Vector3.Cross(vector.normalized, normalized));
			if (vector.sqrMagnitude != 0f)
			{
				auxPitchAimTransform.localRotation = Quaternion.RotateTowards(auxPitchAimTransform.localRotation, Quaternion.AngleAxis(angle, Vector3.right), base.AimRotationSpeed * Time.deltaTime);
			}
		}
	}
}
