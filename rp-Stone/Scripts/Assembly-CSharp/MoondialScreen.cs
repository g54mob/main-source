using System;
using System.Collections.Generic;
using UnityEngine;

public class MoondialScreen : PopUpModalScreen
{
	private enum MoondialState
	{
		Idle = 0,
		SelectingItem = 1,
		ItemDetails = 2,
		ImprovedItemDialog1 = 3,
		ImprovedItemDialog2 = 4,
		ImprovedItemDialog3 = 5,
		Mutating = 6
	}

	private const int MUTATE_DURATION = 30;

	public AsciiSprite highlightMoon;

	public AsciiSprite highlightArea1;

	public AsciiSprite highlightArea2;

	public AsciiSprite highlightArea3;

	public ItemSlot equipFrame;

	public AsciiSprite mutateButtonBg;

	public DialogButton mutateButton;

	public AsciiString mutateCostLabel;

	public PlusMinusButtons plusMinusButtonsPrefab;

	private PlusMinusButtons plusMinusButtons;

	private ItemDetailsDialog improvedItemDetailsDialog;

	private int improvedItemTransitionDuration = 25;

	public RollingMessage rollingMessage;

	public Action<Item> OnPreMutate;

	private MoondialState moondialState;

	private int elapsedMoondialStateTics;

	private Item result;

	private int mutationType;

	private int blinkCostTime;

	private System.Random rng;

	private int rngSeed;

	private static readonly string[] BASIC_ITEMS = new string[5] { "sword", "shield", "crossbow", "wand", "quarterstaff" };

	private static readonly ItemData.Element[] ELEMENTS = new ItemData.Element[5]
	{
		ItemData.Element.Poison,
		ItemData.Element.Vigor,
		ItemData.Element.AEther,
		ItemData.Element.Fire,
		ItemData.Element.Ice
	};

	private List<string> mutationHistory = new List<string>();

	private int mutateCost;

	private ItemDetailsDialog itemDetailsDialog => GameStates.Singleton.itemScreen.itemDetailsDialog;

	public bool craftInterrupted { get; set; }

	public static MoondialScreen singleton { get; private set; }

	public override void Show()
	{
		base.Show();
		ClearEquipFrame();
		SetMoondialState(MoondialState.Idle);
	}

	public override void Hide()
	{
		base.Hide();
		ItemSelectionPopup itemSelectionPopup = ItemSelectionPopup.singleton;
		itemSelectionPopup.OnItemSelected = (Action<Item>)Delegate.Remove(itemSelectionPopup.OnItemSelected, new Action<Item>(HandleItemSelected));
	}

	private void SetMoondialState(MoondialState newState)
	{
		switch (newState)
		{
		case MoondialState.Idle:
			UpdatePlusMinusButtonStates();
			GameStates.Singleton.ShowMouse();
			break;
		case MoondialState.SelectingItem:
		{
			ItemSelectionPopup.singleton.mode = ItemSelectionPopup.Mode.Moondial;
			ItemSelectionPopup.singleton.Show();
			ItemSelectionPopup itemSelectionPopup = ItemSelectionPopup.singleton;
			itemSelectionPopup.OnItemSelected = (Action<Item>)Delegate.Combine(itemSelectionPopup.OnItemSelected, new Action<Item>(HandleItemSelected));
			break;
		}
		case MoondialState.Mutating:
			result = MutateItem(equipFrame.item);
			if (equipFrame.item.isShiny)
			{
				result.isShiny = true;
			}
			result.nameTag = equipFrame.item.nameTag;
			result.signature = equipFrame.item.signature;
			GameStates.Singleton.HideMouse();
			SfxController.singleton.Play("smithy_hammer");
			AchievementController.singleton.ReportItemMutated();
			break;
		}
		moondialState = newState;
		elapsedMoondialStateTics = 0;
	}

	public override void UpdateTic()
	{
		if (moondialState == MoondialState.Idle)
		{
			base.UpdateTic();
		}
		elapsedMoondialStateTics++;
		if (moondialState == MoondialState.Idle)
		{
			equipFrame.UpdateTic();
			if (equipFrame.item != null && mutateButton.enabled)
			{
				mutateButton.UpdateTic();
			}
			plusMinusButtons.UpdateTic();
		}
		else if (moondialState == MoondialState.SelectingItem)
		{
			ItemSelectionPopup.singleton.UpdateTic();
			if (ItemSelectionPopup.singleton.currentState == State.Disabled)
			{
				mutationHistory.Clear();
				if (equipFrame.item != null)
				{
					string groupId = equipFrame.item.GetGroupId();
					mutationHistory.Add(groupId);
				}
				if (equipFrame.item != null && equipFrame.item.GetRarityType() != ItemData.Rarity.Type.Common)
				{
					itemDetailsDialog.item = equipFrame.item;
					itemDetailsDialog.Show();
					SetMoondialState(MoondialState.ItemDetails);
				}
				else
				{
					SetMoondialState(MoondialState.Idle);
				}
			}
		}
		else if (moondialState == MoondialState.ItemDetails)
		{
			itemDetailsDialog.UpdateTic();
			if (itemDetailsDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetMoondialState(MoondialState.Idle);
			}
		}
		else if (moondialState == MoondialState.ImprovedItemDialog1)
		{
			itemDetailsDialog.UpdateTic();
			improvedItemDetailsDialog.UpdateTic();
			if (elapsedMoondialStateTics == 25 || AsciiMouse.singleton.down0)
			{
				SetMoondialState(MoondialState.ImprovedItemDialog2);
			}
			else if (itemDetailsDialog.CurrentState == DialogNineSlice.State.Out)
			{
				SetMoondialState(MoondialState.Idle);
			}
		}
		else if (moondialState == MoondialState.ImprovedItemDialog2)
		{
			itemDetailsDialog.UpdateTic();
			improvedItemDetailsDialog.UpdateTic();
			if (elapsedMoondialStateTics == improvedItemTransitionDuration || AsciiMouse.singleton.down0 || improvedItemDetailsDialog.CurrentState == DialogNineSlice.State.Out)
			{
				SetMoondialState(MoondialState.ImprovedItemDialog3);
			}
			else if (itemDetailsDialog.CurrentState == DialogNineSlice.State.Out)
			{
				SetMoondialState(MoondialState.Idle);
			}
		}
		else if (moondialState == MoondialState.ImprovedItemDialog3)
		{
			itemDetailsDialog.UpdateTic();
			improvedItemDetailsDialog.UpdateTic();
			if (improvedItemDetailsDialog.CurrentState == DialogNineSlice.State.Disabled || itemDetailsDialog.CurrentState == DialogNineSlice.State.Out)
			{
				SetMoondialState(MoondialState.Idle);
			}
		}
		else if (moondialState == MoondialState.Mutating && elapsedMoondialStateTics >= 30)
		{
			int count = equipFrame.count;
			Inventory.Singleton.RemoveItem(equipFrame.item, count);
			result = Inventory.Singleton.AddItem(result, count);
			result.hasInteracted = true;
			AnvilScreen.UnequipAndReequip(equipFrame.item, result);
			UtilityBeltKeyShortcuts.singleton.ReportCraft((Weapon)equipFrame.item, (Weapon)result);
			equipFrame.SetContent(result, count);
			SetMoondialState(MoondialState.Idle);
		}
		if (blinkCostTime > 0)
		{
			blinkCostTime--;
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX + (Width >> 1);
		offsetY += PositionY + (int)transitionOffsetY;
		if (moondialState == MoondialState.Mutating)
		{
			float num = (float)elapsedMoondialStateTics / 30f;
			num = 1f - Mathf.Pow(2f * num - 1f, 2f);
			Color overrideForeground = Color.Lerp(ColorConstants.darkGrey, ColorConstants.white, num);
			highlightMoon.Draw(r, offsetX, offsetY, overrideForeground);
			if (mutationType == 0)
			{
				highlightArea1.Draw(r, offsetX, offsetY, overrideForeground);
			}
			else if (mutationType == 1)
			{
				highlightArea2.Draw(r, offsetX, offsetY, overrideForeground);
			}
			else
			{
				highlightArea3.Draw(r, offsetX, offsetY, overrideForeground);
			}
		}
		equipFrame.Draw(r, offsetX, offsetY);
		if (equipFrame.item != null)
		{
			plusMinusButtons.PositionX = equipFrame.PositionX + 8;
			plusMinusButtons.PositionY = equipFrame.PositionY;
			plusMinusButtons.Draw(r, offsetX, offsetY);
		}
		if (equipFrame.item != null && mutateButton.enabled && moondialState != MoondialState.Mutating)
		{
			int offsetX2 = offsetX + mutateButton.PositionX;
			int offsetY2 = offsetY + mutateButton.PositionY;
			mutateButtonBg.Draw(r, offsetX2, offsetY2);
			if (blinkCostTime > 0 && (blinkCostTime - 1) % 6 <= 2)
			{
				mutateCostLabel.Draw(r, offsetX2, offsetY2, ColorConstants.red);
			}
			else
			{
				mutateCostLabel.Draw(r, offsetX2, offsetY2);
			}
			mutateButton.Draw(r, offsetX, offsetY);
		}
		GameStates.Singleton.money.Draw(r, 0, 0, GameStates.State.ItemScreen);
		rollingMessage.Draw(r, offsetX, offsetY);
		if (moondialState == MoondialState.SelectingItem)
		{
			ItemSelectionPopup.singleton.Draw(r, offsetX, offsetY);
		}
		else if (moondialState == MoondialState.ItemDetails || moondialState == MoondialState.ImprovedItemDialog1)
		{
			itemDetailsDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		else if (moondialState == MoondialState.ImprovedItemDialog2)
		{
			itemDetailsDialog.Draw(r, r.width >> 1, r.height >> 1);
			if (improvedItemDetailsDialog.Height < itemDetailsDialog.Height)
			{
				improvedItemDetailsDialog.PositionY = itemDetailsDialog.PositionY;
				improvedItemDetailsDialog.Height = itemDetailsDialog.Height;
			}
			int num2 = improvedItemDetailsDialog.Height * elapsedMoondialStateTics / improvedItemTransitionDuration;
			num2 += (r.height >> 1) + improvedItemDetailsDialog.PositionY;
			if (improvedItemDetailsDialog.CurrentState == DialogNineSlice.State.Idle)
			{
				int lastDrawX = itemDetailsDialog.lastDrawX;
				int num3 = lastDrawX + improvedItemDetailsDialog.Width - 1;
				for (int i = lastDrawX; i <= num3; i++)
				{
					r.SetCell(i, num2, SpecialSymbols.Map('█'), Color.white);
				}
			}
			r.PushClip(new AsciiRenderProcedural.Clip
			{
				bottom = r.height - num2
			});
			improvedItemDetailsDialog.Draw(r, r.width >> 1, r.height >> 1);
			r.PopClip();
		}
		else if (moondialState == MoondialState.ImprovedItemDialog3)
		{
			itemDetailsDialog.Draw(r, r.width >> 1, r.height >> 1);
			improvedItemDetailsDialog.Draw(r, r.width >> 1, r.height >> 1);
		}
		else
		{
			_ = moondialState;
			_ = 6;
		}
	}

	protected override void Update()
	{
		if (moondialState != MoondialState.SelectingItem && moondialState != MoondialState.ItemDetails && moondialState != MoondialState.Mutating)
		{
			base.Update();
		}
	}

	private void ShowItemDetails(Item item)
	{
		if (item != null)
		{
			itemDetailsDialog.item = item;
			itemDetailsDialog.Show();
			SetMoondialState(MoondialState.ItemDetails);
		}
	}

	private void ClearEquipFrame()
	{
		equipFrame.SetContent(null, 0);
	}

	private Item MutateItem(Item sourceItem)
	{
		string id = sourceItem.id;
		ItemData.Element element = sourceItem.element;
		int num = sourceItem.rngSeed;
		ItemData.Rarity rarity = ((sourceItem.rarity != null) ? sourceItem.rarity.Clone() : null);
		int level = sourceItem.level;
		int num2 = ItemFactory.singleton.ComputeComplexityMultiplier(sourceItem.complexity, element);
		level /= num2;
		if (element == ItemData.Element.Stone)
		{
			mutationType = 0;
			int num3 = rng.Next(BASIC_ITEMS.Length);
			if (id == BASIC_ITEMS[num3])
			{
				num3 = (num3 + 1) % BASIC_ITEMS.Length;
			}
			id = BASIC_ITEMS[num3];
			ItemFactory.singleton.ClearCosmetic(sourceItem);
			Item item = ItemFactory.singleton.MakeItemWithLevel(id, level, rarity);
			item.LoadAbilities();
			return item;
		}
		if (id == "runestone")
		{
			mutationType = 2;
			int num4 = 0;
			for (int i = 0; i < ELEMENTS.Length; i++)
			{
				if (element == ELEMENTS[i])
				{
					num4 = i;
					break;
				}
			}
			num4++;
			num4 %= ELEMENTS.Length;
			element = ELEMENTS[num4];
			return ItemFactory.singleton.MakeItemWithLevelAndAbilities(id, level, element, num, rarity);
		}
		mutationType = 1;
		num++;
		Item item2 = null;
		string text = null;
		for (int j = 0; j < 4; j++)
		{
			if (item2 != null)
			{
				UnityEngine.Object.Destroy(item2.gameObject);
			}
			item2 = ItemFactory.singleton.MakeItemWithLevelAndAbilities(id, level, element, num, rarity);
			text = item2.GetGroupId();
			if (mutationHistory.Count < 2 || mutationHistory[1] != text)
			{
				break;
			}
			num += 2;
		}
		mutationHistory.Insert(0, text);
		if (sourceItem.cosmeticId != null)
		{
			item2.cosmeticId = sourceItem.cosmeticId;
			item2.cosmetic = sourceItem.cosmetic;
			ItemFactory.singleton.UpdateCosmeticReference(item2);
		}
		return item2;
	}

	private int ComputeMutateCost()
	{
		Item item = equipFrame.item;
		if (item == null)
		{
			return 0;
		}
		if (IsRerollOnly(item))
		{
			return 0;
		}
		int count = equipFrame.count;
		int level = equipFrame.item.level;
		if (item.element == ItemData.Element.Stone)
		{
			return 10 * count * level;
		}
		if (item.id == "runestone")
		{
			return 40 * count * level;
		}
		return 275;
	}

	private bool IsRerollOnly(Item item)
	{
		if (item.canMutateOnMoondial && (item.complexity <= 0 || item.element != ItemData.Element.Stone))
		{
			return false;
		}
		return true;
	}

	private void HandleItemSelected(Item item)
	{
		ItemSelectionPopup itemSelectionPopup = ItemSelectionPopup.singleton;
		itemSelectionPopup.OnItemSelected = (Action<Item>)Delegate.Remove(itemSelectionPopup.OnItemSelected, new Action<Item>(HandleItemSelected));
		equipFrame.SetContent(item, 1);
		mutateButton.enabled = item.id != "enchantment";
		UpdateMutateCost();
	}

	private void UpdateMutateCost()
	{
		mutateCost = ComputeMutateCost();
		if (mutateCost <= 0)
		{
			mutateButton.label.SetValue(Te.xt("Re-roll"));
			mutateCostLabel.Clear();
		}
		else
		{
			mutateButton.label.SetValue(Te.xt("Mutate"));
			mutateCostLabel.SetValue("@" + Utils.FormatNumber(mutateCost) + " ");
		}
	}

	private void HandleEquipFramePressed(DialogButton btn)
	{
		if (moondialState == MoondialState.Idle)
		{
			SetMoondialState(MoondialState.SelectingItem);
		}
	}

	private void HandleEquipSecondaryPressed(DialogButton btn)
	{
		if (moondialState == MoondialState.Idle)
		{
			ShowItemDetails(equipFrame.item);
		}
	}

	private void HandleMutatePressed(DialogButton btn)
	{
		if (IsRerollOnly(equipFrame.item))
		{
			itemDetailsDialog.item = equipFrame.item;
			itemDetailsDialog.Show();
			SetMoondialState(MoondialState.ItemDetails);
		}
		else if (mutateCost <= InventoryResources.singleton.GetResourceOfType(Data.Resource.Xi))
		{
			craftInterrupted = false;
			OnPreMutate?.Invoke(equipFrame.item);
			if (craftInterrupted)
			{
				rollingMessage.Show(Te.xt("tid_craft_interrupted"), Color.red);
				return;
			}
			SetMoondialState(MoondialState.Mutating);
			InventoryResources.singleton.RemoveResourceOfType(Data.Resource.Xi, mutateCost);
			plusMinusButtons.Hide();
		}
		else
		{
			blinkCostTime = 15;
		}
	}

	private void UpdatePlusMinusButtonStates()
	{
		if (GetItemCountLimit() > 1)
		{
			plusMinusButtons.Show();
			plusMinusButtons.plusButton.enabled = true;
		}
		else
		{
			plusMinusButtons.Hide();
			equipFrame.count = 1;
		}
	}

	private void HandlePlusPressed(PlusMinusButtons buttons, bool isRepeating)
	{
		if (moondialState != MoondialState.Idle)
		{
			return;
		}
		int itemCountLimit = GetItemCountLimit();
		if (equipFrame.count < itemCountLimit)
		{
			int num = 1;
			if (equipFrame.count >= 50 && isRepeating)
			{
				num = 11;
				num = Mathf.Min(num, itemCountLimit - equipFrame.count);
			}
			equipFrame.count += num;
			if (equipFrame.count == GetItemCountLimit())
			{
				plusMinusButtons.plusButton.enabled = false;
			}
			plusMinusButtons.repeatFrameSkip = ((equipFrame.count < 10) ? 2 : 0);
			UpdateMutateCost();
		}
	}

	private void HandleMinusPressed(PlusMinusButtons buttons, bool isRepeating)
	{
		if (moondialState == MoondialState.Idle)
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
			UpdateMutateCost();
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

	private void HandleImprovedItemDialogClickedOutside()
	{
		itemDetailsDialog.Hide();
		improvedItemDetailsDialog.Hide();
	}

	private void HandleImprovedItemDialogCloseButton(DialogButton button)
	{
		itemDetailsDialog.Hide();
		improvedItemDetailsDialog.Hide();
	}

	private void HandleRerollEnchantmentPressed(DialogButton btn)
	{
		Item item = ((btn == improvedItemDetailsDialog.rerollEnchantmentButton) ? improvedItemDetailsDialog.item : itemDetailsDialog.item);
		int num = item.ComputeRerollCost();
		if (num <= InventoryResources.singleton.GetResourceOfType(Data.Resource.Xi))
		{
			InventoryResources.singleton.RemoveResourceOfType(Data.Resource.Xi, num);
			Item item2 = ItemFactory.singleton.RerollEnchantment(item);
			Inventory.Singleton.RemoveItem(item, 1);
			item2 = Inventory.Singleton.AddItem(item2);
			item2.hasInteracted = true;
			equipFrame.SetContent(item2, 1);
			UnequipAndReequip(item, item2);
			Weapon weapon = (Weapon)item;
			Weapon weapon2 = (Weapon)item2;
			if (weapon != null && weapon2 != null)
			{
				UtilityBeltKeyShortcuts.singleton.ReportCraft(weapon, weapon2);
			}
			itemDetailsDialog.item = item;
			itemDetailsDialog.hasReroll = false;
			improvedItemDetailsDialog.item = item2;
			improvedItemDetailsDialog.Show();
			SetMoondialState(MoondialState.ImprovedItemDialog1);
		}
	}

	public string Serialize()
	{
		SlimJson.BeginSerialization();
		rngSeed = rng.Next();
		SlimJson.AddProperty("seed", rngSeed);
		return SlimJson.EndSerialization();
	}

	public void Parse(string sjson)
	{
		ClearProgress();
		InitItemDetails();
		if (sjson != null && SlimJson.HasKey(sjson, "seed"))
		{
			rngSeed = SlimJson.ParseInt(sjson, "seed");
			rng = new System.Random(rngSeed);
		}
	}

	public void ClearProgress()
	{
		rng = new System.Random();
	}

	public int GetStateNumericRepresentation()
	{
		return (int)moondialState;
	}

	private void InitItemDetails()
	{
		if (!(improvedItemDetailsDialog != null))
		{
			improvedItemDetailsDialog = UnityEngine.Object.Instantiate(GameStates.Singleton.itemScreen.itemDetailsDialogPrefab);
			ModalFade component = improvedItemDetailsDialog.gameObject.GetComponent<ModalFade>();
			if (component != null)
			{
				UnityEngine.Object.Destroy(component);
			}
			improvedItemDetailsDialog.OnClickedOutside += HandleImprovedItemDialogClickedOutside;
			improvedItemDetailsDialog.closeButton.OnPressed += HandleImprovedItemDialogCloseButton;
			itemDetailsDialog.rerollEnchantmentButton.OnPressed += HandleRerollEnchantmentPressed;
			improvedItemDetailsDialog.rerollEnchantmentButton.OnPressed += HandleRerollEnchantmentPressed;
		}
	}

	protected override void Start()
	{
		base.Start();
		equipFrame.OnPressed += HandleEquipFramePressed;
		equipFrame.OnSecondaryPressed += HandleEquipSecondaryPressed;
		mutateButton.OnPressed += HandleMutatePressed;
	}

	protected override void OnDestroy()
	{
		equipFrame.OnPressed -= HandleEquipFramePressed;
		equipFrame.OnSecondaryPressed -= HandleEquipSecondaryPressed;
		mutateButton.OnPressed -= HandleMutatePressed;
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
	}
}
