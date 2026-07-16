using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "NewTrain", menuName = "Trains/NewBaseTrain")]
public class NewTrainBase : ScriptableObject
{
	[SerializeField]
	public int WorldBeaten;

	private bool isApplied;

	[field: SerializeField]
	public string TrainName { get; private set; }

	[field: SerializeField]
	public LocalizedString NameTxt { get; private set; }

	[field: SerializeField]
	public LocalizedString TrainDescriptionTxt { get; private set; }

	[field: SerializeField]
	public Sprite Icon { get; private set; }

	[field: SerializeField]
	public LocalizedString PassiveNameTxt { get; private set; }

	[field: SerializeField]
	public LocalizedString PassiveDescriptionTxt { get; private set; }

	[field: SerializeField]
	public LocalizedString UnlockRequirementTxt { get; private set; }

	[field: SerializeField]
	public TrainType trainType { get; private set; }

	[field: SerializeField]
	public List<EnhancementModule> additionalStartingModules { get; private set; }

	[field: SerializeField]
	public List<EnhancementUpgrade> additionalStartingUpgrades { get; private set; }

	[field: SerializeField]
	public List<EnhancementUpgrade> additionalStartingRelics { get; private set; }

	[field: SerializeField]
	public List<StatsUpgrade> statUpgrades { get; private set; }

	[field: SerializeField]
	public Sprite locomotiveArt { get; private set; }

	[field: SerializeField]
	public Color trainColor { get; private set; }

	[field: SerializeField]
	public string animName { get; private set; }

	[field: SerializeField]
	public Sprite roofSprite { get; private set; }

	[field: SerializeField]
	public List<Sprite> wagonRoofSprite { get; private set; }

	[field: SerializeField]
	public List<string> wagonRoofAnimName { get; private set; }

	[field: SerializeField]
	public Sprite PlowArt { get; private set; }

	[field: SerializeField]
	public List<Sprite> HardenPlatingArt { get; private set; }

	public void ApplyNewTrain(bool ignoreEnhancements = false, bool forceApply = false)
	{
		if (!isApplied || forceApply)
		{
			isApplied = true;
			if (!ignoreEnhancements)
			{
				ApplyEnhancements();
			}
			ApplyPassive();
		}
	}

	public void RemoveTrain(bool isRemoveAll = false)
	{
		if (isApplied)
		{
			isApplied = false;
			RemoveEnhancements();
			RemovePassive(isRemoveAll);
		}
	}

	protected virtual void ApplyEnhancements()
	{
		foreach (EnhancementModule additionalStartingModule in additionalStartingModules)
		{
			UpgradeManager.Instance.AddModule(additionalStartingModule);
		}
		foreach (EnhancementUpgrade additionalStartingUpgrade in additionalStartingUpgrades)
		{
			UpgradeManager.Instance.AddUpgrade(additionalStartingUpgrade);
		}
		foreach (EnhancementUpgrade additionalStartingRelic in additionalStartingRelics)
		{
			UpgradeManager.Instance.AddRelic(additionalStartingRelic);
		}
	}

	protected virtual void RemoveEnhancements()
	{
		if (additionalStartingModules.Count > 0)
		{
			foreach (EnhancementModule additionalStartingModule in additionalStartingModules)
			{
				UpgradeManager.Instance.ReturnModuleToPool(additionalStartingModule);
			}
		}
		if (additionalStartingUpgrades.Count > 0)
		{
			foreach (EnhancementUpgrade additionalStartingUpgrade in additionalStartingUpgrades)
			{
				UpgradeManager.Instance.ReturnUpgradeToPool(additionalStartingUpgrade);
			}
		}
		if (additionalStartingRelics.Count <= 0)
		{
			return;
		}
		foreach (EnhancementUpgrade additionalStartingRelic in additionalStartingRelics)
		{
			UpgradeManager.Instance.ReturnRelicToPool(additionalStartingRelic);
		}
	}

	protected virtual void ApplyPassive()
	{
		if (trainType == TrainType.Regular)
		{
			Train.Instance.ResetTrainArt(this);
		}
		else
		{
			Train.Instance.SwapTrainArt(this);
		}
		foreach (Wagon wagon in Train.Instance.Wagons)
		{
			if (wagon.WagonType != WagonType.Main)
			{
				wagon.SetWagonArt(this);
			}
		}
		if (statUpgrades == null || statUpgrades.Count == 0)
		{
			return;
		}
		foreach (StatsUpgrade statUpgrade in statUpgrades)
		{
			ApplyStatUpgrade(statUpgrade);
		}
	}

	protected virtual void RemovePassive(bool isRemoveAll = false)
	{
		if (statUpgrades == null || statUpgrades.Count == 0)
		{
			return;
		}
		foreach (StatsUpgrade statUpgrade in statUpgrades)
		{
			RemoveStatUpgrade(statUpgrade);
		}
	}

	private void ApplyStatUpgrade(StatsUpgrade su)
	{
		su.StatsObjectToUpgrade.ApplyStatUpgrades(su.StatUpgrade);
	}

	private void RemoveStatUpgrade(StatsUpgrade su)
	{
		su.StatsObjectToUpgrade.RemoveStatUpgrades(su.StatUpgrade);
	}

	public virtual bool CheckUnlockRequirements()
	{
		return false;
	}

	public virtual void UnlockTrain()
	{
		if (Train.Instance.trains[this])
		{
			MenuManager.Instance.GetMenu(MenuType.GameOver).gameObject.GetComponent<PostcardMenu>().AddNewUnlock(Icon, "NEW TRAIN", TrainName, Rarity.Legendary);
		}
		Train.Instance.trains[this] = false;
	}
}
