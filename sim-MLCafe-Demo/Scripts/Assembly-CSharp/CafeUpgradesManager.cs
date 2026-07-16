using System;
using UnityEngine;

public class CafeUpgradesManager : MonoBehaviour, IDataPersistence
{
	[SerializeField]
	private GameObject customizationScreen;

	[SerializeField]
	private CafeStyleUpgrade[] wallStyles;

	private bool useLoadedUpgrades;

	private void Awake()
	{
		CafeDataLoader.OnLoadWorldFinished.AddListener(delegate(GameData data)
		{
			LoadData(data, isNewGameData: false);
		});
	}

	private void Start()
	{
		if (!useLoadedUpgrades)
		{
			LockStyles(wallStyles);
			TryUnlockStyles(ProgressionManager.GetCurrentLevel(), wallStyles);
		}
		UpdateButtonSelection(0, wallStyles);
		UnlockStyle(0, wallStyles);
		wallStyles[0].HideBuyScreen();
		ProgressionManager.ListenOnLevelUp(delegate(int lvl)
		{
			TryUnlockStyles(lvl, wallStyles);
		});
	}

	public void LockStyles(CafeStyleUpgrade[] list)
	{
		for (int i = 1; i < list.Length; i++)
		{
			list[i].Lock();
		}
	}

	public void TryUnlockStyles(int lvl, CafeStyleUpgrade[] list)
	{
		for (int i = 1; i < list.Length; i++)
		{
			if (lvl >= list[i].unlockLevel)
			{
				list[i].Unlock();
			}
		}
	}

	public void UnlockStyle(int style, CafeStyleUpgrade[] list)
	{
		if (style < list.Length)
		{
			list[style].Unlock();
		}
	}

	public void ShowCustomizationScreen()
	{
		customizationScreen.SetActive(value: true);
	}

	public void HideCustomizationScreen()
	{
		customizationScreen.SetActive(value: false);
	}

	public void SetWallVariation(int index)
	{
		if (!wallStyles[index].bought)
		{
			Action onConfirm = delegate
			{
				WalletSystem.GetPlayerWallet().ForceRemoveAmount(wallStyles[index].price);
				wallStyles[index].HideBuyScreen();
				SoundManager.PlaySoundOnce("management_buy_cafestyle");
			};
			PopupMessageManager.GetConfirmationPopUp().ShowComputerConfirmationPopUp("ui_popup_confirmation_msg_buystyle", onConfirm, null);
		}
		else
		{
			WallVisualizerComponent[] array = UnityEngine.Object.FindObjectsByType<WallVisualizerComponent>(FindObjectsSortMode.InstanceID);
			for (int num = 0; num < array.Length; num++)
			{
				array[num].SwitchWallSet(index);
			}
			UpdateButtonSelection(index, wallStyles);
		}
	}

	private void UpdateButtonSelection(int index, CafeStyleUpgrade[] list)
	{
		for (int i = 0; i < list.Length; i++)
		{
			if (i == index)
			{
				list[i].button.Select();
			}
			else
			{
				list[i].button.Deselect();
			}
		}
	}

	public void LoadData(GameData data, bool isNewGameData)
	{
		useLoadedUpgrades = true;
		LockStyles(wallStyles);
		TryUnlockStyles(data.level, wallStyles);
		for (int i = 0; i < data.wallUpgrades.Count && i < wallStyles.Length; i++)
		{
			UnlockStyle(i, wallStyles);
			wallStyles[i].HideBuyScreen();
		}
	}

	public void SaveData(ref GameData data)
	{
		for (int i = 0; i < wallStyles.Length; i++)
		{
			if (wallStyles[i].bought)
			{
				data.wallUpgrades.Add(i);
			}
		}
	}
}
