using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnhancementCard : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler
{
	private Button button;

	[SerializeField]
	private Image iconFrameImage;

	[SerializeField]
	private Image iconMaskImage;

	[SerializeField]
	private Image iconImage;

	[SerializeField]
	private TextMeshProUGUI typeText;

	[SerializeField]
	private TextMeshProUGUI nameText;

	[SerializeField]
	private TextMeshProUGUI rarityText;

	[SerializeField]
	private TextMeshProUGUI descriptionText;

	[SerializeField]
	private Material materialAssetHover;

	[SerializeField]
	private Material materialAssetRegular;

	[SerializeField]
	private Image dividerImage;

	[SerializeField]
	private Sprite dividerSpriteRegular;

	[SerializeField]
	private Sprite dividerSpriteHover;

	[SerializeField]
	public Image containerOutlineImage;

	[SerializeField]
	private GameObject shopContainer;

	[SerializeField]
	private TextMeshProUGUI costText;

	[SerializeField]
	public Button buyButton;

	[SerializeField]
	private TextMeshProUGUI buyButtonText;

	[SerializeField]
	private Image buyButtonCheckmarkImage;

	[SerializeField]
	private GameObject discountTag;

	[SerializeField]
	private int maxDiscountValue;

	[SerializeField]
	private int minDiscountValue;

	[SerializeField]
	private int incrementStep;

	[SerializeField]
	private TextMeshProUGUI discountText;

	[Header("Icon Frame and Mask Sprites")]
	[SerializeField]
	private Sprite moduleFrame;

	[SerializeField]
	private Sprite moduleMask;

	[SerializeField]
	private Sprite upgradeFrame;

	[SerializeField]
	private Sprite upgradeMask;

	[SerializeField]
	private Sprite relicFrame;

	[SerializeField]
	private Sprite relicMask;

	[SerializeField]
	private AudioClip clickClip;

	[SerializeField]
	private AudioClip buyClip;

	private AudioSource audioSource;

	private float shopCost;

	private int discountValue;

	private int cost;

	private bool discounted;

	private int indexInShop;

	[NonSerialized]
	public bool isBought;

	[field: SerializeField]
	public CargoContainer Container { get; private set; }

	[field: NonSerialized]
	public Enhancement en { get; private set; }

	public event Action Obtained;

	public static event Action<EnhancementCard> OnCardClicked;

	public void Initialize(Enhancement cardEn, int index, int cardCost = 0, bool isDiscounted = false, bool sold = false, bool isClickable = true)
	{
		en = cardEn;
		cost = cardCost;
		discounted = isDiscounted;
		indexInShop = index;
		button = GetComponent<Button>();
		audioSource = GetComponent<AudioSource>();
		AssignTypeDependencies(en);
		rarityText.text = StringFormatHelper.GetRarityString(en);
		rarityText.color = UIManager.Instance.DarkerRarityColor(en.Rarity);
		nameText.color = UIManager.Instance.DarkerRarityColor(en.Rarity);
		iconFrameImage.color = UIManager.Instance.DarkerRarityColor(en.Rarity);
		iconImage.sprite = en.Icon;
		if (MenuManager.Instance.CurrentMenu == MenuManager.Instance.GetMenu(MenuType.Choice) || MenuManager.Instance.CurrentMenu == MenuManager.Instance.GetMenu(MenuType.MysteryLocation) || MenuManager.Instance.CurrentMenu == MenuManager.Instance.GetMenu(MenuType.ReadyUp) || MenuManager.Instance.CurrentMenu == MenuManager.Instance.GetMenu(MenuType.GameOver))
		{
			containerOutlineImage.color = UIManager.Instance.RarityColor(en.Rarity);
			Container.OnContainerOpened += OnOpened;
		}
		en.NameKey.StringChanged += delegate(string value)
		{
			nameText.text = value;
		};
		en.DescriptionKey.StringChanged += delegate(string value)
		{
			descriptionText.text = value;
		};
		nameText.text = en.NameKey.GetLocalizedString();
		descriptionText.text = en.DescriptionKey.GetLocalizedString();
		if (cost > 0)
		{
			shopContainer.gameObject.SetActive(value: true);
			cost = LootManager.Instance.ApplyCostModifier(en.Cost, ShopItemType.Enhancment);
			if (discounted)
			{
				discountValue = GenerateRandomDiscountValue();
				cost = Mathf.FloorToInt(cost * (100 - discountValue) / 100);
				discountText.text = discountValue + "%";
				discountTag.gameObject.SetActive(value: true);
			}
			if ((float)cost > ResourceManager.Instance.Scrap.Value)
			{
				costText.color = ColorUtils.HexToColor("FF0800");
			}
			else
			{
				costText.color = ColorUtils.HexToColor("3BFF00");
			}
			costText.text = StringFormatHelper.ConvertToCurrency(cost);
			buyButton.onClick.RemoveAllListeners();
			buyButton.onClick.AddListener(delegate
			{
				Buy(en, cost);
			});
			button.interactable = false;
		}
		else
		{
			if (!isClickable)
			{
				return;
			}
			button.onClick.RemoveAllListeners();
			button.onClick.AddListener(delegate
			{
				Obtain(en);
			});
			shopContainer.gameObject.SetActive(value: false);
			button.interactable = true;
		}
		shopCost = cost;
		if (sold)
		{
			CleanUp();
		}
	}

	private void Buy(Enhancement en, int cost)
	{
		if (!(ResourceManager.Instance.Scrap.Value < (float)cost) && UpgradeManager.Instance.AddEnhancement(en))
		{
			ResourceManager.Instance.Scrap.TrySpend(cost);
			DataTrackingManager.Instance.AddScrapUsedUpgrades(cost);
			AudioManager.Instance.PlayClipWithMixer(buyClip, AMG.SFX);
			ShopWindow.Instance.CheckForScrap();
			CleanUp();
			SaveManager.Instance.AddShopEnhancementPurchase(indexInShop, en);
			isBought = true;
			Container.Anim.Play("ShopCargoClose");
			EnhancementCard.OnCardClicked?.Invoke(this);
		}
	}

	private void Obtain(Enhancement en)
	{
		if (UpgradeManager.Instance.AddEnhancement(en))
		{
			this.Obtained?.Invoke();
			EnhancementCard.OnCardClicked?.Invoke(this);
			AudioManager.Instance.PlayClipWithMixer(clickClip, AMG.SFX);
			CleanUp();
			SaveManager.Instance.SaveJourney();
		}
	}

	private void CleanUp()
	{
		isBought = true;
		button.onClick.RemoveAllListeners();
		buyButton.onClick.RemoveAllListeners();
		Container.OnContainerOpened -= OnOpened;
		buyButton.interactable = false;
		buyButtonText.enabled = false;
		buyButtonCheckmarkImage.enabled = true;
		costText.text = "Sold";
		this.Obtained = null;
	}

	private void AssignTypeDependencies(Enhancement en)
	{
		if (!(en is EnhancementUpgrade enhancementUpgrade))
		{
			if (en is EnhancementModule)
			{
				iconFrameImage.sprite = moduleFrame;
				iconMaskImage.sprite = moduleMask;
			}
		}
		else if (enhancementUpgrade.IsRelic)
		{
			iconFrameImage.sprite = relicFrame;
			iconMaskImage.sprite = relicMask;
		}
		else
		{
			iconFrameImage.sprite = upgradeFrame;
			iconMaskImage.sprite = upgradeMask;
		}
		typeText.text = StringFormatHelper.GetEnhancementString(en);
	}

	private int GenerateRandomDiscountValue()
	{
		int maxExclusive = (maxDiscountValue - minDiscountValue) / incrementStep + 1;
		int num = DRNG.Instance.NextInt(0, maxExclusive);
		return minDiscountValue + num * incrementStep;
	}

	public void CheckForScrap()
	{
		if (shopCost > ResourceManager.Instance.Scrap.Value)
		{
			costText.color = ColorUtils.HexToColor("FF0800");
		}
		else
		{
			costText.color = ColorUtils.HexToColor("3BFF00");
		}
	}

	public void UpdatePrice()
	{
		if (cost > 0)
		{
			cost = LootManager.Instance.ApplyCostModifier(en.Cost, ShopItemType.Enhancment);
			if (discounted)
			{
				cost = Mathf.FloorToInt(cost * (100 - discountValue) / 100);
			}
			if ((float)cost > ResourceManager.Instance.Scrap.Value)
			{
				costText.color = ColorUtils.HexToColor("FF0800");
			}
			else
			{
				costText.color = ColorUtils.HexToColor("3BFF00");
			}
			costText.text = StringFormatHelper.ConvertToCurrency(cost);
			buyButton.onClick.RemoveAllListeners();
			buyButton.onClick.AddListener(delegate
			{
				Buy(en, cost);
			});
			button.interactable = false;
		}
		else
		{
			button.onClick.RemoveAllListeners();
			button.onClick.AddListener(delegate
			{
				Obtain(en);
			});
			shopContainer.gameObject.SetActive(value: false);
			button.interactable = true;
		}
		shopCost = cost;
	}

	public void OnSelect(BaseEventData eventData)
	{
		descriptionText.fontMaterial = materialAssetHover;
		rarityText.fontMaterial = materialAssetHover;
		nameText.fontMaterial = materialAssetHover;
		typeText.fontMaterial = materialAssetHover;
		dividerImage.sprite = dividerSpriteHover;
		iconFrameImage.color = UIManager.Instance.RarityColor(en.Rarity);
		if (button.interactable)
		{
			containerOutlineImage.gameObject.SetActive(value: true);
		}
		nameText.color = UIManager.Instance.RarityColor(en.Rarity);
		rarityText.color = UIManager.Instance.RarityColor(en.Rarity);
	}

	public void OnDeselect(BaseEventData eventData)
	{
		descriptionText.fontMaterial = materialAssetRegular;
		rarityText.fontMaterial = materialAssetRegular;
		nameText.fontMaterial = materialAssetRegular;
		typeText.fontMaterial = materialAssetRegular;
		dividerImage.sprite = dividerSpriteRegular;
		iconFrameImage.color = UIManager.Instance.DarkerRarityColor(en.Rarity);
		if (button.interactable)
		{
			containerOutlineImage.gameObject.SetActive(value: false);
		}
		nameText.color = UIManager.Instance.DarkerRarityColor(en.Rarity);
		rarityText.color = UIManager.Instance.DarkerRarityColor(en.Rarity);
	}

	private void OnOpened(CargoContainer container)
	{
		button.interactable = true;
	}
}
