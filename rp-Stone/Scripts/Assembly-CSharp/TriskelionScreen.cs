using System;
using UnityEngine;

public class TriskelionScreen : PopUpModalScreen, IPostAsciiRendererEffect
{
	private enum TriskelionState
	{
		Idle = 0,
		SelectingItem = 1,
		ItemDetails = 2,
		FuseMoreDialog = 3,
		Fusing = 4,
		AutomatedCraftStep1 = 5,
		AutomatedCraftStep2 = 6,
		AutomatedCraftStep3 = 7,
		InfoDialog = 8
	}

	private const int AUTOMATION_DURATION_STEP_1 = 5;

	private const int AUTOMATION_DURATION_STEP_2 = 5;

	private const int AUTOMATION_DURATION_STEP_3 = 5;

	private static string PLAYER_PREFS_KEY_SAW_TRISKELION_INFO = "saw_triskelion_info";

	public ItemSlot centerFrame;

	public ItemSlot topFrame;

	public ItemSlot leftFrame;

	public ItemSlot rightFrame;

	public EnchantmentProgressBar progressBar;

	public AsciiSprite centerHighlight;

	public AsciiSprite topHighlight;

	public AsciiSprite leftHighlight;

	public AsciiSprite rightHighlight;

	public BurstAndGatherEmitter topEmitter;

	public BurstAndGatherEmitter leftEmitter;

	public BurstAndGatherEmitter rightEmitter;

	public DialogButton fuseButton;

	public AsciiString fuseCostLabel;

	public DialogButton fuseMoreButton;

	public AsciiTextBox slotCountRemaining;

	public TriskelionFuseMoreDialog fuseMoreDialog;

	public RollingMessage rollingMessage;

	public DialogButton infoButton;

	public OneChoiceIconDialog infoDialog;

	private TriskelionState triskelionState;

	private int elapsedTriskelionStateTics;

	private ItemSlot selectedFrame;

	private bool canFuse = true;

	private int fuseKiCost;

	private int insufficientKiCounter;

	private bool canFuseMore;

	private Item lastCenterItem;

	private int initialCloseButtonY;

	private ItemFactory.FuseResult result;

	public Action<Item, Item, Item, Item> OnPreFuse;

	private ItemDetailsDialog itemDetailsDialog => GameStates.Singleton.itemScreen.itemDetailsDialog;

	public bool craftInterrupted { get; set; }

	public static TriskelionScreen singleton { get; private set; }

	public override void Show()
	{
		base.Show();
		centerFrame.SetContent(null, 0);
		topFrame.SetContent(null, 0);
		leftFrame.SetContent(null, 0);
		rightFrame.SetContent(null, 0);
		lastCenterItem = null;
		fuseMoreButton.label.SetValue(Te.xt("FUSE") + "+");
		SetTriskelionState(TriskelionState.Idle);
		infoButton.enabled = ABTesting.FissureInfoDialog();
		if (infoButton.enabled && !PlayerPrefs.HasKey(PLAYER_PREFS_KEY_SAW_TRISKELION_INFO))
		{
			SetTriskelionState(TriskelionState.InfoDialog);
			PlayerPrefs.SetString(PLAYER_PREFS_KEY_SAW_TRISKELION_INFO, "true");
		}
	}

	public override void Hide()
	{
		base.Hide();
		ItemSelectionPopup itemSelectionPopup = ItemSelectionPopup.singleton;
		itemSelectionPopup.OnItemSelected = (Action<Item>)Delegate.Remove(itemSelectionPopup.OnItemSelected, new Action<Item>(HandleItemSelected));
	}

	private void SetTriskelionState(TriskelionState newState)
	{
		switch (newState)
		{
		case TriskelionState.Idle:
			UpdateCanFuse();
			UpdateProgressBar();
			GameStates.Singleton.ShowMouse();
			Hud.EnableAll();
			break;
		case TriskelionState.InfoDialog:
			infoDialog.Show();
			break;
		case TriskelionState.SelectingItem:
		{
			if (selectedFrame == centerFrame)
			{
				ItemSelectionPopup.singleton.mode = ItemSelectionPopup.Mode.Triskelion;
			}
			else
			{
				ItemSelectionPopup.singleton.mode = ItemSelectionPopup.Mode.TriskelionBoost;
			}
			ItemSelectionPopup.singleton.Show();
			ItemSelectionPopup itemSelectionPopup = ItemSelectionPopup.singleton;
			itemSelectionPopup.OnItemSelected = (Action<Item>)Delegate.Combine(itemSelectionPopup.OnItemSelected, new Action<Item>(HandleItemSelected));
			break;
		}
		case TriskelionState.FuseMoreDialog:
			fuseMoreDialog.Show();
			break;
		case TriskelionState.Fusing:
			EmitFireworks();
			if (!fuseMoreDialog.automationEnabled)
			{
				progressBar.Setup(0f, progressBar.targetFillColor);
			}
			result = ItemFactory.singleton.FuseEnchantments(centerFrame.item, topFrame.item, leftFrame.item, rightFrame.item);
			topFrame.SetContent(result.resultBoostItemA, 1);
			leftFrame.SetContent(result.resultBoostItemB, 1);
			rightFrame.SetContent(result.resultBoostItemC, 1);
			GameStates.Singleton.HideMouse();
			SfxController.singleton.Play("triskelion_fuse");
			AchievementController.singleton.ReportEnchantmentUpgraded(result);
			break;
		case TriskelionState.AutomatedCraftStep1:
			Hud.DisableAll();
			topFrame.SetContent(fuseMoreDialog.GetNextForAutomation(), 1);
			break;
		case TriskelionState.AutomatedCraftStep2:
			rightFrame.SetContent(fuseMoreDialog.GetNextForAutomation(), 1);
			break;
		case TriskelionState.AutomatedCraftStep3:
			leftFrame.SetContent(fuseMoreDialog.GetNextForAutomation(), 1);
			break;
		}
		triskelionState = newState;
		elapsedTriskelionStateTics = 0;
	}

	public override void UpdateTic()
	{
		if (triskelionState == TriskelionState.Idle)
		{
			base.UpdateTic();
		}
		elapsedTriskelionStateTics++;
		insufficientKiCounter--;
		infoButton.UpdateTic();
		if (triskelionState == TriskelionState.Idle)
		{
			centerFrame.UpdateTic();
			topFrame.UpdateTic();
			leftFrame.UpdateTic();
			rightFrame.UpdateTic();
			if (canFuse)
			{
				fuseButton.UpdateTic();
			}
			if (canFuseMore)
			{
				fuseMoreButton.UpdateTic();
			}
		}
		else if (triskelionState == TriskelionState.InfoDialog)
		{
			infoDialog.UpdateTic();
			if (infoDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetTriskelionState(TriskelionState.Idle);
			}
		}
		else if (triskelionState == TriskelionState.SelectingItem)
		{
			ItemSelectionPopup.singleton.UpdateTic();
			if (elapsedTriskelionStateTics == 15)
			{
				CleanupCommonItems();
			}
			if (ItemSelectionPopup.singleton.currentState == State.Disabled)
			{
				SetTriskelionState(TriskelionState.Idle);
			}
		}
		else if (triskelionState == TriskelionState.ItemDetails)
		{
			itemDetailsDialog.UpdateTic();
			if (itemDetailsDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetTriskelionState(TriskelionState.Idle);
			}
		}
		else if (triskelionState == TriskelionState.FuseMoreDialog)
		{
			fuseMoreDialog.UpdateTic();
			if (fuseMoreDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				if (fuseMoreDialog.automationEnabled)
				{
					SetTriskelionState(TriskelionState.AutomatedCraftStep1);
				}
				else
				{
					SetTriskelionState(TriskelionState.Idle);
				}
			}
		}
		else if (triskelionState == TriskelionState.Fusing && (elapsedTriskelionStateTics >= 60 || (fuseMoreDialog.automationEnabled && elapsedTriskelionStateTics >= 40 && fuseMoreDialog.totalIngredientCount > 1)))
		{
			if (result != null && result.outcome == ItemFactory.FuseResult.Outcome.Fused)
			{
				Inventory.Singleton.RemoveItem(result.primaryItem, 1);
				Inventory.Singleton.RemoveItem(result.boostItemA, 1);
				Inventory.Singleton.RemoveItem(result.boostItemB, 1);
				Inventory.Singleton.RemoveItem(result.boostItemC, 1);
				Item item = Inventory.Singleton.AddItem(result.resultPrimaryItem);
				item.hasInteracted = true;
				AnvilScreen.UnequipAndReequip(result.boostItemA, result.resultBoostItemA);
				AnvilScreen.UnequipAndReequip(result.boostItemB, result.resultBoostItemB);
				AnvilScreen.UnequipAndReequip(result.boostItemC, result.resultBoostItemC);
				AnvilScreen.UnequipAndReequip(result.primaryItem, result.resultPrimaryItem);
				UtilityBeltKeyShortcuts.singleton.ReportCraft(result);
				centerFrame.SetContent(item, 1);
				if (result.resultBoostItemA != null)
				{
					Item item2 = Inventory.Singleton.AddItem(result.resultBoostItemA);
					topFrame.SetContent(item2, 1);
				}
				else
				{
					topFrame.SetContent(null, 0);
				}
				if (result.resultBoostItemB != null)
				{
					Item item3 = Inventory.Singleton.AddItem(result.resultBoostItemB);
					leftFrame.SetContent(item3, 1);
				}
				else
				{
					leftFrame.SetContent(null, 0);
				}
				if (result.resultBoostItemC != null)
				{
					Item item4 = Inventory.Singleton.AddItem(result.resultBoostItemC);
					rightFrame.SetContent(item4, 1);
				}
				else
				{
					rightFrame.SetContent(null, 0);
				}
				if (fuseMoreDialog.automationEnabled)
				{
					fuseMoreDialog.ReportTransactionCompleted();
					if (!fuseMoreDialog.automationEnabled)
					{
						SfxController.singleton.Play("ui_starold4");
						SfxController.singleton.Play("mindstone_off");
					}
				}
				if (fuseMoreDialog.automationEnabled)
				{
					UpdateProgressBar();
					SetTriskelionState(TriskelionState.AutomatedCraftStep1);
					return;
				}
				if (AdditionalSettings.isScreenFlash)
				{
					GameStates.Singleton.asciiRenderer.AddPostEffect(this);
				}
				SetTriskelionState(TriskelionState.Idle);
			}
			else
			{
				SetTriskelionState(TriskelionState.Idle);
			}
		}
		else if (triskelionState == TriskelionState.AutomatedCraftStep1 && elapsedTriskelionStateTics >= 5)
		{
			SetTriskelionState(TriskelionState.AutomatedCraftStep2);
		}
		else if (triskelionState == TriskelionState.AutomatedCraftStep2 && elapsedTriskelionStateTics >= 5)
		{
			SetTriskelionState(TriskelionState.AutomatedCraftStep3);
		}
		else if (triskelionState == TriskelionState.AutomatedCraftStep3 && elapsedTriskelionStateTics >= 5)
		{
			if (topFrame.item != null && leftFrame.item != null && rightFrame.item != null)
			{
				fuseKiCost = 0;
				HandleFusePressed(null);
			}
			else
			{
				fuseMoreDialog.automationEnabled = false;
				SetTriskelionState(TriskelionState.Idle);
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		closeButton.PositionY = (fuseMoreDialog.automationEnabled ? (-999) : initialCloseButtonY);
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX + (Width >> 1);
		offsetY += PositionY + (int)transitionOffsetY;
		if (triskelionState != TriskelionState.Fusing)
		{
			if (centerFrame.item == null)
			{
				centerHighlight.Draw(r, offsetX, offsetY);
			}
			if (centerFrame.item != null)
			{
				if (topFrame.item == null || topFrame.item.GetRarityType() == ItemData.Rarity.Type.Common)
				{
					topHighlight.Draw(r, offsetX, offsetY);
				}
				if (leftFrame.item == null || leftFrame.item.GetRarityType() == ItemData.Rarity.Type.Common)
				{
					leftHighlight.Draw(r, offsetX, offsetY);
				}
				if (rightFrame.item == null || rightFrame.item.GetRarityType() == ItemData.Rarity.Type.Common)
				{
					rightHighlight.Draw(r, offsetX, offsetY);
				}
			}
		}
		centerFrame.Draw(r, offsetX, offsetY);
		topFrame.Draw(r, offsetX, offsetY);
		leftFrame.Draw(r, offsetX, offsetY);
		rightFrame.Draw(r, offsetX, offsetY);
		if (centerFrame.item != null)
		{
			progressBar.Draw(r, offsetX, offsetY);
		}
		if (infoButton.enabled)
		{
			int offsetX2 = offsetX + infoButton.PositionX;
			int offsetY2 = offsetY + infoButton.PositionY;
			infoButton.Draw(r, offsetX2, offsetY2);
		}
		if (canFuse && triskelionState != TriskelionState.Fusing)
		{
			fuseButton.Draw(r, offsetX, offsetY);
			int num = offsetX;
			if (fuseKiCost < 10 || (fuseKiCost > 99 && fuseKiCost < 1000))
			{
				num--;
			}
			if (insufficientKiCounter > 0 && insufficientKiCounter % 6 >= 3)
			{
				fuseCostLabel.Draw(r, num, offsetY, ColorConstants.red);
			}
			else
			{
				fuseCostLabel.Draw(r, num, offsetY);
			}
		}
		else if (triskelionState != TriskelionState.Fusing && !fuseMoreDialog.automationEnabled)
		{
			slotCountRemaining.Draw(r, offsetX, offsetY);
			if (canFuseMore)
			{
				fuseMoreButton.Draw(r, offsetX, offsetY);
			}
		}
		rollingMessage.Draw(r, offsetX, offsetY);
		if (triskelionState == TriskelionState.SelectingItem)
		{
			ItemSelectionPopup.singleton.Draw(r, offsetX, offsetY);
		}
		else if (triskelionState == TriskelionState.ItemDetails)
		{
			itemDetailsDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (triskelionState == TriskelionState.FuseMoreDialog)
		{
			fuseMoreDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (triskelionState != TriskelionState.Fusing && triskelionState == TriskelionState.InfoDialog)
		{
			infoDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
	}

	public void ApplyPostEffect(AsciiRenderProcedural r)
	{
		r.RemovePostEffect(this);
		for (int i = 0; i < r.width; i++)
		{
			for (int j = 0; j < r.height; j++)
			{
				AsciiCellProcedural cell = r.GetCell(i, j);
				Color foreground = cell.GetBackground();
				cell.SetBackground(Color.white);
				cell.SetForeground(foreground);
			}
		}
	}

	private void UpdateCanFuse()
	{
		canFuse = centerFrame.item != null && topFrame.item != null && leftFrame.item != null && rightFrame.item != null && centerFrame.item.GetRarityType() > ItemData.Rarity.Type.Common && topFrame.item.GetRarityType() > ItemData.Rarity.Type.Common && leftFrame.item.GetRarityType() > ItemData.Rarity.Type.Common && rightFrame.item.GetRarityType() > ItemData.Rarity.Type.Common && centerFrame.item.GetRarityBonus() < 21;
		if (!canFuse)
		{
			int num = 4;
			if (centerFrame.item != null && centerFrame.item.GetRarityType() != ItemData.Rarity.Type.Common)
			{
				num--;
			}
			if (topFrame.item != null && topFrame.item.GetRarityType() != ItemData.Rarity.Type.Common)
			{
				num--;
			}
			if (leftFrame.item != null && leftFrame.item.GetRarityType() != ItemData.Rarity.Type.Common)
			{
				num--;
			}
			if (rightFrame.item != null && rightFrame.item.GetRarityType() != ItemData.Rarity.Type.Common)
			{
				num--;
			}
			if (num == 0 || num == 4)
			{
				slotCountRemaining.Text = "";
			}
			else
			{
				slotCountRemaining.Text = string.Format(Te.xt("{0} more\nto go"), num);
			}
		}
		if (canFuse)
		{
			fuseKiCost = 0;
			if (topFrame.item != null && topFrame.item.rarity != null)
			{
				fuseKiCost += topFrame.item.rarity.quality;
			}
			if (leftFrame.item != null && leftFrame.item.rarity != null)
			{
				fuseKiCost += leftFrame.item.rarity.quality;
			}
			if (rightFrame.item != null && rightFrame.item.rarity != null)
			{
				fuseKiCost += rightFrame.item.rarity.quality;
			}
			int qualityThreshold = ItemData.Rarity.GetQualityThreshold(21);
			if (fuseKiCost + centerFrame.item.rarity.quality > qualityThreshold)
			{
				fuseKiCost = qualityThreshold - centerFrame.item.rarity.quality;
			}
			fuseCostLabel.SetValue("-@" + Utils.FormatNumber(fuseKiCost));
		}
		if (centerFrame.item == null || Inventory.Singleton.GetEnchantBoostItems().Count < 13)
		{
			canFuseMore = false;
		}
		else if (lastCenterItem != centerFrame.item)
		{
			lastCenterItem = centerFrame.item;
			fuseMoreDialog.SimplifyEnchantmentMemory();
			canFuseMore = fuseMoreDialog.ComputeUpgrade(centerFrame.item, 1);
		}
	}

	private void UpdateProgressBar()
	{
		if (!(centerFrame.item != null) || centerFrame.item.rarity == null)
		{
			return;
		}
		if (centerFrame.item.rarity.levelBonus == 21)
		{
			progressBar.Setup(1f, ColorConstants.white);
			progressBar.isRainbow = true;
			progressBar.maxEnchantment = true;
			return;
		}
		int levelBonus = centerFrame.item.rarity.levelBonus;
		int num = centerFrame.item.rarity.quality;
		if (topFrame.item != null && topFrame.item.rarity != null)
		{
			num += topFrame.item.rarity.quality;
		}
		if (leftFrame.item != null && leftFrame.item.rarity != null)
		{
			num += leftFrame.item.rarity.quality;
		}
		if (rightFrame.item != null && rightFrame.item.rarity != null)
		{
			num += rightFrame.item.rarity.quality;
		}
		int qualityThreshold = ItemData.Rarity.GetQualityThreshold(levelBonus);
		int qualityThreshold2 = ItemData.Rarity.GetQualityThreshold(levelBonus + 1);
		int bonusForQuality = ItemData.Rarity.GetBonusForQuality(num);
		float num2 = (float)(num - qualityThreshold) / (float)(qualityThreshold2 - qualityThreshold);
		if (num2 > 1f && bonusForQuality != 21)
		{
			int qualityThreshold3 = ItemData.Rarity.GetQualityThreshold(bonusForQuality);
			int qualityThreshold4 = ItemData.Rarity.GetQualityThreshold(bonusForQuality + 1);
			float num3 = (float)(num - qualityThreshold3) / (float)(qualityThreshold4 - qualityThreshold3);
			num2 = (float)(bonusForQuality - levelBonus) + num3;
		}
		progressBar.Setup(num2, ItemData.Rarity.GetColorForBonus(bonusForQuality));
		progressBar.isRainbow = bonusForQuality >= 16;
		progressBar.maxEnchantment = bonusForQuality == 21;
	}

	protected override void Update()
	{
		if (triskelionState != TriskelionState.SelectingItem && triskelionState != TriskelionState.ItemDetails && triskelionState != TriskelionState.FuseMoreDialog && triskelionState != TriskelionState.Fusing && !fuseMoreDialog.automationEnabled)
		{
			base.Update();
		}
	}

	private void CleanupCommonItems()
	{
		CleanupCommonItemFromFrame(centerFrame);
		CleanupCommonItemFromFrame(topFrame);
		CleanupCommonItemFromFrame(leftFrame);
		CleanupCommonItemFromFrame(rightFrame);
	}

	private void CleanupCommonItemFromFrame(ItemSlot frame)
	{
		Item item = frame.item;
		if (item != null && item.GetRarityType() == ItemData.Rarity.Type.Common && !item.isShiny && !item.isLost && !item.isNamed)
		{
			frame.SetContent(null, 0);
		}
	}

	private void ShowItemDetails(Item item)
	{
		if (item != null)
		{
			itemDetailsDialog.item = item;
			itemDetailsDialog.Show();
			SetTriskelionState(TriskelionState.ItemDetails);
		}
	}

	private void EmitFireworks()
	{
		AsciiRenderProcedural asciiRenderer = GameStates.Singleton.asciiRenderer;
		Vector3 vector = new Vector3((float)asciiRenderer.width / 2f, 0f, 0f);
		if (topFrame.item != null && topFrame.item.rarity != null)
		{
			topEmitter.transform.position = vector + new Vector3(-0.5f, 5.8f, 0f);
			topEmitter.gatherDestination = vector + new Vector3(0f, 12.3f, 0f);
			topEmitter.colorOverride = ItemData.Rarity.GetColorForRarity(topFrame.item.GetRarityType());
			topEmitter.Emit();
		}
		if (leftFrame.item != null && leftFrame.item.rarity != null)
		{
			leftEmitter.transform.position = vector + new Vector3(-12f, 16.8f, 0f);
			leftEmitter.gatherDestination = vector + new Vector3(0f, 12.3f, 0f);
			leftEmitter.colorOverride = ItemData.Rarity.GetColorForRarity(leftFrame.item.GetRarityType());
			leftEmitter.Emit();
		}
		if (rightFrame.item != null && rightFrame.item.rarity != null)
		{
			rightEmitter.transform.position = vector + new Vector3(10.5f, 16.8f, 0f);
			rightEmitter.gatherDestination = vector + new Vector3(0f, 12.3f, 0f);
			rightEmitter.colorOverride = ItemData.Rarity.GetColorForRarity(rightFrame.item.GetRarityType());
			rightEmitter.Emit();
		}
	}

	private void HandleItemSelected(Item item)
	{
		ItemSelectionPopup itemSelectionPopup = ItemSelectionPopup.singleton;
		itemSelectionPopup.OnItemSelected = (Action<Item>)Delegate.Remove(itemSelectionPopup.OnItemSelected, new Action<Item>(HandleItemSelected));
		int num = item.count;
		if (selectedFrame != centerFrame && centerFrame.item == item && --num <= 0)
		{
			centerFrame.SetContent(null, 0);
		}
		if (selectedFrame != topFrame && topFrame.item == item && --num <= 0)
		{
			topFrame.SetContent(null, 0);
		}
		if (selectedFrame != leftFrame && leftFrame.item == item && --num <= 0)
		{
			leftFrame.SetContent(null, 0);
		}
		if (selectedFrame != rightFrame && rightFrame.item == item && --num <= 0)
		{
			rightFrame.SetContent(null, 0);
		}
		selectedFrame.SetContent(item, 1);
		UpdateCanFuse();
	}

	private void HandleFramePressed(DialogButton btn)
	{
		selectedFrame = btn as ItemSlot;
		SetTriskelionState(TriskelionState.SelectingItem);
	}

	private void HandleFrameSecondaryPressed(DialogButton btn)
	{
		ItemSlot itemSlot = btn as ItemSlot;
		ShowItemDetails(itemSlot.item);
	}

	private void HandleFusePressed(DialogButton btn)
	{
		if (fuseKiCost > InventoryResources.singleton.GetResourceOfType(Data.Resource.Xi))
		{
			insufficientKiCounter = 18;
			return;
		}
		craftInterrupted = false;
		OnPreFuse?.Invoke(centerFrame.item, topFrame.item, leftFrame.item, rightFrame.item);
		if (craftInterrupted)
		{
			rollingMessage.Show(Te.xt("tid_craft_interrupted"), Color.red);
			return;
		}
		InventoryResources.singleton.RemoveResourceOfType(Data.Resource.Xi, fuseKiCost);
		SetTriskelionState(TriskelionState.Fusing);
	}

	private void HandleFuseMorePressed(DialogButton btn)
	{
		SetTriskelionState(TriskelionState.FuseMoreDialog);
	}

	private void HandleInfoButtonPressed(DialogButton btn)
	{
		SetTriskelionState(TriskelionState.InfoDialog);
	}

	private void HandleInfoDialogOKPressed(DialogButton btn)
	{
		infoDialog.Hide();
	}

	public int GetStateNumericRepresentation()
	{
		return (int)triskelionState;
	}

	protected override void Start()
	{
		base.Start();
		initialCloseButtonY = closeButton.PositionY;
		centerFrame.OnPressed += HandleFramePressed;
		topFrame.OnPressed += HandleFramePressed;
		leftFrame.OnPressed += HandleFramePressed;
		rightFrame.OnPressed += HandleFramePressed;
		centerFrame.OnSecondaryPressed += HandleFrameSecondaryPressed;
		topFrame.OnSecondaryPressed += HandleFrameSecondaryPressed;
		leftFrame.OnSecondaryPressed += HandleFrameSecondaryPressed;
		rightFrame.OnSecondaryPressed += HandleFrameSecondaryPressed;
		fuseButton.OnPressed += HandleFusePressed;
		fuseMoreButton.OnPressed += HandleFuseMorePressed;
		infoButton.OnPressed += HandleInfoButtonPressed;
		infoDialog.okButton.OnPressed += HandleInfoDialogOKPressed;
	}

	protected override void OnDestroy()
	{
		centerFrame.OnPressed -= HandleFramePressed;
		topFrame.OnPressed -= HandleFramePressed;
		leftFrame.OnPressed -= HandleFramePressed;
		rightFrame.OnPressed -= HandleFramePressed;
		centerFrame.OnSecondaryPressed -= HandleFrameSecondaryPressed;
		topFrame.OnSecondaryPressed -= HandleFrameSecondaryPressed;
		leftFrame.OnSecondaryPressed -= HandleFrameSecondaryPressed;
		rightFrame.OnSecondaryPressed -= HandleFrameSecondaryPressed;
		fuseButton.OnPressed -= HandleFusePressed;
		fuseMoreButton.OnPressed -= HandleFuseMorePressed;
		infoButton.OnPressed -= HandleInfoButtonPressed;
		infoDialog.okButton.OnPressed -= HandleInfoDialogOKPressed;
		base.OnDestroy();
	}

	protected override void Awake()
	{
		base.Awake();
		singleton = this;
	}
}
