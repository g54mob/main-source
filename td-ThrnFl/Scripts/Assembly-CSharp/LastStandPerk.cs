using System.Collections.Generic;
using UnityEngine;

public class LastStandPerk : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	[SerializeField]
	private Hp hp;

	private float healthLast;

	private float threshhold;

	private List<TagManager.ETag> mustHave = new List<TagManager.ETag>();

	private List<TagManager.ETag> mayNotHave = new List<TagManager.ETag>();

	private bool canStillBeTriggeredTonight = true;

	private void OnEnable()
	{
		if (PerkManager.instance == null)
		{
			Object.Destroy(this);
			return;
		}
		if (!PerkManager.instance.LastStandEquipped)
		{
			Object.Destroy(this);
			return;
		}
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		threshhold = PerkManager.instance.lastStandHealthThreshhold;
		healthLast = hp.HpValue;
		mustHave.Clear();
		mustHave.Add(TagManager.ETag.Tower);
		mayNotHave.Clear();
		canStillBeTriggeredTonight = true;
	}

	private void Update()
	{
		if (healthLast > hp.HpValue && hp.HpPercentage <= threshhold && healthLast > threshhold && canStillBeTriggeredTonight)
		{
			LastStand();
		}
		healthLast = hp.HpValue;
	}

	private void LastStand()
	{
		Hp.ReviveAllUnitsWithTag(mustHave, mayNotHave);
		canStillBeTriggeredTonight = false;
	}

	public void OnDuskEarly()
	{
	}

	public void OnDusk()
	{
		canStillBeTriggeredTonight = true;
	}

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDawn_BeforeSunrise()
	{
	}
}
