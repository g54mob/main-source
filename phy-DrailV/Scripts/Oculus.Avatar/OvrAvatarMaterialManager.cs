using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class OvrAvatarMaterialManager : MonoBehaviour
{
	public enum TextureType
	{
		DiffuseTextures = 0,
		NormalMaps = 1,
		RoughnessMaps = 2,
		Count = 3
	}

	public struct AvatarComponentMaterialProperties
	{
		public ovrAvatarBodyPartType TypeIndex;

		public Color Color;

		public Texture2D[] Textures;

		public float DiffuseIntensity;

		public float RimIntensity;

		public float ReflectionIntensity;
	}

	public struct AvatarTextureArrayProperties
	{
		public Texture2D[] Textures;

		public Texture2DArray TextureArray;
	}

	public struct AvatarMaterialPropertyBlock
	{
		public Vector4[] Colors;

		public float[] DiffuseIntensities;

		public float[] RimIntensities;

		public float[] ReflectionIntensities;
	}

	[Serializable]
	public class AvatarMaterialConfig
	{
		public AvatarComponentMaterialProperties[] ComponentMaterialProperties;

		public AvatarMaterialPropertyBlock MaterialPropertyBlock;
	}

	private Renderer TargetRenderer;

	private AvatarTextureArrayProperties[] TextureArrays;

	private readonly string[] TextureTypeToShaderProperties = new string[3] { "_MainTex", "_NormalMap", "_RoughnessMap" };

	public AvatarMaterialConfig LocalAvatarConfig = new AvatarMaterialConfig();

	public List<ReflectionProbeBlendInfo> ReflectionProbes = new List<ReflectionProbeBlendInfo>();

	private Shader CombinedShader;

	public static string AVATAR_SHADER_LOADER = "OvrAvatar/Avatar_Mobile_Loader";

	public static string AVATAR_SHADER_MAINTEX = "_MainTex";

	public static string AVATAR_SHADER_NORMALMAP = "_NormalMap";

	public static string AVATAR_SHADER_ROUGHNESSMAP = "_RoughnessMap";

	public static string AVATAR_SHADER_COLOR = "_BaseColor";

	public static string AVATAR_SHADER_DIFFUSEINTENSITY = "_DiffuseIntensity";

	public static string AVATAR_SHADER_RIMINTENSITY = "_RimIntensity";

	public static string AVATAR_SHADER_REFLECTIONINTENSITY = "_ReflectionIntensity";

	public static string AVATAR_SHADER_CUBEMAP = "_Cubemap";

	public static string AVATAR_SHADER_ALPHA = "_Alpha";

	public static string AVATAR_SHADER_LOADING_DIMMER = "_LoadingDimmer";

	public static string AVATAR_SHADER_IRIS_COLOR = "_MaskColorIris";

	public static string AVATAR_SHADER_LIP_COLOR = "_MaskColorLips";

	public static string AVATAR_SHADER_BROW_COLOR = "_MaskColorBrows";

	public static string AVATAR_SHADER_LASH_COLOR = "_MaskColorLashes";

	public static string AVATAR_SHADER_SCLERA_COLOR = "_MaskColorSclera";

	public static string AVATAR_SHADER_GUM_COLOR = "_MaskColorGums";

	public static string AVATAR_SHADER_TEETH_COLOR = "_MaskColorTeeth";

	public static string AVATAR_SHADER_LIP_SMOOTHNESS = "_LipSmoothness";

	public static float[] DiffuseIntensities = new float[5] { 0.3f, 0.1f, 0f, 0.15f, 0.15f };

	public static float[] RimIntensities = new float[5] { 5f, 2f, 2.84f, 4f, 4f };

	public static float[] ReflectionIntensities = new float[5] { 0f, 0.3f, 0.4f, 0f, 0f };

	private const float LOADING_ANIMATION_AMPLITUDE = 0.5f;

	private const float LOADING_ANIMATION_PERIOD = 0.35f;

	private const float LOADING_ANIMATION_CURVE_SCALE = 0.25f;

	private const float LOADING_ANIMATION_DIMMER_MIN = 0.3f;

	public void CreateTextureArrays()
	{
		LocalAvatarConfig.ComponentMaterialProperties = new AvatarComponentMaterialProperties[5];
		LocalAvatarConfig.MaterialPropertyBlock.Colors = new Vector4[5];
		LocalAvatarConfig.MaterialPropertyBlock.DiffuseIntensities = new float[5];
		LocalAvatarConfig.MaterialPropertyBlock.RimIntensities = new float[5];
		LocalAvatarConfig.MaterialPropertyBlock.ReflectionIntensities = new float[5];
		for (int i = 0; i < LocalAvatarConfig.ComponentMaterialProperties.Length; i++)
		{
			LocalAvatarConfig.ComponentMaterialProperties[i].Textures = new Texture2D[3];
		}
		TextureArrays = new AvatarTextureArrayProperties[3];
	}

	public void SetRenderer(Renderer renderer)
	{
		TargetRenderer = renderer;
		TargetRenderer.GetClosestReflectionProbes(ReflectionProbes);
	}

	public void OnCombinedMeshReady()
	{
		InitTextureArrays();
		SetMaterialPropertyBlock();
		StartCoroutine(RunLoadingAnimation(DeleteTextureSet));
	}

	public void AddTextureIDToTextureManager(ulong assetID, bool isSingleComponent)
	{
		OvrAvatarSDKManager.Instance.GetTextureCopyManager().AddTextureIDToTextureSet(GetInstanceID(), assetID, isSingleComponent);
	}

	private void DeleteTextureSet()
	{
		OvrAvatarSDKManager.Instance.GetTextureCopyManager().DeleteTextureSet(GetInstanceID());
	}

	public void InitTextureArrays()
	{
		AvatarComponentMaterialProperties avatarComponentMaterialProperties = LocalAvatarConfig.ComponentMaterialProperties[0];
		for (int i = 0; i < TextureArrays.Length && i < avatarComponentMaterialProperties.Textures.Length; i++)
		{
			TextureArrays[i].TextureArray = new Texture2DArray(avatarComponentMaterialProperties.Textures[0].height, avatarComponentMaterialProperties.Textures[0].width, LocalAvatarConfig.ComponentMaterialProperties.Length, avatarComponentMaterialProperties.Textures[0].format, mipChain: true, (QualitySettings.activeColorSpace != ColorSpace.Gamma) ? true : false)
			{
				filterMode = FilterMode.Trilinear,
				anisoLevel = ((i == 2) ? 16 : 4)
			};
			TextureArrays[i].TextureArray.name = $"Texture Array Type: {(TextureType)i}";
			TextureArrays[i].Textures = new Texture2D[LocalAvatarConfig.ComponentMaterialProperties.Length];
			for (int j = 0; j < LocalAvatarConfig.ComponentMaterialProperties.Length; j++)
			{
				TextureArrays[i].Textures[j] = LocalAvatarConfig.ComponentMaterialProperties[j].Textures[i];
				TextureArrays[i].Textures[j].name = $"Texture Type: {(TextureType)i} Component: {j}";
			}
			ProcessTexturesWithMips(TextureArrays[i].Textures, avatarComponentMaterialProperties.Textures[i].height, TextureArrays[i].TextureArray);
		}
	}

	private void ProcessTexturesWithMips(Texture2D[] textures, int texArrayResolution, Texture2DArray texArray)
	{
		for (int i = 0; i < textures.Length; i++)
		{
			int num = texArrayResolution;
			for (int num2 = textures[i].mipmapCount - 1; num2 >= 0; num2--)
			{
				int mipSize = texArrayResolution / num;
				OvrAvatarSDKManager.Instance.GetTextureCopyManager().CopyTexture(textures[i], texArray, num2, mipSize, i, useQueue: false);
				num /= 2;
			}
		}
	}

	private void SetMaterialPropertyBlock()
	{
		if (TargetRenderer != null)
		{
			for (int i = 0; i < LocalAvatarConfig.ComponentMaterialProperties.Length; i++)
			{
				LocalAvatarConfig.MaterialPropertyBlock.Colors[i] = LocalAvatarConfig.ComponentMaterialProperties[i].Color;
				LocalAvatarConfig.MaterialPropertyBlock.DiffuseIntensities[i] = DiffuseIntensities[i];
				LocalAvatarConfig.MaterialPropertyBlock.RimIntensities[i] = RimIntensities[i];
				LocalAvatarConfig.MaterialPropertyBlock.ReflectionIntensities[i] = ReflectionIntensities[i];
			}
		}
	}

	private void ApplyMaterialPropertyBlock()
	{
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		materialPropertyBlock.SetVectorArray(AVATAR_SHADER_COLOR, LocalAvatarConfig.MaterialPropertyBlock.Colors);
		materialPropertyBlock.SetFloatArray(AVATAR_SHADER_DIFFUSEINTENSITY, LocalAvatarConfig.MaterialPropertyBlock.DiffuseIntensities);
		materialPropertyBlock.SetFloatArray(AVATAR_SHADER_RIMINTENSITY, LocalAvatarConfig.MaterialPropertyBlock.RimIntensities);
		materialPropertyBlock.SetFloatArray(AVATAR_SHADER_REFLECTIONINTENSITY, LocalAvatarConfig.MaterialPropertyBlock.ReflectionIntensities);
		TargetRenderer.GetClosestReflectionProbes(ReflectionProbes);
		if (ReflectionProbes != null && ReflectionProbes.Count > 0 && ReflectionProbes[0].probe.texture != null)
		{
			materialPropertyBlock.SetTexture(AVATAR_SHADER_CUBEMAP, ReflectionProbes[0].probe.texture);
		}
		for (int i = 0; i < TextureArrays.Length; i++)
		{
			materialPropertyBlock.SetTexture(TextureTypeToShaderProperties[i], TextureArrays[i].TextureArray);
		}
		TargetRenderer.SetPropertyBlock(materialPropertyBlock);
	}

	public static ovrAvatarBodyPartType GetComponentType(string objectName)
	{
		if (objectName.Contains("0"))
		{
			return ovrAvatarBodyPartType.Body;
		}
		if (objectName.Contains("1"))
		{
			return ovrAvatarBodyPartType.Clothing;
		}
		if (objectName.Contains("2"))
		{
			return ovrAvatarBodyPartType.Eyewear;
		}
		if (objectName.Contains("3"))
		{
			return ovrAvatarBodyPartType.Hair;
		}
		if (objectName.Contains("4"))
		{
			return ovrAvatarBodyPartType.Beard;
		}
		return ovrAvatarBodyPartType.Count;
	}

	private ulong GetTextureIDForType(ovrAvatarPBSMaterialState materialState, TextureType type)
	{
		switch (type)
		{
		case TextureType.DiffuseTextures:
			return materialState.albedoTextureID;
		case TextureType.NormalMaps:
			return materialState.normalTextureID;
		case TextureType.RoughnessMaps:
			return materialState.metallicnessTextureID;
		default:
			return 0uL;
		}
	}

	public void ValidateTextures(ovrAvatarPBSMaterialState[] materialStates)
	{
		AvatarComponentMaterialProperties[] componentMaterialProperties = LocalAvatarConfig.ComponentMaterialProperties;
		int[] array = new int[3];
		TextureFormat[] array2 = new TextureFormat[3];
		for (int i = 0; i < componentMaterialProperties.Length; i++)
		{
			for (int j = 0; j < componentMaterialProperties[i].Textures.Length; j++)
			{
				if (componentMaterialProperties[i].Textures[j] == null)
				{
					string text = componentMaterialProperties[i].TypeIndex.ToString();
					TextureType textureType = (TextureType)j;
					throw new Exception(text + "Invalid: " + textureType);
				}
				array[j] = componentMaterialProperties[i].Textures[j].height;
				array2[j] = componentMaterialProperties[i].Textures[j].format;
			}
		}
		for (int k = 0; k < 3; k++)
		{
			for (int l = 1; l < componentMaterialProperties.Length; l++)
			{
				if (componentMaterialProperties[l - 1].Textures[k].height != componentMaterialProperties[l].Textures[k].height)
				{
					object[] obj = new object[12]
					{
						componentMaterialProperties[l].TypeIndex.ToString(),
						" Mismatching Resolutions: ",
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null
					};
					TextureType textureType = (TextureType)k;
					obj[2] = textureType.ToString();
					obj[3] = " ";
					obj[4] = componentMaterialProperties[l - 1].Textures[k].height;
					obj[5] = " (ID: ";
					obj[6] = GetTextureIDForType(materialStates[l - 1], (TextureType)k);
					obj[7] = ") vs ";
					obj[8] = componentMaterialProperties[l].Textures[k].height;
					obj[9] = " (ID: ";
					obj[10] = GetTextureIDForType(materialStates[l], (TextureType)k);
					obj[11] = ") Ensure you are using ASTC texture compression on Android or turn off CombineMeshes";
					throw new Exception(string.Concat(obj));
				}
				if (componentMaterialProperties[l - 1].Textures[k].format != componentMaterialProperties[l].Textures[k].format)
				{
					object[] obj2 = new object[12]
					{
						componentMaterialProperties[l].TypeIndex.ToString(),
						" Mismatching Formats: ",
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null
					};
					TextureType textureType = (TextureType)k;
					obj2[2] = textureType.ToString();
					obj2[3] = " ";
					obj2[4] = componentMaterialProperties[l - 1].Textures[k].format;
					obj2[5] = " (ID: ";
					obj2[6] = GetTextureIDForType(materialStates[l - 1], (TextureType)k);
					obj2[7] = ") vs ";
					obj2[8] = componentMaterialProperties[l].Textures[k].format;
					obj2[9] = " (ID: ";
					obj2[10] = GetTextureIDForType(materialStates[l], (TextureType)k);
					obj2[11] = ") Ensure you are using ASTC texture compression on Android or turn off CombineMeshes";
					throw new Exception(string.Concat(obj2));
				}
			}
		}
	}

	private IEnumerator RunLoadingAnimation(Action callBack)
	{
		CombinedShader = TargetRenderer.sharedMaterial.shader;
		int srcBlend = TargetRenderer.sharedMaterial.GetInt("_SrcBlend");
		int dstBlend = TargetRenderer.sharedMaterial.GetInt("_DstBlend");
		string lightModeTag = TargetRenderer.sharedMaterial.GetTag("LightMode", searchFallbacks: false);
		string renderTypeTag = TargetRenderer.sharedMaterial.GetTag("RenderType", searchFallbacks: false);
		string renderQueueTag = TargetRenderer.sharedMaterial.GetTag("Queue", searchFallbacks: false);
		string ignoreProjectorTag = TargetRenderer.sharedMaterial.GetTag("IgnoreProjector", searchFallbacks: false);
		int renderQueue = TargetRenderer.sharedMaterial.renderQueue;
		bool transparentQueue = TargetRenderer.sharedMaterial.IsKeywordEnabled("_ALPHATEST_ON");
		TargetRenderer.sharedMaterial.shader = Shader.Find(AVATAR_SHADER_LOADER);
		TargetRenderer.sharedMaterial.SetColor(AVATAR_SHADER_COLOR, Color.white);
		while (OvrAvatarSDKManager.Instance.GetTextureCopyManager().GetTextureCount() > 0)
		{
			float value = (0.5f * Mathf.Sin(Time.timeSinceLevelLoad / 0.35f) + 0.5f) * 0.25f + 0.3f;
			TargetRenderer.sharedMaterial.SetFloat(AVATAR_SHADER_LOADING_DIMMER, value);
			yield return null;
		}
		TargetRenderer.sharedMaterial.SetFloat(AVATAR_SHADER_LOADING_DIMMER, 1f);
		TargetRenderer.sharedMaterial.shader = CombinedShader;
		TargetRenderer.sharedMaterial.SetInt("_SrcBlend", srcBlend);
		TargetRenderer.sharedMaterial.SetInt("_DstBlend", dstBlend);
		TargetRenderer.sharedMaterial.SetOverrideTag("LightMode", lightModeTag);
		TargetRenderer.sharedMaterial.SetOverrideTag("RenderType", renderTypeTag);
		TargetRenderer.sharedMaterial.SetOverrideTag("Queue", renderQueueTag);
		TargetRenderer.sharedMaterial.SetOverrideTag("IgnoreProjector", ignoreProjectorTag);
		if (transparentQueue)
		{
			TargetRenderer.sharedMaterial.EnableKeyword("_ALPHATEST_ON");
			TargetRenderer.sharedMaterial.EnableKeyword("_ALPHABLEND_ON");
			TargetRenderer.sharedMaterial.EnableKeyword("_ALPHAPREMULTIPLY_ON");
		}
		else
		{
			TargetRenderer.sharedMaterial.DisableKeyword("_ALPHATEST_ON");
			TargetRenderer.sharedMaterial.DisableKeyword("_ALPHABLEND_ON");
			TargetRenderer.sharedMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
		}
		TargetRenderer.sharedMaterial.renderQueue = renderQueue;
		ApplyMaterialPropertyBlock();
		callBack?.Invoke();
	}
}
