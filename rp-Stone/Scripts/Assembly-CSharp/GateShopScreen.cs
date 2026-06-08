using System;
using System.Collections.Generic;
using System.Globalization;
using SafeTypes;
using UnityEngine;
using UnityEngine.Purchasing;

public class GateShopScreen : ScrollContainerScreen
{
	public enum State
	{
		Normal = 0,
		ShopKeeperIntro = 1,
		ShopKeeperReward = 2,
		ShopKeeperBigHead = 3,
		ShopKeeperLoyalCustomer = 4,
		ShopKeeperGhostSlayer1 = 5,
		ShopKeeperGhostSlayer2 = 6,
		ShopKeeperGhostSlayer3 = 7,
		ShopKeeperTitanicBundle = 8,
		LimitedTimeBuyConfirmation = 9,
		BuyConfirmation = 10,
		OpeningTreasures = 11,
		FailedToShowAd = 12
	}

	public MultiSlotRow rowPrefab;

	public GateShopSlot bigSlotPrefab;

	public GateShopSlot smallSlotPrefab;

	public SpecialOfferShopSlot specialOfferSlot;

	public TwoChoiceDialog genericInfoDialog;

	public GateShopBuyConfirmationDialog buyConfirmationDialog;

	private LimitedTimeBundleConfirmationDialog activeBundleConfirmationDialog;

	public OpenTreasureDialog openTreasureDialogPrefab;

	public ShopKeeper shopKeeper;

	public AsciiString pendingPurchasesLabel;

	public AsciiSprite loadingIcon;

	public Stack<GateShopSlot> bigSlotPool = new Stack<GateShopSlot>();

	public Stack<GateShopSlot> smallSlotPool = new Stack<GateShopSlot>();

	private ShopData.ShopState shopState;

	private bool hasWatchToEarn;

	private LimitedTimeBundleSlot limitedTimeBundleSlot;

	private LimitedTimeBundleConfirmationDialog limitedTimeBundleConfirmationDialog;

	private bool isLimitedTimeSlotSmall;

	private LimitedTimeBundleSlot beginnerBundleSlot;

	private LimitedTimeBundleConfirmationDialog beginnerBundleConfirmationDialog;

	private int beginnerBundleSlotReplacementColumn;

	private static string LAST_WATCH_TO_EARN_KEY = "last_watch_to_earn";

	private static int WATCH_TO_EARN_INTERVAL = 60;

	private string lastPreloadActiveBundleId;

	private string lastPreloadBeginnerBundleId;

	private float f_containerX;

	private float f_containerTargetX;

	private int cooldownUpdateInAppPurchases;

	private List<Item> itemsToPickup = new List<Item>();

	private List<int> itemCountToPickup = new List<int>();

	public OpenTreasureDialog openTreasureDialog { get; private set; }

	public int moneyHudOffsetX { get; private set; }

	public State currentState { get; private set; }

	public void Preload()
	{
		ShopData.LimitedTimeBundle potentialActiveBundle = LimitedTimeBundlesController.singleton.GetPotentialActiveBundle("mushroom_shop");
		if (potentialActiveBundle != null && lastPreloadActiveBundleId != potentialActiveBundle.id)
		{
			lastPreloadActiveBundleId = potentialActiveBundle.id;
			LimitedTimeBundleFactory.Preload(lastPreloadActiveBundleId);
		}
		potentialActiveBundle = LimitedTimeBundlesController.singleton.GetPotentialBeginnerBundle("mushroom_shop");
		if (potentialActiveBundle != null && lastPreloadBeginnerBundleId != potentialActiveBundle.id)
		{
			lastPreloadBeginnerBundleId = potentialActiveBundle.id;
			LimitedTimeBundleFactory.Preload(lastPreloadBeginnerBundleId);
		}
	}

	public override void Activate()
	{
		base.Activate();
		ShopData.LimitedTimeBundle bundle = LimitedTimeBundlesController.singleton.GetActiveSuperBundle("mushroom_shop");
		if (limitedTimeBundleSlot != null && limitedTimeBundleSlot.bundleData != bundle)
		{
			limitedTimeBundleSlot.OnPressed -= HandleLimitedTimeBundlePressed;
			limitedTimeBundleConfirmationDialog.OnTreasuresPurchased -= HandleTreasurePurchased;
			limitedTimeBundleSlot = null;
			limitedTimeBundleConfirmationDialog = null;
		}
		if (limitedTimeBundleSlot == null && bundle != null)
		{
			LimitedTimeBundleFactory.InstantiateSlot(bundle.id, base.transform, delegate(LimitedTimeBundleSlot slot, bool isSmallSlot)
			{
				limitedTimeBundleSlot = slot;
				limitedTimeBundleSlot.bundleData = bundle;
				limitedTimeBundleSlot.OnPressed += HandleLimitedTimeBundlePressed;
				isLimitedTimeSlotSmall = isSmallSlot;
			});
			LimitedTimeBundleFactory.InstantiateConfirmationDialog(bundle.id, base.transform, delegate(LimitedTimeBundleConfirmationDialog dialog)
			{
				limitedTimeBundleConfirmationDialog = dialog;
				limitedTimeBundleConfirmationDialog.OnTreasuresPurchased += HandleTreasurePurchased;
			});
		}
		ShopData.LimitedTimeBundle beginnerBundle = LimitedTimeBundlesController.singleton.GetActiveBeginnerBundle("mushroom_shop");
		if (beginnerBundleSlot != null && beginnerBundleSlot.bundleData != beginnerBundle)
		{
			beginnerBundleSlot.OnPressed -= HandleBeginnerBundlePressed;
			beginnerBundleConfirmationDialog.OnTreasuresPurchased -= HandleTreasurePurchased;
			beginnerBundleSlot = null;
			beginnerBundleConfirmationDialog = null;
		}
		if (beginnerBundle != null)
		{
			LimitedTimeBundleFactory.InstantiateSlot(beginnerBundle.id, base.transform, delegate(LimitedTimeBundleSlot slot, bool isSmallSlot)
			{
				beginnerBundleSlot = slot;
				beginnerBundleSlot.bundleData = beginnerBundle;
				beginnerBundleSlot.OnPressed += HandleBeginnerBundlePressed;
				beginnerBundleSlotReplacementColumn = 1;
			});
			LimitedTimeBundleFactory.InstantiateConfirmationDialog(beginnerBundle.id, base.transform, delegate(LimitedTimeBundleConfirmationDialog dialog)
			{
				beginnerBundleConfirmationDialog = dialog;
				beginnerBundleConfirmationDialog.OnTreasuresPurchased += HandleTreasurePurchased;
			});
		}
		if (ShopController.singleton.hasSeenShopkeeper)
		{
			MusicController.singleton.Play("shop");
			if (bundle != null)
			{
				if (bundle is GhostSlayerBundleEntryData ghostSlayerBundleEntryData)
				{
					if (!ghostSlayerBundleEntryData.hasSeenGhostSlayer)
					{
						ghostSlayerBundleEntryData.hasSeenGhostSlayer = true;
						if (!QuestController.singleton.IsAvailable("icy_ridge"))
						{
							if (QuestController.singleton.IsAvailable("undead_crypt"))
							{
								ghostSlayerBundleEntryData.HasSeenReminder = true;
								SetState(State.ShopKeeperGhostSlayer3);
							}
							else
							{
								SetState(State.ShopKeeperGhostSlayer1);
							}
							return;
						}
					}
					else if (!ghostSlayerBundleEntryData.HasSeenReminder && (QuestController.singleton.IsAvailable("undead_crypt") || bundle.GetRemainingSeconds() <= LimitedTimeBundlesController.TIME_48_HOURS_IN_SECONDS))
					{
						ghostSlayerBundleEntryData.HasSeenReminder = true;
						SetState(State.ShopKeeperGhostSlayer2);
						return;
					}
				}
				if (bundle is TitanicBundleEntryData { hasSeenTitanicBundle: false } titanicBundleEntryData)
				{
					titanicBundleEntryData.hasSeenTitanicBundle = true;
					SetState(State.ShopKeeperTitanicBundle);
					return;
				}
			}
			if (HeroSettings.bigHeadEnabled && !ProgressFlags.GetFlag("shop_keeper_big_head"))
			{
				ProgressFlags.SetFlag("shop_keeper_big_head");
				SetState(State.ShopKeeperBigHead);
			}
			else
			{
				SetState(State.Normal);
			}
		}
		else
		{
			MusicController.singleton.FadeToSilence();
			MusicController.singleton.Play("fire_loop");
			SetState(State.ShopKeeperIntro);
		}
	}

	private void SetState(State newState)
	{
		switch (newState)
		{
		case State.ShopKeeperIntro:
			shopKeeper.ActivateIntro();
			break;
		case State.ShopKeeperReward:
			MusicController.singleton.Play("shop");
			shopKeeper.ActivateReward();
			break;
		case State.ShopKeeperBigHead:
			shopKeeper.ActivateBigHead();
			break;
		case State.ShopKeeperLoyalCustomer:
			shopKeeper.ActivateLoyalCustomer();
			break;
		case State.ShopKeeperGhostSlayer1:
		{
			int defeatedAntCount = Mathf.Max(24, LimitedTimeBundlesController.singleton.antsKilled);
			shopKeeper.ActivateGhostSlayer_Case1_Intro(defeatedAntCount);
			break;
		}
		case State.ShopKeeperGhostSlayer2:
			shopKeeper.ActivateGhostSlayer_Case2_Reminder();
			break;
		case State.ShopKeeperGhostSlayer3:
			shopKeeper.ActivateGhostSlayer_Case3_SkippedCases1n2();
			break;
		case State.ShopKeeperTitanicBundle:
			shopKeeper.ActivateTitanicBundle_Intro();
			break;
		case State.FailedToShowAd:
			genericInfoDialog.SetMessage("tid_shop_7_video_failed");
			genericInfoDialog.Show();
			break;
		}
		currentState = newState;
	}

	public bool ShouldShowMoneyHUD()
	{
		if (currentState != State.Normal && (currentState != State.LimitedTimeBuyConfirmation || activeBundleConfirmationDialog.CurrentState == DialogNineSlice.State.Idle))
		{
			return currentState >= State.BuyConfirmation;
		}
		return true;
	}

	public override void UpdateTic()
	{
		CrashReportController.singleton.AddBreadcrumb("shop:" + currentState);
		if (currentState == State.Normal)
		{
			base.UpdateTic();
			if (shopState.specialOffer != null)
			{
				specialOfferSlot.UpdateTic();
			}
			if (limitedTimeBundleSlot != null && limitedTimeBundleConfirmationDialog != null)
			{
				limitedTimeBundleSlot.UpdateTic();
			}
			if (beginnerBundleSlot != null && beginnerBundleConfirmationDialog != null)
			{
				beginnerBundleSlot.UpdateTic();
			}
			if (ShopController.singleton.treasuresToOpen.Count > 0)
			{
				string shopId = shopState.shopId;
				for (int i = 0; i < ShopController.singleton.treasuresToOpen.Count; i++)
				{
					string text = ShopController.singleton.treasuresToOpen[i];
					if (text != "lost")
					{
						ShopController.singleton.treasuresToOpen.RemoveAt(i);
						List<ItemData.Element> possibleElements = TreasureFactory.singleton.MakeListOfPossibleElements();
						TreasureFactory.singleton.SetRandom(Utils.random);
						TreasureItem treasureItem = TreasureFactory.singleton.MakeTreasureItem(shopId, text, possibleElements);
						openTreasureDialog.Setup(treasureItem);
						openTreasureDialog.Show();
						ShopController.FireItemPurchased(treasureItem);
						SetState(State.OpeningTreasures);
						break;
					}
				}
			}
			else if (ShopController.singleton.itemsToGrant.Count > 0)
			{
				Item item = ShopController.singleton.itemsToGrant[0];
				ShopController.singleton.itemsToGrant.RemoveAt(0);
				int count = item.count;
				item = Inventory.Singleton.AddItem(item, count);
				SequentialPopupManager.singleton.ScheduleItemFound(item, count);
				ItemData.Rarity.Type rarityType = item.GetRarityType();
				if (item.isShiny || rarityType >= ItemData.Rarity.Type.Legendary)
				{
					SfxController.singleton.Play("treasure_item_red");
					return;
				}
				switch (rarityType)
				{
				case ItemData.Rarity.Type.Epic:
					SfxController.singleton.Play("treasure_item_blue");
					break;
				case ItemData.Rarity.Type.Heroic:
					SfxController.singleton.Play("treasure_item_green");
					break;
				case ItemData.Rarity.Type.Rare:
					SfxController.singleton.Play("treasure_item_yellow");
					break;
				case ItemData.Rarity.Type.Uncommon:
					SfxController.singleton.Play("treasure_item_cyan");
					break;
				default:
					SfxController.singleton.Play("pickup_success");
					break;
				}
			}
			else
			{
				UpdateInAppPurchases();
				UpdateItemsToPickup();
			}
		}
		else if (currentState >= State.ShopKeeperIntro && currentState <= State.ShopKeeperTitanicBundle)
		{
			shopKeeper.UpdateTic();
			if (shopKeeper.currentState == ShopKeeper.State.DoneIntro)
			{
				ShopController.singleton.hasSeenShopkeeper = true;
				if (limitedTimeBundleConfirmationDialog != null && currentState >= State.ShopKeeperGhostSlayer1 && currentState <= State.ShopKeeperTitanicBundle)
				{
					HandleLimitedTimeBundlePressed(null);
				}
				else
				{
					SetState(State.Normal);
				}
			}
		}
		else if (currentState == State.BuyConfirmation)
		{
			buyConfirmationDialog.UpdateTic();
			if (buyConfirmationDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				UpdateContents();
				if (buyConfirmationDialog.soldOut && !buyConfirmationDialog.IsTreasure() && !ProgressFlags.GetFlag("shop_keeper_loyal"))
				{
					ProgressFlags.SetFlag("shop_keeper_loyal");
					SetState(State.ShopKeeperLoyalCustomer);
				}
				else
				{
					SetState(State.Normal);
				}
			}
		}
		else if (currentState == State.LimitedTimeBuyConfirmation)
		{
			activeBundleConfirmationDialog.UpdateTic();
			if (activeBundleConfirmationDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
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
		else if (currentState == State.FailedToShowAd)
		{
			genericInfoDialog.UpdateTic();
			if (genericInfoDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetState(State.Normal);
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		DialogButton backButton = GameStates.Singleton.playItemNavBar.backButton;
		int num = backButton.lastDrawnX + backButton.Width;
		bool flag = false;
		if (isLimitedTimeSlotSmall)
		{
			flag = limitedTimeBundleSlot != null;
		}
		else
		{
			int num2 = r.width - num;
			int num3 = scrollContainer.Width;
			if (limitedTimeBundleSlot != null && limitedTimeBundleConfirmationDialog != null)
			{
				num3 += limitedTimeBundleSlot.Width - 1;
				flag = true;
			}
			int num4 = num + (num2 - num3) / 2;
			if (num4 < num)
			{
				flag = false;
				num4 = num + (num2 - scrollContainer.Width) / 2;
			}
			f_containerTargetX = num4 - offsetX;
		}
		float t = Mathf.Clamp01(Time.deltaTime * 12f);
		f_containerX = Mathf.Lerp(f_containerX, f_containerTargetX, t);
		scrollContainer.PositionX = Mathf.RoundToInt(f_containerX);
		moneyHudOffsetX = (num + 1) / 2;
		scrollContainer.PositionY = Mathf.Max(1, (r.height - scrollContainer.Height) / 2);
		if (shopState.specialOffer != null)
		{
			scrollContainer.PositionY += specialOfferSlot.Height - 1;
		}
		base.Draw(r, offsetX, offsetY);
		if (shopState.specialOffer != null)
		{
			int num5 = scrollContainer.lastContainerDrawY - specialOfferSlot.Height + 1;
			num5 -= scrollContainer.DisplayScrollY;
			specialOfferSlot.Draw(r, scrollContainer.lastContainerDrawX, num5);
		}
		if (flag)
		{
			int offsetX2;
			int num5;
			if (isLimitedTimeSlotSmall)
			{
				offsetX2 = backButton.lastDrawnX;
				num5 = backButton.lastDrawnY + backButton.Height + 2;
			}
			else
			{
				offsetX2 = offsetX + scrollContainer.PositionX + scrollContainer.Width;
				num5 = offsetY + scrollContainer.PositionY + scrollContainer.totalContentLength - limitedTimeBundleSlot.Height;
			}
			limitedTimeBundleSlot.Draw(r, offsetX2, num5);
		}
		if (beginnerBundleSlot != null)
		{
			GateShopSlot gateShopSlot = (rows[rows.Count - 1] as MultiSlotRow).slots[beginnerBundleSlotReplacementColumn] as GateShopSlot;
			beginnerBundleSlot.Draw(r, gateShopSlot.lastDrawX, gateShopSlot.lastDrawY);
		}
		if (currentState >= State.ShopKeeperIntro && currentState <= State.ShopKeeperTitanicBundle)
		{
			shopKeeper.Draw(r, 0, 0);
		}
		else if (currentState == State.BuyConfirmation)
		{
			buyConfirmationDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (currentState == State.LimitedTimeBuyConfirmation)
		{
			activeBundleConfirmationDialog.Draw(r, 0, 0);
		}
		else if (currentState == State.OpeningTreasures)
		{
			openTreasureDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (currentState == State.FailedToShowAd)
		{
			genericInfoDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
	}

	public void DrawInAppPurchasePendingProgress(AsciiRenderProcedural r)
	{
		if (InAppPurchaseController.singleton.HasPendingPurchases())
		{
			int lastDrawnX = GameStates.Singleton.playItemNavBar.backButton.lastDrawnX;
			loadingIcon.Draw(r, lastDrawnX, 0);
			pendingPurchasesLabel.Draw(r, lastDrawnX + 3, 0);
		}
	}

	public void Setup(string shopId)
	{
		shopState = ShopController.singleton.GetShopState(shopId);
	}

	public override void UpdateContents()
	{
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
		bool flag = true;
		bool flag2 = false;
		hasWatchToEarn = false;
		int num = 1;
		MultiSlotRow multiSlotRow2 = null;
		for (int k = 0; k < shopState.fullEntries.Length; k++)
		{
			ShopData.Entry entry = shopState.fullEntries[k];
			if (entry.id == "watch_to_earn")
			{
				if (PlayerPrefs.HasKey(LAST_WATCH_TO_EARN_KEY))
				{
					DateTime dateTime = DateTime.Parse(PlayerPrefs.GetString(LAST_WATCH_TO_EARN_KEY), CultureInfo.InvariantCulture).AddMinutes(WATCH_TO_EARN_INTERVAL);
					Debug.Log("watch_to_earn will next be available at: " + dateTime);
					if (dateTime <= DateTime.Now)
					{
						entry.amountPurchased = new SafeInt(0);
					}
				}
				else
				{
					entry.amountPurchased = new SafeInt(0);
				}
			}
			GateShopSlot gateShopSlot2 = (entry.isSmallSlot ? GetSmallSlot() : GetBigSlot());
			gateShopSlot2.SetContent(entry);
			if (gateShopSlot2.mode == GateShopSlot.Mode.Sold && entry.replacementEntry != null)
			{
				entry = entry.replacementEntry;
				gateShopSlot2.SetContent(entry);
			}
			if (gateShopSlot2.isWatchToEarn)
			{
				hasWatchToEarn = true;
			}
			gateShopSlot2.OnPressed += HandleOnSlotPressed;
			gateShopSlot2.OnSecondaryPressed += HandleOnSlotPressed;
			if (multiSlotRow2 == null || multiSlotRow2.IsFull(gateShopSlot2.Width))
			{
				multiSlotRow2 = AddRowFromPrefab(rowPrefab) as MultiSlotRow;
				num += multiSlotRow2.Height - 1;
			}
			multiSlotRow2.AddSlot(gateShopSlot2);
			int value = entry.copies.GetValue();
			if (entry.amountPurchased.GetValue() < value)
			{
				flag = false;
			}
			else if (value > 3)
			{
				flag2 = true;
			}
		}
		if (!hasWatchToEarn && shopState.specialOffer != null && shopState.specialOffer.id.Contains("watch_to_earn"))
		{
			hasWatchToEarn = true;
		}
		if (flag2)
		{
			AchievementController.singleton.ReportOneShopItemCleared();
		}
		if (flag)
		{
			AchievementController.singleton.ReportShopCleared();
		}
		if (shopState.specialOffer != null)
		{
			specialOfferSlot.SetContent(shopState.specialOffer);
			num += specialOfferSlot.Height - 1;
		}
		scrollContainer.Height = num;
	}

	public bool IsRewardPending()
	{
		if (ShopController.singleton.totalPurchases >= 2)
		{
			return !Inventory.Singleton.HasItemById("craft_book");
		}
		return false;
	}

	public void ShowReward()
	{
		SetState(State.ShopKeeperReward);
	}

	private void HandleOnSlotPressed(DialogButton button)
	{
		GateShopSlot gateShopSlot = button as GateShopSlot;
		ShopData.Entry entry = gateShopSlot.entry;
		if (gateShopSlot.isWatchToEarn)
		{
			TryWatchToEarn(entry);
			return;
		}
		SetState(State.BuyConfirmation);
		buyConfirmationDialog.Setup(gateShopSlot.entry);
		buyConfirmationDialog.Show();
	}

	private void HandleSpecialOfferPressed(DialogButton button)
	{
		HandleOnSlotPressed(button);
	}

	private void HandleLimitedTimeBundlePressed(DialogButton btn)
	{
		activeBundleConfirmationDialog = limitedTimeBundleConfirmationDialog;
		ShopData.LimitedTimeBundle bundleData = limitedTimeBundleSlot.bundleData;
		Item inventoryItem = bundleData.MakeInventoryItem();
		activeBundleConfirmationDialog.Setup(bundleData, inventoryItem);
		activeBundleConfirmationDialog.Show();
		SetState(State.LimitedTimeBuyConfirmation);
	}

	private void HandleBeginnerBundlePressed(DialogButton btn)
	{
		activeBundleConfirmationDialog = beginnerBundleConfirmationDialog;
		ShopData.LimitedTimeBundle bundleData = beginnerBundleSlot.bundleData;
		Item inventoryItem = bundleData.MakeInventoryItem();
		activeBundleConfirmationDialog.Setup(bundleData, inventoryItem);
		activeBundleConfirmationDialog.Show();
		SetState(State.LimitedTimeBuyConfirmation);
	}

	private void TryWatchToEarn(ShopData.Entry entry)
	{
		if (SubscriptionController.singleton.HasSubscription(SubscriptionController.EVENTS_SUBSCRIPTION_ID))
		{
			_WatchToEarnRewards(entry);
		}
		else if (AdsWrapper.singleton.IsReady())
		{
			AdsWrapper.singleton.ShowRewardedAd(delegate(bool isSuccessful)
			{
				if (isSuccessful)
				{
					_WatchToEarnRewards(entry);
					AnalyticsMacros.WatchedMushroomShop();
				}
				else
				{
					AnalyticsMacros.FailedToShowAd();
					SetState(State.FailedToShowAd);
				}
			});
		}
		else
		{
			SetState(State.FailedToShowAd);
		}
	}

	private void _WatchToEarnRewards(ShopData.Entry entry)
	{
		if (entry.treasures != null && entry.treasures.Length != 0)
		{
			List<ItemData.Element> possibleElements = TreasureFactory.singleton.MakeListOfPossibleElements();
			for (int i = 0; i < entry.treasures.Length; i++)
			{
				string treasureId = entry.treasures[i];
				TreasureItem item = TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", treasureId, possibleElements);
				itemsToPickup.Add(item);
				itemCountToPickup.Add(1);
			}
		}
		int num = entry.kiReward.GetValue() + entry.kiPerLevel.GetValue() * XPController.singleton.currentLevel;
		if (num > 0)
		{
			itemsToPickup.Add(Inventory.Singleton.MakeReward("ki", 1));
			itemCountToPickup.Add(num);
		}
		++entry.amountPurchased;
		SfxController.singleton.Play("pickup_success");
		PlayerPrefs.SetString(LAST_WATCH_TO_EARN_KEY, DateTime.Now.ToString(CultureInfo.InvariantCulture));
		UpdateContents();
	}

	private void UpdateInAppPurchases()
	{
		if (--cooldownUpdateInAppPurchases > 0 || !InAppPurchaseController.singleton.HasPurchasesToDeliver())
		{
			return;
		}
		cooldownUpdateInAppPurchases = 90;
		bool flag = false;
		ShopData shopById = ShopController.singleton.GetShopById("mushroom_shop");
		List<Product> pendingDeliveries = InAppPurchaseController.singleton.GetPendingDeliveries();
		for (int num = pendingDeliveries.Count - 1; num >= 0; num--)
		{
			Product product = pendingDeliveries[num];
			string id = product.definition.id;
			if (shopById.entriesDict.ContainsKey(id))
			{
				ShopData.Entry entry = shopById.entriesDict[id];
				if (entry.treasures != null)
				{
					for (int i = 0; i < entry.treasures.Length; i++)
					{
						string item = entry.treasures[i];
						ShopController.singleton.treasuresToOpen.Add(item);
					}
				}
				if (entry is ShopData.LimitedTimeBundle)
				{
					List<Item> items = (entry as ShopData.LimitedTimeBundle).GetItems();
					foreach (Item item2 in items)
					{
						ShopController.singleton.itemsToGrant.Add(item2);
					}
					items.Clear();
					LimitedTimeBundlesController.singleton.Complete(shopById.id, entry.id);
				}
				InAppPurchaseController.singleton.MarkPurchaseAsDelivered(product);
				flag = true;
			}
		}
		if (flag)
		{
			SfxController.singleton.Play("buy");
			GameStates.Singleton.TryToSaveProgress();
		}
	}

	private void UpdateItemsToPickup()
	{
		while (itemsToPickup.Count > 0)
		{
			Item item = itemsToPickup[0];
			int count = itemCountToPickup[0];
			itemsToPickup.RemoveAt(0);
			itemCountToPickup.RemoveAt(0);
			item = Inventory.Singleton.GainItem(item, count);
			SequentialPopupManager.singleton.ScheduleItemFound(item, count);
		}
	}

	private void HandleTreasurePurchased(string treasureId)
	{
		ShopController.singleton.treasuresToOpen.Add(treasureId);
	}

	private void HandleItemPurchased(Item item)
	{
		ShopController.FireItemPurchased(item);
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

	protected override void OnDestroy()
	{
		RemoveSlotCallbacks();
		specialOfferSlot.OnPressed -= HandleSpecialOfferPressed;
		buyConfirmationDialog.OnTreasuresPurchased -= HandleTreasurePurchased;
		buyConfirmationDialog.OnItemPurchased -= HandleItemPurchased;
		if (limitedTimeBundleConfirmationDialog != null)
		{
			limitedTimeBundleConfirmationDialog.OnTreasuresPurchased -= HandleTreasurePurchased;
		}
		if (limitedTimeBundleSlot != null)
		{
			limitedTimeBundleSlot.OnPressed -= HandleLimitedTimeBundlePressed;
		}
		if (beginnerBundleConfirmationDialog != null)
		{
			beginnerBundleConfirmationDialog.OnTreasuresPurchased -= HandleTreasurePurchased;
		}
		if (beginnerBundleSlot != null)
		{
			beginnerBundleSlot.OnPressed -= HandleBeginnerBundlePressed;
		}
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
		specialOfferSlot.OnPressed += HandleSpecialOfferPressed;
		buyConfirmationDialog.OnTreasuresPurchased += HandleTreasurePurchased;
		buyConfirmationDialog.OnItemPurchased += HandleItemPurchased;
	}

	private void Start()
	{
		openTreasureDialog = UnityEngine.Object.Instantiate(openTreasureDialogPrefab);
	}
}
