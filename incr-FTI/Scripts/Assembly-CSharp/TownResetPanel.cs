using TMPro;

public class TownResetPanel : MenuPanel
{
	public TextMeshProUGUI totalResets;

	public TextMeshProUGUI totalResetsCount;

	public TextMeshProUGUI totalPerkCoinsEarned;

	public TextMeshProUGUI totalPerkCoinsEarnedCount;

	public TextMeshProUGUI townXpMultiplier;

	public TextMeshProUGUI townXpMultiplierCount;

	public TextMeshProUGUI currentTownLevel;

	public TextMeshProUGUI currentTownLevelCount;

	public LabelButton resetButton;

	public LabelButton perksButton;

	public TextMeshProUGUI resetButtonValue;

	private TextFlashAnimation pointValueFlashAnimation;

	private string InfoFormatPos = "{0} <color=#00FF00><b>-></b> {1}</color> ({2})";

	private string InfoFormatNeg = "{0} <color=#FF0000><b>-></b> {1}</color>";

	public override void Initialize()
	{
		base.Initialize();
		resetButton.AddPointerClickTrigger(OnResetPressed);
		perksButton.AddPointerClickTrigger(OnPerksPressed);
		pointValueFlashAnimation = new TextFlashAnimation(resetButtonValue);
	}

	public override void Show()
	{
		ReloadLabels();
		base.Show();
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		pointValueFlashAnimation.UpdateAnimation();
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		Town activeTown = MenuPanel.gm.activeTown;
		double currentCount = activeTown.townPerkPointState.currentCount;
		double value = activeTown.townPerkPointState.currentCount + (double)activeTown.pendingPrestigeCoins;
		float num = 0f;
		int numTownResets = activeTown.numTownResets;
		int pendingPrestigeCoins = activeTown.pendingPrestigeCoins;
		float num2 = 1f;
		totalResets.text = "TownResets".Localized();
		totalResetsCount.text = string.Format(InfoFormatPos, TextDisplay.LocalizedNumber(numTownResets), TextDisplay.LocalizedNumber(numTownResets + 1), "+" + TextDisplay.LocalizedNumber(1));
		currentTownLevel.text = "TownLevel".Localized();
		currentTownLevelCount.text = string.Format(InfoFormatNeg, TextDisplay.LocalizedNumber(MenuPanel.gm.activeTown.townLevel), TextDisplay.LocalizedNumber(0));
		totalPerkCoinsEarned.text = string.Format("TotalEarnedFormat".Localized(), TextDisplay.LabelForItem(ItemType.UtilityPrestigePoint));
		totalPerkCoinsEarnedCount.text = string.Format(InfoFormatPos, TextDisplay.LocalizedNumber(currentCount), TextDisplay.LocalizedNumber(value), "+" + TextDisplay.LocalizedNumber(pendingPrestigeCoins));
		townXpMultiplier.text = "TownXPMultiplier".Localized();
		townXpMultiplierCount.text = string.Format(InfoFormatPos, TextDisplay.Percent(num - 1f), TextDisplay.Percent(num2 - 1f), "+" + TextDisplay.Percent(num2 - num));
		resetButtonValue.text = "+" + TextDisplay.LocalizedNumber(pendingPrestigeCoins);
		if (MenuPanel.gm.activeTown.townLevel >= 0)
		{
			_ = (float)MenuPanel.gm.activeTown.pendingPrestigeCoins > 0f;
		}
		else
			_ = 0;
		resetButton.label.text = "Reset".Localized();
		resetButton.buttonState = CustomButtonState.Default;
		perksButton.label.text = "PrestigeUpgrades".Localized();
		perksButton.buttonState = CustomButtonState.Default;
	}

	private void OnPerksPressed()
	{
		MenuPanel.m.townPerksPanel.ManuallyOpen();
	}

	private void OnResetPressed()
	{
	}
}
