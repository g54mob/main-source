namespace NSMedieval.State
{
	public interface ILightReceiver
	{
		float GetReceivingLightAmount();

		float GetSunlightLossMultiplier();
	}
}
