using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class UserHandle : IDisposable
	{
		public enum AvatarType
		{
			Gif = 0,
			Webp = 1,
			Png = 2,
			Jpeg = 3
		}

		internal NativeMethods.UserHandle self;

		private int disposed_;

		internal UserHandle(NativeMethods.UserHandle self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~UserHandle()
		{
			Dispose();
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.UserHandle* ptr = &self)
				{
					NativeMethods.UserHandle.Drop(ptr);
				}
			}
		}

		public unsafe UserHandle(UserHandle other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("UserHandle");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.UserHandle* arg = &other.self)
			{
				fixed (NativeMethods.UserHandle* ptr = &self)
				{
					NativeMethods.UserHandle.Clone(ptr, arg);
				}
			}
		}

		internal unsafe UserHandle(NativeMethods.UserHandle* otherPtr)
		{
			fixed (NativeMethods.UserHandle* ptr = &self)
			{
				NativeMethods.UserHandle.Clone(ptr, otherPtr);
			}
		}

		public unsafe string? Avatar()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("UserHandle");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool num;
			fixed (NativeMethods.UserHandle* ptr = &self)
			{
				num = NativeMethods.UserHandle.Avatar(ptr, &discord_String);
			}
			if (!num)
			{
				return null;
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe static string AvatarTypeToString(AvatarType type)
		{
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			NativeMethods.UserHandle.AvatarTypeToString(type, &discord_String);
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe string AvatarUrl(AvatarType animatedType, AvatarType staticType)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("UserHandle");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.UserHandle* ptr = &self)
			{
				NativeMethods.UserHandle.AvatarUrl(ptr, animatedType, staticType, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe string DisplayName()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("UserHandle");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.UserHandle* ptr = &self)
			{
				NativeMethods.UserHandle.DisplayName(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe Activity? GameActivity()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("UserHandle");
			}
			NativeMethods.Activity activity = default(NativeMethods.Activity);
			bool num;
			fixed (NativeMethods.UserHandle* ptr = &self)
			{
				num = NativeMethods.UserHandle.GameActivity(ptr, &activity);
			}
			if (!num)
			{
				return null;
			}
			return new Activity(activity, 0);
		}

		public unsafe string? GlobalName()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("UserHandle");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool num;
			fixed (NativeMethods.UserHandle* ptr = &self)
			{
				num = NativeMethods.UserHandle.GlobalName(ptr, &discord_String);
			}
			if (!num)
			{
				return null;
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe ulong Id()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("UserHandle");
			}
			ulong result;
			fixed (NativeMethods.UserHandle* ptr = &self)
			{
				result = NativeMethods.UserHandle.Id(ptr);
			}
			return result;
		}

		public unsafe bool IsProvisional()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("UserHandle");
			}
			bool result;
			fixed (NativeMethods.UserHandle* ptr = &self)
			{
				result = NativeMethods.UserHandle.IsProvisional(ptr);
			}
			return result;
		}

		public unsafe RelationshipHandle Relationship()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("UserHandle");
			}
			NativeMethods.RelationshipHandle relationshipHandle = default(NativeMethods.RelationshipHandle);
			fixed (NativeMethods.UserHandle* ptr = &self)
			{
				NativeMethods.UserHandle.Relationship(ptr, &relationshipHandle);
			}
			return new RelationshipHandle(relationshipHandle, 0);
		}

		public unsafe StatusType Status()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("UserHandle");
			}
			StatusType result;
			fixed (NativeMethods.UserHandle* ptr = &self)
			{
				result = NativeMethods.UserHandle.Status(ptr);
			}
			return result;
		}

		public unsafe UserApplicationProfileHandle[] UserApplicationProfiles()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("UserHandle");
			}
			NativeMethods.Discord_UserApplicationProfileHandleSpan discord_UserApplicationProfileHandleSpan = default(NativeMethods.Discord_UserApplicationProfileHandleSpan);
			fixed (NativeMethods.UserHandle* ptr = &self)
			{
				NativeMethods.UserHandle.UserApplicationProfiles(ptr, &discord_UserApplicationProfileHandleSpan);
			}
			UserApplicationProfileHandle[] array = new UserApplicationProfileHandle[(uint)discord_UserApplicationProfileHandleSpan.size];
			for (int i = 0; i < (int)(uint)discord_UserApplicationProfileHandleSpan.size; i++)
			{
				array[i] = new UserApplicationProfileHandle(discord_UserApplicationProfileHandleSpan.ptr[i], 0);
			}
			NativeMethods.Discord_Free(discord_UserApplicationProfileHandleSpan.ptr);
			return array;
		}

		public unsafe string Username()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("UserHandle");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.UserHandle* ptr = &self)
			{
				NativeMethods.UserHandle.Username(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}
	}
}
