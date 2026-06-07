using System;

namespace ModApi.Ui.Inspector
{
	[AttributeUsage(AttributeTargets.Field)]
	public class InspectorPropertyAttribute : Attribute
	{
		public bool AllowArrayAddRemove { get; set; } = true;

		public bool AllowArrayReorder { get; set; } = true;

		public bool ForceRefresh { get; set; }

		public string Label { get; set; }

		public int Order { get; set; }

		public bool ShowArrayGroup { get; set; } = true;

		public string Tooltip { get; set; }

		public InspectorPropertyAttribute(string tooltip = null, bool forceRefresh = false)
		{
			Tooltip = tooltip;
			ForceRefresh = forceRefresh;
			Order = -1;
		}
	}
}
