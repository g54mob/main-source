using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class CliffTexturePicker : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler
{
	[Serializable]
	public class OnCliffTextureSelectedEvent : UnityEvent<short>
	{
	}

	private const float delta = 25f;

	public OnCliffTextureSelectedEvent onCliffTextureSelected;

	public RectTransform selection0;

	public RectTransform selection1;

	public RawImage preview;

	public Text previewText;

	private short _currentTexture;

	public short currentTexture
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	private void Update()
	{
	}

	public void OnPointerDown(PointerEventData ped)
	{
	}

	public void OnPointerUp(PointerEventData ped)
	{
	}

	public void OnPointerClick(PointerEventData ped)
	{
	}

	public void SetCurrentTexture(short val)
	{
	}

	private Vector2 GetTexturePosFromMouse(Vector2 mousePos)
	{
		return default(Vector2);
	}

	private short GetTexureNumber(Vector2 mousePos)
	{
		return 0;
	}

	private Vector2 GetPosFromTexture(int t)
	{
		return default(Vector2);
	}
}
