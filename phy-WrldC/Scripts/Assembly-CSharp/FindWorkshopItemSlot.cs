using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FindWorkshopItemSlot : MonoBehaviour
{
	public enum ItemType
	{
		Level = 0,
		Contraption = 1
	}

	[SerializeField]
	private ItemType itemType;

	private TextMeshProUGUI findItemText;

	private TextMeshProUGUI steamOfflineText;

	private Button workshopButton;

	private void Awake()
	{
		findItemText = base.transform.FindComponent<TextMeshProUGUI>("FindItemText", isRecursively: true);
		steamOfflineText = base.transform.FindComponent<TextMeshProUGUI>("SteamOfflineText", isRecursively: true);
		workshopButton = base.transform.FindComponent<Button>("WorkshopButton", isRecursively: true);
		if (!SteamManager.Initialized)
		{
			findItemText.gameObject.SetActive(value: false);
			steamOfflineText.gameObject.SetActive(value: true);
			workshopButton.gameObject.SetActive(value: false);
		}
		workshopButton.onClick.AddListener(delegate
		{
			if (SteamManager.Initialized)
			{
				string text = SteamUtils.GetAppID().ToString();
				string text2 = ((itemType == ItemType.Level) ? "level" : "contraption");
				SteamFriends.ActivateGameOverlayToWebPage("https://steamcommunity.com/workshop/browse/?appid=" + text + "&requiredtags[]=" + text2);
			}
		});
	}
}
