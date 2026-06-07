using System;

namespace Gh.Tk
{
	public interface IAiComponentVisualInfo
	{
		bool ShouldUpdateTooltipPeriodically { get; }

		int DisplayOrder { get; }

		bool IsHidden { get; }

		event EventHandler<EventArgs<bool>> IsHiddenChanged;

		event EventHandler TooltipChanged;

		TooltipData GetTooltipData();

		string GetTraitBadgeIconPrefabName();
	}
}
