using UnityEngine;
using UnityEngine.Serialization;

namespace Cinemachine
{
	[DocumentationSorting(DocumentationSortingAttribute.Level.UserRef)]
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[ExcludeFromPreset]
	[AddComponentMenu("Cinemachine/CinemachineVirtualCamera")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.cinemachine@2.9/manual/CinemachineVirtualCamera.html")]
	public class CinemachineVirtualCamera : CinemachineVirtualCameraBase
	{
		public delegate Transform CreatePipelineDelegate(CinemachineVirtualCamera vcam, string name, CinemachineComponentBase[] copyFrom);

		public delegate void DestroyPipelineDelegate(GameObject pipeline);

		[Tooltip("The object that the camera wants to look at (the Aim target).  If this is null, then the vcam's Transform orientation will define the camera's orientation.")]
		[NoSaveDuringPlay]
		[VcamTargetProperty]
		public Transform m_LookAt;

		[Tooltip("The object that the camera wants to move with (the Body target).  If this is null, then the vcam's Transform position will define the camera's position.")]
		[NoSaveDuringPlay]
		[VcamTargetProperty]
		public Transform m_Follow;

		[FormerlySerializedAs("m_LensAttributes")]
		[Tooltip("Specifies the lens properties of this Virtual Camera.  This generally mirrors the Unity Camera's lens settings, and will be used to drive the Unity camera when the vcam is active.")]
		public LensSettings m_Lens;

		public TransitionParams m_Transitions;

		[SerializeField]
		[HideInInspector]
		[FormerlySerializedAs("m_BlendHint")]
		[FormerlySerializedAs("m_PositionBlending")]
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

		internal void DestroyPipeline()
		{
		}

		internal Transform CreatePipeline(CinemachineVirtualCamera copyFrom)
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

		public T GetCinemachineComponent<T>()
		{
			return default(T);
		}

		public T AddCinemachineComponent<T>()
		{
			return default(T);
		}

		public void DestroyCinemachineComponent<T>()
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

		internal override bool RequiresUserInput()
		{
			return false;
		}

		internal override void OnBeforeSerialize()
		{
		}
	}
}
