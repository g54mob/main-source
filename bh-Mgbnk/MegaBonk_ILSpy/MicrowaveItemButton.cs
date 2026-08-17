using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.UI.Localization;
using UnityEngine;
using UnityEngine.UI;

public class MicrowaveItemButton : MyButton
{
	public RawImage icon;

	private MicrowaveUi microwaveUi;

	private ItemData itemData;

	public void Set(MicrowaveUi microwaveUi, EItem eItem)
	{
		this.microwaveUi = microwaveUi;
		ItemData item = DataManager.Instance.GetItem(eItem);
		this.itemData = item;
		ItemData itemData = this.itemData;
		icon.texture = itemData.icon;
	}

	public unsafe void SelectUpgrade()
	{
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected I4, but got Unknown
		//IL_016d: Expected O, but got Ref
		//IL_016d: Expected O, but got Ref
		ItemData itemData = this.itemData;
		if (itemData.maxAmount > 0)
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			ItemData itemData2 = this.itemData;
			int amount = inventory.itemInventory.GetAmount(itemData2.eItem);
			ItemData itemData3 = this.itemData;
			if (amount >= itemData3.maxAmount)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				int num = this.itemData + 112;
				string value = ((int*)num)->ToString();
				((Dictionary<object, object>)(object)dictionary).Add((object)"maxAmount", (object)value);
				object value2 = this.itemData.GetName();
				((Dictionary<object, object>)(object)dictionary).Add((object)"itemName", value2);
				string localizedString = LocalizationUtility.GetLocalizedString("PopupText", "MICROWAVE_MAX_ITEMS", dictionary);
				AlwaysUi instance2 = AlwaysUi.Instance;
				Transform transform = base.transform;
				Vector3 position = transform.position;
				object obj = default(object);
				object obj2 = default(object);
				float desiredScale = default(float);
				instance2.UiTextPopup.SetText(localizedString, (Vector3)(&obj), (Color)(&obj2), desiredScale);
				return;
			}
		}
		ItemData itemData4 = this.itemData;
		InteractableMicrowave.currentlyInteracting.UseMicrowave(itemData4.eItem);
		UiManager instance3 = UiManager.Instance;
		instance3.encounterWindows.RewardFinished();
	}

	public override void StartHover()
	{
		isHovering = true;
	}

	public override void StopHover()
	{
		isHovering = false;
	}

	protected override void OnClick()
	{
	}

	public MicrowaveItemButton()
	{
		hoverScale = 1.05f;
		((MonoBehaviour)this)._002Ector();
	}
}
