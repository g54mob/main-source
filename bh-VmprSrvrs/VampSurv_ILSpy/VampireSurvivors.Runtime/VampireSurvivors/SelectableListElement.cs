using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VampireSurvivors;

public class SelectableListElement : Selectable
{
	private Selectable _RedirectSelectionTo;

	public override void OnSelect(BaseEventData eventData)
	{
		base._003ChasSelection_003Ek__BackingField = true;
		EvaluateAndTransitionToSelectionState();
		_RedirectSelectionTo.Select();
	}
}
