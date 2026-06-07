using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
	public class PlayerListView : MonoBehaviourPunCallbacks
	{
		[CompilerGenerated]
		private sealed class _003CUpdateUIPing_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerListView _003C_003E4__this;

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
			public _003CUpdateUIPing_003Ed__13(int _003C_003E1__state)
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

		public PlayerDetailsController PlayerDetailManager;

		public PlayerListCell CellPrototype;

		public Text PlayerCountsText;

		public Text UpdateStatusText;

		private Dictionary<int, PlayerListCell> playerCellList;

		private void Awake()
		{
		}

		public override void OnEnable()
		{
		}

		public void SelectPlayer(Player player)
		{
		}

		public override void OnPlayerEnteredRoom(Player newPlayer)
		{
		}

		public override void OnMasterClientSwitched(Player newMasterClient)
		{
		}

		public override void OnPlayerPropertiesUpdate(Player target, ExitGames.Client.Photon.Hashtable changedProps)
		{
		}

		public override void OnPlayerLeftRoom(Player otherPlayer)
		{
		}

		private void RefreshCount()
		{
		}

		[IteratorStateMachine(typeof(_003CUpdateUIPing_003Ed__13))]
		private IEnumerator UpdateUIPing()
		{
			return null;
		}

		public void ResetList()
		{
		}
	}
}
