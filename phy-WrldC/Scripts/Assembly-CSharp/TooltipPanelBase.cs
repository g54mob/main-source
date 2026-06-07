using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class TooltipPanelBase : MonoBehaviour
{
	public enum VerticalAlignment
	{
		Top = 0,
		Middle = 1,
		Bottom = 2
	}

	public enum HorizontalAlignment
	{
		Right = 0,
		Center = 1,
		Left = 2
	}

	protected Canvas parentCanvas;

	protected RectTransform parentCanvasRecTransform;

	private CanvasGroup canvasGroup;

	[SerializeField]
	protected float fadeInTime = 0.2f;

	[SerializeField]
	protected float fadeOutTime = 0.2f;

	[SerializeField]
	protected bool isPositionFixed;

	[Space(10f)]
	[SerializeField]
	protected VerticalAlignment verticalAlignment = VerticalAlignment.Bottom;

	[SerializeField]
	protected HorizontalAlignment horizontalAlignment;

	[Tooltip("Valor positivo move para cima e negativo para baixo")]
	[SerializeField]
	protected float verticalOffset;

	[Tooltip("Valor positivo move para direita e negativo para esquerda")]
	[SerializeField]
	protected float horizontalOffset;

	protected float rightEndScreenPadding = 10f;

	protected float leftEndScreenPadding = 10f;

	private float fadeTimeCounter;

	public bool IsPanelVisible { get; private set; }

	public RectTransform RectTransform { get; private set; }

	public float UIPixelScale { get; private set; }

	public bool IsPositionFixed => isPositionFixed;

	public event Action OnTooltipDisplayedEvent;

	protected virtual void Awake()
	{
		parentCanvas = GetComponentInParent<Canvas>();
		parentCanvasRecTransform = parentCanvas.GetComponent<RectTransform>();
		canvasGroup = GetComponent<CanvasGroup>();
		RectTransform = GetComponent<RectTransform>();
		IsPanelVisible = false;
		fadeTimeCounter = 0f;
		canvasGroup.alpha = 0f;
		UIPixelScale = parentCanvas.transform.localScale.x;
	}

	protected virtual void Update()
	{
		if (IsPanelVisible)
		{
			canvasGroup.alpha = Mathf.SmoothDamp(canvasGroup.alpha, 1f, ref fadeTimeCounter, fadeInTime);
		}
		else
		{
			canvasGroup.alpha = Mathf.SmoothDamp(canvasGroup.alpha, 0f, ref fadeTimeCounter, fadeOutTime);
		}
	}

	public void SetPosition(Vector3 newPosition)
	{
		SetPosition(newPosition, verticalAlignment, horizontalAlignment);
	}

	public void SetPosition(Vector3 newPosition, VerticalAlignment verticalAlignment)
	{
		SetPosition(newPosition, verticalAlignment, horizontalAlignment);
	}

	public void SetPosition(Vector3 newPosition, HorizontalAlignment horizontalAlignment)
	{
		SetPosition(newPosition, verticalAlignment, horizontalAlignment);
	}

	public void SetPosition(Vector3 newPosition, VerticalAlignment verticalAlignment, HorizontalAlignment horizontalAlignment)
	{
		this.verticalAlignment = verticalAlignment;
		this.horizontalAlignment = horizontalAlignment;
		Canvas.ForceUpdateCanvases();
		LayoutRebuilder.ForceRebuildLayoutImmediate(RectTransform);
		base.transform.SetPositionX(newPosition.x);
		base.transform.SetPositionY(newPosition.y);
		Vector3[] array = new Vector3[4];
		Vector3[] array2 = new Vector3[4];
		RectTransform.GetWorldCorners(array);
		parentCanvasRecTransform.GetWorldCorners(array2);
		float num = array[1].y - array[0].y;
		switch (verticalAlignment)
		{
		case VerticalAlignment.Top:
			base.transform.SetPositionY(base.transform.position.y + num);
			break;
		case VerticalAlignment.Middle:
			base.transform.SetPositionY(base.transform.position.y + num / 2f);
			break;
		}
		RectTransform.GetWorldCorners(array);
		float num2 = array[2].x - array[1].x;
		switch (horizontalAlignment)
		{
		case HorizontalAlignment.Center:
			base.transform.SetPositionX(base.transform.position.x - num2 / 2f);
			break;
		case HorizontalAlignment.Left:
			base.transform.SetPositionX(base.transform.position.x - num2);
			break;
		}
		RectTransform.GetWorldCorners(array);
		float x = array[2].x;
		float x2 = array2[2].x;
		float num3 = x - x2;
		if (num3 > 0f)
		{
			base.transform.SetPositionX(base.transform.position.x - (num3 + rightEndScreenPadding * UIPixelScale));
		}
		RectTransform.GetWorldCorners(array);
		float x3 = array[1].x;
		float num4 = array2[1].x - x3;
		if (num4 > 0f)
		{
			base.transform.SetPositionX(base.transform.position.x + (num4 + leftEndScreenPadding * UIPixelScale));
		}
		base.transform.SetPositionX(base.transform.position.x + horizontalOffset * UIPixelScale);
		base.transform.SetPositionY(base.transform.position.y + verticalOffset * UIPixelScale);
	}

	public virtual void SetVisibility(bool isVisible)
	{
		IsPanelVisible = isVisible;
		if (isVisible && this.OnTooltipDisplayedEvent != null)
		{
			this.OnTooltipDisplayedEvent();
		}
	}
}
