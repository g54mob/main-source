using UnityEngine;
using UnityEngine.EventSystems;

public class MiniMapMovement : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
{
	public MiniMapHover miniMapHover;

	public MapConvertPositionToMap mapConvertPositionToMap;

	public RectTransform buttonDisableGhostMode;

	public RectTransform miniMapRect;

	public Camera targetCamera;

	public float panSpeed;

	public float ghostActivationThreshold;

	public Vector2 cameraLimitX;

	public Vector2 cameraLimitZ;

	private bool isDragging;

	private bool hasGhostModeStarted;

	private Vector2 dragStartMousePosition;

	private Vector2 lastMousePosition;

	public Vector2Int CameraZoom;

	public float zoomStep;

	public void Update()
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	public void OnDrag(PointerEventData eventData)
	{
	}

	public void ButtonDisableGhostMode()
	{
	}
}
