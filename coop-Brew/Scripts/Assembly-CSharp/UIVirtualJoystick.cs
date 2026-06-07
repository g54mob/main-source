using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UIVirtualJoystick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IDragHandler, IPointerUpHandler
{
	[Header("Rect References")]
	public RectTransform containerRect;

	public RectTransform handleRect;

	[Header("Settings")]
	public float joystickRange;

	public float magnitudeMultiplier;

	public bool invertXOutputValue;

	public bool invertYOutputValue;

	[Header("Output")]
	public UnityEvent<Vector2> joystickOutputEvent;

	private void Start()
	{
	}

	private void SetupHandle()
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnDrag(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	private void OutputPointerEventValue(Vector2 pointerPosition)
	{
	}

	private void UpdateHandleRectPosition(Vector2 newPosition)
	{
	}

	private Vector2 ApplySizeDelta(Vector2 position)
	{
		return default(Vector2);
	}

	private Vector2 ClampValuesToMagnitude(Vector2 position)
	{
		return default(Vector2);
	}

	private Vector2 ApplyInversionFilter(Vector2 position)
	{
		return default(Vector2);
	}

	private float InvertValue(float value)
	{
		return 0f;
	}
}
