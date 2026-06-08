using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class UulaaShopScreen : ScrollContainerScreen
{
	public enum State
	{
		Hidden = 0,
		SlideIn = 1,
		Normal = 2,
		BuyConfirmation = 3,
		OpeningTreasures = 4,
		SlideOutRestock = 5,
		SlideOut = 6,
		Leaving = 7,
		Done = 8
	}

	public AsciiString crystalCountLabel;

	public MultiSlotRow rowPrefab;

	public GateShopSlot bigSlotPrefab;

	public GateShopSlot smallSlotPrefab;

	public SpecialOfferShopSlot specialOfferSlot;

	public AsciiSprite doubleKiUpsell;

	public GateShopBuyConfirmationDialog buyConfirmationDialog;

	public OpenTreasureDialog openTreasureDialog;

	public DialogButton backButton;

	public AsciiString restockHeader;

	public AsciiString restockTime;

	public ShopHiddenSlot hiddenSlotCover0;

	public ShopHiddenSlot hiddenSlotCover1;

	public ShopHiddenSlot hiddenSlotCover2;

	public ShopHiddenSlot hiddenSlotCover3;

	public ShopHiddenSlot hiddenSlotCover4;

	public AsciiString pendingPurchasesLabel;

	public AsciiSprite loadingIcon;

	public Stack<GateShopSlot> bigSlotPool = new Stack<GateShopSlot>();

	public Stack<GateShopSlot> smallSlotPool = new Stack<GateShopSlot>();

	private ShopData.ShopState shopState;

	private int stateElapsedTics;

	private int cameraStartX;

	private float backButtonSlideX;

	private float containerSlideX;

	private readonly float UI_POS_OUTSIDE = 90f;

	private bool firstTimeToday = true;

	private bool showHiddenSlotCovers;

	private int crystalCount;

	private int targetCrystalCount;

	private int cooldownUpdateInAppPurchases;

	public static UulaaShopScreen singleton;

	public State currentState { get; private set; }

	public event Action OnDailyCrystal;

	public event Action OnShopDone;

	public void Show()
	{
		if (currentState == State.Hidden || currentState == State.Leaving)
		{
			Setup("uulaa_shop");
			UpdateContents();
			SetState(State.SlideIn);
			PanCameraForShop();
		}
	}

	public void Hide()
	{
		SetState(State.Hidden);
	}

	public void PanCameraForShop()
	{
		GameCamera gameCamera = GameStates.Singleton.level.gameCamera;
		cameraStartX = gameCamera.PositionX;
		gameCamera.SetupLerpToPos(26, 0, 13, gameCamera.playLerpSpeed);
	}

	public void PanCameraForUUlaa()
	{
		GameCamera gameCamera = GameStates.Singleton.level.gameCamera;
		gameCamera.SetupLerpToPos(cameraStartX, 0, 13, gameCamera.playLerpSpeed);
	}

	private void SetState(State newState)
	{
		switch (newState)
		{
		case State.SlideIn:
			backButtonSlideX = 0f - UI_POS_OUTSIDE;
			containerSlideX = UI_POS_OUTSIDE;
			break;
		case State.Normal:
			backButtonSlideX = 0f;
			containerSlideX = 0f;
			if (showHiddenSlotCovers && currentState == State.SlideIn)
			{
				OpenHiddenSlots();
			}
			break;
		case State.SlideOut:
			PanCameraForUUlaa();
			break;
		}
		currentState = newState;
		stateElapsedTics = 0;
	}

	private void Update()
	{
		if (currentState == State.SlideIn)
		{
			backButtonSlideX = Mathf.Lerp(backButtonSlideX, 0f, Time.deltaTime * 8f);
			containerSlideX = Mathf.Lerp(containerSlideX, 0f, Time.deltaTime * 8f);
		}
		else if (currentState == State.SlideOutRestock || currentState == State.SlideOut)
		{
			backButtonSlideX = Mathf.Lerp(backButtonSlideX, 0f - UI_POS_OUTSIDE, Time.deltaTime * 8f);
			containerSlideX = Mathf.Lerp(containerSlideX, UI_POS_OUTSIDE, Time.deltaTime * 8f);
		}
		if (currentState == State.Normal && Input.GetKeyDown(KeyCode.Escape))
		{
			HandleBackButtonPressed(backButton);
		}
	}

	public override void UpdateTic()
	{
		if (currentState == State.Hidden || currentState == State.Done)
		{
			return;
		}
		stateElapsedTics++;
		if (currentState == State.SlideIn && stateElapsedTics >= 20)
		{
			SetState(State.Normal);
		}
		else if (currentState == State.SlideOutRestock && stateElapsedTics >= 12)
		{
			Setup(shopState.shopId);
			UpdateContents();
			SetState(State.SlideIn);
		}
		else if (currentState == State.Normal)
		{
			base.UpdateTic();
			if (showHiddenSlotCovers)
			{
				hiddenSlotCover0.UpdateTic();
				hiddenSlotCover1.UpdateTic();
				hiddenSlotCover2.UpdateTic();
			}
			if (shopState.specialOffer != null)
			{
				specialOfferSlot.UpdateTic();
			}
			string shopId = shopState.shopId;
			int num = 0;
			if (num < ShopController.singleton.treasuresToOpen.Count)
			{
				string treasureId = ShopController.singleton.treasuresToOpen[num];
				ShopController.singleton.treasuresToOpen.RemoveAt(num);
				List<ItemData.Element> possibleElements = TreasureFactory.singleton.MakeListOfPossibleElements();
				TreasureItem treasureItem = TreasureFactory.singleton.MakeTreasureItem(shopId, treasureId, possibleElements);
				if (treasureItem.itemsInTreasure.Length != 0 && treasureItem.itemsInTreasure[0].id == "ki_crystal")
				{
					ShopData shopById = ShopController.singleton.GetShopById(shopId);
					if (shopById.entriesDict.ContainsKey("lost_treasure"))
					{
						ShopData.Entry entry = shopById.entriesDict["lost_treasure"];
						treasureItem.itemsInTreasure[0].countMin = entry.baseCost.GetValue() - 5;
						treasureItem.itemsInTreasure[0].countMax = entry.baseCost.GetValue() + 5;
					}
				}
				openTreasureDialog.Setup(treasureItem);
				openTreasureDialog.Show();
				ShopController.FireItemPurchased(treasureItem);
				SetState(State.OpeningTreasures);
			}
		}
		else if (currentState == State.BuyConfirmation)
		{
			buyConfirmationDialog.UpdateTic();
			if (buyConfirmationDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				UpdateContents();
				SetState(State.Normal);
			}
		}
		else if (currentState == State.OpeningTreasures)
		{
			openTreasureDialog.UpdateTic();
			if (openTreasureDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				UpdateContents();
				SetState(State.Normal);
			}
		}
		UpdateInAppPurchases();
		UpdateCrystalCountLabel();
		backButton.UpdateTic();
		UpdateRestockTime();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (currentState == State.Hidden || currentState == State.Done)
		{
			return;
		}
		scrollContainer.PositionY = Mathf.Max(1, (r.height - scrollContainer.Height) / 2);
		if (shopState.specialOffer != null)
		{
			scrollContainer.PositionY += specialOfferSlot.Height - 1;
		}
		bool num = r.width <= 59;
		if (num)
		{
			offsetX--;
		}
		int num2 = Mathf.RoundToInt(containerSlideX);
		base.Draw(r, offsetX + num2, offsetY);
		if (showHiddenSlotCovers)
		{
			hiddenSlotCover0.Draw(r, offsetX + num2, offsetY + scrollContainer.PositionY);
			hiddenSlotCover1.Draw(r, offsetX + num2, offsetY + scrollContainer.PositionY);
			hiddenSlotCover2.Draw(r, offsetX + num2, offsetY + scrollContainer.PositionY);
		}
		if (shopState.specialOffer != null)
		{
			int num3 = scrollContainer.lastContainerDrawY - specialOfferSlot.Height + 1;
			num3 -= scrollContainer.DisplayScrollY;
			specialOfferSlot.Draw(r, scrollContainer.lastContainerDrawX, num3);
		}
		if (num)
		{
			offsetX += 2;
		}
		backButton.Draw(r, offsetX + Mathf.RoundToInt(backButtonSlideX), offsetY);
		if (num)
		{
			offsetX++;
		}
		restockHeader.Draw(r, offsetX + Mathf.RoundToInt(backButtonSlideX), r.height - 3);
		restockTime.Draw(r, offsetX + Mathf.RoundToInt(backButtonSlideX), r.height - 2);
		if (doubleKiUpsell.enabled && currentState >= State.Normal && hiddenSlotCover4.IsDisabled())
		{
			MultiSlotRow multiSlotRow = rows[rows.Count - 1] as MultiSlotRow;
			if (multiSlotRow != null)
			{
				GateShopSlot gateShopSlot = multiSlotRow.slots[0] as GateShopSlot;
				if (gateShopSlot != null)
				{
					doubleKiUpsell.Draw(r, gateShopSlot.lastDrawnX, gateShopSlot.lastDrawnY);
				}
			}
		}
		if (num)
		{
			offsetX -= 2;
		}
		if (currentState == State.BuyConfirmation)
		{
			buyConfirmationDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (currentState == State.OpeningTreasures)
		{
			openTreasureDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		int offsetX2 = r.width >> 1;
		crystalCountLabel.Draw(r, offsetX2, 0);
		if (InAppPurchaseController.singleton.HasPendingPurchases())
		{
			offsetX2 = backButton.lastDrawnX;
			loadingIcon.Draw(r, offsetX2, 0);
			pendingPurchasesLabel.Draw(r, offsetX2 + 3, 0);
		}
	}

	public void Setup(string shopId)
	{
		shopState = ShopController.singleton.GetShopState(shopId);
		showHiddenSlotCovers = firstTimeToday && shopState.totalDaysOpen == 0;
		if (GameStates.Singleton.level.QuestData != null)
		{
			QuestController.singleton.MarkAsPlayed(GameStates.Singleton.level.QuestData.id);
		}
	}

	public override void UpdateContents()
	{
		UpdateCrystalCount();
		RemoveSlotCallbacks();
		for (int i = 0; i < rows.Count; i++)
		{
			MultiSlotRow multiSlotRow = rows[i] as MultiSlotRow;
			for (int j = 0; j < multiSlotRow.slots.Count; j++)
			{
				GateShopSlot gateShopSlot = multiSlotRow.slots[j] as GateShopSlot;
				if (gateShopSlot.Width == smallSlotPrefab.Width)
				{
					smallSlotPool.Push(gateShopSlot);
				}
				else
				{
					bigSlotPool.Push(gateShopSlot);
				}
			}
			multiSlotRow.slots.Clear();
		}
		RecycleAllRows();
		int num = 1;
		MultiSlotRow multiSlotRow2 = null;
		for (int k = 0; k < shopState.fullEntries.Length; k++)
		{
			ShopData.Entry entry = shopState.fullEntries[k];
			GateShopSlot gateShopSlot2 = (entry.isSmallSlot ? GetSmallSlot() : GetBigSlot());
			gateShopSlot2.SetContent(entry);
			gateShopSlot2.OnPressed += HandleOnSlotPressed;
			gateShopSlot2.OnSecondaryPressed += HandleOnSlotPressed;
			if (multiSlotRow2 == null || multiSlotRow2.IsFull(gateShopSlot2.Width))
			{
				multiSlotRow2 = AddRowFromPrefab(rowPrefab) as MultiSlotRow;
				num += multiSlotRow2.Height - 1;
			}
			multiSlotRow2.AddSlot(gateShopSlot2);
		}
		if (shopState.specialOffer != null)
		{
			specialOfferSlot.SetContent(shopState.specialOffer);
			num += specialOfferSlot.Height - 1;
		}
		doubleKiUpsell.enabled = false;
		scrollContainer.Height = num;
	}

	private void UpdateCrystalCount(bool animate = false)
	{
		targetCrystalCount = 0;
		Item firstItemWithId = Inventory.Singleton.GetFirstItemWithId("ki_crystal");
		if (firstItemWithId != null)
		{
			targetCrystalCount = firstItemWithId.count;
		}
		if (!animate)
		{
			crystalCount = targetCrystalCount;
			UpdateCrystalCountLabel();
		}
	}

	private void UpdateCrystalCountLabel()
	{
		if (crystalCount > targetCrystalCount)
		{
			crystalCount--;
		}
		else if (crystalCount < targetCrystalCount)
		{
			if (targetCrystalCount - crystalCount > 1000)
			{
				crystalCount += 100;
			}
			else if (targetCrystalCount - crystalCount > 100)
			{
				crystalCount += 10;
			}
			else
			{
				crystalCount++;
			}
		}
		string text = Utils.FormatNumber(crystalCount);
		crystalCountLabel.SetValue("♦ " + text);
	}

	private void UpdateRestockTime()
	{
		int num = (int)shopState.RestockSecondsRemaining();
		restockTime.SetValue(Utils.FormatTimeCasual(num));
		if (num <= 0 && currentState == State.Normal && !IsRemnantOfFive())
		{
			SetState(State.SlideOutRestock);
		}
	}

	private void UpdateInAppPurchases()
	{
		if (--cooldownUpdateInAppPurchases > 0 || !InAppPurchaseController.singleton.HasPurchasesToDeliver())
		{
			return;
		}
		cooldownUpdateInAppPurchases = 90;
		int num = 0;
		bool flag = false;
		ShopData shopById = ShopController.singleton.GetShopById("uulaa_shop");
		List<Product> pendingDeliveries = InAppPurchaseController.singleton.GetPendingDeliveries();
		for (int num2 = pendingDeliveries.Count - 1; num2 >= 0; num2--)
		{
			Product product = pendingDeliveries[num2];
			string id = product.definition.id;
			if (shopById.entriesDict.ContainsKey(id))
			{
				ShopData.Entry entry = shopById.entriesDict[id];
				num += entry.copies.GetValue();
				InAppPurchaseController.singleton.MarkPurchaseAsDelivered(product);
				flag = true;
			}
		}
		if (num > 0)
		{
			Item item = Inventory.Singleton.MakeReward("ki_crystal", 1);
			Inventory.Singleton.GainItem(item, num);
			UpdateCrystalCount(animate: true);
		}
		if (flag)
		{
			SfxController.singleton.Play("buy");
			GameStates.Singleton.TryToSaveProgress();
		}
	}

	private void HandleOnSlotPressed(DialogButton button)
	{
		GateShopSlot gateShopSlot = button as GateShopSlot;
		if (gateShopSlot.entry.id == "ki_crystal")
		{
			Item item = Inventory.Singleton.MakeReward("ki_crystal", 1, ItemData.Element.Stone, 0);
			Inventory.Singleton.GainItem(item);
			++gateShopSlot.entry.amountPurchased;
			SfxController.singleton.Play("buy");
			UpdateContents();
			this.OnDailyCrystal?.Invoke();
		}
		else
		{
			SetState(State.BuyConfirmation);
			buyConfirmationDialog.Setup(gateShopSlot.entry);
			buyConfirmationDialog.Show();
		}
	}

	private void HandleSpecialOfferPressed(DialogButton button)
	{
		SetState(State.BuyConfirmation);
		GateShopSlot gateShopSlot = button as GateShopSlot;
		buyConfirmationDialog.Setup(gateShopSlot.entry);
		buyConfirmationDialog.Show();
	}

	private void HandleTreasurePurchased(string treasureId)
	{
		UpdateCrystalCount(animate: true);
		ShopController.singleton.treasuresToOpen.Add(treasureId);
	}

	private void HandleItemPurchased(Item item)
	{
		UpdateCrystalCount(animate: true);
		ShopController.FireItemPurchased(item);
	}

	private void HandleBackButtonPressed(DialogButton btn)
	{
		this.OnShopDone?.Invoke();
		if (IsRemnantOfFive())
		{
			SetState(State.SlideOut);
		}
		else
		{
			SetState(State.Leaving);
			GameStates.Singleton.LeaveQuest();
		}
		firstTimeToday = false;
		showHiddenSlotCovers = false;
	}

	private GateShopSlot GetBigSlot()
	{
		if (bigSlotPool.Count > 0)
		{
			return bigSlotPool.Pop();
		}
		GateShopSlot gateShopSlot = UnityEngine.Object.Instantiate(bigSlotPrefab);
		gateShopSlot.transform.parent = base.transform;
		return gateShopSlot;
	}

	private GateShopSlot GetSmallSlot()
	{
		if (smallSlotPool.Count > 0)
		{
			return smallSlotPool.Pop();
		}
		GateShopSlot gateShopSlot = UnityEngine.Object.Instantiate(smallSlotPrefab);
		gateShopSlot.transform.parent = base.transform;
		return gateShopSlot;
	}

	private bool IsRemnantOfFive()
	{
		return GameStates.Singleton.level.QuestData.id == "uulaa_shop_rem5";
	}

	private void OpenHiddenSlots()
	{
		hiddenSlotCover0.Show(0);
		hiddenSlotCover1.Show(20);
		hiddenSlotCover2.Show(40);
	}

	protected override void OnDestroy()
	{
		RemoveSlotCallbacks();
		buyConfirmationDialog.OnTreasuresPurchased -= HandleTreasurePurchased;
		buyConfirmationDialog.OnItemPurchased -= HandleItemPurchased;
		backButton.OnPressed -= HandleBackButtonPressed;
		base.OnDestroy();
	}

	private void RemoveSlotCallbacks()
	{
		for (int i = 0; i < rows.Count; i++)
		{
			MultiSlotRow multiSlotRow = rows[i] as MultiSlotRow;
			for (int j = 0; j < multiSlotRow.slots.Count; j++)
			{
				GateShopSlot obj = multiSlotRow.slots[j] as GateShopSlot;
				obj.OnPressed -= HandleOnSlotPressed;
				obj.OnSecondaryPressed -= HandleOnSlotPressed;
			}
		}
	}

	private void Awake()
	{
		singleton = this;
		specialOfferSlot.OnPressed += HandleSpecialOfferPressed;
		buyConfirmationDialog.OnTreasuresPurchased += HandleTreasurePurchased;
		buyConfirmationDialog.OnItemPurchased += HandleItemPurchased;
		backButton.OnPressed += HandleBackButtonPressed;
	}

	private void Start()
	{
		crystalCountLabel.SetColorMask(new List<Color> { Color.magenta });
	}
}
