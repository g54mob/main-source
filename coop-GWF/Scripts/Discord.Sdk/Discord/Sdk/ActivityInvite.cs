using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class ActivityInvite : IDisposable
	{
		internal NativeMethods.ActivityInvite self;

		private int disposed_;

		internal ActivityInvite(NativeMethods.ActivityInvite self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~ActivityInvite()
		{
			Dispose();
		}

		public unsafe ActivityInvite()
		{
			NativeMethods.__Init();
			fixed (NativeMethods.ActivityInvite* ptr = &self)
			{
				NativeMethods.ActivityInvite.Init(ptr);
			}
			NativeMethods.__OnPostConstruct(this);
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.ActivityInvite* ptr = &self)
				{
					NativeMethods.ActivityInvite.Drop(ptr);
				}
			}
		}

		public unsafe ActivityInvite(ActivityInvite other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityInvite");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.ActivityInvite* rhs = &other.self)
			{
				fixed (NativeMethods.ActivityInvite* ptr = &self)
				{
					NativeMethods.ActivityInvite.Clone(ptr, rhs);
				}
			}
		}

		internal unsafe ActivityInvite(NativeMethods.ActivityInvite* otherPtr)
		{
			fixed (NativeMethods.ActivityInvite* ptr = &self)
			{
				NativeMethods.ActivityInvite.Clone(ptr, otherPtr);
			}
		}

		public unsafe ulong SenderId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityInvite");
			}
			ulong result;
			fixed (NativeMethods.ActivityInvite* ptr = &self)
			{
				result = NativeMethods.ActivityInvite.SenderId(ptr);
			}
			return result;
		}

		public unsafe void SetSenderId(ulong value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityInvite");
			}
			fixed (NativeMethods.ActivityInvite* ptr = &self)
			{
				NativeMethods.ActivityInvite.SetSenderId(ptr, value);
			}
		}

		public unsafe ulong ChannelId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityInvite");
			}
			ulong result;
			fixed (NativeMethods.ActivityInvite* ptr = &self)
			{
				result = NativeMethods.ActivityInvite.ChannelId(ptr);
			}
			return result;
		}

		public unsafe void SetChannelId(ulong value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityInvite");
			}
			fixed (NativeMethods.ActivityInvite* ptr = &self)
			{
				NativeMethods.ActivityInvite.SetChannelId(ptr, value);
			}
		}

		public unsafe ulong MessageId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityInvite");
			}
			ulong result;
			fixed (NativeMethods.ActivityInvite* ptr = &self)
			{
				result = NativeMethods.ActivityInvite.MessageId(ptr);
			}
			return result;
		}

		public unsafe void SetMessageId(ulong value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityInvite");
			}
			fixed (NativeMethods.ActivityInvite* ptr = &self)
			{
				NativeMethods.ActivityInvite.SetMessageId(ptr, value);
			}
		}

		public unsafe ActivityActionTypes Type()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityInvite");
			}
			ActivityActionTypes result;
			fixed (NativeMethods.ActivityInvite* ptr = &self)
			{
				result = NativeMethods.ActivityInvite.Type(ptr);
			}
			return result;
		}

		public unsafe void SetType(ActivityActionTypes value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityInvite");
			}
			fixed (NativeMethods.ActivityInvite* ptr = &self)
			{
				NativeMethods.ActivityInvite.SetType(ptr, value);
			}
		}

		public unsafe ulong ApplicationId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityInvite");
			}
			ulong result;
			fixed (NativeMethods.ActivityInvite* ptr = &self)
			{
				result = NativeMethods.ActivityInvite.ApplicationId(ptr);
			}
			return result;
		}

		public unsafe void SetApplicationId(ulong value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityInvite");
			}
			fixed (NativeMethods.ActivityInvite* ptr = &self)
			{
				NativeMethods.ActivityInvite.SetApplicationId(ptr, value);
			}
		}

		public unsafe ulong ParentApplicationId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityInvite");
			}
			ulong result;
			fixed (NativeMethods.ActivityInvite* ptr = &self)
			{
				result = NativeMethods.ActivityInvite.ParentApplicationId(ptr);
			}
			return result;
		}

		public unsafe void SetParentApplicationId(ulong value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityInvite");
			}
			fixed (NativeMethods.ActivityInvite* ptr = &self)
			{
				NativeMethods.ActivityInvite.SetParentApplicationId(ptr, value);
			}
		}

		public unsafe string PartyId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityInvite");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.ActivityInvite* ptr = &self)
			{
				NativeMethods.ActivityInvite.PartyId(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetPartyId(string value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityInvite");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String value2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &value2, value);
			fixed (NativeMethods.ActivityInvite* ptr = &self)
			{
				NativeMethods.ActivityInvite.SetPartyId(ptr, value2);
			}
			NativeMethods.__FreeLocalString(&value2, owned);
		}

		public unsafe string SessionId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityInvite");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.ActivityInvite* ptr = &self)
			{
				NativeMethods.ActivityInvite.SessionId(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetSessionId(string value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityInvite");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String value2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &value2, value);
			fixed (NativeMethods.ActivityInvite* ptr = &self)
			{
				NativeMethods.ActivityInvite.SetSessionId(ptr, value2);
			}
			NativeMethods.__FreeLocalString(&value2, owned);
		}

		public unsafe bool IsValid()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityInvite");
			}
			bool result;
			fixed (NativeMethods.ActivityInvite* ptr = &self)
			{
				result = NativeMethods.ActivityInvite.IsValid(ptr);
			}
			return result;
		}

		public unsafe void SetIsValid(bool value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityInvite");
			}
			fixed (NativeMethods.ActivityInvite* ptr = &self)
			{
				NativeMethods.ActivityInvite.SetIsValid(ptr, value);
			}
		}
	}
}
