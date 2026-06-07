using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	public class UMAGlobalContext : UMAContextBase
	{
		public override void Start()
		{
		}

		public override void ValidateDictionaries()
		{
		}

		public override RaceData HasRace(string name)
		{
			return null;
		}

		public override RaceData HasRace(int nameHash)
		{
			return null;
		}

		public override void EnsureRaceKey(string name)
		{
		}

		public override RaceData GetRace(string name)
		{
			return null;
		}

		public override RaceData GetRace(int nameHash)
		{
			return null;
		}

		public override RaceData GetRaceWithUpdate(int nameHash, bool allowUpdate)
		{
			return null;
		}

		public override RaceData[] GetAllRaces()
		{
			return null;
		}

		public override RaceData[] GetAllRacesBase()
		{
			return null;
		}

		public override void AddRace(RaceData race)
		{
		}

		public override SlotData InstantiateSlot(string name)
		{
			return null;
		}

		public override SlotData InstantiateSlot(int nameHash)
		{
			return null;
		}

		public override SlotData InstantiateSlot(string name, List<OverlayData> overlayList)
		{
			return null;
		}

		public override SlotData InstantiateSlot(int nameHash, List<OverlayData> overlayList)
		{
			return null;
		}

		public override bool HasSlot(string name)
		{
			return false;
		}

		public override bool HasSlot(int nameHash)
		{
			return false;
		}

		public override void AddSlotAsset(SlotDataAsset slot)
		{
		}

		public override bool HasOverlay(string name)
		{
			return false;
		}

		public override bool HasOverlay(int nameHash)
		{
			return false;
		}

		public override OverlayData InstantiateOverlay(string name)
		{
			return null;
		}

		public override OverlayData InstantiateOverlay(int nameHash)
		{
			return null;
		}

		public override OverlayData InstantiateOverlay(string name, Color color)
		{
			return null;
		}

		public override OverlayData InstantiateOverlay(int nameHash, Color color)
		{
			return null;
		}

		public override void AddOverlayAsset(OverlayDataAsset overlay)
		{
		}

		public override List<DynamicUMADnaAsset> GetAllDNA()
		{
			return null;
		}

		public override DynamicUMADnaAsset GetDNA(string Name)
		{
			return null;
		}

		public override RuntimeAnimatorController GetAnimatorController(string Name)
		{
			return null;
		}

		public override List<RuntimeAnimatorController> GetAllAnimatorControllers()
		{
			return null;
		}

		public override void AddRecipe(UMATextRecipe recipe)
		{
		}

		public override UMATextRecipe GetRecipe(string filename, bool dynamicallyAdd = true)
		{
			return null;
		}

		public override UMARecipeBase GetBaseRecipe(string filename, bool dynamicallyAdd)
		{
			return null;
		}

		public override string GetCharacterRecipe(string filename)
		{
			return null;
		}

		public override List<string> GetRecipeFiles()
		{
			return null;
		}

		public override bool HasRecipe(string Name)
		{
			return false;
		}

		public override bool CheckRecipeAvailability(string recipeName)
		{
			return false;
		}

		public override List<string> GetRecipeNamesForRaceSlot(string race, string slot)
		{
			return null;
		}

		public override List<UMARecipeBase> GetRecipesForRaceSlot(string race, string slot)
		{
			return null;
		}

		public override Dictionary<string, List<UMATextRecipe>> GetRecipes(string raceName)
		{
			return null;
		}
	}
}
