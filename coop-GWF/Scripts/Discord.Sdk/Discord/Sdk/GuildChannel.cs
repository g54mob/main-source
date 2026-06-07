using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class GuildChannel : IDisposable
	{
		internal NativeMethods.GuildChannel self;

		private int disposed_;

		internal GuildChannel(NativeMethods.GuildChannel self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~GuildChannel()
		{
			Dispose();
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.GuildChannel* ptr = &self)
				{
					NativeMethods.GuildChannel.Drop(ptr);
				}
			}
		}

		public unsafe GuildChannel(GuildChannel other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("GuildChannel");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.GuildChannel* arg = &other.self)
			{
				fixed (NativeMethods.GuildChannel* ptr = &self)
				{
					NativeMethods.GuildChannel.Clone(ptr, arg);
				}
			}
		}

		internal unsafe GuildChannel(NativeMethods.GuildChannel* otherPtr)
		{
			fixed (NativeMethods.GuildChannel* ptr = &self)
			{
				NativeMethods.GuildChannel.Clone(ptr, otherPtr);
			}
		}

		public unsafe ulong Id()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("GuildChannel");
			}
			ulong result;
			fixed (NativeMethods.GuildChannel* ptr = &self)
			{
				result = NativeMethods.GuildChannel.Id(ptr);
			}
			return result;
		}

		public unsafe void SetId(ulong value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("GuildChannel");
			}
			fixed (NativeMethods.GuildChannel* ptr = &self)
			{
				NativeMethods.GuildChannel.SetId(ptr, value);
			}
		}

		public unsafe string Name()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("GuildChannel");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.GuildChannel* ptr = &self)
			{
				NativeMethods.GuildChannel.Name(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetName(string value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("GuildChannel");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String value2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &value2, value);
			fixed (NativeMethods.GuildChannel* ptr = &self)
			{
				NativeMethods.GuildChannel.SetName(ptr, value2);
			}
			NativeMethods.__FreeLocalString(&value2, owned);
		}

		public unsafe ChannelType Type()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("GuildChannel");
			}
			ChannelType result;
			fixed (NativeMethods.GuildChannel* ptr = &self)
			{
				result = NativeMethods.GuildChannel.Type(ptr);
			}
			return result;
		}

		public unsafe void SetType(ChannelType value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("GuildChannel");
			}
			fixed (NativeMethods.GuildChannel* ptr = &self)
			{
				NativeMethods.GuildChannel.SetType(ptr, value);
			}
		}

		public unsafe int Position()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("GuildChannel");
			}
			int result;
			fixed (NativeMethods.GuildChannel* ptr = &self)
			{
				result = NativeMethods.GuildChannel.Position(ptr);
			}
			return result;
		}

		public unsafe void SetPosition(int value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("GuildChannel");
			}
			fixed (NativeMethods.GuildChannel* ptr = &self)
			{
				NativeMethods.GuildChannel.SetPosition(ptr, value);
			}
		}

		public unsafe ulong? ParentId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("GuildChannel");
			}
			bool num;
			ulong value = default(ulong);
			fixed (NativeMethods.GuildChannel* ptr = &self)
			{
				num = NativeMethods.GuildChannel.ParentId(ptr, &value);
			}
			if (!num)
			{
				return null;
			}
			return value;
		}

		public unsafe void SetParentId(ulong? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("GuildChannel");
			}
			ulong valueOrDefault = value.GetValueOrDefault();
			fixed (NativeMethods.GuildChannel* ptr = &self)
			{
				NativeMethods.GuildChannel.SetParentId(ptr, value.HasValue ? (&valueOrDefault) : null);
			}
		}

		public unsafe bool IsLinkable()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("GuildChannel");
			}
			bool result;
			fixed (NativeMethods.GuildChannel* ptr = &self)
			{
				result = NativeMethods.GuildChannel.IsLinkable(ptr);
			}
			return result;
		}

		public unsafe void SetIsLinkable(bool value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("GuildChannel");
			}
			fixed (NativeMethods.GuildChannel* ptr = &self)
			{
				NativeMethods.GuildChannel.SetIsLinkable(ptr, value);
			}
		}

		public unsafe bool IsViewableAndWriteableByAllMembers()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("GuildChannel");
			}
			bool result;
			fixed (NativeMethods.GuildChannel* ptr = &self)
			{
				result = NativeMethods.GuildChannel.IsViewableAndWriteableByAllMembers(ptr);
			}
			return result;
		}

		public unsafe void SetIsViewableAndWriteableByAllMembers(bool value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("GuildChannel");
			}
			fixed (NativeMethods.GuildChannel* ptr = &self)
			{
				NativeMethods.GuildChannel.SetIsViewableAndWriteableByAllMembers(ptr, value);
			}
		}

		public unsafe LinkedLobby? LinkedLobby()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("GuildChannel");
			}
			NativeMethods.LinkedLobby linkedLobby = default(NativeMethods.LinkedLobby);
			bool num;
			fixed (NativeMethods.GuildChannel* ptr = &self)
			{
				num = NativeMethods.GuildChannel.LinkedLobby(ptr, &linkedLobby);
			}
			if (!num)
			{
				return null;
			}
			return new LinkedLobby(linkedLobby, 0);
		}

		public unsafe void SetLinkedLobby(LinkedLobby? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("GuildChannel");
			}
			NativeMethods.LinkedLobby linkedLobby = value?.self ?? default(NativeMethods.LinkedLobby);
			fixed (NativeMethods.GuildChannel* ptr = &self)
			{
				NativeMethods.GuildChannel.SetLinkedLobby(ptr, (value != null) ? (&linkedLobby) : null);
			}
			if (value != null)
			{
				value.self = linkedLobby;
			}
		}
	}
}
