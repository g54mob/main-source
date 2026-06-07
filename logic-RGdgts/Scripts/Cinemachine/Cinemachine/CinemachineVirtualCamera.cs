using UnityEngine;

namespace Cinemachine
{
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[ExcludeFromPreset]
	public class CinemachineVirtualCamera : CinemachineVirtualCameraBase
	{
		public delegate Transform CreatePipelineDelegate(CinemachineVirtualCamera vcam, string name, CinemachineComponentBase[] copyFrom);

		public delegate void DestroyPipelineDelegate(GameObject pipeline);

		[NoSaveDuringPlay]
		[VcamTargetProperty]
		public Transform m_LookAt;

		[NoSaveDuringPlay]
		[VcamTargetProperty]
		public Transform m_Follow;

		public LensSettings m_Lens;

		public TransitionParams m_Transitions;

		[SerializeField]
		[HideInInspector]
		private BlendHint m_LegacyBlendHint;

		public const string PipelineName = "cm";

		public static CreatePipelineDelegate CreatePipelineOverride;

		public static DestroyPipelineDelegate DestroyPipelineOverride;

		private CameraState m_State;

		private CinemachineComponentBase[] m_ComponentPipeline;

		[SerializeField]
		[HideInInspector]
		private Transform m_ComponentOwner;

		private Transform mCachedLookAtTarget;

		private CinemachineVirtualCameraBase mCachedLookAtTargetVcam;

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

		public bool UserIsDragging { get; set; }

		public override float GetMaxDampTime()
		{
			return 0f;
		}

		public override void InternalUpdateCameraState(Vector3 worldUp, float deltaTime)
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void OnValidate()
		{
		}

		private void OnTransformChildrenChanged()
		{
		}

		private void Reset()
		{
		}

		private void DestroyPipeline()
		{
		}

		private Transform CreatePipeline(CinemachineVirtualCamera copyFrom)
		{
			return null;
		}

		public void InvalidateComponentPipeline()
		{
		}

		public Transform GetComponentOwner()
		{
			return null;
		}

		public CinemachineComponentBase[] GetComponentPipeline()
		{
			return null;
		}

		public CinemachineComponentBase GetCinemachineComponent(CinemachineCore.Stage stage)
		{
			return null;
		}

		public T GetCinemachineComponent<T>() where T : CinemachineComponentBase
		{
			return null;
		}

		public T AddCinemachineComponent<T>() where T : CinemachineComponentBase
		{
			return null;
		}

		public void DestroyCinemachineComponent<T>() where T : CinemachineComponentBase
		{
		}

		private void UpdateComponentPipeline()
		{
		}

		internal static void SetFlagsForHiddenChild(GameObject child)
		{
		}

		private CameraState CalculateNewState(Vector3 worldUp, float deltaTime)
		{
			return default(CameraState);
		}

		public override void OnTargetObjectWarped(Transform target, Vector3 positionDelta)
		{
		}

		public override void ForceCameraPosition(Vector3 pos, Quaternion rot)
		{
		}

		internal void SetStateRawPosition(Vector3 pos)
		{
		}

		public override void OnTransitionFromCamera(ICinemachineCamera fromCam, Vector3 worldUp, float deltaTime)
		{
		}
	}
}
