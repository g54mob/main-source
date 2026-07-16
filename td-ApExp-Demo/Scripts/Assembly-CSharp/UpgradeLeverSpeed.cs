using UnityEngine;

[CreateAssetMenu(fileName = "LeverSpeed", menuName = "Upgrade/Lever/Speed")]
public class UpgradeLeverSpeed : EnhancementUpgrade
{
	private ModuleDirectionLever lever;

	[SerializeField]
	private float duration;

	[SerializeField]
	private float speedAmount;

	public override void ApplyUpgrade()
	{
		lever = Train.Instance.GetModuleByType<ModuleDirectionLever>();
		lever.speedAmount = speedAmount;
		lever.duration = duration;
	}
}
