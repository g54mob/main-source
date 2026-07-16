using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ShopWindow : Menu
{
	public static ShopWindow Instance;

	[Header("Discount Config")]
	[SerializeField]
	private int maxDiscountValue;

	[SerializeField]
	private int minDiscountValue;

	[SerializeField]
	private int incrementStep;

	private int cardsToDisplay = 4;

	private int firstCardToBeDiscounted;

	private int secondCardToBeDiscounted;

	private List<GameObject> shopCardGOs;

	private List<Enhancement> enhancements;

	private List<EnhancementCard> enhancementCards = new List<EnhancementCard>();

	[Header("UI Prefabs")]
	[SerializeField]
	public GameObject shopCargoContainerPrefab;

	[Header("Card Transforms")]
	[SerializeField]
	private Transform topCardsTf;

	[SerializeField]
	private Transform bottomCardsTf;

	[Header("Close Button")]
	[SerializeField]
	private Button closeButton;

	[Header("Discount GameObjects")]
	[SerializeField]
	private GameObject discountGoAmmo1;

	[SerializeField]
	private GameObject discountGoAmmo2;

	[SerializeField]
	private GameObject discountGoHull1;

	[SerializeField]
	private GameObject discountGoHull2;

	[SerializeField]
	private GameObject discountGoWagon1;

	[SerializeField]
	private GameObject discountGoWagon2;

	[Header("Discount Texts")]
	[SerializeField]
	private TextMeshProUGUI discountTextAmmo1;

	[SerializeField]
	private TextMeshProUGUI discountTextAmmo2;

	[SerializeField]
	private TextMeshProUGUI discountTextHull1;

	[SerializeField]
	private TextMeshProUGUI discountTextHull2;

	[SerializeField]
	private TextMeshProUGUI discountTextWagon1;

	[SerializeField]
	private TextMeshProUGUI discountTextWagon2;

	[Header("Category Lists")]
	[SerializeField]
	private List<ShopCategoryWagon> shopWagonCategories;

	[SerializeField]
	private List<ShopCategoryAmmo> shopAmmoCategories;

	[SerializeField]
	private List<ShopCategoryHull> shopHullCategories;

	[SerializeField]
	private List<ShopCategoryCores> shopCoresCategories;

	[Header("Misc UI")]
	[SerializeField]
	private GameObject reopenButtonGo;

	[SerializeField]
	private GameObject reopenGamepadInputGo;

	[SerializeField]
	private List<SlidingUIElement> slidingUIElements;

	[Header("Music")]
	[SerializeField]
	public AudioClip buyClip;

	[SerializeField]
	public AudioClip airWrench;

	private int ammoCost1;

	private int ammoCost2;

	private int hullCost1;

	private int hullCost2;

	private int wagonDiscountValue1;

	private int wagonDiscountValue2;

	[NonSerialized]
	public int coresCostModifier;

	public bool Active { get; private set; }

	public event Action OnCheckForScrap;

	public event Action OnUpdatePrices;

	public override void Init()
	{
		base.Init();
		Instance = this;
		shopCardGOs = new List<GameObject>();
		LevelManager.Instance.DestinationReached += HandleDestinationReached;
		LevelManager.Instance.NextLevelSelected += delegate
		{
			HandleNextLevelSelected();
		};
	}

	private void HandleDestinationReached()
	{
		if (LevelManager.Instance.CurrentLevel.LootType == LootType.Shop)
		{
			Restock();
		}
	}

	private void HandleNextLevelSelected()
	{
		reopenButtonGo.gameObject.SetActive(value: false);
		reopenGamepadInputGo.gameObject.SetActive(value: false);
		MenuManager.Instance.MenuClosed -= delegate
		{
			HandleMenuClosed();
		};
		MenuManager.Instance.MenuOpened -= delegate
		{
			HandleMenuOpened();
		};
	}

	private void HandleMenuClosed()
	{
		ResetContainers();
		InputManager.Instance.OnYPressed -= OnReopenPressed;
		LootType lootType = LevelManager.Instance.CurrentLevel.LootType;
		bool flag = LevelManager.Instance.IsAtDestination && lootType == LootType.Shop && LevelManager.Instance.NextLevel == null;
		if (InputManager.Instance.IsLastInputGamepad)
		{
			reopenGamepadInputGo.SetActive(flag);
		}
		else
		{
			reopenButtonGo.SetActive(flag);
		}
		if (flag)
		{
			InputManager.Instance.OnYPressed += OnReopenPressed;
		}
	}

	private void OnReopenPressed(int _, InputAction.CallbackContext __)
	{
		if (!base.gameObject.activeSelf && LevelManager.Instance.CurrentLevel.LootType == LootType.Shop)
		{
			if (enhancementCards[0] != null)
			{
				EventSystem.current.SetSelectedGameObject(enhancementCards[0].buyButton.gameObject);
			}
			else
			{
				EventSystem.current.SetSelectedGameObject(shopWagonCategories[0].buyButton.gameObject);
			}
			MenuManager.Instance.OpenMenu(base.MenuType);
		}
	}

	private void HandleMenuOpened()
	{
		reopenButtonGo.SetActive(value: false);
		reopenGamepadInputGo.SetActive(value: false);
	}

	private void Restock()
	{
		this.OnCheckForScrap = null;
		ClearShopWindow();
		enhancements = new List<Enhancement>();
		wagonDiscountValue1 = 0;
		wagonDiscountValue2 = 0;
		if (DRNG.Instance.NextFloat01() <= LootManager.Instance.DiscountProbWagon)
		{
			if (DRNG.Instance.NextInt(1, 3) == 1)
			{
				wagonDiscountValue1 = GenerateRandomDiscountValue();
				discountTextWagon1.text = wagonDiscountValue1 + "%";
				discountGoWagon1.SetActive(value: true);
			}
			else
			{
				wagonDiscountValue2 = GenerateRandomDiscountValue();
				discountTextWagon2.text = wagonDiscountValue2 + "%";
				discountGoWagon2.SetActive(value: true);
			}
		}
		else
		{
			discountGoWagon1.SetActive(value: false);
			discountGoWagon2.SetActive(value: false);
		}
		ShopWagon shopWagon = SaveManager.Instance.GetShopWagon(0);
		if (shopWagon != null)
		{
			shopWagonCategories[0].Setup(LootUtils.GetWagonBySize(shopWagon.Size), wagonDiscountValue1, 0);
		}
		else
		{
			EnhancementWagon randomWagon = LootUtils.GetRandomWagon();
			shopWagonCategories[0].Setup(randomWagon, wagonDiscountValue1, 0);
			SaveManager.Instance.AddShopWagon(new ShopWagon(0, shopWagonCategories[0].wagon.ModuleSlotCount));
		}
		ShopWagon shopWagon2 = SaveManager.Instance.GetShopWagon(1);
		if (shopWagon2 != null)
		{
			shopWagonCategories[1].Setup(LootUtils.GetWagonBySize(shopWagon2.Size), wagonDiscountValue2, 1);
		}
		else
		{
			EnhancementWagon randomWagon2 = LootUtils.GetRandomWagon();
			shopWagonCategories[1].Setup(randomWagon2, wagonDiscountValue2, 1);
			SaveManager.Instance.AddShopWagon(new ShopWagon(1, shopWagonCategories[1].wagon.ModuleSlotCount));
		}
		ammoCost1 = Mathf.RoundToInt(LootManager.Instance.AmmoCost1);
		ammoCost2 = Mathf.RoundToInt(LootManager.Instance.AmmoCost2);
		hullCost1 = Mathf.RoundToInt(LootManager.Instance.HullCost1);
		hullCost2 = Mathf.RoundToInt(LootManager.Instance.HullCost2);
		if (DRNG.Instance.NextFloat01() <= LootManager.Instance.DiscountProbAmmoAndHull1)
		{
			int num = GenerateRandomDiscountValue();
			int num2 = DRNG.Instance.NextInt(1, 5);
			switch (num2)
			{
			case 1:
				ammoCost1 = Mathf.FloorToInt(ammoCost1 * (100 - num) / 100);
				discountTextAmmo1.text = num + "%";
				discountGoAmmo1.SetActive(value: true);
				break;
			case 2:
				ammoCost2 = Mathf.FloorToInt(ammoCost2 * (100 - num) / 100);
				discountTextAmmo2.text = num + "%";
				discountGoAmmo2.SetActive(value: true);
				break;
			case 3:
				hullCost1 = Mathf.FloorToInt(hullCost1 * (100 - num) / 100);
				discountTextHull1.text = num + "%";
				discountGoHull1.SetActive(value: true);
				break;
			case 4:
				hullCost2 = Mathf.FloorToInt(hullCost2 * (100 - num) / 100);
				discountTextHull2.text = num + "%";
				discountGoHull2.SetActive(value: true);
				break;
			}
			if (DRNG.Instance.NextFloat01() <= LootManager.Instance.DiscountProbAmmoAndHull2)
			{
				int num3 = GenerateRandomDiscountValue();
				int num4;
				for (num4 = num2; num4 == num2; num4 = DRNG.Instance.NextInt(1, 5))
				{
				}
				switch (num4)
				{
				case 1:
					ammoCost1 = Mathf.FloorToInt(ammoCost1 * (100 - num3) / 100);
					discountTextAmmo1.text = num3 + "%";
					discountGoAmmo1.SetActive(value: true);
					break;
				case 2:
					ammoCost2 = Mathf.FloorToInt(ammoCost2 * (100 - num3) / 100);
					discountTextAmmo2.text = num3 + "%";
					discountGoAmmo2.SetActive(value: true);
					break;
				case 3:
					hullCost1 = Mathf.FloorToInt(hullCost1 * (100 - num3) / 100);
					discountTextHull1.text = num3 + "%";
					discountGoHull1.SetActive(value: true);
					break;
				case 4:
					hullCost2 = Mathf.FloorToInt(hullCost2 * (100 - num3) / 100);
					discountTextHull2.text = num3 + "%";
					discountGoHull2.SetActive(value: true);
					break;
				}
			}
		}
		else
		{
			discountGoAmmo1.SetActive(value: false);
			discountGoAmmo2.SetActive(value: false);
			discountGoHull1.SetActive(value: false);
			discountGoHull2.SetActive(value: false);
		}
		shopAmmoCategories[0].Setup(Mathf.FloorToInt(ammoCost1), LootManager.Instance.AmmoQuantity1);
		shopAmmoCategories[1].Setup(Mathf.FloorToInt(ammoCost2), LootManager.Instance.AmmoQuantity2);
		shopHullCategories[0].Setup(Mathf.FloorToInt(hullCost1), LootManager.Instance.HullQuantity1);
		shopHullCategories[1].Setup(Mathf.FloorToInt(hullCost2), LootManager.Instance.HullQuantity2);
		int num5 = LootManager.Instance.CoresCost;
		for (int i = 0; i < coresCostModifier; i++)
		{
			num5 *= 2;
		}
		shopCoresCategories[0].Setup(num5, LootManager.Instance.CoresQuantity);
		UpdateCategoryColors();
		int numberOfEmptyModuleSlots = Train.Instance.GetNumberOfEmptyModuleSlots();
		int num6 = 0;
		int num7 = 0;
		EnhancementUpgrade[] relicsInInventory = UpgradeManager.Instance.RelicsInInventory;
		for (int j = 0; j < relicsInInventory.Length && !(relicsInInventory[j] == null); j++)
		{
			num7++;
		}
		int num8 = 0;
		for (int k = 0; k < cardsToDisplay; k++)
		{
			Enhancement enhancement = null;
			Enhancement purchasedShopEnhancementAtIndex = SaveManager.Instance.GetPurchasedShopEnhancementAtIndex(k);
			if ((object)purchasedShopEnhancementAtIndex != null)
			{
				enhancements.Add(purchasedShopEnhancementAtIndex);
				continue;
			}
			Enhancement shopEnhancementAtIndex = SaveManager.Instance.GetShopEnhancementAtIndex(k);
			if ((object)shopEnhancementAtIndex != null)
			{
				enhancements.Add(shopEnhancementAtIndex);
				continue;
			}
			switch (LootUtils.GetWeightedIndex(LootManager.Instance.ShopWeights))
			{
			case 0:
				enhancement = LootUtils.GetRandomLoot(LootType.Upgrade, LevelManager.Instance.CurrentLevel.Difficulty.GetWeightedRarity(), enhancements);
				break;
			case 1:
				enhancement = ((!Train.Instance.GetFirstEmptyModuleSlot()) ? LootUtils.GetRandomLoot(LootType.Upgrade, LevelManager.Instance.CurrentLevel.Difficulty.GetWeightedRarity(), enhancements) : LootUtils.GetRandomLoot(LootType.Module, LevelManager.Instance.CurrentLevel.Difficulty.GetWeightedRarity(), enhancements));
				break;
			case 2:
				enhancement = ((!(UpgradeManager.Instance.RelicsInInventory[8] == null)) ? LootUtils.GetRandomLoot(LootType.Upgrade, LevelManager.Instance.CurrentLevel.Difficulty.GetWeightedRarity(), enhancements) : LootUtils.GetRandomLoot(LootType.Relic, LevelManager.Instance.CurrentLevel.Difficulty.GetWeightedRarity(), enhancements));
				break;
			case 3:
				enhancement = LootUtils.GetRandomLoot(LootType.CannonUpgrade, LevelManager.Instance.CurrentLevel.Difficulty.GetWeightedRarity(), enhancements);
				break;
			}
			if (enhancement == null)
			{
				enhancement = GenerateAnyLoot(enhancement, enhancements);
			}
			if (enhancement is EnhancementModule)
			{
				num6++;
			}
			if (enhancement is EnhancementUpgrade { IsRelic: not false })
			{
				num8++;
			}
			if (num6 > numberOfEmptyModuleSlots && num8 + num7 > 9)
			{
				enhancement = GenerateAnyLoot(enhancement, enhancements, canBeModule: false, canBeRelic: false);
			}
			else if (num6 > numberOfEmptyModuleSlots)
			{
				enhancement = GenerateAnyLoot(enhancement, enhancements, canBeModule: false);
				if (enhancement is EnhancementUpgrade { IsRelic: not false })
				{
					num8++;
					if (num8 + num7 > 9)
					{
						enhancement = GenerateAnyLoot(enhancement, enhancements, canBeModule: false, canBeRelic: false);
					}
				}
			}
			else if (num8 + num7 > 9)
			{
				enhancement = GenerateAnyLoot(enhancement, enhancements, canBeModule: true, canBeRelic: false);
				if (enhancement is EnhancementModule)
				{
					num6++;
					if (num6 > numberOfEmptyModuleSlots)
					{
						enhancement = GenerateAnyLoot(enhancement, enhancements, canBeModule: false, canBeRelic: false);
					}
				}
			}
			if (!(enhancement == null))
			{
				enhancements.Add(enhancement);
				SaveManager.Instance.AddShopEnhancement(k, enhancement);
			}
		}
		DisplayEnhancements();
		MenuManager.Instance.OpenMenu(MenuType.Shop);
		MenuManager.Instance.MenuClosed += delegate
		{
			HandleMenuClosed();
		};
		MenuManager.Instance.MenuOpened += delegate
		{
			HandleMenuOpened();
		};
	}

	public Enhancement GenerateAnyLoot(Enhancement en, List<Enhancement> oldEnhancements, bool canBeModule = true, bool canBeRelic = true)
	{
		en = LootUtils.GetRandomLoot(LootType.Upgrade, LevelManager.Instance.CurrentLevel.Difficulty.GetWeightedRarity(), oldEnhancements);
		if (en == null)
		{
			en = LootUtils.GetRandomLoot(LootType.CannonUpgrade, LevelManager.Instance.CurrentLevel.Difficulty.GetWeightedRarity(), oldEnhancements);
		}
		if (canBeRelic && en == null && UpgradeManager.Instance.RelicsInInventory[8] == null)
		{
			en = LootUtils.GetRandomLoot(LootType.Relic, LevelManager.Instance.CurrentLevel.Difficulty.GetWeightedRarity(), oldEnhancements);
		}
		if (canBeModule && en == null && (bool)Train.Instance.GetFirstEmptyModuleSlot())
		{
			en = LootUtils.GetRandomLoot(LootType.Module, LevelManager.Instance.CurrentLevel.Difficulty.GetWeightedRarity(), oldEnhancements);
		}
		if (en == null)
		{
			return null;
		}
		return en;
	}

	private void DisplayEnhancements()
	{
		enhancementCards.Clear();
		if (enhancements.Count == 0)
		{
			return;
		}
		if (DRNG.Instance.NextFloat01() <= LootManager.Instance.DiscountProbShop1)
		{
			firstCardToBeDiscounted = DRNG.Instance.NextInt(1, 5);
			if (DRNG.Instance.NextFloat01() <= LootManager.Instance.DiscountProbShop2)
			{
				for (secondCardToBeDiscounted = firstCardToBeDiscounted; secondCardToBeDiscounted == firstCardToBeDiscounted; secondCardToBeDiscounted = DRNG.Instance.NextInt(1, 5))
				{
				}
			}
		}
		for (int i = 0; i < enhancements.Count; i++)
		{
			if (enhancements[i] != null)
			{
				CreateShopCard(i, enhancements[i]);
			}
		}
		List<Button> cardButtons = enhancementCards.Select((EnhancementCard c) => c.buyButton).ToList();
		BuildShopNav(cardButtons, shopWagonCategories[0].buyButton);
		if (enhancementCards[0] != null)
		{
			EventSystem.current.SetSelectedGameObject(enhancementCards[0].buyButton.gameObject);
		}
		else
		{
			EventSystem.current.SetSelectedGameObject(shopWagonCategories[0].buyButton.gameObject);
		}
	}

	private void CreateShopCard(int i, Enhancement enhancement)
	{
		if (!(enhancement == null))
		{
			Transform parent = ((i < 2) ? topCardsTf : bottomCardsTf);
			GameObject gameObject = UnityEngine.Object.Instantiate(shopCargoContainerPrefab, parent);
			EnhancementCard card = gameObject.GetComponent<CargoContainer>().Card;
			bool isDiscounted = false;
			int count = shopCardGOs.Count;
			if ((firstCardToBeDiscounted != 0 && count == firstCardToBeDiscounted - 1) || (secondCardToBeDiscounted != 0 && count == secondCardToBeDiscounted - 1))
			{
				isDiscounted = true;
			}
			card.Initialize(enhancement, i, enhancement.Cost, isDiscounted, SaveManager.Instance.HasPurchasedShopEnhancementAtIndex(i), isClickable: false);
			shopCardGOs.Add(gameObject);
			enhancementCards.Add(card);
			OnCheckForScrap += card.CheckForScrap;
			OnUpdatePrices += card.UpdatePrice;
		}
	}

	public void BuildShopNav(List<Button> cardButtons, Button wagonBuyButtonTop)
	{
		if (cardButtons.Count == 4)
		{
			Button button = cardButtons[0];
			Button button2 = cardButtons[1];
			Button button3 = cardButtons[2];
			Button button4 = cardButtons[3];
			button.navigation = new Navigation
			{
				mode = Navigation.Mode.Explicit,
				selectOnRight = button2,
				selectOnDown = button3
			};
			button2.navigation = new Navigation
			{
				mode = Navigation.Mode.Explicit,
				selectOnLeft = button,
				selectOnDown = button4,
				selectOnRight = wagonBuyButtonTop
			};
			button3.navigation = new Navigation
			{
				mode = Navigation.Mode.Explicit,
				selectOnRight = button4,
				selectOnUp = button,
				selectOnDown = closeButton
			};
			button4.navigation = new Navigation
			{
				mode = Navigation.Mode.Explicit,
				selectOnLeft = button3,
				selectOnUp = button2,
				selectOnRight = wagonBuyButtonTop,
				selectOnDown = closeButton
			};
			Navigation navigation = wagonBuyButtonTop.navigation;
			navigation.selectOnLeft = button2;
			wagonBuyButtonTop.navigation = navigation;
			Navigation navigation2 = closeButton.navigation;
			navigation2.selectOnLeft = button4;
			closeButton.navigation = navigation2;
		}
	}

	public void ClearShopWindow()
	{
		for (int i = 0; i < topCardsTf.childCount; i++)
		{
			UnityEngine.Object.Destroy(topCardsTf.GetChild(i).gameObject);
		}
		for (int j = 0; j < bottomCardsTf.childCount; j++)
		{
			UnityEngine.Object.Destroy(bottomCardsTf.GetChild(j).gameObject);
		}
		shopCardGOs.Clear();
		discountGoAmmo1.SetActive(value: false);
		discountGoAmmo2.SetActive(value: false);
		discountGoHull1.SetActive(value: false);
		discountGoHull2.SetActive(value: false);
		discountGoWagon1.SetActive(value: false);
		discountGoWagon2.SetActive(value: false);
	}

	private int GenerateRandomDiscountValue()
	{
		int maxExclusive = (maxDiscountValue - minDiscountValue) / incrementStep + 1;
		int num = DRNG.Instance.NextInt(0, maxExclusive);
		return minDiscountValue + num * incrementStep;
	}

	public void CheckForScrap()
	{
		this.OnCheckForScrap?.Invoke();
		_ = ResourceManager.Instance.Scrap.Value;
		UpdateCategoryColors();
	}

	private void UpdateCategoryColors()
	{
		float value = ResourceManager.Instance.Scrap.Value;
		foreach (ShopCategory item in shopAmmoCategories.Cast<ShopCategory>().Concat(shopHullCategories).Concat(shopWagonCategories)
			.Concat(shopCoresCategories))
		{
			item.SetCostColor(value);
		}
	}

	public void UpdatePrices()
	{
		if (!base.gameObject.activeSelf)
		{
			return;
		}
		this.OnUpdatePrices?.Invoke();
		shopAmmoCategories[0].Setup(Mathf.FloorToInt(ammoCost1), LootManager.Instance.AmmoQuantity1);
		shopAmmoCategories[1].Setup(Mathf.FloorToInt(ammoCost2), LootManager.Instance.AmmoQuantity2);
		shopHullCategories[0].Setup(Mathf.FloorToInt(hullCost1), LootManager.Instance.HullQuantity1);
		shopHullCategories[1].Setup(Mathf.FloorToInt(hullCost2), LootManager.Instance.HullQuantity2);
		int num = LootManager.Instance.CoresCost;
		for (int i = 0; i < coresCostModifier; i++)
		{
			num *= 2;
		}
		shopCoresCategories[0].Setup(num, LootManager.Instance.CoresQuantity);
		if (!shopWagonCategories[0].isBought)
		{
			int num2 = Mathf.FloorToInt(shopWagonCategories[0].wagon.Cost * (100 - wagonDiscountValue1) / 100);
			shopWagonCategories[0].shopCost = num2;
			if ((float)num2 > ResourceManager.Instance.Scrap.Value)
			{
				shopWagonCategories[0].costText.color = ColorUtils.HexToColor("FF0800");
			}
			else
			{
				shopWagonCategories[0].costText.color = ColorUtils.HexToColor("3BFF00");
			}
			shopWagonCategories[0].costText.text = StringFormatHelper.ConvertToCurrency(num2);
			shopWagonCategories[0].buyButton.interactable = true;
			shopWagonCategories[0].buyButton.onClick.RemoveAllListeners();
			shopWagonCategories[0].buyButton.onClick.AddListener(delegate
			{
				shopWagonCategories[0].BuyWagon(shopWagonCategories[0].wagon);
			});
			shopWagonCategories[0].buyButtonText.enabled = true;
			shopWagonCategories[0].checkmarkImage.enabled = false;
		}
		if (!shopWagonCategories[1].isBought)
		{
			int num3 = Mathf.FloorToInt(shopWagonCategories[1].wagon.Cost * (100 - wagonDiscountValue2) / 100);
			shopWagonCategories[1].shopCost = num3;
			if ((float)num3 > ResourceManager.Instance.Scrap.Value)
			{
				shopWagonCategories[1].costText.color = ColorUtils.HexToColor("FF0800");
			}
			else
			{
				shopWagonCategories[1].costText.color = ColorUtils.HexToColor("3BFF00");
			}
			shopWagonCategories[1].costText.text = StringFormatHelper.ConvertToCurrency(num3);
			shopWagonCategories[1].buyButton.interactable = true;
			shopWagonCategories[1].buyButton.onClick.RemoveAllListeners();
			shopWagonCategories[1].buyButton.onClick.AddListener(delegate
			{
				shopWagonCategories[1].BuyWagon(shopWagonCategories[1].wagon);
			});
			shopWagonCategories[1].buyButtonText.enabled = true;
			shopWagonCategories[1].checkmarkImage.enabled = false;
		}
	}

	public void ResetContainers()
	{
		foreach (EnhancementCard enhancementCard in enhancementCards)
		{
			enhancementCard.Container.gameObject.GetComponent<ShopCargoContainer>().ResetContainer();
		}
	}

	public void ShopSlideInStarted()
	{
		AudioManager.Instance.SfxHelper.PlaySoundEffect(airWrench, 1f, 1f);
	}

	public void ShopSlideInEnded()
	{
		if (enhancementCards != null && enhancementCards.Count > 0)
		{
			StartCoroutine(OpenContainersCoroutine());
		}
	}

	private IEnumerator OpenContainersCoroutine()
	{
		foreach (EnhancementCard enhancementCard in enhancementCards)
		{
			if (!enhancementCard.isBought)
			{
				enhancementCard.Container.Anim.enabled = true;
				enhancementCard.Container.Anim.Play("ShopCargoOpen");
				yield return new WaitForSecondsRealtime(0.15f);
			}
		}
	}
}
