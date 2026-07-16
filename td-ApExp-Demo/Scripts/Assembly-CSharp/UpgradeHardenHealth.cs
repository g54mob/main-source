using UnityEngine;

[CreateAssetMenu(fileName = "HardenHealth", menuName = "Upgrade/Harden/Health")]
public class UpgradeHardenHealth : EnhancementUpgrade
{
	[SerializeField]
	private float healthIncrease = 10f;

	public override void ApplyUpgrade()
	{
		ModuleHarden moduleByType = Train.Instance.GetModuleByType<ModuleHarden>();
		if ((object)moduleByType != null)
		{
			moduleByType.HealthIncrease += healthIncrease;
		}
	}

	public override void OnRemove()
	{
		base.OnRemove();
		ModuleHarden moduleByType = Train.Instance.GetModuleByType<ModuleHarden>();
		if ((object)moduleByType != null)
		{
			moduleByType.HealthIncrease -= healthIncrease;
		}
	}
}
