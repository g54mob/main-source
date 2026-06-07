using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class LobbyHandle : IDisposable
	{
		internal NativeMethods.LobbyHandle self;

		private int disposed_;

		internal LobbyHandle(NativeMethods.LobbyHandle self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~LobbyHandle()
		{
			Dispose();
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.LobbyHandle* ptr = &self)
				{
					NativeMethods.LobbyHandle.Drop(ptr);
				}
			}
		}

		public unsafe LobbyHandle(LobbyHandle other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LobbyHandle");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.LobbyHandle* other2 = &other.self)
			{
				fixed (NativeMethods.LobbyHandle* ptr = &self)
				{
					NativeMethods.LobbyHandle.Clone(ptr, other2);
				}
			}
		}

		internal unsafe LobbyHandle(NativeMethods.LobbyHandle* otherPtr)
		{
			fixed (NativeMethods.LobbyHandle* ptr = &self)
			{
				NativeMethods.LobbyHandle.Clone(ptr, otherPtr);
			}
		}

		public unsafe CallInfoHandle? GetCallInfoHandle()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LobbyHandle");
			}
			NativeMethods.CallInfoHandle callInfoHandle = default(NativeMethods.CallInfoHandle);
			bool callInfoHandle2;
			fixed (NativeMethods.LobbyHandle* ptr = &self)
			{
				callInfoHandle2 = NativeMethods.LobbyHandle.GetCallInfoHandle(ptr, &callInfoHandle);
			}
			if (!callInfoHandle2)
			{
				return null;
			}
			return new CallInfoHandle(callInfoHandle, 0);
		}

		public unsafe LobbyMemberHandle? GetLobbyMemberHandle(ulong memberId)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LobbyHandle");
			}
			NativeMethods.LobbyMemberHandle lobbyMemberHandle = default(NativeMethods.LobbyMemberHandle);
			bool lobbyMemberHandle2;
			fixed (NativeMethods.LobbyHandle* ptr = &self)
			{
				lobbyMemberHandle2 = NativeMethods.LobbyHandle.GetLobbyMemberHandle(ptr, memberId, &lobbyMemberHandle);
			}
			if (!lobbyMemberHandle2)
			{
				return null;
			}
			return new LobbyMemberHandle(lobbyMemberHandle, 0);
		}

		public unsafe ulong Id()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LobbyHandle");
			}
			ulong result;
			fixed (NativeMethods.LobbyHandle* ptr = &self)
			{
				result = NativeMethods.LobbyHandle.Id(ptr);
			}
			return result;
		}

		public unsafe LinkedChannel? LinkedChannel()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LobbyHandle");
			}
			NativeMethods.LinkedChannel linkedChannel = default(NativeMethods.LinkedChannel);
			bool num;
			fixed (NativeMethods.LobbyHandle* ptr = &self)
			{
				num = NativeMethods.LobbyHandle.LinkedChannel(ptr, &linkedChannel);
			}
			if (!num)
			{
				return null;
			}
			return new LinkedChannel(linkedChannel, 0);
		}

		public unsafe ulong[] LobbyMemberIds()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LobbyHandle");
			}
			NativeMethods.Discord_UInt64Span discord_UInt64Span = default(NativeMethods.Discord_UInt64Span);
			fixed (NativeMethods.LobbyHandle* ptr = &self)
			{
				NativeMethods.LobbyHandle.LobbyMemberIds(ptr, &discord_UInt64Span);
			}
			ulong[] result = new Span<ulong>(discord_UInt64Span.ptr, (int)(uint)discord_UInt64Span.size).ToArray();
			NativeMethods.Discord_Free(discord_UInt64Span.ptr);
			return result;
		}

		public unsafe LobbyMemberHandle[] LobbyMembers()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LobbyHandle");
			}
			NativeMethods.Discord_LobbyMemberHandleSpan discord_LobbyMemberHandleSpan = default(NativeMethods.Discord_LobbyMemberHandleSpan);
			fixed (NativeMethods.LobbyHandle* ptr = &self)
			{
				NativeMethods.LobbyHandle.LobbyMembers(ptr, &discord_LobbyMemberHandleSpan);
			}
			LobbyMemberHandle[] array = new LobbyMemberHandle[(uint)discord_LobbyMemberHandleSpan.size];
			for (int i = 0; i < (int)(uint)discord_LobbyMemberHandleSpan.size; i++)
			{
				array[i] = new LobbyMemberHandle(discord_LobbyMemberHandleSpan.ptr[i], 0);
			}
			NativeMethods.Discord_Free(discord_LobbyMemberHandleSpan.ptr);
			return array;
		}

		public unsafe Dictionary<string, string> Metadata()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LobbyHandle");
			}
			NativeMethods.Discord_Properties props = default(NativeMethods.Discord_Properties);
			fixed (NativeMethods.LobbyHandle* ptr = &self)
			{
				NativeMethods.LobbyHandle.Metadata(ptr, &props);
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
	}
}
