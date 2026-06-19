using System;
using System.Collections;
using System.Collections.Generic;
using HighlightingSystem;
using I2.Loc;
using UnityEngine;

public class DogLooks : MonoBehaviour
{
	private delegate string GeneGenerator(int size, bool addSeperator = true);

	public bool isDummy;

	private bool isGhost;

	public Material ghostBodyMat;

	public Material ghostFaceMat;

	public Material ghostNoseEarsMat;

	public bool useOldHead;

	public GameObject oldFace;

	public GameObject oldFaceHolder;

	public GameObject face;

	public GameObject faceHolder;

	public GameObject nose;

	public GameObject oldNose;

	public GameObject ears;

	public GameObject hornLeftHolder;

	public GameObject hornCenterHolder;

	public GameObject hornRightHolder;

	public GameObject bodyFront;

	public GameObject bodyBack;

	public GameObject bodyFrontBone;

	public GameObject bodyBackBone;

	public Renderer bodyRenderer;

	public GameObject collisionHelperFront;

	public GameObject collisionHelperBack;

	public GameObject collisionHelperBodyFront;

	public GameObject collisionHelperBodyBack;

	public GameObject frontLeftLeg;

	public GameObject frontRightLeg;

	public GameObject backLeftLeg;

	public GameObject backRightLeg;

	public GameObject tail;

	public GameObject leftWing;

	public GameObject rightWing;

	public GameObject legMeshHolder;

	private List<GameObject> leftLegs = new List<GameObject>();

	private List<GameObject> rightLegs = new List<GameObject>();

	private List<GameObject> allLegs = new List<GameObject>();

	private float currentGhostlyAlpha;

	private float ghostlyAlphaDecayRate = 1f;

	private float ghostlyAlphaAttackRate = 3f;

	private List<Material> ghostMats = new List<Material>();

	private List<Color> originalGhostMatEmissionColors = new List<Color>();

	private List<Renderer> lateGhostRenderers = new List<Renderer>();

	private Dictionary<Renderer, Material> lateGhostMaterialAssignments = new Dictionary<Renderer, Material>();

	public SaveableDogGene dogGene;

	private bool needsInitialMutation;

	private float defaultColorMax = 1f;

	private float defaultEmissionColorMax = 0.95f;

	private Material defaultBodyMaterial;

	private Material defaultBodyPatternMat;

	private float bodyMatMetallicMin;

	private float bodyMatMetallicMax = 0.95f;

	private float bodyMatGlossMin;

	private float bodyMatGlossMax = 0.95f;

	public Material defaultLegMaterial;

	private float legMatMetallicMin;

	private float legMatMetallicMax = 0.95f;

	private float legMatGlossMin;

	private float legMatGlossMax = 0.95f;

	private Material defaultNoseEarMaterial;

	private float noseEarMatMetallicMin;

	private float noseEarMatMetallicMax = 0.95f;

	private float noseEarMatGlossMin;

	private float noseEarMatGlossMax = 0.95f;

	private NoseType chosenNoseType;

	private LocalizedString chosenNoseName;

	private EarType chosenEarType;

	private LocalizedString chosenEarName;

	private bool syncedCurls;

	private HornType chosenHornType;

	private string chosenHornName;

	private bool centerHorn;

	private bool traditionalHorns;

	private float chosenHornSize;

	private float hornSizeMin = 0.5f;

	private float hornSizeMax = 0.5f;

	private float headSizeMin = 0.4f;

	private float headSizeMax = 0.2f;

	private float cappedHeadSize = 0.5f;

	private float chosenHeadSize;

	private float bigHeadCutoff = 0.625f;

	private float tinyHeadCutoff = 0.25f;

	private bool hasBigHead;

	private bool hasTinyHead;

	private float headRadius = 0.25f;

	private int headNumMin = 1;

	private int headnumMax = 1;

	private int chosenHeadCount;

	private int cappedHeadNumSoftMax = 4;

	private int cappedHeadNumHardMax = 10;

	private float bodyScaleXMin = 0.75f;

	private float bodyScaleXMax = 0.75f;

	private float cappedBodyScaleX = 2f;

	private float bodyLengthMod;

	private float bodyScaleYMin = 0.5f;

	private float bodyScaleYMax = 1f;

	private float cappedBodyScaleY = 2f;

	private float bodyHeightMod;

	private float bodyScaleYZMin = 0.3f;

	private float bodyScaleYZMax = 0.3f;

	private float cappedBodyScaleYZ = 0.6f;

	private float bodyScaleZMin = 0.5f;

	private float bodyScaleZMax = 1f;

	private float cappedBodyScaleZ = 2f;

	private float bodyWidthMod;

	private float bodyHeightAdjust;

	private float tailScaleMin = 0.5f;

	private float tailScaleMax = 1.75f;

	private float cappedTailScale = 2.25f;

	private TailType chosenTailType;

	private LocalizedString chosenTailName;

	private float tailNumMin = 1f;

	private float tailNumMax = 1f;

	private float tailRadius = 0.15f;

	private int chosenTailNumber;

	private int cappedTailNumber = 4;

	private float wingScaleMin = 0.75f;

	private float wingScaleMax = 0.5f;

	private float wingNumberMin = 1f;

	private float wingNumberMax = 2f;

	private int chosenWingNumber;

	private int cappedWingNumber = 4;

	private float minWingZ = -0.35f;

	private float maxWingZ = -0.17f;

	private WingType chosenWingType;

	private string chosenWingName;

	private float defaultScaleAdd = 0.3f;

	private float legScaleXZMinFront = 0.55f;

	private float legScaleXZMaxFront = 1f;

	private float legScaleXZMaxFrontPuppy = 0.6f;

	private float legScaleXZMinBack = 0.55f;

	private float legScaleXZMaxBack = 1f;

	private float legScaleXZMaxBackPuppy = 0.6f;

	private float legScaleYMinFrontTop = 0.15f;

	private float legScaleYMaxFrontTop = 0.75f;

	private float legScaleYMinFrontBot = 0.25f;

	private float legScaleYMaxFrontBot = 0.75f;

	private float legScaleYMinBackTop = 0.15f;

	private float legScaleYMaxBackTop = 0.75f;

	private float legScaleYMinBackBot = 0.25f;

	private float legScaleYMaxBackBot = 0.75f;

	private float totalFrontLegLength;

	private float totalBackLegLength;

	private float stanceWidthMin = 1f;

	private float stanceWidthMax = 1f;

	private float minLegSeparation = 0.1f;

	private float originalBodyScaleZ;

	private float legNumberMin = 1f;

	private float legNumberMax = 2f;

	private float legNumberIncreaseRate = 0.975f;

	private int frontLegPairs = 1;

	private int backLegPairs = 1;

	private int cappedLegPairs = 6;

	private int cappedLegPairsHard = 30;

	private float legEndOffset = 0.4f;

	private float legFrontOffset = 0.2f;

	private float legBackOffset = 0.2f;

	private float legPairSpace = 0.1f;

	private float backLegPosZ;

	private float frontLegPosZ;

	private float backLegParentPosZ;

	private float frontLegParentPosZ;

	private PatternType chosenPatternType;

	private float textureAlphaMin;

	private float textureAlphaMax = 1f;

	private float textureMetallicMin;

	private float textureMetallicMax = 0.75f;

	private float textureSmoothnessMin;

	private float textureSmoothnessMax = 0.75f;

	private int patternNumMin;

	private int patternNumMax = 25;

	private float splotchSizeMin;

	private float splotchSizeMax = 100f;

	private float splotchChance10 = 5f;

	private float splotchChance64 = 85f;

	private float splotchChance128 = 99f;

	private float stripeInfoSize = 100f;

	private float puppyBodyModX = -0.1f;

	private float puppyBodyModYZ = 0.1f;

	private float puppyLegModY = -0.2f;

	private float puppyLegModXZ = 0.2f;

	private float puppyTailModXYZ = 0.5f;

	private float puppyHeadSize;

	private Vector3 dogScale = new Vector3(1f, 1f, 1f);

	private Vector3 puppyScale = new Vector3(0.5f, 0.5f, 0.5f);

	private float dogScaleGlobalMin = 0.5f;

	private float dogScaleGlobalMax = 0.5f;

	private float cappedDogScaleGlobal = 0.5f;

	private float globalScaleMod;

	private Vector3 bodyFrontMov = Vector3.zero;

	private Vector3 bodyBackMov = Vector3.zero;

	private Vector3 bodySizeMod;

	private float backLegGirth = 1f;

	private float frontLegGirth = 1f;

	private Material noseEarMat;

	private Material originalNoseEarMat;

	private float noseModA;

	private float earModA;

	private float earCurlLeft;

	private float earCurlRight;

	private float snoutModRotYMin = 95f;

	private float snoutModRotYMax = 65f;

	private float snoutModLenMin = 0.25f;

	private float snoutModLenMax = 0.5f;

	private float snoutModScaleMin = 0.5f;

	private float snoutModScaleMax = 1f;

	private System.Random seededRandom;

	private bool manualGenetics;

	private bool randomGenome;

	private bool generateTextures = true;

	private bool useBaseGenomeWithoutMutation;

	private bool looksUpdated;

	private float ageRatio = 1f;

	private DoggyBrain brainRef;

	private LegController legControllerRef;

	private MasterDogGene masterDogGeneRef;

	private FaceController faceControllerRef;

	[HideInInspector]
	public TextureLoader textureLoaderRef;

	[HideInInspector]
	public ModelLoader modelLoaderRef;

	public float BodyMatEmissionColorRMin { get; private set; }

	public float BodyMatEmissionColorRMax { get; private set; }

	public float BodyMatEmissionColorGMin { get; private set; }

	public float BodyMatEmissionColorGMax { get; private set; }

	public float BodyMatEmissionColorBMin { get; private set; }

	public float BodyMatEmissionColorBMax { get; private set; }

	public float BodyMatColorRMin { get; private set; }

	public float BodyMatColorRMax { get; private set; }

	public float BodyMatColorGMin { get; private set; }

	public float BodyMatColorGMax { get; private set; }

	public float BodyMatColorBMin { get; private set; }

	public float BodyMatColorBMax { get; private set; }

	public float BodyPatternMatEmissionColorRMin { get; private set; }

	public float BodyPatternMatEmissionColorRMax { get; private set; }

	public float BodyPatternMatEmissionColorGMin { get; private set; }

	public float BodyPatternMatEmissionColorGMax { get; private set; }

	public float BodyPatternMatEmissionColorBMin { get; private set; }

	public float BodyPatternMatEmissionColorBMax { get; private set; }

	public float BodyPatternMatColorRMin { get; private set; }

	public float BodyPatternMatColorRMax { get; private set; }

	public float BodyPatternMatColorGMin { get; private set; }

	public float BodyPatternMatColorGMax { get; private set; }

	public float BodyPatternMatColorBMin { get; private set; }

	public float BodyPatternMatColorBMax { get; private set; }

	public float LegMatEmissionColorRMin { get; private set; }

	public float LegMatEmissionColorRMax { get; private set; }

	public float LegMatEmissionColorGMin { get; private set; }

	public float LegMatEmissionColorGMax { get; private set; }

	public float LegMatEmissionColorBMin { get; private set; }

	public float LegMatEmissionColorBMax { get; private set; }

	public float LegMatColorRMin { get; private set; }

	public float LegMatColorRMax { get; private set; }

	public float LegMatColorGMin { get; private set; }

	public float LegMatColorGMax { get; private set; }

	public float LegMatColorBMin { get; private set; }

	public float LegMatColorBMax { get; private set; }

	public float NoseEarMatEmissionColorRMin { get; private set; }

	public float NoseEarMatEmissionColorRMax { get; private set; }

	public float NoseEarMatEmissionColorGMin { get; private set; }

	public float NoseEarMatEmissionColorGMax { get; private set; }

	public float NoseEarMatEmissionColorBMin { get; private set; }

	public float NoseEarMatEmissionColorBMax { get; private set; }

	public float NoseEarMatColorRMin { get; private set; }

	public float NoseEarMatColorRMax { get; private set; }

	public float NoseEarMatColorGMin { get; private set; }

	public float NoseEarMatColorGMax { get; private set; }

	public float NoseEarMatColorBMin { get; private set; }

	public float NoseEarMatColorBMax { get; private set; }

	public void UnpackSavedDogInfo(SaveableDog savedDog = null)
	{
		if (savedDog != null)
		{
			dogGene = savedDog.dogGene;
		}
	}

	public void SetGenetics(SaveableDogGene newGene)
	{
		dogGene = newGene;
	}

	private void Initialize()
	{
		if (CheatEngine.cheatRef != null)
		{
			randomGenome = CheatEngine.cheatRef.randomDogGenes;
			string defaultDogGene = CheatEngine.cheatRef.defaultDogGene;
			string text = CheatEngine.cheatRef.defaultDomRecDogGene;
			if (CheatEngine.cheatRef.defaultDogGeneFull.dogGene.Length > 1)
			{
				SaveableDogGene copy = CheatEngine.cheatRef.defaultDogGeneFull.GetCopy();
				MasterDogGene.MigrateSaveableDogGene(copy);
				defaultDogGene = copy.dogGene;
				text = copy.domRecGene;
			}
			if ((defaultDogGene != null && defaultDogGene.Length > 0) || (text != null && text.Length > 0))
			{
				if (dogGene == null)
				{
					dogGene = new SaveableDogGene();
				}
				dogGene.geneVersion = MasterDogGene.currentGeneticVersion;
			}
			if (defaultDogGene != null && defaultDogGene.Length > 0)
			{
				dogGene.dogGene = defaultDogGene;
			}
			if (text != null && text.Length > 0)
			{
				dogGene.domRecGene = text;
			}
			if (CheatEngine.cheatRef.manualDogGenetics)
			{
				manualGenetics = true;
			}
		}
		leftLegs.Add(frontLeftLeg);
		leftLegs.Add(backLeftLeg);
		rightLegs.Add(frontRightLeg);
		rightLegs.Add(backRightLeg);
		allLegs.AddRange(leftLegs);
		allLegs.AddRange(rightLegs);
		legControllerRef = GetComponent<LegController>();
		faceControllerRef = GetComponent<FaceController>();
		textureLoaderRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<TextureLoader>(GlobalObject.TEXTURE_LOADER, nullAllowed: true);
		if (textureLoaderRef == null)
		{
			generateTextures = false;
		}
		modelLoaderRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ModelLoader>(GlobalObject.MODEL_LOADER, nullAllowed: true);
		SetMaterialRanges();
		masterDogGeneRef = GetComponent<MasterDogGene>();
		if (useBaseGenomeWithoutMutation)
		{
			masterDogGeneRef.MapDogGene();
		}
		else if (dogGene != null)
		{
			if (dogGene.geneVersion != MasterDogGene.currentGeneticVersion)
			{
				Debug.LogError("Something went wrong! Attempting to create a dog with an out of date gene!");
			}
			masterDogGeneRef.MapDogGene(dogGene, needsInitialMutation, randomGenome);
		}
		else
		{
			masterDogGeneRef.MapDogGene(null, mutateGene: true, randomGenome);
		}
		dogGene = masterDogGeneRef.GetSaveableDogGene(dogGene);
		brainRef = GetComponent<DoggyBrain>();
		if (brainRef != null)
		{
			ageRatio = brainRef.GetDogAgeRatio();
		}
	}

	public void UseUnmutatedBaseGenome()
	{
		useBaseGenomeWithoutMutation = true;
	}

	public int GetLoopCountForGene(string key)
	{
		int result = 0;
		Debug.LogError("No loop count info found for key: " + key);
		return result;
	}

	public IEnumerator CreateDog(bool ghost)
	{
		isGhost = ghost;
		Initialize();
		if (!isDummy)
		{
			yield return StartCoroutine(UpdateLooks());
		}
	}

	public int GetTailNumber()
	{
		return chosenTailNumber;
	}

	public int GetWingNumber()
	{
		return chosenWingNumber;
	}

	public int GetHeadCount()
	{
		return chosenHeadCount;
	}

	public float GetHeadSize()
	{
		return chosenHeadSize;
	}

	public bool HasBigHead()
	{
		return hasBigHead;
	}

	public bool HasTinyHead()
	{
		return hasTinyHead;
	}

	public int GetFrontLegPairCount()
	{
		return frontLegPairs;
	}

	public int GetBackLegPairCount()
	{
		return backLegPairs;
	}

	public TailType GetTailType()
	{
		return chosenTailType;
	}

	public LocalizedString GetTailName()
	{
		return chosenTailName;
	}

	public WingType GetWingType()
	{
		return chosenWingType;
	}

	public string GetWingName()
	{
		return chosenWingName;
	}

	public NoseType GetNoseType()
	{
		return chosenNoseType;
	}

	public LocalizedString GetNoseName()
	{
		return chosenNoseName;
	}

	public EarType GetEarType()
	{
		return chosenEarType;
	}

	public LocalizedString GetEarName()
	{
		return chosenEarName;
	}

	public string GetSyncedCurlString()
	{
		if (syncedCurls)
		{
			return ScriptLocalization.Genetics.DOMREC_EARCURL_SYNCED;
		}
		return ScriptLocalization.Genetics.DOMREC_EARCURL_DESYNCED;
	}

	public HornType GetHornType()
	{
		return chosenHornType;
	}

	public string GetHornName()
	{
		return chosenHornName;
	}

	public string GetHornStyle()
	{
		if (centerHorn)
		{
			return ScriptLocalization.Genetics.DOMREC_HORNSTYLE_CENTER;
		}
		return ScriptLocalization.Genetics.DOMREC_PROP_STANDARD;
	}

	public PatternType GetPatternType()
	{
		return chosenPatternType;
	}

	public string GetPatternTypeString()
	{
		switch (chosenPatternType)
		{
		case PatternType.REPEATING:
			return ScriptLocalization.Genetics.DOMREC_PATTERN_REPEATING;
		case PatternType.SPLOTCHES:
			return ScriptLocalization.Genetics.DOMREC_PATTERN_SPLOTCH;
		case PatternType.STRIPES:
			return ScriptLocalization.Genetics.DOMREC_PATTERN_STRIPE;
		default:
			return ScriptLocalization.Genetics.DOMREC_MISSING_NONE;
		}
	}

	public float GetGlobalScaleMod()
	{
		return globalScaleMod;
	}

	public float GetMaxGlobalScaleMod()
	{
		return dogScaleGlobalMax;
	}

	public float GetMinGlobalScaleMod()
	{
		return dogScaleGlobalMin;
	}

	public float GetBodyHeightMod()
	{
		return bodyHeightMod;
	}

	public float GetMaxBodyHeightMod()
	{
		return bodyScaleYMax;
	}

	public float GetMinBodyHeightMod()
	{
		return bodyScaleYMin;
	}

	public float GetBodyWidthMod()
	{
		return bodyWidthMod;
	}

	public float GetMaxBodyWidthMod()
	{
		return bodyScaleZMax;
	}

	public float GetMinBodyWidthMod()
	{
		return bodyScaleZMin;
	}

	public float GetBodyLengthMod()
	{
		return bodyLengthMod;
	}

	public float GetMaxBodyLengthMod()
	{
		return bodyScaleXMax;
	}

	public float GetMinBodyLengthMod()
	{
		return bodyScaleXMin;
	}

	public float GetCombinedLegLength()
	{
		return totalBackLegLength + totalFrontLegLength;
	}

	public float GetMaxCombinedLegLength()
	{
		return legScaleYMaxBackBot + legScaleYMaxBackTop + legScaleYMaxFrontBot + legScaleYMaxFrontTop;
	}

	public float GetMaxHeadSize()
	{
		return headSizeMax;
	}

	public float GetMinHeadSize()
	{
		return headSizeMin;
	}

	public Material GetDefaultBodyMaterial()
	{
		return defaultBodyMaterial;
	}

	public Material GetDefaultLegMaterial()
	{
		return defaultLegMaterial;
	}

	public Material GetDefaultNoseEarMaterial()
	{
		return defaultNoseEarMaterial;
	}

	public Material GetBodyMainMaterial()
	{
		if (!looksUpdated)
		{
			return null;
		}
		return bodyRenderer.materials[0];
	}

	public Material GetDefaultBodyPatternMaterial()
	{
		return defaultBodyPatternMat;
	}

	public Material GetBodyPatternMaterial()
	{
		if (!looksUpdated || bodyRenderer.materials.Length <= 2)
		{
			return null;
		}
		return bodyRenderer.materials[1];
	}

	public Material GetLegMaterial()
	{
		if (!looksUpdated || legMeshHolder == null)
		{
			return null;
		}
		Renderer renderer = legMeshHolder.GetComponentInChildren<Renderer>();
		if (renderer == null)
		{
			renderer = face.GetComponent<Renderer>();
			if (useOldHead)
			{
				renderer = oldFace.GetComponent<Renderer>();
			}
		}
		return renderer.material;
	}

	public Material GetNoseEarMaterial()
	{
		if (!looksUpdated)
		{
			return null;
		}
		return noseEarMat;
	}

	public Texture GetBodyPatternTexture()
	{
		if (bodyRenderer.materials.Length > 2)
		{
			return bodyRenderer.materials[1].mainTexture;
		}
		return null;
	}

	public float GetBodyPatternTextureAlpha()
	{
		if (bodyRenderer.materials.Length > 2)
		{
			return bodyRenderer.materials[1].color.a;
		}
		return 1f;
	}

	public float GetBodyPatternTextureMetallic()
	{
		if (bodyRenderer.materials.Length > 2)
		{
			return bodyRenderer.materials[1].GetFloat("_Metallic");
		}
		return 1f;
	}

	public float GetBodyPatternTextureSmoothness()
	{
		if (bodyRenderer.materials.Length > 2)
		{
			return bodyRenderer.materials[1].GetFloat("_Glossiness");
		}
		return 1f;
	}

	public Color GetBodyPatternColor()
	{
		if (bodyRenderer.materials.Length > 2)
		{
			return bodyRenderer.materials[1].color;
		}
		return defaultBodyPatternMat.color;
	}

	public Color GetBodyPatternEmissionColor()
	{
		if (bodyRenderer.materials.Length > 2)
		{
			return bodyRenderer.materials[1].GetColor("_EmissionColor");
		}
		return defaultBodyPatternMat.GetColor("_EmissionColor");
	}

	public Color GetNoseEarsColor()
	{
		Renderer renderer;
		if (useOldHead)
		{
			if (oldNose == null)
			{
				Debug.LogError("No nose found.");
				return Color.white;
			}
			renderer = oldNose.GetComponent<Renderer>();
		}
		else
		{
			if (nose == null)
			{
				Debug.LogError("No nose found.");
				return Color.white;
			}
			renderer = nose.GetComponentInChildren<Renderer>();
		}
		if (renderer == null)
		{
			Debug.LogError("No nose renderer found.");
			return Color.white;
		}
		return renderer.material.color;
	}

	public Vector3 GetBodySizeMod()
	{
		return bodySizeMod;
	}

	public float GetFrontLegGirth()
	{
		return frontLegGirth;
	}

	public float GetBackLegGirth()
	{
		return backLegGirth;
	}

	public void ApplyBodyPatternTexture(Texture newTexture, float newTextureAlpha, float newTextureMetallic, float newTextureSmoothness, Color emissionColor)
	{
		if (newTexture == null)
		{
			bodyRenderer.materials = new Material[2]
			{
				bodyRenderer.materials[0],
				bodyRenderer.materials[2]
			};
			return;
		}
		Material material = bodyRenderer.materials[1];
		material.mainTexture = newTexture;
		material.SetColor("_EmissionColor", emissionColor);
		material.color = new Color(1f, 1f, 1f, newTextureAlpha);
		float num = material.GetFloat("_Metallic");
		material.SetFloat("_Metallic", newTextureMetallic + num);
		num = material.GetFloat("_Glossiness");
		material.SetFloat("_Glossiness", newTextureSmoothness + num);
		bodyRenderer.materials[1] = material;
	}

	private int GetSeededRandomValue(int startingValue, int min, int max)
	{
		int num = seededRandom.Next(min, max + 1);
		num = (num + startingValue) % (max + 1);
		if (num < min || num > max)
		{
			Debug.LogError("Invalid random value,");
		}
		return num;
	}

	private float GetSeededRandomValue(float startingValue, float min, float max)
	{
		float num = Mathf.Clamp(seededRandom.Next(Mathf.RoundToInt(min), Mathf.RoundToInt(max) + 1), min, max);
		num = Mathf.Clamp((num + startingValue) % (max + 0.1f), min, max);
		if (num < min || num > max)
		{
			Debug.LogError("Invalid random value,");
		}
		return num;
	}

	private void SetMaterialRanges()
	{
		defaultBodyMaterial = new Material(bodyRenderer.material);
		defaultBodyPatternMat = new Material(bodyRenderer.materials[1]);
		defaultNoseEarMaterial = new Material(nose.GetComponentInChildren<Renderer>().material);
		bodyMatMetallicMin = defaultBodyMaterial.GetFloat("_Metallic");
		bodyMatMetallicMax -= bodyMatMetallicMin;
		bodyMatGlossMin = defaultBodyMaterial.GetFloat("_Glossiness");
		bodyMatGlossMax -= bodyMatGlossMin;
		textureMetallicMin = defaultBodyPatternMat.GetFloat("_Metallic");
		textureMetallicMax -= textureMetallicMin;
		textureSmoothnessMin = defaultBodyPatternMat.GetFloat("_Glossiness");
		textureSmoothnessMax -= textureSmoothnessMin;
		Color color = defaultBodyMaterial.GetColor("_EmissionColor");
		BodyMatEmissionColorRMin = color.r;
		BodyMatEmissionColorRMax = Mathf.Max(defaultEmissionColorMax - color.r, 0f);
		BodyMatEmissionColorGMin = color.g;
		BodyMatEmissionColorGMax = Mathf.Max(defaultEmissionColorMax - color.g, 0f);
		BodyMatEmissionColorBMin = color.b;
		BodyMatEmissionColorBMax = Mathf.Max(defaultEmissionColorMax - color.b, 0f);
		color = defaultBodyMaterial.color;
		BodyMatColorRMin = color.r;
		BodyMatColorRMax = Mathf.Max(defaultColorMax - color.r, 0f);
		BodyMatColorGMin = color.g;
		BodyMatColorGMax = Mathf.Max(defaultColorMax - color.g, 0f);
		BodyMatColorBMin = color.b;
		BodyMatColorBMax = Mathf.Max(defaultColorMax - color.b, 0f);
		color = defaultBodyPatternMat.GetColor("_EmissionColor");
		BodyPatternMatEmissionColorRMin = color.r;
		BodyPatternMatEmissionColorRMax = Mathf.Max(defaultEmissionColorMax - color.r, 0f);
		BodyPatternMatEmissionColorGMin = color.g;
		BodyPatternMatEmissionColorGMax = Mathf.Max(defaultEmissionColorMax - color.g, 0f);
		BodyPatternMatEmissionColorBMin = color.b;
		BodyPatternMatEmissionColorBMax = Mathf.Max(defaultEmissionColorMax - color.b, 0f);
		color = defaultBodyPatternMat.color;
		BodyPatternMatColorRMin = color.r;
		BodyPatternMatColorRMax = Mathf.Max(defaultColorMax - color.r, 0f);
		BodyPatternMatColorGMin = color.g;
		BodyPatternMatColorGMax = Mathf.Max(defaultColorMax - color.g, 0f);
		BodyPatternMatColorBMin = color.b;
		BodyPatternMatColorBMax = Mathf.Max(defaultColorMax - color.b, 0f);
		legMatMetallicMin = defaultLegMaterial.GetFloat("_Metallic");
		legMatMetallicMax -= legMatMetallicMin;
		legMatGlossMin = defaultLegMaterial.GetFloat("_Glossiness");
		legMatGlossMax -= legMatGlossMin;
		color = defaultLegMaterial.GetColor("_EmissionColor");
		LegMatEmissionColorRMin = color.r;
		LegMatEmissionColorRMax = Mathf.Max(defaultEmissionColorMax - color.r, 0f);
		LegMatEmissionColorGMin = color.g;
		LegMatEmissionColorGMax = Mathf.Max(defaultEmissionColorMax - color.g, 0f);
		LegMatEmissionColorBMin = color.b;
		LegMatEmissionColorBMax = Mathf.Max(defaultEmissionColorMax - color.b, 0f);
		color = defaultLegMaterial.color;
		LegMatColorRMin = color.r;
		LegMatColorRMax = Mathf.Max(defaultColorMax - color.r, 0f);
		LegMatColorGMin = color.g;
		LegMatColorGMax = Mathf.Max(defaultColorMax - color.g, 0f);
		LegMatColorBMin = color.b;
		LegMatColorBMax = Mathf.Max(defaultColorMax - color.b, 0f);
		noseEarMatMetallicMin = defaultNoseEarMaterial.GetFloat("_Metallic");
		noseEarMatMetallicMax -= noseEarMatMetallicMin;
		noseEarMatGlossMin = defaultNoseEarMaterial.GetFloat("_Glossiness");
		noseEarMatGlossMax -= noseEarMatGlossMin;
		color = defaultNoseEarMaterial.GetColor("_EmissionColor");
		NoseEarMatEmissionColorRMin = color.r;
		NoseEarMatEmissionColorRMax = Mathf.Max(defaultEmissionColorMax - color.r, 0f);
		NoseEarMatEmissionColorGMin = color.g;
		NoseEarMatEmissionColorGMax = Mathf.Max(defaultEmissionColorMax - color.g, 0f);
		NoseEarMatEmissionColorBMin = color.b;
		NoseEarMatEmissionColorBMax = Mathf.Max(defaultEmissionColorMax - color.b, 0f);
		color = defaultNoseEarMaterial.color;
		NoseEarMatColorRMin = color.r;
		NoseEarMatColorRMax = Mathf.Max(defaultColorMax - color.r, 0f);
		NoseEarMatColorGMin = color.g;
		NoseEarMatColorGMax = Mathf.Max(defaultColorMax - color.g, 0f);
		NoseEarMatColorBMin = color.b;
		NoseEarMatColorBMax = Mathf.Max(defaultColorMax - color.b, 0f);
	}

	private float GetAgeRatioModifiedValue(float puppyValue, float adultValue = 0f, DogAge overrideAge = DogAge.NONE)
	{
		float dogAgeRatio = ageRatio;
		if (overrideAge != DogAge.NONE)
		{
			dogAgeRatio = brainRef.GetDogAgeRatio(overrideAge);
		}
		if (puppyValue < adultValue)
		{
			return MathUtil.GetValueOfRangePercentage(dogAgeRatio, puppyValue, adultValue);
		}
		return MathUtil.GetValueOfRangePercentage(1f - dogAgeRatio, adultValue, puppyValue);
	}

	public IEnumerator UpdateLooks()
	{
		useOldHead = masterDogGeneRef.ShouldDogUseOldHead();
		if (useOldHead)
		{
			oldFaceHolder.SetActive(value: true);
			faceControllerRef.SetUseOldHead();
			UnityEngine.Object.Destroy(faceHolder);
		}
		else
		{
			UnityEngine.Object.Destroy(oldFaceHolder);
		}
		UpdateDogScale();
		Rigidbody[] componentsInChildren = GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody obj in componentsInChildren)
		{
			obj.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
			obj.isKinematic = true;
		}
		componentsInChildren = legMeshHolder.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody obj2 in componentsInChildren)
		{
			obj2.isKinematic = false;
			obj2.collisionDetectionMode = CollisionDetectionMode.Continuous;
		}
		int seed = (int)masterDogGeneRef.GetRandomSeedFloat();
		seededRandom = new System.Random(seed);
		Vector3 bodyScale = bodyFront.transform.localScale;
		Vector3 faceScale = faceHolder.transform.lossyScale;
		if (useOldHead)
		{
			faceScale = oldFaceHolder.transform.lossyScale;
		}
		Transform collisionHelperBackParent = collisionHelperBack.transform.parent;
		Transform collisionHelperFrontParent = collisionHelperFront.transform.parent;
		Transform collisionHelperBodyBackParent = collisionHelperBodyBack.transform.parent;
		Transform collisionHelperBodyFrontParent = collisionHelperBodyFront.transform.parent;
		Vector3 collisionHelperBackOff = collisionHelperBack.transform.position - bodyBack.transform.position;
		Vector3 collisionHelperFrontOff = collisionHelperFront.transform.position - bodyFront.transform.position;
		Vector3 collisionHelperBodyBackOff = collisionHelperBodyBack.transform.position - bodyBack.transform.position;
		Vector3 collisionHelperBodyFrontOff = collisionHelperBodyFront.transform.position - bodyFront.transform.position;
		collisionHelperBack.transform.SetParent(null);
		collisionHelperFront.transform.SetParent(null);
		collisionHelperBodyBack.transform.SetParent(null);
		collisionHelperBodyFront.transform.SetParent(null);
		UpdateBodyMaterial();
		UpdateLegMaterial();
		UpdateNoseEarMaterial();
		UpdateBodySize();
		UpdateWingSize();
		UpdateTailSize();
		UpdateNose();
		UpdateEars();
		UpdateHorns();
		UpdateLegNumber();
		yield return StartCoroutine(UpdateLegSize());
		UpdateFace(faceScale, bodyScale);
		collisionHelperBackOff -= Vector3.up * (bodyHeightAdjust / 2f);
		collisionHelperFrontOff -= Vector3.up * (bodyHeightAdjust / 2f);
		collisionHelperBack.transform.position = bodyBack.transform.position + collisionHelperBackOff;
		collisionHelperFront.transform.position = bodyFront.transform.position + collisionHelperFrontOff;
		collisionHelperBodyBack.transform.position = bodyBack.transform.position + collisionHelperBodyBackOff;
		collisionHelperBodyFront.transform.position = bodyFront.transform.position + collisionHelperBodyFrontOff;
		collisionHelperBack.transform.SetParent(collisionHelperBackParent);
		collisionHelperFront.transform.SetParent(collisionHelperFrontParent);
		collisionHelperBodyBack.transform.SetParent(collisionHelperBodyBackParent);
		collisionHelperBodyFront.transform.SetParent(collisionHelperBodyFrontParent);
		faceControllerRef.UpdateHeadCollisions();
		looksUpdated = true;
		if (isGhost)
		{
			yield return new WaitForEndOfFrame();
			for (int j = 0; j < lateGhostRenderers.Count; j++)
			{
				lateGhostRenderers[j].material = lateGhostMaterialAssignments[lateGhostRenderers[j]];
				ghostMats.Add(lateGhostRenderers[j].material);
				originalGhostMatEmissionColors.Add(lateGhostRenderers[j].material.GetColor("_EmissionColor"));
			}
			GhostlyAlphaColorShift(0f);
			lateGhostRenderers.Clear();
			lateGhostMaterialAssignments.Clear();
		}
		componentsInChildren = GetComponentsInChildren<Rigidbody>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].isKinematic = false;
		}
		GetComponent<BoundingBoxComponent>().ClearColliderCache();
	}

	public void RequestGhostlyColorShift(float a)
	{
		if (isGhost && !(a <= currentGhostlyAlpha))
		{
			a = Mathf.Min(a, currentGhostlyAlpha + ghostlyAlphaAttackRate * Time.deltaTime);
			GhostlyAlphaColorShift(a);
		}
	}

	private void GhostlyAlphaColorShift(float a)
	{
		if (isGhost)
		{
			if (a < 0f)
			{
				a = 0f;
			}
			for (int i = 0; i < ghostMats.Count; i++)
			{
				ghostMats[i].color = new Color(ghostMats[i].color.r, ghostMats[i].color.g, ghostMats[i].color.b, a);
				Color value = Color.Lerp(originalGhostMatEmissionColors[i], Color.black, 1f - a);
				ghostMats[i].SetColor("_EmissionColor", value);
			}
			currentGhostlyAlpha = a;
		}
	}

	private void Update()
	{
		if (isGhost && !(currentGhostlyAlpha <= 0f))
		{
			GhostlyAlphaColorShift(currentGhostlyAlpha - ghostlyAlphaDecayRate * Time.deltaTime);
		}
	}

	private void UpdateBodyMaterial()
	{
		Material material = bodyRenderer.GetComponent<Renderer>().material;
		if (isGhost)
		{
			material = new Material(ghostBodyMat);
		}
		float num = material.GetFloat("_Metallic");
		float num2 = 0f - GetFloatFromGene(GeneticProperty.BodyMetallicMinus, 0f, bodyMatMetallicMin) + GetFloatFromGene(GeneticProperty.BodyMetallicPlus, 0f, bodyMatMetallicMax);
		material.SetFloat("_Metallic", num2 + num);
		num = material.GetFloat("_Glossiness");
		float num3 = 0f - GetFloatFromGene(GeneticProperty.BodyGlossMinus, 0f, bodyMatGlossMin) + GetFloatFromGene(GeneticProperty.BodyGlossPlus, 0f, bodyMatGlossMax);
		material.SetFloat("_Glossiness", num3 + num);
		Color color = material.GetColor("_EmissionColor");
		float num4 = 0f - GetFloatFromGene(GeneticProperty.BodyEmissionColorRMinus, 0f, BodyMatEmissionColorRMin) + GetFloatFromGene(GeneticProperty.BodyEmissionColorGPlus, 0f, BodyMatEmissionColorRMax);
		float num5 = 0f - GetFloatFromGene(GeneticProperty.BodyEmissionColorGMinus, 0f, BodyMatEmissionColorGMin) + GetFloatFromGene(GeneticProperty.BodyEmissionColorGPlus, 0f, BodyMatEmissionColorGMax);
		float num6 = 0f - GetFloatFromGene(GeneticProperty.BodyEmissionColorBMinus, 0f, BodyMatEmissionColorBMin) + GetFloatFromGene(GeneticProperty.BodyEmissionColorBPlus, 0f, BodyMatEmissionColorBMax);
		color = new Color(num4 + color.r, num5 + color.g, num6 + color.b, color.a);
		material.SetColor("_EmissionColor", color);
		color = material.color;
		float a = color.a;
		if (isGhost)
		{
			a = material.color.a;
		}
		num4 = 0f - GetFloatFromGene(GeneticProperty.BodyColorRMinus, 0f, BodyMatColorRMin) + GetFloatFromGene(GeneticProperty.BodyColorRPlus, 0f, BodyMatColorRMax);
		num5 = 0f - GetFloatFromGene(GeneticProperty.BodyColorGMinus, 0f, BodyMatColorGMin) + GetFloatFromGene(GeneticProperty.BodyColorGPlus, 0f, BodyMatColorGMax);
		num6 = 0f - GetFloatFromGene(GeneticProperty.BodyColorBMinus, 0f, BodyMatColorBMin) + GetFloatFromGene(GeneticProperty.BodyColorBPlus, 0f, BodyMatColorBMax);
		color = new Color(num4 + color.r, num5 + color.g, num6 + color.b, a);
		material.color = color;
		if (isGhost)
		{
			lateGhostRenderers.Add(bodyRenderer);
			lateGhostMaterialAssignments[bodyRenderer] = material;
		}
		else
		{
			bodyRenderer.material = material;
		}
		if (manualGenetics)
		{
			material = CheatEngine.cheatRef.cheatLooks.GetBodyMat(material);
			bodyRenderer.material = material;
			if (CheatEngine.cheatRef.cheatLooks.replaceHeadTexture)
			{
				faceControllerRef.DebugReplaceTexture(CheatEngine.cheatRef.cheatLooks.GetHeadMat(material));
			}
		}
	}

	private void UpdateLegMaterial()
	{
		Material material = defaultLegMaterial;
		float num = material.GetFloat("_Metallic");
		float value = 0f - GetFloatFromGene(GeneticProperty.LegMetallicMinus, 0f, legMatMetallicMin) + GetFloatFromGene(GeneticProperty.LegMetallicPlus, 0f, legMatMetallicMax) + num;
		num = material.GetFloat("_Glossiness");
		float value2 = 0f - GetFloatFromGene(GeneticProperty.LegGlossMinus, 0f, legMatGlossMin) + GetFloatFromGene(GeneticProperty.LegGlossPlus, 0f, legMatGlossMax) + num;
		Color color = material.GetColor("_EmissionColor");
		float num2 = 0f - GetFloatFromGene(GeneticProperty.LegEmissionColorRMinus, 0f, LegMatEmissionColorRMin) + GetFloatFromGene(GeneticProperty.LegEmissionColorRPlus, 0f, LegMatEmissionColorRMax);
		float num3 = 0f - GetFloatFromGene(GeneticProperty.LegEmissionColorGMinus, 0f, LegMatEmissionColorGMin) + GetFloatFromGene(GeneticProperty.LegEmissionColorGPlus, 0f, LegMatEmissionColorGMax);
		float num4 = 0f - GetFloatFromGene(GeneticProperty.LegEmissionColorBMinus, 0f, LegMatEmissionColorBMin) + GetFloatFromGene(GeneticProperty.LegEmissionColorBPlus, 0f, LegMatEmissionColorBMax);
		color = new Color(num2 + color.r, num3 + color.g, num4 + color.b, color.a);
		Color color2 = material.color;
		num2 = 0f - GetFloatFromGene(GeneticProperty.LegColorRMinus, 0f, LegMatColorRMin) + GetFloatFromGene(GeneticProperty.LegColorRPlus, 0f, LegMatColorRMax);
		num3 = 0f - GetFloatFromGene(GeneticProperty.LegColorGMinus, 0f, LegMatColorGMin) + GetFloatFromGene(GeneticProperty.LegColorGPlus, 0f, LegMatColorGMax);
		num4 = 0f - GetFloatFromGene(GeneticProperty.LegColorBMinus, 0f, LegMatColorBMin) + GetFloatFromGene(GeneticProperty.LegColorBPlus, 0f, LegMatColorBMax);
		color2 = new Color(num2 + color2.r, num3 + color2.g, num4 + color2.b, color2.a);
		if (manualGenetics && CheatEngine.cheatRef.cheatLooks.customLegMat)
		{
			Material legMat = CheatEngine.cheatRef.cheatLooks.GetLegMat(material);
			color2 = legMat.color;
			value2 = legMat.GetFloat("_Glossiness");
			value = legMat.GetFloat("_Metallic");
			color = legMat.GetColor("_EmissionColor");
		}
		Renderer[] componentsInChildren = legMeshHolder.GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in componentsInChildren)
		{
			renderer.materials[0].color = color2;
			renderer.materials[0].SetFloat("_Glossiness", value2);
			renderer.materials[0].SetFloat("_Metallic", value);
			renderer.materials[0].SetColor("_EmissionColor", color);
			renderer.materials[1].color = color2;
			renderer.materials[1].SetColor("_EmissionColor", color);
			if (isGhost)
			{
				renderer.enabled = false;
			}
		}
		Renderer component = face.GetComponent<Renderer>();
		if (useOldHead)
		{
			component = oldFace.GetComponent<Renderer>();
		}
		Material material2 = component.material;
		Color color3 = color2;
		if (isGhost)
		{
			material2 = new Material(ghostFaceMat);
			color3 = new Color(color3.r, color3.g, color3.b, material2.color.a);
		}
		material2.color = color3;
		material2.SetFloat("_Glossiness", value2);
		material2.SetFloat("_Metallic", value);
		material2.SetColor("_EmissionColor", color);
		if (isGhost)
		{
			lateGhostRenderers.Add(component);
			lateGhostMaterialAssignments[component] = material2;
		}
		else
		{
			component.material = material2;
		}
	}

	private void UpdateNoseEarMaterial()
	{
		Renderer renderer = nose.GetComponentInChildren<Renderer>();
		if (useOldHead)
		{
			renderer = oldNose.GetComponent<Renderer>();
		}
		noseEarMat = renderer.material;
		originalNoseEarMat = noseEarMat;
		if (isGhost)
		{
			noseEarMat = new Material(ghostNoseEarsMat);
		}
		float num = noseEarMat.GetFloat("_Metallic");
		float num2 = 0f - GetFloatFromGene(GeneticProperty.NoseEarMetallicMinus, 0f, noseEarMatMetallicMin) + GetFloatFromGene(GeneticProperty.NoseEarMetallicPlus, 0f, noseEarMatMetallicMax);
		noseEarMat.SetFloat("_Metallic", num2 + num);
		num = noseEarMat.GetFloat("_Glossiness");
		float num3 = 0f - GetFloatFromGene(GeneticProperty.NoseEarGlossMinus, 0f, noseEarMatGlossMin) + GetFloatFromGene(GeneticProperty.NoseEarGlossPlus, 0f, noseEarMatGlossMax);
		noseEarMat.SetFloat("_Glossiness", num3 + num);
		Color color = noseEarMat.GetColor("_EmissionColor");
		float num4 = 0f - GetFloatFromGene(GeneticProperty.NoseEarEmissionColorRMinus, 0f, NoseEarMatEmissionColorRMin) + GetFloatFromGene(GeneticProperty.NoseEarEmissionColorRPlus, 0f, NoseEarMatEmissionColorRMax);
		float num5 = 0f - GetFloatFromGene(GeneticProperty.NoseEarEmissionColorGMinus, 0f, NoseEarMatEmissionColorGMin) + GetFloatFromGene(GeneticProperty.NoseEarEmissionColorGPlus, 0f, NoseEarMatEmissionColorGMax);
		float num6 = 0f - GetFloatFromGene(GeneticProperty.NoseEarEmissionColorBMinus, 0f, NoseEarMatEmissionColorBMin) + GetFloatFromGene(GeneticProperty.NoseEarEmissionColorBPlus, 0f, NoseEarMatEmissionColorBMax);
		color = new Color(num4 + color.r, num5 + color.g, num6 + color.b, color.a);
		noseEarMat.SetColor("_EmissionColor", color);
		color = noseEarMat.color;
		num4 = 0f - GetFloatFromGene(GeneticProperty.NoseEarColorRMinus, 0f, NoseEarMatColorRMin) + GetFloatFromGene(GeneticProperty.NoseEarColorRPlus, 0f, NoseEarMatColorRMax);
		num5 = 0f - GetFloatFromGene(GeneticProperty.NoseEarColorGMinus, 0f, NoseEarMatColorGMin) + GetFloatFromGene(GeneticProperty.NoseEarColorGPlus, 0f, NoseEarMatColorGMax);
		num6 = 0f - GetFloatFromGene(GeneticProperty.NoseEarColorBMinus, 0f, NoseEarMatColorBMin) + GetFloatFromGene(GeneticProperty.NoseEarColorBPlus, 0f, NoseEarMatColorBMax);
		color = new Color(num4 + color.r, num5 + color.g, num6 + color.b, color.a);
		noseEarMat.color = color;
		if (manualGenetics)
		{
			noseEarMat = CheatEngine.cheatRef.cheatLooks.GetNoseEarMat(noseEarMat);
		}
	}

	public int GetSplotchWidthFromFloat(float f)
	{
		if (f <= splotchChance10)
		{
			return 10;
		}
		if (f <= splotchChance64)
		{
			return 64;
		}
		if (f <= splotchChance128)
		{
			return 128;
		}
		return 256;
	}

	private int GetNumVariationsForSplotchSize(int size)
	{
		switch (size)
		{
		case 10:
			return textureLoaderRef.spots_10x10.Count;
		case 64:
			return textureLoaderRef.spots_64x64.Count;
		case 128:
			return textureLoaderRef.spots_128x128.Count;
		case 256:
			return textureLoaderRef.spots_256x256.Count;
		default:
			Debug.LogError("Invalid size: " + size);
			return 0;
		}
	}

	public Direction GetDirectionForFloat(float f)
	{
		if (f <= 33f)
		{
			return Direction.LEFT;
		}
		if (f <= 66f)
		{
			return Direction.MIDDLE;
		}
		return Direction.RIGHT;
	}

	private PatternType FindPatternType()
	{
		PatternType result = PatternType.NONE;
		bool domRecPropertyStatus = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.NO_PATTERN);
		bool domRecPropertyStatus2 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.STRIPE_PATTERN);
		bool domRecPropertyStatus3 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.SPLOTCH_PATTERN);
		bool domRecPropertyStatus4 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.REPEATING_PATTERN);
		if (domRecPropertyStatus)
		{
			result = PatternType.NONE;
		}
		else if (domRecPropertyStatus3)
		{
			result = PatternType.SPLOTCHES;
		}
		else if (domRecPropertyStatus2)
		{
			result = PatternType.STRIPES;
		}
		else if (domRecPropertyStatus4)
		{
			result = PatternType.REPEATING;
		}
		return result;
	}

	private int GetNumSizesForRepeatingType(int type)
	{
		switch (type)
		{
		case 0:
			return 1;
		case 1:
			return 2;
		case 2:
			return 1;
		case 3:
			return 2;
		case 4:
			return 1;
		default:
			Debug.LogError("Invalid type.");
			return 1;
		}
	}

	private int GetSizeForRepeatingSizeFloat(int sizeFloat)
	{
		switch (sizeFloat)
		{
		case 0:
			return 64;
		case 1:
			return 128;
		default:
			Debug.LogError("Invalid sizefloat.");
			return 64;
		}
	}

	public List<Texture2D> GetRefListForRepeatingTypeAndSize(int type, int size)
	{
		switch (type)
		{
		case 0:
			if (size == 64)
			{
				return textureLoaderRef.repeatingSpots_64x64;
			}
			break;
		case 1:
			switch (size)
			{
			case 64:
				return textureLoaderRef.repeatingLeapords_64x64;
			case 128:
				return textureLoaderRef.repeatingLeapords_128x128;
			}
			break;
		case 2:
			if (size == 64)
			{
				return textureLoaderRef.repeatingHearts_64x64;
			}
			break;
		case 3:
			switch (size)
			{
			case 64:
				return textureLoaderRef.repeating90s_64x64;
			case 128:
				return textureLoaderRef.repeating90s_128x128;
			}
			break;
		case 4:
			if (size == 64)
			{
				return textureLoaderRef.repeatingCircles_64x64;
			}
			break;
		}
		Debug.LogError("No valid type and size combination found for: " + type + " " + size);
		return textureLoaderRef.repeatingSpots_64x64;
	}

	private List<PatternInfoField> FillPatternInfo()
	{
		List<PatternInfoField> list = new List<PatternInfoField>();
		for (int i = 0; i < patternNumMax; i++)
		{
			list.Add(new PatternInfoField
			{
				splotchInfo = GenerateSplotchInfo(),
				stripeInfo = GenerateStripeInfo(),
				repeatingPatternInfo = GenerateRepeatingInfo(i)
			});
		}
		return list;
	}

	private SplotchInfoField GenerateSplotchInfo()
	{
		SplotchInfoField result = default(SplotchInfoField);
		result.a = GetSeededRandomValue(GetIntFromGene(GeneticProperty.PatternFlipX, 0f, 1f), 0, 1);
		result.b = GetSeededRandomValue(GetIntFromGene(GeneticProperty.PatternFlipY, 0f, 1f), 0, 1);
		result.c = GetFloatFromGene(GeneticProperty.PatternInfo, splotchSizeMin, splotchSizeMax);
		result.c = GetSplotchWidthFromFloat(GetSeededRandomValue(result.c, splotchSizeMin, splotchSizeMax));
		result.d = GetSeededRandomValue(GetFloatFromGene(GeneticProperty.PatternInfo, 0f, 100f), 0f, 100f);
		result.e = GetSeededRandomValue(GetFloatFromGene(GeneticProperty.PatternInfo, 0f, 100f), 0f, 100f) / 100f;
		result.f = GetSeededRandomValue(GetFloatFromGene(GeneticProperty.PatternInfo, 0f, 100f), 0f, 100f) / 100f;
		return result;
	}

	private StripeInfoField GenerateStripeInfo()
	{
		StripeInfoField result = new StripeInfoField
		{
			c = GetSeededRandomValue(GetFloatFromGene(GeneticProperty.PatternInfo, 0f, stripeInfoSize), 0f, stripeInfoSize),
			d = GetSeededRandomValue(GetFloatFromGene(GeneticProperty.PatternInfo, 0f, stripeInfoSize), 0f, stripeInfoSize),
			e = GetSeededRandomValue(GetFloatFromGene(GeneticProperty.PatternInfo, 0f, stripeInfoSize), 0f, stripeInfoSize)
		};
		int num = 1;
		if (generateTextures)
		{
			num = textureLoaderRef.stripeCaps_TopLeft.Count - 1;
		}
		result.f = GetSeededRandomValue(GetIntFromGene(GeneticProperty.PatternInfo, 0f, num), 0, num);
		return result;
	}

	private RepeatingPatternInfoField GenerateRepeatingInfo(int loop)
	{
		RepeatingPatternInfoField result = new RepeatingPatternInfoField
		{
			a = GetSeededRandomValue(GetIntFromGene(GeneticProperty.PatternFlipX, 0f, 1f), 0, 1),
			b = GetSeededRandomValue(GetIntFromGene(GeneticProperty.PatternFlipY, 0f, 1f), 0, 1)
		};
		if (loop == 0 && generateTextures)
		{
			int intFromGene = GetIntFromGene(GeneticProperty.PatternInfo, 0f, textureLoaderRef.GetNumRepeatingTypes() - 1);
			intFromGene = GetSeededRandomValue(intFromGene, 0, textureLoaderRef.GetNumRepeatingTypes() - 1);
			result.c = intFromGene;
			int intFromGene2 = GetIntFromGene(GeneticProperty.PatternInfo, 0f, GetNumSizesForRepeatingType(intFromGene) - 1);
			intFromGene2 = GetSizeForRepeatingSizeFloat(GetSeededRandomValue(intFromGene2, 0, GetNumSizesForRepeatingType(intFromGene) - 1));
			result.d = intFromGene2;
		}
		else
		{
			result.c = GetSeededRandomValue(GetIntFromGene(GeneticProperty.PatternInfo, 0f, 100f), 0, 100);
			result.d = GetSeededRandomValue(GetIntFromGene(GeneticProperty.PatternInfo, 0f, 100f), 0, 100);
		}
		result.e = GetSeededRandomValue(GetIntFromGene(GeneticProperty.PatternInfo, 0f, 100f), 0, 100);
		result.f = GetSeededRandomValue(GetIntFromGene(GeneticProperty.PatternInfo, 0f, 100f), 0, 100);
		return result;
	}

	private void ChooseTailType()
	{
		bool domRecPropertyStatus = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.NO_TAIL);
		bool domRecPropertyStatus2 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.THIN_TAIL);
		bool domRecPropertyStatus3 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.NUB_TAIL);
		bool domRecPropertyStatus4 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.FLAT_TAIL);
		bool domRecPropertyStatus5 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.STIFF_TAIL);
		bool domRecPropertyStatus6 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.BULBOUS_TAIL);
		bool domRecPropertyStatus7 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.TAIL_3D);
		bool domRecPropertyStatus8 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.REPEATED_TAIL);
		bool domRecPropertyStatus9 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.CURLED_TAIL);
		bool domRecPropertyStatus10 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.SLIGHTLY_CURLED_TAIL);
		if (domRecPropertyStatus)
		{
			chosenTailType = TailType.NO_TAIL;
		}
		else if (!domRecPropertyStatus7)
		{
			if (domRecPropertyStatus5)
			{
				if (domRecPropertyStatus10)
				{
					chosenTailType = TailType.STIFF_SLIGHTLY_CURLY;
				}
				else if (domRecPropertyStatus9)
				{
					chosenTailType = TailType.STIFF_CURLY;
				}
				else
				{
					chosenTailType = TailType.STIFF;
				}
			}
			else if (domRecPropertyStatus3)
			{
				chosenTailType = TailType.NUB;
			}
			else
			{
				chosenTailType = TailType.FLOWY;
			}
		}
		else if (domRecPropertyStatus3 && domRecPropertyStatus10)
		{
			chosenTailType = TailType.LIFTED;
		}
		else if (domRecPropertyStatus2 && domRecPropertyStatus5)
		{
			chosenTailType = TailType.WHIP;
		}
		else if (domRecPropertyStatus8 && domRecPropertyStatus10)
		{
			chosenTailType = TailType.CURL;
		}
		else if (domRecPropertyStatus8 && domRecPropertyStatus9)
		{
			chosenTailType = TailType.DOUBLE_CURL;
		}
		else if (domRecPropertyStatus8 && domRecPropertyStatus4)
		{
			chosenTailType = TailType.FERAL;
		}
		else if (domRecPropertyStatus6 && domRecPropertyStatus4)
		{
			chosenTailType = TailType.TRI;
		}
		else if (domRecPropertyStatus6)
		{
			chosenTailType = TailType.BULBOUS;
		}
		else if (domRecPropertyStatus4)
		{
			chosenTailType = TailType.PADDLE;
		}
		else
		{
			chosenTailType = TailType.PLUME;
		}
	}

	private void ChooseWingType()
	{
		bool domRecPropertyStatus = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.NO_WINGS);
		bool domRecPropertyStatus2 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.ALIGNMENT_GOOD);
		bool domRecPropertyStatus3 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.ALIGNMENT_EVIL);
		bool domRecPropertyStatus4 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.WING_FEATHERS);
		bool domRecPropertyStatus5 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.WING_ISSUES);
		bool domRecPropertyStatus6 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.ALIGNMENT_NEUTRAL);
		bool flag = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_LEFT_WING);
		bool flag2 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_RIGHT_WING);
		if (!domRecPropertyStatus5)
		{
			flag = false;
			flag2 = false;
		}
		chosenWingType = WingType.NO_WINGS;
		if (domRecPropertyStatus || (flag && flag2))
		{
			chosenWingType = WingType.NO_WINGS;
		}
		else if (!domRecPropertyStatus4)
		{
			if (domRecPropertyStatus3)
			{
				chosenWingType = WingType.BAT;
			}
			else
			{
				chosenWingType = WingType.VESTIGAL;
			}
		}
		else if (domRecPropertyStatus6)
		{
			chosenWingType = WingType.PARADISE;
		}
		else if (domRecPropertyStatus2)
		{
			chosenWingType = WingType.ANGEL;
		}
		else if (domRecPropertyStatus3)
		{
			chosenWingType = WingType.VULTURE;
		}
	}

	private void ChooseNoseInfo()
	{
		bool domRecPropertyStatus = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.NOSE_FLAT);
		bool domRecPropertyStatus2 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.NOSE_SQUISH);
		bool domRecPropertyStatus3 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.NOSE_STRETCH);
		bool domRecPropertyStatus4 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.NOSE_REPEATED);
		bool domRecPropertyStatus5 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.NOSE_EXTRUSION);
		noseModA = 0f - GetFloatFromGene(GeneticProperty.NoseModAMinus, 0f, NoseModInfo.GetModAMin()) + GetFloatFromGene(GeneticProperty.NoseModAPlus, 0f, NoseModInfo.GetModAMax());
		if (manualGenetics)
		{
			noseModA = CheatEngine.cheatRef.cheatLooks.GetCustomNoseModA(noseModA);
		}
		chosenNoseType = NoseType.TYPE_A;
		if (domRecPropertyStatus5 && domRecPropertyStatus4 && domRecPropertyStatus2)
		{
			chosenNoseType = NoseType.WIDE;
		}
		else if (domRecPropertyStatus4 && domRecPropertyStatus2)
		{
			chosenNoseType = NoseType.SQUARE;
		}
		else if (domRecPropertyStatus4 && domRecPropertyStatus5)
		{
			chosenNoseType = NoseType.PUG;
		}
		else if (domRecPropertyStatus4 && domRecPropertyStatus)
		{
			chosenNoseType = NoseType.MALLOW;
		}
		else if (domRecPropertyStatus && domRecPropertyStatus3)
		{
			chosenNoseType = NoseType.TRIANGLE;
		}
		else if (domRecPropertyStatus3)
		{
			chosenNoseType = NoseType.GREYHOUND;
		}
		else if (domRecPropertyStatus5)
		{
			chosenNoseType = NoseType.BULB;
		}
		else if (domRecPropertyStatus)
		{
			chosenNoseType = NoseType.HALF_MALLOW;
		}
	}

	private void ChooseEarInfo()
	{
		bool domRecPropertyStatus = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.EAR_SHARP);
		bool domRecPropertyStatus2 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.EAR_CONIC);
		bool domRecPropertyStatus3 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.EAR_FILLED);
		bool domRecPropertyStatus4 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.EAR_FLOPPY);
		bool domRecPropertyStatus5 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.EAR_HALVED);
		bool domRecPropertyStatus6 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.TILTED_EARS);
		bool domRecPropertyStatus7 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.EAR_PARTIAL_FLOP);
		chosenEarType = EarType.SHEPHERD;
		if (domRecPropertyStatus3)
		{
			chosenEarType = EarType.TYPE_A;
			if (domRecPropertyStatus6)
			{
				chosenEarType = EarType.TYPE_B;
			}
			else if (domRecPropertyStatus5)
			{
				chosenEarType = EarType.BLUNT;
			}
		}
		else if (domRecPropertyStatus && domRecPropertyStatus2 && domRecPropertyStatus5)
		{
			chosenEarType = EarType.TWISTED;
		}
		else if (domRecPropertyStatus && domRecPropertyStatus4)
		{
			chosenEarType = EarType.BULBOUS;
		}
		else if (domRecPropertyStatus)
		{
			chosenEarType = EarType.CROSS;
		}
		else if (domRecPropertyStatus4)
		{
			chosenEarType = EarType.BENT;
		}
		else if (domRecPropertyStatus2)
		{
			chosenEarType = EarType.HORN;
		}
		else if (domRecPropertyStatus7)
		{
			chosenEarType = EarType.WAVY;
		}
		earModA = 0f - GetFloatFromGene(GeneticProperty.EarModAMinus, 0f, EarModInfo.GetModAMin(chosenEarType)) + GetFloatFromGene(GeneticProperty.EarModAPlus, 0f, EarModInfo.GetModAMax(chosenEarType));
		earCurlLeft = GetFloatFromGene(GeneticProperty.EarCurlLeft, 0f, 1f);
		earCurlRight = GetFloatFromGene(GeneticProperty.EarCurlRight, 0f, 1f);
		if (manualGenetics)
		{
			earModA = CheatEngine.cheatRef.cheatLooks.GetCustomEarModA(earModA);
		}
	}

	private void ChooseHornInfo()
	{
		bool domRecPropertyStatus = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.HORNS_CENTER);
		bool domRecPropertyStatus2 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.HORNS_TRADITIONAL);
		bool domRecPropertyStatus3 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.HORNS_NONE);
		bool domRecPropertyStatus4 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.HORNS_CURLED);
		bool domRecPropertyStatus5 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.HORNS_NUB);
		bool domRecPropertyStatus6 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.HORNS_THICK);
		bool domRecPropertyStatus7 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.HORNS_THIN);
		chosenHornSize = 0f - GetFloatFromGene(GeneticProperty.HornSizeMinus, 0f, hornSizeMin) + GetFloatFromGene(GeneticProperty.HornSizePlus, 0f, hornSizeMax);
		if (domRecPropertyStatus3)
		{
			chosenHornType = HornType.NO_HORNS;
		}
		else if (domRecPropertyStatus5)
		{
			chosenHornType = HornType.NUB;
		}
		else if (domRecPropertyStatus6)
		{
			chosenHornType = HornType.THICK;
		}
		else if (domRecPropertyStatus7)
		{
			chosenHornType = HornType.THIN;
		}
		else if (domRecPropertyStatus4)
		{
			chosenHornType = HornType.CURLED;
		}
		else
		{
			chosenHornType = HornType.NO_HORNS;
		}
		centerHorn = domRecPropertyStatus;
		traditionalHorns = domRecPropertyStatus2;
		if (!domRecPropertyStatus && !domRecPropertyStatus2)
		{
			chosenHornType = HornType.NO_HORNS;
		}
	}

	public float GetDefaultDogScale()
	{
		return dogScale.x;
	}

	public float GetMaxDogScale()
	{
		return dogScale.x + dogScale.x * dogScaleGlobalMax;
	}

	public float GetMinDogScale()
	{
		return dogScale.x - dogScale.x * dogScaleGlobalMin;
	}

	private void UpdateDogScale()
	{
		Vector3 localScale = new Vector3(GetAgeRatioModifiedValue(puppyScale.x, dogScale.x), GetAgeRatioModifiedValue(puppyScale.y, dogScale.y), GetAgeRatioModifiedValue(puppyScale.z, dogScale.z));
		base.transform.localScale = localScale;
		globalScaleMod = GetDynamicSeparatedFloatFromGene(GeneticProperty.BodyScaleGlobalPlus, 0f, dogScaleGlobalMax) - GetDynamicSeparatedFloatFromGene(GeneticProperty.BodyScaleGlobalMinus, 0f, dogScaleGlobalMin, negativeValue: true);
		if (manualGenetics)
		{
			globalScaleMod = CheatEngine.cheatRef.cheatLooks.GetBodyScaleGlobal(globalScaleMod);
		}
		if (GameSettings.AreGeneticsCapped() && globalScaleMod > cappedDogScaleGlobal)
		{
			globalScaleMod = cappedDogScaleGlobal;
		}
		base.transform.localScale += base.transform.localScale * globalScaleMod;
	}

	private void UpdateBodySize()
	{
		chosenPatternType = FindPatternType();
		List<PatternInfoField> patternInfo = FillPatternInfo();
		Color color = defaultBodyPatternMat.GetColor("_EmissionColor");
		float num = 0f - GetFloatFromGene(GeneticProperty.PatternEmissionColorRMinus, 0f, BodyMatEmissionColorRMin) + GetFloatFromGene(GeneticProperty.PatternEmissionColorRPlus, 0f, BodyMatEmissionColorRMax);
		float num2 = 0f - GetFloatFromGene(GeneticProperty.PatternEmissionColorGMinus, 0f, BodyMatEmissionColorGMin) + GetFloatFromGene(GeneticProperty.PatternEmissionColorGPlus, 0f, BodyMatEmissionColorGMax);
		float num3 = 0f - GetFloatFromGene(GeneticProperty.PatternEmissionColorBMinus, 0f, BodyMatEmissionColorBMin) + GetFloatFromGene(GeneticProperty.PatternEmissionColorBPlus, 0f, BodyMatEmissionColorBMax);
		color = new Color(num + color.r, num2 + color.g, num3 + color.b, color.a);
		Color emissionColor = color;
		num = 0f - GetFloatFromGene(GeneticProperty.PatternColorRMinus, 0f, BodyMatColorRMin) + GetFloatFromGene(GeneticProperty.PatternColorRPlus, 0f, BodyMatColorRMax);
		num2 = 0f - GetFloatFromGene(GeneticProperty.PatternColorGMinus, 0f, BodyMatColorGMin) + GetFloatFromGene(GeneticProperty.PatternColorGPlus, 0f, BodyMatColorGMax);
		num3 = 0f - GetFloatFromGene(GeneticProperty.PatternColorBMinus, 0f, BodyMatColorBMin) + GetFloatFromGene(GeneticProperty.PatternColorBPlus, 0f, BodyMatColorBMax);
		Color color2 = defaultBodyMaterial.color;
		Color textureColor = new Color(num + color2.r, num2 + color2.g, num3 + color2.b, 0f);
		float floatFromGene = GetFloatFromGene(GeneticProperty.PatternAlpha, textureAlphaMin, textureAlphaMax);
		float newTextureMetallic = 0f - GetFloatFromGene(GeneticProperty.PatternMetallicMinus, 0f, textureMetallicMin) + GetFloatFromGene(GeneticProperty.PatternMetallicPlus, 0f, textureMetallicMax);
		float newTextureSmoothness = 0f - GetFloatFromGene(GeneticProperty.PatternSmoothnessMinus, 0f, textureSmoothnessMin) + GetFloatFromGene(GeneticProperty.PatternSmoothnessPlus, 0f, textureSmoothnessMax);
		int seededRandomValue = GetSeededRandomValue((int)GetFloatFromGene(GeneticProperty.PatternNum, patternNumMin, patternNumMax), patternNumMin, patternNumMax);
		ChooseTailType();
		ChooseWingType();
		ChooseNoseInfo();
		ChooseEarInfo();
		ChooseHornInfo();
		originalBodyScaleZ = bodyFront.transform.localScale.z;
		float num4 = 0f - GetDynamicSeparatedFloatFromGene(GeneticProperty.BodyScaleXMinus, 0f, bodyScaleXMin, negativeValue: true) + GetDynamicSeparatedFloatFromGene(GeneticProperty.BodyScaleXPlus, 0f, bodyScaleXMax);
		float num5 = 0f - GetDynamicSeparatedFloatFromGene(GeneticProperty.BodyScaleYMinus, 0f, bodyScaleZMin, negativeValue: true) + GetDynamicSeparatedFloatFromGene(GeneticProperty.BodyScaleYPlus, 0f, bodyScaleZMax);
		float num6 = 0f - GetDynamicSeparatedFloatFromGene(GeneticProperty.BodyScaleZMinus, 0f, bodyScaleYMin, negativeValue: true) + GetDynamicSeparatedFloatFromGene(GeneticProperty.BodyScaleZPlus, 0f, bodyScaleYMax);
		float num7 = 0f - GetDynamicSeparatedFloatFromGene(GeneticProperty.BodyScaleYZMinus, 0f, bodyScaleYZMin, negativeValue: true) + GetDynamicSeparatedFloatFromGene(GeneticProperty.BodyScaleYZPlus, 0f, bodyScaleYZMax);
		if (manualGenetics)
		{
			num4 = CheatEngine.cheatRef.cheatLooks.GetBodyScaleX(num4);
			num5 = CheatEngine.cheatRef.cheatLooks.GetBodyScaleY(num5);
			num6 = CheatEngine.cheatRef.cheatLooks.GetBodyScaleZ(num6);
			num7 = CheatEngine.cheatRef.cheatLooks.GetBodyScaleYZ(num7);
		}
		if (GameSettings.AreGeneticsCapped())
		{
			if (num4 > cappedBodyScaleX)
			{
				num4 = cappedBodyScaleX;
			}
			if (num5 > cappedBodyScaleY)
			{
				num5 = cappedBodyScaleY;
			}
			if (num6 > cappedBodyScaleZ)
			{
				num6 = cappedBodyScaleZ;
			}
			if (num7 > cappedBodyScaleYZ)
			{
				num7 = cappedBodyScaleYZ;
			}
		}
		bodyWidthMod = num5;
		bodyHeightMod = num6;
		bodyLengthMod = num4;
		num4 = Mathf.Clamp(num4 + GetAgeRatioModifiedValue(puppyBodyModX), 0f - bodyScaleXMin, bodyScaleXMax);
		num7 = Mathf.Clamp(num7 + GetAgeRatioModifiedValue(puppyBodyModYZ), 0f - bodyScaleYZMin, bodyScaleYZMax);
		num6 += num7;
		bodyHeightAdjust = bodyFront.transform.TransformVector(new Vector3(0f, num6, 0f)).y;
		Vector3 vector = new Vector3(num4, num7 + num5, num6);
		Vector3 vector2 = new Vector3(num4 * bodyFront.transform.localScale.x, num6 * bodyFront.transform.localScale.y, (num7 + num5) * bodyFront.transform.localScale.z);
		bodySizeMod = vector;
		Vector3 localScale = bodyFrontBone.transform.localScale + new Vector3(bodyFrontBone.transform.localScale.x * vector.x, bodyFrontBone.transform.localScale.y * vector.y, bodyFrontBone.transform.localScale.z * vector.z);
		Vector3 vector3 = new Vector3(localScale.x - bodyFrontBone.transform.localScale.x, localScale.y - bodyFrontBone.transform.localScale.y, localScale.z - bodyFrontBone.transform.localScale.z);
		bodyFront.transform.localScale += vector2;
		bodyBack.transform.localScale += vector2;
		bodyFrontBone.transform.localScale = localScale;
		bodyBackBone.transform.localScale = localScale;
		bodyFrontMov = vector2.x / 2f * -bodyFront.transform.right;
		bodyBackMov = vector2.x / 2f * bodyBack.transform.right;
		bodyFront.transform.localPosition += bodyFrontMov;
		bodyBack.transform.localPosition += bodyBackMov;
		bodyFrontBone.SetActive(value: false);
		bodyBackBone.SetActive(value: false);
		bodyFront.SetActive(value: false);
		bodyFrontBone.transform.localPosition += vector3.x * bodyFrontBone.transform.up;
		bodyBackBone.SetActive(value: true);
		bodyFrontBone.SetActive(value: true);
		bodyFront.SetActive(value: true);
		Vector3 vector4 = bodyBackMov * 2f + vector2.y / 4f * bodyBack.transform.up;
		Vector3 vector5 = bodyFrontMov + vector2.y / 4f * bodyFront.transform.up;
		Vector3 vector6 = vector2.z / 4f * -bodyFront.transform.forward;
		Vector3 vector7 = vector2.y / 4f * bodyFront.transform.up;
		tail.SetActive(value: false);
		tail.transform.localPosition += vector4;
		tail.SetActive(value: true);
		vector5 *= base.transform.localScale.x;
		vector6 *= base.transform.localScale.x;
		vector7 *= base.transform.localScale.x;
		leftWing.transform.position += vector5;
		rightWing.transform.position += vector5;
		leftWing.transform.position += vector6;
		rightWing.transform.position -= vector6;
		leftWing.transform.position += vector7;
		rightWing.transform.position += vector7;
		bodyFrontMov += vector2.y / 4f * -bodyFront.transform.up;
		bodyBackMov += vector2.y / 4f * -bodyBack.transform.up;
		if (isDummy)
		{
			return;
		}
		if (chosenPatternType == PatternType.NONE)
		{
			bodyRenderer.materials = new Material[2]
			{
				bodyRenderer.materials[0],
				bodyRenderer.materials[2]
			};
			return;
		}
		float textureWidth = bodyFront.transform.localScale.x + bodyBack.transform.localScale.x;
		float textureHeight = bodyFront.transform.localScale.y + bodyFront.transform.localScale.z;
		if (generateTextures)
		{
			Texture2D newTexture = TextureGeneration.GenerateTexture(this, defaultColorMax, textureWidth, textureHeight, chosenPatternType, seededRandomValue, patternNumMax, textureColor, patternInfo);
			ApplyBodyPatternTexture(newTexture, floatFromGene, newTextureMetallic, newTextureSmoothness, emissionColor);
		}
	}

	private void IgnoreObjectCollisions(GameObject tailA, GameObject tailB)
	{
		Collider[] componentsInChildren = tailA.GetComponentsInChildren<Collider>();
		foreach (Collider collider in componentsInChildren)
		{
			Collider[] componentsInChildren2 = tailB.GetComponentsInChildren<Collider>();
			foreach (Collider collider2 in componentsInChildren2)
			{
				Physics.IgnoreCollision(collider, collider2);
			}
		}
	}

	private void UpdateTailSize()
	{
		float num = 0f - GetDynamicSeparatedFloatFromGene(GeneticProperty.TailScaleMinus, 0f, tailScaleMin, negativeValue: true) + GetDynamicSeparatedFloatFromGene(GeneticProperty.TailScalePlus, 0f, tailScaleMax);
		chosenTailNumber = GetDynamicSeparatedIntFromGene(GeneticProperty.TailNum, tailNumMin, tailNumMax);
		num += GetAgeRatioModifiedValue(puppyTailModXYZ);
		num = Mathf.Min(num, tailScaleMax / (float)chosenTailNumber);
		if (manualGenetics)
		{
			num = CheatEngine.cheatRef.cheatLooks.GetCustomTailSize(num);
			chosenTailNumber = CheatEngine.cheatRef.cheatLooks.GetCustomTailNum(chosenTailNumber);
			chosenTailType = CheatEngine.cheatRef.cheatLooks.GetCustomTailType(chosenTailType);
		}
		if (GameSettings.AreGeneticsCapped() && num > cappedTailScale)
		{
			num = cappedTailScale;
		}
		if (GameSettings.AreGeneticsCapped() && chosenTailNumber > cappedTailNumber)
		{
			chosenTailNumber = cappedTailNumber;
		}
		chosenTailName = modelLoaderRef.GetTailNameForType(chosenTailType);
		GameObject tailForType = modelLoaderRef.GetTailForType(chosenTailType);
		if (tailForType == null)
		{
			return;
		}
		Material material = new Material(bodyRenderer.materials[0]);
		Vector3 localPosition = Vector3.zero;
		List<GameObject> list = new List<GameObject>();
		for (int i = 0; i < chosenTailNumber; i++)
		{
			if (chosenTailNumber > 1)
			{
				localPosition = -tail.transform.up * tailRadius;
				localPosition -= tail.transform.up * (tailRadius * Mathf.Cos((float)i / (float)chosenTailNumber * ((float)Math.PI * 2f)));
				localPosition -= tail.transform.forward * (tailRadius * Mathf.Sin((float)i / (float)chosenTailNumber * ((float)Math.PI * 2f)));
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(tailForType);
			gameObject.transform.SetParent(tail.transform);
			gameObject.transform.localPosition = localPosition;
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.localRotation = Quaternion.identity;
			Renderer componentInChildren = gameObject.GetComponentInChildren<Renderer>();
			componentInChildren.material = material;
			if (isGhost)
			{
				lateGhostRenderers.Add(componentInChildren);
				lateGhostMaterialAssignments[componentInChildren] = lateGhostMaterialAssignments[bodyRenderer];
			}
			list.Add(gameObject);
		}
		List<Vector3> list2 = new List<Vector3>();
		Rigidbody[] componentsInChildren = tail.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rigidbody in componentsInChildren)
		{
			list2.Add(rigidbody.centerOfMass);
		}
		for (int k = 0; k < list.Count; k++)
		{
			Transform scaleTransform = list[k].GetComponent<TailController>().scaleTransform;
			scaleTransform.gameObject.SetActive(value: false);
			float num2 = scaleTransform.localScale.x + scaleTransform.localScale.x * num;
			Vector3 localScale = new Vector3(num2, num2, num2);
			scaleTransform.localScale = localScale;
			scaleTransform.gameObject.SetActive(value: true);
		}
		int num3 = 0;
		componentsInChildren = tail.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rigidbody2 in componentsInChildren)
		{
			rigidbody2.centerOfMass = list2[num3];
			rigidbody2.ResetInertiaTensor();
			num3++;
			if (isDummy)
			{
				rigidbody2.isKinematic = true;
			}
		}
		if (isDummy)
		{
			for (int l = 0; l < list.Count; l++)
			{
				GameObject gameObject2 = list[l];
				UnityEngine.Object.Destroy(gameObject2.GetComponent<TailController>());
				if (gameObject2.GetComponent<Collider>() != null)
				{
					gameObject2.GetComponent<Collider>().isTrigger = true;
				}
				Collider[] componentsInChildren2 = gameObject2.GetComponentsInChildren<Collider>();
				for (int j = 0; j < componentsInChildren2.Length; j++)
				{
					componentsInChildren2[j].isTrigger = true;
				}
			}
		}
		for (int m = 0; m <= list.Count; m++)
		{
			for (int n = m + 1; n < list.Count; n++)
			{
				IgnoreObjectCollisions(list[m], list[n]);
			}
		}
		for (int num4 = 0; num4 < list.Count; num4++)
		{
			IgnoreObjectCollisions(list[num4], leftWing);
			IgnoreObjectCollisions(list[num4], rightWing);
		}
	}

	private void UpdateWingSize()
	{
		float num = 0f - GetFloatFromGene(GeneticProperty.WingSizeMinus, 0f, wingScaleMin) + GetFloatFromGene(GeneticProperty.WingSizePlus, 0f, wingScaleMax);
		chosenWingNumber = GetDynamicSeparatedIntFromGene(GeneticProperty.WingNumber, wingNumberMin, wingNumberMax);
		if (GameSettings.AreGeneticsCapped() && chosenWingNumber > cappedWingNumber)
		{
			chosenWingNumber = cappedWingNumber;
		}
		if (chosenWingType == WingType.NO_WINGS)
		{
			chosenWingName = ScriptLocalization.Genetics.DOMREC_MISSING_NONE;
			return;
		}
		if (manualGenetics)
		{
			num = CheatEngine.cheatRef.cheatLooks.GetCustomWingSize(num);
			chosenWingNumber = CheatEngine.cheatRef.cheatLooks.GetCustomWingNum(chosenWingNumber);
			chosenWingType = CheatEngine.cheatRef.cheatLooks.GetCustomWingType(chosenWingType);
		}
		bool domRecPropertyStatus = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.WING_ISSUES);
		bool flag = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_LEFT_WING);
		bool flag2 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_RIGHT_WING);
		if (!domRecPropertyStatus)
		{
			flag = false;
			flag2 = false;
		}
		chosenWingName = modelLoaderRef.GetWingNameForType(chosenWingType);
		GameObject wingForType = modelLoaderRef.GetWingForType(chosenWingType);
		if (wingForType == null)
		{
			return;
		}
		List<GameObject> list = new List<GameObject>();
		if (!flag)
		{
			Vector3 localPosition = leftWing.transform.localPosition;
			for (int i = 0; i < chosenWingNumber; i++)
			{
				float valueOfRangePercentage = MathUtil.GetValueOfRangePercentage(((float)chosenWingNumber - (float)i) / (float)chosenWingNumber, minWingZ, maxWingZ);
				leftWing.transform.localPosition = new Vector3(leftWing.transform.localPosition.x, leftWing.transform.localPosition.y, valueOfRangePercentage);
				GameObject gameObject = UnityEngine.Object.Instantiate(wingForType);
				gameObject.transform.SetParent(leftWing.transform);
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localRotation = Quaternion.identity;
				Vector3 position = gameObject.transform.position;
				leftWing.transform.localPosition = localPosition;
				gameObject.transform.position = position;
				WingController component = gameObject.GetComponent<WingController>();
				component.SetIsLeftWing(val: true);
				component.SetTotalWingCount(chosenWingNumber, i);
				list.Add(gameObject);
			}
		}
		if (!flag2)
		{
			Vector3 localPosition2 = rightWing.transform.localPosition;
			for (int j = 0; j < chosenWingNumber; j++)
			{
				float valueOfRangePercentage2 = MathUtil.GetValueOfRangePercentage(((float)chosenWingNumber - (float)j) / (float)chosenWingNumber, minWingZ, maxWingZ);
				rightWing.transform.localPosition = new Vector3(rightWing.transform.localPosition.x, rightWing.transform.localPosition.y, 0f - valueOfRangePercentage2);
				GameObject gameObject2 = UnityEngine.Object.Instantiate(wingForType);
				gameObject2.transform.SetParent(rightWing.transform);
				gameObject2.transform.localPosition = Vector3.zero;
				gameObject2.transform.localScale = Vector3.one;
				gameObject2.transform.localRotation = Quaternion.identity;
				Vector3 position2 = gameObject2.transform.position;
				rightWing.transform.localPosition = localPosition2;
				gameObject2.transform.position = position2;
				WingController component2 = gameObject2.GetComponent<WingController>();
				component2.SetIsLeftWing(val: false);
				component2.SetTotalWingCount(chosenWingNumber, j);
				list.Add(gameObject2);
			}
		}
		Material material = new Material(list[0].GetComponentInChildren<Renderer>().material);
		material.color = bodyRenderer.materials[0].color;
		material.SetColor("_EmissionColor", bodyRenderer.materials[0].GetColor("_EmissionColor"));
		Rigidbody component3 = bodyFront.GetComponent<Rigidbody>();
		for (int k = 0; k < list.Count; k++)
		{
			Renderer componentInChildren = list[k].GetComponentInChildren<Renderer>();
			componentInChildren.material = material;
			if (isGhost)
			{
				lateGhostRenderers.Add(componentInChildren);
				lateGhostMaterialAssignments[componentInChildren] = lateGhostMaterialAssignments[bodyRenderer];
			}
			WingController component4 = list[k].GetComponent<WingController>();
			Transform scaleTransform = component4.scaleTransform;
			scaleTransform.gameObject.SetActive(value: false);
			float num2 = scaleTransform.localScale.x + scaleTransform.localScale.x * num;
			Vector3 localScale = new Vector3(num2, num2, num2);
			scaleTransform.localScale = localScale;
			scaleTransform.gameObject.SetActive(value: true);
			component4.jointDrive.connectedBody = component3;
			SetRBGravStatus(list[k], status: false);
		}
		for (int l = 0; l < list.Count; l++)
		{
			for (int m = l + 1; m < list.Count; m++)
			{
				IgnoreObjectCollisions(list[l], list[m]);
			}
		}
	}

	public void SetRBGravStatus(GameObject startingObj, bool status)
	{
		Rigidbody[] components = startingObj.GetComponents<Rigidbody>();
		foreach (Rigidbody rigidbody in components)
		{
			rigidbody.useGravity = status;
			bool flag = !status;
			if (flag)
			{
				rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
			}
			rigidbody.isKinematic = flag;
			if (!flag)
			{
				rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
			}
		}
		components = startingObj.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rigidbody2 in components)
		{
			rigidbody2.useGravity = status;
			bool flag = !status;
			if (flag)
			{
				rigidbody2.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
			}
			rigidbody2.isKinematic = !status;
			if (!flag)
			{
				rigidbody2.collisionDetectionMode = CollisionDetectionMode.Continuous;
			}
		}
	}

	private void UpdateNose()
	{
		if (manualGenetics)
		{
			chosenNoseType = CheatEngine.cheatRef.cheatLooks.GetCustomNoseType(chosenNoseType);
		}
		chosenNoseName = modelLoaderRef.GetNoseNameForType(chosenNoseType);
		if (!useOldHead)
		{
			UnityEngine.Object.Destroy(nose.transform.GetChild(0).gameObject);
			GameObject obj = UnityEngine.Object.Instantiate(modelLoaderRef.GetNoseForType(chosenNoseType));
			obj.transform.SetParent(nose.transform);
			obj.transform.localScale = Vector3.one;
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localRotation = Quaternion.identity;
			Renderer componentInChildren = obj.transform.GetComponentInChildren<Renderer>();
			if (isGhost)
			{
				componentInChildren.material = originalNoseEarMat;
				lateGhostRenderers.Add(componentInChildren);
				lateGhostMaterialAssignments[componentInChildren] = noseEarMat;
			}
			else
			{
				componentInChildren.material = noseEarMat;
			}
			NoseModInfo.ApplyModA(nose, noseModA);
		}
	}

	private void UpdateEars()
	{
		if (manualGenetics)
		{
			chosenEarType = CheatEngine.cheatRef.cheatLooks.GetCustomEarType(chosenEarType);
		}
		chosenEarName = modelLoaderRef.GetEarNameForType(chosenEarType);
		if (useOldHead)
		{
			return;
		}
		UnityEngine.Object.Destroy(ears.transform.GetChild(0).gameObject);
		GameObject gameObject = UnityEngine.Object.Instantiate(modelLoaderRef.GetEarForType(chosenEarType));
		gameObject.transform.SetParent(ears.transform);
		gameObject.transform.localScale = Vector3.one;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localRotation = Quaternion.identity;
		syncedCurls = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.EAR_CURL_SYNCED);
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			Renderer componentInChildren = gameObject.transform.GetChild(i).GetComponentInChildren<Renderer>();
			if (isGhost)
			{
				lateGhostRenderers.Add(componentInChildren);
				lateGhostMaterialAssignments[componentInChildren] = noseEarMat;
			}
			else
			{
				componentInChildren.material = noseEarMat;
			}
			gameObject.GetComponent<DogEar>().ApplyEarCurlMod(earCurlLeft, earCurlRight, syncedCurls);
		}
		EarModInfo.ApplyModA(gameObject, earModA, chosenEarType);
	}

	private void UpdateHorns()
	{
		if (chosenHornType == HornType.NO_HORNS)
		{
			chosenHornName = ScriptLocalization.Genetics.DOMREC_MISSING_NONE;
			return;
		}
		chosenHornName = modelLoaderRef.GetHornNameForType(chosenHornType);
		if (useOldHead)
		{
			return;
		}
		List<GameObject> list = new List<GameObject>();
		GameObject hornForType = modelLoaderRef.GetHornForType(chosenHornType);
		if (traditionalHorns)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(hornForType);
			GameObject gameObject2 = UnityEngine.Object.Instantiate(hornForType);
			gameObject.transform.SetParent(hornLeftHolder.transform);
			gameObject2.transform.SetParent(hornRightHolder.transform);
			list.Add(gameObject);
			list.Add(gameObject2);
		}
		else if (centerHorn)
		{
			GameObject gameObject3 = UnityEngine.Object.Instantiate(hornForType);
			gameObject3.transform.SetParent(hornCenterHolder.transform);
			list.Add(gameObject3);
		}
		for (int i = 0; i < list.Count; i++)
		{
			list[i].transform.localScale = Vector3.one + Vector3.one * chosenHornSize;
			list[i].transform.localPosition = Vector3.zero;
			list[i].transform.localRotation = Quaternion.identity;
			Renderer componentInChildren = list[i].transform.GetComponentInChildren<Renderer>();
			if (isGhost)
			{
				lateGhostRenderers.Add(componentInChildren);
				lateGhostMaterialAssignments[componentInChildren] = noseEarMat;
			}
			else
			{
				componentInChildren.material = noseEarMat;
			}
		}
	}

	private void UpdateLegNumber()
	{
		bool domRecPropertyStatus = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_FRONT_LEFT_LEG);
		bool domRecPropertyStatus2 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_FRONT_RIGHT_LEG);
		bool domRecPropertyStatus3 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_BACK_LEFT_LEG);
		bool domRecPropertyStatus4 = masterDogGeneRef.GetDomRecPropertyStatus(GeneticDomRecProperty.MISSING_BACK_RIGHT_LEG);
		backLegPosZ = backLeftLeg.transform.localPosition.z;
		frontLegPosZ = frontLeftLeg.transform.localPosition.z;
		backLegParentPosZ = backLeftLeg.transform.parent.localPosition.z;
		frontLegParentPosZ = frontLeftLeg.transform.parent.localPosition.z;
		backLegPairs = Mathf.FloorToInt(GetDynamicSeparatedFloatFromGene(GeneticProperty.LegPairsBack, legNumberMin, legNumberMax) / legNumberIncreaseRate);
		frontLegPairs = Mathf.FloorToInt(GetDynamicSeparatedFloatFromGene(GeneticProperty.LegPairsFront, legNumberMin, legNumberMax) / legNumberIncreaseRate);
		if (manualGenetics)
		{
			frontLegPairs = CheatEngine.cheatRef.cheatLooks.GetCustomFrontLegNum(frontLegPairs);
			backLegPairs = CheatEngine.cheatRef.cheatLooks.GetCustomBackLegNum(backLegPairs);
		}
		int num = cappedLegPairsHard;
		if (GameSettings.AreGeneticsCapped())
		{
			num = cappedLegPairs;
		}
		if (backLegPairs + frontLegPairs > num)
		{
			int num2 = 1;
			while (backLegPairs + frontLegPairs > num)
			{
				if (num2 % 2 == 0)
				{
					if (backLegPairs <= 1)
					{
						frontLegPairs--;
					}
					else
					{
						backLegPairs--;
					}
				}
				else if (frontLegPairs <= 1)
				{
					backLegPairs--;
				}
				else
				{
					frontLegPairs--;
				}
				num2++;
			}
		}
		if (frontLegPairs < 1)
		{
			frontLegPairs = 1;
		}
		else if (backLegPairs < 1)
		{
			backLegPairs = 1;
		}
		int index = 0;
		for (int i = 0; i < frontLeftLeg.transform.parent.childCount; i++)
		{
			if (frontLeftLeg.transform.parent.GetChild(i).gameObject == frontLeftLeg)
			{
				index = i;
				break;
			}
		}
		int index2 = 0;
		for (int j = 0; j < backLeftLeg.transform.parent.childCount; j++)
		{
			if (backLeftLeg.transform.parent.GetChild(j).gameObject == backLeftLeg)
			{
				index2 = j;
				break;
			}
		}
		float num3 = bodyFront.transform.localScale.x - legEndOffset;
		for (int k = 0; k < frontLegPairs; k++)
		{
			Vector3 vector = bodyFront.transform.right * (num3 / (float)frontLegPairs) * k;
			GameObject gameObject;
			GameObject gameObject2;
			if (!domRecPropertyStatus)
			{
				gameObject = UnityEngine.Object.Instantiate(frontLeftLeg.transform.parent.gameObject, frontLeftLeg.transform.parent.parent);
				gameObject.name = "FrontHolder_Leg_LeftAdditional_" + k;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.position = frontLeftLeg.transform.parent.position;
				gameObject.transform.localRotation = frontLeftLeg.transform.parent.localRotation;
				gameObject.transform.localPosition += vector;
				gameObject2 = gameObject.transform.GetChild(index).gameObject;
				leftLegs.Add(gameObject2);
				allLegs.Add(gameObject2);
			}
			else
			{
				gameObject2 = null;
				gameObject = null;
			}
			GameObject gameObject3;
			GameObject gameObject4;
			if (!domRecPropertyStatus2)
			{
				gameObject3 = UnityEngine.Object.Instantiate(frontRightLeg.transform.parent.gameObject, frontRightLeg.transform.parent.parent);
				gameObject3.name = "FrontHolder_Leg_RightAdditional_" + k;
				gameObject3.transform.localScale = Vector3.one;
				gameObject3.transform.position = frontRightLeg.transform.parent.position;
				gameObject3.transform.localRotation = frontRightLeg.transform.parent.localRotation;
				gameObject3.transform.localPosition += vector;
				gameObject4 = gameObject3.transform.GetChild(index).gameObject;
				rightLegs.Add(gameObject4);
				allLegs.Add(gameObject4);
			}
			else
			{
				gameObject4 = null;
				gameObject3 = null;
			}
			if (!isDummy)
			{
				LegPair item = new LegPair(gameObject2, gameObject4);
				legControllerRef.legPairs.Add(item);
			}
			if (k == 0)
			{
				leftLegs.Remove(frontLeftLeg);
				rightLegs.Remove(frontRightLeg);
				allLegs.Remove(frontLeftLeg);
				allLegs.Remove(frontRightLeg);
				for (int l = 0; l < legControllerRef.legPairs.Count; l++)
				{
					if (legControllerRef.legPairs[l].leftLeg == frontLeftLeg && legControllerRef.legPairs[l].rightLeg == frontRightLeg)
					{
						legControllerRef.legPairs.RemoveAt(l);
					}
				}
				if (gameObject == null)
				{
					UnityEngine.Object.Destroy(frontLeftLeg.transform.parent.gameObject.GetComponent<LegMeshLinker>().legBaseObject);
				}
				if (gameObject3 == null)
				{
					UnityEngine.Object.Destroy(frontRightLeg.transform.parent.gameObject.GetComponent<LegMeshLinker>().legBaseObject);
				}
				UnityEngine.Object.Destroy(frontLeftLeg.transform.parent.gameObject);
				UnityEngine.Object.Destroy(frontRightLeg.transform.parent.gameObject);
				frontLeftLeg = gameObject2;
				frontRightLeg = gameObject4;
			}
			AddMeshToNewLegs(k, gameObject, gameObject3, frontLeg: true, k == 0);
		}
		num3 = bodyBack.transform.localScale.x - legEndOffset;
		for (int m = 0; m < backLegPairs; m++)
		{
			Vector3 vector = -bodyBack.transform.right * (num3 / (float)backLegPairs) * m;
			GameObject gameObject;
			GameObject gameObject2;
			if (!domRecPropertyStatus3)
			{
				gameObject = UnityEngine.Object.Instantiate(backLeftLeg.transform.parent.gameObject, backLeftLeg.transform.parent.parent);
				gameObject.name = "BackHolder_Leg_LeftAdditional_" + m;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.position = backLeftLeg.transform.parent.position;
				gameObject.transform.localRotation = backLeftLeg.transform.parent.localRotation;
				gameObject.transform.localPosition += vector;
				gameObject2 = gameObject.transform.GetChild(index2).gameObject;
				leftLegs.Add(gameObject2);
				allLegs.Add(gameObject2);
			}
			else
			{
				gameObject2 = null;
				gameObject = null;
			}
			GameObject gameObject3;
			GameObject gameObject4;
			if (!domRecPropertyStatus4)
			{
				gameObject3 = UnityEngine.Object.Instantiate(backRightLeg.transform.parent.gameObject, backRightLeg.transform.parent.parent);
				gameObject3.name = "BackHolder_Leg_RightAdditional_" + m;
				gameObject3.transform.localScale = Vector3.one;
				gameObject3.transform.position = backRightLeg.transform.parent.position;
				gameObject3.transform.localRotation = backRightLeg.transform.parent.localRotation;
				gameObject3.transform.localPosition += vector;
				gameObject4 = gameObject3.transform.GetChild(index2).gameObject;
				rightLegs.Add(gameObject4);
				allLegs.Add(gameObject4);
			}
			else
			{
				gameObject4 = null;
				gameObject3 = null;
			}
			if (!isDummy)
			{
				LegPair item2 = new LegPair(gameObject2, gameObject4);
				legControllerRef.legPairs.Add(item2);
			}
			if (m == 0)
			{
				leftLegs.Remove(backLeftLeg);
				rightLegs.Remove(backRightLeg);
				allLegs.Remove(backLeftLeg);
				allLegs.Remove(backRightLeg);
				for (int n = 0; n < legControllerRef.legPairs.Count; n++)
				{
					if (legControllerRef.legPairs[n].leftLeg == backLeftLeg && legControllerRef.legPairs[n].rightLeg == backRightLeg)
					{
						legControllerRef.legPairs.RemoveAt(n);
					}
				}
				if (gameObject == null)
				{
					UnityEngine.Object.Destroy(backLeftLeg.transform.parent.gameObject.GetComponent<LegMeshLinker>().legBaseObject);
				}
				if (gameObject3 == null)
				{
					UnityEngine.Object.Destroy(backRightLeg.transform.parent.gameObject.GetComponent<LegMeshLinker>().legBaseObject);
				}
				UnityEngine.Object.Destroy(backLeftLeg.transform.parent.gameObject);
				UnityEngine.Object.Destroy(backRightLeg.transform.parent.gameObject);
				backLeftLeg = gameObject2;
				backRightLeg = gameObject4;
			}
			AddMeshToNewLegs(m, gameObject, gameObject3, frontLeg: false, m == 0);
		}
	}

	private void AddMeshToNewLegs(int index, GameObject leftHolder, GameObject rightHolder, bool frontLeg, bool existingMesh = false)
	{
		if (leftHolder != null)
		{
			LegMeshLinker component = leftHolder.GetComponent<LegMeshLinker>();
			GameObject legBaseObject = component.legBaseObject;
			GameObject gameObject = UnityEngine.Object.Instantiate(legBaseObject, legBaseObject.transform.parent);
			if (frontLeg)
			{
				gameObject.name = "FrontLeftLegMesh_Additional_" + index;
			}
			else
			{
				gameObject.name = "BackLeftLegMesh_Additional_" + index;
			}
			component.legBaseObject = gameObject;
			component.legRoot = ObjectUtil.FindNestedTransformByName(gameObject, component.legRoot.name).gameObject;
			component.legMesh = ObjectUtil.FindNestedTransformByName(gameObject, component.legMesh.name).GetComponent<SkinnedMeshRenderer>();
			for (int i = 0; i < component.jointRemapping.Count; i++)
			{
				component.jointRemapping[i].refObject = ObjectUtil.FindNestedTransformByName(gameObject, component.jointRemapping[i].refObject.name).gameObject;
				component.jointRemapping[i].remapTarget = ObjectUtil.FindNestedTransformByName(gameObject, component.jointRemapping[i].remapTarget.name).gameObject;
			}
			ConfigurableJoint[] componentsInChildren = gameObject.GetComponentsInChildren<ConfigurableJoint>();
			foreach (ConfigurableJoint configurableJoint in componentsInChildren)
			{
				configurableJoint.connectedBody = ObjectUtil.FindNestedTransformByName(leftHolder, configurableJoint.connectedBody.name).GetComponent<Rigidbody>();
			}
			if (existingMesh)
			{
				UnityEngine.Object.Destroy(legBaseObject);
			}
		}
		if (rightHolder != null)
		{
			LegMeshLinker component2 = rightHolder.GetComponent<LegMeshLinker>();
			GameObject legBaseObject2 = component2.legBaseObject;
			GameObject gameObject2 = UnityEngine.Object.Instantiate(legBaseObject2, legBaseObject2.transform.parent);
			if (frontLeg)
			{
				gameObject2.name = "FrontRightLegMesh_Additional_" + index;
			}
			else
			{
				gameObject2.name = "BackRightLegMesh_Additional_" + index;
			}
			component2.legBaseObject = gameObject2;
			component2.legRoot = ObjectUtil.FindNestedTransformByName(gameObject2, component2.legRoot.name).gameObject;
			component2.legMesh = ObjectUtil.FindNestedTransformByName(gameObject2, component2.legMesh.name).GetComponent<SkinnedMeshRenderer>();
			for (int k = 0; k < component2.jointRemapping.Count; k++)
			{
				component2.jointRemapping[k].refObject = ObjectUtil.FindNestedTransformByName(gameObject2, component2.jointRemapping[k].refObject.name).gameObject;
				component2.jointRemapping[k].remapTarget = ObjectUtil.FindNestedTransformByName(gameObject2, component2.jointRemapping[k].remapTarget.name).gameObject;
			}
			ConfigurableJoint[] componentsInChildren = gameObject2.GetComponentsInChildren<ConfigurableJoint>();
			foreach (ConfigurableJoint configurableJoint2 in componentsInChildren)
			{
				configurableJoint2.connectedBody = ObjectUtil.FindNestedTransformByName(rightHolder, configurableJoint2.connectedBody.name).GetComponent<Rigidbody>();
			}
			if (existingMesh)
			{
				UnityEngine.Object.Destroy(legBaseObject2);
			}
		}
	}

	private void BeefUpLeg(GameObject leg, float scaleAmount)
	{
		leg.transform.parent.GetComponent<LegMeshLinker>().legBaseObject.GetComponent<Highlighter>().SetDisplacement(enabled: true, scaleAmount);
		SkinnedMeshRenderer legMesh = leg.transform.parent.GetComponent<LegMeshLinker>().legMesh;
		for (int i = 0; i < legMesh.materials.Length; i++)
		{
			legMesh.materials[i].SetFloat("_Chub", scaleAmount);
		}
	}

	private IEnumerator UpdateLegSize()
	{
		WaitForSecondsRealtime standardWait = new WaitForSecondsRealtime(GlobalProperties.standardTimeslice);
		float ageRatioModifiedValue = GetAgeRatioModifiedValue(legScaleXZMaxBackPuppy, legScaleXZMaxBack);
		float ageRatioModifiedValue2 = GetAgeRatioModifiedValue(legScaleXZMaxFrontPuppy, legScaleXZMaxFront);
		float ageRatioModifiedValue3 = GetAgeRatioModifiedValue(legScaleXZMaxBackPuppy, legScaleXZMaxBack, DogAge.ADULT);
		float ageRatioModifiedValue4 = GetAgeRatioModifiedValue(legScaleXZMaxFrontPuppy, legScaleXZMaxFront, DogAge.ADULT);
		float num = 0f - GetDynamicSeparatedFloatFromGene(GeneticProperty.LegScaleXZFrontMinus, 0f, legScaleXZMinFront, negativeValue: true) + GetDynamicSeparatedFloatFromGene(GeneticProperty.LegScaleXZFrontPlus, 0f, ageRatioModifiedValue2, negativeValue: false, ageRatioModifiedValue4);
		float num2 = 0f - GetDynamicSeparatedFloatFromGene(GeneticProperty.LegScaleXZBackMinus, 0f, legScaleXZMinBack, negativeValue: true) + GetDynamicSeparatedFloatFromGene(GeneticProperty.LegScaleXZBackPlus, 0f, ageRatioModifiedValue, negativeValue: false, ageRatioModifiedValue3);
		float num3 = 0f - GetDynamicSeparatedFloatFromGene(GeneticProperty.LegScaleYFrontTopMinus, 0f, legScaleYMinFrontTop, negativeValue: true) + GetDynamicSeparatedFloatFromGene(GeneticProperty.LegScaleYFrontTopPlus, 0f, legScaleYMaxFrontTop);
		float num4 = 0f - GetDynamicSeparatedFloatFromGene(GeneticProperty.LegScaleYFrontBotMinus, 0f, legScaleYMinFrontBot, negativeValue: true) + GetDynamicSeparatedFloatFromGene(GeneticProperty.LegScaleYFrontBotPlus, 0f, legScaleYMaxFrontBot);
		float num5 = 0f - GetDynamicSeparatedFloatFromGene(GeneticProperty.LegScaleYBackTopMinus, 0f, legScaleYMinBackTop, negativeValue: true) + GetDynamicSeparatedFloatFromGene(GeneticProperty.LegScaleYBackTopPlus, 0f, legScaleYMaxBackTop);
		float num6 = 0f - GetDynamicSeparatedFloatFromGene(GeneticProperty.LegScaleYBackBotMinus, 0f, legScaleYMinBackBot, negativeValue: true) + GetDynamicSeparatedFloatFromGene(GeneticProperty.LegScaleYBackBotPlus, 0f, legScaleYMaxBackBot);
		float num7 = 0f - GetFloatFromGene(GeneticProperty.StanceWidthFrontMinus, 0f, stanceWidthMin) + GetFloatFromGene(GeneticProperty.StanceWidthFrontPlus, 0f, stanceWidthMax);
		float num8 = 0f - GetFloatFromGene(GeneticProperty.StanceWidthBackMinus, 0f, stanceWidthMin) + GetFloatFromGene(GeneticProperty.StanceWidthBackPlus, 0f, stanceWidthMax);
		if (manualGenetics)
		{
			num = CheatEngine.cheatRef.cheatLooks.GetCustomLegXZFrontScale(num);
			num2 = CheatEngine.cheatRef.cheatLooks.GetCustomLegXZBackScale(num2);
			num3 = CheatEngine.cheatRef.cheatLooks.GetCustomLegYFrontTopScale(num3);
			num4 = CheatEngine.cheatRef.cheatLooks.GetCustomLegYFrontBotScale(num4);
			num5 = CheatEngine.cheatRef.cheatLooks.GetCustomLegYBackTopScale(num5);
			num6 = CheatEngine.cheatRef.cheatLooks.GetCustomLegYBackBotScale(num6);
			num7 = CheatEngine.cheatRef.cheatLooks.GetCustomStanceWidthFront(num7);
			num8 = CheatEngine.cheatRef.cheatLooks.GetCustomStanceWidthBack(num8);
		}
		float ageRatioModifiedValue5 = GetAgeRatioModifiedValue(puppyLegModY);
		float ageRatioModifiedValue6 = GetAgeRatioModifiedValue(puppyLegModXZ);
		num3 = Mathf.Clamp(num3 + ageRatioModifiedValue5, 0f - legScaleYMinFrontTop, legScaleYMaxFrontTop);
		num4 = Mathf.Clamp(num4 + ageRatioModifiedValue5, 0f - legScaleYMinFrontBot, legScaleYMaxFrontBot);
		num5 = Mathf.Clamp(num5 + ageRatioModifiedValue5, 0f - legScaleYMinBackTop, legScaleYMaxBackTop);
		num6 = Mathf.Clamp(num6 + ageRatioModifiedValue5, 0f - legScaleYMinBackBot, legScaleYMaxBackBot);
		totalFrontLegLength = num3 + num4;
		totalBackLegLength = num5 + num6;
		num2 = Mathf.Clamp(num2 + ageRatioModifiedValue6 + defaultScaleAdd, 0f - legScaleXZMinBack, ageRatioModifiedValue);
		num = Mathf.Clamp(num + ageRatioModifiedValue6 + defaultScaleAdd, 0f - legScaleXZMinFront, ageRatioModifiedValue2);
		float num9 = bodyFront.transform.localScale.z / 2f - minLegSeparation;
		float num10 = bodyBack.transform.localScale.z / 2f - minLegSeparation;
		float a = (bodyFront.transform.localScale.x - legFrontOffset) / (float)frontLegPairs;
		float a2 = (bodyBack.transform.localScale.x - legBackOffset) / (float)backLegPairs;
		if (frontLegPairs > 1)
		{
			num9 -= legPairSpace;
		}
		if (backLegPairs > 1)
		{
			num10 -= legPairSpace;
		}
		if (num9 <= 0f)
		{
			num9 = Mathf.Max(num9 + legPairSpace, 0.1f);
		}
		if (num10 <= 0f)
		{
			num10 += Mathf.Max(num10 + legPairSpace, 0.1f);
		}
		float num11 = Mathf.Min(a, num9);
		float num12 = Mathf.Min(a2, num10);
		float num13 = 1f;
		float num14 = 1f;
		float num15 = 1f;
		float num16 = 1f;
		if (frontLeftLeg != null)
		{
			num15 = frontLeftLeg.transform.localScale.x;
			num16 = frontLeftLeg.transform.localScale.z;
		}
		else if (frontRightLeg != null)
		{
			num15 = frontRightLeg.transform.localScale.x;
			num16 = frontRightLeg.transform.localScale.z;
		}
		if (backLeftLeg != null)
		{
			num13 = backLeftLeg.transform.localScale.x;
			num14 = backLeftLeg.transform.localScale.z;
		}
		else if (backRightLeg != null)
		{
			num13 = backRightLeg.transform.localScale.x;
			num14 = backRightLeg.transform.localScale.z;
		}
		float a3 = (num11 - num16) / num16;
		float a4 = (num12 - num14) / num14;
		if (num * num16 + num16 > num11)
		{
			num = Mathf.Max(a3, 0f - legScaleXZMinFront);
		}
		if (num2 * num14 + num14 > num12)
		{
			num2 = Mathf.Max(a4, 0f - legScaleXZMinBack);
		}
		float a5 = (num11 - num15) / num15;
		float a6 = (num12 - num13) / num13;
		if (num * num15 + num15 > num11)
		{
			num = Mathf.Max(a5, 0f - legScaleXZMinFront);
		}
		if (num2 * num13 + num13 > num12)
		{
			num2 = Mathf.Max(a6, 0f - legScaleXZMinBack);
		}
		Vector3 vector = new Vector3(num, 0f, num);
		Vector3 vector2 = new Vector3(num2, 0f, num2);
		backLegGirth = num2;
		frontLegGirth = num;
		Vector3 vector3 = new Vector3(0f, num3, 0f);
		Vector3 vector4 = new Vector3(0f, num4, 0f);
		Vector3 vector5 = new Vector3(0f, num5, 0f);
		Vector3 vector6 = new Vector3(0f, num6, 0f);
		float z = bodyFront.transform.localScale.z;
		float z2 = bodyBack.transform.localScale.z;
		float num17 = frontLegPosZ + frontLegParentPosZ;
		float num18 = backLegPosZ + backLegParentPosZ;
		float num19 = originalBodyScaleZ / 2f - num16 / 2f + num17;
		float num20 = originalBodyScaleZ / 2f - num14 / 2f + num18;
		float num21 = 0f - num17 - num16 / 2f;
		float num22 = 0f - num18 - num14 / 2f;
		float num23 = (z - originalBodyScaleZ) / 2f - num * num16 / 2f + num19 - minLegSeparation / 2f;
		float num24 = (z2 - originalBodyScaleZ) / 2f - num2 * num14 / 2f + num20 - minLegSeparation / 2f;
		float num25 = 0f - num21 + num * num16 / 2f + minLegSeparation / 2f;
		float num26 = 0f - num22 + num2 * num14 / 2f + minLegSeparation / 2f;
		Vector3 vector7 = Vector3.zero;
		Vector3 vector8 = Vector3.zero;
		if (num23 < 0f && (num7 > 0f || num23 < num25 * Mathf.Abs(num7)))
		{
			vector7 = num23 * -bodyFront.transform.forward;
		}
		else if (num25 > 0f && (num7 < 0f || num25 > num23 * Mathf.Abs(num7)))
		{
			vector7 = num25 * -bodyFront.transform.forward;
		}
		else if (num7 > 0f)
		{
			vector7 = num23 * Mathf.Abs(num7) * -bodyFront.transform.forward;
		}
		else if (num7 < 0f)
		{
			vector7 = num25 * Mathf.Abs(num7) * -bodyFront.transform.forward;
		}
		if (num24 < 0f && (num8 > 0f || num24 < num26 * Mathf.Abs(num8)))
		{
			vector8 = num24 * -bodyBack.transform.forward;
		}
		else if (num26 > 0f && (num8 < 0f || num26 > num24 * Mathf.Abs(num8)))
		{
			vector8 = num26 * -bodyBack.transform.forward;
		}
		else if (num8 > 0f)
		{
			vector8 = num24 * Mathf.Abs(num8) * -bodyBack.transform.forward;
		}
		else if (num8 < 0f)
		{
			vector8 = num26 * Mathf.Abs(num8) * -bodyBack.transform.forward;
		}
		GameObject gameObject = null;
		Vector3 vector9 = Vector3.one;
		List<GameObject> frontFootJointObjects = new List<GameObject>();
		Vector3 vector10 = Vector3.zero;
		for (int i = 0; i < allLegs.Count; i++)
		{
			bool flag = false;
			bool flag2 = false;
			GameObject gameObject2 = allLegs[i];
			if (gameObject2.GetComponent<Rigidbody>() == null)
			{
				continue;
			}
			GameObject gameObject3 = gameObject2.transform.parent.GetChild(0).GetComponent<ConfigurableJoint>().connectedBody.gameObject;
			Vector3 vector11;
			Vector3 vector12;
			Vector3 vector13;
			Vector3 vector14;
			Vector3 vector15;
			if (gameObject3 == bodyFront)
			{
				vector11 = vector;
				vector12 = vector4;
				vector13 = vector3;
				vector14 = vector7;
				vector15 = bodyFrontMov;
			}
			else
			{
				vector11 = vector2;
				vector12 = vector6;
				vector13 = vector5;
				vector14 = vector8;
				vector15 = bodyBackMov;
			}
			if (rightLegs.Contains(gameObject2))
			{
				vector14 *= -1f;
			}
			for (int j = 0; j < gameObject2.transform.parent.childCount; j++)
			{
				GameObject gameObject4 = gameObject2.transform.parent.GetChild(j).gameObject;
				gameObject4.transform.localPosition += vector14;
				Vector3 vector16 = new Vector3(gameObject4.transform.localScale.x * vector11.x, gameObject4.transform.localScale.y * vector11.y, gameObject4.transform.localScale.z * vector11.z);
				if (j == 3 && vector11.x > 0f)
				{
					vector16.x = 0f;
				}
				float scaleAmount = gameObject4.transform.lossyScale.x * vector11.x / 2f;
				gameObject4.transform.localScale += vector16;
				LegMeshLinker component = gameObject2.transform.parent.GetComponent<LegMeshLinker>();
				List<ConfigurableJoint> list = null;
				if (j == 3)
				{
					if (gameObject3 == bodyBack)
					{
						vector16.x = gameObject4.transform.localScale.x * vector11.x / 2f;
					}
					Rigidbody component2 = gameObject4.GetComponent<Rigidbody>();
					list = new List<ConfigurableJoint>();
					list.AddRange(component.legRoot.GetComponentsInChildren<ConfigurableJoint>());
					for (int k = 0; k < list.Count; k++)
					{
						if (!(list[k].connectedBody == component2))
						{
							continue;
						}
						if (gameObject3 == bodyFront)
						{
							bool flag3 = false;
							for (int l = 0; l < component.jointRemapping.Count; l++)
							{
								if (component.jointRemapping[l].refObject == list[k].gameObject)
								{
									flag3 = true;
									frontFootJointObjects.Add(component.jointRemapping[l].remapTarget);
									break;
								}
							}
							if (!flag3)
							{
								frontFootJointObjects.Add(list[k].gameObject);
							}
						}
						else
						{
							Vector3 vector17 = list[k].connectedBody.transform.InverseTransformVector(vector16) / 2f;
							vector17.y = 0f;
							vector17.z = 0f;
							vector17 *= base.transform.localScale.x;
							list[k].connectedAnchor -= vector17;
						}
						break;
					}
				}
				if (j == 0)
				{
					BeefUpLeg(gameObject2, scaleAmount);
				}
				if (j == 3 && gameObject3 == bodyFront)
				{
					vector16.x = 0f - vector10.x;
				}
				vector10 = vector16;
				Vector3 vector18;
				if (gameObject3 == bodyFront)
				{
					vector18 = vector16.x / 2f * gameObject4.transform.right;
					switch (j)
					{
					case 1:
						vector18 = vector16.x / 2f * -gameObject4.transform.right;
						break;
					case 3:
						vector18 = vector16.x / 4f * -gameObject4.transform.right;
						break;
					}
				}
				else
				{
					vector18 = vector16.x / 2f * -gameObject4.transform.right;
					switch (j)
					{
					case 1:
						vector18 = vector16.x / 2f * gameObject4.transform.right;
						break;
					case 3:
						vector18 = vector16.x / 2f * -gameObject4.transform.right;
						break;
					}
				}
				gameObject4.transform.localPosition += vector18;
				for (int m = j + 1; m < gameObject2.transform.parent.childCount; m++)
				{
					if (j == 2)
					{
						break;
					}
					gameObject2.transform.parent.GetChild(m).localPosition += vector18 * 2f;
				}
				if (gameObject4 == gameObject2)
				{
					flag = true;
					vector16 = new Vector3(gameObject4.transform.localScale.x * vector13.x, gameObject4.transform.localScale.y * vector13.y, gameObject4.transform.localScale.z * vector13.z);
				}
				else if (!flag || flag2)
				{
					vector16 = ((j != 3) ? Vector3.zero : new Vector3(0f, gameObject4.transform.localScale.y * vector11.x, 0f));
				}
				else
				{
					flag2 = true;
					vector16 = new Vector3(gameObject4.transform.localScale.x * vector12.x, gameObject4.transform.localScale.y * vector12.y, gameObject4.transform.localScale.z * vector12.z);
				}
				gameObject4.transform.localScale += vector16;
				vector18 = vector16.y / 2f * -gameObject4.transform.up;
				gameObject4.transform.localPosition += vector18;
				for (int n = j + 1; n < gameObject2.transform.parent.childCount; n++)
				{
					gameObject2.transform.parent.GetChild(n).localPosition += vector18 * 2f;
				}
				if (j == 2 && gameObject4.transform.childCount > 0 && gameObject == null)
				{
					gameObject = gameObject4.transform.GetChild(0).gameObject;
					vector9 = new Vector3(0f, gameObject.transform.localScale.y * (vector11.x - vector12.y), 0f);
				}
				gameObject4.transform.localPosition += vector15 * 2f;
				if (j == 3)
				{
					Rigidbody component3 = gameObject4.GetComponent<Rigidbody>();
					for (int num27 = 0; num27 < list.Count; num27++)
					{
						if (list[num27].connectedBody == component3)
						{
							Vector3 vector19 = list[num27].connectedBody.transform.InverseTransformVector(vector16) * 2f;
							vector19 *= base.transform.localScale.x;
							if (gameObject3 != bodyFront)
							{
								list[num27].connectedAnchor += vector19;
							}
							break;
						}
					}
				}
				gameObject4.SetActive(value: false);
				gameObject4.SetActive(value: true);
				RefreshAllChildren(legMeshHolder);
			}
			if (gameObject != null)
			{
				float num28 = 0.1f;
				if (gameObject.transform.localScale.y + vector9.y <= num28)
				{
					vector9 = new Vector3(vector9.x, 0f - (gameObject.transform.localScale.y - num28), vector9.z);
				}
				gameObject.transform.localScale += vector9;
				gameObject.transform.localPosition -= vector9 / 2f;
				gameObject = null;
			}
		}
		for (int num29 = 0; num29 < allLegs.Count; num29++)
		{
			allLegs[num29].transform.parent.gameObject.SetActive(value: false);
			allLegs[num29].transform.parent.gameObject.SetActive(value: true);
		}
		RefreshAllChildren(legMeshHolder);
		int maxJoints = 0;
		List<LegMeshLinker> linkers = new List<LegMeshLinker>();
		for (int num30 = 0; num30 < allLegs.Count; num30++)
		{
			LegMeshLinker component4 = allLegs[num30].transform.parent.GetComponent<LegMeshLinker>();
			if (component4 != null)
			{
				linkers.Add(component4);
				maxJoints = Mathf.Max(maxJoints, component4.GetNumberOfJoints());
			}
		}
		yield return standardWait;
		yield return standardWait;
		List<Vector3> anchors = new List<Vector3>();
		List<JointDataStruct> structs = new List<JointDataStruct>();
		for (int num31 = 0; num31 < maxJoints; num31++)
		{
			anchors.Clear();
			structs.Clear();
			yield return standardWait;
			for (int num32 = 0; num32 < linkers.Count; num32++)
			{
				Vector3 attachedJointAnchor = Vector3.zero;
				JointDataStruct jointInfo = default(JointDataStruct);
				linkers[num32].RemapJointIndexStart(num31, ref attachedJointAnchor, ref jointInfo);
				anchors.Add(attachedJointAnchor);
				structs.Add(jointInfo);
			}
			yield return standardWait;
			for (int num33 = 0; num33 < linkers.Count; num33++)
			{
				linkers[num33].RemapJointIndexEnd(num31, anchors[num33], structs[num33]);
			}
		}
		for (int num34 = 0; num34 < linkers.Count; num34++)
		{
			linkers[num34].RepositionJoints();
		}
		linkers.Clear();
		anchors.Clear();
		structs.Clear();
		for (int num35 = 0; num35 < frontFootJointObjects.Count; num35++)
		{
			ConfigurableJoint component5 = frontFootJointObjects[num35].GetComponent<ConfigurableJoint>();
			if (!(component5 == null))
			{
				component5.transform.parent.localPosition = new Vector3(component5.transform.parent.localPosition.x, 0f, component5.transform.parent.localPosition.z);
			}
		}
		for (int num36 = 0; num36 < allLegs.Count; num36++)
		{
			IgnoreObjectCollisions(allLegs[num36], leftWing);
			IgnoreObjectCollisions(allLegs[num36], rightWing);
		}
	}

	private void RefreshAllChildren(GameObject topLevelObj)
	{
		topLevelObj.SetActive(value: false);
		topLevelObj.SetActive(value: true);
	}

	private void UpdateFace(Vector3 faceScale, Vector3 bodyScale)
	{
		GameObject gameObject = faceHolder;
		if (useOldHead)
		{
			gameObject = oldFaceHolder;
		}
		Transform parent = gameObject.transform.parent;
		gameObject.transform.SetParent(null);
		gameObject.SetActive(value: false);
		float num = bodyFront.transform.localScale.y / bodyScale.y;
		float b = bodyFront.transform.localScale.z / bodyScale.z;
		float num2 = Mathf.Min(num, b);
		gameObject.transform.localScale = faceScale * num2;
		gameObject.transform.SetParent(parent);
		Vector3 vector = -gameObject.transform.forward * (bodyFront.transform.localScale.x - bodyScale.x) + gameObject.transform.up * (num - 1f) / 4f;
		if (useOldHead)
		{
			vector = gameObject.transform.right * (bodyFront.transform.localScale.x - bodyScale.x) + gameObject.transform.up * (num - 1f) / 4f;
		}
		gameObject.transform.localPosition += vector;
		gameObject.SetActive(value: true);
		float num3 = 0f - GetFloatFromGene(GeneticProperty.SnoutModAMinus, 0f, snoutModRotYMin) + GetFloatFromGene(GeneticProperty.SnoutModAPlus, 0f, snoutModRotYMax);
		float num4 = 0f - GetFloatFromGene(GeneticProperty.SnoutModBMinus, 0f, snoutModLenMin) + GetFloatFromGene(GeneticProperty.SnoutModBPlus, 0f, snoutModLenMax);
		float num5 = 0f - GetFloatFromGene(GeneticProperty.SnoutModCMinus, 0f, snoutModScaleMin) + GetFloatFromGene(GeneticProperty.SnoutModCPlus, 0f, snoutModScaleMax);
		if (manualGenetics)
		{
			num3 = CheatEngine.cheatRef.cheatLooks.GetCustomSnoutModA(num3);
			num4 = CheatEngine.cheatRef.cheatLooks.GetCustomSnoutModB(num4);
			num5 = CheatEngine.cheatRef.cheatLooks.GetCustomSnoutModC(num5);
		}
		if (!useOldHead)
		{
			GameObject snoutBone = faceControllerRef.mainDogHead.snoutBone;
			float x = snoutBone.transform.localScale.x;
			snoutBone.transform.localPosition -= new Vector3(num4, 0f, 0f);
			snoutBone.transform.localRotation = Quaternion.Euler(0f, num3 + snoutBone.transform.localRotation.eulerAngles.y, 0f);
			snoutBone.transform.localScale += new Vector3(num5, num5, num5);
			Transform transform = nose.transform;
			float x2 = transform.transform.lossyScale.x;
			transform.localScale /= snoutBone.transform.localScale.x / x;
			transform.localPosition += transform.right * ((x2 - transform.lossyScale.x) / 8f);
			transform.localPosition += transform.up * ((x2 - transform.lossyScale.x) / 8f);
		}
		gameObject.SetActive(value: false);
		gameObject.SetActive(value: true);
		Rigidbody[] componentsInChildren = gameObject.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody obj in componentsInChildren)
		{
			obj.gameObject.SetActive(value: false);
			obj.gameObject.SetActive(value: true);
		}
		UpdateHeadSize();
		AddAdditionalHeads();
	}

	private float GetSmallHeadBodyRatio()
	{
		return faceControllerRef.mainDogHead.headHolder.transform.localScale.x / Mathf.Min(bodyFront.transform.localScale.y, bodyFront.transform.localScale.z);
	}

	private float GetBigHeadBodyRatio()
	{
		return faceControllerRef.mainDogHead.headHolder.transform.localScale.x / Mathf.Max(bodyFront.transform.localScale.y, bodyFront.transform.localScale.z);
	}

	private void UpdateHeadSize()
	{
		chosenHeadSize = GetFloatFromGene(GeneticProperty.HeadSizePlus, 0f, headSizeMax) - GetFloatFromGene(GeneticProperty.HeadSizeMinus, 0f, headSizeMin);
		if (manualGenetics)
		{
			chosenHeadSize = CheatEngine.cheatRef.cheatLooks.GetCustomHeadSize(chosenHeadSize);
		}
		chosenHeadSize = Mathf.Clamp(chosenHeadSize + GetAgeRatioModifiedValue(puppyHeadSize), 0f - headSizeMin, headSizeMax);
		if (GameSettings.AreGeneticsCapped() && chosenHeadSize > cappedHeadSize)
		{
			chosenHeadSize = cappedHeadSize;
		}
		GameObject headHolder = faceControllerRef.mainDogHead.headHolder;
		if (useOldHead)
		{
			headHolder = faceControllerRef.oldDogHead.headHolder;
		}
		float a = headHolder.transform.localScale.x + chosenHeadSize;
		a = Mathf.Max(a, 0.1f);
		Vector3 localScale = new Vector3(a, a, a);
		headHolder.transform.localScale = localScale;
		if (useOldHead)
		{
			hasBigHead = false;
			hasTinyHead = false;
		}
		else
		{
			hasBigHead = GetBigHeadBodyRatio() >= bigHeadCutoff;
			hasTinyHead = GetSmallHeadBodyRatio() <= tinyHeadCutoff;
		}
		headHolder.SetActive(value: false);
		headHolder.SetActive(value: true);
	}

	private void AddAdditionalHeads()
	{
		chosenHeadCount = GetDynamicSeparatedIntFromGene(GeneticProperty.HeadNumber, headNumMin, headnumMax);
		if (useOldHead)
		{
			return;
		}
		if (manualGenetics)
		{
			chosenHeadCount = CheatEngine.cheatRef.cheatLooks.GetCustomHeadNumber(chosenHeadCount);
		}
		int num = cappedHeadNumHardMax;
		if (GameSettings.AreGeneticsCapped())
		{
			num = cappedHeadNumSoftMax;
		}
		if (chosenHeadCount > num)
		{
			chosenHeadCount = num;
		}
		Renderer key = null;
		if (isGhost && chosenHeadCount > 1)
		{
			key = face.GetComponent<Renderer>();
		}
		GameObject headHolder = faceControllerRef.mainDogHead.headHolder;
		for (int i = 0; i < chosenHeadCount - 1; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(headHolder, headHolder.transform.parent);
			DogHead dogHead = new DogHead();
			dogHead.headHolder = gameObject;
			dogHead.snoutBone = ObjectUtil.FindNestedTransformByName(gameObject, "SnoutBone").gameObject;
			dogHead.faceObject = ObjectUtil.FindNestedTransformByName(gameObject, "HeadMesh").gameObject;
			dogHead.earsHolder = ObjectUtil.FindNestedTransformByName(gameObject, "EarsHolder").gameObject;
			dogHead.armatureStart = ObjectUtil.FindNestedTransformByName(gameObject, "MainFaceBone").gameObject;
			dogHead.vocalizationEffect = ObjectUtil.FindNestedTransformByName(gameObject, "DogVocalizationEffect").gameObject.GetComponent<DogVocalizer>();
			dogHead.mouthJointBody = ObjectUtil.FindNestedTransformByName(gameObject, "MidFaceBone").GetComponent<Rigidbody>();
			dogHead.mouthJointRef = dogHead.armatureStart.transform;
			dogHead.mouthTransform = ObjectUtil.FindNestedTransformByName(gameObject, "Mouth");
			faceControllerRef.AddDogHead(dogHead);
			PositionHead(gameObject, i + 2, chosenHeadCount);
			if (isGhost)
			{
				Renderer component = dogHead.faceObject.GetComponent<Renderer>();
				Transform child = ObjectUtil.FindNestedTransformByName(gameObject, "EarsHolder").GetChild(0);
				Renderer componentInChildren = ObjectUtil.FindNestedTransformByName(gameObject, "NoseHolder").GetComponentInChildren<Renderer>();
				lateGhostRenderers.Add(component);
				lateGhostRenderers.Add(componentInChildren);
				lateGhostMaterialAssignments[component] = lateGhostMaterialAssignments[key];
				lateGhostMaterialAssignments[componentInChildren] = noseEarMat;
				for (int j = 0; j < child.childCount; j++)
				{
					Renderer componentInChildren2 = child.GetChild(j).GetComponentInChildren<Renderer>();
					lateGhostRenderers.Add(componentInChildren2);
					lateGhostMaterialAssignments[componentInChildren2] = noseEarMat;
				}
			}
		}
		if (chosenHeadCount > 1)
		{
			PositionHead(headHolder, 1, chosenHeadCount);
		}
	}

	private void PositionHead(GameObject headObject, int index, int headMax)
	{
		float num = 45f;
		float num2 = (float)index / (float)headMax;
		float num3 = Mathf.Sin(num2 * 360f * ((float)Math.PI / 180f));
		float num4 = Mathf.Cos(num2 * 360f * ((float)Math.PI / 180f));
		Vector3 zero = Vector3.zero;
		zero -= headObject.transform.up * (headRadius * num3);
		zero -= headObject.transform.right * (headRadius * num4);
		headObject.transform.localPosition += zero;
		Vector3 eulerAngles = headObject.transform.localRotation.eulerAngles;
		headObject.transform.localRotation = Quaternion.Euler(eulerAngles.x + num3 * (0f - num), eulerAngles.y + num4 * num, eulerAngles.z);
		headObject.SetActive(value: false);
		headObject.SetActive(value: true);
	}

	public float GetDynamicSeparatedFloatFromGene(GeneticProperty key, float minVal, float maxVal, bool negativeValue = false, float? optionalTrueMaxVal = null)
	{
		string geneString = masterDogGeneRef.GetGeneString(key);
		int expectedGeneSize = masterDogGeneRef.GetExpectedGeneSize(key);
		int length = geneString.Length;
		float num = maxVal + masterDogGeneRef.GetMaxValIncrease(key) * (float)(length - expectedGeneSize);
		if (num < maxVal)
		{
			Debug.LogError(string.Concat("This dog code appears to have been manually edited and ", key, " is shorter than it should be. This should not be possible."));
			num = maxVal;
		}
		if (negativeValue && length != expectedGeneSize)
		{
			num = maxVal;
		}
		float floatFromGeneSequence = MathUtil.GetFloatFromGeneSequence(geneString, minVal, num);
		float? trueVal = null;
		if (optionalTrueMaxVal.HasValue)
		{
			trueVal = MathUtil.GetFloatFromGeneSequence(geneString, minVal, optionalTrueMaxVal.Value);
		}
		masterDogGeneRef.SetGeneValues(key, floatFromGeneSequence, minVal, num, maxVal, optionalTrueMaxVal, trueVal);
		return floatFromGeneSequence;
	}

	public int GetDynamicSeparatedIntFromGene(GeneticProperty key, float minVal, float maxVal)
	{
		string geneString = masterDogGeneRef.GetGeneString(key);
		int expectedGeneSize = masterDogGeneRef.GetExpectedGeneSize(key);
		int length = geneString.Length;
		bool flag = true;
		if (length < expectedGeneSize)
		{
			flag = false;
			Debug.LogError("Invalid gene: " + geneString + " for key: " + key);
			Debug.LogError("Actual size lower than expected size. This likely means it was tampered with manually.");
		}
		float maxVal2 = maxVal + masterDogGeneRef.GetMaxValIncrease(key) * (float)(length - expectedGeneSize);
		int num = ((!flag) ? Mathf.RoundToInt(minVal) : Mathf.RoundToInt(MathUtil.GetFloatFromGeneSequence(geneString, minVal, maxVal2)));
		masterDogGeneRef.SetGeneValues(key, num, minVal, maxVal2, maxVal);
		return num;
	}

	public float GetFloatFromGene(GeneticProperty key, float minVal, float maxVal)
	{
		float floatFromGeneSequence = MathUtil.GetFloatFromGeneSequence(masterDogGeneRef.GetGeneString(key), minVal, maxVal);
		masterDogGeneRef.SetGeneValues(key, floatFromGeneSequence, minVal, maxVal, maxVal);
		return floatFromGeneSequence;
	}

	public int GetIntFromGene(GeneticProperty key, float minVal, float maxVal)
	{
		int num = Mathf.RoundToInt(MathUtil.GetFloatFromGeneSequence(masterDogGeneRef.GetGeneString(key), minVal, maxVal));
		masterDogGeneRef.SetGeneValues(key, num, minVal, maxVal, maxVal);
		return num;
	}
}
