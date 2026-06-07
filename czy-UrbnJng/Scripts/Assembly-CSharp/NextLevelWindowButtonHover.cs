using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class NextLevelWindowButtonHover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public event EventHandler OnHoverStart;

	public event EventHandler OnHoverEnd;

	public void OnPointerEnter(PointerEventData eventData)
	{
		this.OnHoverStart?.Invoke(this, EventArgs.Empty);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		this.OnHoverEnd?.Invoke(this, EventArgs.Empty);
	}
}
