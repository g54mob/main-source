using System;
using TMPro;
using UnityEngine;

public class SimpleTooltip : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI headerField;

	[SerializeField]
	private TextMeshProUGUI contentField;

	private RectTransform rt;

	[NonSerialized]
	public GameObject currentTarget;

	public void SetText(string content, string header = "", GameObject target = null)
	{
		currentTarget = target;
		if (string.IsNullOrEmpty(header))
		{
			headerField.gameObject.SetActive(value: false);
		}
		else
		{
			headerField.gameObject.SetActive(value: true);
			headerField.text = header;
		}
		contentField.text = content;
		SetPosition();
	}

	private void Update()
	{
		SetPosition();
	}

	private void SetPosition()
	{
		if (currentTarget == null)
		{
			return;
		}
		if (rt == null)
		{
			rt = GetComponent<RectTransform>();
		}
		RectTransform component = currentTarget.GetComponent<RectTransform>();
		if (!(component == null))
		{
			rt.position = component.position;
			Canvas componentInParent = GetComponentInParent<Canvas>();
			if (!(componentInParent == null))
			{
				Vector2 size = componentInParent.GetComponent<RectTransform>().rect.size;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(componentInParent.transform as RectTransform, component.position, (componentInParent.renderMode == RenderMode.ScreenSpaceOverlay) ? null : componentInParent.worldCamera, out var localPoint);
				Vector2 pivot = new Vector2((localPoint.x > 0f) ? 1f : 0f, (localPoint.y > 0f) ? 1f : 0f);
				rt.pivot = pivot;
				Vector2 anchoredPosition = localPoint;
				Vector2 vector = rt.rect.size * 0.5f;
				anchoredPosition.x = Mathf.Clamp(anchoredPosition.x, (0f - size.x) / 2f + vector.x, size.x / 2f - vector.x);
				anchoredPosition.y = Mathf.Clamp(anchoredPosition.y, (0f - size.y) / 2f + vector.y, size.y / 2f - vector.y);
				rt.anchoredPosition = anchoredPosition;
			}
		}
	}
}
