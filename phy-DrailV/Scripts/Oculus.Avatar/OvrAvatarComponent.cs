using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Oculus.Avatar;
using UnityEngine;

public class OvrAvatarComponent : MonoBehaviour
{
	public static readonly string[] LayerKeywords = new string[9] { "LAYERS_0", "LAYERS_1", "LAYERS_2", "LAYERS_3", "LAYERS_4", "LAYERS_5", "LAYERS_6", "LAYERS_7", "LAYERS_8" };

	public static readonly string[] LayerSampleModeParameters = new string[8] { "_LayerSampleMode0", "_LayerSampleMode1", "_LayerSampleMode2", "_LayerSampleMode3", "_LayerSampleMode4", "_LayerSampleMode5", "_LayerSampleMode6", "_LayerSampleMode7" };

	public static readonly string[] LayerBlendModeParameters = new string[8] { "_LayerBlendMode0", "_LayerBlendMode1", "_LayerBlendMode2", "_LayerBlendMode3", "_LayerBlendMode4", "_LayerBlendMode5", "_LayerBlendMode6", "_LayerBlendMode7" };

	public static readonly string[] LayerMaskTypeParameters = new string[8] { "_LayerMaskType0", "_LayerMaskType1", "_LayerMaskType2", "_LayerMaskType3", "_LayerMaskType4", "_LayerMaskType5", "_LayerMaskType6", "_LayerMaskType7" };

	public static readonly string[] LayerColorParameters = new string[8] { "_LayerColor0", "_LayerColor1", "_LayerColor2", "_LayerColor3", "_LayerColor4", "_LayerColor5", "_LayerColor6", "_LayerColor7" };

	public static readonly string[] LayerSurfaceParameters = new string[8] { "_LayerSurface0", "_LayerSurface1", "_LayerSurface2", "_LayerSurface3", "_LayerSurface4", "_LayerSurface5", "_LayerSurface6", "_LayerSurface7" };

	public static readonly string[] LayerSampleParametersParameters = new string[8] { "_LayerSampleParameters0", "_LayerSampleParameters1", "_LayerSampleParameters2", "_LayerSampleParameters3", "_LayerSampleParameters4", "_LayerSampleParameters5", "_LayerSampleParameters6", "_LayerSampleParameters7" };

	public static readonly string[] LayerMaskParametersParameters = new string[8] { "_LayerMaskParameters0", "_LayerMaskParameters1", "_LayerMaskParameters2", "_LayerMaskParameters3", "_LayerMaskParameters4", "_LayerMaskParameters5", "_LayerMaskParameters6", "_LayerMaskParameters7" };

	public static readonly string[] LayerMaskAxisParameters = new string[8] { "_LayerMaskAxis0", "_LayerMaskAxis1", "_LayerMaskAxis2", "_LayerMaskAxis3", "_LayerMaskAxis4", "_LayerMaskAxis5", "_LayerMaskAxis6", "_LayerMaskAxis7" };

	private Dictionary<Material, ovrAvatarMaterialState> materialStates = new Dictionary<Material, ovrAvatarMaterialState>();

	public List<OvrAvatarRenderComponent> RenderParts = new List<OvrAvatarRenderComponent>();

	protected OvrAvatar owner;

	protected ovrAvatarComponent nativeAvatarComponent;

	public void SetOvrAvatarOwner(OvrAvatar ovrAvatarOwner)
	{
		owner = ovrAvatarOwner;
	}

	public void UpdateAvatar(IntPtr nativeComponent)
	{
		CAPI.ovrAvatarComponent_Get(nativeComponent, includeName: false, ref nativeAvatarComponent);
		OvrAvatar.ConvertTransform(nativeAvatarComponent.transform, base.transform);
		for (uint num = 0u; num < nativeAvatarComponent.renderPartCount && RenderParts.Count > num; num++)
		{
			OvrAvatarRenderComponent ovrAvatarRenderComponent = RenderParts[(int)num];
			IntPtr renderPart = OvrAvatar.GetRenderPart(nativeAvatarComponent, num);
			switch (CAPI.ovrAvatarRenderPart_GetType(renderPart))
			{
			case ovrAvatarRenderPartType.SkinnedMeshRender:
				((OvrAvatarSkinnedMeshRenderComponent)ovrAvatarRenderComponent).UpdateSkinnedMeshRender(this, owner, renderPart);
				break;
			case ovrAvatarRenderPartType.SkinnedMeshRenderPBS:
				((OvrAvatarSkinnedMeshRenderPBSComponent)ovrAvatarRenderComponent).UpdateSkinnedMeshRenderPBS(owner, renderPart, ovrAvatarRenderComponent.mesh.sharedMaterial);
				break;
			case ovrAvatarRenderPartType.SkinnedMeshRenderPBS_V2:
				((OvrAvatarSkinnedMeshPBSV2RenderComponent)ovrAvatarRenderComponent).UpdateSkinnedMeshRender(this, owner, renderPart);
				break;
			}
		}
	}

	protected void UpdateActive(OvrAvatar avatar, ovrAvatarVisibilityFlags mask)
	{
		bool flag = avatar.ShowFirstPerson && (mask & ovrAvatarVisibilityFlags.FirstPerson) != 0;
		flag |= avatar.ShowThirdPerson && (mask & ovrAvatarVisibilityFlags.ThirdPerson) != 0;
		base.gameObject.SetActive(flag);
	}

	public void UpdateAvatarMaterial(Material mat, ovrAvatarMaterialState matState)
	{
		mat.SetColor("_BaseColor", matState.baseColor);
		mat.SetInt("_BaseMaskType", (int)matState.baseMaskType);
		mat.SetVector("_BaseMaskParameters", matState.baseMaskParameters);
		mat.SetVector("_BaseMaskAxis", matState.baseMaskAxis);
		if (matState.alphaMaskTextureID != 0L)
		{
			mat.SetTexture("_AlphaMask", GetLoadedTexture(matState.alphaMaskTextureID));
			mat.SetTextureScale("_AlphaMask", new Vector2(matState.alphaMaskScaleOffset.x, matState.alphaMaskScaleOffset.y));
			mat.SetTextureOffset("_AlphaMask", new Vector2(matState.alphaMaskScaleOffset.z, matState.alphaMaskScaleOffset.w));
		}
		if (matState.normalMapTextureID != 0L)
		{
			mat.EnableKeyword("NORMAL_MAP_ON");
			mat.SetTexture("_NormalMap", GetLoadedTexture(matState.normalMapTextureID));
			mat.SetTextureScale("_NormalMap", new Vector2(matState.normalMapScaleOffset.x, matState.normalMapScaleOffset.y));
			mat.SetTextureOffset("_NormalMap", new Vector2(matState.normalMapScaleOffset.z, matState.normalMapScaleOffset.w));
		}
		if (matState.parallaxMapTextureID != 0L)
		{
			mat.SetTexture("_ParallaxMap", GetLoadedTexture(matState.parallaxMapTextureID));
			mat.SetTextureScale("_ParallaxMap", new Vector2(matState.parallaxMapScaleOffset.x, matState.parallaxMapScaleOffset.y));
			mat.SetTextureOffset("_ParallaxMap", new Vector2(matState.parallaxMapScaleOffset.z, matState.parallaxMapScaleOffset.w));
		}
		if (matState.roughnessMapTextureID != 0L)
		{
			mat.EnableKeyword("ROUGHNESS_ON");
			mat.SetTexture("_RoughnessMap", GetLoadedTexture(matState.roughnessMapTextureID));
			mat.SetTextureScale("_RoughnessMap", new Vector2(matState.roughnessMapScaleOffset.x, matState.roughnessMapScaleOffset.y));
			mat.SetTextureOffset("_RoughnessMap", new Vector2(matState.roughnessMapScaleOffset.z, matState.roughnessMapScaleOffset.w));
		}
		mat.EnableKeyword(LayerKeywords[matState.layerCount]);
		for (ulong num = 0uL; num < matState.layerCount; num++)
		{
			ovrAvatarMaterialLayerState ovrAvatarMaterialLayerState2 = matState.layers[num];
			mat.SetInt(LayerSampleModeParameters[num], (int)ovrAvatarMaterialLayerState2.sampleMode);
			mat.SetInt(LayerBlendModeParameters[num], (int)ovrAvatarMaterialLayerState2.blendMode);
			mat.SetInt(LayerMaskTypeParameters[num], (int)ovrAvatarMaterialLayerState2.maskType);
			mat.SetColor(LayerColorParameters[num], ovrAvatarMaterialLayerState2.layerColor);
			if (ovrAvatarMaterialLayerState2.sampleMode != ovrAvatarMaterialLayerSampleMode.Color)
			{
				string text = LayerSurfaceParameters[num];
				mat.SetTexture(text, GetLoadedTexture(ovrAvatarMaterialLayerState2.sampleTexture));
				mat.SetTextureScale(text, new Vector2(ovrAvatarMaterialLayerState2.sampleScaleOffset.x, ovrAvatarMaterialLayerState2.sampleScaleOffset.y));
				mat.SetTextureOffset(text, new Vector2(ovrAvatarMaterialLayerState2.sampleScaleOffset.z, ovrAvatarMaterialLayerState2.sampleScaleOffset.w));
			}
			if (ovrAvatarMaterialLayerState2.sampleMode == ovrAvatarMaterialLayerSampleMode.Parallax)
			{
				mat.EnableKeyword("PARALLAX_ON");
			}
			mat.SetColor(LayerSampleParametersParameters[num], ovrAvatarMaterialLayerState2.sampleParameters);
			mat.SetColor(LayerMaskParametersParameters[num], ovrAvatarMaterialLayerState2.maskParameters);
			mat.SetColor(LayerMaskAxisParameters[num], ovrAvatarMaterialLayerState2.maskAxis);
		}
		materialStates[mat] = matState;
	}

	public static Texture2D GetLoadedTexture(ulong assetId)
	{
		return ((OvrAvatarAssetTexture)OvrAvatarSDKManager.Instance.GetAsset(assetId))?.texture;
	}
}
public struct ovrAvatarComponent
{
	public ovrAvatarTransform transform;

	public uint renderPartCount;

	public IntPtr renderParts;

	[MarshalAs(UnmanagedType.LPStr)]
	public string name;
}
