public class ValueTooltippedSlider : TooltippedSlider
{
	public override string ReturnParsedTooltip(string tooltip)
	{
		return $"{value:0%}";
	}
}
