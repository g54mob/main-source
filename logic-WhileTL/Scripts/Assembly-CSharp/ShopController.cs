using System;
using System.Collections;
using System.Collections.Generic;
using App.Data;
using Aux;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : ActiveComponent
{
	public enum OpenShopState
	{
		Interier = 0,
		Hardware = 1,
		Block = 2,
		Cat = 3
	}

	[SceneBind("Canvas/ExitButton")]
	private Button ExitButton;

	[SceneBind("Layer")]
	private Button Layer;

	[SceneBind("Canvas/BonusLayer")]
	private RectTransform BonusLayer;

	[SceneBind("Canvas/Money")]
	private Text Money;

	[SceneBind("Canvas/View")]
	public RectTransform View;

	private Rect viewRect = Rect.zero;

	[SceneBind("Canvas/BlocksShop/HardBtn")]
	private Button FromBlocksToHard;

	[SceneBind("Canvas/BlocksShop/CatBtn")]
	private Button FromBlocksToCat;

	[SceneBind("Canvas/HardwareShop/BlocksBtn")]
	private Button FromHardToBlocks;

	[SceneBind("Canvas/HardwareShop/CatBtn")]
	private Button FromHardToCat;

	[SceneBind("Canvas/CatShop/BlocksBtn")]
	private Button FromCatToBlocks;

	[SceneBind("Canvas/CatShop/HardBtn")]
	private Button FromCatToHardware;

	[SceneBind("Canvas/CatShop/OtherBtn")]
	private Button FromCatToOther;

	[SceneBind("Canvas/HardwareShop/OtherBtn")]
	private Button FromHardToOther;

	[SceneBind("Canvas/BlocksShop/OtherBtn")]
	private Button FromBlocksToOther;

	[SceneBind("Canvas/OtherShop/CatBtn")]
	private Button FromOtherToCat;

	[SceneBind("Canvas/OtherShop/BlocksBtn")]
	private Button FromOtherToBlocks;

	[SceneBind("Canvas/OtherShop/HardBtn")]
	private Button FromOtherToHardware;

	[SceneBind("Canvas/HardwareShop")]
	private Image HardwareShop;

	[SceneBind("Canvas/CatShop")]
	private Image CatShop;

	[SceneBind("Canvas/OtherShop")]
	private Image OtherShop;

	[SceneBind("Canvas/UnreadBlocks")]
	private UnreadController UnreadBlocks;

	[SceneBind("Canvas/UnreadHardware")]
	private UnreadController UnreadHardware;

	[SceneBind("Canvas/UnreadOther")]
	private UnreadController UnreadOthers;

	[SceneBind("Canvas/UnreadCat")]
	private UnreadController UnreadCat;

	[SceneBind("Canvas/BlocksShop")]
	private Image BlocksShop;

	[SceneBind("Canvas/AttentionBought")]
	private Image AttentionBought;

	[SceneBind("Canvas/Scroll View")]
	private ScrollRect scorll;

	[SceneBind("Canvas/Label")]
	private Text Label;

	[SceneBind("Canvas/HideBought")]
	public Toggle HideBought;

	[SceneBind("Canvas/HideLocked")]
	public Toggle HideLocked;

	[SceneBind("Canvas/AttentionBought/Hide")]
	public Toggle HideAcceptBought;

	[SceneBind("Canvas/AttentionBought/Accept")]
	private Button AcceptBuy;

	[SceneBind("Canvas/AttentionBought/Cancel")]
	private Button CancelBuy;

	[SceneBind("Canvas/AttentionBought/Body")]
	private Text BodyText;

	[SceneBind("Canvas/Scroll View")]
	public ScrollRect ScrollRect;

	[SceneBind("Canvas/Scroll View")]
	public RectTransform ScrollRectRect;

	[SceneBind("Canvas/Scroll View/Scrollbar Vertical")]
	public RectTransform Vertical;

	[SceneBind("Canvas/Scroll View/Viewport/AlgoContent")]
	public RectTransform Content;

	[SceneBind("Canvas/BonusLayer/ChainSpeed")]
	private Text ChainSpeed;

	[SceneBind("Canvas/BonusLayer/BlocksSpeed")]
	private Text BlocksSpeed;

	[SceneBind("Canvas/BonusLayer/ServersCost")]
	private Text BonusServersCost;

	[SceneBind("Canvas/BonusLayer/SocketDepth")]
	private Text SocketDepth;

	private GameObject AlgoContent;

	private GameObject BuyBlock;

	public bool waitAction;

	public bool denied;

	private ContentSizeFitter sizeFilter;

	private GridLayoutGroup layoutGroup;

	private List<GameObject> buyButtons = new List<GameObject>();

	private int curShopLen;

	private List<int> hiddenBlocks = new List<int>();

	private bool startDrawMoney;

	public double _drawnMoney;

	private double _moneySpeed;

	public long maxDrawedMoney;

	private const float DRAW_TIME = 2f;

	private int skipFrames;

	private float baseBlocksHeight = -1f;

	public void OpenShop(OpenShopState state)
	{
		viewRect = Helper.GetWorldRect(View);
		ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_RoomTone_Loop", 0f);
		InitRedraw();
		HideBought.isOn = ActiveComponent.Model.P.hideBought == 1;
		HideLocked.isOn = ActiveComponent.Model.P.hideLockedShop == 1;
		switch (state)
		{
		case OpenShopState.Interier:
			ToOtherClick();
			break;
		case OpenShopState.Hardware:
			ToHardClick();
			break;
		case OpenShopState.Block:
			ToBlocksClick();
			break;
		case OpenShopState.Cat:
			ToCatClick();
			break;
		}
	}

	public void RedrawUnwatched()
	{
		ActiveComponent._controller.Redraw();
		UnreadBlocks.Num = Logic.GetUnwatchedBlocks();
		UnreadCat.Num = Logic.GetUnwatchedHats();
		UnreadHardware.Num = Logic.GetUnwatchedHardware();
		UnreadOthers.Num = Logic.GetUnwatchedOthers();
	}

	private void ToHardClick()
	{
		BonusLayer.gameObject.SetActive(value: true);
		RedrawUnwatched();
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		HardwareShop.gameObject.SetActive(value: true);
		BlocksShop.gameObject.SetActive(value: false);
		CatShop.gameObject.SetActive(value: false);
		OtherShop.gameObject.SetActive(value: false);
		scorll.verticalNormalizedPosition = 1f;
		Label.text = Logic.ColorTransform("GREEN", TextResources.GetString("HARDWARE"));
		RedrawUpgrades();
	}

	private void ToBlocksClick()
	{
		BonusLayer.gameObject.SetActive(value: true);
		RedrawUnwatched();
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		HardwareShop.gameObject.SetActive(value: false);
		BlocksShop.gameObject.SetActive(value: true);
		CatShop.gameObject.SetActive(value: false);
		OtherShop.gameObject.SetActive(value: false);
		scorll.verticalNormalizedPosition = 1f;
		Label.text = Logic.ColorTransform("GREEN", TextResources.GetString("BLOCKS"));
		RedrawBlocks();
	}

	private void ToCatClick()
	{
		BonusLayer.gameObject.SetActive(value: false);
		RedrawUnwatched();
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		BlocksShop.gameObject.SetActive(value: false);
		HardwareShop.gameObject.SetActive(value: false);
		CatShop.gameObject.SetActive(value: true);
		OtherShop.gameObject.SetActive(value: false);
		scorll.verticalNormalizedPosition = 1f;
		Label.text = Logic.ColorTransform("GREEN", TextResources.GetString("CATHATS"));
		RedrawCatHats();
	}

	private void ToOtherClick()
	{
		BonusLayer.gameObject.SetActive(value: false);
		RedrawUnwatched();
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		BlocksShop.gameObject.SetActive(value: false);
		HardwareShop.gameObject.SetActive(value: false);
		CatShop.gameObject.SetActive(value: false);
		OtherShop.gameObject.SetActive(value: true);
		scorll.verticalNormalizedPosition = 1f;
		Label.text = Logic.ColorTransform("GREEN", TextResources.GetString("OTHER"));
		RedrawOther();
	}

	private void ExitClick()
	{
		ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_RoomTone_Loop", Logic.GetModel().globalSaves.soundVolume);
		ToBlocksClick();
		ActiveComponent._controller.Redraw();
		ActiveComponent._controller._resourcesView._drawedMoney = ActiveComponent.Model.P.Money;
		ActiveComponent._controller._resourcesView.Redraw();
		ActiveComponent._controller.cat.Redraw();
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
		Logic.UpdateGameSaves();
		base.gameObject.SetActive(value: false);
	}

	public IEnumerator WaitForUserAction()
	{
		while (!waitAction)
		{
			yield return new WaitForEndOfFrame();
		}
	}

	protected override void LeftSwipe()
	{
		if (BlocksShop.gameObject.activeInHierarchy)
		{
			ToHardClick();
		}
		else if (HardwareShop.gameObject.activeInHierarchy)
		{
			ToCatClick();
		}
		else if (OtherShop.gameObject.activeInHierarchy)
		{
			ToBlocksClick();
		}
		else if (CatShop.gameObject.activeInHierarchy)
		{
			ToOtherClick();
		}
	}

	protected override void RightSwipe()
	{
		if (CatShop.gameObject.activeInHierarchy)
		{
			ToHardClick();
		}
		else if (BlocksShop.gameObject.activeInHierarchy)
		{
			ToOtherClick();
		}
		else if (HardwareShop.gameObject.activeInHierarchy)
		{
			ToBlocksClick();
		}
		else if (OtherShop.gameObject.activeInHierarchy)
		{
			ToCatClick();
		}
	}

	public void RedrawAttentionWindow(int cost)
	{
		AttentionBought.gameObject.SetActive(value: true);
		BodyText.text = TextResources.GetString("ARE YOU SURE YOU WANT SPEND") + " " + Logic.ColorTransform("MONEY", cost + "$") + "?";
		waitAction = false;
		denied = false;
	}

	private void AcceptBuyClick()
	{
		waitAction = true;
		AttentionBought.gameObject.SetActive(value: false);
	}

	private void CancelBuyClick()
	{
		waitAction = true;
		denied = false;
		AttentionBought.gameObject.SetActive(value: false);
	}

	private void HideBoughtAcceptClick(bool click)
	{
		if (click)
		{
			ActiveComponent.Model.P.HideAttentionBuy = 1;
		}
		else
		{
			ActiveComponent.Model.P.HideAttentionBuy = 0;
		}
	}

	private void HideLockedClick(bool click)
	{
		sizeFilter.enabled = true;
		layoutGroup.enabled = true;
		ScrollRect.enabled = true;
		skipFrames = 0;
		if (click)
		{
			ActiveComponent.Model.P.hideLockedShop = 1;
		}
		else
		{
			ActiveComponent.Model.P.hideLockedShop = 0;
		}
		if (CatShop.gameObject.activeSelf)
		{
			RedrawCatHats();
		}
		if (BlocksShop.gameObject.activeSelf)
		{
			RedrawBlocks();
		}
		if (HardwareShop.gameObject.activeSelf)
		{
			RedrawUpgrades();
		}
		if (OtherShop.gameObject.activeSelf)
		{
			RedrawOther();
		}
	}

	protected override void OnInit()
	{
		base.OnInit();
		dragDistance = (float)Screen.height * 5f / 100f;
		SceneBindContainer.BindObjects(this, base.transform);
		Layer.onClick.AddListener(ExitClick);
		viewRect = Helper.GetWorldRect(View);
		UnreadBlocks.Init();
		UnreadCat.Init();
		UnreadHardware.Init();
		UnreadOthers.Init();
		sizeFilter = Content.GetComponent<ContentSizeFitter>();
		layoutGroup = Content.GetComponent<GridLayoutGroup>();
		AlgoContent = GameObject.Find("AlgoContent");
		BuyBlock = Resources.Load("Prefabs/NewBuyBlock") as GameObject;
		ExitButton.onClick.AddListener(ExitClick);
		HardwareShop.gameObject.SetActive(value: false);
		CatShop.gameObject.SetActive(value: false);
		OtherShop.gameObject.SetActive(value: false);
		FromBlocksToHard.onClick.AddListener(ToHardClick);
		FromHardToBlocks.onClick.AddListener(ToBlocksClick);
		FromBlocksToCat.onClick.AddListener(ToCatClick);
		FromHardToCat.onClick.AddListener(ToCatClick);
		FromCatToBlocks.onClick.AddListener(ToBlocksClick);
		FromCatToHardware.onClick.AddListener(ToHardClick);
		FromCatToOther.onClick.AddListener(ToOtherClick);
		FromBlocksToOther.onClick.AddListener(ToOtherClick);
		FromHardToOther.onClick.AddListener(ToOtherClick);
		FromOtherToCat.onClick.AddListener(ToCatClick);
		FromOtherToBlocks.onClick.AddListener(ToBlocksClick);
		FromOtherToHardware.onClick.AddListener(ToHardClick);
		HideBought.onValueChanged.AddListener(HideBoughtClick);
		ScrollRect.onValueChanged.AddListener(delegate
		{
			UpdateVisibilityOnScreen();
		});
		AttentionBought.gameObject.SetActive(value: false);
		AcceptBuy.onClick.AddListener(AcceptBuyClick);
		CancelBuy.onClick.AddListener(CancelBuyClick);
		HideAcceptBought.onValueChanged.AddListener(HideBoughtAcceptClick);
		HideLocked.onValueChanged.AddListener(HideLockedClick);
		buyButtons.Clear();
		int num = ActiveComponent._staticData.CatCost.Count;
		foreach (CatVR promoCat in ActiveComponent._staticData.PromoCats)
		{
			if (promoCat.VisibleToPlayer && promoCat.Locked == 0)
			{
				num++;
			}
		}
		num = Mathf.Max(ActiveComponent._staticData.ShopItems.Count, num);
		num = Mathf.Max(ActiveComponent._staticData.PCUpgrades.Count, num);
		int num2 = 0;
		foreach (ConstructionBlock constructionBlock in ActiveComponent._staticData.ConstructionBlocks)
		{
			if (constructionBlock.VisibleToPlayer && constructionBlock.Extra == 1)
			{
				num2++;
			}
		}
		num = Mathf.Max(num2, num);
		for (int num3 = 0; num3 < num; num3++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(BuyBlock, AlgoContent.transform.position, AlgoContent.transform.rotation).gameObject;
			gameObject.transform.SetParent(AlgoContent.transform);
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
			gameObject.GetComponent<BuyBlock>().Init();
			buyButtons.Add(gameObject);
		}
	}

	private void UpdateVisibilityOnScreen()
	{
		if (skipFrames < 5)
		{
			return;
		}
		for (int i = 0; i < curShopLen; i++)
		{
			bool flag = !hiddenBlocks.Contains(i) && viewRect.Contains(buyButtons[i].transform.position);
			if (flag != buyButtons[i].gameObject.activeSelf)
			{
				buyButtons[i].gameObject.SetActive(flag);
			}
		}
	}

	private void HideBoughtClick(bool click)
	{
		sizeFilter.enabled = true;
		layoutGroup.enabled = true;
		ScrollRect.enabled = true;
		skipFrames = 0;
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		if (click)
		{
			ActiveComponent.Model.P.hideBought = 1;
		}
		else
		{
			ActiveComponent.Model.P.hideBought = 0;
		}
		if (CatShop.gameObject.activeSelf)
		{
			RedrawCatHats();
		}
		if (BlocksShop.gameObject.activeSelf)
		{
			RedrawBlocks();
		}
		if (HardwareShop.gameObject.activeSelf)
		{
			RedrawUpgrades();
		}
		if (OtherShop.gameObject.activeSelf)
		{
			RedrawOther();
		}
		Logic.UpdateGameSaves();
	}

	private void RedrawCatHats()
	{
		skipFrames = 0;
		sizeFilter.enabled = true;
		layoutGroup.enabled = true;
		ScrollRect.enabled = true;
		hiddenBlocks.Clear();
		ActiveComponent._controller._resourcesView.Redraw();
		int num = 0;
		for (int i = 0; i < ActiveComponent._staticData.PromoCats.Count; i++)
		{
			if (!ActiveComponent._staticData.PromoCats[i].VisibleToPlayer || ActiveComponent._staticData.PromoCats[i].Locked != 0)
			{
				continue;
			}
			GameObject gameObject = null;
			gameObject = buyButtons[num];
			if (gameObject != null)
			{
				gameObject.SetActive(value: true);
				BuyBlock component = gameObject.GetComponent<BuyBlock>();
				component.Buy.onClick.RemoveAllListeners();
				component.InitPromo(ActiveComponent._staticData.PromoCats[i]);
				if (!gameObject.activeSelf)
				{
					hiddenBlocks.Add(num);
				}
			}
			num++;
		}
		for (int j = 1; j < ActiveComponent._staticData.CatCost.Count; j++)
		{
			GameObject gameObject2 = null;
			gameObject2 = buyButtons[num];
			if (gameObject2 != null)
			{
				gameObject2.SetActive(value: true);
				BuyBlock component2 = gameObject2.GetComponent<BuyBlock>();
				component2.Buy.onClick.RemoveAllListeners();
				component2.ActiveBtn.onClick.RemoveAllListeners();
				component2.DeactiveBtn.onClick.RemoveAllListeners();
				component2.Init(ActiveComponent._staticData.CatCost[j]);
				if (gameObject2.activeSelf)
				{
					component2.Buy.onClick.AddListener(delegate
					{
						RedrawCatHats();
					});
				}
				else
				{
					hiddenBlocks.Add(num);
				}
			}
			num++;
		}
		curShopLen = num;
		HideLastBuyBlocks(num);
	}

	private void HideLastBuyBlocks(int hideId)
	{
		for (int i = hideId; i < buyButtons.Count; i++)
		{
			buyButtons[i].gameObject.SetActive(value: false);
		}
	}

	private void RedrawOther()
	{
		skipFrames = 0;
		sizeFilter.enabled = true;
		layoutGroup.enabled = true;
		ScrollRect.enabled = true;
		hiddenBlocks.Clear();
		ActiveComponent._controller._resourcesView.Redraw();
		for (int i = 0; i < ActiveComponent._staticData.ShopItems.Count; i++)
		{
			GameObject gameObject = buyButtons[i];
			if (!(gameObject != null))
			{
				continue;
			}
			gameObject.SetActive(value: true);
			BuyBlock component = gameObject.GetComponent<BuyBlock>();
			component.Buy.onClick.RemoveAllListeners();
			component.ActiveBtn.onClick.RemoveAllListeners();
			component.DeactiveBtn.onClick.RemoveAllListeners();
			component.Init(ActiveComponent._staticData.ShopItems[i]);
			if (gameObject.activeSelf)
			{
				component.Buy.onClick.AddListener(delegate
				{
					RedrawOther();
				});
				component.ActiveBtn.onClick.AddListener(delegate
				{
					RedrawOther();
				});
				component.DeactiveBtn.onClick.AddListener(delegate
				{
					RedrawOther();
				});
			}
			else
			{
				hiddenBlocks.Add(i);
			}
		}
		curShopLen = ActiveComponent._staticData.ShopItems.Count;
		HideLastBuyBlocks(ActiveComponent._staticData.ShopItems.Count);
	}

	private void RedrawStats()
	{
		SocketDepth.text = TextResources.GetString("SOCKETDEPTHINTERFACE") + " " + Logic.ColorTransform("WARNING", (ActiveComponent.Model.P.upgradeStats.SocketDepthBonus + ActiveComponent._staticData.Settings.SocketDepth).ToString());
		BonusServersCost.text = TextResources.GetString("SERVERSCOSTPERCENT") + " " + Logic.ColorTransform("MONEY", Mathf.CeilToInt(100f * (1f - ActiveComponent.Model.P.upgradeStats.ServersCostBonus)) + "%");
		ChainSpeed.text = TextResources.GetString("CHAINSPEEDPERCENT") + " " + Logic.ColorTransform("TIME", ((float)Math.Round(ActiveComponent._staticData.Settings.TimeOnLine / (1f + ActiveComponent.Model.P.upgradeStats.ChainSpeedBonus), 3)).ToString()) + " " + TextResources.GetString("SEC");
		BlocksSpeed.text = TextResources.GetString("BLOCKSSPEEDPERCENT") + " " + Logic.ColorTransform("TIME", Mathf.CeilToInt(100f + 100f * ActiveComponent.Model.P.upgradeStats.BlocksSpeedBonus) + "%");
	}

	private void RedrawUpgrades()
	{
		RedrawStats();
		skipFrames = 0;
		sizeFilter.enabled = true;
		layoutGroup.enabled = true;
		ScrollRect.enabled = true;
		hiddenBlocks.Clear();
		ActiveComponent._controller.Redraw();
		for (int i = 0; i < ActiveComponent._staticData.PCUpgrades.Count; i++)
		{
			GameObject gameObject = null;
			gameObject = buyButtons[i];
			if (!(gameObject != null))
			{
				continue;
			}
			gameObject.SetActive(value: true);
			BuyBlock component = gameObject.GetComponent<BuyBlock>();
			component.Buy.onClick.RemoveAllListeners();
			component.ActiveBtn.onClick.RemoveAllListeners();
			component.DeactiveBtn.onClick.RemoveAllListeners();
			component.Init(ActiveComponent._staticData.PCUpgrades[i]);
			if (gameObject.activeSelf)
			{
				component.Buy.onClick.AddListener(delegate
				{
					RedrawUpgrades();
				});
				component.ActiveBtn.onClick.AddListener(delegate
				{
					RedrawUpgrades();
				});
				component.DeactiveBtn.onClick.AddListener(delegate
				{
					RedrawUpgrades();
				});
			}
			else
			{
				hiddenBlocks.Add(i);
			}
		}
		curShopLen = ActiveComponent._staticData.PCUpgrades.Count;
		HideLastBuyBlocks(ActiveComponent._staticData.PCUpgrades.Count);
	}

	public void RedrawBlocks()
	{
		RedrawStats();
		skipFrames = 0;
		hiddenBlocks.Clear();
		sizeFilter.enabled = true;
		layoutGroup.enabled = true;
		ScrollRect.enabled = true;
		RedrawUnwatched();
		ActiveComponent._controller._resourcesView.Redraw();
		int num = 0;
		for (int i = 0; i < ActiveComponent._staticData.ConstructionBlocks.Count; i++)
		{
			if (ActiveComponent._staticData.ConstructionBlocks[i].Extra != 1 || !ActiveComponent._staticData.ConstructionBlocks[i].VisibleToPlayer)
			{
				continue;
			}
			GameObject gameObject = null;
			gameObject = buyButtons[num];
			if (gameObject != null)
			{
				gameObject.SetActive(value: true);
				BuyBlock component = gameObject.GetComponent<BuyBlock>();
				component.Buy.onClick.RemoveAllListeners();
				component.Init(ActiveComponent._staticData.ConstructionBlocks[i]);
				if (gameObject.activeSelf)
				{
					component.Buy.onClick.AddListener(delegate
					{
						RedrawBlocks();
					});
				}
				else
				{
					hiddenBlocks.Add(num);
				}
			}
			num++;
		}
		curShopLen = num;
		HideLastBuyBlocks(num);
	}

	public void InitRedraw()
	{
		_drawnMoney = ActiveComponent.Model.P.Money;
		ActiveComponent.Model.drawedMoneySpeed = 1f;
		startDrawMoney = false;
		Redraw();
	}

	public void Redraw()
	{
		if (ActiveComponent.Model.drawedMoneySpeed > 0f)
		{
			Money.text = Logic.ColorTransform("MONEY", (int)_drawnMoney + "$");
		}
		else
		{
			Money.text = Logic.ColorTransform("BAD", (int)_drawnMoney + "$");
		}
		startDrawMoney = true;
	}

	private void Update()
	{
		if (!base.IsInited)
		{
			return;
		}
		skipFrames++;
		if (skipFrames == 5)
		{
			ScrollRect.enabled = Vertical.gameObject.activeSelf;
			sizeFilter.enabled = false;
			layoutGroup.enabled = false;
		}
		if (ActiveComponent.Program.joyInput.areaMove && Vertical.gameObject.activeSelf)
		{
			Vector3 areaMoveDelta = ActiveComponent.Program.joyInput.areaMoveDelta;
			areaMoveDelta.x = 0f;
			ScrollRect.content.transform.position += Logic.ModifySliderMoveDelta(areaMoveDelta);
			UpdateVisibilityOnScreen();
		}
		if (ActiveComponent.Model != null && startDrawMoney)
		{
			_drawnMoney = ActiveComponent.Model.drawnMoney;
			Redraw();
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (AttentionBought.gameObject.activeSelf)
			{
				CancelBuyClick();
			}
			else
			{
				ExitClick();
			}
		}
		if (Input.GetKeyDown(KeyCode.Return) && AttentionBought.gameObject.activeSelf)
		{
			AcceptBuyClick();
		}
		if (ActiveComponent.Program.joyInput.bUp)
		{
			if (ActiveComponent.Model.KeyBoardTicks <= 0)
			{
				if (AttentionBought.gameObject.activeSelf)
				{
					CancelBuyClick();
				}
				else
				{
					ExitClick();
				}
			}
			return;
		}
		CheckJoyConInput();
		if (ActiveComponent.Program.joyInput.bUp && ActiveComponent.Model.KeyBoardTicks <= 0)
		{
			if (AttentionBought.gameObject.activeSelf)
			{
				CancelBuyClick();
			}
			else
			{
				ExitClick();
			}
		}
	}
}
