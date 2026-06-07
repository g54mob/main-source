using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class AuthorizationCodeChallenge : IDisposable
	{
		internal NativeMethods.AuthorizationCodeChallenge self;

		private int disposed_;

		internal AuthorizationCodeChallenge(NativeMethods.AuthorizationCodeChallenge self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~AuthorizationCodeChallenge()
		{
			Dispose();
		}

		public unsafe AuthorizationCodeChallenge()
		{
			NativeMethods.__Init();
			fixed (NativeMethods.AuthorizationCodeChallenge* ptr = &self)
			{
				NativeMethods.AuthorizationCodeChallenge.Init(ptr);
			}
			NativeMethods.__OnPostConstruct(this);
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.AuthorizationCodeChallenge* ptr = &self)
				{
					NativeMethods.AuthorizationCodeChallenge.Drop(ptr);
				}
			}
		}

		public unsafe AuthorizationCodeChallenge(AuthorizationCodeChallenge other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationCodeChallenge");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.AuthorizationCodeChallenge* arg = &other.self)
			{
				fixed (NativeMethods.AuthorizationCodeChallenge* ptr = &self)
				{
					NativeMethods.AuthorizationCodeChallenge.Clone(ptr, arg);
				}
			}
		}

		internal unsafe AuthorizationCodeChallenge(NativeMethods.AuthorizationCodeChallenge* otherPtr)
		{
			fixed (NativeMethods.AuthorizationCodeChallenge* ptr = &self)
			{
				NativeMethods.AuthorizationCodeChallenge.Clone(ptr, otherPtr);
			}
		}

		public unsafe AuthenticationCodeChallengeMethod Method()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationCodeChallenge");
			}
			AuthenticationCodeChallengeMethod result;
			fixed (NativeMethods.AuthorizationCodeChallenge* ptr = &self)
			{
				result = NativeMethods.AuthorizationCodeChallenge.Method(ptr);
			}
			return result;
		}

		public unsafe void SetMethod(AuthenticationCodeChallengeMethod value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationCodeChallenge");
			}
			fixed (NativeMethods.AuthorizationCodeChallenge* ptr = &self)
			{
				NativeMethods.AuthorizationCodeChallenge.SetMethod(ptr, value);
			}
		}

		public unsafe string Challenge()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationCodeChallenge");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.AuthorizationCodeChallenge* ptr = &self)
			{
				NativeMethods.AuthorizationCodeChallenge.Challenge(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetChallenge(string value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationCodeChallenge");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String value2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &value2, value);
			fixed (NativeMethods.AuthorizationCodeChallenge* ptr = &self)
			{
				NativeMethods.AuthorizationCodeChallenge.SetChallenge(ptr, value2);
			}
			NativeMethods.__FreeLocalString(&value2, owned);
		}
	}
}
