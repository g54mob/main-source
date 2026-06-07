using System;
using NAudio.MediaFoundation;

namespace NAudio.Wave
{
	public class MediaFoundationResampler : MediaFoundationTransform
	{
		private int resamplerQuality;

		private static readonly Guid ResamplerClsid;

		private static readonly Guid IMFTransformIid;

		private IMFActivate activate;

		public int ResamplerQuality
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		private static bool IsPcmOrIeeeFloat(WaveFormat waveFormat)
		{
			return false;
		}

		public MediaFoundationResampler(IWaveProvider sourceProvider, WaveFormat outputFormat)
			: base(null, null)
		{
		}

		private void FreeComObject(object comObject)
		{
		}

		private object CreateResamplerComObject()
		{
			return null;
		}

		private object CreateResamplerComObjectUsingActivator()
		{
			return null;
		}

		public MediaFoundationResampler(IWaveProvider sourceProvider, int outputSampleRate)
			: base(null, null)
		{
		}

		protected override IMFTransform CreateTransform()
		{
			return null;
		}

		private static WaveFormat CreateOutputFormat(WaveFormat inputFormat, int outputSampleRate)
		{
			return null;
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
