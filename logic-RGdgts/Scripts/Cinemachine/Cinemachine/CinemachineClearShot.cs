using UnityEngine;

namespace Cinemachine
{
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[ExcludeFromPreset]
	public class CinemachineClearShot : CinemachineVirtualCameraBase
	{
		private struct Pair
		{
			public int a;

			public float b;
		}

		[NoSaveDuringPlay]
		[VcamTargetProperty]
		public Transform m_LookAt;

		[NoSaveDuringPlay]
		[VcamTargetProperty]
		public Transform m_Follow;

		[NoSaveDuringPlay]
		public bool m_ShowDebugText;

		[SerializeField]
		[HideInInspector]
		[NoSaveDuringPlay]
		internal CinemachineVirtualCameraBase[] m_ChildCameras;

		public float m_ActivateAfter;

		public float m_MinDuration;

		public bool m_RandomizeChoice;

		[CinemachineBlendDefinitionProperty]
		public CinemachineBlendDefinition m_DefaultBlend;

		[HideInInspector]
		public CinemachineBlenderSettings m_CustomBlends;

		private CameraState m_State;

		private float mActivationTime;

		private float mPendingActivationTime;

		private ICinemachineCamera mPendingCamera;

		private CinemachineBlend mActiveBlend;

		private bool mRandomizeNow;

		private CinemachineVirtualCameraBase[] m_RandomizedChilden;

		public override string Description => null;

		public ICinemachineCamera LiveChild { get; set; }

		public override CameraState State => default(CameraState);

		public override Transform LookAt
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override Transform Follow
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsBlending => false;

		public CinemachineVirtualCameraBase[] ChildCameras => null;

		private ICinemachineCamera TransitioningFrom { get; set; }

		public override bool IsLiveChild(ICinemachineCamera vcam, bool dominantChildOnly = false)
		{
			return false;
		}

		public override void OnTargetObjectWarped(Transform target, Vector3 positionDelta)
		{
		}

		public override void ForceCameraPosition(Vector3 pos, Quaternion rot)
		{
		}

		public override void InternalUpdateCameraState(Vector3 worldUp, float deltaTime)
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		public void OnTransformChildrenChanged()
		{
		}

		private void OnGuiHandler()
		{
		}

		private void InvalidateListOfChildren()
		{
		}

		public void ResetRandomization()
		{
		}

		private void UpdateListOfChildren()
		{
		}

		private ICinemachineCamera ChooseCurrentCamera(Vector3 worldUp)
		{
			return null;
		}

		private CinemachineVirtualCameraBase[] Randomize(CinemachineVirtualCameraBase[] src)
		{
			return null;
		}

		private CinemachineBlendDefinition LookupBlend(ICinemachineCamera fromKey, ICinemachineCamera toKey)
		{
			return default(CinemachineBlendDefinition);
		}

		public override void OnTransitionFromCamera(ICinemachineCamera fromCam, Vector3 worldUp, float deltaTime)
		{
		}
	}
}
