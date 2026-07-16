using UnityEngine;

[CreateAssetMenu(fileName = "WarpTrain", menuName = "Trains/NewWarpTrain")]
public class WarpTrain : NewTrainBase
{
	[field: SerializeField]
	public int WarpCounterBonus { get; private set; }

	[field: SerializeField]
	public float WrapDamageMultiplierIncrease { get; private set; }

	[field: SerializeField]
	public float ProjectileDamageMultiplier { get; private set; }

	protected override void ApplyPassive()
	{
		base.ApplyPassive();
		Train.Instance.projectileScreenWarpCounter += WarpCounterBonus;
		GlobalFields.Instance.WrapDamageMult += WrapDamageMultiplierIncrease;
		GlobalFields.Instance.WrapDamageMult /= ProjectileDamageMultiplier;
		GlobalFields.Instance.ProjectileDamageMult *= ProjectileDamageMultiplier;
	}

	protected override void RemovePassive(bool isRemoveAll = false)
	{
		base.RemovePassive();
		if (!isRemoveAll)
		{
			Train.Instance.projectileScreenWarpCounter -= WarpCounterBonus;
			GlobalFields.Instance.WrapDamageMult *= ProjectileDamageMultiplier;
			GlobalFields.Instance.WrapDamageMult -= WrapDamageMultiplierIncrease;
			GlobalFields.Instance.ProjectileDamageMult = 1f;
		}
	}
}
