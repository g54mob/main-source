using UnityEngine;

public class ListIcon : UIComponentMonoBehaviour, ISelectionListenerCallback
{
	public GameObject selectedGameObject;

	public GameObject unselectedGameObject;

	public override PivotPosition GetUIComponentPivotPosition()
	{
		return PivotPosition.MiddleLeft;
	}

	public override float GetUIComponentRenderWidth()
	{
		return 0.25f;
	}

	public override float GetUIComponentRenderHeight()
	{
		return 0.25f;
	}

	public void OnSelected(string sourceTag = null)
	{
		selectedGameObject.SetActive(value: true);
		unselectedGameObject.SetActive(value: false);
	}

	public void OnDeselected(string sourceTag = null)
	{
		selectedGameObject.SetActive(value: false);
		unselectedGameObject.SetActive(value: true);
	}
}
