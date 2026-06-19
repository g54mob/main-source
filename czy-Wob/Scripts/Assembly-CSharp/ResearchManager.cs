using System;
using System.Collections.Generic;
using UnityEngine;

public class ResearchManager : MonoBehaviour
{
	public static string basePath = "Researchables/";

	private List<Researchable> allResearchables = new List<Researchable>();

	private Dictionary<string, int> researchableIDToIndexDict = new Dictionary<string, int>();

	private List<string> completedResearchIDs = new List<string>();

	private List<string> remainingNaturalResearchIDs = new List<string>();

	private float seasonalUnlockChance = 0.25f;

	private DogRegistration dogRegRef;

	private void Awake()
	{
		LoadResearchables();
	}

	private void Start()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
	}

	public Sprite GetThumbnailForDog(ulong dogID)
	{
		return dogRegRef.GetDefaultThumbnailForDogID(dogID);
	}

	public SaveableResearchStatus GetSaveableResearch()
	{
		SaveableResearchStatus saveableResearchStatus = new SaveableResearchStatus();
		for (int i = 0; i < completedResearchIDs.Count; i++)
		{
			saveableResearchStatus.completedResearchIDs.Add(completedResearchIDs[i]);
		}
		return saveableResearchStatus;
	}

	public void LoadSavedResearch(SaveableResearchStatus savedResearch)
	{
		completedResearchIDs.Clear();
		remainingNaturalResearchIDs.Clear();
		if (savedResearch != null)
		{
			for (int i = 0; i < savedResearch.completedResearchIDs.Count; i++)
			{
				completedResearchIDs.Add(savedResearch.completedResearchIDs[i]);
			}
		}
		for (int j = 0; j < allResearchables.Count; j++)
		{
			string iDForResearchable = GetIDForResearchable(allResearchables[j]);
			if (allResearchables[j].roomCustomizationObjectUnlock != null && allResearchables[j].roomCustomizationObjectUnlock.canBeUnlocked && (CheatEngine.fishPackEnabled || allResearchables[j].associatedSetType != ItemSet.FISH) && (CheatEngine.groceryPackEnabled || allResearchables[j].associatedSetType != ItemSet.GROCERY) && (CheatEngine.desertPackEnabled || allResearchables[j].associatedSetType != ItemSet.DESERT) && (CheatEngine.basementPackEnabled || allResearchables[j].associatedSetType != ItemSet.BASEMENT))
			{
				remainingNaturalResearchIDs.Add(iDForResearchable);
			}
			if (allResearchables[j].startUnlocked && !completedResearchIDs.Contains(iDForResearchable))
			{
				completedResearchIDs.Add(iDForResearchable);
			}
		}
		for (int k = 0; k < completedResearchIDs.Count; k++)
		{
			if (remainingNaturalResearchIDs.Contains(completedResearchIDs[k]))
			{
				remainingNaturalResearchIDs.Remove(completedResearchIDs[k]);
			}
		}
	}

	public void DebugUnlockAllResearch()
	{
		completedResearchIDs.Clear();
		remainingNaturalResearchIDs.Clear();
		for (int i = 0; i < allResearchables.Count; i++)
		{
			if (allResearchables[i].canBeUnlockedThroughCheats && (CheatEngine.fishPackEnabled || allResearchables[i].associatedSetType != ItemSet.FISH) && (CheatEngine.groceryPackEnabled || allResearchables[i].associatedSetType != ItemSet.GROCERY) && (CheatEngine.desertPackEnabled || allResearchables[i].associatedSetType != ItemSet.DESERT) && (CheatEngine.basementPackEnabled || allResearchables[i].associatedSetType != ItemSet.BASEMENT))
			{
				completedResearchIDs.Add(GetIDForResearchable(allResearchables[i]));
			}
		}
	}

	public bool DoesUnlockedResearchExist()
	{
		return remainingNaturalResearchIDs.Count > 0;
	}

	public Researchable UnlockRandomResearch()
	{
		if (remainingNaturalResearchIDs.Count == 0)
		{
			return null;
		}
		int month = DateTime.Now.Month;
		if ((month == 10 || month == 12) && UnityEngine.Random.value <= seasonalUnlockChance)
		{
			List<string> list = new List<string>();
			for (int i = 0; i < remainingNaturalResearchIDs.Count; i++)
			{
				if (month == 10 && GetResearchableForID(remainingNaturalResearchIDs[i]).associatedSetType == ItemSet.SPOOKY)
				{
					list.Add(remainingNaturalResearchIDs[i]);
				}
				else if (month == 12 && GetResearchableForID(remainingNaturalResearchIDs[i]).associatedSetType == ItemSet.WINTER)
				{
					list.Add(remainingNaturalResearchIDs[i]);
				}
			}
			if (list.Count > 0)
			{
				Researchable researchableForID = GetResearchableForID(ListUtil.GetRandomElement(list));
				if (researchableForID == null)
				{
					Debug.LogError("Failed to unlock any research.");
					return null;
				}
				UnlockSpecificResearch(researchableForID);
				return researchableForID;
			}
		}
		Researchable researchableForID2 = GetResearchableForID(ListUtil.GetRandomElement(remainingNaturalResearchIDs));
		if (researchableForID2 == null)
		{
			Debug.LogError("Failed to unlock any research.");
			return null;
		}
		UnlockSpecificResearch(researchableForID2);
		return researchableForID2;
	}

	public void UnlockSpecificResearch(Researchable newResearch)
	{
		string iDForResearchable = GetIDForResearchable(newResearch);
		if (remainingNaturalResearchIDs.Contains(iDForResearchable))
		{
			remainingNaturalResearchIDs.Remove(iDForResearchable);
		}
		if (!completedResearchIDs.Contains(iDForResearchable))
		{
			completedResearchIDs.Add(iDForResearchable);
		}
	}

	public List<RoomCustomizationObject> GetUnlockedRoomCustomizationObjectsOfType(CustomizationType typeRef)
	{
		List<RoomCustomizationObject> list = new List<RoomCustomizationObject>();
		for (int i = 0; i < completedResearchIDs.Count; i++)
		{
			Researchable researchableForID = GetResearchableForID(completedResearchIDs[i]);
			if (researchableForID.roomCustomizationObjectUnlock != null && researchableForID.roomCustomizationObjectUnlock.objectType == typeRef)
			{
				list.Add(researchableForID.roomCustomizationObjectUnlock);
			}
		}
		return list;
	}

	private void LoadResearchables()
	{
		UnityEngine.Object[] array = Resources.LoadAll(basePath);
		for (int i = 0; i < array.Length; i++)
		{
			Researchable researchable = (Researchable)array[i];
			string iDForResearchable = GetIDForResearchable(researchable);
			if (iDForResearchable != null)
			{
				allResearchables.Add(researchable);
				researchableIDToIndexDict[iDForResearchable] = allResearchables.Count - 1;
				IndexRequirements(researchable);
			}
		}
	}

	public Researchable GetResearchableForID(string ID)
	{
		return allResearchables[researchableIDToIndexDict[ID]];
	}

	public string GetIDForResearchable(Researchable item)
	{
		if (item == null)
		{
			Debug.LogError("No valid researchable passed in to GetIDForResearchable");
			return null;
		}
		if (item.inventoryItemUnlock != null)
		{
			Debug.LogError("No valid researchable passed in to GetIDForResearchable");
			return null;
		}
		if (item.roomCustomizationObjectUnlock != null)
		{
			return item.roomCustomizationObjectUnlock.name;
		}
		Debug.LogError("No valid researchable passed in to GetIDForResearchable");
		return null;
	}

	private void IndexRequirements(Researchable researchableRef)
	{
		if (researchableRef.startUnlocked)
		{
			string iDForResearchable = GetIDForResearchable(researchableRef);
			completedResearchIDs.Add(iDForResearchable);
			if (remainingNaturalResearchIDs.Contains(iDForResearchable))
			{
				remainingNaturalResearchIDs.Remove(iDForResearchable);
			}
		}
	}
}
