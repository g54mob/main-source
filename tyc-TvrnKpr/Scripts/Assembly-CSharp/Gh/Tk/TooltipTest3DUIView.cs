namespace Gh.Tk
{
	public class TooltipTest3DUIView : Button3DUIView, ITooltipDelayOverrider
	{
		public string tooltipDelayProfileKey;

		public float GetTooltipDelay()
		{
			return 0f;
		}

		public override TooltipData GetTooltipData()
		{
			return null;
		}
	}
}
