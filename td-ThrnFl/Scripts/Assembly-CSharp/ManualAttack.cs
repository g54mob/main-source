using System.Collections.Generic;
using Rewired;
using UnityEngine;
using UnityEngine.Events;

public class ManualAttack : MonoBehaviour
{
	public float spawnAttackHeight;

	public List<TargetPriority> targetPriorities = new List<TargetPriority>();

	public Weapon weapon;

	public float cooldownTime = 1f;

	public Transform transformForAttackDirection;

	public Transform attackMarkerPosition;

	public Transform preferredTargetMarkerPosition;

	public bool autoAttack = true;

	public ParticleSystem particlesOnAttack;

	public bool playOneShotOnAttack;

	public ThronefallAudioManager.AudioOneShot oneshotOnAttack;

	public bool allowAttackWithoutTarget;

	protected float cooldown;

	protected float inputBuffer = -1f;

	protected bool isAttacking;

	protected Hp hpPlayer;

	private Player input;

	protected TaggedObject myTaggedObj;

	private DayNightCycle dayNightCycle;

	private PlayerUpgradeManager upgradeManager;

	protected Vector3 lastTargetPos;

	[HideInInspector]
	public UnityEvent onAttack = new UnityEvent();

	protected AudioSet audioSet;

	protected AudioSet.ClipArray caStillOnCooldown;

	protected AudioSet.ClipArray caAttackTimedPerfectly;

	private AudioSet.ClipArray caCooldownOver;

	protected ThronefallAudioManager audioManager;

	private bool preferredTargetPreviouslySet;

	protected bool timedActivationPerfectly;

	protected TaggedObject preferredTarget;

	protected TaggedObject target;

	public float AttackDamageMultiplyer => upgradeManager.PlayerDamageMultiplyer;

	public float Cooldown
	{
		get
		{
			return cooldown;
		}
		set
		{
			cooldown = value;
		}
	}

	public Vector3 LastTargetPos => lastTargetPos;

	public float CooldownPercentage => Mathf.Clamp01(cooldown / cooldownTime);

	public virtual void Start()
	{
		upgradeManager = PlayerUpgradeManager.instance;
		hpPlayer = GetComponentInParent<Hp>();
		input = ReInput.players.GetPlayer(0);
		myTaggedObj = GetComponentInParent<TaggedObject>();
		dayNightCycle = DayNightCycle.Instance;
		audioSet = ThronefallAudioManager.Instance.audioContent;
		audioManager = ThronefallAudioManager.Instance;
		caStillOnCooldown = audioSet.PlayerCantUseActiveAbility;
		caAttackTimedPerfectly = audioSet.AssasinsTrainingWeaponTimedPerfectly;
		caCooldownOver = audioSet.ActiveAbilityCooldownReadyToUse;
	}

	public virtual void Update()
	{
		if (autoAttack)
		{
			if (hpPlayer.HpValue > 0f)
			{
				Tick();
			}
			DisableMarkersIfDead();
		}
	}

	public void DisableMarkersIfDead()
	{
		if (hpPlayer.HpValue <= 0f)
		{
			if ((bool)attackMarkerPosition)
			{
				attackMarkerPosition.gameObject.SetActive(value: false);
			}
			if ((bool)preferredTargetMarkerPosition)
			{
				preferredTargetMarkerPosition.gameObject.SetActive(value: false);
			}
			cooldown = 0f;
			preferredTarget = null;
		}
	}

	public void Tick()
	{
		float num = cooldown;
		cooldown -= Time.deltaTime;
		if (num > 0f && cooldown <= 0f && !autoAttack && DayNightCycle.Instance.CurrentTimestate == DayNightCycle.Timestate.Night)
		{
			audioManager.PlaySoundAsOneShot(caCooldownOver, 1f, 1f, audioSet.mixGroupFX, 5);
		}
		isAttacking = false;
		HandleAttackUpdate();
		inputBuffer -= Time.deltaTime;
		if ((bool)attackMarkerPosition)
		{
			if (autoAttack || cooldown <= 0f)
			{
				target = FindAttackTarget(_choosePreferredTargetIfPossible: true);
				if (target == null)
				{
					attackMarkerPosition.gameObject.SetActive(value: false);
				}
				else
				{
					if (autoAttack)
					{
						inputBuffer = 0.2f;
						isAttacking = true;
					}
					attackMarkerPosition.gameObject.SetActive(value: true);
					attackMarkerPosition.position = target.transform.position;
				}
			}
			else
			{
				attackMarkerPosition.gameObject.SetActive(value: false);
			}
		}
		if (input.GetButtonDown("Lock Target"))
		{
			TaggedObject taggedObject = FindAttackTargetWithInfiniteRange();
			if (preferredTarget == null)
			{
				preferredTarget = taggedObject;
			}
			else
			{
				preferredTarget = null;
			}
		}
		else if (preferredTarget == null && preferredTargetPreviouslySet)
		{
			TaggedObject taggedObject2 = FindAttackTargetWithInfiniteRange();
			if (taggedObject2 != null)
			{
				preferredTarget = taggedObject2;
			}
		}
		if ((bool)preferredTargetMarkerPosition)
		{
			if ((bool)preferredTarget)
			{
				preferredTargetMarkerPosition.gameObject.SetActive(value: true);
				preferredTargetMarkerPosition.position = preferredTarget.transform.position;
			}
			else
			{
				preferredTargetMarkerPosition.gameObject.SetActive(value: false);
			}
		}
		preferredTargetPreviouslySet = preferredTarget != null;
	}

	public void TryToAttack()
	{
		if (dayNightCycle.CurrentTimestate != DayNightCycle.Timestate.Day || autoAttack)
		{
			if (upgradeManager.assassinsTraining)
			{
				timedActivationPerfectly = Mathf.Abs(cooldown) < UpgradeAssassinsTraining.instance.activationWindow;
			}
			inputBuffer = 0.2f;
			isAttacking = true;
		}
	}

	public virtual void HandleAttackUpdate()
	{
		if (!(inputBuffer >= 0f))
		{
			return;
		}
		if (cooldown > 0f)
		{
			if (!autoAttack && cooldown > inputBuffer)
			{
				audioManager.PlaySoundAsOneShot(caStillOnCooldown, 1f, Random.Range(1.8f, 2.2f), audioSet.mixGroupFX, 5);
				inputBuffer = -1f;
			}
			return;
		}
		inputBuffer = -1f;
		isAttacking = true;
		cooldown = cooldownTime;
		if (timedActivationPerfectly)
		{
			cooldown *= UpgradeAssassinsTraining.instance.cooldownMultiForPerfectlyTimedAttacks;
			audioManager.PlaySoundAsOneShot(caAttackTimedPerfectly, 1f, Random.Range(0.9f, 1.1f), audioSet.mixGroupFX, 4);
		}
		Attack();
	}

	public virtual void Attack()
	{
		TaggedObject taggedObject = FindAttackTarget(_choosePreferredTargetIfPossible: true);
		Hp hp = null;
		if ((bool)taggedObject)
		{
			if ((bool)particlesOnAttack)
			{
				particlesOnAttack.Play();
			}
			if (playOneShotOnAttack)
			{
				ThronefallAudioManager.Oneshot(oneshotOnAttack);
			}
			hp = taggedObject.Hp;
			lastTargetPos = taggedObject.transform.position;
			weapon.Attack(base.transform.position + spawnAttackHeight * Vector3.up, hp, transformForAttackDirection.forward, myTaggedObj, AttackDamageMultiplyer);
			onAttack.Invoke();
		}
		else if (allowAttackWithoutTarget)
		{
			if ((bool)particlesOnAttack)
			{
				particlesOnAttack.Play();
			}
			if (playOneShotOnAttack)
			{
				ThronefallAudioManager.Oneshot(oneshotOnAttack);
			}
			weapon.Attack(base.transform.position + spawnAttackHeight * Vector3.up, null, transformForAttackDirection.forward, myTaggedObj, AttackDamageMultiplyer);
			onAttack.Invoke();
		}
		else
		{
			cooldown = 0f;
			if (!autoAttack)
			{
				audioManager.PlaySoundAsOneShot(caStillOnCooldown, 1f, Random.Range(1.8f, 2.2f), audioSet.mixGroupFX, 5);
			}
		}
	}

	public virtual TaggedObject FindAttackTarget(bool _choosePreferredTargetIfPossible = false)
	{
		if (_choosePreferredTargetIfPossible && (bool)preferredTarget && TagManager.instance.MeasureDistanceToTaggedObject(preferredTarget, base.transform.position) <= targetPriorities[0].range)
		{
			return preferredTarget;
		}
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

	public virtual TaggedObject FindAttackTargetWithInfiniteRange(bool _choosePreferredTargetIfPossible = false)
	{
		TaggedObject taggedObject = FindAttackTarget(_choosePreferredTargetIfPossible);
		if ((bool)taggedObject)
		{
			return taggedObject;
		}
		if (_choosePreferredTargetIfPossible && (bool)preferredTarget && TagManager.instance.MeasureDistanceToTaggedObject(preferredTarget, base.transform.position) <= 1000000f)
		{
			return preferredTarget;
		}
		for (int i = 0; i < targetPriorities.Count; i++)
		{
			TaggedObject taggedObject2 = targetPriorities[i].FindClosestTaggedObjectWithoutMaxDistanceCheck(base.transform.position);
			if (taggedObject2 != null)
			{
				return taggedObject2;
			}
		}
		return null;
	}
}
