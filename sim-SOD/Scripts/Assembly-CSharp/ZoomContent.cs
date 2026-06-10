using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class ZoomContent : MonoBehaviour
{
	public enum ZoomPivot
	{
		mousePosition = 0,
		playerMapPosition = 1
	}

	[Header("Zoom settings")]
	[Tooltip("Which controller axis to poll")]
	public string zoomAxis;

	[Tooltip("Use controller input to affect zoom level")]
	public bool enableZoomWithMouseWheel;

	[Tooltip("Toggle true if this is the first person map")]
	public bool enableInFirstPersonMap;

	[Space(7f)]
	public bool useZoomSteps;

	[EnableIf("useZoomSteps")]
	public int numberOfSteps;

	[DisableIf("useZoomSteps")]
	public float zoomSensitivity;

	[DisableIf("useZoomSteps")]
	public float controllerSensitivityMultiplier;

	[Space(7f)]
	[Tooltip("Scaling of the zoom level: Normalized values")]
	public AnimationCurve zoomCurve;

	[Tooltip("How fast this zooms in/out")]
	public float smoothZoomSpeed;

	[Tooltip("Min/max limits of the zoom")]
	public Vector2 zoomLimit;

	[Tooltip("How much the centre of the viewpoint changes to the cursor position")]
	public float zoomToCursorPercentage;

	[Space(7f)]
	public float zoom;

	public float desiredZoom;

	public float normalizedZoom;

	[ReadOnly]
	public float zoomProgress;

	[ReadOnly]
	public Vector2 normalSize;

	[ReadOnly]
	public float axisInputDelay;

	[Space(7f)]
	[Tooltip("If the mouse is over one of these UI elements then allow zoom")]
	public List<string> allowedMouseOverTags;

	[Tooltip("Zoom these additional rectTransforms")]
	public List<RectTransform> additionalRects;

	[Header("References")]
	public InfoWindow window;

	public RectTransform containerRect;

	public CustomScrollRect scroll;

	public RectTransform scrollRectArea;

	public ViewportMouseOver viewportMouseOver;

	public WindowContentController contentController;

	public CanvasGroup canvasGroup;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void SetPivotPoint(float pivotBias, ZoomPivot usePivot = ZoomPivot.mousePosition)
	{
	}

	public void ResetPivot()
	{
	}

	private void LateUpdate()
	{
	}

	public float GetNormalizedZoom(float zoom)
	{
		return 0f;
	}

	public void ApplyZoom(float normalizedZoom)
	{
	}

	public void SetZoom(float newZoom)
	{
	}
}
