using System;
using System.Threading;

namespace Discord.Sdk
{
	public class VoiceStateHandle : IDisposable
	{
		internal NativeMethods.VoiceStateHandle self;

		private int disposed_;

		internal VoiceStateHandle(NativeMethods.VoiceStateHandle self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~VoiceStateHandle()
		{
			Dispose();
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.VoiceStateHandle* ptr = &self)
				{
					NativeMethods.VoiceStateHandle.Drop(ptr);
				}
			}
		}

		public unsafe VoiceStateHandle(VoiceStateHandle other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("VoiceStateHandle");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.VoiceStateHandle* other2 = &other.self)
			{
				fixed (NativeMethods.VoiceStateHandle* ptr = &self)
				{
					NativeMethods.VoiceStateHandle.Clone(ptr, other2);
				}
			}
		}

		internal unsafe VoiceStateHandle(NativeMethods.VoiceStateHandle* otherPtr)
		{
			fixed (NativeMethods.VoiceStateHandle* ptr = &self)
			{
				NativeMethods.VoiceStateHandle.Clone(ptr, otherPtr);
			}
		}

		public unsafe bool SelfDeaf()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("VoiceStateHandle");
			}
			bool result;
			fixed (NativeMethods.VoiceStateHandle* ptr = &self)
			{
				result = NativeMethods.VoiceStateHandle.SelfDeaf(ptr);
			}
			return result;
		}

		public unsafe bool SelfMute()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("VoiceStateHandle");
			}
			bool result;
			fixed (NativeMethods.VoiceStateHandle* ptr = &self)
			{
				result = NativeMethods.VoiceStateHandle.SelfMute(ptr);
			}
			return result;
		}
	}
}
