using TMPro;
using UnityEngine.UI;

public class RewardListItem : MenuButton
{
	public Image iconImage;

	public TextMeshProUGUI primaryLabel;

	public LayoutElement layoutElement;

	public MenuButton titleButton;

	public Image titleButtonImage;

	public EntityId loadedEntity;

	private bool hasInitialized;

	public void ResetRewardItem()
	{
		layoutElement.minHeight = 46f;
		loadedEntity = EntityId.None;
		tooltipEntity = EntityId.None;
		tooltipModifier = TooltipModifier.None;
		tooltipOptions = null;
		if (null != titleButtonImage)
		{
			titleButtonImage.raycastTarget = false;
		}
		if (!hasInitialized)
		{
			if (null != titleButton)
			{
				titleButton.AddPointerClickTrigger(OnTitleLabelClicked);
				titleButton.tooltipOptions = MenuManager.Instance.recipeLabelTooltipOptions;
				titleButton.tooltipModifier = TooltipModifier.ShowGuide;
			}
			hasInitialized = true;
		}
	}

	private void OnTitleLabelClicked()
	{
		if (loadedEntity.type != EntityType.None)
		{
			MenuManager.Instance.tooltipPanel.ToggleEntityPinState(loadedEntity);
		}
	}

	public void SetLarger()
	{
		layoutElement.minHeight = 70f;
	}
}
