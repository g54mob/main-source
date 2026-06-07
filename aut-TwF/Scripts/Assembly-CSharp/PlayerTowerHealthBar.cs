using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class PlayerTowerHealthBar : HealthBar
{
	[SerializeField]
	private TextMeshProUGUI amountText;

	private TooltipComponent_text tooltipText;

	private void Awake()
	{
		tooltipText = GetComponent<TooltipComponent_text>();
	}

	protected override void Start()
	{
		base.Start();
		CombatComponent = LTFunctionLibrary.GetLTGameManager().PlayerTower.CombatComponent;
		amountText.text = combatComponent.Health.ToString();
		UpdateTooltipText();
	}

	protected override void OnHealthChanged(float newValue, float oldValue)
	{
		base.OnHealthChanged(newValue, oldValue);
		amountText.text = newValue.ToString();
		(amountText.transform as RectTransform).DOKill(complete: true);
		(amountText.transform as RectTransform).DOPunchScale(Vector3.one * 0.75f, 0.5f).SetUpdate(isIndependentUpdate: true);
		UpdateTooltipText();
	}

	private void UpdateTooltipText()
	{
		tooltipText.TooltipText = string.Format(LocalizationSettings.StringDatabase.GetTableEntry("UI_InGame", "UI_InGame_main_tooltip_playerHealth").Entry.GetLocalizedString(), CombatComponent.Health, CombatComponent.MaxHealth);
	}
}
