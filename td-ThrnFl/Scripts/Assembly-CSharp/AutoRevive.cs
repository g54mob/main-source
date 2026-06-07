using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Hp))]
public class AutoRevive : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	[SerializeField]
	private PlayerHpRegen playerHpRegen;

	[HideInInspector]
	public UnityEvent onReviveTrigger = new UnityEvent();

	private Hp hp;

	public float reviveAfterBeingKnockedOutFor = 20f;

	public float refillHealthForSecs = 10f;

	private float hasBeenKnockedOutFor;

	private bool ringOfResurection;

	private bool quickReviveAvailable = true;

	private bool godOfDeathActive;

	private bool explosiveRevivalActive;

	[SerializeField]
	private Weapon explosiveRevivalWeapon;

	[SerializeField]
	private Equippable explosiveRevivalPerk;

	private DayNightCycle dayNightCycle;

	[SerializeField]
	private Equippable ringOfResurectionPerk;

	[SerializeField]
	private float minHealthOnRevive = 0.05f;

	private float ReviveAfterBeingKnockedOutFor
	{
		get
		{
			if (ringOfResurection && quickReviveAvailable)
			{
				return 2f;
			}
			return reviveAfterBeingKnockedOutFor;
		}
	}

	public float TimeTillRevive
	{
		get
		{
			if (hasBeenKnockedOutFor <= 0f)
			{
				return -1f;
			}
			return ReviveAfterBeingKnockedOutFor - hasBeenKnockedOutFor;
		}
	}

	public void OnDusk()
	{
	}

	public void OnDawn_AfterSunrise()
	{
		quickReviveAvailable = true;
	}

	public void OnDawn_BeforeSunrise()
	{
	}

	private void Start()
	{
		dayNightCycle = DayNightCycle.Instance;
		godOfDeathActive = PerkManager.instance.GodOfDeathActive;
		explosiveRevivalActive = PerkManager.IsEquipped(explosiveRevivalPerk);
		if (godOfDeathActive)
		{
			reviveAfterBeingKnockedOutFor *= PerkManager.instance.godOfDeath_playerRespawnMultiplyer;
		}
		hp = GetComponent<Hp>();
		ringOfResurection = PerkManager.IsEquipped(ringOfResurectionPerk);
		dayNightCycle.RegisterDaytimeSensitiveObject(this);
	}

	private void Update()
	{
		if (hp.KnockedOut)
		{
			if (dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Day)
			{
				hp.Revive();
				onReviveTrigger.Invoke();
			}
			hasBeenKnockedOutFor += Time.deltaTime;
			if (hasBeenKnockedOutFor >= ReviveAfterBeingKnockedOutFor)
			{
				if (ringOfResurection && quickReviveAvailable)
				{
					hp.Revive();
				}
				else
				{
					hp.Revive(callReviveEvent: true, Mathf.Max(playerHpRegen.HealingPerSecond * refillHealthForSecs / hp.maxHp, minHealthOnRevive));
				}
				if (ringOfResurection && quickReviveAvailable)
				{
					Hp.ReviveAllUnitsWithTag(new List<TagManager.ETag> { TagManager.ETag.PlayerUnit }, new List<TagManager.ETag>());
				}
				if (explosiveRevivalActive)
				{
					explosiveRevivalWeapon.Attack(base.transform.position, null, Vector3.zero, null);
				}
				onReviveTrigger.Invoke();
				quickReviveAvailable = false;
			}
		}
		else
		{
			hasBeenKnockedOutFor = 0f;
		}
	}

	public void OnDuskEarly()
	{
	}
}
