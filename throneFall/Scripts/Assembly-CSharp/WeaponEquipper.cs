using UnityEngine;

public class WeaponEquipper : MonoBehaviour
{
	public Equippable requiredWeapon;

	public ManualAttack activeWeapon;

	public ManualAttack passiveWeapon;

	public GameObject visuals;

	public PlayerAttackTargetFacer facer;

	private void Start()
	{
		if (!PerkManager.IsEquipped(requiredWeapon))
		{
			Object.Destroy(base.gameObject);
			return;
		}
		GetComponentInParent<PlayerInteraction>().EquipWeapon(activeWeapon, passiveWeapon);
		GetComponentInParent<PlayerUpgradeManager>();
		GetComponentInParent<PlayerAttack>().AssignManualAttack(activeWeapon);
		base.gameObject.AddComponent<PlayerWeaponVisuals>().Init(visuals, passiveWeapon);
		facer.AssignAttack(passiveWeapon);
		Object.Destroy(this);
		if (PerkManager.instance.LightMaterialsEquipped)
		{
			RoyalForgeUpgrade.AutoAttackMulti(PerkManager.instance.lightMaterialsCooldownMulti);
		}
		if (PerkManager.instance.SpellScrollActive)
		{
			RoyalForgeUpgrade.ManualAttackMulti(PerkManager.instance.spellScrollActiveCooldownMulti);
		}
	}
}
