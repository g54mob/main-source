using System.Collections.Generic;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuyBlock : ActiveComponent, IPointerEnterHandler, IEventSystemHandler
{
	[SceneBind("Name")]
	private Text Name;

	[SceneBind("ShortDescr")]
	private Text ShortDescr;

	[SceneBind("ServersCost")]
	private Text ServersCost;

	[SceneBind("Speed")]
	private Text Speed;

	[SceneBind("Icon")]
	private Image Icon;

	private GameObject spawnedGo;

	[SceneBind("Hover")]
	private Image Hover;

	[SceneBind("Under")]
	private Image Under;

	[SceneBind("Buy")]
	public Button Buy;

	[SceneBind("Buy/Text")]
	public Text Cost;

	[SceneBind("BuyHover")]
	public Button BuyHover;

	[SceneBind("BuyHover/Text")]
	public Text CostHover;

	[SceneBind("Bought")]
	public Text Bought;

	[SceneBind("Cheshire")]
	public Image SpecialBtn;

	[SceneBind("ActiveBtn")]
	public Button ActiveBtn;

	[SceneBind("DeactiveBtn")]
	public Button DeactiveBtn;

	[SceneBind("Cheshire/GetIt")]
	public Button GetIt;

	[SceneBind("Localization")]
	public RectTransform Localization;

	private ConstructionBlock constructionBlock;

	private UpgradeStats upgradeStats;

	private CatVR curHat;

	private InteriorItem shopItem;

	public void OnPointerEnter(PointerEventData eventData)
	{
		Under.gameObject.SetActive(value: false);
		if (base.gameObject.activeInHierarchy)
		{
			if (curHat != null && !ActiveComponent.Model.P.watchedShop.ContainsKey(curHat.KeyName))
			{
				ActiveComponent.Model.P.watchedShop.Add(curHat.KeyName, 1);
			}
			if (upgradeStats != null && !ActiveComponent.Model.P.watchedShop.ContainsKey(upgradeStats.KeyName))
			{
				ActiveComponent.Model.P.watchedShop.Add(upgradeStats.KeyName, 1);
			}
			if (constructionBlock != null && !ActiveComponent.Model.P.watchedShop.ContainsKey(constructionBlock.KeyName))
			{
				ActiveComponent.Model.P.watchedShop.Add(constructionBlock.KeyName, 1);
			}
			if (shopItem != null && !ActiveComponent.Model.P.watchedShop.ContainsKey(shopItem.KeyName))
			{
				ActiveComponent.Model.P.watchedShop.Add(shopItem.KeyName, 1);
			}
			base.transform.parent.parent.parent.parent.parent.GetComponent<ShopController>().RedrawUnwatched();
		}
	}

	private void ApplyClickBlock()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		string keyName = constructionBlock.KeyName;
		foreach (string extraUnlockedAlgo in ActiveComponent.Model.P.extraUnlockedAlgos)
		{
			if (extraUnlockedAlgo == keyName)
			{
				return;
			}
		}
		Steam.UnlockAchievement("ACHIEVEMENT_25");
		if (ActiveComponent.Model.P.Money >= constructionBlock.MoneyCost)
		{
			ActiveComponent.Model.P.Money -= constructionBlock.MoneyCost;
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MoneyOutcome");
			for (int i = 0; i < ActiveComponent._staticData.ConstructionBlocks.Count; i++)
			{
				if (ActiveComponent._staticData.ConstructionBlocks[i].KeyName == constructionBlock.KeyName)
				{
					ActiveComponent.Model.P.extraUnlockedAlgos.Add(ActiveComponent._staticData.ConstructionBlocks[i].KeyName);
					break;
				}
			}
			Logic.SendAnalytics("BUY ITEM", new Dictionary<string, object> { { "KeyName", constructionBlock.KeyName } });
			Logic.UpdateGameSaves();
		}
		int num = 0;
		int num2 = 0;
		foreach (ConstructionBlock constructionBlock in ActiveComponent._staticData.ConstructionBlocks)
		{
			if (constructionBlock.Extra == 1 && constructionBlock.CanBuy)
			{
				num2++;
				if (ActiveComponent.Model.P.extraUnlockedAlgos.Contains(constructionBlock.KeyName))
				{
					num++;
				}
			}
		}
		if (num == num2)
		{
			Steam.UnlockAchievement("ACHIEVEMENT_14");
		}
	}

	private void ApplyClickStats()
	{
		int hashCode = upgradeStats.KeyName.GetHashCode();
		string keyName = upgradeStats.KeyName;
		foreach (UpgradeStats unlockedUpgrade in ActiveComponent.Model.P.unlockedUpgrades)
		{
			if (unlockedUpgrade.KeyName.GetHashCode() == hashCode)
			{
				return;
			}
		}
		Steam.UnlockAchievement("ACHIEVEMENT_27");
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		if (ActiveComponent.Model.P.Money >= upgradeStats.MoneyCost)
		{
			if (!ActiveComponent.Model.P.activeInterierItem.ContainsKey(keyName))
			{
				ActiveComponent.Model.P.activeInterierItem.Add(keyName, 1);
			}
			ActiveComponent.Model.P.Money -= upgradeStats.MoneyCost;
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MoneyOutcome");
			ActiveComponent.Model.P.unlockedUpgrades.Add(upgradeStats);
			ActiveComponent.Model.P.upgradeStats.Add(upgradeStats);
			Logic.SendAnalytics("BUY ITEM", new Dictionary<string, object> { { "KeyName", upgradeStats.KeyName } });
			SetActiveUpgrade();
			Logic.UpdateGameSaves();
		}
		int num = 0;
		int num2 = 0;
		foreach (UpgradeStats pCUpgrade in ActiveComponent._staticData.PCUpgrades)
		{
			if (!pCUpgrade.CanBuy)
			{
				continue;
			}
			num2++;
			foreach (UpgradeStats unlockedUpgrade2 in ActiveComponent.Model.P.unlockedUpgrades)
			{
				if (unlockedUpgrade2.KeyName == pCUpgrade.KeyName)
				{
					num++;
					break;
				}
			}
		}
		if (num == num2)
		{
			Steam.UnlockAchievement("ACHIEVEMENT_15");
		}
	}

	private void SetActiveShopItem()
	{
		int hashCode = shopItem.Tag.GetHashCode();
		foreach (InteriorItem shopItem in ActiveComponent._staticData.ShopItems)
		{
			if (shopItem.Tag.GetHashCode() == hashCode)
			{
				ActiveComponent.Model.P.activeInterierItem[shopItem.KeyName] = 0;
			}
		}
		ActiveComponent.Model.P.activeInterierItem[this.shopItem.KeyName] = 1;
		ActiveComponent._controller.Redraw();
	}

	private void SetActiveUpgrade()
	{
		int hashCode = upgradeStats.Tag.GetHashCode();
		foreach (UpgradeStats pCUpgrade in ActiveComponent._staticData.PCUpgrades)
		{
			if (pCUpgrade.Tag.GetHashCode() == hashCode)
			{
				ActiveComponent.Model.P.activeInterierItem[pCUpgrade.KeyName] = 0;
			}
		}
		ActiveComponent.Model.P.activeInterierItem[upgradeStats.KeyName] = 1;
		ActiveComponent._controller.Redraw();
	}

	private void DeactiveShopItem()
	{
		ActiveComponent.Model.P.activeInterierItem[shopItem.KeyName] = 0;
		ActiveComponent._controller.Redraw();
	}

	private void DeactiveUpgrade()
	{
		ActiveComponent.Model.P.activeInterierItem[upgradeStats.KeyName] = 0;
		ActiveComponent._controller.Redraw();
	}

	private void ApplyClickOther()
	{
		string keyName = shopItem.KeyName;
		if (ActiveComponent.Model.P.boughtShopItem.ContainsKey(keyName))
		{
			return;
		}
		Steam.UnlockAchievement("ACHIEVEMENT_26");
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		Logic.SendAnalytics("BUY ITEM", new Dictionary<string, object> { { "KeyName", shopItem.KeyName } });
		ActiveComponent.Model.P.Money -= shopItem.Money;
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MoneyOutcome");
		int hashCode = shopItem.Tag.GetHashCode();
		ActiveComponent.Model.P.boughtShopItem.Add(keyName, 1);
		foreach (InteriorItem shopItem in ActiveComponent._staticData.ShopItems)
		{
			if (shopItem.Tag.GetHashCode() == hashCode)
			{
				ActiveComponent.Model.P.activeInterierItem[shopItem.KeyName] = 0;
			}
		}
		if (!ActiveComponent.Model.P.activeInterierItem.ContainsKey(keyName))
		{
			ActiveComponent.Model.P.activeInterierItem.Add(keyName, 1);
		}
		SetActiveShopItem();
		Logic.UpdateGameSaves();
		int num = 0;
		int num2 = 0;
		foreach (InteriorItem shopItem2 in ActiveComponent._staticData.ShopItems)
		{
			num2++;
			if (ActiveComponent.Model.P.boughtShopItem.ContainsKey(shopItem2.KeyName))
			{
				num++;
			}
		}
		if (num == num2)
		{
			Steam.UnlockAchievement("ACHIEVEMENT_17");
		}
	}

	private void ApplyClickHats()
	{
		int hashCode = curHat.KeyName.GetHashCode();
		foreach (CatVR unlockedCatHat in ActiveComponent.Model.P.unlockedCatHats)
		{
			if (unlockedCatHat.KeyName.GetHashCode() == hashCode)
			{
				return;
			}
		}
		ActiveComponent.Model.showSteamWindow = true;
		Steam.UnlockAchievement("ACHIEVEMENT_24");
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		if (ActiveComponent.Model.P.Money >= curHat.Money)
		{
			ActiveComponent.Model.P.Money -= curHat.Money;
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MoneyOutcome");
			ActiveComponent.Model.P.unlockedCatHats.Add(curHat);
			Logic.SendAnalytics("BUY ITEM", new Dictionary<string, object> { { "KeyName", curHat.KeyName } });
			ActiveComponent.Model.P.curCat = ActiveComponent.Model.P.unlockedCatHats.Count - 1;
			Logic.UpdateGameSaves();
		}
		int num = 0;
		int num2 = 0;
		foreach (CatVR item in ActiveComponent._staticData.CatCost)
		{
			num2++;
			foreach (CatVR unlockedCatHat2 in ActiveComponent.Model.P.unlockedCatHats)
			{
				if (unlockedCatHat2.KeyName == item.KeyName)
				{
					num++;
					break;
				}
			}
		}
		if (num == num2)
		{
			Steam.UnlockAchievement("ACHIEVEMENT_12");
		}
	}

	private void OpenCheshireLink(string linkKey)
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		Logic.OpenUrl(TextResources.GetString(linkKey));
	}

	protected override void OnInit()
	{
		SceneBindContainer.BindObjects(this, base.transform);
	}

	public void Init(BaseShopItem baseShopItem)
	{
		base.Init();
		if (spawnedGo != null)
		{
			Object.Destroy(spawnedGo);
		}
		Hover.gameObject.SetActive(value: true);
		curHat = null;
		upgradeStats = null;
		constructionBlock = null;
		shopItem = null;
		Localization.gameObject.SetActive(baseShopItem.KeyName == "TWOFLOWER" && ActiveComponent.Model.P.unlockedCatHats.FindIndex((CatVR c) => c.KeyName == "TWOFLOWER") <= 0);
		BuyHover.gameObject.SetActive(value: true);
		Icon.enabled = true;
		Buy.gameObject.SetActive(value: true);
		if (!baseShopItem.VisibleToPlayer)
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		ActiveBtn.gameObject.SetActive(value: false);
		DeactiveBtn.gameObject.SetActive(value: false);
		SpecialBtn.gameObject.SetActive(value: false);
		Under.gameObject.SetActive(UnlockGroup.IsUnlocked(baseShopItem.ReqUnlockGroups) && Logic.isBuyBlockUnwatched(baseShopItem.KeyName) && baseShopItem.CanBuy);
	}

	public void InitPromo(CatVR hat)
	{
		Init((BaseShopItem)hat);
		GetIt.onClick.RemoveAllListeners();
		if (hat.KeyName == "CHESHIRE")
		{
			GetIt.onClick.AddListener(delegate
			{
				OpenCheshireLink("GETCHESIRELINK");
			});
		}
		if (hat.KeyName == "FEEDBACKCAT")
		{
			GetIt.onClick.AddListener(delegate
			{
				OpenCheshireLink("SURVEY_URL");
			});
		}
		curHat = hat;
		Bought.gameObject.SetActive(value: false);
		Buy.gameObject.SetActive(value: false);
		BuyHover.gameObject.SetActive(value: false);
		Texture2D texture2D = Resources.Load("Art/" + hat.KeyName) as Texture2D;
		if (texture2D != null)
		{
			Sprite sprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100f);
			Icon.sprite = sprite;
		}
		string text = TextResources.GetString(hat.KeyName + "DESCR");
		Hover.gameObject.SetActive(value: false);
		Name.text = TextResources.GetString(hat.KeyName);
		ShortDescr.text = text;
		if (Logic.HasHat(hat.KeyName))
		{
			Bought.gameObject.SetActive(value: true);
			if (ActiveComponent.Model.P.hideBought == 1)
			{
				base.gameObject.SetActive(value: false);
			}
		}
		else if (hat.KeyName == "CHESHIRE" || hat.KeyName == "FEEDBACKCAT")
		{
			SpecialBtn.gameObject.SetActive(value: true);
		}
	}

	public void Init(CatVR hat)
	{
		Init((BaseShopItem)hat);
		curHat = hat;
		Buy.onClick.AddListener(ApplyClickHats);
		Cost.text = Logic.ColorTransform("BLACK", hat.Money + "$");
		CostHover.text = Cost.text;
		Texture2D texture2D = Resources.Load("Art/" + hat.KeyName) as Texture2D;
		if (texture2D != null)
		{
			Sprite sprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100f);
			Icon.sprite = sprite;
		}
		string text = TextResources.GetString(hat.KeyName + "DESCR");
		if (!UnlockGroup.IsUnlocked(hat.ReqUnlockGroups))
		{
			text = Logic.ColorTransform("WARNING", TextResources.GetString("LOCKED"));
			if (ActiveComponent.Model.P.hideLockedShop == 1)
			{
				base.gameObject.SetActive(value: false);
			}
			Bought.gameObject.SetActive(value: false);
			BuyHover.gameObject.SetActive(value: false);
			Buy.gameObject.SetActive(value: false);
		}
		else
		{
			Hover.gameObject.SetActive(value: false);
		}
		if (hat.Money > ActiveComponent.Model.P.Money)
		{
			Bought.gameObject.SetActive(value: false);
		}
		else
		{
			BuyHover.gameObject.SetActive(value: false);
		}
		Name.text = TextResources.GetString(hat.KeyName);
		ShortDescr.text = text;
		if (Logic.HasHat(hat.KeyName))
		{
			Buy.gameObject.SetActive(value: false);
			Bought.gameObject.SetActive(value: true);
			BuyHover.gameObject.SetActive(value: false);
			if (ActiveComponent.Model.P.hideBought == 1)
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}

	public void Init(UpgradeStats upgrade)
	{
		Init((BaseShopItem)upgrade);
		ActiveBtn.onClick.RemoveAllListeners();
		ActiveBtn.onClick.AddListener(SetActiveUpgrade);
		DeactiveBtn.onClick.RemoveAllListeners();
		DeactiveBtn.onClick.AddListener(DeactiveUpgrade);
		upgradeStats = upgrade;
		Buy.onClick.RemoveAllListeners();
		Buy.onClick.AddListener(ApplyClickStats);
		Cost.text = Logic.ColorTransform("BLACK", upgrade.MoneyCost + "$");
		CostHover.text = Cost.text;
		Name.text = Logic.ColorTransform("GREEN", TextResources.GetString(upgrade.KeyName + "SHOP"));
		string text = "";
		if ((double)upgrade.BlocksSpeedBonus > 0.001)
		{
			text = text + TextResources.GetString("BLOCKSSPEEDBONUS") + " " + Logic.ColorTransform("WARNING", Mathf.CeilToInt(upgrade.BlocksSpeedBonus * 100f) + "%");
		}
		if ((double)upgrade.ChainSpeedBonus > 0.001)
		{
			if (text.Length > 0)
			{
				text += "\n";
			}
			text = text + TextResources.GetString("CHAINTIMEBONUS") + " " + Logic.ColorTransform("WARNING", Mathf.CeilToInt(upgrade.ChainSpeedBonus * 100f) + "%");
		}
		if ((double)upgrade.ServersCostBonus > 0.001)
		{
			if (text.Length > 0)
			{
				text += "\n";
			}
			text = text + TextResources.GetString("SERVERSCOSTBONUS") + " " + Logic.ColorTransform("WARNING", Mathf.CeilToInt(upgrade.ServersCostBonus * 100f) + "%");
		}
		if ((double)upgrade.SocketDepthBonus > 0.001)
		{
			if (text.Length > 0)
			{
				text += "\n";
			}
			text = text + TextResources.GetString("SOCKETDEPTHBONUS") + " " + Logic.ColorTransform("WARNING", upgrade.SocketDepthBonus.ToString());
		}
		if (upgrade.MemoryBonus > 0)
		{
			if (text.Length > 0)
			{
				text += "\n";
			}
			text = text + TextResources.GetString("MEMORYBONUS") + " " + Logic.ColorTransform("WARNING", upgrade.MemoryBonus.ToString());
		}
		Texture2D texture2D = Resources.Load("Art/" + upgrade.KeyName) as Texture2D;
		if (texture2D != null)
		{
			Sprite sprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100f);
			Icon.sprite = sprite;
		}
		ShortDescr.text = text;
		if (!UnlockGroup.IsUnlocked(upgrade.ReqUnlockGroups))
		{
			text = Logic.ColorTransform("WARNING", TextResources.GetString("LOCKED"));
			ShortDescr.text = text;
			if (ActiveComponent.Model.P.hideLockedShop == 1)
			{
				base.gameObject.SetActive(value: false);
			}
			Buy.gameObject.SetActive(value: false);
			Bought.gameObject.SetActive(value: false);
			BuyHover.gameObject.SetActive(value: false);
			Hover.gameObject.SetActive(value: true);
			return;
		}
		Hover.gameObject.SetActive(value: false);
		if (!upgrade.CanBuy)
		{
			ShortDescr.text = Logic.ColorTransform("WARNING", TextResources.GetString("LOCKED")) + Logic.ColorTransform("WARNING", " : " + TextResources.GetString("COMING SOON"));
			Buy.gameObject.SetActive(value: false);
			if (ActiveComponent.Model.P.hideLockedShop == 1)
			{
				base.gameObject.SetActive(value: false);
			}
			BuyHover.gameObject.SetActive(value: false);
			Bought.gameObject.SetActive(value: false);
			return;
		}
		ShortDescr.text = text;
		if (Logic.HasUpgrade(upgrade.KeyName))
		{
			Bought.gameObject.SetActive(value: true);
			if (ActiveComponent.Model.P.hideBought == 1)
			{
				base.gameObject.SetActive(value: false);
			}
			BuyHover.gameObject.SetActive(value: false);
			Buy.gameObject.SetActive(value: false);
			string keyName = upgrade.KeyName;
			if (ActiveComponent.Model.P.activeInterierItem.ContainsKey(keyName) && upgradeStats.ShowInRoom == 1)
			{
				ActiveBtn.gameObject.SetActive(ActiveComponent.Model.P.activeInterierItem[keyName] == 0);
				DeactiveBtn.gameObject.SetActive(ActiveComponent.Model.P.activeInterierItem[keyName] == 1);
			}
		}
		else if (upgrade.MoneyCost > ActiveComponent.Model.P.Money)
		{
			BuyHover.gameObject.SetActive(value: true);
		}
		else
		{
			BuyHover.gameObject.SetActive(value: false);
		}
	}

	public void Init(InteriorItem item)
	{
		Init((BaseShopItem)item);
		ActiveBtn.onClick.RemoveAllListeners();
		ActiveBtn.onClick.AddListener(SetActiveShopItem);
		DeactiveBtn.onClick.RemoveAllListeners();
		DeactiveBtn.onClick.AddListener(DeactiveShopItem);
		Icon.sprite = Logic.LoadSprite(item.KeyName);
		Hover.gameObject.SetActive(!UnlockGroup.IsUnlocked(item.ReqUnlockGroups));
		shopItem = item;
		bool flag = ActiveComponent.Model.P.boughtShopItem.ContainsKey(item.KeyName);
		Buy.onClick.AddListener(ApplyClickOther);
		Cost.text = Logic.ColorTransform("BLACK", item.Money + "$");
		CostHover.text = Cost.text;
		BuyHover.gameObject.SetActive(value: false);
		if (item.Money > ActiveComponent.Model.P.Money)
		{
			Buy.gameObject.SetActive(value: false);
			BuyHover.gameObject.SetActive(value: true);
			Bought.gameObject.SetActive(value: false);
		}
		if (flag)
		{
			Buy.gameObject.SetActive(value: false);
			BuyHover.gameObject.SetActive(value: false);
			Bought.gameObject.SetActive(value: true);
			if (ActiveComponent.Model.P.hideBought == 1)
			{
				base.gameObject.SetActive(value: false);
			}
		}
		Name.text = Logic.ColorTransform("GREEN", TextResources.GetString(item.KeyName + "SHOP"));
		if (!UnlockGroup.IsUnlocked(item.ReqUnlockGroups))
		{
			if (ActiveComponent.Model.P.hideLockedShop == 1)
			{
				base.gameObject.SetActive(value: false);
			}
			ShortDescr.text = Logic.ColorTransform("WARNING", TextResources.GetString("LOCKED"));
			Buy.gameObject.SetActive(value: false);
			Bought.gameObject.SetActive(value: false);
			BuyHover.gameObject.SetActive(value: false);
			return;
		}
		ShortDescr.text = TextResources.GetString(item.KeyName + "DESCR");
		if (flag)
		{
			string keyName = item.KeyName;
			if (ActiveComponent.Model.P.activeInterierItem.ContainsKey(keyName))
			{
				ActiveBtn.gameObject.SetActive(ActiveComponent.Model.P.activeInterierItem[keyName] == 0);
				DeactiveBtn.gameObject.SetActive(ActiveComponent.Model.P.activeInterierItem[keyName] == 1);
			}
		}
	}

	public void Init(ConstructionBlock block)
	{
		Init((BaseShopItem)block);
		constructionBlock = block;
		bool flag = Logic.HasAlgoBlock(block.KeyName);
		Buy.onClick.AddListener(ApplyClickBlock);
		Cost.text = Logic.ColorTransform("BLACK", block.MoneyCost + "$");
		CostHover.text = Cost.text;
		for (int i = 0; i < ActiveComponent._staticData.ConstructionBlocks.Count; i++)
		{
			if (ActiveComponent._staticData.ConstructionBlocks[i].VisibleToPlayer && ActiveComponent._staticData.ConstructionBlocks[i].Extra == 1 && ActiveComponent._staticData.ConstructionBlocks[i].KeyName == block.KeyName && ActiveComponent.Model.P.extraUnlockedAlgos.Contains(block.KeyName))
			{
				Buy.gameObject.SetActive(value: false);
				break;
			}
		}
		GameObject gameObject = Logic.LoadPrefab(block.KeyName);
		if (gameObject != null)
		{
			Icon.enabled = false;
			GameObject gameObject2 = Object.Instantiate(gameObject, Icon.gameObject.transform.position, Icon.transform.rotation);
			gameObject2.transform.parent = Icon.transform;
			gameObject2.GetComponent<BlockData>().DeActive(disableSockets: true);
			spawnedGo = gameObject2;
			if (gameObject2 != null)
			{
				Socket[] componentsInChildren = gameObject2.GetComponentsInChildren<Socket>();
				foreach (Socket obj in componentsInChildren)
				{
					obj.Redraw();
					obj.InitDraw();
				}
			}
			gameObject2.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);
		}
		Hover.gameObject.SetActive(value: false);
		if (flag)
		{
			Name.text = Logic.ColorTransform("GREEN", TextResources.GetString(block.KeyName + "SHOP"));
			ShortDescr.text = TextResources.GetString(block.KeyName + "DESCR");
			Buy.gameObject.SetActive(value: false);
			BuyHover.gameObject.SetActive(value: false);
			Bought.gameObject.SetActive(value: true);
			if (ActiveComponent.Model.P.hideBought == 1)
			{
				base.gameObject.SetActive(value: false);
			}
		}
		else if (!UnlockGroup.IsUnlocked(block.ReqUnlockGroups))
		{
			Name.text = Logic.ColorTransform("GREEN", TextResources.GetString(block.KeyName + "SHOP"));
			ShortDescr.text = Logic.ColorTransform("WARNING", TextResources.GetString("LOCKED"));
			if (ActiveComponent.Model.P.hideLockedShop == 1)
			{
				base.gameObject.SetActive(value: false);
			}
			if (!block.CanBuy)
			{
				ShortDescr.text += Logic.ColorTransform("WARNING", " : " + TextResources.GetString("COMING SOON"));
			}
			Buy.gameObject.SetActive(value: false);
			BuyHover.gameObject.SetActive(value: false);
			Bought.gameObject.SetActive(value: false);
			Hover.gameObject.SetActive(value: true);
		}
		else if (!block.CanBuy)
		{
			Name.text = Logic.ColorTransform("GREEN", TextResources.GetString(block.KeyName + "SHOP"));
			if (ActiveComponent.Model.P.hideLockedShop == 1)
			{
				base.gameObject.SetActive(value: false);
			}
			ShortDescr.text = TextResources.GetString(block.KeyName + "DESCR") + "\n" + Logic.ColorTransform("WARNING", TextResources.GetString("COMING SOON"));
			Buy.gameObject.SetActive(value: false);
			BuyHover.gameObject.SetActive(value: false);
			Bought.gameObject.SetActive(value: false);
		}
		else
		{
			if (block.MoneyCost < ActiveComponent.Model.P.Money)
			{
				BuyHover.gameObject.SetActive(value: false);
			}
			Name.text = Logic.ColorTransform("GREEN", TextResources.GetString(block.KeyName + "SHOP"));
			ShortDescr.text = TextResources.GetString(block.KeyName + "DESCR");
		}
	}
}
