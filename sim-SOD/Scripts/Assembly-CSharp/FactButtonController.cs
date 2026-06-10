using UnityEngine;
using UnityEngine.UI;

public class FactButtonController : ButtonController
{
	public Evidence.FactLink link;

	public Fact fact;

	public ButtonController toggleHiddenButton;

	public Image parentToThisIcon;

	public Image childOfThisIcon;

	public Sprite shownConnection;

	public Sprite hiddenConnection;

	public Color shownColor;

	public Color hiddenColor;

	public RectTransform isSeenIcon;

	private bool isSetup;

	private bool enabledFirstTime;

	public bool inSlot;

	public void Setup(Evidence.FactLink newFactLink, InfoWindow newParentWindow)
	{
	}

	public void OnSeen()
	{
	}

	public void ToggleHidden(ButtonController thisButton)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	public override void VisualUpdate()
	{
	}

	public override void OnLeftClick()
	{
	}

	public override void UpdateTooltipText()
	{
	}

	public override void OnHoverStart()
	{
	}

	public override void OnHoverEnd()
	{
	}

	public void UpdatePulsate(ButtonController hoveredButton, bool mouseOver)
	{
	}
}
