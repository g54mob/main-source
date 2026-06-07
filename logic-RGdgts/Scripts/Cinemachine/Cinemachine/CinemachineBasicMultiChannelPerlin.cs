using UnityEngine;

namespace Cinemachine
{
	[SaveDuringPlay]
	public class CinemachineBasicMultiChannelPerlin : CinemachineComponentBase
	{
		[NoiseSettingsProperty]
		public NoiseSettings m_NoiseProfile;

		public Vector3 m_PivotOffset;

		public float m_AmplitudeGain;

		public float m_FrequencyGain;

		private bool mInitialized;

		private float mNoiseTime;

		[SerializeField]
		[HideInInspector]
		private Vector3 mNoiseOffsets;

		public override bool IsValid => false;

		public override CinemachineCore.Stage Stage => default(CinemachineCore.Stage);

		public override void MutateCameraState(ref CameraState curState, float deltaTime)
		{
		}

		public void ReSeed()
		{
		}

		private void Initialize()
		{
		}
	}
}
