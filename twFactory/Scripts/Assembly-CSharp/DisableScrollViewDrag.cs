using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisableScrollViewDrag : ScrollRect
{
	[SerializeField]
	private float autoScrollExtraOffsetTop;

	[SerializeField]
	private float autoScrollExtraOffsetBot;

	[SerializeField]
	private float elementExtraOffsetTop;

	[SerializeField]
	private float elementExtraOffsetBot;

	private List<GameObject> selectableElements;

	private RectTransform viewportRectTransform;

	private RectTransform contentRectTransform;

	private RectTransform selectedRectTransform;

	protected override void Start()
	{
		base.Start();
		base.verticalScrollbar.value = 1f;
		selectableElements = new List<GameObject>();
		selectableElements.AddRange(base.content.GetComponentsInChildren<GameObject>());
		viewportRectTransform = base.viewport;
		contentRectTransform = base.content;
	}

	private void Update()
	{
		if (!EventSystem.current || GameManager.instance.PlayerController.GetCurrentInputControlScheme() == PlayerController.EInputControlScheme.KeyboardMouse)
		{
			return;
		}
		GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;
		if (!(currentSelectedGameObject == null) && selectableElements.Contains(currentSelectedGameObject))
		{
			selectedRectTransform = currentSelectedGameObject.GetComponent<RectTransform>();
			Rect rect = viewportRectTransform.rect;
			Rect rect2 = selectedRectTransform.rect.Transform(selectedRectTransform).InverseTransform(viewportRectTransform);
			float num = rect2.yMax + elementExtraOffsetTop - rect.yMax;
			float num2 = rect.yMin - rect2.yMin - elementExtraOffsetBot;
			if (num < 0f)
			{
				num = 0f;
			}
			if (num2 < 0f)
			{
				num2 = 0f;
			}
			float num3 = ((num > 0f) ? num : (0f - num2));
			if (num3 != 0f)
			{
				float num4 = contentRectTransform.rect.Transform(contentRectTransform).InverseTransform(viewportRectTransform).height - rect.height;
				float num5 = 1f / num4;
				float num6 = ((Mathf.Sign(num3) == 1f) ? autoScrollExtraOffsetTop : (0f - autoScrollExtraOffsetBot));
				base.verticalNormalizedPosition += (num3 + num6) * num5;
			}
		}
	}

	public override void OnBeginDrag(PointerEventData eventData)
	{
	}

	public override void OnDrag(PointerEventData eventData)
	{
	}

	public override void OnEndDrag(PointerEventData eventData)
	{
	}
}
