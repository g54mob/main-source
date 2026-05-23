using UnityEngine;

public class PerkSpawnOnDestroy : MonoBehaviour
{
	[SerializeField]
	private Equippable requiredEquippable;

	[SerializeField]
	private Hp hp;

	[SerializeField]
	private Weapon weaponToSpawn;

	private void Update()
	{
		if (PerkManager.IsEquipped(requiredEquippable))
		{
			hp.SpwanAttackOnDeath = weaponToSpawn;
		}
		Object.Destroy(this);
	}
}
