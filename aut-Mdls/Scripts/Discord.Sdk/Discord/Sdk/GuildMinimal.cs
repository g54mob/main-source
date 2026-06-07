using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class GuildMinimal : IDisposable
	{
		internal NativeMethods.GuildMinimal self;

		private int disposed_;

		internal GuildMinimal(NativeMethods.GuildMinimal self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~GuildMinimal()
		{
			Dispose();
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.GuildMinimal* ptr = &self)
				{
					NativeMethods.GuildMinimal.Drop(ptr);
				}
			}
		}

		public unsafe GuildMinimal(GuildMinimal other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("GuildMinimal");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.GuildMinimal* arg = &other.self)
			{
				fixed (NativeMethods.GuildMinimal* ptr = &self)
				{
					NativeMethods.GuildMinimal.Clone(ptr, arg);
				}
			}
		}

		internal unsafe GuildMinimal(NativeMethods.GuildMinimal* otherPtr)
		{
			fixed (NativeMethods.GuildMinimal* ptr = &self)
			{
				NativeMethods.GuildMinimal.Clone(ptr, otherPtr);
			}
		}

		public unsafe ulong Id()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("GuildMinimal");
			}
			ulong result;
			fixed (NativeMethods.GuildMinimal* ptr = &self)
			{
				result = NativeMethods.GuildMinimal.Id(ptr);
			}
			return result;
		}

		public unsafe void SetId(ulong value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("GuildMinimal");
			}
			fixed (NativeMethods.GuildMinimal* ptr = &self)
			{
				NativeMethods.GuildMinimal.SetId(ptr, value);
			}
		}

		public unsafe string Name()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("GuildMinimal");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.GuildMinimal* ptr = &self)
			{
				NativeMethods.GuildMinimal.Name(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetName(string value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("GuildMinimal");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String value2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &value2, value);
			fixed (NativeMethods.GuildMinimal* ptr = &self)
			{
				NativeMethods.GuildMinimal.SetName(ptr, value2);
			}
			NativeMethods.__FreeLocalString(&value2, owned);
		}
	}
}
