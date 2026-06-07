using System;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ComplexListItem : MonoBehaviour, IScrollHandler, IEventSystemHandler
{
	public RectTransform Self;

	[NonSerialized]
	public bool InUse;

	private GUIComplexList _parent;

	[NonSerialized]
	private object _content;

	public object Content
	{
		get
		{
			return _content;
		}
		set
		{
			InitItem(value);
			RefreshSelected();
		}
	}

	public void Init(GUIComplexList parent)
	{
		_parent = parent;
	}

	private void InitItem(object item)
	{
		_content = item;
		Self.sizeDelta = new Vector2(0f, GetHeight(item, _parent.ContentPanel.rect.width));
		InitializeContent(item);
	}

	public void RefreshSelected()
	{
		SetSelectedUI(_parent.GetSelected(_content));
	}

	protected abstract void InitializeContent(object item);

	public abstract void SetSelectedUI(bool toggle);

	public abstract float GetHeight(object content, float width);

	public void SelectClick()
	{
		_parent.ToggleSelected(this);
	}

	public void OnScroll(PointerEventData eventData)
	{
		GUIComplexList parent = _parent;
		if ((object)parent != null)
		{
			parent.OnScroll(eventData);
		}
	}
}
