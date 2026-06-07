using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class AuthorizationCodeVerifier : IDisposable
	{
		internal NativeMethods.AuthorizationCodeVerifier self;

		private int disposed_;

		internal AuthorizationCodeVerifier(NativeMethods.AuthorizationCodeVerifier self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~AuthorizationCodeVerifier()
		{
			Dispose();
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.AuthorizationCodeVerifier* ptr = &self)
				{
					NativeMethods.AuthorizationCodeVerifier.Drop(ptr);
				}
			}
		}

		public unsafe AuthorizationCodeVerifier(AuthorizationCodeVerifier other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationCodeVerifier");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.AuthorizationCodeVerifier* arg = &other.self)
			{
				fixed (NativeMethods.AuthorizationCodeVerifier* ptr = &self)
				{
					NativeMethods.AuthorizationCodeVerifier.Clone(ptr, arg);
				}
			}
		}

		internal unsafe AuthorizationCodeVerifier(NativeMethods.AuthorizationCodeVerifier* otherPtr)
		{
			fixed (NativeMethods.AuthorizationCodeVerifier* ptr = &self)
			{
				NativeMethods.AuthorizationCodeVerifier.Clone(ptr, otherPtr);
			}
		}

		public unsafe AuthorizationCodeChallenge Challenge()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationCodeVerifier");
			}
			NativeMethods.AuthorizationCodeChallenge authorizationCodeChallenge = default(NativeMethods.AuthorizationCodeChallenge);
			fixed (NativeMethods.AuthorizationCodeVerifier* ptr = &self)
			{
				NativeMethods.AuthorizationCodeVerifier.Challenge(ptr, &authorizationCodeChallenge);
			}
			return new AuthorizationCodeChallenge(authorizationCodeChallenge, 0);
		}

		public unsafe void SetChallenge(AuthorizationCodeChallenge value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationCodeVerifier");
			}
			fixed (NativeMethods.AuthorizationCodeChallenge* value2 = &value.self)
			{
				fixed (NativeMethods.AuthorizationCodeVerifier* ptr = &self)
				{
					NativeMethods.AuthorizationCodeVerifier.SetChallenge(ptr, value2);
				}
			}
		}

		public unsafe string Verifier()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationCodeVerifier");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.AuthorizationCodeVerifier* ptr = &self)
			{
				NativeMethods.AuthorizationCodeVerifier.Verifier(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetVerifier(string value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationCodeVerifier");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String value2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &value2, value);
			fixed (NativeMethods.AuthorizationCodeVerifier* ptr = &self)
			{
				NativeMethods.AuthorizationCodeVerifier.SetVerifier(ptr, value2);
			}
			NativeMethods.__FreeLocalString(&value2, owned);
		}
	}
}
