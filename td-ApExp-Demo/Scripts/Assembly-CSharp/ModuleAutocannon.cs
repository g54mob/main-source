using System;
using UnityEngine;

public class ModuleAutocannon : Module
{
	[Header("Autocannon Fields")]
	public GameObject projectile;

	public bool nCannonActive;

	public bool sCannonActive;

	private Autocannon autocannonN;

	private Autocannon autocannonS;

	private GameObject doubleLoader;

	[NonSerialized]
	public bool frenzy;

	[NonSerialized]
	public float frenzyDuration;

	[NonSerialized]
	public float frenzyAttackSpeedGain;

	[NonSerialized]
	public bool findHighestHpTarget;

	[NonSerialized]
	public bool findLowestHpTarget;

	private int ammoCurrent;

	public int AmmoCurrent
	{
		get
		{
			return ammoCurrent;
		}
		set
		{
			ammoCurrent = value;
			Vector3 localScale = new Vector3(1f - (float)ammoCurrent / GetUpgradedStatValueByStatType(StatTypes.capacity), 1f, 1f);
			autocannonN.Mask.localScale = localScale;
			autocannonS.Mask.localScale = localScale;
		}
	}

	public event Delegates.HealthChangeHandler OnKill;

	private new void Start()
	{
		base.Start();
		doubleLoader = base.transform.Find("Double Loader").gameObject;
		autocannonN = base.transform.Find("Autocannon N").GetComponent<Autocannon>();
		autocannonN.module = this;
		autocannonS = base.transform.Find("Autocannon S").GetComponent<Autocannon>();
		autocannonS.module = this;
		autocannonN.OnKill += OnKillHandler;
		autocannonS.OnKill += OnKillHandler;
		SetAutocannonsActive(northActive: true, southActive: true);
	}

	protected override void SetEmpSoundChannels()
	{
	}

	private void OnKillHandler(HealthChangeInfo info)
	{
		this.OnKill?.Invoke(info);
	}

	public override bool CanInteract()
	{
		return false;
	}

	protected override void OnInteractStart(Interactor interactor)
	{
		AmmoCurrent = (int)GetUpgradedStatValueByStatType(StatTypes.capacity);
	}

	public void ChooseRandomAutocannonActive()
	{
		if (UnityEngine.Random.Range(0, 2) == 0)
		{
			SetAutocannonsActive(northActive: true, southActive: false);
		}
		else
		{
			SetAutocannonsActive(northActive: false, southActive: true);
		}
	}

	public void SetAutocannonsActive(bool northActive, bool southActive)
	{
		autocannonN.gameObject.SetActive(northActive);
		autocannonS.gameObject.SetActive(southActive);
		if (northActive && southActive)
		{
			autocannonN.LoaderActive(active: false);
			autocannonS.LoaderActive(active: false);
			doubleLoader.SetActive(value: true);
			GetComponent<Outline>().outlineSr = doubleLoader.GetComponent<SpriteRenderer>();
		}
		else if (northActive)
		{
			autocannonN.LoaderActive(northActive);
			doubleLoader.SetActive(value: false);
			GetComponent<Outline>().outlineSr = autocannonN.LoaderSr;
		}
		else if (southActive)
		{
			autocannonS.LoaderActive(southActive);
			doubleLoader.SetActive(value: false);
			GetComponent<Outline>().outlineSr = autocannonS.LoaderSr;
		}
	}

	protected override void Break(HealthChangeInfo info)
	{
		base.Break(info);
	}

	public void PlayShotSound()
	{
		PlayModuleUniqueSound();
	}
}
