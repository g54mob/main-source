using System.Collections.Generic;
using DV.JObjectExtstensions;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Data upgrade/GadgetItemPrefabRenames (v15 -> v16)")]
public class Upgrade_V15_to_V16_GadgetItemPrefabRenames : ASaveSnapshotUpgrader
{
	public override int InputVersion => 15;

	public override JObject Upgrade(UserManager manager, string fileName, List<(int Type, byte[] Data)> customChunks, IStorageProvider storage, GameSession session, JObject data)
	{
		Dictionary<string, string> renamedItems = new Dictionary<string, string>
		{
			{ "gadget_ditch_light_item", "Headlight" },
			{ "gadget_light_controller_item", "SwitchAnalog" },
			{ "gadget_switch_button_item", "SwitchButton" },
			{ "gadget_switch_lever_item", "SwitchLever" },
			{ "gadget_light_switch_item", "SwitchRotary" },
			{ "gadget_switch_slider_item", "SwitchSlider" }
		};
		RenameItemsInStoratge("Storage_World");
		RenameItemsInStoratge("Storage_Inventory");
		RenameItemsInStoratge("Storage_LostAndFound");
		RenameItemsInStoratge("Storage_InstalledGadgets");
		return data;
		void RenameItemsInStoratge(string storageKey)
		{
			List<StorageItemData> objectViaJSON = data.GetObjectViaJSON<List<StorageItemData>>(storageKey);
			if (objectViaJSON != null)
			{
				foreach (StorageItemData item in objectViaJSON)
				{
					if (item != null && renamedItems.TryGetValue(item.itemPrefabName, out var value))
					{
						item.itemPrefabName = value;
					}
				}
				data.SetObjectViaJSON(storageKey, objectViaJSON);
			}
		}
	}
}
