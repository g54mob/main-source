using System.Collections.Generic;
using UnityEngine;

public class UpgradeGodlyCurse : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	public static UpgradeGodlyCurse instance;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Percentage)]
	private float damagePercentage;

	private HashSet<Hp> damagedHpObjects = new HashSet<Hp>();

	private void Awake()
	{
		instance = this;
	}

	private void OnEnable()
	{
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		PlayerUpgradeManager.instance.godlyCurse = true;
	}

	public void Damage(Hp _hp)
	{
		if (!damagedHpObjects.Contains(_hp))
		{
			_hp.TakeDamage(_hp.maxHp * damagePercentage);
			damagedHpObjects.Add(_hp);
		}
	}

	public void OnDuskEarly()
	{
		damagedHpObjects.Clear();
	}

	public void OnDusk()
	{
	}

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDawn_BeforeSunrise()
	{
	}
}
