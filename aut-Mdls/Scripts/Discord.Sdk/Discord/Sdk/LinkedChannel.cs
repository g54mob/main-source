using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class LinkedChannel : IDisposable
	{
		internal NativeMethods.LinkedChannel self;

		private int disposed_;

		internal LinkedChannel(NativeMethods.LinkedChannel self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~LinkedChannel()
		{
			Dispose();
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.LinkedChannel* ptr = &self)
				{
					NativeMethods.LinkedChannel.Drop(ptr);
				}
			}
		}

		public unsafe LinkedChannel(LinkedChannel other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LinkedChannel");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.LinkedChannel* arg = &other.self)
			{
				fixed (NativeMethods.LinkedChannel* ptr = &self)
				{
					NativeMethods.LinkedChannel.Clone(ptr, arg);
				}
			}
		}

		internal unsafe LinkedChannel(NativeMethods.LinkedChannel* otherPtr)
		{
			fixed (NativeMethods.LinkedChannel* ptr = &self)
			{
				NativeMethods.LinkedChannel.Clone(ptr, otherPtr);
			}
		}

		public unsafe ulong Id()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LinkedChannel");
			}
			ulong result;
			fixed (NativeMethods.LinkedChannel* ptr = &self)
			{
				result = NativeMethods.LinkedChannel.Id(ptr);
			}
			return result;
		}

		public unsafe void SetId(ulong value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LinkedChannel");
			}
			fixed (NativeMethods.LinkedChannel* ptr = &self)
			{
				NativeMethods.LinkedChannel.SetId(ptr, value);
			}
		}

		public unsafe string Name()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LinkedChannel");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.LinkedChannel* ptr = &self)
			{
				NativeMethods.LinkedChannel.Name(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetName(string value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LinkedChannel");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String value2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &value2, value);
			fixed (NativeMethods.LinkedChannel* ptr = &self)
			{
				NativeMethods.LinkedChannel.SetName(ptr, value2);
			}
			NativeMethods.__FreeLocalString(&value2, owned);
		}

		public unsafe ulong GuildId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LinkedChannel");
			}
			ulong result;
			fixed (NativeMethods.LinkedChannel* ptr = &self)
			{
				result = NativeMethods.LinkedChannel.GuildId(ptr);
			}
			return result;
		}

		public unsafe void SetGuildId(ulong value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LinkedChannel");
			}
			fixed (NativeMethods.LinkedChannel* ptr = &self)
			{
				NativeMethods.LinkedChannel.SetGuildId(ptr, value);
			}
		}
	}
}
