using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class UpgradeTooltip : ObjectTooltip
{
	[SerializeField]
	private TextMeshProUGUI _title;

	[SerializeField]
	private TextMeshProUGUI _description;

	[SerializeField]
	private TextMeshProUGUI _levelText;

	[SerializeField]
	private TextMeshProUGUI _actionText;

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
	private LocalizedString _hasRequirementLocalizedString;

	[SerializeField]
	private LocalizedString _hasRequirementTitleLocalizedString;

	private UpgradeLevel _shownLevel;

	[SerializeField]
	private bool _showItemTootlips;

	public override string ID => null;

	public override bool CanHandle(object obj)
	{
		return false;
	}

	public override bool CanWipe(object obj)
	{
		return false;
	}

	protected override bool DoHandle(object obj)
	{
		return false;
	}

	protected override bool DoWipe(object obj)
	{
		return false;
	}
}
