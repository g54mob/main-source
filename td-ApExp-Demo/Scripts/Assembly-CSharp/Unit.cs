using System;
using System.Collections;
using System.Collections.Generic;
using AudioSystem;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(StatusEffectComponent))]
[RequireComponent(typeof(Collider2D))]
public class Unit : MonoBehaviour
{
	public delegate void TargetChangeHandler(Unit newUnit);

	protected SoundBuilder soundBuilder;

	[SerializeField]
	public bool ignoreProjectiles;

	[SerializeField]
	public bool isImmuneToEMP;

	[SerializeField]
	private bool isHackable;

	[SerializeField]
	public bool IsHacked;

	[SerializeField]
	public bool IsGrounded = true;

	[NonSerialized]
	public float lastFloatingDamageNumberSpawnTime;

	[NonSerialized]
	public List<EMPProjectile> attachedEMPs = new List<EMPProjectile>();

	[NonSerialized]
	public int maxNumberOfOpponents = 100;

	[NonSerialized]
	public int numberOfCurrentOpponents;

	protected bool lastEnemySide;

	[SerializeField]
	private bool isEnemy;

	private Unit targetUnit;

	public bool isShieldPlate;

	protected Coroutine snotCoroutine;

	protected float lastSnotStrength;

	[field: NonSerialized]
	[field: Header("Unit")]
	public Health HealthComponent { get; private set; }

	[field: SerializeField]
	[field: Range(0f, 1f)]
	public float DodgeProb { get; set; }

	[field: SerializeField]
	public bool IsElite { get; private set; }

	public bool IsEMPattached
	{
		get
		{
			if (attachedEMPs != null)
			{
				return attachedEMPs.Count > 0;
			}
			return false;
		}
	}

	public bool IsHackable
	{
		get
		{
			return isHackable;
		}
		set
		{
			isHackable = value;
			if (!value && !IsEnemy)
			{
				Hack(isHacked: false);
			}
		}
	}

	public bool IsEnemyStatusOriginal { get; private set; }

	public bool IsEnemy
	{
		get
		{
			return isEnemy;
		}
		set
		{
			lastEnemySide = isEnemy;
			isEnemy = value;
			if (isEnemy != lastEnemySide)
			{
				OnFactionChanged();
			}
		}
	}

	public Unit TargetUnit
	{
		get
		{
			return targetUnit;
		}
		set
		{
			targetUnit = value;
			this.OnTargetChanged?.Invoke(value);
		}
	}

	public event TargetChangeHandler OnTargetChanged;

	protected void Awake()
	{
		HealthComponent = GetComponent<Health>();
		IsEnemyStatusOriginal = IsEnemy;
		soundBuilder = PersistentSingleton<SoundEmitterManager>.Instance.CreateSoundBuilder();
	}

	protected void Start()
	{
		LevelManager.Instance.DestinationReached += ClearSnotOnLevelEnd;
	}

	public virtual bool TryDodge()
	{
		return ProbUtils.CheckWithLuck(DodgeProb);
	}

	protected virtual void OnFactionChanged()
	{
	}

	public virtual void Hack(bool isHacked)
	{
		IsHacked = isHacked;
		if (isHacked)
		{
			if (base.gameObject != null && HealthComponent != null && !HealthComponent.IsDead && TryGetComponent<Outline>(out var component))
			{
				component.SetOutline(isActive: true, UIManager.Instance.HackedColor);
			}
			IsEnemy = !IsEnemyStatusOriginal;
			HealthComponent.RemoveSunder();
			HealthComponent.RemoveWeaken();
		}
		else
		{
			if (base.gameObject != null && HealthComponent != null && !HealthComponent.IsDead && TryGetComponent<Outline>(out var component2))
			{
				component2.SetOutline(isActive: false, Color.white);
			}
			IsEnemy = IsEnemyStatusOriginal;
		}
	}

	public void SnotUnit(float duration, float strength)
	{
		if (snotCoroutine != null)
		{
			StopCoroutine(snotCoroutine);
			RemoveSnot(lastSnotStrength);
		}
		snotCoroutine = StartCoroutine(SnotCoroutine(duration, strength));
	}

	protected IEnumerator SnotCoroutine(float duration, float strength)
	{
		ApplySnot(strength);
		yield return new WaitForSeconds(duration);
		RemoveSnot(strength);
		snotCoroutine = null;
	}

	protected virtual void ApplySnot(float strength)
	{
		lastSnotStrength = strength;
	}

	protected virtual void RemoveSnot(float strength)
	{
		lastSnotStrength = 0f;
	}

	protected virtual void ClearSnotOnLevelEnd()
	{
		if (snotCoroutine != null)
		{
			StopCoroutine(snotCoroutine);
			RemoveSnot(lastSnotStrength);
		}
	}
}
