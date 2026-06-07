namespace UIScripts.UIReferences.LineagePanel
{
	public class LineageSpeciesNodePoint : LineageElement
	{
		public TooltipTrigger tooltip;

		public void UpdateTooltip(string title, string tooltipText)
		{
			tooltip.UpdateText(title, tooltipText);
		}
	}
}
