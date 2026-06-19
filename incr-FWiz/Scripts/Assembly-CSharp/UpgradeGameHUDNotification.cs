using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class UpgradeGameHUDNotification : GameHUDNotification
{
	[SerializeField]
	private TextMeshProUGUI _titleText;

	[SerializeField]
	private TextMeshProUGUI _levelText;

	[SerializeField]
	private Image _upgradeImage;

	[SerializeField]
	private LocalizedString _levelUnlockedLocalizedString;

	[SerializeField]
	private LocalizedString _unlockedLocalizedString;

	public void Set(UpgradeInstance upgradeInstance)
	{
	}
}
