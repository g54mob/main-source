using System;
using System.Threading;

namespace Discord.Sdk
{
	public class VADThresholdSettings : IDisposable
	{
		internal NativeMethods.VADThresholdSettings self;

		private int disposed_;

		internal VADThresholdSettings(NativeMethods.VADThresholdSettings self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~VADThresholdSettings()
		{
			Dispose();
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.VADThresholdSettings* ptr = &self)
				{
					NativeMethods.VADThresholdSettings.Drop(ptr);
				}
			}
		}

		public unsafe float VadThreshold()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("VADThresholdSettings");
			}
			float result;
			fixed (NativeMethods.VADThresholdSettings* ptr = &self)
			{
				result = NativeMethods.VADThresholdSettings.VadThreshold(ptr);
			}
			return result;
		}

		public unsafe void SetVadThreshold(float value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("VADThresholdSettings");
			}
			fixed (NativeMethods.VADThresholdSettings* ptr = &self)
			{
				NativeMethods.VADThresholdSettings.SetVadThreshold(ptr, value);
			}
		}

		public unsafe bool Automatic()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("VADThresholdSettings");
			}
			bool result;
			fixed (NativeMethods.VADThresholdSettings* ptr = &self)
			{
				result = NativeMethods.VADThresholdSettings.Automatic(ptr);
			}
			return result;
		}

		public unsafe void SetAutomatic(bool value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("VADThresholdSettings");
			}
			fixed (NativeMethods.VADThresholdSettings* ptr = &self)
			{
				NativeMethods.VADThresholdSettings.SetAutomatic(ptr, value);
			}
		}
	}
}
