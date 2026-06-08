public class UITooltips : UITextLabel
{
	public static UITooltips CurrentTooltip;

	public static void MakeActive(UITooltips activeTooltips)
	{
		CurrentTooltip = activeTooltips;
	}
}
