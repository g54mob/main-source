using Rhizomatic.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class SVController : MonoBehaviour, IDragHandler, IEventSystemHandler, IPointerDownHandler
{
	public RectTransform rectTransform;

	public Transform controller;

	public ColorPickerPopup colorPicker;

	public void UpdatePosition()
	{
	}

	public Vector3 GetPosition()
	{
		return default(Vector3);
	}

	public void SetPosition(Color color)
	{
	}

	public Color GetColor(float hue)
	{
		return default(Color);
	}

	public void OnDrag(PointerEventData eventData)
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}
}
