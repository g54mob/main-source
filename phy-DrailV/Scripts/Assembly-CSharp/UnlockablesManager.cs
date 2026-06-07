using System.Collections.Generic;
using System.Linq;
using DV.Common;
using DV.ThingTypes;
using DV.UserManagement;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class UnlockablesManager : SingletonBehaviour<UnlockablesManager>
{
	private const bool UNLOCK_ONLY_IN_CAREER = true;

	private IUserProfile initializedUser;

	private JObject json;

	private HashSet<string> unlockedGeneralLicenses = new HashSet<string>();

	private HashSet<string> unlockedJobLicenses = new HashSet<string>();

	private HashSet<string> unlockedGarages = new HashSet<string>();

	private HashSet<string> unlockedItems = new HashSet<string>();

	private static readonly HashSet<string> EmptySet = new HashSet<string>();

	public IReadOnlyCollection<string> UnlockedGeneralLicenses
	{
		get
		{
			if (!CheckUser())
			{
				return EmptySet;
			}
			return unlockedGeneralLicenses;
		}
	}

	public IReadOnlyCollection<string> UnlockedJobLicenses
	{
		get
		{
			if (!CheckUser())
			{
				return EmptySet;
			}
			return unlockedJobLicenses;
		}
	}

	public IReadOnlyCollection<string> UnlockedGarages
	{
		get
		{
			if (!CheckUser())
			{
				return EmptySet;
			}
			return unlockedGarages;
		}
	}

	public IReadOnlyCollection<string> UnlockedItems
	{
		get
		{
			if (!CheckUser())
			{
				return EmptySet;
			}
			return unlockedItems;
		}
	}

	public new static string AllowAutoCreate()
	{
		return "[UnlockablesManager]";
	}

	protected override void Initialize()
	{
		if (SingletonBehaviour<UserManager>.Instance != null)
		{
			InitializeUser(SingletonBehaviour<UserManager>.Instance.CurrentUser);
		}
	}

	private void InitializeUser(IUserProfile user)
	{
		unlockedGeneralLicenses.Clear();
		unlockedJobLicenses.Clear();
		unlockedGarages.Clear();
		unlockedItems.Clear();
		json = user.ReadProgressionState();
		unlockedGeneralLicenses.UnionWith((json["Unlocked_general_licenses"] as JArray).Select((JToken t) => t.Value<string>()));
		unlockedJobLicenses.UnionWith((json["Unlocked_job_licenses"] as JArray).Select((JToken t) => t.Value<string>()));
		unlockedGarages.UnionWith((json["Unlocked_garages"] as JArray).Select((JToken t) => t.Value<string>()));
		unlockedItems.UnionWith((json["Unlocked_items"] as JArray).Select((JToken t) => t.Value<string>()));
		initializedUser = user;
	}

	public void ReadFromSaveGame(SaveGameData saveData)
	{
		if (CheckUser())
		{
			saveData.GetStringArray("Unlocked_items")?.ToList().ForEach(delegate(string l)
			{
				UnlockItem(l, updateCurrentSave: false);
			});
		}
		else
		{
			Debug.LogError("User is currently not initialized, but we're importing unlockables from save game, something is very wrong");
		}
	}

	private bool CheckUser()
	{
		if ((bool)SingletonBehaviour<UserManager>.Instance)
		{
			if (SingletonBehaviour<UserManager>.Instance.CurrentUser != initializedUser)
			{
				InitializeUser(SingletonBehaviour<UserManager>.Instance.CurrentUser);
			}
			return true;
		}
		return false;
	}

	public bool IsGeneralLicenseUnlocked(string licenseId)
	{
		if (!CheckUser())
		{
			return false;
		}
		return unlockedGeneralLicenses.Contains(licenseId);
	}

	public bool IsJobLicenseUnlocked(string licenseId)
	{
		if (!CheckUser())
		{
			return false;
		}
		return unlockedJobLicenses.Contains(licenseId);
	}

	public bool IsGarageUnlocked(string garageId)
	{
		if (!CheckUser())
		{
			return false;
		}
		return unlockedGarages.Contains(garageId);
	}

	public bool IsThingUnlocked(Thing_v2 thing)
	{
		if (thing is GeneralLicenseType_v2)
		{
			return IsGeneralLicenseUnlocked(thing.id);
		}
		if (thing is JobLicenseType_v2)
		{
			return IsJobLicenseUnlocked(thing.id);
		}
		if (thing is GarageType_v2)
		{
			return IsGarageUnlocked(thing.id);
		}
		Debug.LogWarning("Checking an untracked thing type (" + thing.GetType().Name + "), assuming unlocked");
		return true;
	}

	public bool IsItemUnlocked(string itemId)
	{
		if (!CheckUser())
		{
			return false;
		}
		return unlockedItems.Contains(itemId);
	}

	private bool UnlockInArray(HashSet<string> cache, string progressionKey, string saveGameKey, string id)
	{
		if (!CheckUser())
		{
			return false;
		}
		if (initializedUser.CurrentSession.GameMode != "Career")
		{
			return false;
		}
		if (!string.IsNullOrEmpty(saveGameKey))
		{
			SingletonBehaviour<SaveGameManager>.Instance.data.AddToStringArray(saveGameKey, id, enforceUnique: true);
		}
		if (!string.IsNullOrEmpty(progressionKey) && cache.Add(id))
		{
			(json[progressionKey] as JArray).Add(id);
			initializedUser.SaveProgressionState(json);
			return true;
		}
		return false;
	}

	public bool UnlockGeneralLicense(string licenseId)
	{
		return UnlockInArray(unlockedGeneralLicenses, "Unlocked_general_licenses", "", licenseId);
	}

	public bool UnlockJobLicense(string licenseId)
	{
		return UnlockInArray(unlockedJobLicenses, "Unlocked_job_licenses", "", licenseId);
	}

	public bool UnlockGarage(string garageId)
	{
		return UnlockInArray(unlockedGarages, "Unlocked_garages", "", garageId);
	}

	public bool UnlockItem(string itemId, bool updateCurrentSave = true)
	{
		return UnlockInArray(unlockedItems, "Unlocked_items", updateCurrentSave ? "Unlocked_items" : "", itemId);
	}

	public bool UnlockThing(Thing_v2 thing)
	{
		if (thing is GeneralLicenseType_v2)
		{
			return UnlockGeneralLicense(thing.id);
		}
		if (thing is JobLicenseType_v2)
		{
			return UnlockJobLicense(thing.id);
		}
		if (thing is GarageType_v2)
		{
			return UnlockGarage(thing.id);
		}
		Debug.LogWarning("Unlocking an untracked thing type (" + thing.GetType().Name + "), doing nothing");
		return false;
	}
}
