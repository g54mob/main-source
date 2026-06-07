using System.Collections;
using UnityEngine;

public class PlayerUpgradeManager : MonoBehaviour, DayNightCycle.IDaytimeSensitive, ISaveLoad
{
	[SerializeField]
	private Hp hp;

	public static PlayerUpgradeManager instance;

	private PerkManager perkManager;

	private float playerDamageMultiplyer = 1f;

	private float playerHealthRegenerationMultiplyer = 1f;

	public bool assassinsTraining;

	public bool godlyCurse;

	public bool magicArmor;

	public bool commander;

	public float godlyCurseDamageMultiplyer = 1.5f;

	private int damageIncreases;

	public float PlayerDamageMultiplyer
	{
		get
		{
			if (!perkManager)
			{
				perkManager = PerkManager.instance;
			}
			if (perkManager.RiskTakerEquipped)
			{
				return Mathf.Lerp(perkManager.riskTakerMaxBonusDamageMultiplyer, 1f, hp.HpPercentage) * playerDamageMultiplyer;
			}
			return playerDamageMultiplyer;
		}
		set
		{
			playerDamageMultiplyer = value;
		}
	}

	public float PlayerHealthRegenerationMultiplyer
	{
		get
		{
			return playerHealthRegenerationMultiplyer;
		}
		set
		{
			playerHealthRegenerationMultiplyer = value;
		}
	}

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		perkManager = PerkManager.instance;
		if ((bool)DayNightCycle.Instance)
		{
			DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		}
		if (PerkManager.instance.CommanderModeActive)
		{
			playerDamageMultiplyer *= PerkManager.instance.commanderModeSelfDmgMulti;
		}
		if (PerkManager.instance.GlassCanonActive)
		{
			playerDamageMultiplyer *= PerkManager.instance.glassCanon_dmgMulti;
		}
	}

	public void OnDusk()
	{
		GetStrongerIfInWarriorMode();
	}

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDawn_BeforeSunrise()
	{
		GetStrongerIfInWarriorMode();
	}

	public void GetStrongerIfInWarriorMode()
	{
		while (PerkManager.instance.WarriorModeActive && damageIncreases < EnemySpawner.instance.Wavenumber)
		{
			damageIncreases++;
			playerDamageMultiplyer *= Mathf.Pow(PerkManager.instance.warriorModeSelfDmgMultiMax, 1f / (float)EnemySpawner.instance.WaveCount);
		}
	}

	public void OnDuskEarly()
	{
	}

	public void OnBeforeMainLoadPass(string guid)
	{
	}

	public void OnLoad(string guid)
	{
	}

	public void OnAfterMainLoadPass(string guid)
	{
		StartCoroutine(DelayLoadedGetStronger());
	}

	public void OnSave(string guid)
	{
	}

	private IEnumerator DelayLoadedGetStronger()
	{
		yield return null;
		yield return null;
		GetStrongerIfInWarriorMode();
	}
}
