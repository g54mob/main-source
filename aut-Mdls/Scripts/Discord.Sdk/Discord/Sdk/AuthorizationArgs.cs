using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class AuthorizationArgs : IDisposable
	{
		internal NativeMethods.AuthorizationArgs self;

		private int disposed_;

		internal AuthorizationArgs(NativeMethods.AuthorizationArgs self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~AuthorizationArgs()
		{
			Dispose();
		}

		public unsafe AuthorizationArgs()
		{
			NativeMethods.__Init();
			fixed (NativeMethods.AuthorizationArgs* ptr = &self)
			{
				NativeMethods.AuthorizationArgs.Init(ptr);
			}
			NativeMethods.__OnPostConstruct(this);
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.AuthorizationArgs* ptr = &self)
				{
					NativeMethods.AuthorizationArgs.Drop(ptr);
				}
			}
		}

		public unsafe AuthorizationArgs(AuthorizationArgs other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationArgs");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.AuthorizationArgs* arg = &other.self)
			{
				fixed (NativeMethods.AuthorizationArgs* ptr = &self)
				{
					NativeMethods.AuthorizationArgs.Clone(ptr, arg);
				}
			}
		}

		internal unsafe AuthorizationArgs(NativeMethods.AuthorizationArgs* otherPtr)
		{
			fixed (NativeMethods.AuthorizationArgs* ptr = &self)
			{
				NativeMethods.AuthorizationArgs.Clone(ptr, otherPtr);
			}
		}

		public unsafe ulong ClientId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationArgs");
			}
			ulong result;
			fixed (NativeMethods.AuthorizationArgs* ptr = &self)
			{
				result = NativeMethods.AuthorizationArgs.ClientId(ptr);
			}
			return result;
		}

		public unsafe void SetClientId(ulong value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationArgs");
			}
			fixed (NativeMethods.AuthorizationArgs* ptr = &self)
			{
				NativeMethods.AuthorizationArgs.SetClientId(ptr, value);
			}
		}

		public unsafe string Scopes()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationArgs");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.AuthorizationArgs* ptr = &self)
			{
				NativeMethods.AuthorizationArgs.Scopes(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetScopes(string value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationArgs");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String value2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &value2, value);
			fixed (NativeMethods.AuthorizationArgs* ptr = &self)
			{
				NativeMethods.AuthorizationArgs.SetScopes(ptr, value2);
			}
			NativeMethods.__FreeLocalString(&value2, owned);
		}

		public unsafe string? State()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationArgs");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool num;
			fixed (NativeMethods.AuthorizationArgs* ptr = &self)
			{
				num = NativeMethods.AuthorizationArgs.State(ptr, &discord_String);
			}
			if (!num)
			{
				return null;
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetState(string? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationArgs");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitNullableStringLocal(buf, &num, 1024, &discord_String, value);
			fixed (NativeMethods.AuthorizationArgs* ptr = &self)
			{
				NativeMethods.AuthorizationArgs.SetState(ptr, (value != null) ? (&discord_String) : null);
			}
			NativeMethods.__FreeLocalString(&discord_String, owned);
		}

		public unsafe string? Nonce()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationArgs");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool num;
			fixed (NativeMethods.AuthorizationArgs* ptr = &self)
			{
				num = NativeMethods.AuthorizationArgs.Nonce(ptr, &discord_String);
			}
			if (!num)
			{
				return null;
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetNonce(string? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationArgs");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitNullableStringLocal(buf, &num, 1024, &discord_String, value);
			fixed (NativeMethods.AuthorizationArgs* ptr = &self)
			{
				NativeMethods.AuthorizationArgs.SetNonce(ptr, (value != null) ? (&discord_String) : null);
			}
			NativeMethods.__FreeLocalString(&discord_String, owned);
		}

		public unsafe AuthorizationCodeChallenge? CodeChallenge()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationArgs");
			}
			NativeMethods.AuthorizationCodeChallenge authorizationCodeChallenge = default(NativeMethods.AuthorizationCodeChallenge);
			bool num;
			fixed (NativeMethods.AuthorizationArgs* ptr = &self)
			{
				num = NativeMethods.AuthorizationArgs.CodeChallenge(ptr, &authorizationCodeChallenge);
			}
			if (!num)
			{
				return null;
			}
			return new AuthorizationCodeChallenge(authorizationCodeChallenge, 0);
		}

		public unsafe void SetCodeChallenge(AuthorizationCodeChallenge? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationArgs");
			}
			NativeMethods.AuthorizationCodeChallenge authorizationCodeChallenge = value?.self ?? default(NativeMethods.AuthorizationCodeChallenge);
			fixed (NativeMethods.AuthorizationArgs* ptr = &self)
			{
				NativeMethods.AuthorizationArgs.SetCodeChallenge(ptr, (value != null) ? (&authorizationCodeChallenge) : null);
			}
			if (value != null)
			{
				value.self = authorizationCodeChallenge;
			}
		}

		public unsafe IntegrationType? IntegrationType()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationArgs");
			}
			bool num;
			IntegrationType value = default(IntegrationType);
			fixed (NativeMethods.AuthorizationArgs* ptr = &self)
			{
				num = NativeMethods.AuthorizationArgs.IntegrationType(ptr, &value);
			}
			if (!num)
			{
				return null;
			}
			return value;
		}

		public unsafe void SetIntegrationType(IntegrationType? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationArgs");
			}
			IntegrationType valueOrDefault = value.GetValueOrDefault();
			fixed (NativeMethods.AuthorizationArgs* ptr = &self)
			{
				NativeMethods.AuthorizationArgs.SetIntegrationType(ptr, value.HasValue ? (&valueOrDefault) : null);
			}
		}

		public unsafe string? CustomSchemeParam()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationArgs");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool num;
			fixed (NativeMethods.AuthorizationArgs* ptr = &self)
			{
				num = NativeMethods.AuthorizationArgs.CustomSchemeParam(ptr, &discord_String);
			}
			if (!num)
			{
				return null;
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetCustomSchemeParam(string? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("AuthorizationArgs");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitNullableStringLocal(buf, &num, 1024, &discord_String, value);
			fixed (NativeMethods.AuthorizationArgs* ptr = &self)
			{
				NativeMethods.AuthorizationArgs.SetCustomSchemeParam(ptr, (value != null) ? (&discord_String) : null);
			}
			NativeMethods.__FreeLocalString(&discord_String, owned);
		}
	}
}
