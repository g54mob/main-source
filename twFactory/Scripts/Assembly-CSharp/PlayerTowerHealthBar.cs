using UnityEngine.Localization.Settings;

public class PlayerTowerHealthBar : HealthBar
{
	private TooltipComponent_text tooltipText;

	private void Awake()
	{
		tooltipText = GetComponent<TooltipComponent_text>();
	}

	protected override void Start()
	{
		base.Start();
		CombatComponent = LTFunctionLibrary.GetLTGameManager().PlayerTower.CombatComponent;
		UpdateTooltipText();
	}

	protected override void OnHealthChanged(float newValue, float oldValue)
	{
		base.OnHealthChanged(newValue, oldValue);
		UpdateTooltipText();
	}

	private void UpdateTooltipText()
	{
		tooltipText.TooltipText = string.Format(LocalizationSettings.StringDatabase.GetTableEntry("UI_InGame", "UI_InGame_main_tooltip_playerHealth").Entry.GetLocalizedString(), CombatComponent.Health, CombatComponent.MaxHealth);
	}
}
