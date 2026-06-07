using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UIVirtualTouchZone : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IDragHandler, IPointerUpHandler
{
	[Header("Rect References")]
	public RectTransform containerRect;

	public RectTransform handleRect;

	[Header("Settings")]
	public bool clampToMagnitude;

	public float magnitudeMultiplier;

	public bool invertXOutputValue;

	public bool invertYOutputValue;

	private Vector2 pointerDownPosition;

	private Vector2 currentPointerPosition;

	[Header("Output")]
	public UnityEvent<Vector2> touchZoneOutputEvent;

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

	private void SetObjectActiveState(GameObject targetObject, bool newState)
	{
	}

	private Vector2 GetDeltaBetweenPositions(Vector2 firstPosition, Vector2 secondPosition)
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
