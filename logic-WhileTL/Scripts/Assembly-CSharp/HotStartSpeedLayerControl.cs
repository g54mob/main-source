public class HotStartSpeedLayerControl : SpeedLayerControl
{
	protected override void IncreaseSpeed()
	{
		if (base.Freezed)
		{
			Unfreeze();
		}
		else
		{
			base.Speed += base.Step;
		}
	}

	protected override void DecreaseSpeed()
	{
		if (base.Freezed)
		{
			Unfreeze();
		}
		else
		{
			base.Speed -= base.Step;
		}
	}
}
