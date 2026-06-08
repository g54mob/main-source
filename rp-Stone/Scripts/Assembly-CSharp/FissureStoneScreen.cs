using System;
using System.Collections.Generic;
using UnityEngine;

public class FissureStoneScreen : PopUpModalScreen
{
	private enum FissureState
	{
		Idle = 0,
		SelectingItem = 1,
		ItemDetails = 2,
		UnmakeConfirmation = 3,
		Unmaking = 4,
		Splitting = 5,
		ResultKi = 6,
		ResultItems = 7,
		InfoDialog = 8
	}

	private struct AutomationEntry
	{
		public Item item;

		public int count;

		public AutomationEntry(Item i, int c)
		{
			item = i;
			count = c;
		}
	}

	private const int AUTOMATION_ARC_DURATION = 11;

	private const float AUTOMATION_LERP_MULTIPLY = 2f;

	private static string PLAYER_PREFS_KEY_SAW_FISSURE_INFO = "saw_fissure_info";

	public ItemSlot equipFrame;

	public AsciiSprite itemDragVfx;

	public AsciiSprite splitButtonBg;

	public AsciiSprite unmakeButtonBg;

	public DialogButton splitButton;

	public DialogButton unmakeButton;

	public AsciiString doubleKiLabel;

	public AsciiAnimation electricityArcAnm;

	public AsciiString splitSubtitle;

	public AsciiString unmakeReward;

	public ItemSlot resultFrameA;

	public ItemSlot resultFrameB;

	public PlusMinusButtons plusMinusButtonsPrefab;

	private PlusMinusButtons plusMinusButtons;

	public DialogButton breakCompletelyButton;

	public AsciiString breakCompletelySubLabel;

	public DialogButton stopAutomationButton;

	public TwoChoiceDialog unmakeConfirmationDialog;

	public RollingMessage rollingMessage;

	public Action<Item, int> OnPreFissure;

	public Action<ItemFactory.Result, int> OnFissure;

	public Action<Item, int> OnPreUnmake;

	public Action<Item, int, int> OnUnmake;

	public DialogButton infoButton;

	public OneChoiceIconDialog infoDialog;

	private FissureState fissureState;

	private FissureState previousFissureState;

	private int elapsedFissureStateTics;

	private bool canUnmake;

	private bool canSplitApart;

	private int splitApartCost;

	private bool isDoubleKi;

	private float currentUnmakeX;

	private float currentUnmakeY;

	private ItemFactory.Result result;

	private float resultItemXa;

	private float resultItemXb;

	private float resultItemY;

	private int blinkCostTime;

	private Queue<AutomationEntry> automationQueue = new Queue<AutomationEntry>();

	private bool _automation;

	private int zeroStarBreakableItemCount;

	private bool canBreakAllZeroStarItems;

	private bool isActiveBreakAllZeroStarItems;

	private SpriteFrameFlashScreen electricityArcFlash;

	private float rLerp = 4f;

	private float rOffsetX = -10f;

	private float rOffsetY = -3f;

	private float destItemXa = -13f;

	private float destItemXb = 5f;

	private float destItemY = 5f;

	private float itemLerp = 6f;

	private int unmakeValue;

	private ItemDetailsDialog itemDetailsDialog => GameStates.Singleton.itemScreen.itemDetailsDialog;

	private bool automationEnabled
	{
		get
		{
			return _automation;
		}
		set
		{
			_automation = value;
			electricityArcFlash.enabled = !value;
		}
	}

	public bool craftInterrupted { get; set; }

	public static FissureStoneScreen singleton { get; private set; }

	public override void Show()
	{
		base.Show();
		ClearEquipFrame();
		ClearSplitResult();
		breakCompletelyButton.enabled = false;
		automationQueue.Clear();
		automationEnabled = false;
		infoButton.enabled = ABTesting.FissureInfoDialog();
		if (infoButton.enabled && !PlayerPrefs.HasKey(PLAYER_PREFS_KEY_SAW_FISSURE_INFO))
		{
			SetFissureState(FissureState.InfoDialog);
			PlayerPrefs.SetString(PLAYER_PREFS_KEY_SAW_FISSURE_INFO, "true");
		}
	}

	public override void Hide()
	{
		base.Hide();
		ClearSplitResult();
		automationQueue.Clear();
		ItemSelectionPopup itemSelectionPopup = ItemSelectionPopup.singleton;
		itemSelectionPopup.OnItemSelected = (Action<Item>)Delegate.Remove(itemSelectionPopup.OnItemSelected, new Action<Item>(HandleItemSelected));
	}

	private void SetFissureState(FissureState newState)
	{
		switch (newState)
		{
		case FissureState.SelectingItem:
		{
			ItemSelectionPopup.singleton.mode = ItemSelectionPopup.Mode.Fissure;
			ItemSelectionPopup.singleton.Show();
			ItemSelectionPopup itemSelectionPopup = ItemSelectionPopup.singleton;
			itemSelectionPopup.OnItemSelected = (Action<Item>)Delegate.Combine(itemSelectionPopup.OnItemSelected, new Action<Item>(HandleItemSelected));
			break;
		}
		case FissureState.InfoDialog:
			infoDialog.Show();
			break;
		case FissureState.UnmakeConfirmation:
		{
			string format = Te.xt("tid_fissure_4");
			int count = equipFrame.count;
			string arg = Utils.FormatNumber(isDoubleKi ? (unmakeValue * 2) : unmakeValue);
			Item item = equipFrame.item;
			string text = item.GetName();
			if (item.level >= 1 && item.showLevelInTitle)
			{
				string starRatingStringForItem = ItemFactory.GetStarRatingStringForItem(item);
				text = text + " " + starRatingStringForItem;
			}
			int rarityBonus = item.GetRarityBonus();
			if (rarityBonus > 0)
			{
				text = text + " +" + rarityBonus;
			}
			format = string.Format(format, count, text, arg);
			unmakeConfirmationDialog.SetMessage(format);
			unmakeConfirmationDialog.Show();
			break;
		}
		case FissureState.Unmaking:
			electricityArcAnm.Play();
			SfxController.singleton.Play("fissure_unmake");
			break;
		case FissureState.Splitting:
			electricityArcAnm.Play();
			SfxController.singleton.Play("fissure_break_apart");
			break;
		case FissureState.ResultKi:
			ClearEquipFrame();
			currentUnmakeX = 0f;
			currentUnmakeY = 8f;
			break;
		case FissureState.ResultItems:
			if (previousFissureState == FissureState.ResultItems && !automationEnabled)
			{
				break;
			}
			ClearEquipFrame();
			resultItemXa = equipFrame.PositionX;
			resultItemXb = resultItemXa;
			resultItemY = equipFrame.PositionY;
			plusMinusButtons.Hide();
			if (automationQueue.Count != 0 || isActiveBreakAllZeroStarItems)
			{
				break;
			}
			automationEnabled = false;
			if (!breakCompletelyButton.enabled)
			{
				zeroStarBreakableItemCount = Inventory.Singleton.GetZeroStarBreakableItemCount();
				if (zeroStarBreakableItemCount >= 3)
				{
					canBreakAllZeroStarItems = true;
					SetupBreakAllZeroStarItemsLabel();
					breakCompletelyButton.enabled = true;
				}
			}
			break;
		}
		previousFissureState = fissureState;
		fissureState = newState;
		elapsedFissureStateTics = 0;
	}

	public override void UpdateTic()
	{
		if (fissureState != FissureState.Unmaking && fissureState != FissureState.Splitting && fissureState != FissureState.ResultKi)
		{
			base.UpdateTic();
		}
		elapsedFissureStateTics++;
		if (!automationEnabled)
		{
			equipFrame.UpdateTic();
		}
		infoButton.UpdateTic();
		if (fissureState == FissureState.Idle && equipFrame.item != null)
		{
			if (canSplitApart)
			{
				splitButton.UpdateTic();
			}
			if (canUnmake)
			{
				unmakeButton.UpdateTic();
			}
			plusMinusButtons.UpdateTic();
		}
		else if (fissureState == FissureState.SelectingItem)
		{
			ItemSelectionPopup.singleton.UpdateTic();
			if (ItemSelectionPopup.singleton.currentState == State.Disabled)
			{
				UpdatePlusMinusButtonStates();
				if (equipFrame.item != null)
				{
					SetFissureState(FissureState.Idle);
				}
				else
				{
					SetFissureState(previousFissureState);
				}
			}
		}
		else if (fissureState == FissureState.ItemDetails)
		{
			itemDetailsDialog.UpdateTic();
			if (itemDetailsDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetFissureState(previousFissureState);
			}
		}
		else if (fissureState == FissureState.UnmakeConfirmation)
		{
			unmakeConfirmationDialog.UpdateTic();
			if (unmakeConfirmationDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetFissureState(previousFissureState);
			}
		}
		else if (fissureState == FissureState.InfoDialog)
		{
			infoDialog.UpdateTic();
			if (infoDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetFissureState(previousFissureState);
			}
		}
		else if (fissureState == FissureState.Unmaking && elapsedFissureStateTics >= 30)
		{
			SetFissureState(FissureState.ResultKi);
		}
		else if (fissureState == FissureState.Splitting && elapsedFissureStateTics >= 30)
		{
			int count = equipFrame.count;
			result = ItemFactory.singleton.SplitItem(equipFrame.item, count);
			if (result != null)
			{
				OnFissure?.Invoke(result, count);
				Inventory.Singleton.RemoveItem(result.resultingItem, count);
				Item item;
				Item item2;
				if (result.itemA == result.itemB)
				{
					item = Inventory.Singleton.AddItem(result.itemA, result.itemA_count + result.itemB_count);
					item2 = item;
				}
				else
				{
					item = Inventory.Singleton.AddItem(result.itemA, result.itemA_count);
					item2 = Inventory.Singleton.AddItem(result.itemB, result.itemB_count);
				}
				resultFrameA.SetContent(item, result.itemA_count);
				resultFrameB.SetContent(item2, result.itemB_count);
				result.itemA = item;
				result.itemB = item2;
				item.hasInteracted = true;
				item2.hasInteracted = true;
				AnvilScreen.UnequipAndReequip(result.resultingItem, result.itemA);
				if (isActiveBreakAllZeroStarItems)
				{
					QueueNextAutomated();
				}
				else if (automationEnabled)
				{
					TryPushResultToAutomation();
				}
				else if (ItemFactory.CanSplitApart(item) || ItemFactory.CanSplitApart(item2))
				{
					SetupBreakCompletelyLabel();
					breakCompletelyButton.enabled = true;
				}
				else
				{
					breakCompletelyButton.enabled = false;
				}
				SetFissureState(FissureState.ResultItems);
			}
			else
			{
				SetFissureState(FissureState.Idle);
			}
		}
		else if (fissureState == FissureState.ResultKi && elapsedFissureStateTics >= 18)
		{
			InventoryResources.singleton.AddResourceOfType(Data.Resource.Xi, unmakeValue);
			SetFissureState(FissureState.Idle);
		}
		else if (fissureState == FissureState.ResultItems)
		{
			if (resultFrameA.item != null && !automationEnabled)
			{
				resultFrameA.UpdateTic();
			}
			if (resultFrameB.item != null && !automationEnabled)
			{
				resultFrameB.UpdateTic();
			}
			if (breakCompletelyButton.enabled)
			{
				breakCompletelyButton.UpdateTic();
			}
			if (automationEnabled && elapsedFissureStateTics == 11)
			{
				NextAutomated();
			}
		}
		if (isActiveBreakAllZeroStarItems)
		{
			stopAutomationButton.UpdateTic();
		}
		base.canBack = !isActiveBreakAllZeroStarItems;
		if (blinkCostTime > 0)
		{
			blinkCostTime--;
		}
	}

	private void NextAutomated()
	{
		if (automationQueue.Count > 0)
		{
			AutomationEntry automationEntry = automationQueue.Dequeue();
			equipFrame.SetContent(automationEntry.item, automationEntry.count);
			ClearSplitResult();
			SetFissureState(FissureState.Splitting);
		}
		else if (canBreakAllZeroStarItems)
		{
			Item firstZeroStarBreakableItem = Inventory.Singleton.GetFirstZeroStarBreakableItem();
			if (firstZeroStarBreakableItem != null)
			{
				isActiveBreakAllZeroStarItems = true;
				if (zeroStarBreakableItemCount > 0)
				{
					rollingMessage.Show(zeroStarBreakableItemCount.ToString(), ColorConstants.white);
				}
				zeroStarBreakableItemCount--;
				equipFrame.SetContent(firstZeroStarBreakableItem, firstZeroStarBreakableItem.count);
				ClearSplitResult();
				SetFissureState(FissureState.Splitting);
			}
			else
			{
				canBreakAllZeroStarItems = false;
				isActiveBreakAllZeroStarItems = false;
				automationEnabled = false;
			}
		}
		else
		{
			automationEnabled = false;
		}
	}

	private void QueueNextAutomated()
	{
		Item firstZeroStarBreakableItem = Inventory.Singleton.GetFirstZeroStarBreakableItem();
		if (firstZeroStarBreakableItem != null)
		{
			isActiveBreakAllZeroStarItems = true;
			if (zeroStarBreakableItemCount > 0)
			{
				rollingMessage.Show(zeroStarBreakableItemCount.ToString(), ColorConstants.white);
			}
			zeroStarBreakableItemCount--;
			TryPushResultToAutomation(firstZeroStarBreakableItem, firstZeroStarBreakableItem.count);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX + (Width >> 1);
		offsetY += PositionY + (int)transitionOffsetY;
		equipFrame.Draw(r, offsetX, offsetY);
		if (fissureState != FissureState.ResultKi && fissureState != FissureState.ResultItems && equipFrame.item != null)
		{
			plusMinusButtons.PositionX = equipFrame.PositionX + 8;
			plusMinusButtons.PositionY = equipFrame.PositionY;
			plusMinusButtons.Draw(r, offsetX, offsetY);
		}
		if (infoButton.enabled)
		{
			int offsetX2 = offsetX + infoButton.PositionX;
			int offsetY2 = offsetY + infoButton.PositionY;
			infoButton.Draw(r, offsetX2, offsetY2);
		}
		if (equipFrame.item != null && (fissureState == FissureState.Idle || fissureState == FissureState.SelectingItem || (fissureState == FissureState.ItemDetails && previousFissureState == FissureState.Idle && previousFissureState == FissureState.SelectingItem)))
		{
			if (canSplitApart)
			{
				int offsetX3 = offsetX + splitButton.PositionX;
				int offsetY3 = offsetY + splitButton.PositionY;
				splitButtonBg.Draw(r, offsetX3, offsetY3);
				if (blinkCostTime > 0 && (blinkCostTime - 1) % 6 <= 2)
				{
					splitSubtitle.Draw(r, offsetX3, offsetY3, ColorConstants.red);
				}
				else
				{
					splitSubtitle.Draw(r, offsetX3, offsetY3);
				}
				splitButton.Draw(r, offsetX, offsetY);
			}
			if (canUnmake)
			{
				int offsetX3 = offsetX + unmakeButton.PositionX;
				int offsetY3 = offsetY + unmakeButton.PositionY;
				unmakeButtonBg.Draw(r, offsetX3, offsetY3);
				unmakeReward.Draw(r, offsetX3, offsetY3);
				unmakeButton.Draw(r, offsetX, offsetY);
				if (isDoubleKi)
				{
					doubleKiLabel.Draw(r, offsetX3, offsetY3);
				}
			}
		}
		GameStates.Singleton.money.Draw(r, 0, 0, GameStates.State.ItemScreen);
		if (resultFrameA.item != null)
		{
			int offsetX4 = offsetX + Mathf.RoundToInt(resultItemXa);
			int offsetY4 = offsetY + Mathf.RoundToInt(resultItemY);
			resultFrameA.Draw(r, offsetX4, offsetY4);
		}
		if (resultFrameB.item != null)
		{
			int offsetX5 = offsetX + Mathf.RoundToInt(resultItemXb);
			int offsetY5 = offsetY + Mathf.RoundToInt(resultItemY);
			resultFrameB.Draw(r, offsetX5, offsetY5);
		}
		rollingMessage.Draw(r, offsetX, offsetY);
		if (fissureState == FissureState.SelectingItem)
		{
			ItemSelectionPopup.singleton.Draw(r, offsetX, offsetY);
		}
		else if (fissureState == FissureState.ItemDetails)
		{
			itemDetailsDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (fissureState == FissureState.UnmakeConfirmation)
		{
			unmakeConfirmationDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (fissureState == FissureState.InfoDialog)
		{
			infoDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (fissureState == FissureState.Unmaking || fissureState == FissureState.Splitting)
		{
			electricityArcAnm.Sprite.Draw(r, offsetX, offsetY);
		}
		else if (fissureState == FissureState.ResultKi)
		{
			int offsetX6 = offsetX + Mathf.RoundToInt(currentUnmakeX);
			int offsetY6 = Mathf.RoundToInt(currentUnmakeY);
			unmakeReward.Draw(r, offsetX6, offsetY6);
		}
		else if (fissureState == FissureState.ResultItems && breakCompletelyButton.enabled)
		{
			breakCompletelyButton.Draw(r, offsetX, offsetY);
			breakCompletelySubLabel.Draw(r, offsetX + breakCompletelyButton.PositionX + breakCompletelyButton.label.PositionX, offsetY + breakCompletelyButton.PositionY + 2);
		}
		if (isActiveBreakAllZeroStarItems)
		{
			stopAutomationButton.Draw(r, r.width, r.height);
		}
	}

	protected override void Update()
	{
		if (fissureState != FissureState.SelectingItem && fissureState != FissureState.ItemDetails && fissureState != FissureState.Unmaking && fissureState != FissureState.Splitting && fissureState != FissureState.ResultKi)
		{
			base.Update();
		}
		if (fissureState == FissureState.ResultKi)
		{
			float b = (float)GameStates.Singleton.asciiRenderer.width / 2f + rOffsetX;
			float b2 = rOffsetY;
			currentUnmakeX = Mathf.Lerp(currentUnmakeX, b, Time.deltaTime * rLerp);
			currentUnmakeY = Mathf.Lerp(currentUnmakeY, b2, Time.deltaTime * rLerp);
		}
		else if (fissureState == FissureState.ResultItems)
		{
			float num = Time.deltaTime * itemLerp;
			if (automationEnabled)
			{
				num *= 2f;
			}
			resultItemXa = Mathf.Lerp(resultItemXa, destItemXa, num);
			resultItemXb = Mathf.Lerp(resultItemXb, destItemXb, num);
			resultItemY = Mathf.Lerp(resultItemY, destItemY, num);
		}
	}

	private void ShowItemDetails(Item item)
	{
		if (item != null)
		{
			itemDetailsDialog.item = item;
			itemDetailsDialog.Show();
			SetFissureState(FissureState.ItemDetails);
		}
	}

	private void ClearEquipFrame()
	{
		equipFrame.SetContent(null, 0);
	}

	private void ClearSplitResult()
	{
		resultFrameA.SetContent(null, 0);
		resultFrameB.SetContent(null, 0);
	}

	private void EmitFromButton(DialogButton button)
	{
		if (button != null)
		{
			SpriteEmitter componentInChildren = itemDragVfx.GetComponentInChildren<SpriteEmitter>();
			if (componentInChildren != null)
			{
				componentInChildren.TryToEmit(button.lastDrawnX - button.clickPaddingLeft, button.lastDrawnY - button.clickPaddingTop);
			}
		}
	}

	private int ComputeUnmakeValue(Item item)
	{
		if (item == null)
		{
			return 0;
		}
		int num = 0;
		if (item.id != "enchantment")
		{
			num += item.level * 5;
			if (item.element != ItemData.Element.Stone)
			{
				int num2 = Mathf.FloorToInt((float)item.level / Mathf.Pow(2f, (float)item.complexity + 1f));
				num += 15 * num2;
			}
		}
		if (item.rarity != null)
		{
			num += item.rarity.quality * 100;
		}
		if (item.isShiny)
		{
			num += 500;
		}
		return num;
	}

	private void SetupBreakCompletelyLabel()
	{
		_SetupBreakLabel("tid_fissure_3");
	}

	private void SetupBreakAllZeroStarItemsLabel()
	{
		_SetupBreakLabel("tid_fissure_5");
	}

	private void _SetupBreakLabel(string textId)
	{
		string[] array = Utils.BreakIntoLines(Te.xt(textId), 15);
		if (array.Length == 1)
		{
			breakCompletelyButton.Height = 3;
			breakCompletelySubLabel.Clear();
		}
		else
		{
			breakCompletelyButton.Height = 4;
			breakCompletelySubLabel.SetValue(array[1]);
		}
		breakCompletelyButton.label.SetValue(array[0]);
	}

	private void HandleItemSelected(Item item)
	{
		ItemSelectionPopup itemSelectionPopup = ItemSelectionPopup.singleton;
		itemSelectionPopup.OnItemSelected = (Action<Item>)Delegate.Remove(itemSelectionPopup.OnItemSelected, new Action<Item>(HandleItemSelected));
		if (StarStoneWeapon.singleton != null && StarStoneWeapon.singleton.level > 1 && item.GetRarityBonus() == 0)
		{
			equipFrame.SetContent(item, item.count);
		}
		else
		{
			equipFrame.SetContent(item, 1);
		}
		ClearSplitResult();
		canSplitApart = ItemFactory.CanSplitApart(item);
		UpdateSplitApartCost();
		UpdateUnmakeValue();
	}

	private void UpdateSplitApartCost()
	{
		if (canSplitApart)
		{
			if (equipFrame.item != null)
			{
				splitApartCost = equipFrame.item.ComputeSplitApartCost() * equipFrame.count;
			}
			else
			{
				splitApartCost = 9999999;
			}
		}
		else
		{
			splitApartCost = 0;
		}
		if (splitApartCost > 0)
		{
			splitSubtitle.SetValue("-@" + splitApartCost);
		}
		else
		{
			splitSubtitle.SetValue(Te.xt("Apart"));
		}
	}

	private void UpdateUnmakeValue()
	{
		Item item = equipFrame.item;
		canUnmake = item != null && item.GetRarityType() == ItemData.Rarity.Type.Common && !item.isLost && !item.isSigned && item.id != "shiny";
		if (canUnmake)
		{
			unmakeValue = ComputeUnmakeValue(equipFrame.item) * equipFrame.count;
			isDoubleKi = EventController.singleton.IsEventActive("2xKi");
			if (isDoubleKi)
			{
				unmakeValue *= 2;
			}
			unmakeReward.SetValue("+@" + Utils.FormatNumber(unmakeValue) + " ");
		}
	}

	private void HandleEquipFramePressed(DialogButton btn)
	{
		if (fissureState != FissureState.Unmaking && fissureState != FissureState.Splitting && fissureState != FissureState.ResultKi)
		{
			SetFissureState(FissureState.SelectingItem);
		}
	}

	private void HandleEquipSecondaryPressed(DialogButton btn)
	{
		if (fissureState != FissureState.Unmaking && fissureState != FissureState.Splitting && fissureState != FissureState.ResultKi)
		{
			ShowItemDetails(equipFrame.item);
		}
	}

	private void HandleSplitPressed(DialogButton btn)
	{
		craftInterrupted = false;
		OnPreFissure?.Invoke(equipFrame.item, equipFrame.count);
		if (craftInterrupted)
		{
			rollingMessage.Show(Te.xt("tid_craft_interrupted"), Color.red);
		}
		else if (splitApartCost <= InventoryResources.singleton.GetResourceOfType(Data.Resource.Xi))
		{
			SetFissureState(FissureState.Splitting);
			InventoryResources.singleton.RemoveResourceOfType(Data.Resource.Xi, splitApartCost);
			plusMinusButtons.Hide();
		}
		else
		{
			blinkCostTime = 15;
		}
	}

	private void HandleUnmakePressed(DialogButton btn)
	{
		craftInterrupted = false;
		OnPreUnmake?.Invoke(equipFrame.item, equipFrame.count);
		if (craftInterrupted)
		{
			rollingMessage.Show(Te.xt("tid_craft_interrupted"), Color.red);
		}
		else
		{
			SetFissureState(FissureState.UnmakeConfirmation);
		}
	}

	private void HandleUnmakeConfirmed(DialogButton btn)
	{
		SetFissureState(FissureState.Unmaking);
		Item item = equipFrame.item;
		int count = equipFrame.count;
		OnUnmake?.Invoke(item, count, unmakeValue);
		Inventory.Singleton.RemoveItem(item, count);
		plusMinusButtons.Hide();
	}

	private void HandleResultItemFramePressed(DialogButton btn)
	{
		ItemSlot itemSlot = btn as ItemSlot;
		ShowItemDetails(itemSlot.item);
	}

	private void UpdatePlusMinusButtonStates()
	{
		int itemCountLimit = GetItemCountLimit();
		if (itemCountLimit > 1)
		{
			plusMinusButtons.Show();
			plusMinusButtons.plusButton.enabled = equipFrame.count < itemCountLimit;
		}
		else
		{
			plusMinusButtons.Hide();
			equipFrame.count = 1;
		}
	}

	private void HandlePlusPressed(PlusMinusButtons buttons, bool isRepeating)
	{
		if (fissureState != FissureState.Idle)
		{
			return;
		}
		int itemCountLimit = GetItemCountLimit();
		if (equipFrame.count < itemCountLimit)
		{
			if (equipFrame.count >= 10 && isRepeating)
			{
				equipFrame.count = itemCountLimit;
			}
			else
			{
				equipFrame.count++;
			}
			if (equipFrame.count == GetItemCountLimit())
			{
				plusMinusButtons.plusButton.enabled = false;
			}
			plusMinusButtons.repeatFrameSkip = ((equipFrame.count >= 5) ? 1 : 2);
			UpdateSplitApartCost();
			UpdateUnmakeValue();
		}
	}

	private void HandleMinusPressed(PlusMinusButtons buttons, bool isRepeating)
	{
		if (fissureState == FissureState.Idle)
		{
			plusMinusButtons.plusButton.enabled = true;
			int num = 1;
			if (equipFrame.count > 100 && isRepeating)
			{
				num = 11;
			}
			equipFrame.count -= num;
			if (equipFrame.count <= 0)
			{
				ClearEquipFrame();
				plusMinusButtons.Hide();
			}
			plusMinusButtons.repeatFrameSkip = ((equipFrame.count < 10) ? 2 : 0);
			UpdateSplitApartCost();
			UpdateUnmakeValue();
		}
	}

	private void HandleBreakCompletelyButtonPressed(DialogButton btn)
	{
		automationEnabled = true;
		breakCompletelyButton.enabled = false;
		automationQueue.Clear();
		TryPushResultToAutomation();
		NextAutomated();
	}

	private void HandleStopAutomationButtonPressed(DialogButton btn)
	{
		canBreakAllZeroStarItems = false;
		isActiveBreakAllZeroStarItems = false;
		automationEnabled = false;
	}

	private void HandleInfoButtonPressed(DialogButton btn)
	{
		SetFissureState(FissureState.InfoDialog);
	}

	private void HandleInfoDialogOKPressed(DialogButton btn)
	{
		infoDialog.Hide();
	}

	private void TryPushResultToAutomation()
	{
		if (result.itemA == result.itemB)
		{
			TryPushResultToAutomation(result.itemA, result.itemA_count + result.itemB_count);
			return;
		}
		TryPushResultToAutomation(result.itemA, result.itemA_count);
		TryPushResultToAutomation(result.itemB, result.itemB_count);
	}

	private void TryPushResultToAutomation(Item item, int count)
	{
		if (item != null && ItemFactory.CanSplitApart(item))
		{
			AutomationEntry item2 = new AutomationEntry(item, count);
			automationQueue.Enqueue(item2);
		}
	}

	private int GetItemCountLimit()
	{
		if (equipFrame.item == null)
		{
			return 0;
		}
		return equipFrame.item.count;
	}

	public int GetStateNumericRepresentation()
	{
		return (int)fissureState;
	}

	protected override void Start()
	{
		base.Start();
		equipFrame.OnPressed += HandleEquipFramePressed;
		equipFrame.OnSecondaryPressed += HandleEquipSecondaryPressed;
		splitButton.OnPressed += HandleSplitPressed;
		unmakeButton.OnPressed += HandleUnmakePressed;
		unmakeConfirmationDialog.okButton.OnPressed += HandleUnmakeConfirmed;
		resultFrameA.OnPressed += HandleResultItemFramePressed;
		resultFrameA.OnSecondaryPressed += HandleResultItemFramePressed;
		resultFrameB.OnPressed += HandleResultItemFramePressed;
		resultFrameB.OnSecondaryPressed += HandleResultItemFramePressed;
		breakCompletelyButton.OnPressed += HandleBreakCompletelyButtonPressed;
		stopAutomationButton.OnPressed += HandleStopAutomationButtonPressed;
		infoButton.OnPressed += HandleInfoButtonPressed;
		infoDialog.okButton.OnPressed += HandleInfoDialogOKPressed;
	}

	protected override void OnDestroy()
	{
		equipFrame.OnPressed -= HandleEquipFramePressed;
		equipFrame.OnSecondaryPressed -= HandleEquipSecondaryPressed;
		splitButton.OnPressed -= HandleSplitPressed;
		unmakeButton.OnPressed -= HandleUnmakePressed;
		unmakeConfirmationDialog.okButton.OnPressed -= HandleUnmakeConfirmed;
		resultFrameA.OnPressed -= HandleResultItemFramePressed;
		resultFrameA.OnSecondaryPressed -= HandleResultItemFramePressed;
		resultFrameB.OnPressed -= HandleResultItemFramePressed;
		resultFrameB.OnSecondaryPressed -= HandleResultItemFramePressed;
		breakCompletelyButton.OnPressed -= HandleBreakCompletelyButtonPressed;
		stopAutomationButton.OnPressed -= HandleStopAutomationButtonPressed;
		infoButton.OnPressed -= HandleInfoButtonPressed;
		infoDialog.okButton.OnPressed -= HandleInfoDialogOKPressed;
		base.OnDestroy();
	}

	protected override void Awake()
	{
		base.Awake();
		singleton = this;
		plusMinusButtons = UnityEngine.Object.Instantiate(plusMinusButtonsPrefab);
		PlusMinusButtons obj = plusMinusButtons;
		obj.OnPlus = (Action<PlusMinusButtons, bool>)Delegate.Combine(obj.OnPlus, new Action<PlusMinusButtons, bool>(HandlePlusPressed));
		PlusMinusButtons obj2 = plusMinusButtons;
		obj2.OnMinus = (Action<PlusMinusButtons, bool>)Delegate.Combine(obj2.OnMinus, new Action<PlusMinusButtons, bool>(HandleMinusPressed));
		electricityArcFlash = electricityArcAnm.GetComponentInChildren<SpriteFrameFlashScreen>();
	}
}
