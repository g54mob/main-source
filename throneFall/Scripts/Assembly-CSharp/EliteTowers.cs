using UnityEngine;

public class EliteTowers : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	private bool eliteMode;

	[SerializeField]
	private GameObject eliteModeMarker;

	[SerializeField]
	private GameObject intactParent;

	private void Start()
	{
		if (PerkManager.instance.EliteTowersEquipped)
		{
			if ((bool)DayNightCycle.Instance)
			{
				DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
			}
			GetComponentInParent<BuildSlot>().OnUpgrade.AddListener(PutIntoEliteMode);
		}
	}

	private void PutIntoEliteMode()
	{
		if (!eliteMode)
		{
			eliteMode = true;
			eliteModeMarker.SetActive(value: true);
			AutoAttack[] componentsInChildren = intactParent.GetComponentsInChildren<AutoAttack>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].DamageMultiplyer *= PerkManager.instance.eliteTowerDamageMultiplyer;
			}
			HotOilTower[] componentsInChildren2 = intactParent.GetComponentsInChildren<HotOilTower>();
			for (int i = 0; i < componentsInChildren2.Length; i++)
			{
				componentsInChildren2[i].DamageMultiplyer *= PerkManager.instance.eliteTowerDamageMultiplyer;
			}
		}
	}

	private void GoOutOfEliteMode()
	{
		if (eliteMode)
		{
			eliteMode = false;
			eliteModeMarker.SetActive(value: false);
			AutoAttack[] componentsInChildren = intactParent.GetComponentsInChildren<AutoAttack>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].DamageMultiplyer /= PerkManager.instance.eliteTowerDamageMultiplyer;
			}
			HotOilTower[] componentsInChildren2 = intactParent.GetComponentsInChildren<HotOilTower>();
			for (int i = 0; i < componentsInChildren2.Length; i++)
			{
				componentsInChildren2[i].DamageMultiplyer /= PerkManager.instance.eliteTowerDamageMultiplyer;
			}
		}
	}

	public void OnDuskEarly()
	{
	}

	public void OnDusk()
	{
	}

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDawn_BeforeSunrise()
	{
		GoOutOfEliteMode();
	}
}
