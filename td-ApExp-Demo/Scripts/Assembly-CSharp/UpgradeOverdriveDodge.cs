using UnityEngine;

[CreateAssetMenu(fileName = "OverdriveDodge", menuName = "Upgrade/Overdrive/Dodge")]
public class UpgradeOverdriveDodge : EnhancementUpgrade
{
	[SerializeField]
	private float dodgeChance = 0.5f;

	public override void ApplyUpgrade()
	{
		ModuleOverdrive moduleByType = Train.Instance.GetModuleByType<ModuleOverdrive>();
		if ((object)moduleByType != null)
		{
			moduleByType.OnOverdriveStart += OnOverdriveStart;
			moduleByType.OnOverdriveEnd += OnOverdriveEnd;
		}
	}

	private void OnOverdriveStart()
	{
		foreach (Module module in Train.Instance.Modules)
		{
			if ((bool)module)
			{
				module.DodgeProb = dodgeChance;
			}
		}
	}

	private void OnOverdriveEnd()
	{
		foreach (Module module in Train.Instance.Modules)
		{
			if ((bool)module)
			{
				module.DodgeProb = 0f;
			}
		}
	}
}
