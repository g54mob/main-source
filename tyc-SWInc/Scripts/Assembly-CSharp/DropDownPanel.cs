using UnityEngine;
using UnityEngine.EventSystems;

public abstract class DropDownPanel : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
{
	public RectTransform DropdownPanel;

	public RectTransform SelfRect;

	private bool _isOpen;

	protected abstract float GetHeight();

	protected abstract void Refresh();

	private void Update()
	{
		float y = DropdownPanel.sizeDelta.y;
		if (_isOpen)
		{
			Refresh();
			float height = GetHeight();
			DropdownPanel.sizeDelta = new Vector2(DropdownPanel.sizeDelta.x, Mathf.Lerp(y, height, Time.deltaTime * 20f));
			if (Mathf.Abs(DropdownPanel.sizeDelta.y - height) < 1f)
			{
				DropdownPanel.sizeDelta = new Vector2(DropdownPanel.sizeDelta.x, height);
			}
			if (!RectTransformUtility.RectangleContainsScreenPoint(DropdownPanel, Input.mousePosition, UICamSize.GetUICam()) && !RectTransformUtility.RectangleContainsScreenPoint(SelfRect, Input.mousePosition, UICamSize.GetUICam()))
			{
				_isOpen = false;
			}
		}
		else if (y > 0f)
		{
			if (y < 0.01f)
			{
				DropdownPanel.sizeDelta = new Vector2(DropdownPanel.sizeDelta.x, 0f);
			}
			else
			{
				DropdownPanel.sizeDelta = new Vector2(DropdownPanel.sizeDelta.x, Mathf.Lerp(y, 0f, Time.deltaTime * 20f));
			}
		}
	}

	public void InstaClose()
	{
		_isOpen = false;
		DropdownPanel.sizeDelta = new Vector2(DropdownPanel.sizeDelta.x, 0f);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_isOpen = true;
	}
}
