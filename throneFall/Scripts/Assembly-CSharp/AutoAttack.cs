using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutoAttack : MonoBehaviour
{
	[BalancingParameter(BalancingParameter.EType.Default)]
	public float cooldownDuration = 1f;

	public float cooldownAfterSpawn = -1f;

	[Range(0f, 1f)]
	public float cooldownRandomization;

	[Tooltip("How often this script checks if an attack is possible once the cooldown is down")]
	public float recheckTargetInterval = 0.5f;

	public List<TargetPriority> targetPriorities = new List<TargetPriority>();

	public Weapon weapon;

	public float spawnAttackHeight = 0.5f;

	protected TaggedObject taggedObject;

	protected float cooldown = -1f;

	[HideInInspector]
	public bool onCooldown;

	public Transform optionalAttackOrigin;

	[SerializeField]
	protected float damageMultiplyer = 1f;

	[SerializeField]
	protected float projectileSpeedMultiplyer = 1f;

	[HideInInspector]
	public UnityEvent onAttackTriggered = new UnityEvent();

	private protected Vector3 lastTargetPosition;

	public float DamageMultiplyer
	{
		get
		{
			return damageMultiplyer;
		}
		set
		{
			damageMultiplyer = value;
		}
	}

	public float ProjectileSpeedMultiplyer
	{
		get
		{
			return projectileSpeedMultiplyer;
		}
		set
		{
			projectileSpeedMultiplyer = value;
		}
	}

	public Vector3 LastTargetPosition => lastTargetPosition;

	public void ReduceCooldownBy(float _reduceBy)
	{
		cooldown -= _reduceBy;
	}

	public void SetCooldownTo(float _cooldown)
	{
		cooldown = _cooldown;
		cooldownAfterSpawn = _cooldown;
	}

	public virtual void Start()
	{
		cooldown = cooldownAfterSpawn;
		taggedObject = GetComponent<TaggedObject>();
	}

	public virtual void Update()
	{
		cooldown -= Time.deltaTime;
		if (!(cooldown > 0f))
		{
			TaggedObject taggedObject = FindAutoAttackTarget();
			if (taggedObject == null)
			{
				cooldown += recheckTargetInterval;
				onCooldown = false;
			}
			else
			{
				cooldown += cooldownDuration * (1f + (1f - 2f * Random.value) * cooldownRandomization);
				OnAttack(taggedObject);
			}
		}
	}

	public virtual void OnAttack(TaggedObject target)
	{
		Vector3 attackOrigin = base.transform.position + spawnAttackHeight * Vector3.up;
		if (optionalAttackOrigin != null)
		{
			attackOrigin = optionalAttackOrigin.position;
		}
		weapon.Attack(attackOrigin, target.Hp, Vector3.zero, taggedObject, damageMultiplyer, projectileSpeedMultiplyer);
		lastTargetPosition = target.transform.position;
		onAttackTriggered.Invoke();
		onCooldown = true;
	}

	public virtual TaggedObject FindAutoAttackTarget()
	{
		for (int i = 0; i < targetPriorities.Count; i++)
		{
			TaggedObject taggedObject = targetPriorities[i].FindClosestTaggedObject(base.transform.position);
			if (taggedObject != null)
			{
				return taggedObject;
			}
		}
		return null;
	}

	public static TaggedObject FindAutoAttackTarget(List<TargetPriority> targetPriorities, Vector3 ownPosition)
	{
		for (int i = 0; i < targetPriorities.Count; i++)
		{
			TaggedObject taggedObject = targetPriorities[i].FindClosestTaggedObject(ownPosition);
			if (taggedObject != null)
			{
				return taggedObject;
			}
		}
		return null;
	}
}
