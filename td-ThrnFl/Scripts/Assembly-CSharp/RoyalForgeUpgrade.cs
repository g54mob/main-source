using UnityEngine;

public class RoyalForgeUpgrade : MonoBehaviour, DayNightCycle.IDaytimeSensitive, ISaveLoad
{
	public enum ERoyalForgeUpgrades
	{
		AutoAttackSpeed = 0,
		AdditionalHealth = 1,
		CooldownReduction = 2,
		OverallDamage = 3
	}

	[SerializeField]
	private BuildingInteractor buildingInteractor;

	[SerializeField]
	private ProductionBar productionBar;

	[SerializeField]
	private ERoyalForgeUpgrades upgrade;

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
		case ERoyalForgeUpgrades.AutoAttackSpeed:
			AutoAttackMulti(multiplyer);
			break;
		case ERoyalForgeUpgrades.AdditionalHealth:
			PlayerHealthMulti(multiplyer);
			break;
		case ERoyalForgeUpgrades.CooldownReduction:
			ManualAttackMulti(multiplyer);
			break;
		case ERoyalForgeUpgrades.OverallDamage:
			PlayerUpgradeManager.instance.PlayerDamageMultiplyer *= multiplyer;
			break;
		}
	}

	public static void PlayerHealthMulti(float _multi)
	{
		PlayerMovement[] registeredPlayers = PlayerManager.Instance.RegisteredPlayers;
		for (int i = 0; i < registeredPlayers.Length; i++)
		{
			Hp component = registeredPlayers[i].GetComponent<Hp>();
			component.maxHp *= _multi;
			component.Heal(float.MaxValue);
		}
		PlayerUpgradeManager.instance.PlayerHealthRegenerationMultiplyer *= _multi;
	}

	public static void ManualAttackMulti(float _multi)
	{
		if ((bool)PlayerInteraction.instance.ManualAttack)
		{
			if (PlayerInteraction.instance.ManualAttack.GetType() == typeof(StabMA))
			{
				((StabMA)PlayerInteraction.instance.ManualAttack).maximumCooldownTime *= _multi;
			}
			else
			{
				PlayerInteraction.instance.ManualAttack.cooldownTime *= _multi;
			}
		}
	}

	public static void AutoAttackMulti(float _multi)
	{
		if ((bool)PlayerInteraction.instance.AutoAttack)
		{
			PlayerInteraction.instance.AutoAttack.cooldownTime *= _multi;
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
