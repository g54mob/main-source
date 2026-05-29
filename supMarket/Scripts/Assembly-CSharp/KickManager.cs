using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

public class KickManager : NoktaSingletonPunCallbacks<KickManager>
{
	private enum QuitType
	{
		Kick = 0,
		Ban = 1
	}

	[CompilerGenerated]
	private sealed class _003CKickSelfRoutine_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public QuitType quitType;

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
		public _003CKickSelfRoutine_003Ed__14(int _003C_003E1__state)
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

	public const byte KickEventCode = 199;

	public List<string> bannedSteamIds;

	public List<string> everybodySteamIds;

	public override void OnEnable()
	{
	}

	public override void OnDisable()
	{
	}

	private void Start()
	{
	}

	public override void OnPlayerEnteredRoom(Player newPlayer)
	{
	}

	public override void OnPlayerLeftRoom(Player otherPlayer)
	{
	}

	[PunRPC]
	public void AddSteamId_Rpc(string steamAccountId, string newPlayerUserId)
	{
	}

	public void KickAndBan(Player target)
	{
	}

	public void Kick(Player target)
	{
	}

	private void SendKickEventToPlayer(Player target, QuitType quitType)
	{
	}

	private void OnEvent(EventData photonEvent)
	{
	}

	[IteratorStateMachine(typeof(_003CKickSelfRoutine_003Ed__14))]
	private IEnumerator KickSelfRoutine(QuitType quitType)
	{
		return null;
	}

	public void AddSteamID_Process(ulong steamAccountId)
	{
	}
}
