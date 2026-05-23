using UnityEngine;

public class TempleSacrifice : TempleUpgrade
{
	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	private float unitRespawnSpeedMulti = 3f;

	public override void EnableEffectAtDusk()
	{
		foreach (TaggedObject playerUnit in TagManager.instance.PlayerUnits)
		{
			playerUnit.Hp.TakeDamage(1E+09f);
		}
		BlacksmithUpgrades.instance.unitRespawnSpeedMulti *= unitRespawnSpeedMulti;
	}

	public override void DisableEffectAtDawn()
	{
		BlacksmithUpgrades.instance.unitRespawnSpeedMulti /= unitRespawnSpeedMulti;
	}
}
