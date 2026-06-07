using System;

namespace NAudio.Dsp
{
	internal class WdlResampler
	{
		private class WDL_Resampler_IIRFilter
		{
			private double m_fpos;

			private double m_a1;

			private double m_a2;

			private double m_b0;

			private double m_b1;

			private double m_b2;

			private double[,] m_hist;

			public void Reset()
			{
			}

			public void setParms(double fpos, double Q)
			{
			}

			public void Apply(float[] inBuffer, int inIndex, float[] outBuffer, int outIndex, int ns, int span, int w)
			{
			}

			private double denormal_filter(float x)
			{
				return 0.0;
			}

			private double denormal_filter(double x)
			{
				return 0.0;
			}
		}

		private const int WDL_RESAMPLE_MAX_FILTERS = 4;

		private const int WDL_RESAMPLE_MAX_NCH = 64;

		private const double PI = Math.PI;

		private double m_sratein;

		private double m_srateout;

		private double m_fracpos;

		private double m_ratio;

		private double m_filter_ratio;

		private float m_filterq;

		private float m_filterpos;

		private float[] m_rsinbuf;

		private float[] m_filter_coeffs;

		private WDL_Resampler_IIRFilter m_iirfilter;

		private int m_filter_coeffs_size;

		private int m_last_requested;

		private int m_filtlatency;

		private int m_samples_in_rsinbuf;

		private int m_lp_oversize;

		private int m_sincsize;

		private int m_filtercnt;

		private int m_sincoversize;

		private bool m_interp;

		private bool m_feedmode;

		public void SetMode(bool interp, int filtercnt, bool sinc, int sinc_size = 64, int sinc_interpsize = 32)
		{
		}

		public void SetFilterParms(float filterpos = 0.693f, float filterq = 0.707f)
		{
		}

		public void SetFeedMode(bool wantInputDriven)
		{
		}

		public void Reset(double fracpos = 0.0)
		{
		}

		public void SetRates(double rate_in, double rate_out)
		{
		}

		public double GetCurrentLatency()
		{
			return 0.0;
		}

		public int ResamplePrepare(int out_samples, int nch, out float[] inbuffer, out int inbufferOffset)
		{
			inbuffer = null;
			inbufferOffset = default(int);
			return 0;
		}

		public int ResampleOut(float[] outBuffer, int outBufferIndex, int nsamples_in, int nsamples_out, int nch)
		{
			return 0;
		}

		private void BuildLowPass(double filtpos)
		{
		}

		private void SincSample(float[] outBuffer, int outBufferIndex, float[] inBuffer, int inBufferIndex, double fracpos, int nch, float[] filter, int filterIndex, int filtsz)
		{
		}

		private void SincSample1(float[] outBuffer, int outBufferIndex, float[] inBuffer, int inBufferIndex, double fracpos, float[] filter, int filterIndex, int filtsz)
		{
		}

		private void SincSample2(float[] outptr, int outBufferIndex, float[] inBuffer, int inBufferIndex, double fracpos, float[] filter, int filterIndex, int filtsz)
		{
		}
	}
}
