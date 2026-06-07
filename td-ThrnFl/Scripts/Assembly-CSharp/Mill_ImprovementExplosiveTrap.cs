using UnityEngine;

public class Mill_ImprovementExplosiveTrap : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	[SerializeField]
	private Weapon weaponLvl1;

	[SerializeField]
	private Weapon weaponLvl2;

	[SerializeField]
	private Weapon weaponLvl3;

	[SerializeField]
	private Hp hpOfBuilding;

	[SerializeField]
	private BuildSlot buildSlot;

	public Mesh lvl2Mesh;

	public Mesh lvl3Mesh;

	private void Start()
	{
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
	}

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDawn_BeforeSunrise()
	{
	}

	public void OnDusk()
	{
		SetCorrectWeapon();
	}

	private void OnEnable()
	{
		buildSlot.upgrades[1].upgradeBranches[0].replacementMesh = lvl2Mesh;
		buildSlot.upgrades[2].upgradeBranches[0].replacementMesh = lvl3Mesh;
		SetCorrectWeapon();
	}

	private void SetCorrectWeapon()
	{
		if (buildSlot.Level == 1)
		{
			hpOfBuilding.SpwanAttackOnDeath = weaponLvl1;
			{
				foreach (BuildSlot item in buildSlot.IsActivatorOf)
				{
					item.GetComponentInChildren<Hp>(includeInactive: true).SpwanAttackOnDeath = weaponLvl1;
				}
				return;
			}
		}
		if (buildSlot.Level == 2)
		{
			hpOfBuilding.SpwanAttackOnDeath = weaponLvl2;
			{
				foreach (BuildSlot item2 in buildSlot.IsActivatorOf)
				{
					item2.GetComponentInChildren<Hp>(includeInactive: true).SpwanAttackOnDeath = weaponLvl2;
				}
				return;
			}
		}
		if (buildSlot.Level != 3)
		{
			return;
		}
		hpOfBuilding.SpwanAttackOnDeath = weaponLvl3;
		foreach (BuildSlot item3 in buildSlot.IsActivatorOf)
		{
			item3.GetComponentInChildren<Hp>(includeInactive: true).SpwanAttackOnDeath = weaponLvl3;
		}
	}

	public void OnDuskEarly()
	{
	}
}
