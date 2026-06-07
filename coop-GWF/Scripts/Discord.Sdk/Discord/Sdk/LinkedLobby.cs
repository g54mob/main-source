using System;
using System.Threading;

namespace Discord.Sdk
{
	public class LinkedLobby : IDisposable
	{
		internal NativeMethods.LinkedLobby self;

		private int disposed_;

		internal LinkedLobby(NativeMethods.LinkedLobby self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~LinkedLobby()
		{
			Dispose();
		}

		public unsafe LinkedLobby()
		{
			NativeMethods.__Init();
			fixed (NativeMethods.LinkedLobby* ptr = &self)
			{
				NativeMethods.LinkedLobby.Init(ptr);
			}
			NativeMethods.__OnPostConstruct(this);
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.LinkedLobby* ptr = &self)
				{
					NativeMethods.LinkedLobby.Drop(ptr);
				}
			}
		}

		public unsafe LinkedLobby(LinkedLobby other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LinkedLobby");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.LinkedLobby* arg = &other.self)
			{
				fixed (NativeMethods.LinkedLobby* ptr = &self)
				{
					NativeMethods.LinkedLobby.Clone(ptr, arg);
				}
			}
		}

		internal unsafe LinkedLobby(NativeMethods.LinkedLobby* otherPtr)
		{
			fixed (NativeMethods.LinkedLobby* ptr = &self)
			{
				NativeMethods.LinkedLobby.Clone(ptr, otherPtr);
			}
		}

		public unsafe ulong ApplicationId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LinkedLobby");
			}
			ulong result;
			fixed (NativeMethods.LinkedLobby* ptr = &self)
			{
				result = NativeMethods.LinkedLobby.ApplicationId(ptr);
			}
			return result;
		}

		public unsafe void SetApplicationId(ulong value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LinkedLobby");
			}
			fixed (NativeMethods.LinkedLobby* ptr = &self)
			{
				NativeMethods.LinkedLobby.SetApplicationId(ptr, value);
			}
		}

		public unsafe ulong LobbyId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LinkedLobby");
			}
			ulong result;
			fixed (NativeMethods.LinkedLobby* ptr = &self)
			{
				result = NativeMethods.LinkedLobby.LobbyId(ptr);
			}
			return result;
		}

		public unsafe void SetLobbyId(ulong value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("LinkedLobby");
			}
			fixed (NativeMethods.LinkedLobby* ptr = &self)
			{
				NativeMethods.LinkedLobby.SetLobbyId(ptr, value);
			}
		}
	}
}
