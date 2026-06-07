using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BerryPicker : MonoBehaviour
{
	public enum BerryPickerState
	{
		Off = 0,
		Random = 1,
		RandomFromBuddies = 2,
		Blueberry = 3,
		Raspberry = 4,
		Strawberry = 5,
		Kiwi = 6,
		Plum = 7,
		Apple = 8,
		Pear = 9,
		Peach = 10,
		Banana = 11,
		Pineapple = 12,
		Watermelon = 13,
		Pumpkin = 14
	}

	public BerryPickerState berryPickerState = BerryPickerState.RandomFromBuddies;

	[Header("Screen UI")]
	[SerializeField]
	private Image screenImage;

	[SerializeField]
	private Sprite[] berrySprites;

	[SerializeField]
	private GameObject screenStateUI_Off;

	[SerializeField]
	private GameObject screenStateUI_Random;

	[SerializeField]
	private GameObject screenStateUI_RandomFromBuddies;

	[Header("Random - UI")]
	[SerializeField]
	private Image[] random_BerryImages;

	[Header("Random From Current - UI")]
	[SerializeField]
	private Image[] randomFromCurr_BerryImages;

	private void Start()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnRoundStart_Action = (Action)Delegate.Combine(singleton.OnRoundStart_Action, new Action(OnRoundStart));
		GameManager singleton2 = GameManager.Singleton;
		singleton2.OnBerryBuddyUpgraded_Action = (Action)Delegate.Combine(singleton2.OnBerryBuddyUpgraded_Action, new Action(OnBerryBuddyUpgraded));
	}

	private void OnDestroy()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnRoundStart_Action = (Action)Delegate.Remove(singleton.OnRoundStart_Action, new Action(OnRoundStart));
		GameManager singleton2 = GameManager.Singleton;
		singleton2.OnBerryBuddyUpgraded_Action = (Action)Delegate.Remove(singleton2.OnBerryBuddyUpgraded_Action, new Action(OnBerryBuddyUpgraded));
	}

	private void OnRoundStart()
	{
		UpdateBerryPickerScreen();
		EnableOrDisableProductionState();
	}

	public void Button_Up()
	{
		BerryPickerState berryPickerState = this.berryPickerState;
		int num = (int)this.berryPickerState;
		if (num < Enum.GetValues(typeof(BerryPickerState)).Length)
		{
			BerryPickerState berryPickerState2 = (BerryPickerState)(num + 1);
			if (berryPickerState2 > BerryPickerState.RandomFromBuddies)
			{
				int num2 = (int)(berryPickerState2 - 3);
				if (num2 < PlayerStats.Singleton.highestBerryTierGrown)
				{
					berryPickerState = (BerryPickerState)(num2 + 3);
				}
			}
			else
			{
				berryPickerState = berryPickerState2;
			}
		}
		this.berryPickerState = berryPickerState;
		EnableOrDisableProductionState();
		UpdateBerryPickerScreen();
		AudioManager.Singleton.PlaySFX_MouseClick();
	}

	public void Button_Down()
	{
		BerryPickerState berryPickerState = this.berryPickerState;
		int num = (int)this.berryPickerState;
		if (num > 0)
		{
			berryPickerState = (BerryPickerState)(num - 1);
		}
		this.berryPickerState = berryPickerState;
		EnableOrDisableProductionState();
		UpdateBerryPickerScreen();
		AudioManager.Singleton.PlaySFX_MouseClick();
	}

	public void UpdateBerryPickerScreen()
	{
		HideAllScreenUI();
		if (berryPickerState == BerryPickerState.Off)
		{
			screenStateUI_Off.SetActive(value: true);
		}
		else if (berryPickerState == BerryPickerState.Random)
		{
			screenStateUI_Random.SetActive(value: true);
			SetRandomBerryImages();
		}
		else if (berryPickerState == BerryPickerState.RandomFromBuddies)
		{
			screenStateUI_RandomFromBuddies.SetActive(value: true);
			SetRandomFromCurrentBerryImages();
		}
		else if (berryPickerState > BerryPickerState.RandomFromBuddies)
		{
			screenImage.gameObject.SetActive(value: true);
			screenImage.sprite = berrySprites[(int)(berryPickerState - 3)];
		}
	}

	private void HideAllScreenUI()
	{
		screenImage.gameObject.SetActive(value: false);
		screenStateUI_Off.SetActive(value: false);
		screenStateUI_Random.SetActive(value: false);
		screenStateUI_RandomFromBuddies.SetActive(value: false);
	}

	public void EnableOrDisableProductionState()
	{
		if (berryPickerState == BerryPickerState.Off)
		{
			GameManager.Singleton.prefabBank.plantBed_SpawnedInScene.HaltBerryProduction();
		}
		else if (GameManager.Singleton.prefabBank.plantBed_SpawnedInScene.GetIsProductionHalted())
		{
			GameManager.Singleton.prefabBank.plantBed_SpawnedInScene.EnableBerryProduction();
		}
	}

	public void SetRandomBerryImages()
	{
		if (berryPickerState != BerryPickerState.Random)
		{
			return;
		}
		for (int i = 0; i < random_BerryImages.Length; i++)
		{
			if (i <= PlayerStats.Singleton.highestBerryTierGrown)
			{
				random_BerryImages[i].gameObject.SetActive(value: true);
			}
			else
			{
				random_BerryImages[i].gameObject.SetActive(value: false);
			}
		}
	}

	public void SetRandomFromCurrentBerryImages()
	{
		if (berryPickerState != BerryPickerState.RandomFromBuddies)
		{
			return;
		}
		List<int> list = new List<int>();
		for (int i = 0; i < 12; i++)
		{
			list.Add(0);
		}
		foreach (BerryCultist_AI spawnedCultist in GameManager.Singleton.spawnedCultists)
		{
			if (spawnedCultist.GetBerryTier() <= 11)
			{
				list[spawnedCultist.GetBerryTier()]++;
			}
		}
		for (int j = 0; j < randomFromCurr_BerryImages.Length; j++)
		{
			if (list[j] > 0)
			{
				randomFromCurr_BerryImages[j].color = Color.white;
			}
			else
			{
				randomFromCurr_BerryImages[j].color = Color.black;
			}
		}
	}

	private void OnBerryBuddyUpgraded()
	{
	}

	private IEnumerator WaitASecThenUpdateBerryBuddyImages()
	{
		yield return null;
		yield return null;
		yield return null;
		SetRandomBerryImages();
		SetRandomFromCurrentBerryImages();
	}
}
