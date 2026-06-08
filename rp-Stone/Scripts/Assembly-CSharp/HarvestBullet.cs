using UnityEngine;

[RequireComponent(typeof(Bullet))]
public class HarvestBullet : MonoBehaviour
{
	public Data.Resource resourceType;

	public int resourcesPerAttack = 1;

	private Bullet myBullet;

	private void Awake()
	{
		myBullet = GetComponent<Bullet>();
		myBullet.OnUpdateTic += UpdateTic;
	}

	private void OnDestroy()
	{
		myBullet.OnUpdateTic -= UpdateTic;
	}

	private void UpdateTic(Character character)
	{
		if (!myBullet.Alive)
		{
			return;
		}
		Weapon weapon = myBullet.weapon;
		if (weapon == null)
		{
			Utils.LogError("Bullet " + myBullet?.ToString() + " does not have a weapon.");
			return;
		}
		if (weapon.Owner == null)
		{
			Utils.LogError("Harvest bullet must have an owner.");
			return;
		}
		HarvestableResource harvestableResource = null;
		int num = int.MaxValue;
		for (int i = 0; i < GameStates.Singleton.level.HarvestableResources.Count; i++)
		{
			HarvestableResource harvestableResource2 = GameStates.Singleton.level.HarvestableResources[i];
			if (harvestableResource2.character.Alive)
			{
				int num2 = harvestableResource2.character.PositionX - weapon.Owner.PositionX;
				int value = harvestableResource2.character.PositionZ - weapon.Owner.PositionZ;
				int num3 = Mathf.Abs(num2) + Mathf.Abs(value);
				if (num > num3 && num2 <= weapon.baseRange && num2 >= 0)
				{
					num = num3;
					harvestableResource = harvestableResource2;
				}
			}
		}
		if (harvestableResource != null)
		{
			string resourceCostFormatted = MoneyUI.GetResourceCostFormatted(resourceType, resourcesPerAttack);
			weapon.Owner.ShowFloatingText(resourceCostFormatted);
			InventoryResources.singleton.AddResourceOfType(resourceType, resourcesPerAttack);
			Damage damage = new Damage();
			damage.amount = 1;
			damage.Owner = weapon.Owner;
			harvestableResource.character.InflictDamage(damage);
			SfxController.singleton.Play(myBullet.impactSfx);
			myBullet.Die(Character.DeathReason.ProjectileImpacted);
		}
	}
}
