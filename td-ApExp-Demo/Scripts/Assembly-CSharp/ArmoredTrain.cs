using UnityEngine;

[CreateAssetMenu(fileName = "ArmoredTrain", menuName = "Trains/NewArmoredTrain")]
public class ArmoredTrain : NewTrainBase
{
	private bool playerDamageMultAdded;

	private bool modulesSurvived;

	[field: SerializeField]
	public float PassiveDamageDealtReductionPercent { get; private set; }

	[field: SerializeField]
	public float RepairSpeedPerStack { get; private set; }

	[field: SerializeField]
	public float ObstacleAoeDamageModifier { get; private set; }

	protected override void ApplyPassive()
	{
		base.ApplyPassive();
		playerDamageMultAdded = true;
		GlobalFields.Instance.ModifyPlayerDamageMultiplier(PassiveDamageDealtReductionPercent);
		LevelManager.Instance.LevelStarted += ResetModuleChecks;
		LevelManager.Instance.LevelCompleted += CheckForBuff;
		GlobalFields.Instance.ObstacleAoeDamageModifier *= ObstacleAoeDamageModifier;
	}

	protected override void RemovePassive(bool isRemoveAll = false)
	{
		base.RemovePassive();
		if (!isRemoveAll)
		{
			LevelManager.Instance.LevelStarted -= ResetModuleChecks;
			LevelManager.Instance.LevelCompleted -= CheckForBuff;
			GlobalFields.Instance.ModifyPlayerDamageMultiplier(0f - PassiveDamageDealtReductionPercent);
			GlobalFields.Instance.ObstacleAoeDamageModifier = 1f;
		}
	}

	private void ResetModuleChecks()
	{
		modulesSurvived = true;
		foreach (Module module in Train.Instance.Modules)
		{
			module.FullyBroken += TrackModuleBreaks;
		}
	}

	private void CheckForBuff()
	{
		if (modulesSurvived)
		{
			foreach (PlayerController player in PlayerManager.Instance.Players)
			{
				player.UpgradeRepairSpeed(RepairSpeedPerStack);
				Train.Instance.playerRepairSpeedIncreaseCounter++;
			}
		}
		foreach (Module module in Train.Instance.Modules)
		{
			module.FullyBroken -= TrackModuleBreaks;
		}
	}

	private void TrackModuleBreaks()
	{
		modulesSurvived = false;
	}

	public void LoadStacks(int modifier = 0)
	{
		Train.Instance.playerRepairSpeedIncreaseCounter += modifier;
		for (int i = 0; i < Train.Instance.playerRepairSpeedIncreaseCounter; i++)
		{
			foreach (PlayerController player in PlayerManager.Instance.Players)
			{
				player.UpgradeRepairSpeed(RepairSpeedPerStack);
			}
		}
	}
}
