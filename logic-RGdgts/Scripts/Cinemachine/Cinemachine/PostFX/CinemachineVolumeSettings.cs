using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Cinemachine.PostFX
{
	[ExecuteAlways]
	[SaveDuringPlay]
	[DisallowMultipleComponent]
	public class CinemachineVolumeSettings : CinemachineExtension
	{
		public enum FocusTrackingMode
		{
			None = 0,
			LookAtTarget = 1,
			FollowTarget = 2,
			CustomTarget = 3,
			Camera = 4
		}

		private class VcamExtraState
		{
			public VolumeProfile mProfileCopy;

			public void CreateProfileCopy(VolumeProfile source)
			{
			}

			public void DestroyProfileCopy()
			{
			}
		}

		public static float s_VolumePriority;

		[HideInInspector]
		public bool m_FocusTracksTarget;

		public FocusTrackingMode m_FocusTracking;

		public Transform m_FocusTarget;

		public float m_FocusOffset;

		public VolumeProfile m_Profile;

		private static string sVolumeOwnerName;

		private static List<Volume> sVolumes;

		public bool IsValid => false;

		public void InvalidateCachedProfile()
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
		{
		}

		private static void OnCameraCut(CinemachineBrain brain)
		{
		}

		private static void ApplyPostFX(CinemachineBrain brain)
		{
		}

		private static List<Volume> GetDynamicBrainVolumes(CinemachineBrain brain, int minVolumes)
		{
			return null;
		}

		[RuntimeInitializeOnLoadMethod]
		private static void InitializeModule()
		{
		}
	}
}
