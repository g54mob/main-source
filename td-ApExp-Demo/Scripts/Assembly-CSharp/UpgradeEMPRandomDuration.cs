using UnityEngine;

[CreateAssetMenu(fileName = "EMPRandomDuration", menuName = "Upgrade/EMP/RandomDuration")]
public class UpgradeEMPRandomDuration : EnhancementUpgrade
{
	[SerializeField]
	private float percentChanceForGoodOutcome;

	[SerializeField]
	private float decreaseDurationPercent;

	[SerializeField]
	private float increaseDurationPercent;

	public override void ApplyUpgrade()
	{
		ModuleEMP moduleByType = Train.Instance.GetModuleByType<ModuleEMP>();
		moduleByType.randomDuration = true;
		moduleByType.percentChanceForGoodOutcome = percentChanceForGoodOutcome;
		moduleByType.decreaseDurationPercent = decreaseDurationPercent;
		moduleByType.increaseDurationPercent = increaseDurationPercent;
	}
}
