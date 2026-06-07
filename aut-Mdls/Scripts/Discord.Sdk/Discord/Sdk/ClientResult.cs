using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class ClientResult : IDisposable
	{
		internal NativeMethods.ClientResult self;

		private int disposed_;

		internal ClientResult(NativeMethods.ClientResult self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~ClientResult()
		{
			Dispose();
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.ClientResult* ptr = &self)
				{
					NativeMethods.ClientResult.Drop(ptr);
				}
			}
		}

		public unsafe ClientResult(ClientResult other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientResult");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.ClientResult* arg = &other.self)
			{
				fixed (NativeMethods.ClientResult* ptr = &self)
				{
					NativeMethods.ClientResult.Clone(ptr, arg);
				}
			}
		}

		internal unsafe ClientResult(NativeMethods.ClientResult* otherPtr)
		{
			fixed (NativeMethods.ClientResult* ptr = &self)
			{
				NativeMethods.ClientResult.Clone(ptr, otherPtr);
			}
		}

		public unsafe override string ToString()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientResult");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.ClientResult* ptr = &self)
			{
				NativeMethods.ClientResult.ToString(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe ErrorType Type()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientResult");
			}
			ErrorType result;
			fixed (NativeMethods.ClientResult* ptr = &self)
			{
				result = NativeMethods.ClientResult.Type(ptr);
			}
			return result;
		}

		public unsafe void SetType(ErrorType value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientResult");
			}
			fixed (NativeMethods.ClientResult* ptr = &self)
			{
				NativeMethods.ClientResult.SetType(ptr, value);
			}
		}

		public unsafe string Error()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientResult");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.ClientResult* ptr = &self)
			{
				NativeMethods.ClientResult.Error(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetError(string value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientResult");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String value2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &value2, value);
			fixed (NativeMethods.ClientResult* ptr = &self)
			{
				NativeMethods.ClientResult.SetError(ptr, value2);
			}
			NativeMethods.__FreeLocalString(&value2, owned);
		}

		public unsafe int ErrorCode()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientResult");
			}
			int result;
			fixed (NativeMethods.ClientResult* ptr = &self)
			{
				result = NativeMethods.ClientResult.ErrorCode(ptr);
			}
			return result;
		}

		public unsafe void SetErrorCode(int value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientResult");
			}
			fixed (NativeMethods.ClientResult* ptr = &self)
			{
				NativeMethods.ClientResult.SetErrorCode(ptr, value);
			}
		}

		public unsafe HttpStatusCode Status()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientResult");
			}
			HttpStatusCode result;
			fixed (NativeMethods.ClientResult* ptr = &self)
			{
				result = NativeMethods.ClientResult.Status(ptr);
			}
			return result;
		}

		public unsafe void SetStatus(HttpStatusCode value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientResult");
			}
			fixed (NativeMethods.ClientResult* ptr = &self)
			{
				NativeMethods.ClientResult.SetStatus(ptr, value);
			}
		}

		public unsafe string ResponseBody()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientResult");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.ClientResult* ptr = &self)
			{
				NativeMethods.ClientResult.ResponseBody(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetResponseBody(string value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientResult");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String value2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &value2, value);
			fixed (NativeMethods.ClientResult* ptr = &self)
			{
				NativeMethods.ClientResult.SetResponseBody(ptr, value2);
			}
			NativeMethods.__FreeLocalString(&value2, owned);
		}

		public unsafe bool Successful()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientResult");
			}
			bool result;
			fixed (NativeMethods.ClientResult* ptr = &self)
			{
				result = NativeMethods.ClientResult.Successful(ptr);
			}
			return result;
		}

		public unsafe void SetSuccessful(bool value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientResult");
			}
			fixed (NativeMethods.ClientResult* ptr = &self)
			{
				NativeMethods.ClientResult.SetSuccessful(ptr, value);
			}
		}

		public unsafe bool Retryable()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientResult");
			}
			bool result;
			fixed (NativeMethods.ClientResult* ptr = &self)
			{
				result = NativeMethods.ClientResult.Retryable(ptr);
			}
			return result;
		}

		public unsafe void SetRetryable(bool value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientResult");
			}
			fixed (NativeMethods.ClientResult* ptr = &self)
			{
				NativeMethods.ClientResult.SetRetryable(ptr, value);
			}
		}

		public unsafe float RetryAfter()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientResult");
			}
			float result;
			fixed (NativeMethods.ClientResult* ptr = &self)
			{
				result = NativeMethods.ClientResult.RetryAfter(ptr);
			}
			return result;
		}

		public unsafe void SetRetryAfter(float value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("ClientResult");
			}
			fixed (NativeMethods.ClientResult* ptr = &self)
			{
				NativeMethods.ClientResult.SetRetryAfter(ptr, value);
			}
		}
	}
}
