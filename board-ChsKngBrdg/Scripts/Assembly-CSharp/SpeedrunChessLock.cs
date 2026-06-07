using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedrunChessLock : MonoBehaviour
{
	[SerializeField]
	private TMP_Text speedrunText;

	[SerializeField]
	private Button button;

	[SerializeField]
	private GlobalColor whiteColor;

	private void Start()
	{
		if (SteamAchievements.IsThisAchievementUnlocked("UNLOCKED_ALL_PAGES"))
		{
			UnlockSpeedrunMode();
		}
		else
		{
			LockSpeedrunMode();
		}
	}

	private void LockSpeedrunMode()
	{
		button.enabled = false;
		speedrunText.color = new Color(whiteColor.globalColor.r, whiteColor.globalColor.g, whiteColor.globalColor.b, 0.5f);
	}

	private void UnlockSpeedrunMode()
	{
		button.enabled = true;
		speedrunText.color = whiteColor.globalColor;
	}
}
