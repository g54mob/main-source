using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class NavigationIcon : MenuButton
{
	public object loadedObject;

	public Image iconImage;

	public UnityAction<NavigationIcon> onClickedDelegate;

	public TextMeshProUGUI label;

	protected override void Awake()
	{
		base.Awake();
		useVerticalTooltip = true;
		AddPointerClickTrigger(OnPointerClick);
		highlightTextDelegate = GetHighlightText;
	}

	private void OnPointerClick()
	{
		onClickedDelegate?.Invoke(this);
	}

	private string GetHighlightText()
	{
		if (loadedObject is TradeMode m)
		{
			return TextDisplay.TooltipForTradeMode(m);
		}
		if (loadedObject is StatePriority p)
		{
			return TextDisplay.LabelForPriority(p);
		}
		if (loadedObject is PauseState pauseState)
		{
			return TextDisplay.LabelforPauseState(pauseState);
		}
		return null;
	}
}
