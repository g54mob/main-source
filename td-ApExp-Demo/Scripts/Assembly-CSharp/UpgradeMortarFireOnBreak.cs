using UnityEngine;

[CreateAssetMenu(fileName = "MortarFireOnBreak", menuName = "Upgrade/Mortar/FireOnBreak")]
public class UpgradeMortarFireOnBreak : EnhancementUpgrade
{
	private ModuleMortar mortar;

	private float lastFireTime;

	public float cooldown = 1f;

	public override void ApplyUpgrade()
	{
		mortar = Train.Instance.GetModuleByType<ModuleMortar>();
		Module[] modulesByType = Train.Instance.GetModulesByType<Module>();
		if (modulesByType != null)
		{
			for (int i = 0; i < modulesByType.Length; i++)
			{
				modulesByType[i].ModuleBreak += OnModuleFullyBroken;
			}
		}
	}

	private void OnModuleFullyBroken(HealthChangeInfo info)
	{
		if (info != null && info.source != null && !(Time.time - lastFireTime < cooldown))
		{
			lastFireTime = Time.time;
			object obj = ((!(info.source is APCMissile aPCMissile)) ? info.source : aPCMissile.parentEnemy);
			if (obj is EnemyBase enemyBase)
			{
				mortar.SpawnProjectile(enemyBase.transform.position);
			}
		}
	}
}
