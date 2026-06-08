using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemScreen), typeof(ModalFade))]
public class AnvilScreen : AsciiObject, IAsciiObject
{
	public enum State
	{
		Disabled = 0,
		In = 1,
		Out = 2,
		Idle = 3,
		Fuse1 = 4,
		Fuse2 = 5,
		Fuse3 = 6,
		ImprovedItemDialog1 = 7,
		ImprovedItemDialog2 = 8,
		ImprovedItemDialog3 = 9,
		MakeAnotherDialog = 10,
		AutomatedCraftStep1 = 11,
		AutomatedCraftStep2 = 12,
		EnchantmentWarningDialog = 13,
		LostItemBoostDialog = 14,
		LostItemDumpIngredients = 15,
		LostItemBoost1 = 16,
		LostItemBoost2 = 17,
		LostItemBoost3 = 18,
		LostItemUpgrade1 = 19,
		LostItemUpgrade2 = 20,
		LostItemUpgrade3 = 21
	}

	private enum Step
	{
		BothSlotsEmpty = 0,
		LostItem = 1,
		FirstSlotFilled = 2,
		SecondSlotFilled = 3,
		BothSlotsFilled = 4
	}

	private const int AUTOMATION_DURATION_STEP_1 = 2;

	private const int AUTOMATION_DURATION_STEP_2 = 2;

	private const int AUTOMATION_DURATION_STEP_3 = 8;

	public AsciiSprite largeAnvilSprite;

	public DialogButton closeButton;

	public AsciiString step1Label;

	public AsciiString step2Label;

	public AsciiString step3Label;

	public DialogButton fuseButton;

	public DialogButton lostUpgradeButton;

	public DialogButton lostBoostButton;

	public DialogButton makeAnotherButton;

	public AsciiString makeAnotherSubLabel;

	public AnvilMakeAnotherDialog makeAnotherDialog;

	public AsciiString automatedCountLabel;

	private bool areResultsSwapped;

	public AsciiSprite blankAnvil;

	public AsciiAnimation smithyHammerLongAnm;

	public AsciiAnimation smithyHammerShortAnm;

	private AsciiAnimation smithyHammerAnm;

	public PlusMinusButtons plusMinusButtonsPrefab;

	private PlusMinusButtons plusMinusButtons;

	public DialogButton stopAutomationButton;

	public TwoChoiceDialog enchantmentWarningDialog;

	private bool confirmDoubleEnchantmentFuse;

	public LostBoostIngredientsDialog lostItemBoostDialog;

	private SpriteDump boostIngredientDump;

	private ItemDetailsDialog improvedItemDetailsDialog;

	private int improvedItemTransitionDuration = 25;

	public RollingMessage rollingMessage;

	public Action<Item, Item, int> OnPreFuse;

	private Item _firstSlot;

	private Item _secondSlot;

	private State currentState = State.Idle;

	private int stateElapsedTics;

	private Step currentStep;

	private ItemScreen itemScreen;

	private ModalFade modalFade;

	private ItemFactory.Result result;

	private int craftCount;

	private List<string> hasMadeItems = new List<string>();

	private float outAcceleration = 1.8f;

	private float inVelocity = 6f;

	private float inBounceThreshold = 6f;

	private float inBounceAcceleration = 1.6f;

	private float inBounceMaxVelocity = 1f;

	private float transitionMaxPosition = 29f;

	private float transitionOffsetY;

	private float transitionVelocity;

	private Item cloneOfOldItem;

	private bool firstTimeDrawing = true;

	private int automatedCraftedAmount = -1;

	private int automatedTargetAmount;

	public Item firstSlot
	{
		get
		{
			return _firstSlot;
		}
		set
		{
			if (value == _secondSlot && _secondSlot != null && itemScreen.IsDraggingFromEquipSlot())
			{
				if (secondSlotCount <= 1)
				{
					secondSlot = null;
				}
				else
				{
					HandleMinusPressed(plusMinusButtons, isRepeating: false);
				}
			}
			_firstSlot = value;
			UpdateStepBasedOnSlots();
			UpdatePlusMinusButtonStates();
			makeAnotherButton.enabled = false;
		}
	}

	public Item secondSlot
	{
		get
		{
			return _secondSlot;
		}
		set
		{
			if (value == _firstSlot && _firstSlot != null && itemScreen.IsDraggingFromEquipSlot())
			{
				firstSlot = null;
			}
			if (_secondSlot == value && value != null)
			{
				if (secondSlotCount < GetSecondSlotCountLimit())
				{
					HandlePlusPressed(plusMinusButtons, isRepeating: false);
				}
			}
			else
			{
				_secondSlot = value;
				secondSlotCount = (value ? 1 : 0);
				UpdateStepBasedOnSlots();
				UpdatePlusMinusButtonStates();
				makeAnotherButton.enabled = false;
			}
		}
	}

	public State CurrentState => currentState;

	public int StateElapsedTics => stateElapsedTics;

	public bool craftInterrupted { get; set; }

	public int secondSlotCount { get; set; }

	public static AnvilScreen singleton { get; private set; }

	public event Action<ItemFactory.Result> OnFuse;

	public void Show()
	{
		SetState(State.In);
		firstSlot = null;
		secondSlot = null;
		SetStep(Step.BothSlotsEmpty);
		itemScreen.UpdateContents();
		firstTimeDrawing = true;
		craftCount = 0;
		hasMadeItems.Clear();
		SetupMakeAnotherLabel();
	}

	public void Hide()
	{
		makeAnotherDialog.automationEnabled = false;
		if (craftCount > 0)
		{
			GameStates.Singleton.TryToSaveProgress();
		}
		SetState(State.Out);
	}

	private void SetState(State newState)
	{
		if (modalFade != null)
		{
			modalFade.active = newState != State.Disabled && newState != State.Out;
		}
		if (newState != State.Fuse1 && newState != State.Fuse2 && newState != State.LostItemBoost1 && newState != State.LostItemBoost2 && newState != State.LostItemBoost3 && newState != State.LostItemUpgrade1 && newState != State.LostItemUpgrade2 && newState != State.LostItemUpgrade3)
		{
			smithyHammerLongAnm.gameObject.SetActive(value: false);
			smithyHammerShortAnm.gameObject.SetActive(value: false);
		}
		switch (newState)
		{
		case State.In:
			transitionOffsetY = transitionMaxPosition;
			transitionVelocity = 0f - inVelocity;
			Inventory.Singleton.lockItemDestruction++;
			break;
		case State.Out:
		case State.Idle:
			transitionOffsetY = 0f;
			transitionVelocity = 0f;
			GameStates.Singleton.ShowMouse();
			FinalizeRemainingAutomatedLabel();
			break;
		case State.Disabled:
			transitionOffsetY = transitionMaxPosition;
			transitionVelocity = 0f;
			Inventory.Singleton.lockItemDestruction--;
			break;
		case State.Fuse1:
			if (IsAutomating())
			{
				smithyHammerAnm = smithyHammerShortAnm;
			}
			else
			{
				smithyHammerAnm = smithyHammerLongAnm;
				GameStates.Singleton.HideMouse();
			}
			smithyHammerAnm.gameObject.SetActive(value: true);
			smithyHammerAnm.Stop();
			smithyHammerAnm.Play();
			makeAnotherButton.enabled = false;
			break;
		case State.Fuse2:
			if (result.outcome == ItemFactory.Result.Outcome.Fused || result.outcome == ItemFactory.Result.Outcome.Boosted)
			{
				SfxController.singleton.Play("smithy_hammer");
			}
			else
			{
				SfxController.singleton.Play("smithy_hammer_fail");
			}
			UpdateRemainingAutomatedLabel();
			break;
		case State.MakeAnotherDialog:
			if (result != null)
			{
				makeAnotherDialog.anvilScreen = this;
				makeAnotherDialog.item = result.resultingItem;
				makeAnotherDialog.maxAmount = HowManyTimesCouldBeRepeated(result);
			}
			makeAnotherDialog.Show();
			break;
		case State.AutomatedCraftStep1:
			if (areResultsSwapped)
			{
				itemScreen.EquipLeft(result.itemB as Weapon);
			}
			else
			{
				itemScreen.EquipLeft(result.itemA as Weapon);
			}
			break;
		case State.AutomatedCraftStep2:
			if (areResultsSwapped)
			{
				itemScreen.EquipRight(result.itemA as Weapon, playSfx: false);
				secondSlotCount = result.itemA_count;
			}
			else
			{
				itemScreen.EquipRight(result.itemB as Weapon, playSfx: false);
				secondSlotCount = result.itemB_count - result.itemB_remainder;
			}
			break;
		case State.EnchantmentWarningDialog:
			confirmDoubleEnchantmentFuse = false;
			enchantmentWarningDialog.Show();
			break;
		case State.LostItemBoostDialog:
			lostItemBoostDialog.Show(firstSlot);
			break;
		case State.LostItemDumpIngredients:
			SetupBoostIngredientDumpAnimation();
			GameStates.Singleton.HideMouse();
			lostUpgradeButton.enabled = false;
			lostBoostButton.enabled = false;
			SfxController.singleton.Play("lost_item_boost");
			break;
		case State.LostItemBoost1:
		case State.LostItemUpgrade1:
			smithyHammerAnm = smithyHammerLongAnm;
			smithyHammerAnm.gameObject.SetActive(value: true);
			smithyHammerAnm.Stop();
			smithyHammerAnm.Play();
			lostUpgradeButton.enabled = false;
			lostBoostButton.enabled = false;
			break;
		case State.LostItemBoost2:
		case State.LostItemUpgrade2:
			boostIngredientDump.Stop();
			break;
		}
		currentState = newState;
		stateElapsedTics = 0;
	}

	private void UpdateStepBasedOnSlots()
	{
		if ((bool)secondSlot)
		{
			if ((bool)firstSlot)
			{
				SetStep(Step.BothSlotsFilled);
			}
			else if (secondSlot.isLost)
			{
				Item item = (firstSlot = secondSlot);
				itemScreen.leftEquippedFrame.item = item;
				secondSlot = null;
				itemScreen.rightEquippedFrame.item = null;
				SetStep(Step.LostItem);
			}
			else
			{
				SetStep(Step.SecondSlotFilled);
			}
		}
		else if ((bool)firstSlot)
		{
			if (firstSlot.isLost)
			{
				SetStep(Step.LostItem);
			}
			else
			{
				SetStep(Step.FirstSlotFilled);
			}
		}
		else
		{
			SetStep(Step.BothSlotsEmpty);
		}
	}

	private void SetStep(Step newStep)
	{
		itemScreen.leftEquippedFrame.enabled = true;
		itemScreen.rightEquippedFrame.enabled = newStep >= Step.FirstSlotFilled;
		if (newStep == Step.LostItem)
		{
			UpdateLostUpgradeButton();
			UpdateLostBoostButton();
		}
		currentStep = newStep;
	}

	public override void UpdateTic()
	{
		stateElapsedTics++;
		if (currentState == State.Out)
		{
			transitionVelocity += outAcceleration;
			transitionOffsetY += transitionVelocity;
			if (transitionOffsetY > transitionMaxPosition)
			{
				SetState(State.Disabled);
			}
		}
		else if (currentState == State.In)
		{
			bool flag = transitionOffsetY >= 0f && transitionVelocity >= 0f;
			if (transitionOffsetY > inBounceThreshold)
			{
				transitionOffsetY += transitionVelocity;
			}
			else
			{
				transitionVelocity = Mathf.Min(inBounceMaxVelocity, transitionVelocity + inBounceAcceleration);
				transitionOffsetY += transitionVelocity;
				if (transitionOffsetY >= 0f && transitionVelocity >= 0f)
				{
					flag = true;
				}
			}
			if (flag)
			{
				SetState(State.Idle);
				transitionOffsetY = 0f;
				transitionVelocity = 0f;
			}
			itemScreen.UpdateTic();
		}
		else if (currentState == State.Idle)
		{
			closeButton.UpdateTic();
			if (currentStep == Step.BothSlotsFilled)
			{
				fuseButton.UpdateTic();
			}
			else if (currentStep == Step.LostItem)
			{
				if (lostUpgradeButton.enabled)
				{
					lostUpgradeButton.UpdateTic();
				}
				if (lostBoostButton.enabled)
				{
					lostBoostButton.UpdateTic();
				}
			}
			plusMinusButtons.UpdateTic();
			if (makeAnotherButton.enabled)
			{
				makeAnotherButton.UpdateTic();
			}
			itemScreen.UpdateTic();
		}
		else if (currentState == State.Fuse1 && stateElapsedTics == 7)
		{
			result = ItemFactory.singleton.CombineItems(firstSlot, secondSlot, 1, secondSlotCount);
			areResultsSwapped = result.itemA == secondSlot && result.itemB == firstSlot && result.itemB_count == 1;
			ShowResult(0.5f);
			if (result.resultingItem != null)
			{
				craftCount++;
				string groupId = result.resultingItem.GetGroupId();
				bool hasMadeBefore = hasMadeItems.Contains(groupId);
				AnalyticsMacros.ItemCrafted(result, hasMadeBefore);
				AchievementController.singleton.ReportCraftedOnAnvil(result);
				this.OnFuse?.Invoke(result);
			}
			else
			{
				AnalyticsMacros.ItemCraftFailed(result);
			}
			SetState(State.Fuse2);
		}
		else if (currentState == State.Fuse2)
		{
			if (stateElapsedTics == 8 && makeAnotherDialog.automationEnabled)
			{
				makeAnotherDialog.amountToMake--;
				if (makeAnotherDialog.amountToMake <= 0)
				{
					makeAnotherDialog.automationEnabled = false;
				}
				else
				{
					SetState(State.AutomatedCraftStep1);
				}
			}
			else if (stateElapsedTics >= 45)
			{
				SetState(State.Fuse3);
			}
		}
		else if (currentState == State.Fuse3 && stateElapsedTics == 12)
		{
			SetState(State.Idle);
			if (result.outcome == ItemFactory.Result.Outcome.Fused || result.outcome == ItemFactory.Result.Outcome.Boosted)
			{
				string groupId2 = result.resultingItem.GetGroupId();
				if (!hasMadeItems.Contains(groupId2))
				{
					hasMadeItems.Add(groupId2);
					itemScreen.ShowItemDetails(result.itemA);
					itemScreen.itemDetailsDialog.hasReroll = false;
					improvedItemDetailsDialog.item = result.resultingItem;
					improvedItemDetailsDialog.Show();
					SetState(State.ImprovedItemDialog1);
				}
				if (!result.resultingItem.isLost)
				{
					makeAnotherButton.enabled = HowManyTimesCouldBeRepeated(result) > 0;
				}
			}
		}
		else if (currentState == State.ImprovedItemDialog1)
		{
			itemScreen.UpdateTic();
			improvedItemDetailsDialog.UpdateTic();
			if (stateElapsedTics == 25 || AsciiMouse.singleton.down0)
			{
				SetState(State.ImprovedItemDialog2);
			}
			else if (itemScreen.itemDetailsDialog.CurrentState == DialogNineSlice.State.Out)
			{
				SetState(State.Idle);
			}
		}
		else if (currentState == State.ImprovedItemDialog2)
		{
			itemScreen.UpdateTic();
			improvedItemDetailsDialog.UpdateTic();
			if (stateElapsedTics == improvedItemTransitionDuration || AsciiMouse.singleton.down0 || improvedItemDetailsDialog.CurrentState == DialogNineSlice.State.Out)
			{
				SetState(State.ImprovedItemDialog3);
			}
			else if (itemScreen.itemDetailsDialog.CurrentState == DialogNineSlice.State.Out)
			{
				SetState(State.Idle);
			}
		}
		else if (currentState == State.ImprovedItemDialog3)
		{
			itemScreen.UpdateTic();
			improvedItemDetailsDialog.UpdateTic();
			if (improvedItemDetailsDialog.CurrentState == DialogNineSlice.State.Disabled || itemScreen.itemDetailsDialog.CurrentState == DialogNineSlice.State.Out)
			{
				SetState(State.Idle);
			}
		}
		else if (currentState == State.MakeAnotherDialog)
		{
			makeAnotherDialog.UpdateTic();
			if (makeAnotherDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				if (makeAnotherDialog.automationEnabled)
				{
					SetupRemainingAutomatedLabel();
					SetState(State.AutomatedCraftStep1);
				}
				else
				{
					SetState(State.Idle);
				}
			}
		}
		else if (currentState == State.AutomatedCraftStep1 && StateElapsedTics >= 2)
		{
			SetState(State.AutomatedCraftStep2);
		}
		else if (currentState == State.AutomatedCraftStep2 && StateElapsedTics >= 2)
		{
			HandleFuseButtonPressed(null);
		}
		else if (currentState == State.EnchantmentWarningDialog)
		{
			enchantmentWarningDialog.UpdateTic();
			if (enchantmentWarningDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				if (confirmDoubleEnchantmentFuse)
				{
					SetState(State.Fuse1);
				}
				else
				{
					SetState(State.Idle);
				}
			}
		}
		else if (currentState == State.LostItemBoostDialog)
		{
			lostItemBoostDialog.UpdateTic();
			if (lostItemBoostDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				if (lostItemBoostDialog.ComputePercentage() >= 1f)
				{
					SetState(State.LostItemDumpIngredients);
				}
				else
				{
					SetState(State.Idle);
				}
			}
		}
		else if (currentState == State.LostItemDumpIngredients && stateElapsedTics == 85)
		{
			SetState(State.LostItemBoost1);
		}
		else if (stateElapsedTics == 7 && (currentState == State.LostItemBoost1 || currentState == State.LostItemUpgrade1))
		{
			SfxController.singleton.Play("smithy_hammer");
		}
		else if (currentState == State.LostItemBoost1 && stateElapsedTics >= 9)
		{
			firstSlot.lostCount++;
			firstSlot.lostBoostsUsed++;
			lostItemBoostDialog.SubtractFromInventory();
			lostItemBoostDialog.ClearIngredientAmounts();
			int lostCount = firstSlot.lostCount;
			int nextLostCountGoal = firstSlot.GetNextLostCountGoal();
			string message = lostCount - 1 + "/" + nextLostCountGoal + " → " + lostCount + "/" + nextLostCountGoal;
			rollingMessage.Show(message, ColorConstants.lightGrey, 1f);
			SetState(State.LostItemBoost2);
		}
		else if (currentState == State.LostItemBoost2 && stateElapsedTics >= 30)
		{
			UpdateLostUpgradeButton();
			UpdateLostBoostButton();
			itemScreen.UpdateContents();
			SetState(State.LostItemBoost3);
		}
		else if (currentState == State.LostItemBoost3 && stateElapsedTics == 12)
		{
			SetState(State.Idle);
		}
		else if (currentState == State.LostItemUpgrade1 && StateElapsedTics >= 9)
		{
			cloneOfOldItem = ItemFactory.singleton.CloneItem(firstSlot);
			cloneOfOldItem.LoadAbilities();
			int levelDisplayIntegerForItem = ItemFactory.GetLevelDisplayIntegerForItem(firstSlot);
			firstSlot.level *= 2;
			string message2 = "☆" + (levelDisplayIntegerForItem - 1) + "☆  →  ☆" + levelDisplayIntegerForItem + "☆";
			rollingMessage.Show(message2, ColorConstants.lightGrey, 1f);
			SetState(State.LostItemUpgrade2);
		}
		else if (currentState == State.LostItemUpgrade2 && stateElapsedTics >= 30)
		{
			UpdateLostUpgradeButton();
			UpdateLostBoostButton();
			itemScreen.UpdateContents();
			SetState(State.LostItemUpgrade3);
		}
		else if (currentState == State.LostItemUpgrade3 && stateElapsedTics == 12)
		{
			itemScreen.ShowItemDetails(cloneOfOldItem);
			itemScreen.itemDetailsDialog.hasReroll = false;
			improvedItemDetailsDialog.item = firstSlot;
			improvedItemDetailsDialog.Show();
			cloneOfOldItem = null;
			SetState(State.ImprovedItemDialog1);
		}
		if (IsAutomating())
		{
			closeButton.UpdateTic();
			stopAutomationButton.UpdateTic();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (modalFade != null)
		{
			modalFade.Draw(r);
		}
		int count = itemScreen.rows.Count;
		int num = ((count <= 1) ? 3 : ((count != 2) ? 1 : 2));
		if (firstTimeDrawing)
		{
			PositionY = num;
			firstTimeDrawing = false;
		}
		else if (num < PositionY)
		{
			PositionY--;
		}
		offsetX += PositionX + (Width >> 1);
		offsetY += PositionY + (int)transitionOffsetY;
		if (currentState == State.Idle)
		{
			r.Clear();
		}
		if (currentState == State.Disabled)
		{
			return;
		}
		largeAnvilSprite.Draw(r, offsetX, offsetY);
		if (itemScreen.currentState != ItemScreen.State.ItemDetails && itemScreen.currentState != ItemScreen.State.CraftBook)
		{
			itemScreen.Draw(r, offsetX, offsetY);
		}
		if (currentStep == Step.BothSlotsEmpty)
		{
			step1Label.Draw(r, offsetX, offsetY);
		}
		else if (currentStep == Step.FirstSlotFilled)
		{
			int offsetX2 = ((step2Label.Length > 10) ? (offsetX + (step2Label.Length - 10)) : offsetX);
			step2Label.Draw(r, offsetX2, offsetY);
		}
		else if (currentStep == Step.SecondSlotFilled)
		{
			int offsetX3 = ((step2Label.Length > 10) ? (offsetX - (step2Label.Length - 10)) : offsetX);
			step3Label.Draw(r, offsetX3, offsetY);
		}
		else if (currentStep == Step.BothSlotsFilled)
		{
			fuseButton.Draw(r, offsetX, offsetY);
		}
		else if (currentStep == Step.LostItem)
		{
			UpdateLostButtonColor(lostUpgradeButton);
			lostUpgradeButton.Draw(r, offsetX, offsetY);
			UpdateLostButtonColor(lostBoostButton);
			lostBoostButton.Draw(r, offsetX, offsetY);
		}
		if (makeAnotherButton.enabled)
		{
			makeAnotherButton.Draw(r, offsetX, offsetY);
			makeAnotherSubLabel.Draw(r, offsetX + makeAnotherButton.PositionX + makeAnotherButton.label.PositionX, offsetY + makeAnotherButton.PositionY + 2);
		}
		itemScreen.DrawDraggingIcon(r);
		rollingMessage.Draw(r, offsetX, offsetY);
		plusMinusButtons.Draw(r, offsetX, offsetY);
		closeButton.Draw(r, 0, offsetY);
		if (itemScreen.currentState == ItemScreen.State.ItemDetails || itemScreen.currentState == ItemScreen.State.CraftBook)
		{
			itemScreen.Draw(r, offsetX, offsetY);
		}
		if ((currentState == State.Fuse2 || currentState == State.Fuse3) && (result.outcome == ItemFactory.Result.Outcome.Fused || result.outcome == ItemFactory.Result.Outcome.Boosted))
		{
			blankAnvil.Draw(r, offsetX, offsetY);
			float t = 0f;
			float a = 9f;
			float num2 = 6f;
			if (currentState == State.Fuse3)
			{
				t = (float)stateElapsedTics / num2 - 1f;
			}
			int offsetX4 = offsetX + itemScreen.PositionX + (int)Mathf.Lerp(a, 0f, t);
			int offsetY2 = offsetY + itemScreen.PositionY;
			itemScreen.leftEquippedFrame.Draw(r, offsetX4, offsetY2);
		}
		DrawRemainingAutomatedLabel(r, offsetX, offsetY);
		if (smithyHammerAnm != null && (currentState == State.Fuse1 || currentState == State.Fuse2))
		{
			smithyHammerAnm.Sprite.Draw(r, offsetX, offsetY);
		}
		if (currentState == State.ImprovedItemDialog2)
		{
			if (improvedItemDetailsDialog.Height < itemScreen.itemDetailsDialog.Height)
			{
				improvedItemDetailsDialog.PositionY = itemScreen.itemDetailsDialog.PositionY;
				improvedItemDetailsDialog.Height = itemScreen.itemDetailsDialog.Height;
			}
			int num3 = improvedItemDetailsDialog.Height * stateElapsedTics / improvedItemTransitionDuration;
			num3 += (r.height >> 1) + improvedItemDetailsDialog.PositionY;
			if (improvedItemDetailsDialog.CurrentState == DialogNineSlice.State.Idle)
			{
				int lastDrawX = itemScreen.itemDetailsDialog.lastDrawX;
				int num4 = lastDrawX + improvedItemDetailsDialog.Width - 1;
				for (int i = lastDrawX; i <= num4; i++)
				{
					r.SetCell(i, num3, SpecialSymbols.Map('█'), Color.white);
				}
			}
			r.PushClip(new AsciiRenderProcedural.Clip
			{
				bottom = r.height - num3
			});
			improvedItemDetailsDialog.Draw(r, r.width >> 1, r.height >> 1);
			r.PopClip();
		}
		else if (currentState == State.ImprovedItemDialog3)
		{
			improvedItemDetailsDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (currentState == State.MakeAnotherDialog)
		{
			makeAnotherDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (currentState == State.EnchantmentWarningDialog)
		{
			enchantmentWarningDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (currentState == State.LostItemBoostDialog)
		{
			lostItemBoostDialog.Draw(r, r.width >> 1, 0);
		}
		else if (currentState == State.LostItemDumpIngredients)
		{
			boostIngredientDump.Draw(r, offsetX, offsetY);
		}
		else if (currentState == State.LostItemBoost1)
		{
			boostIngredientDump.Draw(r, offsetX, offsetY);
			smithyHammerAnm.Sprite.Draw(r, offsetX, offsetY);
		}
		else if (currentState == State.LostItemBoost2 || currentState == State.LostItemBoost3 || currentState == State.LostItemUpgrade1 || currentState == State.LostItemUpgrade2 || currentState == State.LostItemUpgrade3)
		{
			smithyHammerAnm.Sprite.Draw(r, offsetX, offsetY);
		}
		if (IsAutomating())
		{
			stopAutomationButton.Draw(r, r.width, r.height);
		}
	}

	private void UpdateLostButtonColor(DialogButton button)
	{
		if (button.enabled)
		{
			button.label.color = ColorConstants.white;
			button.edgeSymbols.color = ColorConstants.grey;
		}
		else
		{
			button.label.color = ColorConstants.darkGrey;
			button.edgeSymbols.color = ColorConstants.darkGrey;
		}
	}

	private void UpdateLostUpgradeButton()
	{
		if (ItemFactory.GetLevelDisplayIntegerForItem(firstSlot) == ItemFactory.MAX_DISPLAY_LEVEL)
		{
			lostUpgradeButton.enabled = false;
			return;
		}
		int lostCount = firstSlot.lostCount;
		int nextLostCountGoal = firstSlot.GetNextLostCountGoal();
		lostUpgradeButton.enabled = lostCount >= nextLostCountGoal;
	}

	private void UpdateLostBoostButton()
	{
		if (ItemFactory.GetLevelDisplayIntegerForItem(firstSlot) == ItemFactory.MAX_DISPLAY_LEVEL)
		{
			lostBoostButton.enabled = false;
		}
		else
		{
			lostBoostButton.enabled = lostItemBoostDialog.CanLostItemBeBoosted(firstSlot);
		}
	}

	private void SetupBoostIngredientDumpAnimation()
	{
		boostIngredientDump.Clear();
		foreach (KeyValuePair<Item, int> ingredientAmount in lostItemBoostDialog.ingredientAmounts)
		{
			Item key = ingredientAmount.Key;
			int num = ingredientAmount.Value;
			if (num > 3)
			{
				num = 2 + num / 10;
			}
			AsciiSprite icon = key.GetIcon();
			boostIngredientDump.AddSprite(icon, num);
		}
		boostIngredientDump.Play();
	}

	private void SetupMakeAnotherLabel()
	{
		string[] array = Utils.BreakIntoLines(Te.xt("tid_anvil_7"), 11);
		if (array.Length == 1)
		{
			makeAnotherButton.Height = 3;
			makeAnotherSubLabel.Clear();
		}
		else
		{
			makeAnotherButton.Height = 4;
			makeAnotherSubLabel.SetValue(array[1]);
		}
		makeAnotherButton.label.SetValue(array[0]);
	}

	private int HowManyTimesCouldBeRepeated(ItemFactory.Result craftResult)
	{
		if (craftResult != null && craftResult.resultingItem != null && craftResult.itemA != null && craftResult.itemB != null && craftResult.itemA_count > 0 && craftResult.itemB_count > 0)
		{
			string groupId = craftResult.itemA.GetGroupId();
			if (!Inventory.Singleton.HasItemByGroupId(groupId))
			{
				return 0;
			}
			Item item = Inventory.Singleton.GetItem(groupId);
			if (item == null)
			{
				return 0;
			}
			groupId = craftResult.itemB.GetGroupId();
			if (!Inventory.Singleton.HasItemByGroupId(groupId))
			{
				return 0;
			}
			Item item2 = Inventory.Singleton.GetItem(groupId);
			if (item2 == null)
			{
				return 0;
			}
			int num = result.itemB_count - result.itemB_remainder;
			if (item == item2)
			{
				return item.count / (craftResult.itemA_count + num);
			}
			int a = item.count / craftResult.itemA_count;
			int b = item2.count / num;
			return Mathf.Min(a, b);
		}
		return 0;
	}

	private bool IsAutomating()
	{
		if (makeAnotherDialog.automationEnabled)
		{
			return makeAnotherDialog.amountToMake > 1;
		}
		return false;
	}

	private void HandleCloseButtonPressed(DialogButton button)
	{
		Hide();
		itemScreen.SetState(ItemScreen.State.Normal);
		itemScreen.itemSelectedContextButtons.Hide();
	}

	private void HandleMakeAnotherButtonPressed(DialogButton button)
	{
		SetState(State.MakeAnotherDialog);
	}

	private void HandleFuseButtonPressed(DialogButton button)
	{
		craftInterrupted = false;
		OnPreFuse?.Invoke(firstSlot, secondSlot, secondSlotCount);
		if (craftInterrupted)
		{
			ShowError(Te.xt("tid_craft_interrupted"));
		}
		else if (currentStep == Step.BothSlotsFilled)
		{
			if (firstSlot != null && secondSlot != null && firstSlot.GetRarityType() != ItemData.Rarity.Type.Common && secondSlot.GetRarityType() != ItemData.Rarity.Type.Common)
			{
				SetState(State.EnchantmentWarningDialog);
			}
			else
			{
				SetState(State.Fuse1);
			}
		}
	}

	private void HandleLostUpgradeButtonPressed(DialogButton button)
	{
		SetState(State.LostItemUpgrade1);
	}

	private void HandleLostBoostButtonPressed(DialogButton button)
	{
		SetState(State.LostItemBoostDialog);
	}

	private void UpdatePlusMinusButtonStates()
	{
		if (!makeAnotherDialog.automationEnabled)
		{
			if (secondSlot == null)
			{
				plusMinusButtons.Hide();
			}
			else if (GetSecondSlotCountLimit() > 1 && ItemFactory.GetLevelDisplayIntegerForItem(secondSlot) < 9)
			{
				plusMinusButtons.Show();
				plusMinusButtons.plusButton.enabled = true;
			}
			else
			{
				plusMinusButtons.Hide();
				secondSlotCount = 1;
			}
		}
	}

	private void HandlePlusPressed(PlusMinusButtons buttons, bool isRepeating)
	{
		int secondSlotCountLimit = GetSecondSlotCountLimit();
		if (secondSlotCount < secondSlotCountLimit)
		{
			int num = 1;
			if (secondSlotCount >= 50 && isRepeating)
			{
				num = 11;
				num = Mathf.Min(num, secondSlotCountLimit - secondSlotCount);
			}
			secondSlotCount = itemScreen.rightEquippedFrame.count + num;
			if (secondSlotCount == GetSecondSlotCountLimit())
			{
				plusMinusButtons.plusButton.enabled = false;
			}
			itemScreen.UpdateContentForItemCountChange(itemScreen.rightEquippedFrame.item);
			plusMinusButtons.repeatFrameSkip = ((secondSlotCount < 10) ? 2 : 0);
		}
	}

	private void HandleMinusPressed(PlusMinusButtons buttons, bool isRepeating)
	{
		if (secondSlotCount == 1)
		{
			secondSlot = null;
			plusMinusButtons.minusButton.activated = false;
		}
		plusMinusButtons.plusButton.enabled = true;
		int num = 1;
		if (secondSlotCount > 100 && isRepeating)
		{
			num = 11;
		}
		secondSlotCount = itemScreen.rightEquippedFrame.count - num;
		itemScreen.UpdateContentForItemCountChange(itemScreen.rightEquippedFrame.item);
		plusMinusButtons.repeatFrameSkip = ((secondSlotCount < 10) ? 2 : 0);
	}

	private int GetSecondSlotCountLimit()
	{
		if (secondSlot == null)
		{
			return 0;
		}
		if (firstSlot == null)
		{
			return 1;
		}
		if (secondSlot == firstSlot)
		{
			return secondSlot.count - 1;
		}
		if (secondSlot.id == firstSlot.id && secondSlot.level <= firstSlot.level && secondSlot.element == firstSlot.element)
		{
			return secondSlot.count;
		}
		return 1;
	}

	private void ShowResult(float delay)
	{
		if (result.outcome == ItemFactory.Result.Outcome.CannotFuse || result.outcome == ItemFactory.Result.Outcome.TooComplexToBoost || result.outcome == ItemFactory.Result.Outcome.CantBoostWithElement)
		{
			ShowError(Te.xt("NO RESULT"), delay);
		}
		else if (result.outcome == ItemFactory.Result.Outcome.ItemNotFound)
		{
			ShowError(Te.xt("ITEM NOT FOUND"), delay);
		}
		else if (result.outcome == ItemFactory.Result.Outcome.None)
		{
			ShowError(Te.xt("UNKNOWN OUTCOME"), delay);
		}
		else if (result.outcome == ItemFactory.Result.Outcome.Fused || result.outcome == ItemFactory.Result.Outcome.Boosted)
		{
			CraftBookScreen.singleton.ReportCraft(result);
			Inventory.Singleton.RemoveItem(result.itemA, result.itemA_count);
			Inventory.Singleton.RemoveItem(result.itemB, result.itemB_count - result.itemB_remainder);
			result.resultingItem = Inventory.Singleton.AddItem(result.resultingItem);
			result.resultingItem.hasInteracted = true;
			firstSlot = result.resultingItem;
			if (result.itemB_remainder == 0)
			{
				secondSlot = null;
			}
			else
			{
				secondSlotCount = result.itemB_remainder;
			}
			UnequipAndReequip(result.itemA, result.resultingItem);
			UnequipAndReequip(result.itemB, result.resultingItem);
			UtilityBeltKeyShortcuts.singleton.ReportCraft(result);
			ShowSuccess(result.resultingItem, delay);
		}
		itemScreen.UpdateContents();
	}

	public static void UnequipAndReequip(Item oldItem, Item newItem)
	{
		if (oldItem == null || newItem == null)
		{
			return;
		}
		Hero hero = GameStates.Singleton.hero;
		Item leftHand = hero.LeftHand;
		Item rightHand = hero.RightHand;
		Item weapon = hero.faerie.weapon;
		bool flag = leftHand == oldItem;
		bool flag2 = rightHand == oldItem;
		bool flag3 = weapon == oldItem;
		if (!(flag || flag2 || flag3))
		{
			return;
		}
		Weapon weapon2 = oldItem as Weapon;
		if (weapon2 != null)
		{
			hero.Unequip(weapon2);
		}
		weapon2 = newItem as Weapon;
		if (weapon2 != null)
		{
			if (flag)
			{
				hero.EquipLeft(weapon2);
			}
			else if (flag2)
			{
				hero.EquipRight(weapon2);
			}
			else if (flag3)
			{
				hero.faerie.weapon = weapon2;
			}
		}
	}

	private void ShowError(string message, float delay = 0f)
	{
		rollingMessage.Show(message, Color.red, delay);
	}

	private void ShowSuccess(Item item, float delay = 0f)
	{
		string starRatingStringForItem = ItemFactory.GetStarRatingStringForItem(item);
		rollingMessage.Show(starRatingStringForItem + " " + item.GetName() + " " + starRatingStringForItem, ColorConstants.lightGrey, delay);
	}

	private void Update()
	{
		if (itemScreen.currentState == ItemScreen.State.Normal && Input.GetKeyDown(KeyCode.Escape))
		{
			if (IsAutomating())
			{
				HandleStopAutomationButtonPressed(null);
			}
			else if (currentState == State.Idle)
			{
				HandleCloseButtonPressed(null);
			}
		}
	}

	private void SetupRemainingAutomatedLabel()
	{
		automatedCraftedAmount = 0;
		automatedTargetAmount = makeAnotherDialog.amountToMake;
		_UpdateAutomatedLabel();
	}

	private void UpdateRemainingAutomatedLabel()
	{
		if (automatedCraftedAmount >= 0)
		{
			automatedCraftedAmount++;
			if (automatedCraftedAmount <= automatedTargetAmount)
			{
				_UpdateAutomatedLabel();
			}
		}
	}

	private void _UpdateAutomatedLabel()
	{
		automatedCountLabel.SetValue(" " + automatedCraftedAmount + " / " + automatedTargetAmount + " ");
	}

	private void FinalizeRemainingAutomatedLabel()
	{
		automatedCraftedAmount = -1;
	}

	private void DrawRemainingAutomatedLabel(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (automatedCraftedAmount >= 0)
		{
			automatedCountLabel.Draw(r, offsetX, offsetY);
		}
	}

	private void HandleImprovedItemDialogClickedOutside()
	{
		itemScreen.itemDetailsDialog.Hide();
	}

	private void HandleImprovedItemDialogCloseButton(DialogButton button)
	{
		itemScreen.itemDetailsDialog.Hide();
	}

	private void HandleRerollEnchantmentPressed(DialogButton btn)
	{
		Item item = ((btn == improvedItemDetailsDialog.rerollEnchantmentButton) ? improvedItemDetailsDialog.item : itemScreen.itemDetailsDialog.item);
		int num = item.ComputeRerollCost();
		if (num <= InventoryResources.singleton.GetResourceOfType(Data.Resource.Xi))
		{
			InventoryResources.singleton.RemoveResourceOfType(Data.Resource.Xi, num);
			Item item2 = ItemFactory.singleton.RerollEnchantment(item);
			Inventory.Singleton.RemoveItem(item, 1);
			item2 = Inventory.Singleton.AddItem(item2);
			item2.hasInteracted = true;
			if (firstSlot == item)
			{
				firstSlot = item2;
				itemScreen.leftEquippedFrame.item = item2;
			}
			else if (secondSlot == item)
			{
				secondSlot = item2;
				itemScreen.rightEquippedFrame.item = item2;
			}
			UnequipAndReequip(item, item2);
			Weapon weapon = (Weapon)item;
			Weapon weapon2 = (Weapon)item2;
			if (weapon != null && weapon2 != null)
			{
				UtilityBeltKeyShortcuts.singleton.ReportCraft(weapon, weapon2);
			}
			itemScreen.UpdateContents();
			itemScreen.itemDetailsDialog.item = item;
			itemScreen.itemDetailsDialog.hasReroll = false;
			improvedItemDetailsDialog.item = item2;
			improvedItemDetailsDialog.Show();
			SetState(State.ImprovedItemDialog1);
		}
	}

	private void HandleStopAutomationButtonPressed(DialogButton btn)
	{
		makeAnotherDialog.amountToMake = 0;
	}

	private void HandleEnchantmentWarningConfirmed(DialogButton btn)
	{
		confirmDoubleEnchantmentFuse = true;
		enchantmentWarningDialog.Hide();
	}

	public int GetStateNumericRepresentation()
	{
		return (int)currentState;
	}

	private void Start()
	{
		largeAnvilSprite.Load();
		smithyHammerLongAnm.Sprite.Load();
		smithyHammerShortAnm.Sprite.Load();
		improvedItemDetailsDialog = UnityEngine.Object.Instantiate(itemScreen.itemDetailsDialogPrefab);
		ModalFade component = improvedItemDetailsDialog.gameObject.GetComponent<ModalFade>();
		if (component != null)
		{
			UnityEngine.Object.Destroy(component);
		}
		improvedItemDetailsDialog.OnClickedOutside += HandleImprovedItemDialogClickedOutside;
		improvedItemDetailsDialog.closeButton.OnPressed += HandleImprovedItemDialogCloseButton;
		closeButton.OnPressed += HandleCloseButtonPressed;
		fuseButton.OnPressed += HandleFuseButtonPressed;
		lostUpgradeButton.OnPressed += HandleLostUpgradeButtonPressed;
		lostBoostButton.OnPressed += HandleLostBoostButtonPressed;
		makeAnotherButton.OnPressed += HandleMakeAnotherButtonPressed;
		itemScreen.itemDetailsDialog.rerollEnchantmentButton.OnPressed += HandleRerollEnchantmentPressed;
		improvedItemDetailsDialog.rerollEnchantmentButton.OnPressed += HandleRerollEnchantmentPressed;
		stopAutomationButton.OnPressed += HandleStopAutomationButtonPressed;
		enchantmentWarningDialog.okButton.OnPressed += HandleEnchantmentWarningConfirmed;
	}

	private void OnDestroy()
	{
		if (improvedItemDetailsDialog != null)
		{
			improvedItemDetailsDialog.OnClickedOutside -= HandleImprovedItemDialogClickedOutside;
			improvedItemDetailsDialog.closeButton.OnPressed -= HandleImprovedItemDialogCloseButton;
		}
		closeButton.OnPressed -= HandleCloseButtonPressed;
		fuseButton.OnPressed -= HandleFuseButtonPressed;
		lostUpgradeButton.OnPressed -= HandleLostUpgradeButtonPressed;
		lostBoostButton.OnPressed -= HandleLostBoostButtonPressed;
		makeAnotherButton.OnPressed -= HandleMakeAnotherButtonPressed;
		itemScreen.itemDetailsDialog.rerollEnchantmentButton.OnPressed -= HandleRerollEnchantmentPressed;
		improvedItemDetailsDialog.rerollEnchantmentButton.OnPressed -= HandleRerollEnchantmentPressed;
		stopAutomationButton.OnPressed -= HandleStopAutomationButtonPressed;
		enchantmentWarningDialog.okButton.OnPressed -= HandleEnchantmentWarningConfirmed;
	}

	private void Awake()
	{
		singleton = this;
		itemScreen = GetComponent<ItemScreen>();
		itemScreen.mode = ItemScreen.Mode.Anvil;
		modalFade = GetComponent<ModalFade>();
		plusMinusButtons = UnityEngine.Object.Instantiate(plusMinusButtonsPrefab);
		PlusMinusButtons obj = plusMinusButtons;
		obj.OnPlus = (Action<PlusMinusButtons, bool>)Delegate.Combine(obj.OnPlus, new Action<PlusMinusButtons, bool>(HandlePlusPressed));
		PlusMinusButtons obj2 = plusMinusButtons;
		obj2.OnMinus = (Action<PlusMinusButtons, bool>)Delegate.Combine(obj2.OnMinus, new Action<PlusMinusButtons, bool>(HandleMinusPressed));
		boostIngredientDump = GetComponent<SpriteDump>();
		boostIngredientDump.Stop();
	}
}
