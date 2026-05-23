using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class PerkUI : MonoBehaviour
{
	private LocalizedString perkPointString = new LocalizedString("MyTable", "perkpoint");

	private LocalizedString selectString = new LocalizedString("MyTable", "crafting-select");

	private LocalizedString activeString = new LocalizedString("MyTable", "active");

	private LocalizedString lockedString = new LocalizedString("MyTable", "crafting-locked");

	[SerializeField]
	private Perk initPerk;

	private Perk selectedPerk;

	private Perk prevPerk;

	private int perkIndex;

	[SerializeField]
	private TextMeshProUGUI perkTitle;

	[SerializeField]
	private TextMeshProUGUI descriptionText;

	[SerializeField]
	private Image descriptionImage;

	[SerializeField]
	private Color selectedColor;

	[SerializeField]
	private TextMeshProUGUI selectBtnText;

	[SerializeField]
	private TextMeshProUGUI perkPointText;

	public List<Perk> rocketPerks;

	public List<Perk> cookingPerks;

	public List<Perk> intelPerks;

	private bool canOpen;

	private bool canUnlock = true;

	private bool firstLoad = true;

	public static event Action OnPerkUnlocked;

	private void Start()
	{
		GameManager.S.OnPlayerPressTab += Gm_OnPlayerPressTab;
		BusStopUI.OnFadeInDone += BusStopUI_OnFadeInDone;
		LoadPerks();
		PerkChoiced(initPerk);
		perkPointText.text = $"{perkPointString.GetLocalizedString()} : {GameManager.S.perkPoint}";
		OffUI();
	}

	private void OnDestroy()
	{
		GameManager.S.OnPlayerPressTab -= Gm_OnPlayerPressTab;
		BusStopUI.OnFadeInDone -= BusStopUI_OnFadeInDone;
	}

	private void BusStopUI_OnFadeInDone()
	{
		canOpen = true;
	}

	private void LoadPerks()
	{
		int num = 0;
		foreach (bool rocketPerk in GameManager.S.rocketPerkList)
		{
			if (rocketPerk)
			{
				rocketPerks[num].isUnlocked = true;
				rocketPerks[num].bg.color = selectedColor;
			}
			num++;
		}
		num = 0;
		foreach (bool cookingPerk in GameManager.S.cookingPerkList)
		{
			if (cookingPerk)
			{
				cookingPerks[num].isUnlocked = true;
				cookingPerks[num].bg.color = selectedColor;
			}
			num++;
		}
		num = 0;
		foreach (bool intelPerk in GameManager.S.intelPerkList)
		{
			if (intelPerk)
			{
				intelPerks[num].isUnlocked = true;
				intelPerks[num].bg.color = selectedColor;
			}
			num++;
		}
	}

	private void Gm_OnPlayerPressTab(object sender, EventArgs e)
	{
		if (!canOpen)
		{
			return;
		}
		if (GameManager.S.player.canControl && !FirstPersonController.S.rcControl)
		{
			if (!base.gameObject.activeSelf)
			{
				OnUI();
				PerkChoiced(initPerk);
				Cursor.visible = true;
				GameManager.S.player.canControl = false;
				AudioManager.S.PlaySFX(AudioManager.S.memoCheck);
			}
		}
		else if (base.gameObject.activeSelf)
		{
			Exit();
		}
	}

	private void Update()
	{
	}

	public void PerkChoiced(Perk perk)
	{
		if (selectedPerk != null)
		{
			selectedPerk.selectedImage.SetActive(value: false);
		}
		selectedPerk = perk;
		perkTitle.text = perk.perkName.GetLocalizedString();
		descriptionImage.sprite = perk.perkImage;
		descriptionText.text = perk.perkDescription.GetLocalizedString();
		selectedPerk.selectedImage.SetActive(value: true);
		Perk perk2 = null;
		prevPerk = null;
		int num = 0;
		perkIndex = 0;
		foreach (Perk rocketPerk in rocketPerks)
		{
			if (selectedPerk == rocketPerk)
			{
				if (perk2 != null)
				{
					prevPerk = perk2;
				}
				perkIndex = num;
			}
			perk2 = rocketPerk;
			num++;
		}
		perk2 = null;
		if (prevPerk == null)
		{
			foreach (Perk cookingPerk in cookingPerks)
			{
				if (selectedPerk == cookingPerk)
				{
					if (perk2 != null)
					{
						prevPerk = perk2;
					}
					perkIndex = num;
				}
				num++;
				perk2 = cookingPerk;
			}
		}
		perk2 = null;
		if (prevPerk == null)
		{
			foreach (Perk intelPerk in intelPerks)
			{
				if (selectedPerk == intelPerk)
				{
					if (perk2 != null)
					{
						prevPerk = perk2;
					}
					perkIndex = num;
				}
				num++;
				perk2 = intelPerk;
			}
		}
		if (selectedPerk.isUnlocked)
		{
			selectBtnText.text = activeString.GetLocalizedString();
		}
		else if (prevPerk != null)
		{
			if (prevPerk.isUnlocked)
			{
				selectBtnText.text = selectString.GetLocalizedString();
				canUnlock = true;
			}
			else
			{
				selectBtnText.text = lockedString.GetLocalizedString();
				canUnlock = false;
			}
		}
		else
		{
			selectBtnText.text = selectString.GetLocalizedString();
			canUnlock = true;
		}
		if (firstLoad)
		{
			firstLoad = false;
		}
		else
		{
			AudioManager.S.PlaySFX(AudioManager.S.uiClicked);
		}
	}

	public void PerkUnlocked()
	{
		if (selectedPerk.isUnlocked)
		{
			return;
		}
		if (canUnlock)
		{
			if (GameManager.S.perkPoint > 0)
			{
				selectedPerk.isUnlocked = true;
				selectedPerk.bg.color = selectedColor;
				selectBtnText.text = activeString.GetLocalizedString();
				GameManager.S.perkPoint--;
				perkPointText.text = $"{perkPointString.GetLocalizedString()} : {GameManager.S.perkPoint}";
				if (perkIndex < 5)
				{
					GameManager.S.rocketPerkList[perkIndex] = true;
				}
				else if (perkIndex < 10)
				{
					GameManager.S.cookingPerkList[perkIndex - 5] = true;
				}
				else
				{
					GameManager.S.intelPerkList[perkIndex - 10] = true;
				}
				PerkUI.OnPerkUnlocked?.Invoke();
				AudioManager.S.PlayDoorBell(AudioManager.S.uiToggle);
			}
			else
			{
				AudioManager.S.PlayDoorBell(AudioManager.S.notEnoughMoney);
			}
		}
		else
		{
			AudioManager.S.PlayDoorBell(AudioManager.S.notEnoughMoney);
		}
	}

	public void OnUI()
	{
		base.gameObject.SetActive(value: true);
		perkPointText.text = $"{perkPointString.GetLocalizedString()}  : {GameManager.S.perkPoint}";
	}

	public void OffUI()
	{
		base.gameObject.SetActive(value: false);
	}

	public void Exit()
	{
		OffUI();
		Cursor.visible = false;
		GameManager.S.player.canControl = true;
	}
}
