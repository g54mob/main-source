using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class AudioDevice : IDisposable
	{
		internal NativeMethods.AudioDevice self;

		private int disposed_;

		internal AudioDevice(NativeMethods.AudioDevice self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~AudioDevice()
		{
			Dispose();
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.AudioDevice* ptr = &self)
				{
					NativeMethods.AudioDevice.Drop(ptr);
				}
			}
		}

		public unsafe AudioDevice(AudioDevice other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AudioDevice");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.AudioDevice* arg = &other.self)
			{
				fixed (NativeMethods.AudioDevice* ptr = &self)
				{
					NativeMethods.AudioDevice.Clone(ptr, arg);
				}
			}
		}

		internal unsafe AudioDevice(NativeMethods.AudioDevice* otherPtr)
		{
			fixed (NativeMethods.AudioDevice* ptr = &self)
			{
				NativeMethods.AudioDevice.Clone(ptr, otherPtr);
			}
		}

		public unsafe bool Equals(AudioDevice rhs)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AudioDevice");
			}
			bool result;
			fixed (NativeMethods.AudioDevice* rhs2 = &rhs.self)
			{
				fixed (NativeMethods.AudioDevice* ptr = &self)
				{
					result = NativeMethods.AudioDevice.Equals(ptr, rhs2);
				}
			}
			return result;
		}

		public unsafe string Id()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AudioDevice");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.AudioDevice* ptr = &self)
			{
				NativeMethods.AudioDevice.Id(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetId(string value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AudioDevice");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String value2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &value2, value);
			fixed (NativeMethods.AudioDevice* ptr = &self)
			{
				NativeMethods.AudioDevice.SetId(ptr, value2);
			}
			NativeMethods.__FreeLocalString(&value2, owned);
		}

		public unsafe string Name()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AudioDevice");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.AudioDevice* ptr = &self)
			{
				NativeMethods.AudioDevice.Name(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetName(string value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AudioDevice");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String value2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &value2, value);
			fixed (NativeMethods.AudioDevice* ptr = &self)
			{
				NativeMethods.AudioDevice.SetName(ptr, value2);
			}
			NativeMethods.__FreeLocalString(&value2, owned);
		}

		public unsafe bool IsDefault()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AudioDevice");
			}
			bool result;
			fixed (NativeMethods.AudioDevice* ptr = &self)
			{
				result = NativeMethods.AudioDevice.IsDefault(ptr);
			}
			return result;
		}

		public unsafe void SetIsDefault(bool value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AudioDevice");
			}
			fixed (NativeMethods.AudioDevice* ptr = &self)
			{
				NativeMethods.AudioDevice.SetIsDefault(ptr, value);
			}
		}
	}
}
