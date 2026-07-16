using UnityEngine;

[CreateAssetMenu(fileName = "DamageControlMortarCombo", menuName = "Upgrade/DamageControl/MortarCombo")]
public class UpgradeDamageControlMortarCombo : EnhancementUpgradeStats
{
	[SerializeField]
	private float shotDamagePercent;

	[SerializeField]
	private bool resetsMortarCooldown;

	private ModuleDamageControl dc;

	private ModuleMortar mortar;

	private float shotDamage;

	public override void ApplyUpgrade()
	{
		dc = Train.Instance.GetModuleByType<ModuleDamageControl>();
		mortar = Train.Instance.GetModuleByType<ModuleMortar>();
		dc.OnFinishedHealing += Shoot;
	}

	public void Shoot(float totalHeal)
	{
		shotDamage = totalHeal * shotDamagePercent / 100f;
		ModuleMortar moduleMortar = mortar;
		float damage = shotDamage;
		moduleMortar.SpawnProjectile(null, damage);
		if (resetsMortarCooldown)
		{
			mortar.shotTimer = 0f;
		}
	}
}
