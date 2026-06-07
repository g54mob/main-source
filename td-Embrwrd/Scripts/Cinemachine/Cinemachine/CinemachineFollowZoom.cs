using UnityEngine;

namespace Cinemachine
{
	[AddComponentMenu(null)]
	[DocumentationSorting(DocumentationSortingAttribute.Level.UserRef)]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.cinemachine@2.9/manual/CinemachineFollowZoom.html")]
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[SaveDuringPlay]
	public class CinemachineFollowZoom : CinemachineExtension
	{
		private class VcamExtraState
		{
			public float m_previousFrameZoom;
		}

		[Tooltip("The shot width to maintain, in world units, at target distance.")]
		public float m_Width;

		[Range(0f, 20f)]
		[Tooltip("Increase this value to soften the aggressiveness of the follow-zoom.  Small numbers are more responsive, larger numbers give a more heavy slowly responding camera.")]
		public float m_Damping;

		[Tooltip("Lower limit for the FOV that this behaviour will generate.")]
		[Range(1f, 179f)]
		public float m_MinFOV;

		[Tooltip("Upper limit for the FOV that this behaviour will generate.")]
		[Range(1f, 179f)]
		public float m_MaxFOV;

		private void OnValidate()
		{
		}

		public override float GetMaxDampTime()
		{
			return 0f;
		}

		protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
		{
		}
	}
}
