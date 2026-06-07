using UnityEngine;

namespace UTJ.FrameCapturer
{
	[ExecuteInEditMode]
	public class AudioRecorder : RecorderBase
	{
		[SerializeField]
		private AudioEncoderConfigs m_encoderConfigs;

		private AudioEncoder m_encoder;

		public override bool BeginRecording()
		{
			return false;
		}

		public override void EndRecording()
		{
		}

		private void LateUpdate()
		{
		}

		private void OnAudioFilterRead(float[] samples, int channels)
		{
		}
	}
}
