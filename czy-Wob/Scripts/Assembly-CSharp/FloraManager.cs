using System.Collections.Generic;
using UnityEngine;

public class FloraManager : MonoBehaviour
{
	public GameObject newGutFloraIndicator;

	public Sprite commonSymbol;

	public Sprite uncommonSymbol;

	public Sprite rareSymbol;

	public Sprite ultraRareSymbol;

	private List<string> floraUnlockStatusKeys = new List<string>();

	private Dictionary<string, FloraUnlockInfo> floraUnlockStatus = new Dictionary<string, FloraUnlockInfo>();

	private bool initialized;

	private InventoryManager inventoryRef;

	private DogGutsManager dogGutsManagerRef;

	private void Start()
	{
		Initialize();
	}

	private void Initialize(bool force = false)
	{
		if (!initialized || force)
		{
			initialized = true;
			inventoryRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
			dogGutsManagerRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogGutsManager>(GlobalObject.DOG_GUT_MANAGER);
			InitializeUnlocks();
		}
	}

	public List<SaveableFloraUnlock> GetSaveableFloraUnlocks()
	{
		List<SaveableFloraUnlock> list = new List<SaveableFloraUnlock>();
		for (int i = 0; i < dogGutsManagerRef.allFlora.Count; i++)
		{
			string pathForFlora = dogGutsManagerRef.GetPathForFlora(dogGutsManagerRef.allFlora[i]);
			SaveableFloraUnlock item = new SaveableFloraUnlock(floraUnlockStatus[pathForFlora], pathForFlora);
			list.Add(item);
		}
		return list;
	}

	public void LoadSavedFloraUnlocks(List<SaveableFloraUnlock> savedUnlocks)
	{
		Initialize(force: true);
		if (savedUnlocks == null)
		{
			return;
		}
		for (int i = 0; i < savedUnlocks.Count; i++)
		{
			if (floraUnlockStatus.ContainsKey(savedUnlocks[i].key))
			{
				floraUnlockStatus[savedUnlocks[i].key].floraDiscovered = savedUnlocks[i].floraDiscovered;
				floraUnlockStatus[savedUnlocks[i].key].floraDiscoveryRecognized = savedUnlocks[i].floraDiscoveryRecognized;
				floraUnlockStatus[savedUnlocks[i].key].foodListDiscoveries.Clear();
				floraUnlockStatus[savedUnlocks[i].key].floraEffectDiscoveries.Clear();
				floraUnlockStatus[savedUnlocks[i].key].recognizedFoodListDiscoveries.Clear();
				floraUnlockStatus[savedUnlocks[i].key].recognizedFloraEffectDiscoveries.Clear();
				floraUnlockStatus[savedUnlocks[i].key].foodListDiscoveries.AddRange(savedUnlocks[i].foodListDiscoveries);
				floraUnlockStatus[savedUnlocks[i].key].floraEffectDiscoveries.AddRange(savedUnlocks[i].floraEffectDiscoveries);
				floraUnlockStatus[savedUnlocks[i].key].recognizedFoodListDiscoveries.AddRange(savedUnlocks[i].recognizedFoodListDiscoveries);
				floraUnlockStatus[savedUnlocks[i].key].recognizedFloraEffectDiscoveries.AddRange(savedUnlocks[i].recognizedFloraEffectDiscoveries);
			}
		}
	}

	public Rarity GetRarityForFloraPathAndEffect(string floraPath, GutFloraMutationEffect effect)
	{
		GutFloraBase component = dogGutsManagerRef.GetFloraForPath(floraPath).gutFloraPrefab.GetComponent<GutFloraBase>();
		for (int i = 0; i < component.mutationEffects.Count; i++)
		{
			if (component.mutationEffects[i].effect == effect)
			{
				return component.mutationEffects[i].rarity;
			}
		}
		Debug.LogError("No rarity found for path: " + floraPath + " and effect: " + effect);
		return Rarity.COMMON;
	}

	public Sprite GetSymbolForRarity(Rarity r)
	{
		switch (r)
		{
		case Rarity.COMMON:
			return commonSymbol;
		case Rarity.UNCOMMON:
			return uncommonSymbol;
		case Rarity.RARE:
			return rareSymbol;
		case Rarity.ULTRA_RARE:
			return ultraRareSymbol;
		default:
			Debug.LogError("Invalid Rarity: " + r);
			return commonSymbol;
		}
	}

	public bool DoesNewDiscoveryExist()
	{
		return false;
	}

	public bool IsFloraUnlocked(string floraPath)
	{
		return floraUnlockStatus[floraPath].floraDiscovered;
	}

	public bool DoesAnyFloraHaveUnrecognizedInfo()
	{
		for (int i = 0; i < floraUnlockStatusKeys.Count; i++)
		{
			if (DoesFloraHaveUnrecognizedInfo(floraUnlockStatusKeys[i]))
			{
				return true;
			}
		}
		return false;
	}

	public bool DoesFloraHaveUnrecognizedInfo(string floraPath)
	{
		if (!IsFloraUnlocked(floraPath))
		{
			return false;
		}
		if (!floraUnlockStatus[floraPath].floraDiscoveryRecognized)
		{
			return true;
		}
		for (int i = 0; i < floraUnlockStatus[floraPath].foodListDiscoveries.Count; i++)
		{
			if (!floraUnlockStatus[floraPath].recognizedFoodListDiscoveries.Contains(floraUnlockStatus[floraPath].foodListDiscoveries[i]))
			{
				return true;
			}
		}
		for (int j = 0; j < floraUnlockStatus[floraPath].floraEffectDiscoveries.Count; j++)
		{
			if (!floraUnlockStatus[floraPath].recognizedFloraEffectDiscoveries.Contains(floraUnlockStatus[floraPath].floraEffectDiscoveries[j]))
			{
				return true;
			}
		}
		return false;
	}

	public FloraUnlockInfo GetUnlockInfoForFloraPath(string floraPath)
	{
		return floraUnlockStatus[floraPath];
	}

	public void ReportFloraUnlock(string floraPath, bool unlockStatus, GameObject dogRef = null, bool boosted = false)
	{
		if (!floraUnlockStatus.ContainsKey(floraPath))
		{
			return;
		}
		bool floraDiscovered = floraUnlockStatus[floraPath].floraDiscovered;
		floraUnlockStatus[floraPath].floraDiscovered = unlockStatus;
		if (dogRef != null)
		{
			FaceController component = dogRef.GetComponent<FaceController>();
			WorldMessage component2 = Object.Instantiate(position: (!component.OldHead()) ? (component.mainDogHead.emoteJoint.transform.position + new Vector3(0f, 0.25f, 0f)) : (component.oldDogHead.faceObject.transform.position + new Vector3(0f, 0.25f, 0f)), original: newGutFloraIndicator, rotation: Quaternion.identity).GetComponent<WorldMessage>();
			component2.transform.localScale = Vector3.one;
			component2.SetFadeTime(1.5f);
			GutFloraResource floraForPath = dogGutsManagerRef.GetFloraForPath(floraPath);
			component2.SetDisplayIcon(floraForPath.gutFloraPreviewSprite);
			if (boosted)
			{
				component2.iconRef.color = floraForPath.gutFloraPrefab.GetComponent<GutFloraBase>().boostedColor;
			}
		}
		if (!floraDiscovered && unlockStatus)
		{
			int numberOfDiscoveredFlora = GetNumberOfDiscoveredFlora();
			GoalsController.SetGoalEvent(GoalCondition.FLORA_DISCOVERED, numberOfDiscoveredFlora);
			if (numberOfDiscoveredFlora >= dogGutsManagerRef.allFlora.Count)
			{
				GoalsController.SetGoalEvent(GoalCondition.ALL_FLORA_DISCOVERED, 1);
			}
			CheckFieldGuideComplete();
		}
	}

	public float GetUnlockPercentageForFlora(FloraUnlockInfo infoRef)
	{
		float result = 0f;
		if (!infoRef.floraDiscovered)
		{
			return result;
		}
		float num = 1f;
		float num2 = 1f;
		num2 += (float)infoRef.floraEffects.Count;
		num += (float)infoRef.floraEffectDiscoveries.Count;
		for (int i = 0; i < infoRef.foodList.Count; i++)
		{
			InventoryItem itemForPath = inventoryRef.GetItemForPath(infoRef.foodList[i]);
			if ((CheatEngine.fishPackEnabled || itemForPath.setType != ItemSet.FISH) && (CheatEngine.groceryPackEnabled || itemForPath.setType != ItemSet.GROCERY) && (CheatEngine.desertPackEnabled || itemForPath.setType != ItemSet.DESERT) && (CheatEngine.basementPackEnabled || itemForPath.setType != ItemSet.BASEMENT))
			{
				num2 += 1f;
			}
		}
		for (int j = 0; j < infoRef.foodListDiscoveries.Count; j++)
		{
			InventoryItem itemForPath2 = inventoryRef.GetItemForPath(infoRef.foodListDiscoveries[j]);
			if ((CheatEngine.fishPackEnabled || itemForPath2.setType != ItemSet.FISH) && (CheatEngine.groceryPackEnabled || itemForPath2.setType != ItemSet.GROCERY) && (CheatEngine.desertPackEnabled || itemForPath2.setType != ItemSet.DESERT) && (CheatEngine.basementPackEnabled || itemForPath2.setType != ItemSet.BASEMENT))
			{
				num += 1f;
			}
		}
		return num / num2;
	}

	public float GetFieldGuideCompletionPercentage()
	{
		float num = 0f;
		float num2 = 0f;
		for (int i = 0; i < dogGutsManagerRef.allFlora.Count; i++)
		{
			FloraUnlockInfo unlockInfoForFloraPath = GetUnlockInfoForFloraPath(dogGutsManagerRef.floraNameToPathDict[dogGutsManagerRef.allFlora[i].gutFloraName]);
			num2 += 1f;
			num += GetUnlockPercentageForFlora(unlockInfoForFloraPath);
		}
		return num / num2;
	}

	public int GetNumberOfDiscoveredFlora()
	{
		int num = 0;
		for (int i = 0; i < dogGutsManagerRef.allFlora.Count; i++)
		{
			string key = dogGutsManagerRef.floraNameToPathDict[dogGutsManagerRef.allFlora[i].gutFloraName];
			if (floraUnlockStatus.ContainsKey(key) && floraUnlockStatus[key].floraDiscovered)
			{
				num++;
			}
		}
		return num;
	}

	public void ReportFoodUnlock(string floraPath, string foodPath, bool unlockStatus, bool fromConsumption)
	{
		bool flag = false;
		if (!floraUnlockStatus.ContainsKey(floraPath))
		{
			return;
		}
		if (floraUnlockStatus[floraPath].foodList.Contains(foodPath))
		{
			if (unlockStatus && !floraUnlockStatus[floraPath].foodListDiscoveries.Contains(foodPath))
			{
				flag = true;
				floraUnlockStatus[floraPath].foodListDiscoveries.Add(foodPath);
			}
		}
		else if (!fromConsumption)
		{
			floraUnlockStatus[floraPath].foodList.Add(foodPath);
			if (unlockStatus && !floraUnlockStatus[floraPath].foodListDiscoveries.Contains(foodPath))
			{
				flag = true;
				floraUnlockStatus[floraPath].foodListDiscoveries.Add(foodPath);
			}
		}
		if (flag)
		{
			CheckFieldGuideComplete();
		}
	}

	public void ReportEffectUnlock(string floraPath, GutFloraMutationEffect effect, bool unlockStatus)
	{
		if (!floraUnlockStatus.ContainsKey(floraPath))
		{
			return;
		}
		bool flag = false;
		if (floraUnlockStatus[floraPath].floraEffects.Contains(effect))
		{
			if (unlockStatus && !floraUnlockStatus[floraPath].floraEffectDiscoveries.Contains(effect))
			{
				flag = true;
				floraUnlockStatus[floraPath].floraEffectDiscoveries.Add(effect);
			}
		}
		else
		{
			floraUnlockStatus[floraPath].floraEffects.Add(effect);
			if (unlockStatus && !floraUnlockStatus[floraPath].floraEffectDiscoveries.Contains(effect))
			{
				flag = true;
				floraUnlockStatus[floraPath].floraEffectDiscoveries.Add(effect);
			}
		}
		if (flag)
		{
			CheckFieldGuideComplete();
		}
	}

	private void CheckFieldGuideComplete()
	{
		CheckFieldGuideComplete(GetFieldGuideCompletionPercentage());
	}

	public void CheckFieldGuideComplete(float percentage)
	{
		if (percentage >= 1f)
		{
			GoalsController.SetGoalEvent(GoalCondition.FLORA_GUIDE_COMPLETE, 1);
		}
	}

	private void InitializeUnlocks()
	{
		floraUnlockStatus.Clear();
		floraUnlockStatusKeys.Clear();
		for (int i = 0; i < dogGutsManagerRef.allFlora.Count; i++)
		{
			FloraUnlockInfo value = new FloraUnlockInfo();
			string text = dogGutsManagerRef.floraNameToPathDict[dogGutsManagerRef.allFlora[i].gutFloraName];
			floraUnlockStatusKeys.Add(text);
			floraUnlockStatus[text] = value;
		}
		ObjectRegistration.GetRegistrationScript().GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER).InitializeFloraUnlocks();
		for (int j = 0; j < dogGutsManagerRef.allFlora.Count; j++)
		{
			GutFloraBase component = dogGutsManagerRef.allFlora[j].gutFloraPrefab.GetComponent<GutFloraBase>();
			for (int k = 0; k < component.mutationEffects.Count; k++)
			{
				ReportEffectUnlock(dogGutsManagerRef.GetPathForFlora(dogGutsManagerRef.allFlora[j]), component.mutationEffects[k].effect, unlockStatus: false);
			}
		}
	}
}
