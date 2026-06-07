using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine
{
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[ExcludeFromPreset]
	public class CinemachineMixingCamera : CinemachineVirtualCameraBase
	{
		public const int MaxCameras = 8;

		public float m_Weight0;

		public float m_Weight1;

		public float m_Weight2;

		public float m_Weight3;

		public float m_Weight4;

		public float m_Weight5;

		public float m_Weight6;

		public float m_Weight7;

		private CameraState m_State;

		private CinemachineVirtualCameraBase[] m_ChildCameras;

		private Dictionary<CinemachineVirtualCameraBase, int> m_indexMap;

		private ICinemachineCamera LiveChild { get; set; }

		public override CameraState State => default(CameraState);

		public override Transform LookAt { get; set; }

		public override Transform Follow { get; set; }

		public CinemachineVirtualCameraBase[] ChildCameras => null;

		public float GetWeight(int index)
		{
			return 0f;
		}

		public void SetWeight(int index, float w)
		{
		}

		public float GetWeight(CinemachineVirtualCameraBase vcam)
		{
			return 0f;
		}

		public void SetWeight(CinemachineVirtualCameraBase vcam, float w)
		{
		}

		public override void OnTargetObjectWarped(Transform target, Vector3 positionDelta)
		{
		}

		public override void ForceCameraPosition(Vector3 pos, Quaternion rot)
		{
		}

		protected override void OnEnable()
		{
		}

		public void OnTransformChildrenChanged()
		{
		}

		protected override void OnValidate()
		{
		}

		public override bool IsLiveChild(ICinemachineCamera vcam, bool dominantChildOnly = false)
		{
			return false;
		}

		protected void InvalidateListOfChildren()
		{
		}

		protected void ValidateListOfChildren()
		{
		}

		public override void OnTransitionFromCamera(ICinemachineCamera fromCam, Vector3 worldUp, float deltaTime)
		{
		}

		public override void InternalUpdateCameraState(Vector3 worldUp, float deltaTime)
		{
		}
	}
}
