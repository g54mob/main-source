using System;
using Rhizomatic.MemberBinding;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ButtonHelper : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler, IMemberButton
{
	public UnityEvent onClick;

	private float downTime;

	private Vector2 downPosition;

	private bool isDown;

	private float MAX_TIME;

	private float MAX_DISTANCE;

	private void OnClick()
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	public void Register(Action action)
	{
	}
}
