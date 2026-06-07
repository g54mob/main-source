using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class DeviceAuthorizationArgs : IDisposable
	{
		internal NativeMethods.DeviceAuthorizationArgs self;

		private int disposed_;

		internal DeviceAuthorizationArgs(NativeMethods.DeviceAuthorizationArgs self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~DeviceAuthorizationArgs()
		{
			Dispose();
		}

		public unsafe DeviceAuthorizationArgs()
		{
			NativeMethods.__Init();
			fixed (NativeMethods.DeviceAuthorizationArgs* ptr = &self)
			{
				NativeMethods.DeviceAuthorizationArgs.Init(ptr);
			}
			NativeMethods.__OnPostConstruct(this);
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.DeviceAuthorizationArgs* ptr = &self)
				{
					NativeMethods.DeviceAuthorizationArgs.Drop(ptr);
				}
			}
		}

		public unsafe DeviceAuthorizationArgs(DeviceAuthorizationArgs other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("DeviceAuthorizationArgs");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.DeviceAuthorizationArgs* arg = &other.self)
			{
				fixed (NativeMethods.DeviceAuthorizationArgs* ptr = &self)
				{
					NativeMethods.DeviceAuthorizationArgs.Clone(ptr, arg);
				}
			}
		}

		internal unsafe DeviceAuthorizationArgs(NativeMethods.DeviceAuthorizationArgs* otherPtr)
		{
			fixed (NativeMethods.DeviceAuthorizationArgs* ptr = &self)
			{
				NativeMethods.DeviceAuthorizationArgs.Clone(ptr, otherPtr);
			}
		}

		public unsafe ulong ClientId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("DeviceAuthorizationArgs");
			}
			ulong result;
			fixed (NativeMethods.DeviceAuthorizationArgs* ptr = &self)
			{
				result = NativeMethods.DeviceAuthorizationArgs.ClientId(ptr);
			}
			return result;
		}

		public unsafe void SetClientId(ulong value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("DeviceAuthorizationArgs");
			}
			fixed (NativeMethods.DeviceAuthorizationArgs* ptr = &self)
			{
				NativeMethods.DeviceAuthorizationArgs.SetClientId(ptr, value);
			}
		}

		public unsafe string Scopes()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("DeviceAuthorizationArgs");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.DeviceAuthorizationArgs* ptr = &self)
			{
				NativeMethods.DeviceAuthorizationArgs.Scopes(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetScopes(string value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("DeviceAuthorizationArgs");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String value2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &value2, value);
			fixed (NativeMethods.DeviceAuthorizationArgs* ptr = &self)
			{
				NativeMethods.DeviceAuthorizationArgs.SetScopes(ptr, value2);
			}
			NativeMethods.__FreeLocalString(&value2, owned);
		}
	}
}
