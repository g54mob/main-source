using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDiscoveredGameHUDNotification : GameHUDNotification
{
	[SerializeField]
	private TextMeshProUGUI _titleText;

	[SerializeField]
	private Image _upgradeImage;

	public void Set(ItemType itemType)
	{
	}
}
