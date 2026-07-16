using System;
using System.Linq;
using AudioSystem;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	[SerializeField]
	private int maxModulesDamaged = 3;

	[NonSerialized]
	public bool sunder;

	public bool muteExplosion;

	public SoundData explosionSound;

	private const float PS_SCALE_MULT = 8f;

	private const float DEVIATION = 0.25f;

	private const float EXP_PS_DURATION = 2.5f;

	private float durationTimer;

	[SerializeField]
	private ParticleSystem[] pss;

	[SerializeField]
	private AudioClip[] audioClips;

	private AudioSource audioSource;

	private float radius = 1f;

	public Unit SourceUnit { get; private set; }

	[field: SerializeField]
	public float TrainDamage { get; private set; }

	[field: SerializeField]
	public float EnemyDamage { get; private set; }

	public float Radius
	{
		get
		{
			return radius;
		}
		private set
		{
			float num = 1f;
			if ((bool)SourceUnit)
			{
				num = ((!SourceUnit.IsEnemy) ? GlobalFields.Instance.ExplosionRadiusMult : 1f);
			}
			float num2 = UnityEngine.Random.Range(-0.25f, 0.25f);
			value += value * num2 * num;
			foreach (Transform item in pss.Select((ParticleSystem p) => p.transform))
			{
				item.localScale = Vector3.one * value * 8f;
			}
			if ((bool)audioSource)
			{
				audioSource.pitch = 1f + num2 / 2f;
			}
			radius = value;
		}
	}

	public event Delegates.HealthChangeHandler OnExplosionHit;

	public event Delegates.HealthChangeHandler OnExplosionKill;

	public void Initialize(Unit sourceUnit, float radius, float enemyDamage, float trainDamage = 0f, bool mute = false)
	{
		durationTimer = 2.5f;
		if (!muteExplosion && !mute)
		{
			PersistentSingleton<SoundEmitterManager>.Instance.CreateSoundBuilder().Play(explosionSound);
		}
		else
		{
			durationTimer = 1f;
		}
		SourceUnit = sourceUnit;
		Radius = radius;
		EnemyDamage = enemyDamage;
		TrainDamage = trainDamage;
		base.gameObject.SetActive(value: true);
		Component[] components = GetComponents<Component>();
		foreach (Component component in components)
		{
			if (component is Behaviour)
			{
				((Behaviour)component).enabled = true;
			}
		}
		CombatManager.Instance.OnExplosionSpawned(this);
	}

	private void Start()
	{
		DamageTrain();
		DamageEnemiesWithinRadius();
	}

	private void Update()
	{
		durationTimer -= Time.deltaTime;
		if (durationTimer <= 0f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		base.transform.position += new Vector3(-1f, 0f) * Train.Instance.TrainSpeedNormalized * Time.deltaTime;
	}

	private void DamageTrain()
	{
		if (TrainDamage == 0f)
		{
			return;
		}
		Collider2D[] array = Physics2D.OverlapCircleAll(base.transform.position, radius, LayerMask.GetMask("Unit", "Enemy"));
		if (array == null || array.Length == 0)
		{
			return;
		}
		Collider2D[] array2 = array.OrderBy((Collider2D col) => Vector2.Distance(col.transform.position, base.transform.position)).Take(maxModulesDamaged).ToArray();
		for (int num = 0; num < array2.Length; num++)
		{
			Module componentInChildren = array2[num].GetComponentInChildren<Module>();
			if (!(componentInChildren == null))
			{
				HealthChangeInfo info = new HealthChangeInfo(SourceUnit, componentInChildren.HealthComponent, 0f - TrainDamage, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.AoE);
				componentInChildren.HealthComponent.ChangeHealthWithInfo(info);
			}
		}
	}

	private void DamageEnemiesWithinRadius()
	{
		if (EnemyDamage == 0f)
		{
			return;
		}
		Collider2D[] array = Physics2D.OverlapCircleAll(base.transform.position, radius, LayerMask.GetMask("Unit", "Mine", "Enemy"));
		if (array == null || array.Length == 0)
		{
			return;
		}
		Collider2D[] array2 = array;
		foreach (Collider2D collider2D in array2)
		{
			float distance = Vector3.Distance(base.transform.position, collider2D.transform.position);
			float num = EnemyDamage * GlobalFields.Instance.ExplosionDamageMult;
			collider2D.GetComponent<ProjectileMortarShell>()?.DestroyProjectile();
			Unit component = collider2D.GetComponent<Unit>();
			if (((object)component == null || component.IsEnemy) && !(num <= 0f) && collider2D.TryGetComponent<Health>(out var component2) && (bool)component2 && !component2.IsDead && (!(component2.gameObject.GetComponent<Unit>() != null) || !component2.gameObject.GetComponent<Unit>().ignoreProjectiles || (bool)component2.gameObject.GetComponent<E3_5_StealthBomber>()))
			{
				Vector2 direction = (collider2D.transform.position - base.transform.position).normalized;
				RaycastHit2D value = Physics2D.Raycast(base.transform.position, direction, distance, LayerMask.GetMask("Unit", "Mine", "Enemy"));
				HealthChangeInfo healthChangeInfo = new HealthChangeInfo(SourceUnit, component2, 0f - num, isPercent: false, value, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.AoE);
				if (healthChangeInfo.IsLethal)
				{
					this.OnExplosionKill?.Invoke(healthChangeInfo);
				}
				component2.ChangeHealthWithInfo(healthChangeInfo);
				this.OnExplosionHit?.Invoke(healthChangeInfo);
				if (sunder)
				{
					component2.ApplySunder();
				}
			}
		}
	}

	private void OnDestroy()
	{
		this.OnExplosionHit = null;
		CombatManager.Instance.OnExplosionDestroyed(this);
	}
}
