using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class ChannelHandle : IDisposable
	{
		internal NativeMethods.ChannelHandle self;

		private int disposed_;

		internal ChannelHandle(NativeMethods.ChannelHandle self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~ChannelHandle()
		{
			Dispose();
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.ChannelHandle* ptr = &self)
				{
					NativeMethods.ChannelHandle.Drop(ptr);
				}
			}
		}

		public unsafe ChannelHandle(ChannelHandle other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ChannelHandle");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.ChannelHandle* other2 = &other.self)
			{
				fixed (NativeMethods.ChannelHandle* ptr = &self)
				{
					NativeMethods.ChannelHandle.Clone(ptr, other2);
				}
			}
		}

		internal unsafe ChannelHandle(NativeMethods.ChannelHandle* otherPtr)
		{
			fixed (NativeMethods.ChannelHandle* ptr = &self)
			{
				NativeMethods.ChannelHandle.Clone(ptr, otherPtr);
			}
		}

		public unsafe ulong Id()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ChannelHandle");
			}
			ulong result;
			fixed (NativeMethods.ChannelHandle* ptr = &self)
			{
				result = NativeMethods.ChannelHandle.Id(ptr);
			}
			return result;
		}

		public unsafe string Name()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ChannelHandle");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.ChannelHandle* ptr = &self)
			{
				NativeMethods.ChannelHandle.Name(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe ulong[] Recipients()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ChannelHandle");
			}
			NativeMethods.Discord_UInt64Span discord_UInt64Span = default(NativeMethods.Discord_UInt64Span);
			fixed (NativeMethods.ChannelHandle* ptr = &self)
			{
				NativeMethods.ChannelHandle.Recipients(ptr, &discord_UInt64Span);
			}
			ulong[] result = new Span<ulong>(discord_UInt64Span.ptr, (int)(uint)discord_UInt64Span.size).ToArray();
			NativeMethods.Discord_Free(discord_UInt64Span.ptr);
			return result;
		}

		public unsafe ChannelType Type()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ChannelHandle");
			}
			ChannelType result;
			fixed (NativeMethods.ChannelHandle* ptr = &self)
			{
				result = NativeMethods.ChannelHandle.Type(ptr);
			}
			return result;
		}
	}
}
