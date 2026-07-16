using UnityEngine;

[CreateAssetMenu(fileName = "MissileFreeRocket", menuName = "Upgrade/Missile/FreeRocket")]
public class UpgradeMissileFreeRocket : EnhancementUpgrade
{
	[SerializeField]
	private float chanceToFire;

	private ModuleMissile missile;

	public override void ApplyUpgrade()
	{
		missile = Train.Instance.GetModuleByType<ModuleMissile>();
		missile.ExplosionKill += FreeFire;
	}

	public void FreeFire(HealthChangeInfo info)
	{
		if (ProbUtils.CheckWithLuck(chanceToFire))
		{
			missile.SpawnMissile();
		}
	}
}
