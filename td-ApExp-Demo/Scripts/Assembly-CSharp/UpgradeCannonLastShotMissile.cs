using UnityEngine;

[CreateAssetMenu(fileName = "CannonLastShotMissile", menuName = "Upgrade/Mixed/CannonLastShotMissile")]
public class UpgradeCannonLastShotMissile : EnhancementUpgrade
{
	private ModuleMissile missile;

	private ModuleCannon cannon;

	public override void ApplyUpgrade()
	{
		ModuleMissile moduleByType = Train.Instance.GetModuleByType<ModuleMissile>();
		if ((object)moduleByType != null)
		{
			missile = moduleByType;
		}
		ModuleCannon moduleByType2 = Train.Instance.GetModuleByType<ModuleCannon>();
		if ((object)moduleByType2 != null)
		{
			cannon = moduleByType2;
			moduleByType2.cannon.OnFire += OnCannonFire;
		}
	}

	private void OnCannonFire()
	{
		if (!(cannon.cannon.AmmoCount > 0f))
		{
			missile.SpawnMissile();
		}
	}
}
