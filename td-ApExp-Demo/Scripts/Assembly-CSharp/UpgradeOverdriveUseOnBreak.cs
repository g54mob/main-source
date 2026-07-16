using UnityEngine;

[CreateAssetMenu(fileName = "OverdriveUseOnBreak", menuName = "Upgrade/Overdrive/UseOnBreak")]
public class UpgradeOverdriveUseOnBreak : EnhancementUpgrade
{
	private ModuleOverdrive overdrive;

	public override void ApplyUpgrade()
	{
		overdrive = Train.Instance.GetModuleByType<ModuleOverdrive>();
		Module[] modulesByType = Train.Instance.GetModulesByType<Module>();
		if (modulesByType != null)
		{
			for (int i = 0; i < modulesByType.Length; i++)
			{
				modulesByType[i].FullyBroken += OnModuleFullyBroken;
			}
		}
	}

	public void OnModuleFullyBroken()
	{
		if (!overdrive.IsFiring)
		{
			overdrive.freeUse = true;
			overdrive.Interactable.InteractStart(new Interactor());
			overdrive.freeUse = false;
		}
		else
		{
			overdrive.firingTimeElapsed = 0f;
		}
	}
}
