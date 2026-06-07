using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JournalPlantSkinUI : MonoBehaviour
{
	[SerializeField]
	private Image plantImage;

	[SerializeField]
	private Image newNotifyer;

	[SerializeField]
	private Button buySkinButton;

	[SerializeField]
	private TextMeshProUGUI priceText;

	[SerializeField]
	private Image priceImage;

	[SerializeField]
	private Image plantImageBW;

	public string GUID;

	private int price;

	private bool isUnlocked;

	private ObjectSO _objectSo;

	[SerializeField]
	private Transform outline;

	public Action<JournalPlantSkinUI> OnClickAction;

	private void Start()
	{
		buySkinButton.onClick.AddListener(OnBuySkinClick);
	}

	private void OnDestroy()
	{
		buySkinButton.onClick.RemoveListener(OnBuySkinClick);
	}

	private void OnBuySkinClick()
	{
		OnClickAction?.Invoke(this);
	}

	public void UpdateVisual(Sprite sprite, Sprite spriteBW, bool newInCollection, int variantPrice, string guid, ObjectSO objectSo)
	{
		plantImage.sprite = sprite;
		plantImage.gameObject.SetActive(value: false);
		newNotifyer.gameObject.SetActive(newInCollection);
		priceText.text = variantPrice + " <sprite index=35>";
		GUID = guid;
		price = variantPrice;
		_objectSo = objectSo;
		isUnlocked = false;
		if (plantImageBW != null)
		{
			plantImageBW.sprite = spriteBW;
		}
	}

	public Sprite GetSprite()
	{
		if (isUnlocked)
		{
			return plantImage.sprite;
		}
		return plantImageBW.sprite;
	}

	public void HideBuyButton()
	{
		priceImage.gameObject.SetActive(value: false);
	}

	public void ShowPlantImage()
	{
		if (plantImageBW != null)
		{
			isUnlocked = true;
			plantImageBW.gameObject.SetActive(value: false);
			plantImage.gameObject.SetActive(value: true);
		}
	}

	public void ToggleOutline(bool value)
	{
		outline.gameObject.SetActive(value);
	}

	public bool PriceActive()
	{
		return priceImage.IsActive();
	}

	public int GetPrice()
	{
		return price;
	}

	public string GetGuid()
	{
		return GUID;
	}

	public ObjectSO GetObjectSO()
	{
		return _objectSo;
	}
}
