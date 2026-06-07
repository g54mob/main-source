using System;
using Oculus.Avatar;
using UnityEngine;

public class OvrAvatarSkinnedMeshPBSV2RenderComponent : OvrAvatarRenderComponent
{
	private OvrAvatarMaterialManager avatarMaterialManager;

	private bool previouslyActive;

	private bool isCombinedMaterial;

	private ovrAvatarExpressiveParameters ExpressiveParameters;

	private bool EnableExpressive;

	private int blendShapeCount;

	private ovrAvatarBlendShapeParams blendShapeParams;

	private const string MAIN_MATERIAL_NAME = "main_material";

	private const string EYE_MATERIAL_NAME = "eye_material";

	private const string DEFAULT_MATERIAL_NAME = "_material";

	internal void Initialize(IntPtr renderPart, ovrAvatarRenderPart_SkinnedMeshRenderPBS_V2 skinnedMeshRender, OvrAvatarMaterialManager materialManager, int thirdPersonLayer, int firstPersonLayer, bool combinedMesh, ovrAvatarAssetLevelOfDetail lod, bool assignExpressiveParams, OvrAvatar avatar, bool isControllerModel)
	{
		avatarMaterialManager = materialManager;
		isCombinedMaterial = combinedMesh;
		mesh = CreateSkinnedMesh(skinnedMeshRender.meshAssetID, skinnedMeshRender.visibilityMask, thirdPersonLayer, firstPersonLayer);
		EnableExpressive = assignExpressiveParams;
		Shader shader = (EnableExpressive ? avatar.Skinshaded_Expressive_SurfaceShader_SingleComponent : avatar.Skinshaded_SurfaceShader_SingleComponent);
		Shader shader2 = (EnableExpressive ? avatar.Skinshaded_Expressive_VertFrag_CombinedMesh : avatar.Skinshaded_VertFrag_CombinedMesh);
		Shader shader3 = (isCombinedMaterial ? shader2 : shader);
		if (isControllerModel)
		{
			shader3 = avatar.ControllerShader;
		}
		if (EnableExpressive)
		{
			ExpressiveParameters = CAPI.ovrAvatar_GetExpressiveParameters(avatar.sdkAvatar);
			Shader eyeLens = avatar.EyeLens;
			Material[] array = new Material[2]
			{
				CreateAvatarMaterial(base.gameObject.name + "main_material", shader3),
				CreateAvatarMaterial(base.gameObject.name + "eye_material", eyeLens)
			};
			if (avatar.UseTransparentRenderQueue)
			{
				SetMaterialTransparent(array[0]);
			}
			else
			{
				SetMaterialOpaque(array[0]);
			}
			array[1].renderQueue = -1;
			mesh.materials = array;
		}
		else
		{
			mesh.sharedMaterial = CreateAvatarMaterial(base.gameObject.name + "_material", shader3);
			if (avatar.UseTransparentRenderQueue && !isControllerModel)
			{
				SetMaterialTransparent(mesh.sharedMaterial);
			}
			else
			{
				SetMaterialOpaque(mesh.sharedMaterial);
			}
		}
		bones = mesh.bones;
		if (isCombinedMaterial)
		{
			avatarMaterialManager.SetRenderer(mesh);
			InitializeCombinedMaterial(renderPart, (int)lod);
			avatarMaterialManager.OnCombinedMeshReady();
		}
		blendShapeParams = default(ovrAvatarBlendShapeParams);
		blendShapeParams.blendShapeParamCount = 0u;
		blendShapeParams.blendShapeParams = new float[64];
		blendShapeCount = mesh.sharedMesh.blendShapeCount;
	}

	public void UpdateSkinnedMeshRender(OvrAvatarComponent component, OvrAvatar avatar, IntPtr renderPart)
	{
		ovrAvatarVisibilityFlags visibilityMask = CAPI.ovrAvatarSkinnedMeshRenderPBSV2_GetVisibilityMask(renderPart);
		ovrAvatarTransform localTransform = CAPI.ovrAvatarSkinnedMeshRenderPBSV2_GetTransform(renderPart);
		UpdateSkinnedMesh(avatar, bones, localTransform, visibilityMask, renderPart);
		bool activeSelf = base.gameObject.activeSelf;
		if (mesh != null && !previouslyActive && activeSelf && !isCombinedMaterial)
		{
			InitializeSingleComponentMaterial(renderPart, (int)(avatar.LevelOfDetail - 1));
		}
		if (blendShapeCount > 0)
		{
			CAPI.ovrAvatarSkinnedMeshRender_GetBlendShapeParams(renderPart, ref blendShapeParams);
			for (uint num = 0u; num < blendShapeParams.blendShapeParamCount && num < blendShapeCount; num++)
			{
				float num2 = blendShapeParams.blendShapeParams[num];
				mesh.SetBlendShapeWeight((int)num, num2 * 100f);
			}
		}
		previouslyActive = activeSelf;
	}

	private void InitializeSingleComponentMaterial(IntPtr renderPart, int lodIndex)
	{
		ovrAvatarPBSMaterialState ovrAvatarPBSMaterialState2 = CAPI.ovrAvatarSkinnedMeshRenderPBSV2_GetPBSMaterialState(renderPart);
		int componentType = (int)OvrAvatarMaterialManager.GetComponentType(base.gameObject.name);
		Texture2D texture2D = OvrAvatarComponent.GetLoadedTexture(ovrAvatarPBSMaterialState2.albedoTextureID);
		Texture2D texture2D2 = OvrAvatarComponent.GetLoadedTexture(ovrAvatarPBSMaterialState2.normalTextureID);
		Texture2D texture2D3 = OvrAvatarComponent.GetLoadedTexture(ovrAvatarPBSMaterialState2.metallicnessTextureID);
		if (texture2D != null)
		{
			avatarMaterialManager.AddTextureIDToTextureManager(ovrAvatarPBSMaterialState2.albedoTextureID, isSingleComponent: true);
		}
		else
		{
			texture2D = OvrAvatarSDKManager.Instance.GetTextureCopyManager().FallbackTextureSets[lodIndex].DiffuseRoughness;
		}
		texture2D.anisoLevel = 4;
		if (texture2D2 != null)
		{
			avatarMaterialManager.AddTextureIDToTextureManager(ovrAvatarPBSMaterialState2.normalTextureID, isSingleComponent: true);
		}
		else
		{
			texture2D2 = OvrAvatarSDKManager.Instance.GetTextureCopyManager().FallbackTextureSets[lodIndex].Normal;
		}
		texture2D2.anisoLevel = 4;
		if (texture2D3 != null)
		{
			avatarMaterialManager.AddTextureIDToTextureManager(ovrAvatarPBSMaterialState2.metallicnessTextureID, isSingleComponent: true);
		}
		else
		{
			texture2D3 = OvrAvatarSDKManager.Instance.GetTextureCopyManager().FallbackTextureSets[lodIndex].DiffuseRoughness;
		}
		texture2D3.anisoLevel = 16;
		mesh.materials[0].SetTexture(OvrAvatarMaterialManager.AVATAR_SHADER_MAINTEX, texture2D);
		mesh.materials[0].SetTexture(OvrAvatarMaterialManager.AVATAR_SHADER_NORMALMAP, texture2D2);
		mesh.materials[0].SetTexture(OvrAvatarMaterialManager.AVATAR_SHADER_ROUGHNESSMAP, texture2D3);
		mesh.materials[0].SetVector(OvrAvatarMaterialManager.AVATAR_SHADER_COLOR, ovrAvatarPBSMaterialState2.albedoMultiplier);
		mesh.materials[0].SetFloat(OvrAvatarMaterialManager.AVATAR_SHADER_DIFFUSEINTENSITY, OvrAvatarMaterialManager.DiffuseIntensities[componentType]);
		mesh.materials[0].SetFloat(OvrAvatarMaterialManager.AVATAR_SHADER_RIMINTENSITY, OvrAvatarMaterialManager.RimIntensities[componentType]);
		mesh.materials[0].SetFloat(OvrAvatarMaterialManager.AVATAR_SHADER_REFLECTIONINTENSITY, OvrAvatarMaterialManager.ReflectionIntensities[componentType]);
		mesh.GetClosestReflectionProbes(avatarMaterialManager.ReflectionProbes);
		if (avatarMaterialManager.ReflectionProbes != null && avatarMaterialManager.ReflectionProbes.Count > 0)
		{
			mesh.materials[0].SetTexture(OvrAvatarMaterialManager.AVATAR_SHADER_CUBEMAP, avatarMaterialManager.ReflectionProbes[0].probe.texture);
		}
		if (EnableExpressive)
		{
			mesh.materials[0].SetVector(OvrAvatarMaterialManager.AVATAR_SHADER_IRIS_COLOR, ExpressiveParameters.irisColor);
			mesh.materials[0].SetVector(OvrAvatarMaterialManager.AVATAR_SHADER_LIP_COLOR, ExpressiveParameters.lipColor);
			mesh.materials[0].SetVector(OvrAvatarMaterialManager.AVATAR_SHADER_BROW_COLOR, ExpressiveParameters.browColor);
			mesh.materials[0].SetVector(OvrAvatarMaterialManager.AVATAR_SHADER_LASH_COLOR, ExpressiveParameters.lashColor);
			mesh.materials[0].SetVector(OvrAvatarMaterialManager.AVATAR_SHADER_SCLERA_COLOR, ExpressiveParameters.scleraColor);
			mesh.materials[0].SetVector(OvrAvatarMaterialManager.AVATAR_SHADER_GUM_COLOR, ExpressiveParameters.gumColor);
			mesh.materials[0].SetVector(OvrAvatarMaterialManager.AVATAR_SHADER_TEETH_COLOR, ExpressiveParameters.teethColor);
			mesh.materials[0].SetFloat(OvrAvatarMaterialManager.AVATAR_SHADER_LIP_SMOOTHNESS, ExpressiveParameters.lipSmoothness);
		}
	}

	private void InitializeCombinedMaterial(IntPtr renderPart, int lodIndex)
	{
		ovrAvatarPBSMaterialState[] array = CAPI.ovrAvatar_GetBodyPBSMaterialStates(renderPart);
		if (array.Length != 5)
		{
			return;
		}
		avatarMaterialManager.CreateTextureArrays();
		OvrAvatarMaterialManager.AvatarComponentMaterialProperties[] componentMaterialProperties = avatarMaterialManager.LocalAvatarConfig.ComponentMaterialProperties;
		for (int i = 0; i < array.Length; i++)
		{
			componentMaterialProperties[i].TypeIndex = (ovrAvatarBodyPartType)i;
			componentMaterialProperties[i].Color = array[i].albedoMultiplier;
			componentMaterialProperties[i].DiffuseIntensity = OvrAvatarMaterialManager.DiffuseIntensities[i];
			componentMaterialProperties[i].RimIntensity = OvrAvatarMaterialManager.RimIntensities[i];
			componentMaterialProperties[i].ReflectionIntensity = OvrAvatarMaterialManager.ReflectionIntensities[i];
			Texture2D loadedTexture = OvrAvatarComponent.GetLoadedTexture(array[i].albedoTextureID);
			Texture2D loadedTexture2 = OvrAvatarComponent.GetLoadedTexture(array[i].normalTextureID);
			Texture2D loadedTexture3 = OvrAvatarComponent.GetLoadedTexture(array[i].metallicnessTextureID);
			if (loadedTexture != null)
			{
				componentMaterialProperties[i].Textures[0] = loadedTexture;
				avatarMaterialManager.AddTextureIDToTextureManager(array[i].albedoTextureID, isSingleComponent: false);
			}
			else
			{
				componentMaterialProperties[i].Textures[0] = OvrAvatarSDKManager.Instance.GetTextureCopyManager().FallbackTextureSets[lodIndex].DiffuseRoughness;
			}
			componentMaterialProperties[i].Textures[0].anisoLevel = 4;
			if (loadedTexture2 != null)
			{
				componentMaterialProperties[i].Textures[1] = loadedTexture2;
				avatarMaterialManager.AddTextureIDToTextureManager(array[i].normalTextureID, isSingleComponent: false);
			}
			else
			{
				componentMaterialProperties[i].Textures[1] = OvrAvatarSDKManager.Instance.GetTextureCopyManager().FallbackTextureSets[lodIndex].Normal;
			}
			componentMaterialProperties[i].Textures[1].anisoLevel = 4;
			if (loadedTexture3 != null)
			{
				componentMaterialProperties[i].Textures[2] = loadedTexture3;
				avatarMaterialManager.AddTextureIDToTextureManager(array[i].metallicnessTextureID, isSingleComponent: false);
			}
			else
			{
				componentMaterialProperties[i].Textures[2] = OvrAvatarSDKManager.Instance.GetTextureCopyManager().FallbackTextureSets[lodIndex].DiffuseRoughness;
			}
			componentMaterialProperties[i].Textures[2].anisoLevel = 16;
		}
		if (EnableExpressive)
		{
			mesh.materials[0].SetVector(OvrAvatarMaterialManager.AVATAR_SHADER_IRIS_COLOR, ExpressiveParameters.irisColor);
			mesh.materials[0].SetVector(OvrAvatarMaterialManager.AVATAR_SHADER_LIP_COLOR, ExpressiveParameters.lipColor);
			mesh.materials[0].SetVector(OvrAvatarMaterialManager.AVATAR_SHADER_BROW_COLOR, ExpressiveParameters.browColor);
			mesh.materials[0].SetVector(OvrAvatarMaterialManager.AVATAR_SHADER_LASH_COLOR, ExpressiveParameters.lashColor);
			mesh.materials[0].SetVector(OvrAvatarMaterialManager.AVATAR_SHADER_SCLERA_COLOR, ExpressiveParameters.scleraColor);
			mesh.materials[0].SetVector(OvrAvatarMaterialManager.AVATAR_SHADER_GUM_COLOR, ExpressiveParameters.gumColor);
			mesh.materials[0].SetVector(OvrAvatarMaterialManager.AVATAR_SHADER_TEETH_COLOR, ExpressiveParameters.teethColor);
			mesh.materials[0].SetFloat(OvrAvatarMaterialManager.AVATAR_SHADER_LIP_SMOOTHNESS, ExpressiveParameters.lipSmoothness);
		}
		avatarMaterialManager.ValidateTextures(array);
	}

	private void SetMaterialTransparent(Material mat)
	{
		mat.SetOverrideTag("Queue", "Transparent");
		mat.SetOverrideTag("RenderType", "Transparent");
		mat.SetInt("_SrcBlend", 5);
		mat.SetInt("_DstBlend", 10);
		mat.EnableKeyword("_ALPHATEST_ON");
		mat.EnableKeyword("_ALPHABLEND_ON");
		mat.EnableKeyword("_ALPHAPREMULTIPLY_ON");
		mat.renderQueue = 3000;
	}

	private void SetMaterialOpaque(Material mat)
	{
		mat.SetOverrideTag("Queue", "Geometry");
		mat.SetOverrideTag("RenderType", "Opaque");
		mat.SetInt("_SrcBlend", 1);
		mat.SetInt("_DstBlend", 0);
		mat.DisableKeyword("_ALPHATEST_ON");
		mat.DisableKeyword("_ALPHABLEND_ON");
		mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
		mat.renderQueue = 2000;
	}
}
