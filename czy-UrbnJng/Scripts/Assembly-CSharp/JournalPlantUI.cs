using System;
using System.Collections.Generic;
using Infrastructure.Services;
using Infrastructure.Services.CoinService;
using Infrastructure.Services.PersistentProgress;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JournalPlantUI : MonoBehaviour
{
	[SerializeField]
	private ObjectSO objectSO;

	[SerializeField]
	private GameObject sunlightText;

	[SerializeField]
	private GameObject noSunlightText;

	[SerializeField]
	private GameObject humidityText;

	[SerializeField]
	private GameObject noHumidityText;

	[SerializeField]
	private GameObject sunlightIcon;

	[SerializeField]
	private GameObject noSunlightIcon;

	[SerializeField]
	private GameObject humidityIcon;

	[SerializeField]
	private GameObject noHumidityIcon;

	[SerializeField]
	private TextMeshProUGUI tip;

	[SerializeField]
	private TextMeshProUGUI unlockedSkinsQuantity;

	[SerializeField]
	private TextMeshProUGUI maxSkinsQuantity;

	[SerializeField]
	private List<JournalPlantSkinUI> skinsPerPlantList;

	[SerializeField]
	public Button buyButton;

	[SerializeField]
	private TextMeshProUGUI priceText;

	[SerializeField]
	private Image plantImage;

	[SerializeField]
	private TextMeshProUGUI plantName;

	private JournalPlantSkinUI selectedJournalPlantSkin;

	private int selectedSkinNumber;

	private const int SpecialIndex = -100;

	private const int InitialSelectedSkin = 100;

	private List<string> collectedSkins = new List<string>();

	private void Start()
	{
		CollectionManager instance = CollectionManager.Instance;
		instance.OnLoadCollection = (Action)Delegate.Combine(instance.OnLoadCollection, new Action(LoadCollectedSkins));
		buyButton.onClick.AddListener(BuySkin);
		foreach (JournalPlantSkinUI skinsPerPlant in skinsPerPlantList)
		{
			skinsPerPlant.OnClickAction = (Action<JournalPlantSkinUI>)Delegate.Combine(skinsPerPlant.OnClickAction, new Action<JournalPlantSkinUI>(SkinSelected));
		}
		selectedSkinNumber = 100;
		maxSkinsQuantity.text = "/" + skinsPerPlantList.Count;
		UpdateVisual();
	}

	public void BuySkin()
	{
		if (buyButton.isActiveAndEnabled)
		{
			if (AllServices.Container.Single<IPersistentProgressService>().Progress.Coins >= selectedJournalPlantSkin.GetPrice())
			{
				AllServices.Container.Single<ICoinService>().SubtractCoin(selectedJournalPlantSkin.GetPrice());
				buyButton.gameObject.SetActive(value: false);
				CollectionManager.Instance.NewSkinPurchased(selectedJournalPlantSkin.GetGuid(), selectedJournalPlantSkin.GetObjectSO());
				Debug.Log("You purchased skin!");
			}
			else
			{
				Debug.Log("You don't have enough flowers");
			}
			UpdateVisual();
		}
	}

	private void OnDestroy()
	{
		CollectionManager instance = CollectionManager.Instance;
		instance.OnLoadCollection = (Action)Delegate.Remove(instance.OnLoadCollection, new Action(LoadCollectedSkins));
		buyButton.onClick.RemoveListener(BuySkin);
		foreach (JournalPlantSkinUI skinsPerPlant in skinsPerPlantList)
		{
			skinsPerPlant.OnClickAction = (Action<JournalPlantSkinUI>)Delegate.Remove(skinsPerPlant.OnClickAction, new Action<JournalPlantSkinUI>(SkinSelected));
		}
	}

	private void OnDisable()
	{
		selectedSkinNumber = 100;
		DeactivateChoose();
	}

	public void DeactivateChoose()
	{
		foreach (JournalPlantSkinUI skinsPerPlant in skinsPerPlantList)
		{
			skinsPerPlant.ToggleOutline(value: false);
		}
		buyButton.gameObject.SetActive(value: false);
	}

	public bool ChooseSkin(int nextIndex)
	{
		int num = selectedSkinNumber;
		if (nextIndex == -100)
		{
			selectedSkinNumber = skinsPerPlantList.Count - 1;
			SkinSelected(skinsPerPlantList[selectedSkinNumber]);
			return true;
		}
		num = ((num == 100) ? ((nextIndex == -1) ? (skinsPerPlantList.Count - 1) : 0) : (num + nextIndex));
		if (num < 0 || num > skinsPerPlantList.Count - 1)
		{
			return false;
		}
		SkinSelected(skinsPerPlantList[num]);
		selectedSkinNumber = num;
		return true;
	}

	private void SkinSelected(JournalPlantSkinUI journalPlantSkinUI)
	{
		foreach (JournalPlantSkinUI skinsPerPlant in skinsPerPlantList)
		{
			skinsPerPlant.ToggleOutline(value: false);
		}
		journalPlantSkinUI.ToggleOutline(value: true);
		buyButton.gameObject.SetActive(value: false);
		selectedJournalPlantSkin = journalPlantSkinUI;
		for (int i = 0; i < skinsPerPlantList.Count; i++)
		{
			if (skinsPerPlantList[i] == journalPlantSkinUI)
			{
				selectedSkinNumber = i;
			}
		}
		if (journalPlantSkinUI.PriceActive())
		{
			priceText.text = journalPlantSkinUI.GetPrice().ToString();
			buyButton.gameObject.SetActive(value: true);
		}
		plantImage.sprite = journalPlantSkinUI.GetSprite();
	}

	private void LoadCollectedSkins()
	{
		foreach (KeyValuePair<string, string> collectedPlants in CollectionManager.Instance.GetCollectedPlantsList())
		{
			collectedSkins.Add(collectedPlants.Key);
		}
	}

	public void UpdateVisual()
	{
		if (objectSO.sunlight == EnvironmentSunlight.Sunlight.Low)
		{
			SunlightNeedDescription(value: false);
		}
		else
		{
			SunlightNeedDescription(value: true);
		}
		if (objectSO.humidity == EnvironmentHumidity.Humidity.Low)
		{
			HumidityNeedDescription(value: false);
		}
		else
		{
			HumidityNeedDescription(value: true);
		}
		UpdateSkins();
	}

	private void SunlightNeedDescription(bool value)
	{
		if (value)
		{
			sunlightText.SetActive(value: true);
			sunlightIcon.SetActive(value: true);
			noSunlightText.SetActive(value: false);
			noSunlightIcon.SetActive(value: false);
		}
		else
		{
			sunlightText.SetActive(value: false);
			sunlightIcon.SetActive(value: false);
			noSunlightText.SetActive(value: true);
			noSunlightIcon.SetActive(value: true);
		}
	}

	private void HumidityNeedDescription(bool value)
	{
		if (value)
		{
			humidityText.SetActive(value: true);
			humidityIcon.SetActive(value: true);
			noHumidityText.SetActive(value: false);
			noHumidityIcon.SetActive(value: false);
		}
		else
		{
			humidityText.SetActive(value: false);
			humidityIcon.SetActive(value: false);
			noHumidityText.SetActive(value: true);
			noHumidityIcon.SetActive(value: true);
		}
	}

	public void UpdateSkins()
	{
		Dictionary<string, string> collectedPlantsList = CollectionManager.Instance.GetCollectedPlantsList();
		int num = 0;
		foreach (Variant variants in objectSO.variantsList)
		{
			if (num < skinsPerPlantList.Count)
			{
				skinsPerPlantList[num].UpdateVisual(variants.variantSprite, variants.variantSpriteBW, newInCollection: false, variants.price, variants.GUID, objectSO);
			}
			num++;
		}
		if (num == 0)
		{
			skinsPerPlantList[0].UpdateVisual(objectSO.sprite, objectSO.sprite, newInCollection: false, objectSO.price, objectSO.GUID, objectSO);
		}
		num = 0;
		foreach (KeyValuePair<string, string> item in collectedPlantsList)
		{
			foreach (JournalPlantSkinUI skinsPerPlant in skinsPerPlantList)
			{
				skinsPerPlant.HideBuyButton();
				if (item.Key == skinsPerPlant.GUID && item.Value == objectSO.GUID)
				{
					skinsPerPlant.ShowPlantImage();
					num++;
				}
			}
		}
		plantImage.sprite = skinsPerPlantList[0].GetSprite();
		unlockedSkinsQuantity.text = num.ToString();
		tip.text = CollectionManager.Instance.GetPlantTipLocalize(objectSO.objectName);
	}

	private Sprite GetSprite(string GUID)
	{
		Sprite result = null;
		if (objectSO.variantsList.Count > 0)
		{
			foreach (Variant variants in objectSO.variantsList)
			{
				if (GUID == variants.GUID)
				{
					result = variants.variantSprite;
					break;
				}
			}
		}
		else
		{
			result = objectSO.journalSprite;
		}
		return result;
	}

	public ObjectSO GetObjectSO()
	{
		return objectSO;
	}

	public string GetTip()
	{
		return tip.text;
	}

	public string GetPlantName()
	{
		return plantName.text;
	}

	public List<JournalPlantSkinUI> GetSkins()
	{
		return skinsPerPlantList;
	}

	public List<string> GetCollectedSkins()
	{
		return collectedSkins;
	}
}
