using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class BuildingUnlockedGameHUDNotification : GameHUDNotification
{
	[SerializeField]
	private TextMeshProUGUI _titleText;

	[SerializeField]
	private TextMeshProUGUI _unlockedText;

	[SerializeField]
	private Image _upgradeImage;

	[SerializeField]
	private LocalizedString _unlockedLocalizedString;

	public void Set(BuildingAsset buildingAsset)
	{
	}
}
