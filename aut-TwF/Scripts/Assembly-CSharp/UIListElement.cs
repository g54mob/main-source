using System;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UIListElement : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Action<UIListElement> onClickElement;

	public Action<UIListElement> onPointerEnter;

	public Action<UIListElement> onPointerExit;

	private int index;

	private object data;

	public int Index
	{
		get
		{
			return index;
		}
		set
		{
			index = value;
		}
	}

	public object Data
	{
		get
		{
			return data;
		}
		set
		{
			data = value;
			LoadData();
		}
	}

	public abstract void LoadData();

	public virtual void OnPointerClick(PointerEventData eventData)
	{
		onClickElement?.Invoke(this);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		onPointerEnter?.Invoke(this);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		onPointerExit?.Invoke(this);
	}
}
