using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace UTJ.FrameCapturer
{
	[ExecuteInEditMode]
	public class GBufferRecorder : RecorderBase
	{
		[Serializable]
		public struct FrameBufferConponents
		{
			public bool frameBuffer;

			public bool fbColor;

			public bool fbAlpha;

			public bool GBuffer;

			public bool gbAlbedo;

			public bool gbOcclusion;

			public bool gbSpecular;

			public bool gbSmoothness;

			public bool gbNormal;

			public bool gbEmission;

			public bool gbDepth;

			public bool gbVelocity;

			public static FrameBufferConponents defaultValue => default(FrameBufferConponents);
		}

		private class BufferRecorder
		{
			private RenderTexture m_rt;

			private int m_channels;

			private int m_targetFramerate;

			private string m_name;

			private MovieEncoder m_encoder;

			public BufferRecorder(RenderTexture rt, int ch, string name, int tf)
			{
			}

			public bool Initialize(MovieEncoderConfigs c, DataPath p)
			{
				return false;
			}

			public void Release()
			{
			}

			public void Update(double time)
			{
			}
		}

		[SerializeField]
		private MovieEncoderConfigs m_encoderConfigs;

		[SerializeField]
		private FrameBufferConponents m_fbComponents;

		[SerializeField]
		private Shader m_shCopy;

		private Material m_matCopy;

		private Mesh m_quad;

		private CommandBuffer m_cbCopyFB;

		private CommandBuffer m_cbCopyGB;

		private CommandBuffer m_cbClearGB;

		private CommandBuffer m_cbCopyVelocity;

		private RenderTexture[] m_rtFB;

		private RenderTexture[] m_rtGB;

		private List<BufferRecorder> m_recorders;

		public FrameBufferConponents fbComponents
		{
			get
			{
				return default(FrameBufferConponents);
			}
			set
			{
			}
		}

		public MovieEncoderConfigs encoderConfigs => null;

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
	}
}
