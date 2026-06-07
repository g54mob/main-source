using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class LobbyMemberHandle : IDisposable
	{
		internal NativeMethods.LobbyMemberHandle self;

		private int disposed_;

		internal LobbyMemberHandle(NativeMethods.LobbyMemberHandle self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~LobbyMemberHandle()
		{
			Dispose();
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.LobbyMemberHandle* ptr = &self)
				{
					NativeMethods.LobbyMemberHandle.Drop(ptr);
				}
			}
		}

		public unsafe LobbyMemberHandle(LobbyMemberHandle other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LobbyMemberHandle");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.LobbyMemberHandle* other2 = &other.self)
			{
				fixed (NativeMethods.LobbyMemberHandle* ptr = &self)
				{
					NativeMethods.LobbyMemberHandle.Clone(ptr, other2);
				}
			}
		}

		internal unsafe LobbyMemberHandle(NativeMethods.LobbyMemberHandle* otherPtr)
		{
			fixed (NativeMethods.LobbyMemberHandle* ptr = &self)
			{
				NativeMethods.LobbyMemberHandle.Clone(ptr, otherPtr);
			}
		}

		public unsafe bool CanLinkLobby()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LobbyMemberHandle");
			}
			bool result;
			fixed (NativeMethods.LobbyMemberHandle* ptr = &self)
			{
				result = NativeMethods.LobbyMemberHandle.CanLinkLobby(ptr);
			}
			return result;
		}

		public unsafe bool Connected()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LobbyMemberHandle");
			}
			bool result;
			fixed (NativeMethods.LobbyMemberHandle* ptr = &self)
			{
				result = NativeMethods.LobbyMemberHandle.Connected(ptr);
			}
			return result;
		}

		public unsafe ulong Id()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LobbyMemberHandle");
			}
			ulong result;
			fixed (NativeMethods.LobbyMemberHandle* ptr = &self)
			{
				result = NativeMethods.LobbyMemberHandle.Id(ptr);
			}
			return result;
		}

		public unsafe Dictionary<string, string> Metadata()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LobbyMemberHandle");
			}
			NativeMethods.Discord_Properties props = default(NativeMethods.Discord_Properties);
			fixed (NativeMethods.LobbyMemberHandle* ptr = &self)
			{
				NativeMethods.LobbyMemberHandle.Metadata(ptr, &props);
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>((int)props.size);
			for (int i = 0; i < (int)props.size; i++)
			{
				string key = Marshal.PtrToStringUTF8((IntPtr)props.keys[i].ptr, (int)(uint)props.keys[i].size);
				string value = Marshal.PtrToStringUTF8((IntPtr)props.values[i].ptr, (int)(uint)props.values[i].size);
				dictionary[key] = value;
			}
			NativeMethods.Discord_FreeProperties(props);
			return dictionary;
		}

		public unsafe UserHandle? User()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LobbyMemberHandle");
			}
			NativeMethods.UserHandle userHandle = default(NativeMethods.UserHandle);
			bool num;
			fixed (NativeMethods.LobbyMemberHandle* ptr = &self)
			{
				num = NativeMethods.LobbyMemberHandle.User(ptr, &userHandle);
			}
			if (!num)
			{
				return null;
			}
			return new UserHandle(userHandle, 0);
		}
	}
}
