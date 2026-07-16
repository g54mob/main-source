using UnityEngine;

[CreateAssetMenu(fileName = "CannonTrain", menuName = "Trains/NewCannonTrain")]
public class CannonTrain : NewTrainBase
{
	public GameObject twoSlotWagon;

	public GameObject fourSlotWagon;

	public EnhancementModule moduleCannon;

	public EnhancementModule moduleClaw;

	public StatsUpgrade cannonDamagePerHardLocation;

	private bool isHardLocation;

	protected override void ApplyPassive()
	{
		base.ApplyPassive();
		Wagon wagon = Train.Instance.Wagons[1];
		Train.Instance.Wagons.Remove(wagon);
		Object.Destroy(wagon.gameObject);
		Train.Instance.AddWagon(twoSlotWagon);
		UpgradeManager.Instance.AddModule(moduleCannon);
		UpgradeManager.Instance.AddModule(moduleClaw);
		foreach (Wagon wagon2 in Train.Instance.Wagons)
		{
			wagon2.SetHardening(isHardened: false);
		}
		LevelManager.Instance.NextLevelSelected += CheckLocation;
		LevelManager.Instance.DestinationReached += IncreaseCannonDamage;
		Train.Instance.HealthComponent.ChangeMaxHealthBy((0f - Train.Instance.healthIncreasePerModule) * 2f);
	}

	protected override void RemovePassive(bool isRemoveAll = false)
	{
		base.RemovePassive();
		Wagon wagon = Train.Instance.Wagons[1];
		Train.Instance.Wagons.Remove(wagon);
		Object.Destroy(wagon.gameObject);
		Train.Instance.AddWagon(fourSlotWagon);
		UpgradeManager.Instance.AddModule(moduleCannon);
		UpgradeManager.Instance.AddModule(moduleClaw, Train.Instance.Wagons[1].ModuleSlots[3]);
		LevelManager.Instance.NextLevelSelected -= CheckLocation;
		LevelManager.Instance.DestinationReached -= IncreaseCannonDamage;
		for (int i = 0; i < Train.Instance.cannonDamageIncreaseCounter; i++)
		{
			cannonDamagePerHardLocation.StatsObjectToUpgrade.RemoveStatUpgrades(cannonDamagePerHardLocation.StatUpgrade);
		}
		Train.Instance.HealthComponent.ChangeMaxHealthBy((0f - Train.Instance.healthIncreasePerModule) * 2f);
	}

	private void CheckLocation(Level level)
	{
		if (level.Difficulty.Name == "Hard")
		{
			isHardLocation = true;
		}
		else
		{
			isHardLocation = false;
		}
	}

	private void IncreaseCannonDamage()
	{
		if (isHardLocation)
		{
			cannonDamagePerHardLocation.StatsObjectToUpgrade.ApplyStatUpgrades(cannonDamagePerHardLocation.StatUpgrade);
			Train.Instance.cannonDamageIncreaseCounter++;
		}
		isHardLocation = false;
	}

	public void LoadCannonDamage(int modifier = 0)
	{
		Train.Instance.cannonDamageIncreaseCounter += modifier;
		for (int i = 0; i < Train.Instance.cannonDamageIncreaseCounter; i++)
		{
			cannonDamagePerHardLocation.StatsObjectToUpgrade.ApplyStatUpgrades(cannonDamagePerHardLocation.StatUpgrade);
		}
	}
}
