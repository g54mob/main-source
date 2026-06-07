using System.Collections;
using UnityEngine;

public class TemplePrayers : TempleUpgrade
{
	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	private float rangeMulti = 1.5f;

	private Shrine[] shrines;

	public override void EnableEffectAtPurchase()
	{
		shrines = Object.FindObjectsOfType<Shrine>(includeInactive: true);
		Shrine[] array = shrines;
		foreach (Shrine obj in array)
		{
			obj.CollectionRange *= rangeMulti;
			obj.GetComponentInChildren<AutoAttack>(includeInactive: true).targetPriorities[0].range *= rangeMulti;
			obj.ParentBuildSlot.GoldIncome = 0;
		}
	}

	public override void EnableEffectAtDusk()
	{
		StartCoroutine(MarkShrineAsKnockedOut());
		Shrine[] array = shrines;
		foreach (Shrine shrine in array)
		{
			shrine.ParentBuildSlot.GoldIncome = (shrine.ShrineHasBeenActivated ? shrine.IncomeOnceUnlocked : 0);
		}
	}

	private IEnumerator MarkShrineAsKnockedOut()
	{
		yield return null;
		yield return null;
		Shrine[] array = shrines;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].ParentBuildSlot.Interactor.OnKnockOut();
		}
	}

	public override void DisableEffectAtDawn()
	{
		Shrine[] array = shrines;
		foreach (Shrine obj in array)
		{
			obj.CollectionRange /= rangeMulti;
			obj.GetComponentInChildren<AutoAttack>(includeInactive: true).targetPriorities[0].range /= rangeMulti;
		}
	}
}
