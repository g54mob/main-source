using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class UpgradeTreeUpgradeTooltip : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _title;

	[SerializeField]
	private TextMeshProUGUI _description;

	[SerializeField]
	private TextMeshProUGUI _levelText;

	[SerializeField]
	private TextMeshProUGUI _actionText;

	public Color _baseActionTextColor;

	public Color _missingIngredientActionTextColor;

	[SerializeField]
	private CostGroupUI _costGroupUI;

	private UpgradeInstance _upgradeInstance;

	[SerializeField]
	private LocalizedString _levelLocalizedString;

	[SerializeField]
	private LocalizedString _completedLocalizedString;

	[SerializeField]
	private LocalizedString _notVisibleLocalizedString;

	[SerializeField]
	private LocalizedString _notVisibleTitleLocalizedString;

	[SerializeField]
	private LocalizedString _missingIngredientLocalizedString;

	private UpgradeLevel _shownLevel;

	public Vector2 Offset;

	public UIFadeInOnEnable UIFadeInOnEnable;

	public void Show(UpgradeTreeUIUpgrade upgradeUI)
	{
	}

	public void Clear()
	{
	}
}
