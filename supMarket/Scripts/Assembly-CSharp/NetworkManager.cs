using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;
using MyBox;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class NetworkManager : NoktaSingletonPunCallbacks<NetworkManager>
{
	[CompilerGenerated]
	private sealed class _003CInitialLoadingUIRoutine_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NetworkManager _003C_003E4__this;

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
		public _003CInitialLoadingUIRoutine_003Ed__34(int _003C_003E1__state)
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
	private sealed class _003CInitialLoadingWarningRoutine_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NetworkManager _003C_003E4__this;

		public Player newPlayer;

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
		public _003CInitialLoadingWarningRoutine_003Ed__35(int _003C_003E1__state)
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
	private sealed class _003CSyncLoop_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NetworkManager _003C_003E4__this;

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
		public _003CSyncLoop_003Ed__31(int _003C_003E1__state)
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

	private const float DisconnectTimeout = 4f;

	private const byte MyEventCode = 1;

	[SerializeField]
	private TMP_Text dataUsageText;

	[SerializeField]
	private TMP_Text m_StateText;

	[SerializeField]
	private TMP_Text m_PingText;

	[SerializeField]
	private List<TMP_Text> m_PlayerList;

	[SerializeField]
	private GameObject m_LoadingPanel;

	[SerializeField]
	private TMP_Text m_JoiningPlayerText;

	[SerializeField]
	private float m_MaxWaitTimeForJoiningPlayers;

	private string m_CloudRegion;

	private PhotonPeer photonPeer;

	private long previousBytesIn;

	private long previousBytesOut;

	private float timer;

	private float m_DisconnectTimer;

	private string m_MasterUserId;

	public Action<string> OnSyncRequest;

	public int SyncedSystemCount;

	private int m_TargetSyncSystemCount;

	public List<NetworkPhotonViewOwnerTransporter> NetworkPhotonViewOwnerTransporters;

	private bool m_ReturningToMainMenuFlag;

	private long totalBytes;

	private WaitForSecondsRealtime _waitForSecondsRealtime180;

	private void OnDestroy()
	{
	}

	private void Awake()
	{
	}

	public override void OnDisable()
	{
	}

	private void Update()
	{
	}

	public void SubscribeTransporter(NetworkPhotonViewOwnerTransporter ownerTransporter)
	{
	}

	private void Start()
	{
	}

	private void LateUpdate()
	{
	}

	private void OnDayFinished()
	{
	}

	[IteratorStateMachine(typeof(_003CSyncLoop_003Ed__31))]
	private IEnumerator SyncLoop()
	{
		return null;
	}

	public void SyncObjectPositions()
	{
	}

	private void OnLoadingDone()
	{
	}

	[IteratorStateMachine(typeof(_003CInitialLoadingUIRoutine_003Ed__34))]
	private IEnumerator InitialLoadingUIRoutine()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CInitialLoadingWarningRoutine_003Ed__35))]
	private IEnumerator InitialLoadingWarningRoutine(Player newPlayer)
	{
		return null;
	}

	private string GetPhotonStatus()
	{
		return null;
	}

	private string GetCurrentState()
	{
		return null;
	}

	private void UpdatePlayerList()
	{
	}

	private void SetupNewPlayerVisuals()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void RequestPlayerState(string UserId)
	{
	}

	[PunRPC]
	public void SyncYourself(string newPlayerUserId)
	{
	}

	public override void OnPlayerEnteredRoom(Player newPlayer)
	{
	}

	public override void OnPlayerLeftRoom(Player otherPlayer)
	{
	}
}
