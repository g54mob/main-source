using DG.Tweening;
using UnityEngine;

public class SidePanelManager : MonoBehaviour
{
	private bool panelOpen;

	private float horizontalOpenPos = -234f;

	private float horizontalClosedPos = 230f;

	private float verticalOpenPos = 148f;

	private float verticalClosedPos = -144f;

	private RectTransform rectTrans;

	private Vector2 vAnchorMin = new Vector2(0.5f, 0f);

	private Vector2 vAnchorMax = new Vector2(0.5f, 0f);

	private Vector2 hAnchorMin = new Vector2(1f, 0f);

	private Vector2 hAnchorMax = new Vector2(1f, 0f);

	[Header("Panels")]
	public GameObject seedsPanel;

	public GameObject animalPanel;

	public GameObject beePanel;

	public GameObject buildPanel;

	public GameObject upgradesPanel;

	public GameObject shopPanel;

	public GameObject priorityPanel;

	public GameObject statsPanel;

	public GameObject settingsPanel;

	public GameObject helpPanel;

	public GameObject creditsPanel;

	[Header("Setting Panels")]
	public SettingsPanel childSettingsPanel;

	[Header("Convert Biofuel")]
	public GameObject convertBiofuelPanel;

	[Header("Sounds")]
	[SerializeField]
	private AudioClip openPanelAudio;

	[SerializeField]
	private AudioClip changePanelAudio;

	[SerializeField]
	private AudioClip closePanelAudio;

	private void Start()
	{
		rectTrans = GetComponent<RectTransform>();
		panelOpen = true;
		if (SaveData.ins.verticalMode)
		{
			rectTrans.anchorMin = vAnchorMin;
			rectTrans.anchorMax = vAnchorMax;
			rectTrans.anchoredPosition = new Vector2(0f, verticalOpenPos);
			rectTrans.sizeDelta = new Vector2(532f, 296f);
		}
		OpenSeedsPanel();
	}

	private void Update()
	{
		if (!GameManager.ins.canUseLetterShortcuts)
		{
			return;
		}
		if (SaveData.ins.verticalMode)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				OpenSeedsPanel();
			}
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				OpenBuildPanel();
			}
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				OpenUpgradesPanel();
			}
			if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				OpenShopPanel();
			}
			if (Input.GetKeyDown(KeyCode.Alpha5))
			{
				OpenBeePanel();
			}
			if (Input.GetKeyDown(KeyCode.Alpha6))
			{
				OpenAnimalPanel();
			}
			if (Input.GetKeyDown(KeyCode.Alpha7))
			{
				OpenStatsPanel();
			}
			if (Input.GetKeyDown(KeyCode.Alpha8))
			{
				OpenPriorityPanel();
			}
			if (Input.GetKeyDown(KeyCode.Alpha9))
			{
				OpenSettingsPanel();
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				OpenSeedsPanel();
			}
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				OpenBuildPanel();
			}
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				OpenUpgradesPanel();
			}
			if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				OpenShopPanel();
			}
			if (Input.GetKeyDown(KeyCode.Alpha5))
			{
				OpenSettingsPanel();
			}
			if (Input.GetKeyDown(KeyCode.Alpha6))
			{
				OpenBeePanel();
			}
			if (Input.GetKeyDown(KeyCode.Alpha7))
			{
				OpenAnimalPanel();
			}
			if (Input.GetKeyDown(KeyCode.Alpha8))
			{
				OpenStatsPanel();
			}
			if (Input.GetKeyDown(KeyCode.Alpha9))
			{
				OpenPriorityPanel();
			}
		}
	}

	public void OpenShopPanel()
	{
		PlayChangeSound();
		CheckIfWindowIsOpen();
		CloseAllOtherPanels(shopPanel);
		shopPanel.SetActive(value: true);
		convertBiofuelPanel.SetActive(value: true);
		Inventory.ins.CheckForUnlockedSigns();
	}

	public void OpenSeedsPanel()
	{
		PlayChangeSound();
		CheckIfWindowIsOpen();
		CloseAllOtherPanels(seedsPanel);
		seedsPanel.SetActive(value: true);
		convertBiofuelPanel.SetActive(value: true);
	}

	public void OpenSettingsPanel()
	{
		PlayChangeSound();
		CheckIfWindowIsOpen();
		CloseAllOtherPanels(settingsPanel);
		settingsPanel.SetActive(value: true);
		childSettingsPanel.OpenMainPanel();
	}

	public void OpenSettingsSavefilePanel()
	{
		PlayChangeSound();
		CheckIfWindowIsOpen();
		CloseAllOtherPanels(settingsPanel);
		settingsPanel.SetActive(value: true);
	}

	public void OpenBuildPanel()
	{
		PlayChangeSound();
		CheckIfWindowIsOpen();
		CloseAllOtherPanels(buildPanel);
		buildPanel.SetActive(value: true);
		convertBiofuelPanel.SetActive(value: true);
	}

	public void OpenAnimalPanel()
	{
		PlayChangeSound();
		CheckIfWindowIsOpen();
		CloseAllOtherPanels(animalPanel);
		animalPanel.SetActive(value: true);
		convertBiofuelPanel.SetActive(value: true);
	}

	public void OpenBeePanel()
	{
		PlayChangeSound();
		CheckIfWindowIsOpen();
		CloseAllOtherPanels(beePanel);
		beePanel.SetActive(value: true);
		convertBiofuelPanel.SetActive(value: true);
	}

	public void OpenPriorityPanel()
	{
		PlayChangeSound();
		CheckIfWindowIsOpen();
		CloseAllOtherPanels(priorityPanel);
		priorityPanel.SetActive(value: true);
	}

	public void OpenStatsPanel()
	{
		PlayChangeSound();
		CheckIfWindowIsOpen();
		CloseAllOtherPanels(statsPanel);
		statsPanel.SetActive(value: true);
	}

	public void OpenUpgradesPanel()
	{
		PlayChangeSound();
		CheckIfWindowIsOpen();
		CloseAllOtherPanels(upgradesPanel);
		upgradesPanel.SetActive(value: true);
		convertBiofuelPanel.SetActive(value: true);
		if (GameManager.ins.canUpgradeBuildings)
		{
			GameManager.ins.state = GameManager.State.CanUpgrade;
		}
	}

	public void OpenHelpPanel()
	{
		PlayChangeSound();
		CheckIfWindowIsOpen();
		CloseAllOtherPanels(helpPanel);
		helpPanel.SetActive(value: true);
	}

	public void OpenCreditsPanel()
	{
		PlayChangeSound();
		CheckIfWindowIsOpen();
		CloseAllOtherPanels(helpPanel);
		creditsPanel.SetActive(value: true);
	}

	private void CloseAllOtherPanels(GameObject leaveThisPanelOpen)
	{
		GameManager.ins.SetStateToIdle();
		BuildInfoPanel.ins.SetBlank();
		CropInfoPanel.ins.SetBlank();
		if (shopPanel != leaveThisPanelOpen)
		{
			shopPanel.SetActive(value: false);
		}
		if (seedsPanel != leaveThisPanelOpen)
		{
			seedsPanel.SetActive(value: false);
		}
		if (settingsPanel != leaveThisPanelOpen)
		{
			settingsPanel.SetActive(value: false);
		}
		if (buildPanel != leaveThisPanelOpen)
		{
			buildPanel.SetActive(value: false);
		}
		if (animalPanel != leaveThisPanelOpen)
		{
			animalPanel.SetActive(value: false);
		}
		if (beePanel != leaveThisPanelOpen)
		{
			beePanel.SetActive(value: false);
		}
		if (priorityPanel != leaveThisPanelOpen)
		{
			priorityPanel.SetActive(value: false);
		}
		if (statsPanel != leaveThisPanelOpen)
		{
			statsPanel.SetActive(value: false);
		}
		if (upgradesPanel != leaveThisPanelOpen)
		{
			upgradesPanel.SetActive(value: false);
		}
		if (helpPanel != leaveThisPanelOpen)
		{
			helpPanel.SetActive(value: false);
		}
		if (creditsPanel != leaveThisPanelOpen)
		{
			creditsPanel.SetActive(value: false);
		}
		convertBiofuelPanel.SetActive(value: false);
		if ((bool)UpgradePanel.ins && upgradesPanel != leaveThisPanelOpen)
		{
			UpgradePanel.ins.HideUpgradePanel();
		}
	}

	private void CheckIfWindowIsOpen()
	{
		if (!panelOpen)
		{
			if (SaveData.ins.verticalMode)
			{
				rectTrans.DOAnchorPosY(verticalOpenPos, 0.25f).SetEase(Ease.OutQuart);
			}
			else
			{
				rectTrans.DOAnchorPosX(horizontalOpenPos, 0.25f).SetEase(Ease.OutQuart);
			}
			panelOpen = true;
			SoundManager.ins.PlaySound(openPanelAudio);
		}
	}

	private void PlayChangeSound()
	{
		if (panelOpen)
		{
			SoundManager.ins.PlaySound(changePanelAudio);
		}
	}

	public void CloseEntireWindow()
	{
		if (!panelOpen)
		{
			CheckIfWindowIsOpen();
			return;
		}
		if (SaveData.ins.verticalMode)
		{
			rectTrans.DOAnchorPosY(verticalClosedPos, 0.25f).SetEase(Ease.OutQuart);
		}
		else
		{
			rectTrans.DOAnchorPosX(horizontalClosedPos, 0.25f).SetEase(Ease.OutQuart);
		}
		panelOpen = false;
		SoundManager.ins.PlaySound(closePanelAudio);
	}
}
