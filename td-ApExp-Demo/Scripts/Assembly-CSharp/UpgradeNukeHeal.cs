using UnityEngine;

[CreateAssetMenu(fileName = "MortarNukeHeal", menuName = "Upgrade/Nuke/Heal")]
public class UpgradeNukeHeal : EnhancementUpgrade
{
	[SerializeField]
	private float healAmount = 100f;

	public override void ApplyUpgrade()
	{
		ModuleNuke moduleByType = Train.Instance.GetModuleByType<ModuleNuke>();
		if ((object)moduleByType != null)
		{
			moduleByType.Heal = healAmount;
		}
	}
}
