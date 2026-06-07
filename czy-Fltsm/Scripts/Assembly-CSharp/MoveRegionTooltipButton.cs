using System.Text.RegularExpressions;

public class MoveRegionTooltipButton : TooltipButton
{
	public override string ReturnTooltip()
	{
		return Regex.Replace(_tooltipMessage, "%BIOME_COST%", string.Format("<b>{0}</b>", GameplaySettings.ReturnNextBiomeEnergyCost().ToString("F0")), RegexOptions.IgnoreCase);
	}
}
