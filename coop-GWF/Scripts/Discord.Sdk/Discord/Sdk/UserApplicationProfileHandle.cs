using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class UserApplicationProfileHandle : IDisposable
	{
		internal NativeMethods.UserApplicationProfileHandle self;

		private int disposed_;

		internal UserApplicationProfileHandle(NativeMethods.UserApplicationProfileHandle self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~UserApplicationProfileHandle()
		{
			Dispose();
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.UserApplicationProfileHandle* ptr = &self)
				{
					NativeMethods.UserApplicationProfileHandle.Drop(ptr);
				}
			}
		}

		public unsafe UserApplicationProfileHandle(UserApplicationProfileHandle other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("UserApplicationProfileHandle");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.UserApplicationProfileHandle* other2 = &other.self)
			{
				fixed (NativeMethods.UserApplicationProfileHandle* ptr = &self)
				{
					NativeMethods.UserApplicationProfileHandle.Clone(ptr, other2);
				}
			}
		}

		internal unsafe UserApplicationProfileHandle(NativeMethods.UserApplicationProfileHandle* otherPtr)
		{
			fixed (NativeMethods.UserApplicationProfileHandle* ptr = &self)
			{
				NativeMethods.UserApplicationProfileHandle.Clone(ptr, otherPtr);
			}
		}

		public unsafe string AvatarHash()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("UserApplicationProfileHandle");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.UserApplicationProfileHandle* ptr = &self)
			{
				NativeMethods.UserApplicationProfileHandle.AvatarHash(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe string Metadata()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("UserApplicationProfileHandle");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.UserApplicationProfileHandle* ptr = &self)
			{
				NativeMethods.UserApplicationProfileHandle.Metadata(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe string? ProviderId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("UserApplicationProfileHandle");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool num;
			fixed (NativeMethods.UserApplicationProfileHandle* ptr = &self)
			{
				num = NativeMethods.UserApplicationProfileHandle.ProviderId(ptr, &discord_String);
			}
			if (!num)
			{
				return null;
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe string ProviderIssuedUserId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("UserApplicationProfileHandle");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.UserApplicationProfileHandle* ptr = &self)
			{
				NativeMethods.UserApplicationProfileHandle.ProviderIssuedUserId(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe ExternalIdentityProviderType ProviderType()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("UserApplicationProfileHandle");
			}
			ExternalIdentityProviderType result;
			fixed (NativeMethods.UserApplicationProfileHandle* ptr = &self)
			{
				result = NativeMethods.UserApplicationProfileHandle.ProviderType(ptr);
			}
			return result;
		}

		public unsafe string Username()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("UserApplicationProfileHandle");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.UserApplicationProfileHandle* ptr = &self)
			{
				NativeMethods.UserApplicationProfileHandle.Username(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}
	}
}
