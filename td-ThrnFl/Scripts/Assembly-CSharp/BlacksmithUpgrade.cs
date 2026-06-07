using UnityEngine;

public class BlacksmithUpgrade : MonoBehaviour, DayNightCycle.IDaytimeSensitive, ISaveLoad
{
	[SerializeField]
	private BuildingInteractor buildingInteractor;

	[SerializeField]
	private ProductionBar productionBar;

	[SerializeField]
	private Weapon.EDamageAffectedByBlacksmithUpgrade upgrade;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	[SerializeField]
	private float multiplyer = 1.2f;

	[BalancingParameter(BalancingParameter.EType.Default)]
	[SerializeField]
	private int researchTime = 2;

	[SerializeField]
	private Equippable researchSpeedPerk;

	private int researchTimeLeft;

	private bool isInitializedForSaving;

	private bool hasLoadedDataFromSave;

	private bool bumpedResearchThisDawn;

	private void Start()
	{
		if (!hasLoadedDataFromSave || researchTimeLeft > 0)
		{
			DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		}
	}

	public void OnDawn_AfterSunrise()
	{
		if (!base.gameObject.activeInHierarchy || bumpedResearchThisDawn)
		{
			return;
		}
		bumpedResearchThisDawn = true;
		isInitializedForSaving = true;
		if (!buildingInteractor.KnockedOutTonight)
		{
			researchTimeLeft--;
			UpdateProgressBar();
			if (researchTimeLeft <= 0)
			{
				productionBar.gameObject.SetActive(value: false);
				buildingInteractor.showsHarvestDeniedCueEvenWithNoIncome = false;
				ApplyUpgrade();
				buildingInteractor.buildingIsCurrentlyBusyAndCantBeUpgraded = false;
				buildingInteractor.UpdateInteractionState();
				DayNightCycle.Instance.UnregisterDaytimeSensitiveObject(this);
			}
		}
	}

	public void OnDawn_BeforeSunrise()
	{
	}

	private void ApplyUpgrade()
	{
		switch (upgrade)
		{
		case Weapon.EDamageAffectedByBlacksmithUpgrade.MultiplyBy_MeleeDamage:
			BlacksmithUpgrades.instance.meleeDamage *= multiplyer;
			break;
		case Weapon.EDamageAffectedByBlacksmithUpgrade.MultiplyBy_RangedDamage:
			BlacksmithUpgrades.instance.rangedDamage *= multiplyer;
			break;
		case Weapon.EDamageAffectedByBlacksmithUpgrade.DivideBy_MeleeResistance:
			BlacksmithUpgrades.instance.meleeResistance *= multiplyer;
			break;
		case Weapon.EDamageAffectedByBlacksmithUpgrade.DivideBy_RangedResistance:
			BlacksmithUpgrades.instance.rangedResistance *= multiplyer;
			break;
		}
	}

	public void OnDusk()
	{
		bumpedResearchThisDawn = false;
	}

	private void OnEnable()
	{
		ManualLoad(GetComponentInParent<SaveLoadEntity>().GUID);
		if (!hasLoadedDataFromSave)
		{
			researchTimeLeft = researchTime;
			if (PerkManager.IsEquipped(researchSpeedPerk))
			{
				researchTimeLeft--;
			}
			UpdateProgressBar();
			buildingInteractor.buildingIsCurrentlyBusyAndCantBeUpgraded = true;
			buildingInteractor.UpdateInteractionState();
		}
	}

	private void UpdateProgressBar()
	{
		productionBar.gameObject.SetActive(value: true);
		productionBar.UpdateVisual(1f - (float)researchTimeLeft / (float)researchTime + 0.075f);
		buildingInteractor.showsHarvestDeniedCueEvenWithNoIncome = true;
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
	}

	public void OnSave(string guid)
	{
		if (isInitializedForSaving)
		{
			MatchSaveLoadHandler.SaveValue(guid, base.transform.parent.gameObject.name + "_" + base.gameObject.name + "_researchTimeLeft", researchTimeLeft);
		}
	}

	private void ManualLoad(string guid)
	{
		if (!MatchSaveLoadHandler.IsLoadingPermitted)
		{
			return;
		}
		hasLoadedDataFromSave = MatchSaveLoadHandler.TryLoadValue(guid, base.transform.parent.gameObject.name + "_" + base.gameObject.name + "_researchTimeLeft", ref researchTimeLeft);
		if (hasLoadedDataFromSave)
		{
			if (researchTimeLeft > 0)
			{
				UpdateProgressBar();
				buildingInteractor.buildingIsCurrentlyBusyAndCantBeUpgraded = true;
				buildingInteractor.UpdateInteractionState();
			}
			else
			{
				ApplyUpgrade();
				buildingInteractor.UpdateInteractionState();
				researchTimeLeft = -10;
			}
		}
	}
}
