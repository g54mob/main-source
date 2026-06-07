using UnityEngine;

[CreateAssetMenu(fileName = "GE_healLightTower_default", menuName = "Tower Factory/GameplayEffect/Player/Heal Light Tower")]
public class GE_HealLightTowerData : GameplayEffectData
{
	[Header("Heal Light Tower")]
	[SerializeField]
	private int healedAmount;

	public int HealedAmount => healedAmount;

	public override GameplayEffect InstantiateEffect()
	{
		return new GE_HealLightTower();
	}

	protected override bool ShowDescriptionInInspector()
	{
		return false;
	}

	protected override bool ShowDurationInInspector()
	{
		return false;
	}

	protected override bool ShowMaxStacksInInspector()
	{
		return false;
	}

	protected override bool ShowTickInInspector()
	{
		return false;
	}
}
