using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class MessageHandle : IDisposable
	{
		internal NativeMethods.MessageHandle self;

		private int disposed_;

		internal MessageHandle(NativeMethods.MessageHandle self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~MessageHandle()
		{
			Dispose();
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.MessageHandle* ptr = &self)
				{
					NativeMethods.MessageHandle.Drop(ptr);
				}
			}
		}

		public unsafe MessageHandle(MessageHandle other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("MessageHandle");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.MessageHandle* other2 = &other.self)
			{
				fixed (NativeMethods.MessageHandle* ptr = &self)
				{
					NativeMethods.MessageHandle.Clone(ptr, other2);
				}
			}
		}

		internal unsafe MessageHandle(NativeMethods.MessageHandle* otherPtr)
		{
			fixed (NativeMethods.MessageHandle* ptr = &self)
			{
				NativeMethods.MessageHandle.Clone(ptr, otherPtr);
			}
		}

		public unsafe AdditionalContent? AdditionalContent()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("MessageHandle");
			}
			NativeMethods.AdditionalContent additionalContent = default(NativeMethods.AdditionalContent);
			bool num;
			fixed (NativeMethods.MessageHandle* ptr = &self)
			{
				num = NativeMethods.MessageHandle.AdditionalContent(ptr, &additionalContent);
			}
			if (!num)
			{
				return null;
			}
			return new AdditionalContent(additionalContent, 0);
		}

		public unsafe ulong? ApplicationId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("MessageHandle");
			}
			bool num;
			ulong value = default(ulong);
			fixed (NativeMethods.MessageHandle* ptr = &self)
			{
				num = NativeMethods.MessageHandle.ApplicationId(ptr, &value);
			}
			if (!num)
			{
				return null;
			}
			return value;
		}

		public unsafe UserHandle? Author()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("MessageHandle");
			}
			NativeMethods.UserHandle userHandle = default(NativeMethods.UserHandle);
			bool num;
			fixed (NativeMethods.MessageHandle* ptr = &self)
			{
				num = NativeMethods.MessageHandle.Author(ptr, &userHandle);
			}
			if (!num)
			{
				return null;
			}
			return new UserHandle(userHandle, 0);
		}

		public unsafe ulong AuthorId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("MessageHandle");
			}
			ulong result;
			fixed (NativeMethods.MessageHandle* ptr = &self)
			{
				result = NativeMethods.MessageHandle.AuthorId(ptr);
			}
			return result;
		}

		public unsafe ChannelHandle? Channel()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("MessageHandle");
			}
			NativeMethods.ChannelHandle channelHandle = default(NativeMethods.ChannelHandle);
			bool num;
			fixed (NativeMethods.MessageHandle* ptr = &self)
			{
				num = NativeMethods.MessageHandle.Channel(ptr, &channelHandle);
			}
			if (!num)
			{
				return null;
			}
			return new ChannelHandle(channelHandle, 0);
		}

		public unsafe ulong ChannelId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("MessageHandle");
			}
			ulong result;
			fixed (NativeMethods.MessageHandle* ptr = &self)
			{
				result = NativeMethods.MessageHandle.ChannelId(ptr);
			}
			return result;
		}

		public unsafe string Content()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("MessageHandle");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.MessageHandle* ptr = &self)
			{
				NativeMethods.MessageHandle.Content(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe DisclosureTypes? DisclosureType()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("MessageHandle");
			}
			bool num;
			DisclosureTypes value = default(DisclosureTypes);
			fixed (NativeMethods.MessageHandle* ptr = &self)
			{
				num = NativeMethods.MessageHandle.DisclosureType(ptr, &value);
			}
			if (!num)
			{
				return null;
			}
			return value;
		}

		public unsafe ulong EditedTimestamp()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("MessageHandle");
			}
			ulong result;
			fixed (NativeMethods.MessageHandle* ptr = &self)
			{
				result = NativeMethods.MessageHandle.EditedTimestamp(ptr);
			}
			return result;
		}

		public unsafe ulong Id()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("MessageHandle");
			}
			ulong result;
			fixed (NativeMethods.MessageHandle* ptr = &self)
			{
				result = NativeMethods.MessageHandle.Id(ptr);
			}
			return result;
		}

		public unsafe LobbyHandle? Lobby()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("MessageHandle");
			}
			NativeMethods.LobbyHandle lobbyHandle = default(NativeMethods.LobbyHandle);
			bool num;
			fixed (NativeMethods.MessageHandle* ptr = &self)
			{
				num = NativeMethods.MessageHandle.Lobby(ptr, &lobbyHandle);
			}
			if (!num)
			{
				return null;
			}
			return new LobbyHandle(lobbyHandle, 0);
		}

		public unsafe Dictionary<string, string> Metadata()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("MessageHandle");
			}
			NativeMethods.Discord_Properties props = default(NativeMethods.Discord_Properties);
			fixed (NativeMethods.MessageHandle* ptr = &self)
			{
				NativeMethods.MessageHandle.Metadata(ptr, &props);
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

		public unsafe Dictionary<string, string> ModerationMetadata()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("MessageHandle");
			}
			NativeMethods.Discord_Properties props = default(NativeMethods.Discord_Properties);
			fixed (NativeMethods.MessageHandle* ptr = &self)
			{
				NativeMethods.MessageHandle.ModerationMetadata(ptr, &props);
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

		public unsafe string RawContent()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("MessageHandle");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.MessageHandle* ptr = &self)
			{
				NativeMethods.MessageHandle.RawContent(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe UserHandle? Recipient()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("MessageHandle");
			}
			NativeMethods.UserHandle userHandle = default(NativeMethods.UserHandle);
			bool num;
			fixed (NativeMethods.MessageHandle* ptr = &self)
			{
				num = NativeMethods.MessageHandle.Recipient(ptr, &userHandle);
			}
			if (!num)
			{
				return null;
			}
			return new UserHandle(userHandle, 0);
		}

		public unsafe ulong RecipientId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("MessageHandle");
			}
			ulong result;
			fixed (NativeMethods.MessageHandle* ptr = &self)
			{
				result = NativeMethods.MessageHandle.RecipientId(ptr);
			}
			return result;
		}

		public unsafe bool SentFromGame()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("MessageHandle");
			}
			bool result;
			fixed (NativeMethods.MessageHandle* ptr = &self)
			{
				result = NativeMethods.MessageHandle.SentFromGame(ptr);
			}
			return result;
		}

		public unsafe ulong SentTimestamp()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("MessageHandle");
			}
			ulong result;
			fixed (NativeMethods.MessageHandle* ptr = &self)
			{
				result = NativeMethods.MessageHandle.SentTimestamp(ptr);
			}
			return result;
		}
	}
}
