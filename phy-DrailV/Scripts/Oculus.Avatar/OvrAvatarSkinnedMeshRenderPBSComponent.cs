using System;
using Oculus.Avatar;
using UnityEngine;

public class OvrAvatarSkinnedMeshRenderPBSComponent : OvrAvatarRenderComponent
{
	private bool isMaterialInitilized;

	internal void Initialize(ovrAvatarRenderPart_SkinnedMeshRenderPBS skinnedMeshRenderPBS, Shader shader, int thirdPersonLayer, int firstPersonLayer)
	{
		if (shader == null)
		{
			shader = Shader.Find("OvrAvatar/AvatarSurfaceShaderPBS");
		}
		mesh = CreateSkinnedMesh(skinnedMeshRenderPBS.meshAssetID, skinnedMeshRenderPBS.visibilityMask, thirdPersonLayer, firstPersonLayer);
		mesh.sharedMaterial = CreateAvatarMaterial(base.gameObject.name + "_material", shader);
		bones = mesh.bones;
	}

	internal void UpdateSkinnedMeshRenderPBS(OvrAvatar avatar, IntPtr renderPart, Material mat)
	{
		if (!isMaterialInitilized)
		{
			isMaterialInitilized = true;
			ulong assetId = CAPI.ovrAvatarSkinnedMeshRenderPBS_GetAlbedoTextureAssetID(renderPart);
			ulong assetId2 = CAPI.ovrAvatarSkinnedMeshRenderPBS_GetSurfaceTextureAssetID(renderPart);
			mat.SetTexture("_Albedo", OvrAvatarComponent.GetLoadedTexture(assetId));
			mat.SetTexture("_Surface", OvrAvatarComponent.GetLoadedTexture(assetId2));
		}
		ovrAvatarVisibilityFlags visibilityMask = CAPI.ovrAvatarSkinnedMeshRenderPBS_GetVisibilityMask(renderPart);
		ovrAvatarTransform localTransform = CAPI.ovrAvatarSkinnedMeshRenderPBS_GetTransform(renderPart);
		UpdateSkinnedMesh(avatar, bones, localTransform, visibilityMask, renderPart);
	}
}
