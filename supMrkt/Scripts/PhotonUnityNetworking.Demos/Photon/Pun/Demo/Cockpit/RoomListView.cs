using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Photon.Realtime;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
	public class RoomListView : MonoBehaviourPunCallbacks
	{
		[Serializable]
		public class OnJoinRoomEvent : UnityEvent<string>
		{
		}

		[CompilerGenerated]
		private sealed class _003CclearStatus_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RoomListView _003C_003E4__this;

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
			public _003CclearStatus_003Ed__12(int _003C_003E1__state)
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

		public OnJoinRoomEvent OnJoinRoom;

		public RoomListCell CellPrototype;

		public Text UpdateStatusText;

		public Text ContentFeedback;

		public InputField LobbyNameInputField;

		public InputField SqlQueryInputField;

		private bool _firstUpdate;

		private Dictionary<string, RoomListCell> roomCellList;

		public override void OnEnable()
		{
		}

		public void OnRoomCellJoinButtonClick(string roomName)
		{
		}

		public override void OnRoomListUpdate(List<RoomInfo> roomList)
		{
		}

		[IteratorStateMachine(typeof(_003CclearStatus_003Ed__12))]
		private IEnumerator clearStatus()
		{
			return null;
		}

		public void OnJoinedLobbyCallBack()
		{
		}

		public void GetRoomList()
		{
		}

		public void ResetList()
		{
		}
	}
}
