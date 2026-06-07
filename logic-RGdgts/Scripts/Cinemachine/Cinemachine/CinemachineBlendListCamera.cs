using System;
using UnityEngine;

namespace Cinemachine
{
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[ExcludeFromPreset]
	public class CinemachineBlendListCamera : CinemachineVirtualCameraBase
	{
		[Serializable]
		public struct Instruction
		{
			public CinemachineVirtualCameraBase m_VirtualCamera;

			public float m_Hold;

			[CinemachineBlendDefinitionProperty]
			public CinemachineBlendDefinition m_Blend;
		}

		[NoSaveDuringPlay]
		[VcamTargetProperty]
		public Transform m_LookAt;

		[NoSaveDuringPlay]
		[VcamTargetProperty]
		public Transform m_Follow;

		public bool m_ShowDebugText;

		public bool m_Loop;

		[SerializeField]
		[HideInInspector]
		[NoSaveDuringPlay]
		internal CinemachineVirtualCameraBase[] m_ChildCameras;

		public Instruction[] m_Instructions;

		private CameraState m_State;

		private float mActivationTime;

		private int mCurrentInstruction;

		private CinemachineBlend mActiveBlend;

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

		private ICinemachineCamera TransitioningFrom { get; set; }

		public CinemachineVirtualCameraBase[] ChildCameras => null;

		public bool IsBlending => false;

		private void Reset()
		{
		}

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

		public override void OnTransitionFromCamera(ICinemachineCamera fromCam, Vector3 worldUp, float deltaTime)
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

		private void OnTransformChildrenChanged()
		{
		}

		private void OnGuiHandler()
		{
		}

		private void InvalidateListOfChildren()
		{
		}

		private void UpdateListOfChildren()
		{
		}

		internal void ValidateInstructions()
		{
		}

		private void AdvanceCurrentInstruction(float deltaTime)
		{
		}
	}
}
