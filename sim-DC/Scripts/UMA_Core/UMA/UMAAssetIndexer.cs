using System;
using System.Collections.Generic;
using System.Diagnostics;
using UMA.CharacterSystem;
using UnityEngine;

namespace UMA
{
	[PreferBinarySerialization]
	public class UMAAssetIndexer : ScriptableObject
	{
		[Serializable]
		public class TypeFolders
		{
			public string typeName;

			public string[] Folders;
		}

		private class recipeEqualityComparer : IEqualityComparer<UMAWardrobeRecipe>
		{
			public bool Equals(UMAWardrobeRecipe b1, UMAWardrobeRecipe b2)
			{
				return false;
			}

			public int GetHashCode(UMAWardrobeRecipe bx)
			{
				return 0;
			}
		}

		private const float DefaultLife = 5f;

		private string instanceKey;

		public UMALabelsEvent BeforeProcessingLabels;

		public List<TypeFolders> typeFolders;

		public Dictionary<string, List<string>> TypeFolderSearch;

		private Dictionary<string, Dictionary<string, List<UMATextRecipe>>> raceRecipes;

		public static string SortOrder;

		public static string[] SortOrders;

		public static Dictionary<string, Type> TypeFromString;

		public Dictionary<string, AssetItem> GuidTypes;

		protected Dictionary<Type, Type> TypeToLookup;

		public List<string> IndexedTypeNames;

		public List<AssetItem> SerializedItems;

		private Dictionary<Type, Dictionary<string, AssetItem>> TypeLookup;

		private Type[] Types;

		private static UMAAssetIndexer theIndexer;

		private static bool WasChecked;

		private recipeEqualityComparer req;

		[NonSerialized]
		public List<UMAData> dirtyList;

		public static UMAAssetIndexer Instance => null;

		public bool IndexIsValid => false;

		private void CreateTypeFolderMapping()
		{
		}

		public void Awake()
		{
		}

		private void DebugLog(string msg)
		{
		}

		public static Stopwatch StartTimer()
		{
			return null;
		}

		public static void StopTimer(Stopwatch st, string Status)
		{
		}

		public static void Unload()
		{
		}

		public void Initialize()
		{
		}

		public Type GetRuntimeType(Type type)
		{
			return null;
		}

		public Type[] GetTypes()
		{
			return null;
		}

		public Type GetIndexedType(Type type)
		{
			return null;
		}

		public Dictionary<Type, Type>.ValueCollection GetIndexedTypeValues()
		{
			return null;
		}

		public bool IsIndexedType(Type type)
		{
			return false;
		}

		public bool IsAdditionalIndexedType(string QualifiedName)
		{
			return false;
		}

		public void AddType(Type sType)
		{
		}

		public void RemoveType(Type sType)
		{
		}

		public AssetItem GetRecipeItem(UMAPackedRecipeBase recipe)
		{
			return null;
		}

		public UMAData.UMARecipe GetRecipe(UMATextRecipe recipe, UMAContextBase context)
		{
			return null;
		}

		public bool HasAsset<T>(string Name)
		{
			return false;
		}

		public bool HasAsset<T>(int NameHash)
		{
			return false;
		}

		public AssetItem GetAssetItem<T>(string Name)
		{
			return null;
		}

		public AssetItem GetAssetItemForObject(UnityEngine.Object o)
		{
			return null;
		}

		public AssetItem GetAssetItem(Type ot, string Name)
		{
			return null;
		}

		public List<AssetItem> GetAssetItems(string recipe, bool LookForLODs = false)
		{
			return null;
		}

		public List<AssetItem> GetAssetItems(UMAPackedRecipeBase recipe, bool LookForLODs = false)
		{
			return null;
		}

		private List<AssetItem> GetAssetItemsV2(UMAPackedRecipeBase.UMAPackRecipe PackRecipe, bool LookForLods)
		{
			return null;
		}

		private void GetEvilAssetNameAndHash(Type type, UnityEngine.Object o, ref string assetName, int assetHash)
		{
		}

		public List<AssetItem> GetAssetItems<T>()
		{
			return null;
		}

		public List<AssetItem> GetAssetItems(Type t)
		{
			return null;
		}

		public List<T> GetAllAssets<T>(string[] foldersToSearch = null) where T : UnityEngine.Object
		{
			return null;
		}

		public T GetAsset<T>(int nameHash, string[] foldersToSearch = null, bool recursionGuard = false) where T : UnityEngine.Object
		{
			return null;
		}

		public T GetAsset<T>(string name, string[] foldersToSearch, bool recursionGuard = false) where T : UnityEngine.Object
		{
			return null;
		}

		public UMATextRecipe GetRecipeWardrobeTextCollection(string name)
		{
			return null;
		}

		public T GetAsset<T>(string name, bool recursionGuard = false) where T : UnityEngine.Object
		{
			return null;
		}

		public List<UMARecipeBase> GetRecipesForRaceSlot(string race, string slot)
		{
			return null;
		}

		private void internalGetRecipes(string race, ref Dictionary<string, HashSet<UMATextRecipe>> results)
		{
		}

		public Dictionary<string, List<UMATextRecipe>> GetRecipes(string race)
		{
			return null;
		}

		private HashSet<string> internalGetRecipeNamesForRaceSlot(string race, string slot)
		{
			return null;
		}

		public List<string> GetRecipeNamesForRaceSlot(string race, string slot)
		{
			return null;
		}

		public void AddFromAssetBundle(AssetBundle ab)
		{
		}

		public void UnloadBundle(AssetBundle ab)
		{
		}

		private bool AssetFolderCheck(AssetItem itemToCheck, string[] foldersToSearch = null)
		{
			return false;
		}

		public UMAContextBase GetContext()
		{
			return null;
		}

		public void DestroyEditorUMAContextBase()
		{
		}

		private void RemoveItem(UnityEngine.Object ob)
		{
		}

		public void ProcessNewItem(UnityEngine.Object result, bool isAddressable, bool keepLoaded)
		{
		}

		public void PostBuildMaterialFixup()
		{
		}

		public void AddAsset(Type type, string name, string path, UnityEngine.Object o)
		{
		}

		public bool AddAssetItem(AssetItem ai, bool noDirty = false)
		{
			return false;
		}

		private void AddToTypeDictionary(AssetItem ai, Dictionary<string, AssetItem> TypeDic)
		{
		}

		private void AddToGUIDTypes(AssetItem ai)
		{
		}

		private bool AlreadyHasItem(AssetItem ai, Dictionary<string, AssetItem> typeDic)
		{
			return false;
		}

		private bool GetTypeDictionary(AssetItem ai, out Dictionary<string, AssetItem> TypeDic)
		{
			TypeDic = null;
			return false;
		}

		private void AddToRaceLookup(UMAWardrobeRecipe uwr)
		{
		}

		public void ClearItem(UnityEngine.Object obj)
		{
		}

		public void ReleaseReference(UnityEngine.Object obj)
		{
		}

		public void UpdateSerializedDictionaryItems()
		{
		}

		private void RecreateTypeLookups()
		{
		}

		private void AddRaceRecipe(UMAWardrobeRecipe uwr)
		{
		}

		private void RebuildRaceRecipes()
		{
		}

		private void CreateLookupDictionary(Type type)
		{
		}

		private void DebugSerialization(string msg, bool isClear = false)
		{
		}

		private static void DebugSerializationStatic(string msg, string instanceKey = "", bool isClear = false)
		{
		}

		public void BuildStringTypes()
		{
		}

		public Dictionary<string, AssetItem> GetAssetDictionary(Type type)
		{
			return null;
		}

		public void RebuildIndex()
		{
		}

		public void ClearDictionaries()
		{
		}

		public RaceData HasRace(string name)
		{
			return null;
		}

		public RaceData GetRace(string name)
		{
			return null;
		}

		public RaceData[] GetAllRaces()
		{
			return null;
		}

		public RaceData[] GetAllRacesBase()
		{
			return null;
		}

		public void AddRace(RaceData race)
		{
		}

		public SlotData InstantiateSlot(string name)
		{
			return null;
		}

		public SlotData InstantiateSlot(int nameHash)
		{
			return null;
		}

		public SlotData InstantiateSlot(string name, List<OverlayData> overlayList)
		{
			return null;
		}

		public SlotData InstantiateSlot(int nameHash, List<OverlayData> overlayList)
		{
			return null;
		}

		public bool HasSlot(string name)
		{
			return false;
		}

		public bool HasSlot(int nameHash)
		{
			return false;
		}

		public void AddSlotAsset(SlotDataAsset slot)
		{
		}

		public bool HasOverlay(string name)
		{
			return false;
		}

		public bool HasOverlay(int nameHash)
		{
			return false;
		}

		public OverlayData InstantiateOverlay(string name)
		{
			return null;
		}

		public OverlayData InstantiateOverlay(int nameHash)
		{
			return null;
		}

		public OverlayData InstantiateOverlay(string name, Color color)
		{
			return null;
		}

		public OverlayData InstantiateOverlay(int nameHash, Color color)
		{
			return null;
		}

		public void AddOverlayAsset(OverlayDataAsset overlay)
		{
		}

		public List<DynamicUMADnaAsset> GetAllDNA()
		{
			return null;
		}

		public DynamicUMADnaAsset GetDNA(string Name)
		{
			return null;
		}

		public RuntimeAnimatorController GetAnimatorController(string Name)
		{
			return null;
		}

		public List<RuntimeAnimatorController> GetAllAnimatorControllers()
		{
			return null;
		}

		public void AddRecipe(UMATextRecipe recipe)
		{
		}

		public UMATextRecipe GetRecipe(string filename, bool dynamicallyAdd = true)
		{
			return null;
		}

		public UMARecipeBase GetBaseRecipe(string filename, bool dynamicallyAdd)
		{
			return null;
		}

		public string GetCharacterRecipe(string filename)
		{
			return null;
		}

		public List<string> GetRecipeFiles()
		{
			return null;
		}

		public bool HasRecipe(string Name)
		{
			return false;
		}

		public bool CheckRecipeAvailability(string recipeName)
		{
			return false;
		}
	}
}
