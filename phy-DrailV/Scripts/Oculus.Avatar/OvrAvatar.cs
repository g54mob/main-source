using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Oculus.Avatar;
using UnityEngine;
using UnityEngine.Events;

public class OvrAvatar : MonoBehaviour
{
	public class PacketEventArgs : EventArgs
	{
		public readonly OvrAvatarPacket Packet;

		public PacketEventArgs(OvrAvatarPacket packet)
		{
			Packet = packet;
		}
	}

	public enum HandType
	{
		Right = 0,
		Left = 1,
		Max = 2
	}

	public enum HandJoint
	{
		HandBase = 0,
		IndexBase = 1,
		IndexTip = 2,
		ThumbBase = 3,
		ThumbTip = 4,
		Max = 5
	}

	[Header("Avatar")]
	public IntPtr sdkAvatar = IntPtr.Zero;

	public string oculusUserID;

	public OvrAvatarDriver Driver;

	[Header("Capabilities")]
	public bool EnableBody = true;

	public bool EnableHands = true;

	public bool EnableBase = true;

	public bool EnableExpressive;

	[Header("Network")]
	public bool RecordPackets;

	public bool UseSDKPackets = true;

	public PacketRecordSettings PacketSettings = new PacketRecordSettings();

	[Header("Visibility")]
	public bool StartWithControllers;

	public AvatarLayer FirstPersonLayer;

	public AvatarLayer ThirdPersonLayer;

	public bool ShowFirstPerson = true;

	public bool ShowThirdPerson;

	internal ovrAvatarCapabilities Capabilities = ovrAvatarCapabilities.Body;

	[Header("Performance")]
	[SerializeField]
	internal ovrAvatarAssetLevelOfDetail LevelOfDetail = ovrAvatarAssetLevelOfDetail.Highest;

	private bool CombineMeshes;

	[Tooltip("Enable to use transparent queue, disable to use geometry queue. Requires restart to take effect.")]
	public bool UseTransparentRenderQueue = true;

	[Header("Shaders")]
	public Shader Monochrome_SurfaceShader;

	public Shader Monochrome_SurfaceShader_SelfOccluding;

	public Shader Monochrome_SurfaceShader_PBS;

	public Shader Skinshaded_SurfaceShader_SingleComponent;

	public Shader Skinshaded_VertFrag_SingleComponent;

	public Shader Skinshaded_VertFrag_CombinedMesh;

	public Shader Skinshaded_Expressive_SurfaceShader_SingleComponent;

	public Shader Skinshaded_Expressive_VertFrag_SingleComponent;

	public Shader Skinshaded_Expressive_VertFrag_CombinedMesh;

	public Shader Loader_VertFrag_CombinedMesh;

	public Shader EyeLens;

	public Shader ControllerShader;

	[Header("Other")]
	public bool CanOwnMicrophone = true;

	[Tooltip("Enable laughter detection and animation as part of OVRLipSync.")]
	public bool EnableLaughter = true;

	public GameObject MouthAnchor;

	public Transform LeftHandCustomPose;

	public Transform RightHandCustomPose;

	private HashSet<ulong> assetLoadingIds = new HashSet<ulong>();

	private bool assetsFinishedLoading;

	private OvrAvatarMaterialManager materialManager;

	private bool waitingForCombinedMesh;

	private static bool doneExpressiveGlobalInit;

	private Vector4 clothingAlphaOffset = new Vector4(0f, 0f, 0f, 1f);

	private ulong clothingAlphaTexture;

	private OVRLipSyncMicInput micInput;

	private OVRLipSyncContext lipsyncContext;

	private OVRLipSync.Frame currentFrame = new OVRLipSync.Frame();

	private float[] visemes = new float[16];

	private AudioSource audioSource;

	private ONSPAudioSource spatializedSource;

	private List<float[]> voiceUpdates = new List<float[]>();

	private static ovrAvatarVisemes RuntimeVisemes;

	private Transform cachedLeftHandCustomPose;

	private Transform[] cachedCustomLeftHandJoints;

	private ovrAvatarTransform[] cachedLeftHandTransforms;

	private Transform cachedRightHandCustomPose;

	private Transform[] cachedCustomRightHandJoints;

	private ovrAvatarTransform[] cachedRightHandTransforms;

	private bool showLeftController;

	private bool showRightController;

	private const bool USE_MOBILE_TEXTURE_FORMAT = false;

	private static readonly Vector3 MOUTH_HEAD_OFFSET;

	private const string MOUTH_HELPER_NAME = "MouthAnchor";

	private const int VISEME_COUNT = 16;

	private const float ACTION_UNIT_ONSET_SPEED = 30f;

	private const float ACTION_UNIT_FALLOFF_SPEED = 20f;

	private const float VISEME_LEVEL_MULTIPLIER = 1.5f;

	internal ulong oculusUserIDInternal;

	internal OvrAvatarBase Base;

	internal OvrAvatarTouchController ControllerLeft;

	internal OvrAvatarTouchController ControllerRight;

	internal OvrAvatarBody Body;

	internal OvrAvatarHand HandLeft;

	internal OvrAvatarHand HandRight;

	internal ovrAvatarLookAndFeelVersion LookAndFeelVersion = ovrAvatarLookAndFeelVersion.Two;

	internal ovrAvatarLookAndFeelVersion FallbackLookAndFeelVersion = ovrAvatarLookAndFeelVersion.Two;

	public UnityEvent AssetsDoneLoading = new UnityEvent();

	private OvrAvatarPacket CurrentUnityPacket;

	public EventHandler<PacketEventArgs> PacketRecorded;

	private static string[,] HandJoints;

	private static Vector3 MOUTH_POSITION_OFFSET;

	private static string VOICE_PROPERTY;

	private static string MOUTH_POSITION_PROPERTY;

	private static string MOUTH_DIRECTION_PROPERTY;

	private static string MOUTH_SCALE_PROPERTY;

	private static float MOUTH_SCALE_GLOBAL;

	private static float MOUTH_MAX_GLOBAL;

	private static string NECK_JONT;

	public float VoiceAmplitude;

	public bool EnableMouthVertexAnimation;

	private static ovrAvatarLights ovrLights;

	static OvrAvatar()
	{
		doneExpressiveGlobalInit = false;
		MOUTH_HEAD_OFFSET = new Vector3(0f, -0.085f, 0.09f);
		HandJoints = new string[2, 5]
		{
			{ "hands:r_hand_world", "hands:r_hand_world/hands:b_r_hand/hands:b_r_index1", "hands:r_hand_world/hands:b_r_hand/hands:b_r_index1/hands:b_r_index2/hands:b_r_index3/hands:b_r_index_ignore", "hands:r_hand_world/hands:b_r_hand/hands:b_r_thumb1/hands:b_r_thumb2", "hands:r_hand_world/hands:b_r_hand/hands:b_r_thumb1/hands:b_r_thumb2/hands:b_r_thumb3/hands:b_r_thumb_ignore" },
			{ "hands:l_hand_world", "hands:l_hand_world/hands:b_l_hand/hands:b_l_index1", "hands:l_hand_world/hands:b_l_hand/hands:b_l_index1/hands:b_l_index2/hands:b_l_index3/hands:b_l_index_ignore", "hands:l_hand_world/hands:b_l_hand/hands:b_l_thumb1/hands:b_l_thumb2", "hands:l_hand_world/hands:b_l_hand/hands:b_l_thumb1/hands:b_l_thumb2/hands:b_l_thumb3/hands:b_l_thumb_ignore" }
		};
		MOUTH_POSITION_OFFSET = new Vector3(0f, -0.018f, 0.1051f);
		VOICE_PROPERTY = "_Voice";
		MOUTH_POSITION_PROPERTY = "_MouthPosition";
		MOUTH_DIRECTION_PROPERTY = "_MouthDirection";
		MOUTH_SCALE_PROPERTY = "_MouthEffectScale";
		MOUTH_SCALE_GLOBAL = 0.007f;
		MOUTH_MAX_GLOBAL = 0.007f;
		NECK_JONT = "root_JNT/body_JNT/chest_JNT/neckBase_JNT/neck_JNT";
		ovrLights = default(ovrAvatarLights);
		RuntimeVisemes.visemeParams = new float[32];
		RuntimeVisemes.visemeParamCount = 16u;
	}

	private void OnDestroy()
	{
		if (sdkAvatar != IntPtr.Zero)
		{
			CAPI.ovrAvatar_Destroy(sdkAvatar);
		}
	}

	public void AssetLoadedCallback(OvrAvatarAsset asset)
	{
		assetLoadingIds.Remove(asset.assetID);
	}

	public void CombinedMeshLoadedCallback(IntPtr assetPtr)
	{
		if (waitingForCombinedMesh)
		{
			ulong[] array = CAPI.ovrAvatarAsset_GetCombinedMeshIDs(assetPtr);
			foreach (ulong item in array)
			{
				assetLoadingIds.Remove(item);
			}
			CAPI.ovrAvatar_GetCombinedMeshAlphaData(sdkAvatar, ref clothingAlphaTexture, ref clothingAlphaOffset);
			waitingForCombinedMesh = false;
		}
	}

	private OvrAvatarSkinnedMeshRenderComponent AddSkinnedMeshRenderComponent(GameObject gameObject, ovrAvatarRenderPart_SkinnedMeshRender skinnedMeshRender)
	{
		OvrAvatarSkinnedMeshRenderComponent ovrAvatarSkinnedMeshRenderComponent = gameObject.AddComponent<OvrAvatarSkinnedMeshRenderComponent>();
		ovrAvatarSkinnedMeshRenderComponent.Initialize(skinnedMeshRender, Monochrome_SurfaceShader, Monochrome_SurfaceShader_SelfOccluding, ThirdPersonLayer.layerIndex, FirstPersonLayer.layerIndex);
		return ovrAvatarSkinnedMeshRenderComponent;
	}

	private OvrAvatarSkinnedMeshRenderPBSComponent AddSkinnedMeshRenderPBSComponent(GameObject gameObject, ovrAvatarRenderPart_SkinnedMeshRenderPBS skinnedMeshRenderPBS)
	{
		OvrAvatarSkinnedMeshRenderPBSComponent ovrAvatarSkinnedMeshRenderPBSComponent = gameObject.AddComponent<OvrAvatarSkinnedMeshRenderPBSComponent>();
		ovrAvatarSkinnedMeshRenderPBSComponent.Initialize(skinnedMeshRenderPBS, Monochrome_SurfaceShader_PBS, ThirdPersonLayer.layerIndex, FirstPersonLayer.layerIndex);
		return ovrAvatarSkinnedMeshRenderPBSComponent;
	}

	private OvrAvatarSkinnedMeshPBSV2RenderComponent AddSkinnedMeshRenderPBSV2Component(IntPtr renderPart, GameObject go, ovrAvatarRenderPart_SkinnedMeshRenderPBS_V2 skinnedMeshRenderPBSV2, bool isBodyPartZero, bool isControllerModel)
	{
		OvrAvatarSkinnedMeshPBSV2RenderComponent ovrAvatarSkinnedMeshPBSV2RenderComponent = go.AddComponent<OvrAvatarSkinnedMeshPBSV2RenderComponent>();
		ovrAvatarSkinnedMeshPBSV2RenderComponent.Initialize(renderPart, skinnedMeshRenderPBSV2, materialManager, ThirdPersonLayer.layerIndex, FirstPersonLayer.layerIndex, isBodyPartZero && CombineMeshes, LevelOfDetail, isBodyPartZero && EnableExpressive, this, isControllerModel);
		return ovrAvatarSkinnedMeshPBSV2RenderComponent;
	}

	public static IntPtr GetRenderPart(ovrAvatarComponent component, uint renderPartIndex)
	{
		return Marshal.ReadIntPtr(component.renderParts, Marshal.SizeOf(typeof(IntPtr)) * (int)renderPartIndex);
	}

	private static string GetRenderPartName(ovrAvatarComponent component, uint renderPartIndex)
	{
		return component.name + "_renderPart_" + (int)renderPartIndex;
	}

	internal static void ConvertTransform(float[] transform, ref ovrAvatarTransform target)
	{
		target.position.x = transform[0];
		target.position.y = transform[1];
		target.position.z = transform[2];
		target.orientation.x = transform[3];
		target.orientation.y = transform[4];
		target.orientation.z = transform[5];
		target.orientation.w = transform[6];
		target.scale.x = transform[7];
		target.scale.y = transform[8];
		target.scale.z = transform[9];
	}

	internal static void ConvertTransform(ovrAvatarTransform transform, Transform target)
	{
		Vector3 position = transform.position;
		position.z = 0f - position.z;
		Quaternion orientation = transform.orientation;
		orientation.x = 0f - orientation.x;
		orientation.y = 0f - orientation.y;
		target.localPosition = position;
		target.localRotation = orientation;
		target.localScale = transform.scale;
	}

	public static ovrAvatarTransform CreateOvrAvatarTransform(Vector3 position, Quaternion orientation)
	{
		return new ovrAvatarTransform
		{
			position = new Vector3(position.x, position.y, 0f - position.z),
			orientation = new Quaternion(0f - orientation.x, 0f - orientation.y, orientation.z, orientation.w),
			scale = Vector3.one
		};
	}

	private static ovrAvatarGazeTarget CreateOvrGazeTarget(uint targetId, Vector3 targetPosition, ovrAvatarGazeTargetType targetType)
	{
		return new ovrAvatarGazeTarget
		{
			id = targetId,
			worldPosition = new Vector3(targetPosition.x, targetPosition.y, 0f - targetPosition.z),
			type = targetType
		};
	}

	private void BuildRenderComponents()
	{
		ovrAvatarBaseComponent component = default(ovrAvatarBaseComponent);
		ovrAvatarHandComponent component2 = default(ovrAvatarHandComponent);
		ovrAvatarHandComponent component3 = default(ovrAvatarHandComponent);
		ovrAvatarControllerComponent component4 = default(ovrAvatarControllerComponent);
		ovrAvatarControllerComponent component5 = default(ovrAvatarControllerComponent);
		ovrAvatarBodyComponent component6 = default(ovrAvatarBodyComponent);
		ovrAvatarComponent component7 = default(ovrAvatarComponent);
		if (CAPI.ovrAvatarPose_GetLeftHandComponent(sdkAvatar, ref component2))
		{
			CAPI.ovrAvatarComponent_Get(component2.renderComponent, includeName: true, ref component7);
			AddAvatarComponent(ref HandLeft, component7);
			HandLeft.isLeftHand = true;
		}
		if (CAPI.ovrAvatarPose_GetRightHandComponent(sdkAvatar, ref component3))
		{
			CAPI.ovrAvatarComponent_Get(component3.renderComponent, includeName: true, ref component7);
			AddAvatarComponent(ref HandRight, component7);
			HandRight.isLeftHand = false;
		}
		if (CAPI.ovrAvatarPose_GetBodyComponent(sdkAvatar, ref component6))
		{
			CAPI.ovrAvatarComponent_Get(component6.renderComponent, includeName: true, ref component7);
			AddAvatarComponent(ref Body, component7);
		}
		if (CAPI.ovrAvatarPose_GetLeftControllerComponent(sdkAvatar, ref component4))
		{
			CAPI.ovrAvatarComponent_Get(component4.renderComponent, includeName: true, ref component7);
			AddAvatarComponent(ref ControllerLeft, component7);
			ControllerLeft.isLeftHand = true;
		}
		if (CAPI.ovrAvatarPose_GetRightControllerComponent(sdkAvatar, ref component5))
		{
			CAPI.ovrAvatarComponent_Get(component5.renderComponent, includeName: true, ref component7);
			AddAvatarComponent(ref ControllerRight, component7);
			ControllerRight.isLeftHand = false;
		}
		if (CAPI.ovrAvatarPose_GetBaseComponent(sdkAvatar, ref component))
		{
			CAPI.ovrAvatarComponent_Get(component.renderComponent, includeName: true, ref component7);
			AddAvatarComponent(ref Base, component7);
		}
	}

	private void AddAvatarComponent<T>(ref T root, ovrAvatarComponent nativeComponent) where T : OvrAvatarComponent
	{
		GameObject gameObject = new GameObject();
		gameObject.name = nativeComponent.name;
		gameObject.transform.SetParent(base.transform);
		root = gameObject.AddComponent<T>();
		root.SetOvrAvatarOwner(this);
		AddRenderParts(root, nativeComponent, gameObject.transform);
	}

	private void UpdateCustomPoses()
	{
		if (UpdatePoseRoot(LeftHandCustomPose, ref cachedLeftHandCustomPose, ref cachedCustomLeftHandJoints, ref cachedLeftHandTransforms) && cachedLeftHandCustomPose == null && sdkAvatar != IntPtr.Zero)
		{
			CAPI.ovrAvatar_SetLeftHandGesture(sdkAvatar, ovrAvatarHandGesture.Default);
		}
		if (UpdatePoseRoot(RightHandCustomPose, ref cachedRightHandCustomPose, ref cachedCustomRightHandJoints, ref cachedRightHandTransforms) && cachedRightHandCustomPose == null && sdkAvatar != IntPtr.Zero)
		{
			CAPI.ovrAvatar_SetRightHandGesture(sdkAvatar, ovrAvatarHandGesture.Default);
		}
		if (sdkAvatar != IntPtr.Zero)
		{
			if (cachedLeftHandCustomPose != null && UpdateTransforms(cachedCustomLeftHandJoints, cachedLeftHandTransforms))
			{
				CAPI.ovrAvatar_SetLeftHandCustomGesture(sdkAvatar, (uint)cachedLeftHandTransforms.Length, cachedLeftHandTransforms);
			}
			if (cachedRightHandCustomPose != null && UpdateTransforms(cachedCustomRightHandJoints, cachedRightHandTransforms))
			{
				CAPI.ovrAvatar_SetRightHandCustomGesture(sdkAvatar, (uint)cachedRightHandTransforms.Length, cachedRightHandTransforms);
			}
		}
	}

	private static bool UpdatePoseRoot(Transform poseRoot, ref Transform cachedPoseRoot, ref Transform[] cachedPoseJoints, ref ovrAvatarTransform[] transforms)
	{
		if (poseRoot == cachedPoseRoot)
		{
			return false;
		}
		if (!poseRoot)
		{
			cachedPoseRoot = null;
			cachedPoseJoints = null;
			transforms = null;
		}
		else
		{
			List<Transform> list = new List<Transform>();
			OrderJoints(poseRoot, list);
			cachedPoseRoot = poseRoot;
			cachedPoseJoints = list.ToArray();
			transforms = new ovrAvatarTransform[list.Count];
		}
		return true;
	}

	private static bool UpdateTransforms(Transform[] joints, ovrAvatarTransform[] transforms)
	{
		bool result = false;
		for (int i = 0; i < joints.Length; i++)
		{
			Transform transform = joints[i];
			ovrAvatarTransform ovrAvatarTransform2 = CreateOvrAvatarTransform(transform.localPosition, transform.localRotation);
			if (ovrAvatarTransform2.position != transforms[i].position || ovrAvatarTransform2.orientation != transforms[i].orientation)
			{
				transforms[i] = ovrAvatarTransform2;
				result = true;
			}
		}
		return result;
	}

	private static void OrderJoints(Transform transform, List<Transform> joints)
	{
		joints.Add(transform);
		for (int i = 0; i < transform.childCount; i++)
		{
			OrderJoints(transform.GetChild(i), joints);
		}
	}

	private void AvatarSpecificationCallback(IntPtr avatarSpecification)
	{
		sdkAvatar = CAPI.ovrAvatar_Create(avatarSpecification, Capabilities);
		ShowLeftController(showLeftController);
		ShowRightController(showRightController);
		if (Driver != null)
		{
			Driver.UpdateTransformsFromPose(sdkAvatar);
		}
		uint num = CAPI.ovrAvatar_GetReferencedAssetCount(sdkAvatar);
		for (uint num2 = 0u; num2 < num; num2++)
		{
			ulong num3 = CAPI.ovrAvatar_GetReferencedAsset(sdkAvatar, num2);
			if (OvrAvatarSDKManager.Instance.GetAsset(num3) == null)
			{
				OvrAvatarSDKManager.Instance.BeginLoadingAsset(num3, LevelOfDetail, AssetLoadedCallback);
				assetLoadingIds.Add(num3);
			}
		}
		if (CombineMeshes)
		{
			OvrAvatarSDKManager.Instance.RegisterCombinedMeshCallback(sdkAvatar, CombinedMeshLoadedCallback);
		}
	}

	private void Start()
	{
		if (!(OvrAvatarSDKManager.Instance == null))
		{
			if (CombineMeshes)
			{
				CombineMeshes = false;
			}
			materialManager = base.gameObject.AddComponent<OvrAvatarMaterialManager>();
			try
			{
				oculusUserIDInternal = ulong.Parse(oculusUserID);
			}
			catch (Exception)
			{
				oculusUserIDInternal = 0uL;
			}
			if (oculusUserIDInternal == 0L)
			{
				CombineMeshes = false;
			}
			Capabilities = (ovrAvatarCapabilities)0;
			if (EnableBody)
			{
				Capabilities |= ovrAvatarCapabilities.Body;
			}
			if (EnableHands)
			{
				Capabilities |= ovrAvatarCapabilities.Hands;
			}
			if (EnableBase && EnableBody)
			{
				Capabilities |= ovrAvatarCapabilities.Base;
			}
			if (EnableExpressive)
			{
				Capabilities |= ovrAvatarCapabilities.Expressive;
			}
			if (OVRPlugin.positionSupported)
			{
				Capabilities |= ovrAvatarCapabilities.BodyTilt;
			}
			ShowLeftController(StartWithControllers);
			ShowRightController(StartWithControllers);
			OvrAvatarSDKManager.AvatarSpecRequestParams avatarSpecRequest = new OvrAvatarSDKManager.AvatarSpecRequestParams(oculusUserIDInternal, AvatarSpecificationCallback, CombineMeshes, LevelOfDetail, forceMobileTextureFormat: false, LookAndFeelVersion, FallbackLookAndFeelVersion, EnableExpressive);
			OvrAvatarSDKManager.Instance.RequestAvatarSpecification(avatarSpecRequest);
			OvrAvatarSDKManager.Instance.AddLoadingAvatar(GetInstanceID());
			waitingForCombinedMesh = CombineMeshes;
			if (Driver != null)
			{
				Driver.Mode = ((!UseSDKPackets) ? OvrAvatarDriver.PacketMode.Unity : OvrAvatarDriver.PacketMode.SDK);
			}
		}
	}

	private void Update()
	{
		if (!OvrAvatarSDKManager.Instance || sdkAvatar == IntPtr.Zero || materialManager == null)
		{
			return;
		}
		if (Driver != null)
		{
			Driver.UpdateTransforms(sdkAvatar);
			foreach (float[] voiceUpdate in voiceUpdates)
			{
				CAPI.ovrAvatarPose_UpdateVoiceVisualization(sdkAvatar, voiceUpdate);
			}
			voiceUpdates.Clear();
			CAPI.ovrAvatarPose_Finalize(sdkAvatar, Time.deltaTime);
		}
		if (RecordPackets)
		{
			RecordFrame();
		}
		if (assetLoadingIds.Count != 0)
		{
			return;
		}
		if (!assetsFinishedLoading)
		{
			try
			{
				BuildRenderComponents();
			}
			catch (Exception ex)
			{
				assetsFinishedLoading = true;
				throw ex;
			}
			AssetsDoneLoading.Invoke();
			InitPostLoad();
			assetsFinishedLoading = true;
			OvrAvatarSDKManager.Instance.RemoveLoadingAvatar(GetInstanceID());
		}
		UpdateVoiceBehavior();
		UpdateCustomPoses();
		if (EnableExpressive)
		{
			UpdateExpressive();
		}
	}

	public static ovrAvatarHandInputState CreateInputState(ovrAvatarTransform transform, OvrAvatarDriver.ControllerPose pose)
	{
		return new ovrAvatarHandInputState
		{
			transform = transform,
			buttonMask = pose.buttons,
			touchMask = pose.touches,
			joystickX = pose.joystickPosition.x,
			joystickY = pose.joystickPosition.y,
			indexTrigger = pose.indexTrigger,
			handTrigger = pose.handTrigger,
			isActive = pose.isActive
		};
	}

	public void ShowControllers(bool show)
	{
		ShowLeftController(show);
		ShowRightController(show);
	}

	public void ShowLeftController(bool show)
	{
		if (sdkAvatar != IntPtr.Zero)
		{
			CAPI.ovrAvatar_SetLeftControllerVisibility(sdkAvatar, show);
		}
		showLeftController = show;
	}

	public void ShowRightController(bool show)
	{
		if (sdkAvatar != IntPtr.Zero)
		{
			CAPI.ovrAvatar_SetRightControllerVisibility(sdkAvatar, show);
		}
		showRightController = show;
	}

	public void UpdateVoiceVisualization(float[] voiceSamples)
	{
		voiceUpdates.Add(voiceSamples);
	}

	private void RecordFrame()
	{
		if (UseSDKPackets)
		{
			RecordSDKFrame();
		}
		else
		{
			RecordUnityFrame();
		}
	}

	private void RecordUnityFrame()
	{
		float num = Time.deltaTime;
		OvrAvatarDriver.PoseFrame currentPose = Driver.GetCurrentPose();
		if (CurrentUnityPacket == null)
		{
			CurrentUnityPacket = new OvrAvatarPacket(currentPose);
			num = 0f;
		}
		float num2 = 0f;
		while (num2 < num)
		{
			float num3 = num - num2;
			float num4 = PacketSettings.UpdateRate - CurrentUnityPacket.Duration;
			if (num3 < num4)
			{
				CurrentUnityPacket.AddFrame(currentPose, num3);
				num2 += num3;
				continue;
			}
			OvrAvatarDriver.PoseFrame finalFrame = CurrentUnityPacket.FinalFrame;
			OvrAvatarDriver.PoseFrame b = currentPose;
			float t = num4 / num3;
			OvrAvatarDriver.PoseFrame poseFrame = OvrAvatarDriver.PoseFrame.Interpolate(finalFrame, b, t);
			CurrentUnityPacket.AddFrame(poseFrame, num4);
			num2 += num4;
			if (PacketRecorded != null)
			{
				PacketRecorded(this, new PacketEventArgs(CurrentUnityPacket));
			}
			CurrentUnityPacket = new OvrAvatarPacket(poseFrame);
		}
	}

	private void RecordSDKFrame()
	{
		if (sdkAvatar == IntPtr.Zero)
		{
			return;
		}
		if (!PacketSettings.RecordingFrames)
		{
			CAPI.ovrAvatarPacket_BeginRecording(sdkAvatar);
			PacketSettings.AccumulatedTime = 0f;
			PacketSettings.RecordingFrames = true;
		}
		PacketSettings.AccumulatedTime += Time.deltaTime;
		if (PacketSettings.AccumulatedTime >= PacketSettings.UpdateRate)
		{
			PacketSettings.AccumulatedTime = 0f;
			IntPtr intPtr = CAPI.ovrAvatarPacket_EndRecording(sdkAvatar);
			CAPI.ovrAvatarPacket_BeginRecording(sdkAvatar);
			if (PacketRecorded != null)
			{
				PacketRecorded(this, new PacketEventArgs(new OvrAvatarPacket
				{
					ovrNativePacket = intPtr
				}));
			}
			CAPI.ovrAvatarPacket_Free(intPtr);
		}
	}

	private void AddRenderParts(OvrAvatarComponent ovrComponent, ovrAvatarComponent component, Transform parent)
	{
		bool flag = ovrComponent.name == "body";
		bool flag2 = ovrComponent.name == "controller_left";
		bool flag3 = ovrComponent.name == "controller_right";
		for (uint num = 0u; num < component.renderPartCount; num++)
		{
			GameObject gameObject = new GameObject();
			gameObject.name = GetRenderPartName(component, num);
			gameObject.transform.SetParent(parent);
			IntPtr renderPart = GetRenderPart(component, num);
			ovrAvatarRenderPartType ovrAvatarRenderPartType2 = CAPI.ovrAvatarRenderPart_GetType(renderPart);
			OvrAvatarRenderComponent ovrAvatarRenderComponent = null;
			switch (ovrAvatarRenderPartType2)
			{
			case ovrAvatarRenderPartType.SkinnedMeshRender:
				ovrAvatarRenderComponent = AddSkinnedMeshRenderComponent(gameObject, CAPI.ovrAvatarRenderPart_GetSkinnedMeshRender(renderPart));
				break;
			case ovrAvatarRenderPartType.SkinnedMeshRenderPBS:
				ovrAvatarRenderComponent = AddSkinnedMeshRenderPBSComponent(gameObject, CAPI.ovrAvatarRenderPart_GetSkinnedMeshRenderPBS(renderPart));
				break;
			case ovrAvatarRenderPartType.SkinnedMeshRenderPBS_V2:
				ovrAvatarRenderComponent = AddSkinnedMeshRenderPBSV2Component(renderPart, gameObject, CAPI.ovrAvatarRenderPart_GetSkinnedMeshRenderPBSV2(renderPart), flag && num == 0, flag2 || flag3);
				break;
			}
			if (ovrAvatarRenderComponent != null)
			{
				ovrComponent.RenderParts.Add(ovrAvatarRenderComponent);
			}
		}
	}

	public void RefreshBodyParts()
	{
		if (!(Body != null))
		{
			return;
		}
		foreach (OvrAvatarRenderComponent renderPart in Body.RenderParts)
		{
			UnityEngine.Object.Destroy(renderPart.gameObject);
		}
		Body.RenderParts.Clear();
		ovrAvatarComponent? nativeAvatarComponent = Body.GetNativeAvatarComponent();
		if (nativeAvatarComponent.HasValue)
		{
			AddRenderParts(Body, nativeAvatarComponent.Value, Body.gameObject.transform);
		}
	}

	public ovrAvatarBodyComponent? GetBodyComponent()
	{
		if (Body != null)
		{
			CAPI.ovrAvatarPose_GetBodyComponent(sdkAvatar, ref Body.component);
			return Body.component;
		}
		return null;
	}

	public Transform GetHandTransform(HandType hand, HandJoint joint)
	{
		if (hand >= HandType.Max || joint >= HandJoint.Max)
		{
			return null;
		}
		OvrAvatarHand ovrAvatarHand = ((hand == HandType.Left) ? HandLeft : HandRight);
		if (ovrAvatarHand != null)
		{
			OvrAvatarComponent component = ovrAvatarHand.GetComponent<OvrAvatarComponent>();
			if (component != null && component.RenderParts.Count > 0)
			{
				return component.RenderParts[0].transform.Find(HandJoints[(int)hand, (int)joint]);
			}
		}
		return null;
	}

	public void GetPointingDirection(HandType hand, ref Vector3 forward, ref Vector3 up)
	{
		Transform handTransform = GetHandTransform(hand, HandJoint.HandBase);
		if (handTransform != null)
		{
			forward = handTransform.forward;
			up = handTransform.up;
		}
	}

	private void UpdateVoiceBehavior()
	{
		if (EnableMouthVertexAnimation && Body != null)
		{
			OvrAvatarComponent component = Body.GetComponent<OvrAvatarComponent>();
			VoiceAmplitude = Mathf.Clamp(VoiceAmplitude, 0f, 1f);
			if (component.RenderParts.Count > 0)
			{
				Material sharedMaterial = component.RenderParts[0].mesh.sharedMaterial;
				Transform transform = component.RenderParts[0].mesh.transform.Find(NECK_JONT);
				Vector3 vector = transform.TransformPoint(Vector3.up) - transform.position;
				sharedMaterial.SetFloat(MOUTH_SCALE_PROPERTY, vector.magnitude);
				sharedMaterial.SetFloat(VOICE_PROPERTY, Mathf.Min(vector.magnitude * MOUTH_MAX_GLOBAL, vector.magnitude * VoiceAmplitude * MOUTH_SCALE_GLOBAL));
				sharedMaterial.SetVector(MOUTH_POSITION_PROPERTY, transform.TransformPoint(MOUTH_POSITION_OFFSET));
				sharedMaterial.SetVector(MOUTH_DIRECTION_PROPERTY, transform.up);
			}
		}
	}

	private bool IsValidMic()
	{
		string[] devices = Microphone.devices;
		if (devices.Length < 1)
		{
			return false;
		}
		int num = 0;
		for (int i = 1; i < devices.Length; i++)
		{
			if (devices[i].ToUpper().Contains("RIFT"))
			{
				num = i;
				break;
			}
		}
		string deviceName = devices[num];
		Microphone.GetDeviceCaps(deviceName, out var _, out var maxFreq);
		if (maxFreq == 0)
		{
			maxFreq = 44100;
		}
		if (Microphone.Start(deviceName, loop: true, 1, maxFreq) == null)
		{
			return false;
		}
		Microphone.End(deviceName);
		return true;
	}

	private void InitPostLoad()
	{
		ExpressiveGlobalInit();
		ConfigureHelpers();
		if (GetComponent<OvrAvatarLocalDriver>() != null)
		{
			lipsyncContext.audioLoopback = false;
			if (CanOwnMicrophone && IsValidMic())
			{
				micInput = MouthAnchor.gameObject.AddComponent<OVRLipSyncMicInput>();
				micInput.enableMicSelectionGUI = false;
				micInput.MicFrequency = 44100f;
				micInput.micControl = OVRLipSyncMicInput.micActivation.ConstantSpeak;
			}
			CAPI.ovrAvatar_SetActionUnitOnsetSpeed(sdkAvatar, 30f);
			CAPI.ovrAvatar_SetActionUnitFalloffSpeed(sdkAvatar, 20f);
			CAPI.ovrAvatar_SetVisemeMultiplier(sdkAvatar, 1.5f);
		}
	}

	private static void ExpressiveGlobalInit()
	{
		if (!doneExpressiveGlobalInit)
		{
			doneExpressiveGlobalInit = true;
			ovrLights.lights = new ovrAvatarLight[16];
			InitializeLights();
		}
	}

	private static void InitializeLights()
	{
		ovrLights.ambientIntensity = RenderSettings.ambientLight.grayscale * 0.5f;
		Light[] array = UnityEngine.Object.FindObjectsOfType(typeof(Light)) as Light[];
		int num = 0;
		for (num = 0; num < array.Length && num < ovrLights.lights.Length; num++)
		{
			Light light = array[num];
			if ((bool)light && light.enabled)
			{
				uint instanceID = (uint)light.transform.GetInstanceID();
				switch (light.type)
				{
				case LightType.Directional:
					CreateLightDirectional(instanceID, light.transform.forward, light.intensity, ref ovrLights.lights[num]);
					break;
				case LightType.Point:
					CreateLightPoint(instanceID, light.transform.position, light.range, light.intensity, ref ovrLights.lights[num]);
					break;
				case LightType.Spot:
					CreateLightSpot(instanceID, light.transform.position, light.transform.forward, light.spotAngle, light.range, light.intensity, ref ovrLights.lights[num]);
					break;
				}
			}
		}
		ovrLights.lightCount = (uint)num;
		CAPI.ovrAvatar_UpdateLights(ovrLights);
	}

	private static ovrAvatarLight CreateLightDirectional(uint id, Vector3 direction, float intensity, ref ovrAvatarLight light)
	{
		light.id = id;
		light.type = ovrAvatarLightType.Direction;
		light.worldDirection = new Vector3(direction.x, direction.y, 0f - direction.z);
		light.intensity = intensity;
		return light;
	}

	private static ovrAvatarLight CreateLightPoint(uint id, Vector3 position, float range, float intensity, ref ovrAvatarLight light)
	{
		light.id = id;
		light.type = ovrAvatarLightType.Point;
		light.worldPosition = new Vector3(position.x, position.y, 0f - position.z);
		light.range = range;
		light.intensity = intensity;
		return light;
	}

	private static ovrAvatarLight CreateLightSpot(uint id, Vector3 position, Vector3 direction, float spotAngleDeg, float range, float intensity, ref ovrAvatarLight light)
	{
		light.id = id;
		light.type = ovrAvatarLightType.Spot;
		light.worldPosition = new Vector3(position.x, position.y, 0f - position.z);
		light.worldDirection = new Vector3(direction.x, direction.y, 0f - direction.z);
		light.spotAngleDeg = spotAngleDeg;
		light.range = range;
		light.intensity = intensity;
		return light;
	}

	private void UpdateExpressive()
	{
		ovrAvatarTransform ovrAvatarTransform2 = CreateOvrAvatarTransform(base.transform.position, base.transform.rotation);
		CAPI.ovrAvatar_UpdateWorldTransform(sdkAvatar, ovrAvatarTransform2);
		UpdateFacewave();
	}

	private void ConfigureHelpers()
	{
		Transform transform = base.transform.Find("body/body_renderPart_0/root_JNT/body_JNT/chest_JNT/neckBase_JNT/neck_JNT/head_JNT");
		if (transform == null)
		{
			transform = base.transform;
		}
		if (MouthAnchor == null)
		{
			MouthAnchor = CreateHelperObject(transform, MOUTH_HEAD_OFFSET, "MouthAnchor");
		}
		if (GetComponent<OvrAvatarLocalDriver>() != null)
		{
			if (audioSource == null)
			{
				audioSource = MouthAnchor.gameObject.AddComponent<AudioSource>();
			}
			spatializedSource = MouthAnchor.GetComponent<ONSPAudioSource>();
			if (spatializedSource == null)
			{
				spatializedSource = MouthAnchor.gameObject.AddComponent<ONSPAudioSource>();
			}
			spatializedSource.UseInvSqr = true;
			spatializedSource.EnableRfl = false;
			spatializedSource.EnableSpatialization = true;
			spatializedSource.Far = 100f;
			spatializedSource.Near = 0.1f;
			lipsyncContext = MouthAnchor.GetComponent<OVRLipSyncContext>();
			if (lipsyncContext == null)
			{
				lipsyncContext = MouthAnchor.gameObject.AddComponent<OVRLipSyncContext>();
			}
			lipsyncContext.provider = ((!EnableLaughter) ? OVRLipSync.ContextProviders.Enhanced : OVRLipSync.ContextProviders.Enhanced_with_Laughter);
			lipsyncContext.skipAudioSource = !CanOwnMicrophone;
			StartCoroutine(WaitForMouthAudioSource());
		}
		if (GetComponent<OvrAvatarRemoteDriver>() != null)
		{
			transform.gameObject.AddComponent<GazeTarget>().Type = ovrAvatarGazeTargetType.AvatarHead;
			Transform transform2 = base.transform.Find("hand_left");
			if (!(transform2 == null))
			{
				transform2.gameObject.AddComponent<GazeTarget>().Type = ovrAvatarGazeTargetType.AvatarHand;
			}
			transform2 = base.transform.Find("hand_right");
			if (!(transform2 == null))
			{
				transform2.gameObject.AddComponent<GazeTarget>().Type = ovrAvatarGazeTargetType.AvatarHand;
			}
		}
	}

	private IEnumerator WaitForMouthAudioSource()
	{
		while (MouthAnchor.GetComponent<AudioSource>() == null)
		{
			yield return new WaitForSeconds(0.1f);
		}
		AudioSource component = MouthAnchor.GetComponent<AudioSource>();
		component.minDistance = 0.3f;
		component.maxDistance = 4f;
		component.rolloffMode = AudioRolloffMode.Logarithmic;
		component.loop = true;
		component.playOnAwake = true;
		component.spatialBlend = 1f;
		component.spatialize = true;
		component.spatializePostEffects = true;
	}

	public void DestroyHelperObjects()
	{
		if ((bool)MouthAnchor)
		{
			UnityEngine.Object.DestroyImmediate(MouthAnchor.gameObject);
		}
	}

	public GameObject CreateHelperObject(Transform parent, Vector3 localPositionOffset, string helperName, string helperTag = "")
	{
		GameObject gameObject = new GameObject();
		gameObject.name = helperName;
		if (helperTag != "")
		{
			gameObject.tag = helperTag;
		}
		gameObject.transform.SetParent(parent);
		gameObject.transform.localRotation = Quaternion.identity;
		gameObject.transform.localPosition = localPositionOffset;
		return gameObject;
	}

	public void UpdateVoiceData(short[] pcmData, int numChannels)
	{
		if (lipsyncContext != null && micInput == null)
		{
			lipsyncContext.ProcessAudioSamplesRaw(pcmData, numChannels);
		}
	}

	public void UpdateVoiceData(float[] pcmData, int numChannels)
	{
		if (lipsyncContext != null && micInput == null)
		{
			lipsyncContext.ProcessAudioSamplesRaw(pcmData, numChannels);
		}
	}

	private void UpdateFacewave()
	{
		if (!(lipsyncContext != null) || (!(micInput != null) && CanOwnMicrophone))
		{
			return;
		}
		currentFrame = lipsyncContext.GetCurrentPhonemeFrame();
		if (currentFrame.Visemes.Length != 15)
		{
			Debug.LogError("Unexpected number of visemes " + currentFrame.Visemes);
			return;
		}
		currentFrame.Visemes.CopyTo(visemes, 0);
		visemes[15] = (EnableLaughter ? currentFrame.laughterScore : 0f);
		for (int i = 0; i < 16; i++)
		{
			RuntimeVisemes.visemeParams[i] = visemes[i];
		}
		CAPI.ovrAvatar_SetVisemes(sdkAvatar, RuntimeVisemes);
	}
}
