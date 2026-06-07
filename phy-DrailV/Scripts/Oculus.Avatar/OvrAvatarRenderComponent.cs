using System;
using Oculus.Avatar;
using UnityEngine;
using UnityEngine.Rendering;

public class OvrAvatarRenderComponent : MonoBehaviour
{
	private bool firstSkinnedUpdate = true;

	public SkinnedMeshRenderer mesh;

	public Transform[] bones;

	private bool isBodyComponent;

	protected void UpdateActive(OvrAvatar avatar, ovrAvatarVisibilityFlags mask)
	{
		if (isBodyComponent && avatar.EnableExpressive && avatar.ShowFirstPerson && !avatar.ShowThirdPerson)
		{
			bool num = (mask & ovrAvatarVisibilityFlags.FirstPerson) != 0;
			bool flag = (mask & ovrAvatarVisibilityFlags.ThirdPerson) != 0;
			base.gameObject.SetActive(flag || flag);
			if (!num)
			{
				mesh.enabled = false;
			}
		}
		else
		{
			bool flag2 = avatar.ShowFirstPerson && (mask & ovrAvatarVisibilityFlags.FirstPerson) != 0;
			flag2 |= avatar.ShowThirdPerson && (mask & ovrAvatarVisibilityFlags.ThirdPerson) != 0;
			base.gameObject.SetActive(flag2);
			mesh.enabled = flag2;
		}
	}

	protected SkinnedMeshRenderer CreateSkinnedMesh(ulong assetID, ovrAvatarVisibilityFlags visibilityMask, int thirdPersonLayer, int firstPersonLayer)
	{
		isBodyComponent = base.name.Contains("body");
		OvrAvatarAssetMesh obj = ((OvrAvatarAssetMesh)OvrAvatarSDKManager.Instance.GetAsset(assetID)) ?? throw new Exception("Couldn't find mesh for asset " + assetID);
		if ((visibilityMask & ovrAvatarVisibilityFlags.ThirdPerson) != 0)
		{
			base.gameObject.layer = thirdPersonLayer;
		}
		else
		{
			base.gameObject.layer = firstPersonLayer;
		}
		SkinnedMeshRenderer skinnedMeshRenderer = obj.CreateSkinnedMeshRendererOnObject(base.gameObject);
		skinnedMeshRenderer.quality = SkinQuality.Bone4;
		skinnedMeshRenderer.updateWhenOffscreen = true;
		if ((visibilityMask & ovrAvatarVisibilityFlags.SelfOccluding) == 0)
		{
			skinnedMeshRenderer.shadowCastingMode = ShadowCastingMode.Off;
		}
		base.gameObject.SetActive(value: false);
		return skinnedMeshRenderer;
	}

	protected void UpdateSkinnedMesh(OvrAvatar avatar, Transform[] bones, ovrAvatarTransform localTransform, ovrAvatarVisibilityFlags visibilityMask, IntPtr renderPart)
	{
		UpdateActive(avatar, visibilityMask);
		OvrAvatar.ConvertTransform(localTransform, base.transform);
		ovrAvatarRenderPartType ovrAvatarRenderPartType2 = CAPI.ovrAvatarRenderPart_GetType(renderPart);
		ulong num;
		switch (ovrAvatarRenderPartType2)
		{
		case ovrAvatarRenderPartType.SkinnedMeshRender:
			num = CAPI.ovrAvatarSkinnedMeshRender_GetDirtyJoints(renderPart);
			break;
		case ovrAvatarRenderPartType.SkinnedMeshRenderPBS:
			num = CAPI.ovrAvatarSkinnedMeshRenderPBS_GetDirtyJoints(renderPart);
			break;
		case ovrAvatarRenderPartType.SkinnedMeshRenderPBS_V2:
			num = CAPI.ovrAvatarSkinnedMeshRenderPBSV2_GetDirtyJoints(renderPart);
			break;
		default:
			throw new Exception("Unhandled render part type: " + ovrAvatarRenderPartType2);
		}
		for (uint num2 = 0u; num2 < 64; num2++)
		{
			ulong num3 = (ulong)(1L << (int)num2);
			if ((firstSkinnedUpdate && num2 < bones.Length) || (num3 & num) != 0L)
			{
				Transform target = bones[num2];
				ovrAvatarTransform ovrAvatarTransform2;
				switch (ovrAvatarRenderPartType2)
				{
				case ovrAvatarRenderPartType.SkinnedMeshRender:
					ovrAvatarTransform2 = CAPI.ovrAvatarSkinnedMeshRender_GetJointTransform(renderPart, num2);
					break;
				case ovrAvatarRenderPartType.SkinnedMeshRenderPBS:
					ovrAvatarTransform2 = CAPI.ovrAvatarSkinnedMeshRenderPBS_GetJointTransform(renderPart, num2);
					break;
				case ovrAvatarRenderPartType.SkinnedMeshRenderPBS_V2:
					ovrAvatarTransform2 = CAPI.ovrAvatarSkinnedMeshRenderPBSV2_GetJointTransform(renderPart, num2);
					break;
				default:
					throw new Exception("Unhandled render part type: " + ovrAvatarRenderPartType2);
				}
				OvrAvatar.ConvertTransform(ovrAvatarTransform2, target);
			}
		}
		firstSkinnedUpdate = false;
	}

	protected Material CreateAvatarMaterial(string name, Shader shader)
	{
		if (shader == null)
		{
			throw new Exception("No shader provided for avatar material.");
		}
		return new Material(shader)
		{
			name = name
		};
	}
}
