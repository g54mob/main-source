using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Steamworks
{
	public sealed class CallResult<T> : IDisposable
	{
		public delegate void APIDispatchDelegate(T param, bool bIOFailure);

		private CCallbackBaseVTable VTable;

		private IntPtr m_pVTable;

		private CCallbackBase m_CCallbackBase;

		private GCHandle m_pCCallbackBase;

		private SteamAPICall_t m_hAPICall;

		private readonly int m_size;

		private bool m_bDisposed;

		public SteamAPICall_t Handle => default(SteamAPICall_t);

		private event APIDispatchDelegate m_Func
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

		public static CallResult<T> Create(APIDispatchDelegate func = null)
		{
			return null;
		}

		public CallResult(APIDispatchDelegate func = null)
		{
		}

		~CallResult()
		{
		}

		public void Dispose()
		{
		}

		public void Set(SteamAPICall_t hAPICall, APIDispatchDelegate func = null)
		{
		}

		public bool IsActive()
		{
			return false;
		}

		public void Cancel()
		{
		}

		public void SetGameserverFlag()
		{
		}

		private void OnRunCallback(IntPtr thisptr, IntPtr pvParam)
		{
		}

		private void OnRunCallResult(IntPtr thisptr, IntPtr pvParam, bool bFailed, ulong hSteamAPICall_)
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
