using UnityEngine;
using UnityEngine.EventSystems;

public class SkillTreeViewController : MonoBehaviour, IDragHandler, IEventSystemHandler, IScrollHandler
{
	public RectTransform contentPanel;

	[Tooltip("The viewport RectTransform (mask) that clips the content. Used for pan boundaries and zoom-to-cursor.")]
	public RectTransform viewport;

	[Tooltip("Multiplier for drag input. 1 = pixel-perfect tracking, higher = faster panning.")]
	public float panSpeed = 1f;

	[Tooltip("How smoothly the pan catches up. Higher = snappier, lower = floatier.")]
	public float panSmoothing = 15f;

	public float zoomSpeed = 0.1f;

	public float minZoom = 0.5f;

	public float maxZoom = 2f;

	[Tooltip("How smoothly the zoom interpolates. Higher = snappier.")]
	public float zoomSmoothing = 12f;

	[Tooltip("How far (in pixels) past the content edge the user can pan. 0 = strict boundary.")]
	public float panMargin = 200f;

	private Vector2 targetPosition;

	private Vector3 targetScale;

	private bool initialized;

	private Canvas rootCanvas;

	private Bounds childBounds;

	private bool boundsCalculated;

	private void Start()
	{
		targetPosition = contentPanel.anchoredPosition;
		targetScale = contentPanel.localScale;
		rootCanvas = GetComponentInParent<Canvas>().rootCanvas;
		initialized = true;
		RecalculateChildBounds();
	}

	private void Update()
	{
		if (initialized)
		{
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			contentPanel.anchoredPosition = Vector2.Lerp(contentPanel.anchoredPosition, targetPosition, unscaledDeltaTime * panSmoothing);
			contentPanel.localScale = Vector3.Lerp(contentPanel.localScale, targetScale, unscaledDeltaTime * zoomSmoothing);
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left || eventData.button == PointerEventData.InputButton.Right || eventData.button == PointerEventData.InputButton.Middle)
		{
			float num = ((rootCanvas != null) ? rootCanvas.scaleFactor : 1f);
			targetPosition += eventData.delta * (panSpeed / num);
			ClampTargetPosition();
		}
	}

	public void OnScroll(PointerEventData eventData)
	{
		float y = eventData.scrollDelta.y;
		float x = targetScale.x;
		float num = Mathf.Clamp(x + y * zoomSpeed, minZoom, maxZoom);
		if (!Mathf.Approximately(num, x))
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle((viewport != null) ? viewport : ((RectTransform)base.transform), eventData.position, eventData.enterEventCamera, out var localPoint);
			Vector2 vector = (localPoint - targetPosition) / x;
			targetPosition = localPoint - vector * num;
			targetScale = new Vector3(num, num, 1f);
			ClampTargetPosition();
		}
	}

	public void RecalculateChildBounds()
	{
		boundsCalculated = false;
		if (contentPanel.childCount == 0)
		{
			return;
		}
		Vector2 vector = new Vector2(float.MaxValue, float.MaxValue);
		Vector2 vector2 = new Vector2(float.MinValue, float.MinValue);
		for (int i = 0; i < contentPanel.childCount; i++)
		{
			RectTransform rectTransform = contentPanel.GetChild(i) as RectTransform;
			if (!(rectTransform == null) && rectTransform.gameObject.activeSelf)
			{
				Vector2 anchoredPosition = rectTransform.anchoredPosition;
				Vector2 vector3 = rectTransform.rect.size * 0.5f;
				vector = Vector2.Min(vector, anchoredPosition - vector3);
				vector2 = Vector2.Max(vector2, anchoredPosition + vector3);
			}
		}
		if (!(vector.x > vector2.x))
		{
			Vector3 center = (Vector3)(vector + vector2) * 0.5f;
			Vector3 size = vector2 - vector;
			childBounds = new Bounds(center, size);
			boundsCalculated = true;
		}
	}

	private void ClampTargetPosition()
	{
		if (!(viewport == null) && boundsCalculated)
		{
			float x = targetScale.x;
			Vector2 size = viewport.rect.size;
			Vector2 vector = (Vector2)childBounds.size * x;
			Vector2 vector2 = (Vector2)childBounds.center * x;
			float num = size.x * 0.5f;
			float num2 = size.y * 0.5f;
			float num3 = vector.x * 0.5f;
			float num4 = vector.y * 0.5f;
			float num5 = ((vector.x <= size.x) ? panMargin : (num3 - num + panMargin));
			float num6 = ((vector.y <= size.y) ? panMargin : (num4 - num2 + panMargin));
			float num7 = 0f - vector2.x;
			float num8 = 0f - vector2.y;
			targetPosition.x = Mathf.Clamp(targetPosition.x, num7 - num5, num7 + num5);
			targetPosition.y = Mathf.Clamp(targetPosition.y, num8 - num6, num8 + num6);
		}
	}
}
