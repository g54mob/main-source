using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class AdditionalContent : IDisposable
	{
		internal NativeMethods.AdditionalContent self;

		private int disposed_;

		internal AdditionalContent(NativeMethods.AdditionalContent self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~AdditionalContent()
		{
			Dispose();
		}

		public unsafe AdditionalContent()
		{
			NativeMethods.__Init();
			fixed (NativeMethods.AdditionalContent* ptr = &self)
			{
				NativeMethods.AdditionalContent.Init(ptr);
			}
			NativeMethods.__OnPostConstruct(this);
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.AdditionalContent* ptr = &self)
				{
					NativeMethods.AdditionalContent.Drop(ptr);
				}
			}
		}

		public unsafe AdditionalContent(AdditionalContent other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AdditionalContent");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.AdditionalContent* arg = &other.self)
			{
				fixed (NativeMethods.AdditionalContent* ptr = &self)
				{
					NativeMethods.AdditionalContent.Clone(ptr, arg);
				}
			}
		}

		internal unsafe AdditionalContent(NativeMethods.AdditionalContent* otherPtr)
		{
			fixed (NativeMethods.AdditionalContent* ptr = &self)
			{
				NativeMethods.AdditionalContent.Clone(ptr, otherPtr);
			}
		}

		public unsafe bool Equals(AdditionalContent rhs)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AdditionalContent");
			}
			bool result;
			fixed (NativeMethods.AdditionalContent* rhs2 = &rhs.self)
			{
				fixed (NativeMethods.AdditionalContent* ptr = &self)
				{
					result = NativeMethods.AdditionalContent.Equals(ptr, rhs2);
				}
			}
			return result;
		}

		public unsafe static string TypeToString(AdditionalContentType type)
		{
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			NativeMethods.AdditionalContent.TypeToString(type, &discord_String);
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe AdditionalContentType Type()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AdditionalContent");
			}
			AdditionalContentType result;
			fixed (NativeMethods.AdditionalContent* ptr = &self)
			{
				result = NativeMethods.AdditionalContent.Type(ptr);
			}
			return result;
		}

		public unsafe void SetType(AdditionalContentType value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AdditionalContent");
			}
			fixed (NativeMethods.AdditionalContent* ptr = &self)
			{
				NativeMethods.AdditionalContent.SetType(ptr, value);
			}
		}

		public unsafe string? Title()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AdditionalContent");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool num;
			fixed (NativeMethods.AdditionalContent* ptr = &self)
			{
				num = NativeMethods.AdditionalContent.Title(ptr, &discord_String);
			}
			if (!num)
			{
				return null;
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetTitle(string? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AdditionalContent");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitNullableStringLocal(buf, &num, 1024, &discord_String, value);
			fixed (NativeMethods.AdditionalContent* ptr = &self)
			{
				NativeMethods.AdditionalContent.SetTitle(ptr, (value != null) ? (&discord_String) : null);
			}
			NativeMethods.__FreeLocalString(&discord_String, owned);
		}

		public unsafe byte Count()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AdditionalContent");
			}
			byte result;
			fixed (NativeMethods.AdditionalContent* ptr = &self)
			{
				result = NativeMethods.AdditionalContent.Count(ptr);
			}
			return result;
		}

		public unsafe void SetCount(byte value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AdditionalContent");
			}
			fixed (NativeMethods.AdditionalContent* ptr = &self)
			{
				NativeMethods.AdditionalContent.SetCount(ptr, value);
			}
		}
	}
}
