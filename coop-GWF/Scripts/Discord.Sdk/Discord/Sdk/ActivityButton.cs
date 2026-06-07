using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class ActivityButton : IDisposable
	{
		internal NativeMethods.ActivityButton self;

		private int disposed_;

		internal ActivityButton(NativeMethods.ActivityButton self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~ActivityButton()
		{
			Dispose();
		}

		public unsafe ActivityButton()
		{
			NativeMethods.__Init();
			fixed (NativeMethods.ActivityButton* ptr = &self)
			{
				NativeMethods.ActivityButton.Init(ptr);
			}
			NativeMethods.__OnPostConstruct(this);
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.ActivityButton* ptr = &self)
				{
					NativeMethods.ActivityButton.Drop(ptr);
				}
			}
		}

		public unsafe ActivityButton(ActivityButton other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityButton");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.ActivityButton* arg = &other.self)
			{
				fixed (NativeMethods.ActivityButton* ptr = &self)
				{
					NativeMethods.ActivityButton.Clone(ptr, arg);
				}
			}
		}

		internal unsafe ActivityButton(NativeMethods.ActivityButton* otherPtr)
		{
			fixed (NativeMethods.ActivityButton* ptr = &self)
			{
				NativeMethods.ActivityButton.Clone(ptr, otherPtr);
			}
		}

		public unsafe string Label()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityButton");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.ActivityButton* ptr = &self)
			{
				NativeMethods.ActivityButton.Label(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetLabel(string value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityButton");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String value2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &value2, value);
			fixed (NativeMethods.ActivityButton* ptr = &self)
			{
				NativeMethods.ActivityButton.SetLabel(ptr, value2);
			}
			NativeMethods.__FreeLocalString(&value2, owned);
		}

		public unsafe string Url()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityButton");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.ActivityButton* ptr = &self)
			{
				NativeMethods.ActivityButton.Url(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetUrl(string value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ActivityButton");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String value2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &value2, value);
			fixed (NativeMethods.ActivityButton* ptr = &self)
			{
				NativeMethods.ActivityButton.SetUrl(ptr, value2);
			}
			NativeMethods.__FreeLocalString(&value2, owned);
		}
	}
}
