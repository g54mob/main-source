using System;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;

namespace Oculus.Avatar
{
	public class CAPI
	{
		public delegate void LoggingDelegate(IntPtr str);

		public enum Result
		{
			Success = 0,
			Failure = -1000,
			Failure_InvalidParameter = -1001,
			Failure_NotInitialized = -1002,
			Failure_InvalidOperation = -1003,
			Failure_Unsupported = -1004,
			Failure_NotYetImplemented = -1005,
			Failure_OperationFailed = -1006,
			Failure_InsufficientSize = -1007
		}

		private static class OVRP_1_30_0
		{
			public static readonly Version version = new Version(1, 30, 0);

			[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
			public static extern Result ovrp_SendEvent2(string name, string param, string source);
		}

		private const string LibFile = "libovravatar";

		public static readonly Version AvatarSDKVersion = new Version(1, 36, 0);

		private static IntPtr nativeVisemeData = IntPtr.Zero;

		private static IntPtr nativeGazeTargetsData = IntPtr.Zero;

		private static IntPtr nativeAvatarLightsData = IntPtr.Zero;

		private static IntPtr DebugLineCountData = IntPtr.Zero;

		private static float[] scratchBufferFloat = new float[16];

		private static GameObject debugLineGo;

		private static string SDKRuntimePrefix = "[RUNTIME] - ";

		private const string ovrPluginDLL = "OVRPlugin";

		private static Version ovrPluginVersion;

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_Initialize(string appID);

		public static void Initialize()
		{
			nativeVisemeData = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ovrAvatarVisemes)));
			nativeGazeTargetsData = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ovrAvatarGazeTargets)));
			nativeAvatarLightsData = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ovrAvatarLights)));
			DebugLineCountData = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(uint)));
			debugLineGo = new GameObject();
			debugLineGo.name = "AvatarSDKDebugDrawHelper";
		}

		public static void Shutdown()
		{
			Marshal.FreeHGlobal(nativeVisemeData);
			Marshal.FreeHGlobal(nativeGazeTargetsData);
			Marshal.FreeHGlobal(nativeAvatarLightsData);
			Marshal.FreeHGlobal(DebugLineCountData);
			debugLineGo = null;
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_Shutdown();

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovrAvatarMessage_Pop();

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern ovrAvatarMessageType ovrAvatarMessage_GetType(IntPtr msg);

		public static ovrAvatarMessage_AvatarSpecification ovrAvatarMessage_GetAvatarSpecification(IntPtr msg)
		{
			return (ovrAvatarMessage_AvatarSpecification)Marshal.PtrToStructure(ovrAvatarMessage_GetAvatarSpecification_Native(msg), typeof(ovrAvatarMessage_AvatarSpecification));
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatarMessage_GetAvatarSpecification")]
		private static extern IntPtr ovrAvatarMessage_GetAvatarSpecification_Native(IntPtr msg);

		public static ovrAvatarMessage_AssetLoaded ovrAvatarMessage_GetAssetLoaded(IntPtr msg)
		{
			return (ovrAvatarMessage_AssetLoaded)Marshal.PtrToStructure(ovrAvatarMessage_GetAssetLoaded_Native(msg), typeof(ovrAvatarMessage_AssetLoaded));
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatarMessage_GetAssetLoaded")]
		private static extern IntPtr ovrAvatarMessage_GetAssetLoaded_Native(IntPtr msg);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatarMessage_Free(IntPtr msg);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovrAvatarSpecificationRequest_Create(ulong userID);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatarSpecificationRequest_Destroy(IntPtr specificationRequest);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatarSpecificationRequest_SetCombineMeshes(IntPtr specificationRequest, bool useCombinedMesh);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatarSpecificationRequest_SetLookAndFeelVersion(IntPtr specificationRequest, ovrAvatarLookAndFeelVersion version);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatarSpecificationRequest_SetLevelOfDetail(IntPtr specificationRequest, ovrAvatarAssetLevelOfDetail lod);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_RequestAvatarSpecification(ulong userID);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_RequestAvatarSpecificationFromSpecRequest(IntPtr specificationRequest);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatarSpecificationRequest_SetFallbackLookAndFeelVersion(IntPtr specificationRequest, ovrAvatarLookAndFeelVersion version);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatarSpecificationRequest_SetExpressiveFlag(IntPtr specificationRequest, bool enable);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovrAvatar_Create(IntPtr avatarSpecification, ovrAvatarCapabilities capabilities);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_Destroy(IntPtr avatar);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatarPose_UpdateBody(IntPtr avatar, ovrAvatarTransform headPose);

		public static void ovrAvatarPose_UpdateVoiceVisualization(IntPtr avatar, float[] pcmData)
		{
			ovrAvatarPose_UpdateVoiceVisualization_Native(avatar, (uint)pcmData.Length, pcmData);
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatarPose_UpdateVoiceVisualization")]
		private static extern void ovrAvatarPose_UpdateVoiceVisualization_Native(IntPtr avatar, uint pcmDataSize, [In] float[] pcmData);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatarPose_UpdateHands(IntPtr avatar, ovrAvatarHandInputState inputStateLeft, ovrAvatarHandInputState inputStateRight);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatarPose_UpdateHandsWithType(IntPtr avatar, ovrAvatarHandInputState inputStateLeft, ovrAvatarHandInputState inputStateRight, ovrAvatarControllerType type);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatarPose_Finalize(IntPtr avatar, float elapsedSeconds);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_SetLeftControllerVisibility(IntPtr avatar, bool show);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_SetRightControllerVisibility(IntPtr avatar, bool show);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_SetLeftHandVisibility(IntPtr avatar, bool show);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_SetRightHandVisibility(IntPtr avatar, bool show);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovrAvatarComponent_Count(IntPtr avatar);

		public static void ovrAvatarComponent_Get(IntPtr avatar, uint index, bool includeName, ref ovrAvatarComponent component)
		{
			ovrAvatarComponent_Get(ovrAvatarComponent_Get_Native(avatar, index), includeName, ref component);
		}

		public static void ovrAvatarComponent_Get(IntPtr componentPtr, bool includeName, ref ovrAvatarComponent component)
		{
			Marshal.Copy(new IntPtr(componentPtr.ToInt64() + ovrAvatarComponent_Offsets.transform), scratchBufferFloat, 0, 10);
			OvrAvatar.ConvertTransform(scratchBufferFloat, ref component.transform);
			component.renderPartCount = (uint)Marshal.ReadInt32(componentPtr, ovrAvatarComponent_Offsets.renderPartCount);
			component.renderParts = Marshal.ReadIntPtr(componentPtr, ovrAvatarComponent_Offsets.renderParts);
			if (includeName)
			{
				IntPtr ptr = Marshal.ReadIntPtr(componentPtr, ovrAvatarComponent_Offsets.name);
				component.name = Marshal.PtrToStringAnsi(ptr);
			}
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatarComponent_Get")]
		public static extern IntPtr ovrAvatarComponent_Get_Native(IntPtr avatar, uint index);

		public static bool ovrAvatarPose_GetBaseComponent(IntPtr avatar, ref ovrAvatarBaseComponent component)
		{
			IntPtr intPtr = ovrAvatarPose_GetBaseComponent_Native(avatar);
			if (intPtr == IntPtr.Zero)
			{
				return false;
			}
			int ofs = Marshal.SizeOf(typeof(ovrAvatarBaseComponent)) - Marshal.SizeOf(typeof(IntPtr));
			component.renderComponent = Marshal.ReadIntPtr(intPtr, ofs);
			return true;
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatarPose_GetBaseComponent")]
		private static extern IntPtr ovrAvatarPose_GetBaseComponent_Native(IntPtr avatar);

		public static IntPtr MarshalRenderComponent<T>(IntPtr ptr) where T : struct
		{
			return Marshal.ReadIntPtr(new IntPtr(ptr.ToInt64() + Marshal.OffsetOf(typeof(T), "renderComponent").ToInt64()));
		}

		public static bool ovrAvatarPose_GetBodyComponent(IntPtr avatar, ref ovrAvatarBodyComponent component)
		{
			IntPtr intPtr = ovrAvatarPose_GetBodyComponent_Native(avatar);
			if (intPtr == IntPtr.Zero)
			{
				return false;
			}
			Marshal.Copy(new IntPtr(intPtr.ToInt64() + ovrAvatarBodyComponent_Offsets.leftEyeTransform), scratchBufferFloat, 0, 10);
			OvrAvatar.ConvertTransform(scratchBufferFloat, ref component.leftEyeTransform);
			Marshal.Copy(new IntPtr(intPtr.ToInt64() + ovrAvatarBodyComponent_Offsets.rightEyeTransform), scratchBufferFloat, 0, 10);
			OvrAvatar.ConvertTransform(scratchBufferFloat, ref component.rightEyeTransform);
			Marshal.Copy(new IntPtr(intPtr.ToInt64() + ovrAvatarBodyComponent_Offsets.centerEyeTransform), scratchBufferFloat, 0, 10);
			OvrAvatar.ConvertTransform(scratchBufferFloat, ref component.centerEyeTransform);
			component.renderComponent = MarshalRenderComponent<ovrAvatarBodyComponent>(intPtr);
			return true;
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatarPose_GetBodyComponent")]
		private static extern IntPtr ovrAvatarPose_GetBodyComponent_Native(IntPtr avatar);

		public static bool ovrAvatarPose_GetLeftControllerComponent(IntPtr avatar, ref ovrAvatarControllerComponent component)
		{
			IntPtr intPtr = ovrAvatarPose_GetLeftControllerComponent_Native(avatar);
			if (intPtr == IntPtr.Zero)
			{
				return false;
			}
			int ofs = Marshal.SizeOf(typeof(ovrAvatarControllerComponent)) - Marshal.SizeOf(typeof(IntPtr));
			component.renderComponent = Marshal.ReadIntPtr(intPtr, ofs);
			return true;
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatarPose_GetLeftControllerComponent")]
		private static extern IntPtr ovrAvatarPose_GetLeftControllerComponent_Native(IntPtr avatar);

		public static bool ovrAvatarPose_GetRightControllerComponent(IntPtr avatar, ref ovrAvatarControllerComponent component)
		{
			IntPtr intPtr = ovrAvatarPose_GetRightControllerComponent_Native(avatar);
			if (intPtr == IntPtr.Zero)
			{
				return false;
			}
			int ofs = Marshal.SizeOf(typeof(ovrAvatarControllerComponent)) - Marshal.SizeOf(typeof(IntPtr));
			component.renderComponent = Marshal.ReadIntPtr(intPtr, ofs);
			return true;
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatarPose_GetRightControllerComponent")]
		private static extern IntPtr ovrAvatarPose_GetRightControllerComponent_Native(IntPtr avatar);

		public static bool ovrAvatarPose_GetLeftHandComponent(IntPtr avatar, ref ovrAvatarHandComponent component)
		{
			IntPtr intPtr = ovrAvatarPose_GetLeftHandComponent_Native(avatar);
			if (intPtr == IntPtr.Zero)
			{
				return false;
			}
			int ofs = Marshal.SizeOf(typeof(ovrAvatarHandComponent)) - Marshal.SizeOf(typeof(IntPtr));
			component.renderComponent = Marshal.ReadIntPtr(intPtr, ofs);
			return true;
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatarPose_GetLeftHandComponent")]
		private static extern IntPtr ovrAvatarPose_GetLeftHandComponent_Native(IntPtr avatar);

		public static bool ovrAvatarPose_GetRightHandComponent(IntPtr avatar, ref ovrAvatarHandComponent component)
		{
			IntPtr intPtr = ovrAvatarPose_GetRightHandComponent_Native(avatar);
			if (intPtr == IntPtr.Zero)
			{
				return false;
			}
			int ofs = Marshal.SizeOf(typeof(ovrAvatarHandComponent)) - Marshal.SizeOf(typeof(IntPtr));
			component.renderComponent = Marshal.ReadIntPtr(intPtr, ofs);
			return true;
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatarPose_GetRightHandComponent")]
		private static extern IntPtr ovrAvatarPose_GetRightHandComponent_Native(IntPtr avatar);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatarAsset_BeginLoading(ulong assetID);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovrAvatarAsset_BeginLoadingLOD(ulong assetId, ovrAvatarAssetLevelOfDetail lod);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern ovrAvatarAssetType ovrAvatarAsset_GetType(IntPtr assetHandle);

		public static ovrAvatarMeshAssetData ovrAvatarAsset_GetMeshData(IntPtr assetPtr)
		{
			return (ovrAvatarMeshAssetData)Marshal.PtrToStructure(ovrAvatarAsset_GetMeshData_Native(assetPtr), typeof(ovrAvatarMeshAssetData));
		}

		public static ovrAvatarMeshAssetDataV2 ovrAvatarAsset_GetCombinedMeshData(IntPtr assetPtr)
		{
			return (ovrAvatarMeshAssetDataV2)Marshal.PtrToStructure(ovrAvatarAsset_GetCombinedMeshData_Native(assetPtr), typeof(ovrAvatarMeshAssetDataV2));
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatarAsset_GetCombinedMeshData")]
		private static extern IntPtr ovrAvatarAsset_GetCombinedMeshData_Native(IntPtr assetPtr);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatarAsset_GetMeshData")]
		private static extern IntPtr ovrAvatarAsset_GetMeshData_Native(IntPtr assetPtr);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovrAvatarAsset_GetMeshBlendShapeCount(IntPtr assetPtr);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovrAvatarAsset_GetMeshBlendShapeName(IntPtr assetPtr, uint index);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovrAvatarAsset_GetSubmeshCount(IntPtr assetPtr);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovrAvatarAsset_GetSubmeshLastIndex(IntPtr assetPtr, uint index);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovrAvatarAsset_GetMeshBlendShapeVertices(IntPtr assetPtr);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovrAvatarAsset_GetAvatar(IntPtr assetHandle);

		public static ulong[] ovrAvatarAsset_GetCombinedMeshIDs(IntPtr assetHandle)
		{
			uint structure = 0u;
			IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
			IntPtr ptr = ovrAvatarAsset_GetCombinedMeshIDs_Native(assetHandle, intPtr);
			structure = (uint)Marshal.PtrToStructure(intPtr, typeof(uint));
			ulong[] array = new ulong[structure];
			for (int i = 0; i < structure; i++)
			{
				array[i] = (ulong)Marshal.ReadInt64(ptr, i * Marshal.SizeOf(typeof(ulong)));
			}
			Marshal.FreeHGlobal(intPtr);
			return array;
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatarAsset_GetCombinedMeshIDs")]
		public static extern IntPtr ovrAvatarAsset_GetCombinedMeshIDs_Native(IntPtr assetHandle, IntPtr count);

		public static void ovrAvatar_GetCombinedMeshAlphaData(IntPtr avatar, ref ulong textureID, ref Vector4 offset)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ulong)));
			IntPtr intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Vector4)));
			ovrAvatar_GetCombinedMeshAlphaData_Native(avatar, intPtr, intPtr2);
			textureID = (ulong)Marshal.PtrToStructure(intPtr, typeof(ulong));
			offset = (Vector4)Marshal.PtrToStructure(intPtr2, typeof(Vector4));
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatar_GetCombinedMeshAlphaData")]
		public static extern IntPtr ovrAvatar_GetCombinedMeshAlphaData_Native(IntPtr avatar, IntPtr textureIDPtr, IntPtr offsetPtr);

		public static ovrAvatarTextureAssetData ovrAvatarAsset_GetTextureData(IntPtr assetPtr)
		{
			return (ovrAvatarTextureAssetData)Marshal.PtrToStructure(ovrAvatarAsset_GetTextureData_Native(assetPtr), typeof(ovrAvatarTextureAssetData));
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatarAsset_GetTextureData")]
		private static extern IntPtr ovrAvatarAsset_GetTextureData_Native(IntPtr assetPtr);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatarAsset_GetMaterialData")]
		private static extern IntPtr ovrAvatarAsset_GetMaterialData_Native(IntPtr assetPtr);

		public static ovrAvatarMaterialState ovrAvatarAsset_GetMaterialState(IntPtr assetPtr)
		{
			return (ovrAvatarMaterialState)Marshal.PtrToStructure(ovrAvatarAsset_GetMaterialData_Native(assetPtr), typeof(ovrAvatarMaterialState));
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern ovrAvatarRenderPartType ovrAvatarRenderPart_GetType(IntPtr renderPart);

		public static ovrAvatarRenderPart_SkinnedMeshRender ovrAvatarRenderPart_GetSkinnedMeshRender(IntPtr renderPart)
		{
			return (ovrAvatarRenderPart_SkinnedMeshRender)Marshal.PtrToStructure(ovrAvatarRenderPart_GetSkinnedMeshRender_Native(renderPart), typeof(ovrAvatarRenderPart_SkinnedMeshRender));
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatarRenderPart_GetSkinnedMeshRender")]
		private static extern IntPtr ovrAvatarRenderPart_GetSkinnedMeshRender_Native(IntPtr renderPart);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern ovrAvatarTransform ovrAvatarSkinnedMeshRender_GetTransform(IntPtr renderPart);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern ovrAvatarTransform ovrAvatarSkinnedMeshRenderPBS_GetTransform(IntPtr renderPart);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern ovrAvatarTransform ovrAvatarSkinnedMeshRenderPBSV2_GetTransform(IntPtr renderPart);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern ovrAvatarVisibilityFlags ovrAvatarSkinnedMeshRender_GetVisibilityMask(IntPtr renderPart);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovrAvatarSkinnedMeshRender_MaterialStateChanged(IntPtr renderPart);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovrAvatarSkinnedMeshRenderPBSV2_MaterialStateChanged(IntPtr renderPart);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern ovrAvatarVisibilityFlags ovrAvatarSkinnedMeshRenderPBS_GetVisibilityMask(IntPtr renderPart);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern ovrAvatarVisibilityFlags ovrAvatarSkinnedMeshRenderPBSV2_GetVisibilityMask(IntPtr renderPart);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern ovrAvatarMaterialState ovrAvatarSkinnedMeshRender_GetMaterialState(IntPtr renderPart);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern ovrAvatarPBSMaterialState ovrAvatarSkinnedMeshRenderPBSV2_GetPBSMaterialState(IntPtr renderPart);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern ovrAvatarExpressiveParameters ovrAvatar_GetExpressiveParameters(IntPtr avatar);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovrAvatarSkinnedMeshRender_GetDirtyJoints(IntPtr renderPart);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovrAvatarSkinnedMeshRenderPBS_GetDirtyJoints(IntPtr renderPart);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovrAvatarSkinnedMeshRenderPBSV2_GetDirtyJoints(IntPtr renderPart);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern ovrAvatarTransform ovrAvatarSkinnedMeshRender_GetJointTransform(IntPtr renderPart, uint jointIndex);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_SetActionUnitOnsetSpeed(IntPtr avatar, float onsetSpeed);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_SetActionUnitFalloffSpeed(IntPtr avatar, float falloffSpeed);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_SetVisemeMultiplier(IntPtr avatar, float visemeMultiplier);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern ovrAvatarTransform ovrAvatarSkinnedMeshRenderPBS_GetJointTransform(IntPtr renderPart, uint jointIndex);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern ovrAvatarTransform ovrAvatarSkinnedMeshRenderPBSV2_GetJointTransform(IntPtr renderPart, uint jointIndex);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovrAvatarSkinnedMeshRenderPBS_GetAlbedoTextureAssetID(IntPtr renderPart);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovrAvatarSkinnedMeshRenderPBS_GetSurfaceTextureAssetID(IntPtr renderPart);

		public static ovrAvatarRenderPart_SkinnedMeshRenderPBS ovrAvatarRenderPart_GetSkinnedMeshRenderPBS(IntPtr renderPart)
		{
			return (ovrAvatarRenderPart_SkinnedMeshRenderPBS)Marshal.PtrToStructure(ovrAvatarRenderPart_GetSkinnedMeshRenderPBS_Native(renderPart), typeof(ovrAvatarRenderPart_SkinnedMeshRenderPBS));
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatarRenderPart_GetSkinnedMeshRenderPBS")]
		private static extern IntPtr ovrAvatarRenderPart_GetSkinnedMeshRenderPBS_Native(IntPtr renderPart);

		public static ovrAvatarRenderPart_SkinnedMeshRenderPBS_V2 ovrAvatarRenderPart_GetSkinnedMeshRenderPBSV2(IntPtr renderPart)
		{
			return (ovrAvatarRenderPart_SkinnedMeshRenderPBS_V2)Marshal.PtrToStructure(ovrAvatarRenderPart_GetSkinnedMeshRenderPBSV2_Native(renderPart), typeof(ovrAvatarRenderPart_SkinnedMeshRenderPBS_V2));
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatarRenderPart_GetSkinnedMeshRenderPBSV2")]
		private static extern IntPtr ovrAvatarRenderPart_GetSkinnedMeshRenderPBSV2_Native(IntPtr renderPart);

		public static void ovrAvatarSkinnedMeshRender_GetBlendShapeParams(IntPtr renderPart, ref ovrAvatarBlendShapeParams blendParams)
		{
			IntPtr ptr = ovrAvatarSkinnedMeshRender_GetBlendShapeParams_Native(renderPart);
			blendParams.blendShapeParamCount = (uint)Marshal.ReadInt32(ptr);
			Marshal.Copy(new IntPtr(ptr.ToInt64() + ovrAvatarBlendShapeParams_Offsets.blendShapeParams), blendParams.blendShapeParams, 0, (int)blendParams.blendShapeParamCount);
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatarSkinnedMeshRender_GetBlendShapeParams")]
		private static extern IntPtr ovrAvatarSkinnedMeshRender_GetBlendShapeParams_Native(IntPtr renderPart);

		public static ovrAvatarRenderPart_ProjectorRender ovrAvatarRenderPart_GetProjectorRender(IntPtr renderPart)
		{
			return (ovrAvatarRenderPart_ProjectorRender)Marshal.PtrToStructure(ovrAvatarRenderPart_GetProjectorRender_Native(renderPart), typeof(ovrAvatarRenderPart_ProjectorRender));
		}

		public static ovrAvatarPBSMaterialState[] ovrAvatar_GetBodyPBSMaterialStates(IntPtr renderPart)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(uint)));
			IntPtr intPtr2 = ovrAvatar_GetBodyPBSMaterialStates_Native(renderPart, intPtr);
			ovrAvatarPBSMaterialState[] array = new ovrAvatarPBSMaterialState[Marshal.ReadInt32(intPtr)];
			for (int i = 0; i < array.Length; i++)
			{
				IntPtr ptr = new IntPtr(intPtr2.ToInt64() + i * Marshal.SizeOf(typeof(ovrAvatarPBSMaterialState)));
				array[i] = (ovrAvatarPBSMaterialState)Marshal.PtrToStructure(ptr, typeof(ovrAvatarPBSMaterialState));
			}
			Marshal.FreeHGlobal(intPtr);
			return array;
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatar_GetBodyPBSMaterialStates")]
		private static extern IntPtr ovrAvatar_GetBodyPBSMaterialStates_Native(IntPtr avatar, IntPtr count);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatarRenderPart_GetProjectorRender")]
		private static extern IntPtr ovrAvatarRenderPart_GetProjectorRender_Native(IntPtr renderPart);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovrAvatar_GetReferencedAssetCount(IntPtr avatar);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovrAvatar_GetReferencedAsset(IntPtr avatar, uint index);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_SetLeftHandGesture(IntPtr avatar, ovrAvatarHandGesture gesture);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_SetRightHandGesture(IntPtr avatar, ovrAvatarHandGesture gesture);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_SetLeftHandCustomGesture(IntPtr avatar, uint jointCount, [In] ovrAvatarTransform[] customJointTransforms);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_SetRightHandCustomGesture(IntPtr avatar, uint jointCount, [In] ovrAvatarTransform[] customJointTransforms);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_UpdatePoseFromPacket(IntPtr avatar, IntPtr packet, float secondsFromStart);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatarPacket_BeginRecording(IntPtr avatar);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovrAvatarPacket_EndRecording(IntPtr avatar);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovrAvatarPacket_GetSize(IntPtr packet);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern float ovrAvatarPacket_GetDurationSeconds(IntPtr packet);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatarPacket_Free(IntPtr packet);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovrAvatarPacket_Write(IntPtr packet, uint bufferSize, [Out] byte[] buffer);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovrAvatarPacket_Read(uint bufferSize, [In] byte[] buffer);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		private static extern void ovrAvatar_SetInternalForceASTCTextures(bool value);

		public static void ovrAvatar_SetForceASTCTextures(bool value)
		{
			ovrAvatar_SetInternalForceASTCTextures(value);
		}

		public static void ovrAvatar_OverrideExpressiveLogic(IntPtr avatar, ovrAvatarBlendShapeParams blendParams)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ovrAvatarBlendShapeParams)));
			Marshal.StructureToPtr(blendParams, intPtr, fDeleteOld: false);
			ovrAvatar_OverrideExpressiveLogic_Native(avatar, intPtr);
			Marshal.FreeHGlobal(intPtr);
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatar_OverrideExpressiveLogic")]
		private static extern void ovrAvatar_OverrideExpressiveLogic_Native(IntPtr avatar, IntPtr state);

		public static void ovrAvatar_SetVisemes(IntPtr avatar, ovrAvatarVisemes visemes)
		{
			Marshal.WriteInt32(nativeVisemeData, (int)visemes.visemeParamCount);
			Marshal.Copy(visemes.visemeParams, 0, new IntPtr(nativeVisemeData.ToInt64() + ovrAvatarVisemes_Offsets.visemeParams), (int)visemes.visemeParamCount);
			ovrAvatar_SetVisemes_Native(avatar, nativeVisemeData);
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatar_SetVisemes")]
		private static extern void ovrAvatar_SetVisemes_Native(IntPtr avatar, IntPtr visemes);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_UpdateWorldTransform(IntPtr avatar, ovrAvatarTransform transform);

		public static void ovrAvatar_UpdateGazeTargets(ovrAvatarGazeTargets targets)
		{
			Marshal.WriteInt32(nativeGazeTargetsData, (int)targets.targetCount);
			long targets2 = ovrAvatarGazeTargets_Offsets.targets;
			for (uint num = 0u; num < targets.targetCount; num++)
			{
				long num2 = targets2 + num * Marshal.SizeOf(typeof(ovrAvatarGazeTarget));
				Marshal.WriteInt32(new IntPtr(nativeGazeTargetsData.ToInt64() + num2 + ovrAvatarGazeTarget_Offsets.id), (int)targets.targets[num].id);
				scratchBufferFloat[0] = targets.targets[num].worldPosition.x;
				scratchBufferFloat[1] = targets.targets[num].worldPosition.y;
				scratchBufferFloat[2] = targets.targets[num].worldPosition.z;
				Marshal.Copy(scratchBufferFloat, 0, new IntPtr(nativeGazeTargetsData.ToInt64() + num2 + ovrAvatarGazeTarget_Offsets.worldPosition), 3);
				Marshal.WriteInt32(new IntPtr(nativeGazeTargetsData.ToInt64() + num2 + ovrAvatarGazeTarget_Offsets.type), (int)targets.targets[num].type);
			}
			ovrAvatar_UpdateGazeTargets_Native(nativeGazeTargetsData);
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatar_UpdateGazeTargets")]
		private static extern void ovrAvatar_UpdateGazeTargets_Native(IntPtr targets);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_RemoveGazeTargets(uint targetCount, uint[] ids);

		public static void ovrAvatar_UpdateLights(ovrAvatarLights lights)
		{
			scratchBufferFloat[0] = lights.ambientIntensity;
			Marshal.Copy(scratchBufferFloat, 0, nativeAvatarLightsData, 1);
			Marshal.WriteInt32(new IntPtr(nativeAvatarLightsData.ToInt64() + Marshal.OffsetOf(typeof(ovrAvatarLights), "lightCount").ToInt64()), (int)lights.lightCount);
			long num = Marshal.OffsetOf(typeof(ovrAvatarLights), "lights").ToInt64();
			for (uint num2 = 0u; num2 < lights.lightCount; num2++)
			{
				long num3 = num + num2 * Marshal.SizeOf(typeof(ovrAvatarLight));
				Marshal.WriteInt32(new IntPtr(nativeAvatarLightsData.ToInt64() + num3 + Marshal.OffsetOf(typeof(ovrAvatarLight), "id").ToInt64()), (int)lights.lights[num2].id);
				Marshal.WriteInt32(new IntPtr(nativeAvatarLightsData.ToInt64() + num3 + Marshal.OffsetOf(typeof(ovrAvatarLight), "type").ToInt64()), (int)lights.lights[num2].type);
				scratchBufferFloat[0] = lights.lights[num2].intensity;
				Marshal.Copy(scratchBufferFloat, 0, new IntPtr(nativeAvatarLightsData.ToInt64() + num3 + Marshal.OffsetOf(typeof(ovrAvatarLight), "intensity").ToInt64()), 1);
				scratchBufferFloat[0] = lights.lights[num2].worldDirection.x;
				scratchBufferFloat[1] = lights.lights[num2].worldDirection.y;
				scratchBufferFloat[2] = lights.lights[num2].worldDirection.z;
				Marshal.Copy(scratchBufferFloat, 0, new IntPtr(nativeAvatarLightsData.ToInt64() + num3 + Marshal.OffsetOf(typeof(ovrAvatarLight), "worldDirection").ToInt64()), 3);
				scratchBufferFloat[0] = lights.lights[num2].worldPosition.x;
				scratchBufferFloat[1] = lights.lights[num2].worldPosition.y;
				scratchBufferFloat[2] = lights.lights[num2].worldPosition.z;
				Marshal.Copy(scratchBufferFloat, 0, new IntPtr(nativeAvatarLightsData.ToInt64() + num3 + Marshal.OffsetOf(typeof(ovrAvatarLight), "worldPosition").ToInt64()), 3);
				scratchBufferFloat[0] = lights.lights[num2].range;
				Marshal.Copy(scratchBufferFloat, 0, new IntPtr(nativeAvatarLightsData.ToInt64() + num3 + Marshal.OffsetOf(typeof(ovrAvatarLight), "range").ToInt64()), 1);
				scratchBufferFloat[0] = lights.lights[num2].spotAngleDeg;
				Marshal.Copy(scratchBufferFloat, 0, new IntPtr(nativeAvatarLightsData.ToInt64() + num3 + Marshal.OffsetOf(typeof(ovrAvatarLight), "spotAngleDeg").ToInt64()), 1);
			}
			ovrAvatar_UpdateLights_Native(nativeAvatarLightsData);
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatar_UpdateLights")]
		private static extern void ovrAvatar_UpdateLights_Native(IntPtr lights);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_RemoveLights(uint lightCount, uint[] ids);

		[MonoPInvokeCallback(typeof(LoggingDelegate))]
		public static void LoggingCallback(IntPtr str)
		{
			Marshal.PtrToStringAnsi(str);
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_RegisterLoggingCallback(LoggingDelegate callback);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_SetLoggingLevel(ovrAvatarLogLevel level);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatar_GetDebugTransforms")]
		public static extern IntPtr ovrAvatar_GetDebugTransforms_Native(IntPtr count);

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrAvatar_GetDebugLines")]
		public static extern IntPtr ovrAvatar_GetDebugLines_Native(IntPtr count);

		public static void ovrAvatar_DrawDebugLines()
		{
			IntPtr intPtr = ovrAvatar_GetDebugLines_Native(DebugLineCountData);
			int num = Marshal.ReadInt32(DebugLineCountData);
			ovrAvatarDebugLine ovrAvatarDebugLine2 = default(ovrAvatarDebugLine);
			for (int i = 0; i < num; i++)
			{
				int num2 = i * Marshal.SizeOf(typeof(ovrAvatarDebugLine));
				Marshal.Copy(new IntPtr(intPtr.ToInt64() + num2), scratchBufferFloat, 0, 9);
				ovrAvatarDebugLine2.startPoint.x = scratchBufferFloat[0];
				ovrAvatarDebugLine2.startPoint.y = scratchBufferFloat[1];
				ovrAvatarDebugLine2.startPoint.z = 0f - scratchBufferFloat[2];
				ovrAvatarDebugLine2.endPoint.x = scratchBufferFloat[3];
				ovrAvatarDebugLine2.endPoint.y = scratchBufferFloat[4];
				ovrAvatarDebugLine2.endPoint.z = 0f - scratchBufferFloat[5];
				ovrAvatarDebugLine2.color.x = scratchBufferFloat[6];
				ovrAvatarDebugLine2.color.y = scratchBufferFloat[7];
				ovrAvatarDebugLine2.color.z = scratchBufferFloat[8];
				ovrAvatarDebugLine2.context = (ovrAvatarDebugContext)Marshal.ReadInt32(new IntPtr(intPtr.ToInt64() + num2 + Marshal.OffsetOf(typeof(ovrAvatarDebugLine), "context").ToInt64()));
				ovrAvatarDebugLine2.text = Marshal.ReadIntPtr(new IntPtr(intPtr.ToInt64() + num2 + Marshal.OffsetOf(typeof(ovrAvatarDebugLine), "text").ToInt64()));
				Debug.DrawLine(ovrAvatarDebugLine2.startPoint, ovrAvatarDebugLine2.endPoint, new Color(ovrAvatarDebugLine2.color.x, ovrAvatarDebugLine2.color.y, ovrAvatarDebugLine2.color.z));
			}
			intPtr = ovrAvatar_GetDebugTransforms_Native(DebugLineCountData);
			num = Marshal.ReadInt32(DebugLineCountData);
			ovrAvatarDebugTransform ovrAvatarDebugTransform2 = default(ovrAvatarDebugTransform);
			for (int j = 0; j < num; j++)
			{
				int num3 = j * Marshal.SizeOf(typeof(ovrAvatarDebugTransform));
				Marshal.Copy(new IntPtr(intPtr.ToInt64() + num3), scratchBufferFloat, 0, 10);
				OvrAvatar.ConvertTransform(scratchBufferFloat, ref ovrAvatarDebugTransform2.transform);
				OvrAvatar.ConvertTransform(ovrAvatarDebugTransform2.transform, debugLineGo.transform);
				ovrAvatarDebugTransform2.context = (ovrAvatarDebugContext)Marshal.ReadInt32(new IntPtr(intPtr.ToInt64() + num3 + Marshal.OffsetOf(typeof(ovrAvatarDebugTransform), "context").ToInt64()));
				ovrAvatarDebugTransform2.text = Marshal.ReadIntPtr(new IntPtr(intPtr.ToInt64() + num3 + Marshal.OffsetOf(typeof(ovrAvatarDebugTransform), "text").ToInt64()));
				Vector3 vector = 0.1f * debugLineGo.transform.TransformVector(Vector3.up);
				Vector3 vector2 = 0.1f * debugLineGo.transform.TransformVector(Vector3.right);
				Vector3 vector3 = 0.1f * debugLineGo.transform.TransformVector(Vector3.forward);
				Debug.DrawLine(debugLineGo.transform.position, debugLineGo.transform.position + vector, Color.green);
				Debug.DrawLine(debugLineGo.transform.position, debugLineGo.transform.position + vector2, Color.red);
				Debug.DrawLine(debugLineGo.transform.position, debugLineGo.transform.position + vector3, Color.blue);
			}
		}

		[DllImport("libovravatar", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrAvatar_SetDebugDrawContext(uint context);

		public static bool SendEvent(string name, string param = "", string source = "")
		{
			try
			{
				if (ovrPluginVersion == null)
				{
					string text = ovrp_GetVersion();
					if (!string.IsNullOrEmpty(text))
					{
						ovrPluginVersion = new Version(text.Split('-')[0]);
					}
					else
					{
						ovrPluginVersion = new Version(0, 0, 0);
					}
				}
				if (ovrPluginVersion >= OVRP_1_30_0.version)
				{
					return OVRP_1_30_0.ovrp_SendEvent2(name, param, (source.Length == 0) ? "avatar_sdk" : source) == Result.Success;
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrp_GetVersion")]
		private static extern IntPtr _ovrp_GetVersion();

		public static string ovrp_GetVersion()
		{
			return Marshal.PtrToStringAnsi(_ovrp_GetVersion());
		}
	}
}
