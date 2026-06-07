using UnityEngine;

public class EmpireUpgrade : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private int goldToDoublePower = 1000;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	private float towerDamageMultiplyer = 1f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	private float meleeDamageMultiplyer = 1f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	private float universalResistanceMultiplyer = 1f;

	private float currentlyAppliedMultiplyer = 1f;

	private int lastRememberedGoldBalance = -1;

	private void OnEnable()
	{
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		BlacksmithUpgrades.instance.meleeDamage *= meleeDamageMultiplyer;
		BlacksmithUpgrades.instance.rangedResistance *= universalResistanceMultiplyer;
		BlacksmithUpgrades.instance.meleeResistance *= universalResistanceMultiplyer;
		if (towerDamageMultiplyer != 1f)
		{
			AutoAttackTower[] componentsInChildren = CastleCenter.instance.transform.parent.parent.gameObject.GetComponentsInChildren<AutoAttackTower>(includeInactive: true);
			foreach (AutoAttackTower obj in componentsInChildren)
			{
				obj.DamageMultiplyer *= towerDamageMultiplyer;
				obj.transform.parent.GetComponentInChildren<HotOilTower>(includeInactive: true).DamageMultiplyer *= towerDamageMultiplyer;
			}
		}
	}

	public void OnDusk()
	{
		int balance = PlayerInteraction.instance.Balance;
		if (balance != lastRememberedGoldBalance)
		{
			float num = 1f + (float)balance / (float)goldToDoublePower;
			float num2 = num / currentlyAppliedMultiplyer;
			BlacksmithUpgrades.instance.meleeDamage *= num2;
			BlacksmithUpgrades.instance.rangedDamage *= num2;
			BlacksmithUpgrades.instance.rangedResistance *= num2;
			BlacksmithUpgrades.instance.meleeResistance *= num2;
			currentlyAppliedMultiplyer = num;
			lastRememberedGoldBalance = balance;
		}
	}

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDawn_BeforeSunrise()
	{
	}

	public void OnDuskEarly()
	{
	}
}
