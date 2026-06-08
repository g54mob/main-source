using System.Collections.Generic;
using UnityEngine;

public class IngameUiToggler : MonoBehaviour
{
	[SerializeField]
	private SettingsRouter settingsRouter;

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private List<GameObject> uiObjects;

	[SerializeField]
	private GameObject gameOverScreen;

	private void Start()
	{
		settingsRouter.ShowIngameUI(newActive: true);
		settingsRouter.OnShowIngameUi += ShowIngameUi;
	}

	private void ShowIngameUi(bool newEnabled)
	{
		foreach (GameObject uiObject in uiObjects)
		{
			uiObject.SetActive(newEnabled);
		}
		if (rewardSystem.IsGameOver)
		{
			gameOverScreen.SetActive(newEnabled);
		}
	}

	private void OnDestroy()
	{
		settingsRouter.OnShowIngameUi -= ShowIngameUi;
	}
}
