public class GE_AddGemSlot : GameplayEffect
{
	protected override void OnInitEffect()
	{
		GE_AddGemSlotData gE_AddGemSlotData = base.EffectData as GE_AddGemSlotData;
		base.Owner.GetComponent<GemsComponent>().MaxGems += gE_AddGemSlotData.GemsAmount;
	}

	protected override void OnEndEffect()
	{
		GE_AddGemSlotData gE_AddGemSlotData = base.EffectData as GE_AddGemSlotData;
		base.Owner.GetComponent<GemsComponent>().MaxGems -= gE_AddGemSlotData.GemsAmount;
	}
}
