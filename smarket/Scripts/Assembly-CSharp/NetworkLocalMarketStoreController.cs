using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Photon.Pun;

public class NetworkLocalMarketStoreController : MonoBehaviourPun
{
	[CompilerGenerated]
	private sealed class _003CTestUpdateAvailabilityDelayed_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NetworkLocalMarketStoreController _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CTestUpdateAvailabilityDelayed_003Ed__8(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CUpdatePlayerStoreAvailabilityDelayed_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NetworkLocalMarketStoreController _003C_003E4__this;

		public string id;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CUpdatePlayerStoreAvailabilityDelayed_003Ed__6(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private LocalMarketStoreController m_StoreController;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void OnSyncRequested(string id)
	{
	}

	[IteratorStateMachine(typeof(_003CUpdatePlayerStoreAvailabilityDelayed_003Ed__6))]
	private IEnumerator UpdatePlayerStoreAvailabilityDelayed(string id)
	{
		return null;
	}

	private void OnLicensePurchased(int obj)
	{
	}

	[IteratorStateMachine(typeof(_003CTestUpdateAvailabilityDelayed_003Ed__8))]
	private IEnumerator TestUpdateAvailabilityDelayed()
	{
		return null;
	}

	public void UpdateStoreAvailability_User(string userId)
	{
	}

	public void UpdateStoreAvailability_Broadcast()
	{
	}

	[PunRPC]
	public void UpdateStoreAvailability_RPC()
	{
	}
}
