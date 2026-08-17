using System;
using System.Collections.Generic;
using Assets.Scripts._Data;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.UI.InGame.Rewards;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MyButton
{
	public RawImage icon;

	public TextMeshProUGUI t_name;

	public TextMeshProUGUI t_description;

	public TextMeshProUGUI t_level;

	public TextMeshProUGUI t_rarity;

	public RawImage iconBorder;

	public RawImage iconBackground;

	public Image background;

	public Image backgroundOverlay;

	public GameObject banishOverlay;

	private IUpgradable upgradable;

	private List<StatModifier> upgradeOffer;

	public UpgradePicker upgradePicker;

	public TomeSynergiesUi tomeSynergiesUi;

	private bool isItem;

	private ItemData itemData;

	private ERarity rarity;

	private int price;

	private bool canAfford;

	public GameObject overlayCantAfford;

	public unsafe void SetUpgrade(IUpgradable upgradable)
	{
		//IL_00a0: Expected O, but got Ref
		//IL_00b4: Expected O, but got Ref
		//IL_00c8: Expected O, but got Ref
		//IL_00eb: Expected O, but got Ref
		//IL_00fe: Expected O, but got Ref
		isItem = false;
		StopHover();
		upgradeOffer = null;
		this.upgradable = upgradable;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
		rarity = ERarity.New;
		object obj = default(object);
		if ((nint)obj <= 0)
		{
			ERarity eRarity = ERarity.Common;
		}
		else
		{
			float stat = PlayerStats.GetStat(EStat.Luck);
			ERarity eRarity = (rarity = Rarity.GetUpgradeOfferRarity(stat));
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
		List<StatModifier> list = default(List<StatModifier>);
		upgradeOffer = list;
		Color color = MyColorUtility.RarityToColor(rarity);
		float num = default(float);
		t_rarity.color = (Color)(&num);
		iconBorder.color = (Color)(&num);
		iconBackground.color = (Color)(&num);
		Color rarityColorBackground = MyColorUtility.GetRarityColorBackground(rarity);
		background.color = (Color)(&num);
		TextMeshProUGUI textMeshProUGUI = t_rarity;
		object obj2 = default(object);
		string text = ((Enum)(&obj2)).ToString();
		t_rarity.text = text;
		TextMeshProUGUI textMeshProUGUI2 = t_name;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
		string text2 = default(string);
		t_name.text = text2;
		TextMeshProUGUI textMeshProUGUI3 = t_description;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
		int level = default(int);
		string upgradeDescription = upgradable.GetUpgradeDescription(level, upgradeOffer, rarity);
		t_description.text = upgradeDescription;
		TextMeshProUGUI textMeshProUGUI4 = t_level;
		string text3;
		if ((nint)obj <= 0)
		{
			text3 = "NEW";
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			text3 = $"LVL {arg}";
		}
		t_level.text = text3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
		UnityEngine.Object obj3 = default(UnityEngine.Object);
		if (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
			Texture texture = default(Texture);
			icon.texture = texture;
		}
		Button component = GetComponent<Button>();
		component.interactable = false;
		Invoke("EnableButton", 0.5f);
	}

	public unsafe void SetItem(ItemData itemData)
	{
		//IL_0027: Expected O, but got Ref
		//IL_003b: Expected O, but got Ref
		//IL_004f: Expected O, but got Ref
		//IL_007a: Expected O, but got Ref
		//IL_0083: Expected O, but got Ref
		price = 0;
		canAfford = true;
		this.itemData = itemData;
		isItem = true;
		StopHover();
		Color color = itemData.GetColor();
		float num = default(float);
		t_rarity.color = (Color)(&num);
		iconBorder.color = (Color)(&num);
		iconBackground.color = (Color)(&num);
		Color rarityColorBackground = MyColorUtility.GetRarityColorBackground(itemData.rarity);
		background.color = (Color)(&num);
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		t_rarity.text = text;
		TextMeshProUGUI textMeshProUGUI = t_name;
		string text2 = itemData.GetName();
		textMeshProUGUI.text = text2;
		string shortDescription = itemData.GetShortDescription();
		t_description.text = shortDescription;
		t_level.text = "";
		Texture texture = itemData.GetIcon();
		icon.texture = texture;
		Button component = GetComponent<Button>();
		component.interactable = false;
		Invoke("EnableButton", 0.5f);
	}

	public void SetItemPriced(ItemData itemData, int price)
	{
		//IL_0024: Invalid comparison between F4 and I4
		canAfford = true;
		SetItem(itemData);
		this.price = price;
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		bool flag = inventory._003Cgold_003Ek__BackingField < (float)price;
		bool active = (byte)(((canAfford = !flag) ? 1u : 0u) ^ 1u) != 0;
		overlayCantAfford.SetActive(active);
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string text = $"<color=white><sprite name=gold> {arg:N0}";
		t_level.text = text;
	}

	private void EnableButton()
	{
		Button component = GetComponent<Button>();
		component.interactable = true;
	}

	public unsafe void SelectUpgrade()
	{
		//IL_020e: Expected F4, but got I4
		//IL_020e: Expected O, but got Ref
		//IL_020e: Expected O, but got Ref
		float time = Time.time;
		UpgradePicker upgradePicker = this.upgradePicker;
		if (upgradePicker.banishCooldownOverAtTime > time)
		{
			return;
		}
		ERarity eRarity = default(ERarity);
		if (isItem)
		{
			if (canAfford)
			{
				ItemData itemData = this.itemData;
				if (!upgradePicker._003CbanishMode_003Ek__BackingField)
				{
					MyPlayer instance = MyPlayer.Instance;
					PlayerInventory inventory = instance.inventory;
					inventory.itemInventory.AddItem(itemData.eItem);
					if (upgradePicker.encounterType == EEncounter.ShadyGuy)
					{
						Action a_ShadyGuyDone = UpgradePicker.A_ShadyGuyDone;
						if (UpgradePicker.A_ShadyGuyDone != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v505.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
						}
					}
					LevelupScreen levelupScreen = upgradePicker.levelupScreen;
					UiManager instance2 = UiManager.Instance;
					instance2.encounterWindows.RewardFinished();
					levelupScreen.upgradePicker.StopBanishMode();
				}
				else
				{
					RunUnlockables.BanishItem(this.itemData);
					upgradePicker.levelupScreen.Banish();
					EffectManager.Instance.BanishItem(this.itemData);
				}
				if (price > 0)
				{
					MyPlayer instance3 = MyPlayer.Instance;
					int amount = -price;
					instance3.inventory.ChangeGold(amount);
				}
			}
			else
			{
				AlwaysUi instance4 = AlwaysUi.Instance;
				string localizedString = LocalizationUtility.GetLocalizedString("PopupText", "CANT_AFFORD");
				Transform transform = base.transform;
				Vector3 position = transform.position;
				object obj = default(object);
				object obj2 = default(object);
				instance4.UiTextPopup.SetText(localizedString, (Vector3)(&obj), (Color)(&obj2), (float)eRarity);
			}
		}
		else
		{
			upgradePicker.SelectUpgrade(upgradable, upgradeOffer, this, eRarity);
		}
	}

	public override void StartHover()
	{
		UpgradePicker upgradePicker = this.upgradePicker;
		banishOverlay.SetActive(upgradePicker._003CbanishMode_003Ek__BackingField);
		isHovering = true;
		backgroundOverlay.enabled = true;
	}

	public override void StopHover()
	{
		isHovering = false;
		backgroundOverlay.enabled = false;
		banishOverlay.SetActive(value: false);
	}

	protected override void OnClick()
	{
	}

	public UpgradeButton()
	{
		hoverScale = 1.05f;
		((MonoBehaviour)this)._002Ector();
	}
}
