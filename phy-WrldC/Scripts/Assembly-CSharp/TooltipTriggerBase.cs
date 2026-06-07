using UnityEngine;
using UnityEngine.EventSystems;

public abstract class TooltipTriggerBase : MonoBehaviour
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

	[SerializeField]
	protected bool isActivated = true;

	[SerializeField]
	protected float displayDelay = 1f;

	[Space(10f)]
	[SerializeField]
	protected VerticalAlignment verticalAlignment = VerticalAlignment.Bottom;

	[SerializeField]
	protected HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left;

	[Tooltip("Valor positivo move para cima e negativo para baixo")]
	[SerializeField]
	protected float verticalOffset;

	[Tooltip("Valor positivo move para direita e negativo para esquerda")]
	[SerializeField]
	protected float horizontalOffset;

	[Space(10f)]
	[SerializeField]
	protected TooltipPanelBase tooltipPanel;

	private bool shouldDisplay;

	private float displayDelayCounter;

	protected RectTransform rectTransform;

	public bool IsActivated
	{
		get
		{
			return isActivated;
		}
		set
		{
			isActivated = value;
		}
	}

	protected virtual void Awake()
	{
		Util.AddMouseOverUIEvents(base.gameObject, CheckMouseOverUI);
		Util.AddMouseUIEvent(base.gameObject, EventTriggerType.PointerClick, OnMouseClickedHandler);
		rectTransform = GetComponent<RectTransform>();
		shouldDisplay = false;
	}

	protected virtual void OnDisable()
	{
		shouldDisplay = false;
	}

	protected virtual void Update()
	{
		if (tooltipPanel == null || !shouldDisplay || tooltipPanel.IsPanelVisible)
		{
			return;
		}
		displayDelayCounter += Time.deltaTime;
		if (!(displayDelayCounter >= displayDelay))
		{
			return;
		}
		SetTooltipPanelContent();
		if (!tooltipPanel.IsPositionFixed)
		{
			Vector3[] array = new Vector3[4];
			rectTransform.GetWorldCorners(array);
			float num = 0f;
			float num2 = 0f;
			if (verticalAlignment == VerticalAlignment.Bottom)
			{
				num2 = array[0].y;
			}
			else if (verticalAlignment == VerticalAlignment.Middle)
			{
				num2 = array[0].y + (array[1].y - array[0].y) / 2f;
			}
			else if (verticalAlignment == VerticalAlignment.Top)
			{
				num2 = array[1].y;
			}
			if (horizontalAlignment == HorizontalAlignment.Left)
			{
				num = array[0].x;
			}
			else if (horizontalAlignment == HorizontalAlignment.Center)
			{
				num = array[0].x + (array[3].x - array[0].x) / 2f;
			}
			else if (horizontalAlignment == HorizontalAlignment.Right)
			{
				num = array[3].x;
			}
			num += horizontalOffset * tooltipPanel.UIPixelScale;
			num2 += verticalOffset * tooltipPanel.UIPixelScale;
			tooltipPanel.SetPosition(new Vector3(num, num2, base.transform.position.z));
		}
		tooltipPanel.SetVisibility(isVisible: true);
	}

	protected abstract void SetTooltipPanelContent();

	private void CheckMouseOverUI(bool isOver)
	{
		if (!(tooltipPanel == null) && isActivated)
		{
			shouldDisplay = isOver;
			displayDelayCounter = 0f;
			if (!isOver)
			{
				tooltipPanel.SetVisibility(isVisible: false);
			}
		}
	}

	private void OnMouseClickedHandler(BaseEventData baseEventData)
	{
		if (!(tooltipPanel == null))
		{
			shouldDisplay = false;
			tooltipPanel.SetVisibility(isVisible: false);
		}
	}
}
