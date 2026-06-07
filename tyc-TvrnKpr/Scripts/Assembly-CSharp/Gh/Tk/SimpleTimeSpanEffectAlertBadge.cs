namespace Gh.Tk
{
	public class SimpleTimeSpanEffectAlertBadge : TimeSpanEffectAlertBadge<TimeSpanEffect>
	{
		public SimpleTimeSpanEffectAlertBadge()
			: base((string)null, (string)null, (string)null)
		{
		}

		protected override string GetTooltipKey()
		{
			return null;
		}
	}
}
