using UnityEngine;

public interface IPlaceable : IIconProvider, ITooltipProvider
{
	BuildableCategory Category { get; }

	string Name { get; }

	Sprite Icon { get; }

	bool ShowToggle { get; }

	bool IsToggleEnabled { get; }

	bool IsCategoryEnabled { get; }

	bool RequiresMooringPoint { get; }

	void ActivateCursor(CursorManager.CursorEvent deactivatedCallback);

	string GetDescription();

	bool ReturnCanBePlaced(Community community, bool checkResources = true);
}
