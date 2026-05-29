using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Steamworks
{
	public sealed class Callback<T> : IDisposable
	{
		public delegate void DispatchDelegate(T param);

		private CCallbackBaseVTable VTable;

		private IntPtr m_pVTable;

		private CCallbackBase m_CCallbackBase;

		private GCHandle m_pCCallbackBase;

		private bool m_bGameServer;

		private readonly int m_size;

		private bool m_bDisposed;

		private event DispatchDelegate m_Func
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static Callback<T> Create(DispatchDelegate func)
		{
			return null;
		}

		public static Callback<T> CreateGameServer(DispatchDelegate func)
		{
			return null;
		}

		public Callback(DispatchDelegate func, bool bGameServer = false)
		{
		}

		~Callback()
		{
		}

		public void Dispose()
		{
		}

		public void Register(DispatchDelegate func)
		{
		}

		public void Unregister()
		{
		}

		public void SetGameserverFlag()
		{
		}

		private void OnRunCallback(IntPtr thisptr, IntPtr pvParam)
		{
		}

		private void OnRunCallResult(IntPtr thisptr, IntPtr pvParam, bool bFailed, ulong hSteamAPICall)
		{
		}

		private int OnGetCallbackSizeBytes(IntPtr thisptr)
		{
			return 0;
		}

		private void BuildCCallbackBase()
		{
		}
	}
}
