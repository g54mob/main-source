using UnityEngine;

[CreateAssetMenu(fileName = "MissileFireOnBreak", menuName = "Upgrade/Missile/FireOnBreak")]
public class UpgradeMissileFireOnBreak : EnhancementUpgrade
{
	[SerializeField]
	private int amountOfRocketsFired;

	private ModuleMissile missile;

	public override void ApplyUpgrade()
	{
		missile = Train.Instance.GetModuleByType<ModuleMissile>();
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
		for (int i = 0; i < amountOfRocketsFired; i++)
		{
			missile.SpawnMissile();
		}
	}
}
