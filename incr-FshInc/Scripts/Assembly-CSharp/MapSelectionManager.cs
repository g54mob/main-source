using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapSelectionManager : MonoBehaviour
{
	[Header("Carousel Setup")]
	public Transform zoneContainer;

	public GameObject zoneButtonPrefab;

	public List<ZoneData> allZonesData;

	[Header("Navigation Buttons")]
	public Button leftArrowBtn;

	public Button rightArrowBtn;

	[Header("Details Panel")]
	public GameObject detailsPanel;

	public TMP_Text zoneNameText;

	public TMP_Text zoneStatsText;

	public TMP_Text passiveIncomeText;

	public Image zoneIconImage;

	public Button actionButton;

	public TMP_Text actionButtonText;

	[Header("Fish List")]
	public Transform fishListContainer;

	public GameObject fishEntryPrefab;

	private List<ZoneButtonAnimator> spawnedZones = new List<ZoneButtonAnimator>();

	private int currentZoneIndex;

	private ZoneData selectedZoneData;

	private void Start()
	{
		SpawnMapZones();
		leftArrowBtn.onClick.AddListener(PrevZone);
		rightArrowBtn.onClick.AddListener(NextZone);
		currentZoneIndex = GetHighestUnlockedIndex();
		SelectZoneByIndex(currentZoneIndex);
	}

	private void SpawnMapZones()
	{
		foreach (Transform item in zoneContainer)
		{
			Object.Destroy(item.gameObject);
		}
		spawnedZones.Clear();
		for (int i = 0; i < allZonesData.Count; i++)
		{
			ZoneData zoneData = allZonesData[i];
			GameObject gameObject = Object.Instantiate(zoneButtonPrefab, zoneContainer);
			gameObject.GetComponent<RectTransform>();
			ZoneButtonAnimator component = gameObject.GetComponent<ZoneButtonAnimator>();
			if (!(component != null))
			{
				continue;
			}
			component.zoneData = zoneData;
			if ((bool)component.zoneNameText)
			{
				component.zoneNameText.text = (zoneData.isUnlocked ? zoneData.zoneName : "????");
			}
			if ((bool)component.iconImage)
			{
				component.iconImage.sprite = zoneData.zoneIcon;
			}
			component.InitializeLock(zoneData.isUnlocked);
			if ((bool)component.priceText)
			{
				bool flag = !zoneData.isUnlocked;
				component.priceText.gameObject.SetActive(flag);
				if (flag)
				{
					component.priceText.text = $"{zoneData.unlockCost} G";
				}
			}
			int index = i;
			Button component2 = gameObject.GetComponent<Button>();
			if ((bool)component2)
			{
				component2.onClick.AddListener(delegate
				{
					GoToZoneIndex(index);
				});
			}
			spawnedZones.Add(component);
		}
	}

	public void NextZone()
	{
		if (currentZoneIndex < spawnedZones.Count - 1)
		{
			currentZoneIndex++;
			SelectZoneByIndex(currentZoneIndex);
		}
	}

	public void PrevZone()
	{
		if (currentZoneIndex > 0)
		{
			currentZoneIndex--;
			SelectZoneByIndex(currentZoneIndex);
		}
	}

	public void GoToZoneIndex(int index)
	{
		currentZoneIndex = index;
		SelectZoneByIndex(currentZoneIndex);
	}

	private void SelectZoneByIndex(int index)
	{
		leftArrowBtn.interactable = currentZoneIndex > 0;
		rightArrowBtn.interactable = currentZoneIndex < spawnedZones.Count - 1;
		for (int i = 0; i < spawnedZones.Count; i++)
		{
			bool selected = i == index;
			spawnedZones[i].SetSelected(selected);
		}
		selectedZoneData = spawnedZones[index].zoneData;
		RefreshUIPanel();
	}

	public void RefreshUIPanel()
	{
		if (selectedZoneData == null)
		{
			return;
		}
		if ((bool)detailsPanel)
		{
			detailsPanel.SetActive(value: true);
		}
		if ((bool)zoneNameText)
		{
			zoneNameText.text = selectedZoneData.zoneName;
		}
		if ((bool)zoneIconImage)
		{
			zoneIconImage.sprite = selectedZoneData.zoneIcon;
		}
		actionButton.onClick.RemoveAllListeners();
		if (selectedZoneData.isUnlocked)
		{
			if ((bool)zoneStatsText)
			{
				zoneStatsText.text = $"Level: {selectedZoneData.currentLevel}";
			}
			if ((bool)passiveIncomeText)
			{
				float currentPassiveIncome = selectedZoneData.GetCurrentPassiveIncome();
				string text = ((currentPassiveIncome >= 1000f) ? CurrencyFormatter.FormatMoney(currentPassiveIncome) : currentPassiveIncome.ToString("G2"));
				passiveIncomeText.text = "Passive: " + text + "/s";
			}
			if ((bool)actionButtonText)
			{
				actionButtonText.text = "Travel";
			}
			actionButton.interactable = true;
			actionButton.onClick.AddListener(delegate
			{
				Debug.Log("Travel logic here");
			});
		}
		else
		{
			if ((bool)zoneStatsText)
			{
				zoneStatsText.text = $"Cost: {selectedZoneData.unlockCost} G";
			}
			if ((bool)passiveIncomeText)
			{
				passiveIncomeText.text = "Passive: ???";
			}
			if ((bool)actionButtonText)
			{
				actionButtonText.text = "Unlock";
			}
			actionButton.interactable = true;
			actionButton.onClick.AddListener(delegate
			{
				UnlockCurrent();
			});
		}
		if (!fishListContainer || !fishEntryPrefab)
		{
			return;
		}
		foreach (Transform item in fishListContainer)
		{
			Object.Destroy(item.gameObject);
		}
	}

	private void UnlockCurrent()
	{
		selectedZoneData.isUnlocked = true;
		spawnedZones[currentZoneIndex].UnlockZone();
		RefreshUIPanel();
	}

	private int GetHighestUnlockedIndex()
	{
		for (int num = allZonesData.Count - 1; num >= 0; num--)
		{
			if (allZonesData[num].isUnlocked)
			{
				return num;
			}
		}
		return 0;
	}
}
