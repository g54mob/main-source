using UnityEngine;

[CreateAssetMenu(fileName = "GE_addGemSlot_default", menuName = "Tower Factory/GameplayEffect/Gems/Add Gem Slot")]
public class GE_AddGemSlotData : GameplayEffectData
{
	[Header("Add gem slot")]
	[SerializeField]
	private int gemsAmount;

	public int GemsAmount => gemsAmount;

	public override GameplayEffect InstantiateEffect()
	{
		return new GE_AddGemSlot();
	}

	protected override bool ShowNameInInspector()
	{
		return false;
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
