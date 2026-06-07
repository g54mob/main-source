using UnityEngine;

namespace DV.UIFramework
{
	public interface ITooltip
	{
		ITooltipIcons TooltipIcons { get; }

		string GetText();

		GameObject GetGameObject();
	}
}
