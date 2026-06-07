using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace UTJ.FrameCapturer
{
	[ExecuteInEditMode]
	public class MovieRecorder : RecorderBase
	{
		public enum CaptureTarget
		{
			FrameBuffer = 0,
			RenderTexture = 1
		}

		[SerializeField]
		private MovieEncoderConfigs m_encoderConfigs;

		[SerializeField]
		private CaptureTarget m_captureTarget;

		[SerializeField]
		private RenderTexture m_targetRT;

		[SerializeField]
		private bool m_captureVideo;

		[SerializeField]
		private bool m_captureAudio;

		[SerializeField]
		private Shader m_shCopy;

		private Material m_matCopy;

		private Mesh m_quad;

		private CommandBuffer m_cb;

		private RenderTexture m_scratchBuffer;

		private MovieEncoder m_encoder;

		public CaptureTarget captureTarget
		{
			get
			{
				return default(CaptureTarget);
			}
			set
			{
			}
		}

		public RenderTexture targetRT
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool captureAudio
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool captureVideo
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool supportVideo => false;

		public bool supportAudio => false;

		public RenderTexture scratchBuffer => null;

		public override bool BeginRecording()
		{
			return false;
		}

		public override void EndRecording()
		{
		}

		private IEnumerator OnPostRender()
		{
			return null;
		}

		private void OnAudioFilterRead(float[] samples, int channels)
		{
		}
	}
}
