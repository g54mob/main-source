using System;
using UnityEngine;

public class LimitedTimeBundleFactory
{
	public static bool IsLimitedTimeBundleEntryData(string sjson)
	{
		return SlimJson.HasKey(sjson, "limitedDays");
	}

	public static ShopData.LimitedTimeBundle InstantiateEntryData(string sjson)
	{
		switch (SlimJson.Parse(sjson, "id"))
		{
		case "iap_poisons_edge":
			return new PoisonsEdgeBundleEntryData();
		case "iap_oblivion":
			return new OblivionMaulBundleEntryData();
		case "iap_ashen":
			return new AshenAvengerBundleEntryData();
		case "iap_coldsnap":
			return new ColdsnapArbalestBundleEntryData();
		case "iap_adaptive":
			return new AdaptiveStingerBundleEntryData();
		case "iap_ghost_slayer":
			return new GhostSlayerBundleEntryData();
		case "iap_ghost_slayer_20off":
		case "iap_ghost_slayer_30off":
			return new GhostSlayerBundleEntryDataDiscount();
		case "iap_titanic_bundle":
			return new TitanicBundleEntryData();
		default:
			return new ShopData.LimitedTimeBundle();
		}
	}

	private static string GetSlotPrefabName(string entryId)
	{
		string result = null;
		switch (entryId)
		{
		case "iap_poisons_edge":
			return "PoisonsEdgeBundleSlot";
		case "iap_oblivion":
			return "OblivionBundleSlot";
		case "iap_ashen":
			return "AshenBundleSlot";
		case "iap_coldsnap":
			return "ColdsnapBundleSlot";
		case "iap_adaptive":
			return "AdaptiveBundleSlot";
		case "iap_ghost_slayer":
			if (IsSmallSlot())
			{
				return "GhostSlayerBundleSlotSmall";
			}
			return "GhostSlayerBundleSlot";
		case "iap_titanic_bundle":
			if (IsSmallSlot())
			{
				return "TitanicBundleSlotSmall";
			}
			return "TitanicBundleSlot";
		default:
			return result;
		}
	}

	private static string GetConfirmationDialogPrefabName(string entryId)
	{
		return entryId switch
		{
			"iap_poisons_edge" => "PoisonsEdgeBundleConfirmationDialog", 
			"iap_oblivion" => "OblivionBundleConfirmationDialog", 
			"iap_ashen" => "AshenBundleConfirmationDialog", 
			"iap_coldsnap" => "ColdsnapBundleConfirmationDialog", 
			"iap_adaptive" => "AdaptiveBundleConfirmationDialog", 
			"iap_ghost_slayer" => "GhostSlayerBundleConfirmationDialog", 
			"iap_titanic_bundle" => "TitanicBundleConfirmationDialog", 
			_ => null, 
		};
	}

	public static void Preload(string entryId)
	{
		string slotPrefabName = GetSlotPrefabName(entryId);
		if (slotPrefabName != null)
		{
			Utils.PreloadAsyncPrefab(slotPrefabName);
		}
		slotPrefabName = GetConfirmationDialogPrefabName(entryId);
		if (slotPrefabName != null)
		{
			Utils.PreloadAsyncPrefab(slotPrefabName);
		}
	}

	public static void InstantiateSlot(string entryId, Transform parentTransform, Action<LimitedTimeBundleSlot, bool> callback)
	{
		string slotPrefabName = GetSlotPrefabName(entryId);
		if (slotPrefabName != null)
		{
			Utils.PreloadAsyncPrefab(slotPrefabName, delegate(GameObject go)
			{
				go = UnityEngine.Object.Instantiate(go, parentTransform);
				LimitedTimeBundleSlot component = go.GetComponent<LimitedTimeBundleSlot>();
				callback(component, IsSmallSlot());
			});
		}
		else
		{
			Debug.LogError("Failed to instantiate slot for Limited Time Bundle: " + entryId);
		}
	}

	private static bool IsSmallSlot()
	{
		return GameStates.Singleton.asciiRenderer.width < 81;
	}

	public static void InstantiateConfirmationDialog(string entryId, Transform parentTransform, Action<LimitedTimeBundleConfirmationDialog> callback)
	{
		string confirmationDialogPrefabName = GetConfirmationDialogPrefabName(entryId);
		if (confirmationDialogPrefabName != null)
		{
			Utils.PreloadAsyncPrefab(confirmationDialogPrefabName, delegate(GameObject go)
			{
				go = UnityEngine.Object.Instantiate(go, parentTransform);
				LimitedTimeBundleConfirmationDialog component = go.GetComponent<LimitedTimeBundleConfirmationDialog>();
				callback(component);
			});
		}
		else
		{
			Debug.LogError("Failed to instantiate confirmation dialog for Limited Time Bundle: " + entryId);
		}
	}
}
