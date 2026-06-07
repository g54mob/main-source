using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Cinemachine
{
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[SaveDuringPlay]
	public class CinemachineBrain : MonoBehaviour
	{
		public enum UpdateMethod
		{
			FixedUpdate = 0,
			LateUpdate = 1,
			SmartUpdate = 2,
			ManualUpdate = 3
		}

		public enum BrainUpdateMethod
		{
			FixedUpdate = 0,
			LateUpdate = 1
		}

		[Serializable]
		public class BrainEvent : UnityEvent<CinemachineBrain>
		{
		}

		[Serializable]
		public class VcamActivatedEvent : UnityEvent<ICinemachineCamera, ICinemachineCamera>
		{
		}

		private class BrainFrame
		{
			public int id;

			public CinemachineBlend blend;

			public CinemachineBlend workingBlend;

			public BlendSourceVirtualCamera workingBlendSource;

			public float deltaTimeOverride;

			public bool Active => false;
		}

		public bool m_ShowDebugText;

		public bool m_ShowCameraFrustum;

		public bool m_IgnoreTimeScale;

		public Transform m_WorldUpOverride;

		public UpdateMethod m_UpdateMethod;

		public BrainUpdateMethod m_BlendUpdateMethod;

		[CinemachineBlendDefinitionProperty]
		public CinemachineBlendDefinition m_DefaultBlend;

		public CinemachineBlenderSettings m_CustomBlends;

		private Camera m_OutputCamera;

		public BrainEvent m_CameraCutEvent;

		public VcamActivatedEvent m_CameraActivatedEvent;

		private static ICinemachineCamera mSoloCamera;

		private Coroutine mPhysicsCoroutine;

		private int m_LastFrameUpdated;

		private WaitForFixedUpdate mWaitForFixedUpdate;

		private List<BrainFrame> mFrameStack;

		private int mNextFrameId;

		private CinemachineBlend mCurrentLiveCameras;

		private static readonly AnimationCurve mDefaultLinearAnimationCurve;

		private ICinemachineCamera mActiveCameraPreviousFrame;

		private GameObject mActiveCameraPreviousFrameGameObject;

		public Camera OutputCamera => null;

		public static ICinemachineCamera SoloCamera
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector3 DefaultWorldUp => default(Vector3);

		public ICinemachineCamera ActiveVirtualCamera => null;

		public bool IsBlending => false;

		public CinemachineBlend ActiveBlend => null;

		public CameraState CurrentCameraState { get; private set; }

		public static Color GetSoloGUIColor()
		{
			return default(Color);
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
		}

		private void OnSceneUnloaded(Scene scene)
		{
		}

		private void Start()
		{
		}

		private void OnGuiHandler()
		{
		}

		private IEnumerator AfterPhysics()
		{
			return null;
		}

		private void LateUpdate()
		{
		}

		public void ManualUpdate()
		{
		}

		private float GetEffectiveDeltaTime(bool fixedDelta)
		{
			return 0f;
		}

		private void UpdateVirtualCameras(CinemachineCore.UpdateFilter updateFilter, float deltaTime)
		{
		}

		private static ICinemachineCamera DeepCamBFromBlend(CinemachineBlend blend)
		{
			return null;
		}

		private int GetBrainFrame(int withId)
		{
			return 0;
		}

		public int SetCameraOverride(int overrideId, ICinemachineCamera camA, ICinemachineCamera camB, float weightB, float deltaTime)
		{
			return 0;
		}

		public void ReleaseCameraOverride(int overrideId)
		{
		}

		private void ProcessActiveCamera(float deltaTime)
		{
		}

		private void UpdateFrame0(float deltaTime)
		{
		}

		public void ComputeCurrentBlend(ref CinemachineBlend outputBlend, int numTopLayersToExclude)
		{
		}

		public bool IsLive(ICinemachineCamera vcam, bool dominantChildOnly = false)
		{
			return false;
		}

		private ICinemachineCamera TopCameraFromPriorityQueue()
		{
			return null;
		}

		private CinemachineBlendDefinition LookupBlend(ICinemachineCamera fromKey, ICinemachineCamera toKey)
		{
			return default(CinemachineBlendDefinition);
		}

		private void PushStateToUnityCamera(in CameraState state)
		{
		}
	}
}
