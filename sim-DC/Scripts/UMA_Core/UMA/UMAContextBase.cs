using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	public abstract class UMAContextBase : MonoBehaviour
	{
		private static UMAContextBase _instance;

		public static UMAContextBase Instance
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public abstract void Start();

		public abstract void ValidateDictionaries();

		public abstract RaceData HasRace(string name);

		public abstract RaceData HasRace(int nameHash);

		public abstract void EnsureRaceKey(string name);

		public abstract RaceData GetRace(string name);

		public abstract RaceData GetRace(int nameHash);

		public abstract RaceData GetRaceWithUpdate(int nameHash, bool allowUpdate);

		public abstract RaceData[] GetAllRaces();

		public abstract RaceData[] GetAllRacesBase();

		public abstract void AddRace(RaceData race);

		public abstract SlotData InstantiateSlot(string name);

		public abstract SlotData InstantiateSlot(int nameHash);

		public abstract SlotData InstantiateSlot(string name, List<OverlayData> overlayList);

		public abstract SlotData InstantiateSlot(int nameHash, List<OverlayData> overlayList);

		public abstract bool HasSlot(string name);

		public abstract bool HasSlot(int nameHash);

		public abstract void AddSlotAsset(SlotDataAsset slot);

		public abstract bool HasOverlay(string name);

		public abstract bool HasOverlay(int nameHash);

		public abstract OverlayData InstantiateOverlay(string name);

		public abstract OverlayData InstantiateOverlay(int nameHash);

		public abstract OverlayData InstantiateOverlay(string name, Color color);

		public abstract OverlayData InstantiateOverlay(int nameHash, Color color);

		public abstract void AddOverlayAsset(OverlayDataAsset overlay);

		public abstract List<DynamicUMADnaAsset> GetAllDNA();

		public abstract DynamicUMADnaAsset GetDNA(string Name);

		public abstract RuntimeAnimatorController GetAnimatorController(string Name);

		public abstract List<RuntimeAnimatorController> GetAllAnimatorControllers();

		public abstract void AddRecipe(UMATextRecipe recipe);

		public abstract bool HasRecipe(string Name);

		public abstract bool CheckRecipeAvailability(string recipeName);

		public abstract UMATextRecipe GetRecipe(string filename, bool dynamicallyAdd);

		public abstract UMARecipeBase GetBaseRecipe(string filename, bool dynamicallyAdd);

		public abstract string GetCharacterRecipe(string filename);

		public abstract List<string> GetRecipeFiles();

		public abstract Dictionary<string, List<UMATextRecipe>> GetRecipes(string raceName);

		public abstract List<string> GetRecipeNamesForRaceSlot(string race, string slot);

		public abstract List<UMARecipeBase> GetRecipesForRaceSlot(string race, string slot);

		public static UMAContextBase FindInstance()
		{
			return null;
		}
	}
}
