using System;
using System.Collections.Generic;
using AwesomeTechnologies.Shaders;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[Serializable]
	public class VegetationItemInfoPro
	{
		public string VegetationItemID;

		public string Name;

		public VegetationType VegetationType = VegetationType.Tree;

		public VegetationPrefabType PrefabType;

		public VegetationRenderMode VegetationRenderMode;

		public bool EnableRuntimeSpawn = true;

		public bool DisableShadows;

		public GameObject VegetationPrefab;

		public Texture2D VegetationTexture;

		public string VegetationGuid = "";

		public float SampleDistance = 1.5f;

		public float Density = 1f;

		public bool RandomizePosition = true;

		public bool UseVegetationMasksOnStorage;

		public bool UseSamplePointOffset;

		public float SamplePointMinOffset = 3f;

		public float SamplePointMaxOffset = 5f;

		public Vector3 Offset = new Vector3(0f, 0f, 0f);

		public Vector3 RotationOffset = new Vector3(0f, 0f, 0f);

		public VegetationRotationType Rotation;

		public float MinUpOffset;

		public float MaxUpOffset;

		public Bounds Bounds;

		public Vector3 ScaleMultiplier = new Vector3(1f, 1f, 1f);

		public float RenderDistanceFactor = 1f;

		public int Seed;

		public float MinScale = 0.8f;

		public float MaxScale = 1.2f;

		public float YScale = 1f;

		public ColliderType ColliderType;

		public float ColliderRadius = 0.25f;

		public float ColliderHeight = 2f;

		public Vector3 ColliderOffset = Vector3.zero;

		public Vector3 ColliderSize = Vector3.one;

		public bool ColliderTrigger;

		public Mesh ColliderMesh;

		public bool ColliderUseForBake = true;

		public float ColliderDistanceFactor = 0.15f;

		public string ColliderTag = "";

		public bool ColliderConvex;

		public NavMeshObstacleType NavMeshObstacleType;

		public Vector3 NavMeshObstacleCenter;

		public Vector3 NavMeshObstacleSize = Vector3.one;

		public float NavMeshObstacleRadius = 0.5f;

		public float NavMeshObstacleHeight = 2f;

		public bool NavMeshObstacleCarve = true;

		public int NavMeshArea;

		public bool UseBillboards = true;

		public BillboardQuality BillboardQuality;

		public Texture2D BillboardTexture;

		public Texture2D BillboardNormalTexture;

		public Texture2D BillboardAoTexture;

		public LODLevel BillboardSourceLODLevel;

		public ColorSpace BillboardColorSpace = ColorSpace.Uninitialized;

		public float BillboardBrightness = 1f;

		public float BillboardCutoff = 0.2f;

		public Color BillboardTintColor = Color.white;

		public Color BillboardAtlasBackgroundColor = new Color(16f / 51f, 16f / 51f, 4f / 51f);

		public float BillboardMipmapBias = -2f;

		public float BillboardWindSpeed = 1f;

		public float BillboardSmoothness = 0.2f;

		public float BillboardMetallic = 0.5f;

		public float BillboardSpecular;

		public float BillboardOcclusion = 1f;

		public float BillboardNormalStrength = 1f;

		public float BillboardShadowOffset = 2f;

		public bool BillboardRecalculateNormals;

		public float BillboardNormalBlendFactor = 1f;

		public BillboardRenderMode BillboardRenderMode = BillboardRenderMode.Specular;

		public bool BillboardFlipBackNormals;

		public float BillboardFadeDistance = 5f;

		public bool UseBillboardFade = true;

		public bool OverrideShaderController;

		public bool UseBillboardSnow;

		public bool UseBillboardWind;

		public int BillboardVersion;

		public bool UseHeightRule = true;

		public float MinHeight;

		public float MaxHeight = 1500f;

		public bool UseAdvancedHeightRule;

		public float MaxCurveHeight = 500f;

		public AnimationCurve HeightRuleCurve = new AnimationCurve();

		public bool UseSteepnessRule = true;

		public float MinSteepness;

		public float MaxSteepness = 30f;

		public bool UseAdvancedSteepnessRule;

		public AnimationCurve SteepnessRuleCurve = new AnimationCurve();

		public bool UseNoiseCutoff = true;

		public float NoiseCutoffValue = 0.5f;

		public float NoiseCutoffScale = 5f;

		public bool NoiseCutoffInverse;

		public Vector2 NoiseCutoffOffset = new Vector2(0f, 0f);

		public bool UseNoiseDensity = true;

		public float NoiseDensityScale = 5f;

		public bool NoiseDensityInverse;

		public Vector2 NoiseDensityOffset = new Vector2(0f, 0f);

		public bool UseNoiseScaleRule;

		public float NoiseScaleMinScale = 0.7f;

		public float NoiseScaleMaxScale = 1.3f;

		public float NoiseScaleScale = 5f;

		public bool NoiseScaleInverse;

		public Vector2 NoiseScaleOffset = new Vector2(0f, 0f);

		public bool UseBiomeEdgeScaleRule;

		public float BiomeEdgeScaleDistance = 10f;

		public float BiomeEdgeScaleMinScale = 0.3f;

		public float BiomeEdgeScaleMaxScale = 1f;

		public bool BiomeEdgeScaleInverse;

		public bool UseBiomeEdgeIncludeRule;

		public float BiomeEdgeIncludeDistance = 10f;

		public bool BiomeEdgeIncludeInverse;

		public bool UseConcaveLocationRule;

		public bool ConcaveLocationInverse;

		public float ConcaveLoactionMinHeightDifference = 1f;

		public float ConcaveLoactionDistance = 3f;

		public bool ConcaveLoactionAverage = true;

		public bool UseTerrainTextureIncludeRules;

		public List<TerrainTextureRule> TerrainTextureIncludeRuleList = new List<TerrainTextureRule>();

		public bool UseTerrainTextureExcludeRules;

		public List<TerrainTextureRule> TerrainTextureExcludeRuleList = new List<TerrainTextureRule>();

		public bool UseTextureMaskIncludeRules;

		public List<TextureMaskRule> TextureMaskIncludeRuleList = new List<TextureMaskRule>();

		public bool UseTextureMaskExcludeRules;

		public List<TextureMaskRule> TextureMaskExcludeRuleList = new List<TextureMaskRule>();

		public bool UseTextureMaskScaleRules;

		public List<TextureMaskRule> TextureMaskScaleRuleList = new List<TextureMaskRule>();

		public bool UseTextureMaskDensityRules;

		public List<TextureMaskRule> TextureMaskDensityRuleList = new List<TextureMaskRule>();

		public string ShaderName;

		public ShaderControllerSettings ShaderControllerSettings;

		public bool UseTerrainSourceIncludeRule;

		public TerrainSourceRule TerrainSourceIncludeRule;

		public bool UseTerrainSourceExcludeRule;

		public TerrainSourceRule TerrainSourceExcludeRule;

		public bool DisableLOD;

		public float LODFactor = 1f;

		public bool UseDistanceFalloff;

		public float DistanceFalloffStartDistance = 0.4f;

		public bool UseVegetationMask;

		public VegetationTypeIndex VegetationTypeIndex = VegetationTypeIndex.VegetationType1;

		public List<RuntimePrefabRule> RuntimePrefabRuleList = new List<RuntimePrefabRule>();

		public bool EnableCrossFade;

		public VegetationItemInfoPro()
		{
		}

		public VegetationItemInfoPro(VegetationItemInfoPro sourceItem)
		{
			VegetationItemID = Guid.NewGuid().ToString();
			CopySettingValues(sourceItem);
			Seed = UnityEngine.Random.Range(0, 99);
		}

		public void CopySettingValues(VegetationItemInfoPro sourceItem)
		{
			Name = sourceItem.Name;
			VegetationType = sourceItem.VegetationType;
			VegetationType = sourceItem.VegetationType;
			VegetationRenderMode = sourceItem.VegetationRenderMode;
			VegetationPrefab = sourceItem.VegetationPrefab;
			VegetationTexture = sourceItem.VegetationTexture;
			SampleDistance = sourceItem.SampleDistance;
			EnableRuntimeSpawn = sourceItem.EnableRuntimeSpawn;
			UseSamplePointOffset = sourceItem.UseSamplePointOffset;
			SamplePointMinOffset = sourceItem.SamplePointMinOffset;
			SamplePointMaxOffset = sourceItem.SamplePointMaxOffset;
			VegetationGuid = sourceItem.VegetationGuid;
			Offset = sourceItem.Offset;
			RotationOffset = sourceItem.RotationOffset;
			Rotation = sourceItem.Rotation;
			Bounds = default(Bounds);
			RenderDistanceFactor = sourceItem.RenderDistanceFactor;
			Seed = sourceItem.Seed;
			MinScale = sourceItem.MinScale;
			MaxScale = sourceItem.MaxScale;
			YScale = sourceItem.YScale;
			UseVegetationMasksOnStorage = sourceItem.UseVegetationMasksOnStorage;
			ColliderType = sourceItem.ColliderType;
			ColliderRadius = sourceItem.ColliderRadius;
			ColliderHeight = sourceItem.ColliderHeight;
			ColliderOffset = sourceItem.ColliderOffset;
			ColliderTrigger = sourceItem.ColliderTrigger;
			ColliderMesh = sourceItem.ColliderMesh;
			ColliderUseForBake = sourceItem.ColliderUseForBake;
			ColliderDistanceFactor = sourceItem.ColliderDistanceFactor;
			ColliderSize = sourceItem.ColliderSize;
			ColliderConvex = sourceItem.ColliderConvex;
			NavMeshObstacleType = sourceItem.NavMeshObstacleType;
			NavMeshObstacleCenter = sourceItem.NavMeshObstacleCenter;
			NavMeshObstacleSize = sourceItem.NavMeshObstacleSize;
			NavMeshObstacleRadius = sourceItem.NavMeshObstacleRadius;
			NavMeshObstacleHeight = sourceItem.NavMeshObstacleHeight;
			NavMeshObstacleCarve = sourceItem.NavMeshObstacleCarve;
			UseBillboards = sourceItem.UseBillboards;
			BillboardQuality = sourceItem.BillboardQuality;
			BillboardTexture = sourceItem.BillboardTexture;
			BillboardAoTexture = sourceItem.BillboardAoTexture;
			BillboardNormalTexture = sourceItem.BillboardNormalTexture;
			BillboardSourceLODLevel = sourceItem.BillboardSourceLODLevel;
			BillboardColorSpace = sourceItem.BillboardColorSpace;
			BillboardBrightness = sourceItem.BillboardBrightness;
			BillboardCutoff = sourceItem.BillboardCutoff;
			BillboardTintColor = sourceItem.BillboardTintColor;
			BillboardAtlasBackgroundColor = sourceItem.BillboardAtlasBackgroundColor;
			BillboardMipmapBias = sourceItem.BillboardMipmapBias;
			BillboardWindSpeed = sourceItem.BillboardWindSpeed;
			BillboardMetallic = sourceItem.BillboardMetallic;
			BillboardSmoothness = sourceItem.BillboardSmoothness;
			BillboardSpecular = sourceItem.BillboardSpecular;
			BillboardOcclusion = sourceItem.BillboardOcclusion;
			BillboardRenderMode = sourceItem.BillboardRenderMode;
			BillboardNormalStrength = sourceItem.BillboardNormalStrength;
			BillboardRecalculateNormals = sourceItem.BillboardRecalculateNormals;
			BillboardNormalBlendFactor = sourceItem.BillboardNormalBlendFactor;
			BillboardFlipBackNormals = sourceItem.BillboardFlipBackNormals;
			BillboardShadowOffset = sourceItem.BillboardShadowOffset;
			BillboardVersion = sourceItem.BillboardVersion;
			UseHeightRule = sourceItem.UseHeightRule;
			MinHeight = sourceItem.MinHeight;
			MaxHeight = sourceItem.MaxHeight;
			UseSteepnessRule = sourceItem.UseSteepnessRule;
			MinSteepness = sourceItem.MinSteepness;
			MaxSteepness = sourceItem.MaxSteepness;
			UseConcaveLocationRule = sourceItem.UseConcaveLocationRule;
			ConcaveLocationInverse = sourceItem.ConcaveLocationInverse;
			ConcaveLoactionMinHeightDifference = sourceItem.ConcaveLoactionMinHeightDifference;
			ConcaveLoactionDistance = sourceItem.ConcaveLoactionDistance;
			ConcaveLoactionAverage = sourceItem.ConcaveLoactionAverage;
			UseNoiseCutoff = sourceItem.UseNoiseCutoff;
			NoiseCutoffValue = sourceItem.NoiseCutoffValue;
			NoiseCutoffScale = sourceItem.NoiseCutoffScale;
			NoiseCutoffInverse = sourceItem.NoiseCutoffInverse;
			NoiseCutoffOffset = sourceItem.NoiseCutoffOffset;
			UseNoiseDensity = sourceItem.UseNoiseDensity;
			NoiseDensityScale = sourceItem.NoiseDensityScale;
			NoiseDensityInverse = sourceItem.NoiseDensityInverse;
			NoiseDensityOffset = sourceItem.NoiseDensityOffset;
			UseNoiseScaleRule = sourceItem.UseNoiseScaleRule;
			NoiseScaleMinScale = sourceItem.NoiseScaleMinScale;
			NoiseScaleMaxScale = sourceItem.NoiseScaleMaxScale;
			NoiseScaleScale = sourceItem.NoiseScaleScale;
			NoiseScaleInverse = sourceItem.NoiseScaleInverse;
			NoiseScaleOffset = sourceItem.NoiseScaleOffset;
			UseBiomeEdgeScaleRule = sourceItem.UseBiomeEdgeScaleRule;
			BiomeEdgeScaleDistance = sourceItem.BiomeEdgeScaleDistance;
			BiomeEdgeScaleMinScale = sourceItem.BiomeEdgeScaleMinScale;
			BiomeEdgeScaleMaxScale = sourceItem.BiomeEdgeScaleMaxScale;
			BiomeEdgeScaleInverse = sourceItem.BiomeEdgeScaleInverse;
			UseBiomeEdgeIncludeRule = sourceItem.UseBiomeEdgeIncludeRule;
			BiomeEdgeIncludeDistance = sourceItem.BiomeEdgeIncludeDistance;
			BiomeEdgeIncludeInverse = sourceItem.BiomeEdgeIncludeInverse;
			UseTerrainTextureIncludeRules = sourceItem.UseTerrainTextureIncludeRules;
			UseTerrainTextureExcludeRules = sourceItem.UseTerrainTextureExcludeRules;
			for (int i = 0; i <= sourceItem.TerrainTextureIncludeRuleList.Count - 1; i++)
			{
				TerrainTextureIncludeRuleList.Add(new TerrainTextureRule(sourceItem.TerrainTextureIncludeRuleList[i]));
			}
			for (int j = 0; j <= sourceItem.TerrainTextureExcludeRuleList.Count - 1; j++)
			{
				TerrainTextureExcludeRuleList.Add(new TerrainTextureRule(sourceItem.TerrainTextureExcludeRuleList[j]));
			}
			UseTextureMaskIncludeRules = sourceItem.UseTextureMaskIncludeRules;
			for (int k = 0; k <= sourceItem.TextureMaskIncludeRuleList.Count - 1; k++)
			{
				TextureMaskIncludeRuleList.Add(new TextureMaskRule(sourceItem.TextureMaskIncludeRuleList[k]));
			}
			UseTextureMaskExcludeRules = sourceItem.UseTextureMaskExcludeRules;
			for (int l = 0; l <= sourceItem.TextureMaskExcludeRuleList.Count - 1; l++)
			{
				TextureMaskExcludeRuleList.Add(new TextureMaskRule(sourceItem.TextureMaskExcludeRuleList[l]));
			}
			UseTextureMaskScaleRules = sourceItem.UseTextureMaskScaleRules;
			for (int m = 0; m <= sourceItem.TextureMaskScaleRuleList.Count - 1; m++)
			{
				TextureMaskScaleRuleList.Add(new TextureMaskRule(sourceItem.TextureMaskScaleRuleList[m]));
			}
			UseTextureMaskDensityRules = sourceItem.UseTextureMaskDensityRules;
			for (int n = 0; n <= sourceItem.TextureMaskDensityRuleList.Count - 1; n++)
			{
				TextureMaskDensityRuleList.Add(new TextureMaskRule(sourceItem.TextureMaskDensityRuleList[n]));
			}
			ShaderName = sourceItem.ShaderName;
			ShaderControllerSettings = new ShaderControllerSettings(sourceItem.ShaderControllerSettings);
			DisableLOD = sourceItem.DisableLOD;
			LODFactor = sourceItem.LODFactor;
			UseDistanceFalloff = sourceItem.UseDistanceFalloff;
			DistanceFalloffStartDistance = sourceItem.DistanceFalloffStartDistance;
			UseVegetationMask = sourceItem.UseVegetationMask;
			VegetationTypeIndex = sourceItem.VegetationTypeIndex;
			UseTerrainSourceIncludeRule = sourceItem.UseTerrainSourceIncludeRule;
			TerrainSourceIncludeRule = sourceItem.TerrainSourceIncludeRule;
			UseTerrainSourceExcludeRule = sourceItem.UseTerrainSourceExcludeRule;
			TerrainSourceExcludeRule = sourceItem.TerrainSourceExcludeRule;
			UseAdvancedHeightRule = sourceItem.UseAdvancedHeightRule;
			MaxCurveHeight = sourceItem.MaxCurveHeight;
			HeightRuleCurve = new AnimationCurve(sourceItem.SteepnessRuleCurve.keys);
			UseAdvancedSteepnessRule = sourceItem.UseAdvancedSteepnessRule;
			SteepnessRuleCurve = new AnimationCurve(sourceItem.SteepnessRuleCurve.keys);
			for (int num = 0; num <= sourceItem.RuntimePrefabRuleList.Count - 1; num++)
			{
				RuntimePrefabRuleList.Add(new RuntimePrefabRule(sourceItem.RuntimePrefabRuleList[num]));
			}
			BillboardFadeDistance = sourceItem.BillboardFadeDistance;
			UseBillboardFade = sourceItem.UseBillboardFade;
			EnableCrossFade = sourceItem.EnableCrossFade;
		}

		public void Init()
		{
			HeightRuleCurve.AddKey(0f, 1f);
			HeightRuleCurve.AddKey(1f, 1f);
			SteepnessRuleCurve.AddKey(0f, 0f);
			SteepnessRuleCurve.AddKey(0.5f, 1f);
		}

		public int GetDistanceBand()
		{
			if (VegetationType == VegetationType.Tree || VegetationType == VegetationType.LargeObjects)
			{
				return 1;
			}
			return 0;
		}
	}
}
