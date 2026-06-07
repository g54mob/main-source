using UnityEngine;

public interface ITooltipProvider
{
	string GetTooltip(TooltipBuilder tooltipBuilder);

	Color GetColor(TooltipBuilder tooltipBuilder)
	{
		return Color.black;
	}

	Vector2 GetPosition()
	{
		return FlotsamInputManager.MousePosition;
	}
}
