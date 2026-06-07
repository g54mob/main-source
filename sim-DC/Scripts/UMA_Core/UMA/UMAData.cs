using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace UMA
{
	public class UMAData : MonoBehaviour
	{
		[Serializable]
		public class GeneratedMaterials
		{
			public List<GeneratedMaterial> materials;

			public List<UMARendererAsset> rendererAssets;

			public List<Texture> GetTextures(UMAMaterial umaMaterial, int textureChannel)
			{
				return null;
			}

			public Texture GetTexture(UMARendererAsset rendererAsset, Material material, int textureChannel)
			{
				return null;
			}
		}

		[Serializable]
		public class GeneratedMaterial
		{
			public UMAMaterial umaMaterial;

			public Material material;

			public Material secondPassMaterial;

			public List<MaterialFragment> materialFragments;

			public Texture[] resultingAtlasList;

			public Vector2 cropResolution;

			public Vector2 resolutionScale;

			public string[] textureNameList;

			public UMARendererAsset rendererAsset;

			public SkinnedMeshRenderer skinnedMeshRenderer;

			public int materialIndex;
		}

		[Serializable]
		public class MaterialFragment
		{
			public int size;

			public Color baseColor;

			public UMAMaterial umaMaterial;

			public Rect[] rects;

			public textureData[] overlays;

			public Color32[] overlayColors;

			public Color[][] channelMask;

			public Color[][] channelAdditiveMask;

			public SlotData slotData;

			public OverlayData[] overlayData;

			public Rect atlasRegion;

			public bool isRectShared;

			public bool isNoTextures;

			public List<OverlayData> overlayList;

			public MaterialFragment rectFragment;

			public textureData baseOverlay;

			public int baseVertexInMesh;

			public List<Dictionary<int, Texture>> overrides;

			public Color GetMultiplier(int overlay, int textureType)
			{
				return default(Color);
			}

			public Color32 GetAdditive(int overlay, int textureType)
			{
				return default(Color32);
			}
		}

		[Serializable]
		public class textureData
		{
			public Texture[] textureList;

			public Texture alphaTexture;

			public OverlayDataAsset.OverlayType overlayType;
		}

		[Serializable]
		public class resultAtlasTexture
		{
			public Texture[] textureList;
		}

		[Serializable]
		public class UMARecipe
		{
			public RaceData raceData;

			private Dictionary<int, UMADnaBase> _umaDna;

			protected Dictionary<int, List<DNAConvertDelegate>> umaDNAConverters;

			protected Dictionary<int, List<DNAConvertDelegate>> umaDNAPreApplyConverters;

			protected Dictionary<int, List<DNAConvertDelegate>> umaDNAPostApplyConverters;

			protected Dictionary<string, int> mergedSharedColors;

			[SerializeField]
			public List<UMADnaBase> dnaValues;

			public SlotData[] slotDataList;

			public OverlayColorData[] sharedColors;

			protected Dictionary<int, UMADnaBase> umaDna
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public Dictionary<string, List<MeshHideAsset>> MeshHideDictionary { get; set; }

			public Dictionary<string, List<UMAMeshData>> BlendshapeSlots { get; set; }

			public void UpdateMeshHideMasks()
			{
			}

			public bool Validate()
			{
				return false;
			}

			public bool HasSharedColor(OverlayColorData col)
			{
				return false;
			}

			public UMADnaBase[] GetAllDna()
			{
				return null;
			}

			public UMADnaBase[] GetDefinedDna()
			{
				return null;
			}

			public void AddDna(UMADnaBase dna)
			{
			}

			public T GetDna<T>() where T : UMADnaBase
			{
				return null;
			}

			public void ClearDna()
			{
			}

			public void RemoveDna(int dnaTypeNameHash)
			{
			}

			public void RemoveDna(Type type)
			{
			}

			public UMADnaBase GetDna(Type type)
			{
				return null;
			}

			public UMADnaBase GetDna(int dnaTypeNameHash)
			{
				return null;
			}

			public T GetOrCreateDna<T>() where T : UMADnaBase
			{
				return null;
			}

			public UMADnaBase GetOrCreateDna(Type type)
			{
				return null;
			}

			public UMADnaBase GetOrCreateDna(Type type, int dnaTypeHash)
			{
				return null;
			}

			public void SetRace(RaceData raceData)
			{
			}

			public RaceData GetRace()
			{
				return null;
			}

			public void SetSlot(int index, SlotData slot)
			{
			}

			public void SetSlots(SlotData[] slots)
			{
			}

			public void RemoveSlot(SlotData sd)
			{
			}

			public SlotData FindSlot(string slotName)
			{
				return null;
			}

			public SlotData FindSlotForVertex(int vert)
			{
				return null;
			}

			public SlotData MergeSlot(SlotData slot, bool dontSerialize, bool mergeMatchingOverlays = true)
			{
				return null;
			}

			public SlotData GetSlot(int index)
			{
				return null;
			}

			public SlotData GetSlot(string name)
			{
				return null;
			}

			public SlotData GetFirstSlot()
			{
				return null;
			}

			public SlotData[] GetAllSlots()
			{
				return null;
			}

			public int GetSlotArraySize()
			{
				return 0;
			}

			public Dictionary<string, SlotData> GetIndexedSlots()
			{
				return null;
			}

			public Dictionary<string, SlotData> GetFirstIndexedSlotsByTag()
			{
				return null;
			}

			public Dictionary<string, List<SlotData>> GetIndexedSlotsByTag()
			{
				return null;
			}

			public static bool OverlayListsMatch(List<OverlayData> list1, List<OverlayData> list2)
			{
				return false;
			}

			public void ClearOverlayColorAdjusters()
			{
			}

			public void MergeMatchingOverlays()
			{
			}

			public void PreApplyDNA(UMAData umaData, bool fixUpUMADnaToDynamicUMADna = false)
			{
			}

			public void ApplyDNA(UMAData umaData)
			{
			}

			public void ApplyPostpassDNA(UMAData umaData)
			{
			}

			public void EnsureAllDNAPresent()
			{
			}

			public void ClearDNAConverters()
			{
			}

			public void AddDNAUpdater(IDNAConverter dnaConverter)
			{
			}

			public UMARecipe Mirror()
			{
				return null;
			}

			public void Compress()
			{
			}

			public void Merge(UMARecipe recipe, bool dontSerialize, bool mergeMatchingOverlays = true, bool mergeDNA = true, string raceName = null)
			{
			}
		}

		[Serializable]
		public class BoneData
		{
			public Transform boneTransform;

			public Vector3 originalBoneScale;

			public Vector3 originalBonePosition;

			public Quaternion originalBoneRotation;
		}

		private const string HolderObjectName = "UMA_MI_Holder";

		[SerializeField]
		private SkinnedMeshRenderer[] renderers;

		private UMARendererAsset[] rendererAssets;

		public List<SlotTracker> slotTrackers;

		public List<UMASavedItem> savedItems;

		public string userInformation;

		private Dictionary<string, List<MeshModifier.Modifier>> meshModifiers;

		private Dictionary<string, List<MeshModifier.Modifier>> accumulatedModifiers;

		[NonSerialized]
		public bool staticCharacter;

		[NonSerialized]
		public bool firstBake;

		[NonSerialized]
		public bool RebuildSkeleton;

		public bool rawAvatar;

		public bool raceChanged;

		public bool hideRenderers;

		public UMAGeneratorBase umaGenerator;

		[NonSerialized]
		public GeneratedMaterials generatedMaterials;

		private LinkedListNode<UMAData> listNode;

		[SerializeField]
		public UmaTPose OverrideTpose;

		public Dictionary<string, Dictionary<int, Texture>> TextureOverrides;

		public Dictionary<string, Vector3[]> VertexOverrides;

		public Dictionary<string, Vector2[]> UVOverrides;

		public float atlasResolutionScale;

		public bool ForceRebindAnimator;

		public bool isMeshDirty;

		public bool isShapeDirty;

		public bool isTextureDirty;

		public bool isAtlasDirty;

		public bool markNotReadable;

		public bool markDynamic;

		public BlendShapeSettings blendShapeSettings;

		public RuntimeAnimatorController animationController;

		private Dictionary<int, int> animatedBonesTable;

		[NonSerialized]
		public bool dirty;

		private bool isOfficiallyCreated;

		public UMADataEvent CharacterCreated;

		public UMADataEvent CharacterDestroyed;

		public UMADataEvent CharacterUpdated;

		public UMADataEvent CharacterBeforeUpdated;

		public UMADataEvent CharacterBeforeDnaUpdated;

		public UMADataEvent CharacterDnaUpdated;

		public UMADataEvent CharacterBegun;

		public UMADataEvent AnimatorStateSaved;

		public UMADataEvent AnimatorStateRestored;

		public UMADataEvent PreUpdateUMABody;

		public GameObject umaRoot;

		[FormerlySerializedAs("umaRecipe")]
		public UMARecipe _umaRecipe;

		[NonSerialized]
		public UMARecipe umaOverrideRecipe;

		public Animator animator;

		public UMASkeleton skeleton;

		public bool KeepAvatar;

		public float characterHeight;

		public float characterRadius;

		public float characterMass;

		public UMARendererAsset defaultRendererAsset { get; set; }

		public int rendererCount => 0;

		public Dictionary<string, List<MeshModifier.Modifier>> Modifiers => null;

		public bool cancelled { get; private set; }

		public UMARecipe umaRecipe
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public event Action<UMAData> OnCharacterBegun
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<UMAData> OnCharacterUpdated
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<UMAData> OnCharacterCreated
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<UMAData> OnCharacterDestroyed
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<UMAData> OnCharacterDnaUpdated
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<UMAData> OnCharacterBeforeUpdated
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<UMAData> OnCharacterBeforeDnaUpdated
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<UMAData> OnAnimatorStateSaved
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<UMAData> OnAnimatorStateRestored
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<UMAData> OnPreUpdateUMABody
		{
			add
			{
			}
			remove
			{
			}
		}

		public void ClearModifiers()
		{
		}

		public void AddMeshModifier(MeshModifier.Modifier modifier)
		{
		}

		public void AddMeshModifiers(List<MeshModifier.Modifier> modifiers)
		{
		}

		public void BuildActiveModifiers()
		{
		}

		public void SaveMountedItems()
		{
		}

		public void SaveBonesRecursively(Transform bone, Transform holder, string ignoreTag, string keepTag)
		{
		}

		public void AddSavedItem(Transform transform, bool replace)
		{
		}

		public void RestoreSavedItems()
		{
		}

		public SkinnedMeshRenderer GetRenderer(int idx)
		{
			return null;
		}

		public int GetRendererIndex(SkinnedMeshRenderer renderer)
		{
			return 0;
		}

		public UMARendererAsset GetRendererAsset(int idx)
		{
			return null;
		}

		public SkinnedMeshRenderer[] GetRenderers()
		{
			return null;
		}

		public UMARendererAsset[] GetRendererAssets()
		{
			return null;
		}

		public void SetRenderers(SkinnedMeshRenderer[] renderers)
		{
		}

		public void SetRendererAssets(UMARendererAsset[] assets)
		{
		}

		public bool AreRenderersEqual(List<UMARendererAsset> rendererList)
		{
			return false;
		}

		public void ResetRendererSettings(int idx)
		{
		}

		public void MoveToList(LinkedList<UMAData> list)
		{
		}

		public void ClearOverrides()
		{
		}

		public void AddOverrideTPose(UmaTPose thePose)
		{
		}

		public void AddUVOverride(SlotDataAsset theSlot, Vector2[] theUV)
		{
		}

		public void AddVertexOverride(SlotDataAsset theSlot, Vector3[] theVerts)
		{
		}

		public void RemoveVertexOverride(SlotDataAsset theSlot)
		{
		}

		public void AddTextureOverride(string OverlayName, int Channel, Texture2D theTexture)
		{
		}

		public void RemoveTextureOverride(string OverlayName, int Channel)
		{
		}

		public bool hasOverrides()
		{
			return false;
		}

		public void LogOverrides()
		{
		}

		public Dictionary<int, Texture> GetTextureOverrides(string OverlayName)
		{
			return null;
		}

		public void CheckSkeletonSetup()
		{
		}

		public void SetupSkeleton()
		{
		}

		public void ResetAnimatedBones()
		{
		}

		public void RegisterAnimatedBone(int hash)
		{
		}

		public Transform GetGlobalTransform()
		{
			return null;
		}

		public void RegisterAnimatedBoneHierarchy(int hash)
		{
		}

		private void Awake()
		{
		}

		public UMAGeneratorBase FindGenerator()
		{
			return null;
		}

		public void Initialize(UMAGeneratorBase generator)
		{
		}

		public void SetupOnAwake()
		{
		}

		public void Assign(UMAData other)
		{
		}

		public bool Validate()
		{
			return false;
		}

		public void Show()
		{
		}

		public void Hide()
		{
		}

		public void FirePreUpdateUMABody()
		{
		}

		public void FireAnimatorStateSavedEvent()
		{
		}

		public void FireAnimatorStateRestoredEvent()
		{
		}

		public void FireUpdatedEvent(bool cancelled)
		{
		}

		public void PreApplyDNA()
		{
		}

		public void ApplyDNA()
		{
		}

		public void PostApplyDNA()
		{
		}

		public virtual void Dirty()
		{
		}

		private void OnDestroy()
		{
		}

		public void CleanAvatar()
		{
		}

		public void CleanTextures()
		{
		}

		public void CleanMesh(bool destroyRenderer)
		{
		}

		public RenderTexture GetFirstRenderTexture()
		{
			return null;
		}

		public GameObject GetBoneGameObject(string boneName)
		{
			return null;
		}

		public GameObject GetBoneGameObject(int boneHash)
		{
			return null;
		}

		public UMADnaBase[] GetAllDna()
		{
			return null;
		}

		public UMADnaBase GetDna(int dnaTypeNameHash)
		{
			return null;
		}

		public UMADnaBase GetDna(Type type)
		{
			return null;
		}

		public T GetDna<T>() where T : UMADnaBase
		{
			return null;
		}

		public void Dirty(bool dnaDirty, bool textureDirty, bool meshDirty)
		{
		}

		public void SetSlot(int index, SlotData slot)
		{
		}

		public void SetSlots(SlotData[] slots)
		{
		}

		public SlotData GetSlot(int index)
		{
			return null;
		}

		public int GetSlotArraySize()
		{
			return 0;
		}

		public UMASkeleton GetSkeleton()
		{
			return null;
		}

		public UmaTPose GetTPose()
		{
			return null;
		}

		public void GotoTPose()
		{
		}

		public int[] GetAnimatedBones()
		{
			return null;
		}

		public void FireCharacterBegunEvents()
		{
		}

		public void FireDNAAppliedEvents()
		{
		}

		public void FireCharacterCompletedEvents(bool fireEvents = true)
		{
		}

		public void AddAdditionalRecipes(UMARecipeBase[] umaAdditionalRecipes, UMAContextBase context, bool mergeMatchingOverlays = true)
		{
		}

		[Obsolete("AddBakedBlendShape has been replaced with SetBlendShapeData", true)]
		public void AddBakedBlendShape(float dnaValue, string blendShapeZero, string blendShapeOne, bool rebuild = false)
		{
		}

		[Obsolete("RemoveBakedBlendShape has been replaced with RemoveBlendShapeData", true)]
		public void RemoveBakedBlendShape(string name, bool rebuild = false)
		{
		}

		public void SetBlendShapeData(string name, bool bake, bool rebuild = false)
		{
		}

		public void RemoveBlendShapeData(string name, bool rebuild = false)
		{
		}

		public void SetBlendShape(string name, float weight, bool allowRebuild = false)
		{
		}

		public string GetBlendShapeName(int shapeIndex, int rendererIndex = 0)
		{
			return null;
		}
	}
}
