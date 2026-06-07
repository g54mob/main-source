using UnityEngine;
using UnityEngine.EventSystems;

public class MoveUIByMouse : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
{
	private RectTransform rectTransform;

	[SerializeField]
	private Canvas canvas;

	[SerializeField]
	private Material mat_Map;

	[SerializeField]
	private float materialOffsetScale;

	[SerializeField]
	private float scaleMultiplierMin;

	[SerializeField]
	private float scaleMultiplierMax;

	[SerializeField]
	private float mouseScrollFactor;

	private bool isDragging;

	private Vector2 pointerOffset;

	private Vector2 targetAnchorPos;

	private Vector2 initialPos;

	private Vector2 totalOffset;

	private float scaleMultiplier;

	private void Awake()
	{
	}

	private void Update()
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

	public void CenterToPosition(Vector3 position, Vector3 offset)
	{
	}
}
