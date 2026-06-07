using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace UMA.CharacterSystem
{
	[ExecuteInEditMode]
	public class DynamicCharacterAvatar : UMAAvatarBase
	{
		[Flags]
		public enum ChangeRaceOptions
		{
			useDefaults = 0,
			none = 1,
			keepDNA = 2,
			keepWardrobe = 4,
			keepBodyColors = 8
		}

		[Flags]
		public enum LoadOptions
		{
			useDefaults = 0,
			loadRace = 1,
			loadDNA = 2,
			loadWardrobe = 4,
			loadBodyColors = 8,
			loadWardrobeColors = 0x10
		}

		[Flags]
		public enum SaveOptions
		{
			useDefaults = 0,
			saveDNA = 1,
			saveWardrobe = 2,
			saveColors = 4,
			saveAnimator = 8
		}

		public enum loadPathTypes
		{
			persistentDataPath = 0,
			Resources = 1,
			FileSystem = 2,
			CharacterSystem = 3,
			String = 4
		}

		public enum savePathTypes
		{
			persistentDataPath = 0,
			Resources = 1,
			FileSystem = 2
		}

		[Serializable]
		public class RaceSetter
		{
			public string name;

			[NonSerialized]
			private RaceData _theRaceData;

			public bool isValid => false;

			public RaceData data
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public RaceData racedata => null;

			public void SetRaceData()
			{
			}
		}

		[Serializable]
		public class WardrobeRecipeListItem
		{
			public string _recipeName;

			[NonSerialized]
			public UMATextRecipe _recipe;

			public bool _enabledInDefaultWardrobe;

			public List<string> _compatibleRaces;

			public WardrobeRecipeListItem()
			{
			}

			public WardrobeRecipeListItem(string recipeName)
			{
			}

			public WardrobeRecipeListItem(UMATextRecipe recipe)
			{
			}
		}

		[Serializable]
		public class WardrobeRecipeList
		{
			[Tooltip("If this is checked and the Avatar is NOT creating itself from a previously saved recipe, recipes in here will be added to the Avatar when it loads")]
			public bool loadDefaultRecipes;

			public List<WardrobeRecipeListItem> recipes;

			public List<WardrobeRecipeListItem> GetRecipesForRace(string raceName = "", RaceData race = null)
			{
				return null;
			}
		}

		[Serializable]
		public class RaceAnimator
		{
			public string raceName;

			public string animatorControllerName;

			public RuntimeAnimatorController animatorController;
		}

		[Serializable]
		public class RaceAnimatorList
		{
			public RuntimeAnimatorController defaultAnimationController;

			public List<RaceAnimator> animators;

			public bool dynamicallyAddFromResources;

			public string resourcesFolderPath;

			public RuntimeAnimatorController GetAnimatorForRace(string racename)
			{
				return null;
			}
		}

		[Serializable]
		public class ColorValue : OverlayColorData
		{
			[FormerlySerializedAs("Name")]
			[SerializeField]
			private string _name;

			[FormerlySerializedAs("Color")]
			[SerializeField]
			private Color _color;

			[FormerlySerializedAs("MetallicGloss")]
			[SerializeField]
			private Color _metallicGloss;

			[SerializeField]
			private bool Raw;

			public bool valuesConverted;

			public string Name
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public Color Color
			{
				get
				{
					return default(Color);
				}
				set
				{
				}
			}

			public Color MetallicGloss
			{
				get
				{
					return default(Color);
				}
				set
				{
				}
			}

			public ColorValue()
			{
			}

			public ColorValue(int channels)
			{
			}

			public ColorValue(string nameVal, Color colorVal)
			{
			}

			public ColorValue(string nameVal, OverlayColorData color)
			{
			}

			public ColorValue(ColorValue col)
			{
			}

			public ColorValue(OverlayColorData col)
			{
			}

			private void ConvertOldFieldsToNew()
			{
			}
		}

		[Serializable]
		[ExecuteInEditMode]
		public class ColorValueList
		{
			[FormerlySerializedAs("Colors")]
			public List<ColorValue> _colors;

			public List<ColorValue> Colors
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public ColorValueList()
			{
			}

			public ColorValueList(OverlayColorData[] colors)
			{
			}

			public ColorValueList(List<ColorValue> colorValueList)
			{
			}

			private ColorValue GetColorValue(string name)
			{
				return null;
			}

			public OverlayColorData[] ToOverlayColors()
			{
				return null;
			}

			public OverlayColorData ToOverlayColorData(ColorValue cv)
			{
				return null;
			}

			public bool GetColor(string Name, out Color c)
			{
				c = default(Color);
				return false;
			}

			public bool GetColor(string Name, out OverlayColorData c)
			{
				c = null;
				return false;
			}

			public void SetColor(string name, Color c)
			{
			}

			public void SetColor(string name, OverlayColorData c)
			{
			}

			public void SetRawColorParms(string name, OverlayColorData c)
			{
			}

			public void SetRawColor(string name, OverlayColorData c)
			{
			}

			public void RemoveColor(string name)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CDoWebLoad_003Ed__211 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string path;

			public DynamicCharacterAvatar _003C_003E4__this;

			private UnityWebRequest _003Cwww_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDoWebLoad_003Ed__211(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public float DelayUnload;

		public bool BundleCheck;

		private bool StartGuard;

		public bool KeepAnimatorController;

		[Tooltip("If true, the Animator will be rebuilt anytime the race changes")]
		public bool RecreateAnimatorOnRaceChange;

		public string userInformation;

		public UMADataEvent RecipeUpdated;

		public UMADataWardrobeEvent WardrobeAdded;

		public UMADataWardrobeEvent WardrobeRemoved;

		public UMACharacterEvent CharacterStart;

		public UMADataEvent BuildCharacterBegun;

		public UMASlotsEvent SlotsHidden;

		public UMARecipesEvent WardrobeSuppressed;

		[Tooltip("If checked will turn off the SkinnedMeshRenderer after the character has been created to hide it. If not checked will turn it on again.")]
		public bool hide;

		[NonSerialized]
		public bool lastHide;

		[Tooltip("When this is true, the meshcombiner will upload the data and the mesh will no longer be readable. Set this to false if you use a 3rd party asset that needs to read the mesh data.")]
		public bool markNotReadable;

		[Tooltip("When this is true, the meshcombiner will mark the mesh as dynamic. This will slightly decrease build time and slightly increase rendering.")]
		public bool markDynamic;

		[Tooltip("If true, then the meshcombiner will merge blendshapes found on slots that are part of this umaData")]
		public bool loadBlendShapes;

		[Tooltip("If true, then the meshcombiner will merge blendshapes that have active DNA")]
		public bool loadOnlyUsedBlendshapes;

		[Tooltip("If true, then normals will be loaded from the blendshapes if they exist")]
		public bool loadBlendshapeNormals;

		[Tooltip("If true, then tangents will be loaded from the blendshapes if they exist")]
		public bool loadBlendshapeTangents;

		[Tooltip("If true, then all frames of the blendshapes will be loaded. If false, only the LAST frame will be loaded.")]
		public bool loadAllFrames;

		[Tooltip("List of blendshapes that should always be kept, even if they would otherwise be optimized out.")]
		public List<string> forceKeepBlendshapes;

		[Tooltip("Limit the blendshapes to only those in this list. If empty, all blendshapes will be loaded. This can be set automatically when loading an Avatar Definition if you pass true to 'Limit Blendshapes to DNA'")]
		private HashSet<string> blendShapes;

		[Tooltip("If true, will reuse the mecanim avatar if it exists.")]
		public bool keepAvatar;

		[Tooltip("If checked, will not animate or modify the vertexes")]
		public bool rawAvatar;

		[Tooltip("If checked, the predefined DNA will always be loaded every time the character is built.")]
		public bool keepPredefinedDNA;

		[Tooltip("Selects the race to used. When initialized, the Avatar will use the base recipe from the RaceData selected.")]
		public RaceSetter activeRace;

		private RaceData previousRace;

		[EnumFlags]
		public ChangeRaceOptions defaultChangeRaceOptions;

		[Tooltip("When changing the race of the Avatar, cache the current state?")]
		public bool cacheCurrentState;

		[Tooltip("If true the existing skeleton is cleared and then rebuilt when the race is changed. Turn this off if you experience animation issues.")]
		public bool rebuildSkeleton;

		[Tooltip("Always rebuild the skeleton. This will clear out additional animated bones from slots.")]
		public bool alwaysRebuildSkeleton;

		[Tooltip("This will force the animator to rebind after avatar generation. You will know if you need to do this.")]
		public bool forceRebindAnimator;

		private Dictionary<string, UMATextRecipe> _wardrobeRecipes;

		private Dictionary<string, List<UMATextRecipe>> _additiveRecipes;

		private Dictionary<string, UMAWardrobeCollection> _wardrobeCollections;

		[Tooltip("You can add wardrobe recipes for many races in here and only the ones that apply to the active race will be applied to the Avatar")]
		public WardrobeRecipeList preloadWardrobeRecipes;

		[Tooltip("Add animation controllers here for specific races. If no Controller is found for the active race, the Default Animation Controller is used")]
		public RaceAnimatorList raceAnimationControllers;

		[Tooltip("Any colors here are set when the Avatar is first generated and updated as the values are changed using the color sliders")]
		public ColorValueList characterColors;

		public UMAPredefinedDNA predefinedDNA;

		private UMAPredefinedDNA savedDNA;

		private UMAPredefinedDNA overrideDNA;

		public loadPathTypes loadPathType;

		public string loadPath;

		public string loadFilename;

		public string loadString;

		public bool loadFileOnStart;

		[Tooltip("This will make the slot use the UMAMaterial of the first overlay")]
		public bool forceSlotMaterials;

		[Tooltip("Change to lower this specific DCA's atlas resolution. Leave 1.0f for resolution to be automatic.")]
		[Range(0f, 1f)]
		public float AtlasResolutionScale;

		[EnumFlags]
		public LoadOptions defaultLoadOptions;

		public savePathTypes savePathType;

		public string savePath;

		public string saveFilename;

		[Tooltip("If true a GUID is generated and appended to the filename of the saved file")]
		public bool makeUniqueFilename;

		[Tooltip("If true ALL the colors in the 'characterColors' section of the component are added to the recipe on save. Otherwise only the colors used by the recipe are saved (UMA default)")]
		public bool ensureSharedColors;

		[EnumFlags]
		public SaveOptions defaultSaveOptions;

		public Vector3 BoundsOffset;

		private List<UMATextRecipe> SuppressedRecipes;

		private List<SlotData> HiddenSlots;

		[SerializeField]
		[Tooltip("Builds the character on recipe load or race changed. If you want to load multiple recipes into a character you can disable this and enable it when you are done. By default this should be true.")]
		public bool _buildCharacterEnabled;

		private Dictionary<string, string> cacheStates;

		private List<string> requiredAssetsToCheck;

		private bool _isFirstSettingsBuild;

		private bool wasCrossCompatibleBuild;

		private List<string> crossCompatibleRaces;

		private List<string> forceSuppressedWardrobeSlots;

		private HashSet<string> forceRemovedBaseSlots;

		private List<string> forceSuppressSlotsContaining;

		private HashSet<string> forceRemovedTags;

		private static Scene SmooshScene;

		private static Dictionary<string, Mesh> SmooshTargets;

		public bool debugVertexes;

		public HashSet<string> ForceRemovedTags => null;

		public HashSet<string> ForceRemovedBaseSlots => null;

		public List<string> ForceSuppressedWardrobeSlots => null;

		public List<string> ForceSupressSlotsContaining => null;

		public string RacePreset
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Dictionary<string, List<UMATextRecipe>> AvailableRecipes => null;

		public List<string> CurrentWardrobeSlots => null;

		public OverlayColorData[] CurrentSharedColors => null;

		public List<ColorValue> ActiveColors => null;

		public Dictionary<string, UMATextRecipe> WardrobeRecipes => null;

		public Dictionary<string, List<UMATextRecipe>> AdditiveRecipes => null;

		public Dictionary<string, UMAWardrobeCollection> WardrobeCollections => null;

		public bool BuildCharacterEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private bool BuildUsingComponentSettings => false;

		public void Awake()
		{
		}

		public override void Start()
		{
		}

		public void InitialStartup()
		{
		}

		private void SetUMADataOptions()
		{
		}

		private List<GameObject> GetRenderers(GameObject parent)
		{
			return null;
		}

		public void InitializeFromPreset(UMAPreset preset)
		{
		}

		public void InitializeFromPreset(string presetstring)
		{
		}

		public void GenerateNow()
		{
		}

		public void ToggleHide(bool toggle)
		{
		}

		public void SetRenderers(bool val)
		{
		}

		private void Update()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void BuildFromComponentSettings()
		{
		}

		private void BuildFromStartingFileOrRecipe()
		{
		}

		private bool isDefaultDna(float val)
		{
			return false;
		}

		public AvatarDefinition GetAvatarDefinition(bool skipRaceDefaults, bool skipColorDefaults = true)
		{
			return default(AvatarDefinition);
		}

		public string GetAvatarDefinitionString(bool skipDefaults, bool skipColorDefaults = false)
		{
			return null;
		}

		private void LoadColors(AvatarDefinition adf, bool resetColors)
		{
		}

		private void LoadWardrobe(AvatarDefinition adf, bool loadDefaultWardobe, bool ResetWardrobe)
		{
		}

		private void PreloadAvatarDefinition(AvatarDefinition adf, bool loadDefaultWardrobe, bool resetDNA, bool resetWardrobe, bool resetColors, bool optimizeBlendShapes)
		{
		}

		private void PreloadDNA(AvatarDefinition adf, bool resetDNA, bool optimizeBlendshapes)
		{
		}

		private void SetFilteredBlendshapes(DnaDef[] dna)
		{
		}

		public void LoadAvatarDefinition(AvatarDefinition adf, bool loadDefaultWardrobe = false, bool ResetDNA = true, bool ResetWardrobe = true, bool ResetColors = true, bool optimizeBlendShapes = false)
		{
		}

		public void LoadAvatarDefinition(string adfstring, bool loadDefaultWardrobe = false, bool ResetDNA = true, bool ResetWardrobe = true, bool ResetColors = true, bool optimizeBlendShapes = false)
		{
		}

		private bool SetActiveRace()
		{
			return false;
		}

		public void ChangeRace(string racename, bool force)
		{
		}

		public bool ChangeRace(string racename, ChangeRaceOptions customChangeRaceOptions = ChangeRaceOptions.useDefaults, bool ForceChange = false)
		{
			return false;
		}

		public bool ForceRaceChange(string racename)
		{
			return false;
		}

		public void ChangeRaceData(string raceName)
		{
		}

		public void ChangeRace(RaceData race, ChangeRaceOptions customChangeRaceOptions = ChangeRaceOptions.useDefaults, bool ForceChange = false)
		{
		}

		private void PerformRaceChange(RaceData race, ChangeRaceOptions customChangeRaceOptions = ChangeRaceOptions.useDefaults)
		{
		}

		public void LoadDefaultWardrobe()
		{
		}

		public UMATextRecipe FindSlotRecipe(string Slotname, string Recipename)
		{
			return null;
		}

		public string GetWardrobeItemName(string SlotName)
		{
			return null;
		}

		public UMATextRecipe GetWardrobeItem(string SlotName)
		{
			return null;
		}

		private void internalSetSlot(UMATextRecipe utr, string thisRecipeSlot)
		{
		}

		public bool SetSlot(UMATextRecipe utr)
		{
			return false;
		}

		public void SetSlot(string Slotname)
		{
		}

		public void SetSlot(string Slotname, string Recipename)
		{
		}

		public void ClearSlot(string ws)
		{
		}

		public void ClearSlots(List<string> slotsToClear)
		{
		}

		public void ClearSlots()
		{
		}

		public void LoadWardrobeCollection(string collectionName)
		{
		}

		public void LoadWardrobeCollection(UMAWardrobeCollection uwr)
		{
		}

		public void ReapplyWardrobeCollections()
		{
		}

		public UMAWardrobeCollection GetWardrobeCollection(string collectionName)
		{
			return null;
		}

		public bool IsCollectionApplied(string collectionName, bool fullyApplied = false)
		{
			return false;
		}

		public UMAWardrobeCollection GetWardrobeCollectionGroup(string groupToCheck)
		{
			return null;
		}

		public void UnloadWardrobeCollection(string collectionToUnload)
		{
		}

		public void RemoveUnusedCollections()
		{
		}

		public void UnloadAllWardrobeCollections()
		{
		}

		public void UnloadWardrobeCollectionGroup(string collectionGroupToUnload)
		{
		}

		private void ApplyCurrentWardrobeToNewRace(List<WardrobeSettings> fallbackSet = null)
		{
		}

		public void LoadWardrobeSet(List<WardrobeSettings> wardrobeSet, bool clearExisting = false)
		{
		}

		private void ClearWardrobeCollectionsRecipes(bool removeUnappliedCollections = false)
		{
		}

		public OverlayColorData GetColor(string Name)
		{
			return null;
		}

		public void SetColor(string SharedColorName, Color AlbedoColor, Color MetallicRGB = default(Color), float Gloss = 0f, bool UpdateTexture = false)
		{
		}

		public void SetColorValue(string SharedColorName, Color AlbedoColor)
		{
		}

		public void SetColor(string Name, OverlayColorData colorData, bool UpdateTexture = true)
		{
		}

		public void SetRawColor(string Name, OverlayColorData colorData, bool UpdateTexture = true)
		{
		}

		public void ClearColor(string Name, bool Update = true)
		{
		}

		public void UpdateColors(bool triggerDirty = false)
		{
		}

		private void EnsureSharedColors()
		{
		}

		private OverlayColorData[] ImportSharedColors(OverlayColorData[] colorsToLoad, LoadOptions thisLoadOptions)
		{
			return null;
		}

		private List<string> GetBodyColorNames()
		{
			return null;
		}

		public List<OverlayColorData> LoadBodyColors(OverlayColorData[] colorsToLoad, bool apply = false)
		{
			return null;
		}

		public List<OverlayColorData> LoadWardrobeColors(OverlayColorData[] colorsToLoad, bool apply = false)
		{
			return null;
		}

		private List<OverlayColorData> LoadBodyOrWardrobeColors(OverlayColorData[] colorsToLoad, bool loadingBody = true, bool apply = false)
		{
			return null;
		}

		public List<OverlayColorData> RestoreCachedBodyColors(bool apply = false, bool fullRestore = false)
		{
			return null;
		}

		public List<OverlayColorData> RestoreCachedWardrobeColors(bool apply = false, bool fullRestore = false)
		{
			return null;
		}

		private List<OverlayColorData> RestoreCachedBodyOrWardrobeColors(bool restoringBody = true, bool apply = false, bool fullRestore = false)
		{
			return null;
		}

		private void TryImportDNAValues(UMADnaBase[] prevDna)
		{
		}

		public Dictionary<string, float> GetDefaultDNA()
		{
			return null;
		}

		public Dictionary<string, float> GetDNAValues(UMAData.UMARecipe recipe = null)
		{
			return null;
		}

		public Dictionary<string, DnaSetter> GetDNA(UMAData.UMARecipe recipe = null)
		{
			return null;
		}

		public void SetDNA(string DNAName, float value, bool rebuild = false)
		{
		}

		public UMADnaBase[] GetAllDNA()
		{
			return null;
		}

		public void SetExpressionSet(bool addExressionPlayer = false)
		{
		}

		private void InitializeExpressionPlayer(UMAData umaData)
		{
		}

		private void InitializeExpressionPlayer(bool enable = true)
		{
		}

		public void SetAnimatorController(bool addAnimator = false)
		{
		}

		public static SaveOptions GetSaveOptionsFlags(bool saveDNA, bool saveWardrobe, bool saveColors)
		{
			return default(SaveOptions);
		}

		public string GetCurrentWardrobeRecipe(string recipeName = "", bool includeColors = false, params string[] slotsToSave)
		{
			return null;
		}

		public string GetCurrentColorsRecipe(string recipeName = "")
		{
			return null;
		}

		public string GetCurrentDNARecipe(string recipeName = "")
		{
			return null;
		}

		private string DoPartialSave(string recipeName, SaveOptions thisSaveOpts)
		{
			return null;
		}

		public string GetCurrentRecipe(bool backwardsCompatible = false)
		{
			return null;
		}

		public void DoSave(bool saveAsAsset = false, string filePath = "", SaveOptions customSaveOptions = SaveOptions.useDefaults)
		{
		}

		private string GetSavePath(string extension)
		{
			return null;
		}

		public static LoadOptions GetLoadOptionsFlags(bool loadRace, bool loadDNA, bool loadWardrobe, bool loadBodyColors, bool loadWardrobeColors)
		{
			return default(LoadOptions);
		}

		public void LoadWardrobeFromRecipeString(string recipeString, bool loadColors = true, bool clearExisting = false)
		{
		}

		public void LoadColorsFromRecipeString(string recipeString, bool loadBodyColors = true, bool loadWardrobeColors = true)
		{
		}

		public void LoadDNAFromRecipeString(string recipeString)
		{
		}

		public void InitializeAvatar()
		{
		}

		public void Preload(string Recipe)
		{
		}

		public void SetLoadString(string recipeString)
		{
		}

		public void SetLoadFilename(string filename, loadPathTypes newLoadPathType)
		{
		}

		public void LoadFromRecipe(UMARecipeBase settingsToLoad, LoadOptions customLoadOptions = LoadOptions.useDefaults)
		{
		}

		public void LoadFromRecipeString(string settingsToLoad, LoadOptions customLoadOptions = LoadOptions.useDefaults, bool ClearWardrobe = false)
		{
		}

		private bool ImportSettings(UMATextRecipe.DCSUniversalPackRecipe settingsToLoad, LoadOptions customLoadOptions = LoadOptions.useDefaults, bool forceDCSLoad = false)
		{
			return false;
		}

		private void ImportOldUma(UMATextRecipe.DCSUniversalPackRecipe settingsToLoad, LoadOptions thisLoadOptions, bool wasBuildCharacterEnabled = true)
		{
		}

		public void DoLoad()
		{
		}

		public void LoadFromAssetFile(string Name)
		{
		}

		public void LoadFromTextFile(string Name)
		{
		}

		private void GetRecipeStringToLoad()
		{
		}

		[IteratorStateMachine(typeof(_003CDoWebLoad_003Ed__211))]
		private IEnumerator DoWebLoad(string path)
		{
			return null;
		}

		public bool DNAIsValid(UMADnaBase[] CurrentDNA)
		{
			return false;
		}

		public UMATextRecipe[] GetVisibleWearables()
		{
			return null;
		}

		public void BuildCharacter(bool RestoreDNA = true, bool skipBundleCheck = false, bool useBundleParameter = true)
		{
		}

		public void SetAndSaveOverrideDNA(UMAData udata)
		{
		}

		public void RestoreOverrideDna(UMAData udata)
		{
		}

		private void ApplyPredefinedDNA()
		{
		}

		public override void Load(UMARecipeBase umaRecipe, params UMARecipeBase[] umaAdditionalSerializedRecipes)
		{
		}

		private void LoadCharacter(UMARecipeBase umaRecipe, List<UMAWardrobeRecipe> Replaces, List<UMARecipeBase> umaAdditionalSerializedRecipes, UMARecipeBase[] AdditionalRecipes, Dictionary<string, List<MeshHideAsset>> MeshHideDictionary, List<string> hiddenSlots, List<string> HideTags, UMADnaBase[] CurrentDNA, bool restoreDNA, bool skipBundleCheck)
		{
		}

		private void ApplyDNAToModifiers()
		{
		}

		public Vector3 GetDestVertPhys(Vector3 originVertex, Vector3 center, float PlaneDist, SlotDataAsset SmooshTarget, PhysicsScene ps, int vertindex, float smooshDistance, float overSmoosh)
		{
			return default(Vector3);
		}

		private static void CreateSmooshScene()
		{
		}

		private static void CleanScene(Scene scene)
		{
		}

		public void SmooshSlotPhysics(UMAData umaData, SlotDataAsset SmooshMe, SlotDataAsset SmooshPlane, SlotDataAsset SmooshTarget, bool invertX, bool invertY, bool invertZ, bool invertDist, float smooshDistance, float overSmoosh)
		{
		}

		public void DrawBox(string boxName, Vector3 Min, Vector3 Max, Color c)
		{
		}

		private void UpdateBounds()
		{
		}

		private void UnloadAvatar()
		{
		}

		public void AddAdditionalSerializedRecipes(List<UMARecipeBase> umaAdditionalSerializedRecipes)
		{
		}

		private void FixCrossCompatibleSlots(List<string> hiddenSlots)
		{
		}

		private void OldReplaceSlot(UMAWardrobeRecipe Replacer)
		{
		}

		private void ReplaceSlot(UMAWardrobeRecipe Replacer)
		{
		}

		private void PostProcessSlots(List<string> hiddenSlots, List<string> hideTags = null)
		{
		}

		private void RemoveHiddenSlots(List<string> hiddenSlots)
		{
		}

		public void UpdateUMA()
		{
		}

		public void ForceUpdate(bool DnaDirty, bool TextureDirty = false, bool MeshDirty = false)
		{
		}

		public void AvatarCreated(UMAData uMAData)
		{
		}

		public void ApplyBounds()
		{
		}

		private void AddCharacterStateCache(string cacheStateName = "")
		{
		}

		private void UpdateSetSlots()
		{
		}

		public void Cleanup()
		{
		}

		public bool UpdatePending()
		{
			return false;
		}
	}
}
