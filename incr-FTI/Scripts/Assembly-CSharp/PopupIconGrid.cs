using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PopupIconGrid : MenuPanel
{
	public GameObject iconPrefab;

	public GameObject textButtonPrefab;

	public GridLayoutGroup layoutGroup;

	public RectTransform viewTransform;

	public int childCount;

	private Vector3[] worldCorners = new Vector3[4];

	public override void Show()
	{
		base.Show();
		base.transform.SetAsLastSibling();
	}

	public MenuButton AddTextButton(string text, object loadedObject, UnityAction<NavigationIcon> del)
	{
		NavigationIcon component = MenuManager.GetMenuObject(textButtonPrefab, layoutGroup.transform).GetComponent<NavigationIcon>();
		component.highlightMargin = 1f;
		component.loadedObject = loadedObject;
		component.onClickedDelegate = del;
		component.buttonState = CustomButtonState.Background;
		component.label.text = text;
		component.AnimateInstant();
		childCount++;
		return component;
	}

	public NavigationIcon AddIcon(Sprite sprite, object loadedObject, UnityAction<NavigationIcon> del)
	{
		NavigationIcon component = MenuManager.GetMenuObject(iconPrefab, layoutGroup.transform).GetComponent<NavigationIcon>();
		component.highlightMargin = 1f;
		component.loadedObject = loadedObject;
		component.onClickedDelegate = del;
		component.buttonState = CustomButtonState.Background;
		component.iconImage.sprite = sprite;
		component.AnimateInstant();
		childCount++;
		return component;
	}

	public void ClearPopup()
	{
		childCount = 0;
		foreach (Transform item in layoutGroup.transform)
		{
			Object.Destroy(item.gameObject);
		}
	}
}
