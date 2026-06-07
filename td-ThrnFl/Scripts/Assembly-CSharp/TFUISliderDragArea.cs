using MoreMountains.Feedbacks;
using UnityEngine;

public class TFUISliderDragArea : ThronefallUIElement
{
	public TFUISlider target;

	public Color dragColor;

	public MMF_Player onStartDrag;

	public MMF_Player onEndDrag;

	private Color defaultColor;

	private bool colorInitialized;

	private bool delayedDisable;

	private bool inDrag;

	private float afterDragCounter;

	public override bool dragable => true;

	protected override void OnApply()
	{
	}

	private void Update()
	{
		if (!delayedDisable || inDrag)
		{
			return;
		}
		afterDragCounter += Time.unscaledDeltaTime;
		if (afterDragCounter > 0.35f)
		{
			delayedDisable = false;
			target.knob.SetActive(value: false);
			if ((bool)target.tooltip)
			{
				target.tooltip.SetActive(value: false);
			}
		}
	}

	protected override void OnClear()
	{
		if (!inDrag)
		{
			target.knob.SetActive(value: false);
			if ((bool)target.tooltip)
			{
				target.tooltip.SetActive(value: false);
			}
		}
		else
		{
			delayedDisable = true;
			afterDragCounter = 0f;
		}
	}

	protected override void OnFocus()
	{
		delayedDisable = false;
		target.knob.SetActive(value: true);
		if ((bool)target.tooltip)
		{
			target.tooltip.SetActive(value: true);
		}
	}

	protected override void OnFocusAndSelect()
	{
	}

	protected override void OnHardStateSet(SelectionState selectionState)
	{
	}

	protected override void OnSelect()
	{
	}

	public override void OnDragStart()
	{
		inDrag = true;
		onStartDrag.PlayFeedbacks();
		if (!colorInitialized)
		{
			InitColor();
		}
		target.fillImg.color = dragColor;
		target.knobImg.color = dragColor;
	}

	public override void OnDrag(Vector2 mousePosition)
	{
		target.SetValueByScreenPoint(mousePosition);
	}

	public override void OnDragEnd()
	{
		onEndDrag.PlayFeedbacks();
		target.fillImg.color = defaultColor;
		target.knobImg.color = defaultColor;
		inDrag = false;
	}

	private void InitColor()
	{
		defaultColor = target.fillImg.color;
		colorInitialized = true;
	}

	private void OnEnable()
	{
		if (!colorInitialized)
		{
			InitColor();
		}
		target.fillImg.color = defaultColor;
		inDrag = false;
	}
}
