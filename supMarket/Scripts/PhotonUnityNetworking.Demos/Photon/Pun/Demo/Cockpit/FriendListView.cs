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
	public class FriendListView : MonoBehaviourPunCallbacks
	{
		[Serializable]
		public class FriendDetail
		{
			public string NickName;

			public string UserId;

			public FriendDetail(string NickName, string UserId)
			{
			}
		}

		[Serializable]
		public class OnJoinRoomEvent : UnityEvent<string>
		{
		}

		[CompilerGenerated]
		private sealed class _003CUpdateUIPing_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FriendListView _003C_003E4__this;

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
			public _003CUpdateUIPing_003Ed__15(int _003C_003E1__state)
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

		public FriendListCell CellPrototype;

		public Text ContentFeedback;

		public Text UpdateStatusText;

		public OnJoinRoomEvent OnJoinRoom;

		private Dictionary<string, FriendListCell> FriendCellList;

		private string[] FriendsLUT;

		private void Awake()
		{
		}

		public override void OnEnable()
		{
		}

		public void SetFriendDetails(FriendDetail[] friendList)
		{
		}

		public void FindFriends()
		{
		}

		public override void OnFriendListUpdate(List<FriendInfo> friendList)
		{
		}

		public void OnRoomListUpdateCallBack(List<RoomInfo> roomList)
		{
		}

		public void JoinFriendRoom(string RoomName)
		{
		}

		[IteratorStateMachine(typeof(_003CUpdateUIPing_003Ed__15))]
		private IEnumerator UpdateUIPing()
		{
			return null;
		}

		public void ResetList()
		{
		}
	}
}
