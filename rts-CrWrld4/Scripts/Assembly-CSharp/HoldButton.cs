using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class HoldButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler
{
	[Serializable]
	public class OnClickedEvent : UnityEvent
	{
	}

	public float activateTime;

	public Image indicatorImage;

	public OnClickedEvent OnClicked;

	private float downTime;

	public void OnPointerDown(PointerEventData ped)
	{
	}

	public void OnPointerUp(PointerEventData ped)
	{
	}

	public void OnPointerClick(PointerEventData ped)
	{
	}

	public void Update()
	{
	}

	private void HoldClicked()
	{
	}
}
