using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class ActivityParty : IDisposable
	{
		internal NativeMethods.ActivityParty self;

		private int disposed_;

		internal ActivityParty(NativeMethods.ActivityParty self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~ActivityParty()
		{
			Dispose();
		}

		public unsafe ActivityParty()
		{
			NativeMethods.__Init();
			fixed (NativeMethods.ActivityParty* ptr = &self)
			{
				NativeMethods.ActivityParty.Init(ptr);
			}
			NativeMethods.__OnPostConstruct(this);
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.ActivityParty* ptr = &self)
				{
					NativeMethods.ActivityParty.Drop(ptr);
				}
			}
		}

		public unsafe ActivityParty(ActivityParty other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityParty");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.ActivityParty* arg = &other.self)
			{
				fixed (NativeMethods.ActivityParty* ptr = &self)
				{
					NativeMethods.ActivityParty.Clone(ptr, arg);
				}
			}
		}

		internal unsafe ActivityParty(NativeMethods.ActivityParty* otherPtr)
		{
			fixed (NativeMethods.ActivityParty* ptr = &self)
			{
				NativeMethods.ActivityParty.Clone(ptr, otherPtr);
			}
		}

		public unsafe string Id()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityParty");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.ActivityParty* ptr = &self)
			{
				NativeMethods.ActivityParty.Id(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetId(string value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityParty");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String value2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &value2, value);
			fixed (NativeMethods.ActivityParty* ptr = &self)
			{
				NativeMethods.ActivityParty.SetId(ptr, value2);
			}
			NativeMethods.__FreeLocalString(&value2, owned);
		}

		public unsafe int CurrentSize()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityParty");
			}
			int result;
			fixed (NativeMethods.ActivityParty* ptr = &self)
			{
				result = NativeMethods.ActivityParty.CurrentSize(ptr);
			}
			return result;
		}

		public unsafe void SetCurrentSize(int value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityParty");
			}
			fixed (NativeMethods.ActivityParty* ptr = &self)
			{
				NativeMethods.ActivityParty.SetCurrentSize(ptr, value);
			}
		}

		public unsafe int MaxSize()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityParty");
			}
			int result;
			fixed (NativeMethods.ActivityParty* ptr = &self)
			{
				result = NativeMethods.ActivityParty.MaxSize(ptr);
			}
			return result;
		}

		public unsafe void SetMaxSize(int value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityParty");
			}
			fixed (NativeMethods.ActivityParty* ptr = &self)
			{
				NativeMethods.ActivityParty.SetMaxSize(ptr, value);
			}
		}

		public unsafe ActivityPartyPrivacy Privacy()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityParty");
			}
			ActivityPartyPrivacy result;
			fixed (NativeMethods.ActivityParty* ptr = &self)
			{
				result = NativeMethods.ActivityParty.Privacy(ptr);
			}
			return result;
		}

		public unsafe void SetPrivacy(ActivityPartyPrivacy value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityParty");
			}
			fixed (NativeMethods.ActivityParty* ptr = &self)
			{
				NativeMethods.ActivityParty.SetPrivacy(ptr, value);
			}
		}
	}
}
