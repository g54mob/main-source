using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class CitizenOutfitController : MonoBehaviour
{
	public enum CharacterAnchor
	{
		lowerTorso = 0,
		upperTorso = 1,
		Head = 2,
		Hat = 3,
		UpperArmRight = 4,
		UpperArmLeft = 5,
		LowerArmRight = 6,
		LowerArmLeft = 7,
		HandRight = 8,
		HandLeft = 9,
		UpperLegRight = 10,
		UpperLegLeft = 11,
		LowerLegRight = 12,
		LowerLegLeft = 13,
		Midriff = 14,
		RightFoot = 15,
		LeftFoot = 16,
		Hair = 17,
		Glasses = 18,
		ArmsParent = 19,
		beard = 20
	}

	[Serializable]
	public class AnchorConfig
	{
		public CharacterAnchor anchor;

		public Transform trans;

		public bool outline;

		public bool captureInSurveillance;

		public float weight;
	}

	[Serializable]
	public class Outfit
	{
		public ClothesPreset.OutfitCategory category;

		public List<OutfitClothes> clothes;
	}

	[Serializable]
	public class OutfitClothes
	{
		public string clothes;

		public List<ClothesPreset.ClothesTags> tags;

		public Color baseColor;

		public Color color1;

		public Color color2;

		public Color color3;

		public bool borrowed;

		[NonSerialized]
		public Dictionary<CharacterAnchor, List<MeshRenderer>> spawned;

		[NonSerialized]
		public int rank;

		[NonSerialized]
		public bool incomplete;

		[NonSerialized]
		public bool loadedThisCycle;
	}

	public struct BackupCovering
	{
		public Outfit outfit;

		public ClothesPreset preset;
	}

	public class NewClothingCreation
	{
		public GameObject newPrefab;

		public Vector3 offset;

		public Vector3 euler;
	}

	public enum ClothingCreatorDirectory
	{
		Tops = 0,
		Bottoms = 1,
		Hats = 2,
		Heads = 3,
		Shoes = 4,
		Underwear = 5,
		Undressed = 6
	}

	public enum Expression
	{
		neutral = 0,
		angry = 1,
		sad = 2,
		surprised = 3,
		happy = 4,
		asleep = 5
	}

	[Serializable]
	public class ExpressionSetup
	{
		public Expression expression;

		public Vector3 eyebrowsEuler;

		public float eyebrowsRaise;

		public float eyeHeightMultiplier;

		public bool allowBlinking;
	}

	[Header("Components/Anchors")]
	public Human human;

	public LODGroup lod;

	public MeshRenderer distantLOD;

	public bool isPoser;

	public ScenePoserController poser;

	public List<AnchorConfig> anchorConfig;

	public Dictionary<CharacterAnchor, Transform> anchorReference;

	public Transform pupilParent;

	public Transform leftPupil;

	public Transform rightPupil;

	public Transform eyebrowParent;

	public Transform rightEyebrow;

	public Transform leftEyebrow;

	public Transform mouth;

	public List<MeshRenderer> eyeRenderers;

	public List<MeshRenderer> eyebrowRenderers;

	public MeshRenderer mouthRenderer;

	[ReadOnly]
	public Vector3 pupilParentOffset;

	public List<ExpressionSetup> expressions;

	public Dictionary<Expression, ExpressionSetup> expressionReference;

	[Space(5f)]
	public Material bluePupil;

	public Material greenPupil;

	public Material brownPupil;

	public Material greyPupil;

	private Material eyebrowMat;

	[Header("Outfits")]
	public ClothesPreset.OutfitCategory loadedOutfit;

	public ClothesPreset.OutfitCategory currentOutfit;

	public ClothesPreset.OutfitCategory previousOutfit;

	[NonSerialized]
	public List<OutfitClothes> currentlyLoadedClothes;

	public List<MeshRenderer> allCurrentMeshes;

	public List<MeshFilter> allCurrentMeshFilters;

	private ClothesPreset currentHair;

	private MeshRenderer currentHairRend;

	private ClothesPreset currentHat;

	private MeshRenderer currentHatRend;

	public List<Outfit> outfits;

	[Header("Debug")]
	public List<MeshRenderer> debugRenderers;

	public bool debugOverride;

	[EnableIf("debugOverride")]
	public OccupationPreset debugOverrideJob;

	[EnableIf("debugOverride")]
	public Human.Gender debugOverrideGender;

	[EnableIf("debugOverride")]
	public Descriptors.BuildType debugOverrideBuild;

	[EnableIf("debugOverride")]
	public Descriptors.HairStyle debugOverrideHair;

	[EnableIf("debugOverride")]
	public Descriptors.EyeColour debugOverrideEyeColour;

	[EnableIf("debugOverride")]
	public Human.ShoeType debugOverrideShoeType;

	[Range(0f, 1f)]
	[EnableIf("debugOverride")]
	public float debugOverrideLipstick;

	[EnableIf("debugOverride")]
	public Color debugOverrideSkinColour;

	[EnableIf("debugOverride")]
	public Color debugOverrideHairColour;

	[EnableIf("debugOverride")]
	public Expression debugOverrideExpression;

	[EnableIf("debugOverride")]
	[Range(0f, 1f)]
	public float debugOverrideGrub;

	[Space(5f)]
	public bool enableDebugLog;

	public List<string> outfitDebug;

	[Header("Load Specific")]
	public List<ClothesPreset> outfitToLoad;

	[Header("Create New")]
	public string newClothingName;

	public ClothingCreatorDirectory directory;

	public List<GameObject> newClothingComponents;

	[Tooltip("If this is true, you only need the right side arms and/or legs present as models. The opposite side will be created with flipping.")]
	public bool CreateFlippedArmsAndLegsFromRightSide;

	private Dictionary<CharacterAnchor, int> coveredAnchors;

	private void Awake()
	{
	}

	public void GenerateOutfits(bool forceSpecificDebugOutfit = false)
	{
	}

	public Transform GetBodyAnchor(CharacterAnchor anchor)
	{
		return null;
	}

	public void MakeClothed()
	{
	}

	public void SetCurrentOutfit(ClothesPreset.OutfitCategory category, bool forceLoad = false, bool forceReload = false, bool ignoreIfDead = true)
	{
	}

	public void LoadCurrentOutfit(bool forceLoad = false, bool forceReload = false)
	{
	}

	private void SpawnClothingElement(OutfitClothes cl, ClothesPreset cp)
	{
	}

	private void AddMeshRenderer(MeshRenderer rend, ref Material applyMat, bool isLOD, ref OutfitClothes clothesOutfit, ClothesPreset.ModelSettings model)
	{
	}

	private void RemoveSpecificModel(OutfitClothes cl, CharacterAnchor a)
	{
	}

	public void HairHatCompatibilityCheck()
	{
	}

	private void RemoveClothingComponent(OutfitClothes cl)
	{
	}

	private void RemoveDebugRenderers()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void RemoveCurrentOutfit()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void LoadSpecificOutfit()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void SelectRandomOutfits()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CycleOutfits()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ResetAllOutfits()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CreateNewClothingPreset()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void LoadExpression()
	{
	}

	public T SafeDestroyGameObject<T>(T component) where T : Component
	{
		return null;
	}

	public T SafeDestroy<T>(T obj) where T : UnityEngine.Object
	{
		return null;
	}

	private Color PickColourFromPalette(ref List<ColourPalettePreset> palettes, string debug = "")
	{
		return default(Color);
	}

	private Color GetColourFromUnderneath(ClothesPreset thisPreset, ClothesPreset.OutfitCategory category, ClothesPreset.ClothingColourSource source, ref Dictionary<string, ClothesPreset> clothesDictionary)
	{
		return default(Color);
	}

	public bool GetChance(Human human, ref List<ClothesPreset.TraitPickRule> pickRules, out int addChance)
	{
		addChance = default(int);
		return false;
	}

	private void OnDestroy()
	{
	}
}
