using UnityEngine;
using UnityEngine.UI;

public interface IFocusTarget
{
	int Priority { get; }

	GameObject SelectedGameObject { get; }

	bool SelectedGameObjectIsActiveAndEnabled { get; }

	void OnFocusGained();

	void OnFocusLost();

	void OnCurrentSelectedSelectableChanged(Selectable selectable);
}
