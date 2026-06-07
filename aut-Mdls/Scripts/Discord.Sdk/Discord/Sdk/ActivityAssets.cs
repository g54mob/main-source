using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class ActivityAssets : IDisposable
	{
		internal NativeMethods.ActivityAssets self;

		private int disposed_;

		internal ActivityAssets(NativeMethods.ActivityAssets self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~ActivityAssets()
		{
			Dispose();
		}

		public unsafe ActivityAssets()
		{
			NativeMethods.__Init();
			fixed (NativeMethods.ActivityAssets* ptr = &self)
			{
				NativeMethods.ActivityAssets.Init(ptr);
			}
			NativeMethods.__OnPostConstruct(this);
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.ActivityAssets* ptr = &self)
				{
					NativeMethods.ActivityAssets.Drop(ptr);
				}
			}
		}

		public unsafe ActivityAssets(ActivityAssets other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityAssets");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.ActivityAssets* arg = &other.self)
			{
				fixed (NativeMethods.ActivityAssets* ptr = &self)
				{
					NativeMethods.ActivityAssets.Clone(ptr, arg);
				}
			}
		}

		internal unsafe ActivityAssets(NativeMethods.ActivityAssets* otherPtr)
		{
			fixed (NativeMethods.ActivityAssets* ptr = &self)
			{
				NativeMethods.ActivityAssets.Clone(ptr, otherPtr);
			}
		}

		public unsafe string? LargeImage()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityAssets");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool num;
			fixed (NativeMethods.ActivityAssets* ptr = &self)
			{
				num = NativeMethods.ActivityAssets.LargeImage(ptr, &discord_String);
			}
			if (!num)
			{
				return null;
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetLargeImage(string? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityAssets");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitNullableStringLocal(buf, &num, 1024, &discord_String, value);
			fixed (NativeMethods.ActivityAssets* ptr = &self)
			{
				NativeMethods.ActivityAssets.SetLargeImage(ptr, (value != null) ? (&discord_String) : null);
			}
			NativeMethods.__FreeLocalString(&discord_String, owned);
		}

		public unsafe string? LargeText()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityAssets");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool num;
			fixed (NativeMethods.ActivityAssets* ptr = &self)
			{
				num = NativeMethods.ActivityAssets.LargeText(ptr, &discord_String);
			}
			if (!num)
			{
				return null;
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetLargeText(string? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityAssets");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitNullableStringLocal(buf, &num, 1024, &discord_String, value);
			fixed (NativeMethods.ActivityAssets* ptr = &self)
			{
				NativeMethods.ActivityAssets.SetLargeText(ptr, (value != null) ? (&discord_String) : null);
			}
			NativeMethods.__FreeLocalString(&discord_String, owned);
		}

		public unsafe string? LargeUrl()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityAssets");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool num;
			fixed (NativeMethods.ActivityAssets* ptr = &self)
			{
				num = NativeMethods.ActivityAssets.LargeUrl(ptr, &discord_String);
			}
			if (!num)
			{
				return null;
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetLargeUrl(string? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityAssets");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitNullableStringLocal(buf, &num, 1024, &discord_String, value);
			fixed (NativeMethods.ActivityAssets* ptr = &self)
			{
				NativeMethods.ActivityAssets.SetLargeUrl(ptr, (value != null) ? (&discord_String) : null);
			}
			NativeMethods.__FreeLocalString(&discord_String, owned);
		}

		public unsafe string? SmallImage()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityAssets");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool num;
			fixed (NativeMethods.ActivityAssets* ptr = &self)
			{
				num = NativeMethods.ActivityAssets.SmallImage(ptr, &discord_String);
			}
			if (!num)
			{
				return null;
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetSmallImage(string? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityAssets");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitNullableStringLocal(buf, &num, 1024, &discord_String, value);
			fixed (NativeMethods.ActivityAssets* ptr = &self)
			{
				NativeMethods.ActivityAssets.SetSmallImage(ptr, (value != null) ? (&discord_String) : null);
			}
			NativeMethods.__FreeLocalString(&discord_String, owned);
		}

		public unsafe string? SmallText()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityAssets");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool num;
			fixed (NativeMethods.ActivityAssets* ptr = &self)
			{
				num = NativeMethods.ActivityAssets.SmallText(ptr, &discord_String);
			}
			if (!num)
			{
				return null;
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetSmallText(string? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityAssets");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitNullableStringLocal(buf, &num, 1024, &discord_String, value);
			fixed (NativeMethods.ActivityAssets* ptr = &self)
			{
				NativeMethods.ActivityAssets.SetSmallText(ptr, (value != null) ? (&discord_String) : null);
			}
			NativeMethods.__FreeLocalString(&discord_String, owned);
		}

		public unsafe string? SmallUrl()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityAssets");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool num;
			fixed (NativeMethods.ActivityAssets* ptr = &self)
			{
				num = NativeMethods.ActivityAssets.SmallUrl(ptr, &discord_String);
			}
			if (!num)
			{
				return null;
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetSmallUrl(string? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityAssets");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitNullableStringLocal(buf, &num, 1024, &discord_String, value);
			fixed (NativeMethods.ActivityAssets* ptr = &self)
			{
				NativeMethods.ActivityAssets.SetSmallUrl(ptr, (value != null) ? (&discord_String) : null);
			}
			NativeMethods.__FreeLocalString(&discord_String, owned);
		}

		public unsafe string? InviteCoverImage()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityAssets");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool num;
			fixed (NativeMethods.ActivityAssets* ptr = &self)
			{
				num = NativeMethods.ActivityAssets.InviteCoverImage(ptr, &discord_String);
			}
			if (!num)
			{
				return null;
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetInviteCoverImage(string? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityAssets");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitNullableStringLocal(buf, &num, 1024, &discord_String, value);
			fixed (NativeMethods.ActivityAssets* ptr = &self)
			{
				NativeMethods.ActivityAssets.SetInviteCoverImage(ptr, (value != null) ? (&discord_String) : null);
			}
			NativeMethods.__FreeLocalString(&discord_String, owned);
		}
	}
}
