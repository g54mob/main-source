using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class ActivitySecrets : IDisposable
	{
		internal NativeMethods.ActivitySecrets self;

		private int disposed_;

		internal ActivitySecrets(NativeMethods.ActivitySecrets self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~ActivitySecrets()
		{
			Dispose();
		}

		public unsafe ActivitySecrets()
		{
			NativeMethods.__Init();
			fixed (NativeMethods.ActivitySecrets* ptr = &self)
			{
				NativeMethods.ActivitySecrets.Init(ptr);
			}
			NativeMethods.__OnPostConstruct(this);
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.ActivitySecrets* ptr = &self)
				{
					NativeMethods.ActivitySecrets.Drop(ptr);
				}
			}
		}

		public unsafe ActivitySecrets(ActivitySecrets other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivitySecrets");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.ActivitySecrets* arg = &other.self)
			{
				fixed (NativeMethods.ActivitySecrets* ptr = &self)
				{
					NativeMethods.ActivitySecrets.Clone(ptr, arg);
				}
			}
		}

		internal unsafe ActivitySecrets(NativeMethods.ActivitySecrets* otherPtr)
		{
			fixed (NativeMethods.ActivitySecrets* ptr = &self)
			{
				NativeMethods.ActivitySecrets.Clone(ptr, otherPtr);
			}
		}

		public unsafe string Join()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivitySecrets");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.ActivitySecrets* ptr = &self)
			{
				NativeMethods.ActivitySecrets.Join(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetJoin(string value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivitySecrets");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String value2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &value2, value);
			fixed (NativeMethods.ActivitySecrets* ptr = &self)
			{
				NativeMethods.ActivitySecrets.SetJoin(ptr, value2);
			}
			NativeMethods.__FreeLocalString(&value2, owned);
		}
	}
}
