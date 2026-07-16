using UnityEngine;

[CreateAssetMenu(fileName = "NeedlerFireOnDestroy", menuName = "Upgrade/Needler/FireOnDestroy")]
public class UpgradeNeedlerFireOnDestroy : EnhancementUpgrade
{
	[SerializeField]
	private int amountOfWavesFired;

	private ModuleNeedler needler;

	public override void ApplyUpgrade()
	{
		needler = Train.Instance.GetModuleByType<ModuleNeedler>();
		Module[] modulesByType = Train.Instance.GetModulesByType<Module>();
		if (modulesByType != null)
		{
			for (int i = 0; i < modulesByType.Length; i++)
			{
				modulesByType[i].FullyBroken += OnModuleFullyBroken;
			}
		}
	}

	private void OnModuleFullyBroken()
	{
		needler.StartCoroutine(needler.EmergencyFire(amountOfWavesFired));
	}
}
