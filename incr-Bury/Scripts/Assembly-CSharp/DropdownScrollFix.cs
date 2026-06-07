using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropdownScrollFix : MonoBehaviour
{
	public TMP_Dropdown dropdown;

	private ScrollRect scrollRect;

	private RectTransform content;

	private RectTransform viewport;

	[SerializeField]
	private float selectionPosOffset;

	private void Awake()
	{
		dropdown = GetComponent<TMP_Dropdown>();
	}

	private void Update()
	{
		if (!InputManager.Singleton || InputManager.Singleton.lastUsedControllerType != InputManager.ControllerType.controller)
		{
			return;
		}
		Transform transform = dropdown.transform.Find("Dropdown List");
		if ((bool)transform)
		{
			if (!scrollRect)
			{
				scrollRect = transform.GetComponentInChildren<ScrollRect>();
				content = scrollRect.content;
				viewport = scrollRect.viewport;
			}
			GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;
			if ((bool)currentSelectedGameObject && currentSelectedGameObject.transform.IsChildOf(content))
			{
				ScrollTo(currentSelectedGameObject.GetComponent<RectTransform>());
			}
		}
	}

	private void ScrollTo(RectTransform item)
	{
		Canvas.ForceUpdateCanvases();
		float height = content.rect.height;
		float height2 = viewport.rect.height;
		float verticalNormalizedPosition = Mathf.Clamp01(Mathf.Abs(item.anchoredPosition.y + selectionPosOffset) / (height - height2));
		scrollRect.verticalNormalizedPosition = verticalNormalizedPosition;
	}
}
