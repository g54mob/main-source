using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.UI
{
	public interface IArcanaDisplayContainer
	{
		void ToggleArcanaInfoPanel(SelectableUI arcanaCardUI, ArcanaData arcanaData, ArcanaType arcanaType, Transform cardTransform, bool toggleFromClick, bool toggleFromSelectionChange);
	}
}
