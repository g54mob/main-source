using UnityEngine.UI;

namespace VampireSurvivors.UI;

public interface ISelectableUI : IUIObject
{
	Selectable GetSelectable();

	void UpdateNavigation(Selectable above, Selectable below, Selectable left, Selectable right);
}
