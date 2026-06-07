using UnityEngine;

public interface IIconProvider : ITooltipProvider
{
	Sprite GetIcon();

	void ShowTooltip(GameObject trigger = null, bool delayed = true);

	void ShowTooltip(Vector3 position, bool delayed = true);

	void HideTooltip();
}
