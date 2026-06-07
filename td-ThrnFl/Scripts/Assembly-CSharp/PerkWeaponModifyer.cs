using UnityEngine;

public class PerkWeaponModifyer : MonoBehaviour
{
	public Equippable requiredPerk;

	public Weapon weaponToInsert;

	public AutoAttack autoAttack;

	private void Start()
	{
		if (PerkManager.IsEquipped(requiredPerk))
		{
			autoAttack.weapon = weaponToInsert;
		}
		Object.Destroy(this);
	}
}
