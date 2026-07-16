using UnityEngine;

[CreateAssetMenu(fileName = "MissileNeedlerCombo", menuName = "Upgrade/Missile/NeedlerCombo")]
public class UpgradeMissileNeedlerCombo : EnhancementUpgrade
{
	[SerializeField]
	private int needlerHitsNeeded;

	[SerializeField]
	private int rocketsRefunded;

	private ModuleMissile missile;

	private ModuleNeedler needler;

	private int counter;

	public override void ApplyUpgrade()
	{
		missile = Train.Instance.GetModuleByType<ModuleMissile>();
		needler = Train.Instance.GetModuleByType<ModuleNeedler>();
		needler.OnHit += HitCount;
	}

	public void HitCount(HealthChangeInfo info)
	{
		counter++;
		if (counter >= needlerHitsNeeded)
		{
			for (int i = 0; i < rocketsRefunded; i++)
			{
				missile.ForceReload();
			}
			counter = 0;
		}
	}
}
