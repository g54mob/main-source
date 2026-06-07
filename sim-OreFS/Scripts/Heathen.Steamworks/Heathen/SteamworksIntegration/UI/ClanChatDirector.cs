using Heathen.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;

namespace Heathen.SteamworksIntegration.UI
{
	[HelpURL("https://kb.heathen.group/assets/steamworks/unity-engine/ui-components/clan-chat-director")]
	public class ClanChatDirector : MonoBehaviour
	{
		[Header("Events")]
		public GameConnectedChatJoinEvent evtJoin;

		public GameConnectedClanChatMsgEvent evtReceived;

		public GameConnectedChatLeaveEvent evtLeave;

		private ChatRoom? chatRoom;

		public UserData[] Members
		{
			get
			{
				if (InRoom)
				{
					return chatRoom.Value.Members;
				}
				return new UserData[0];
			}
		}

		public bool IsOpenInSteam
		{
			get
			{
				if (InRoom)
				{
					return chatRoom.Value.IsOpenInSteam;
				}
				return false;
			}
		}

		public bool InRoom
		{
			get
			{
				if (chatRoom.HasValue)
				{
					return chatRoom.Value.enterResponse == EChatRoomEnterResponse.k_EChatRoomEnterResponseSuccess;
				}
				return false;
			}
		}

		public ChatRoom ChatRoom
		{
			get
			{
				if (!chatRoom.HasValue)
				{
					return default(ChatRoom);
				}
				return chatRoom.Value;
			}
		}

		private void OnEnable()
		{
			Clans.Client.EventChatMessageReceived.AddListener(HandleNewMessage);
			Clans.Client.EventGameConnectedChatJoin.AddListener(HandleJoined);
			Clans.Client.EventGameConnectedChatLeave.AddListener(HandleLeave);
		}

		private void OnDisable()
		{
			Clans.Client.EventChatMessageReceived.RemoveListener(HandleNewMessage);
			Clans.Client.EventGameConnectedChatJoin.RemoveListener(HandleJoined);
			Clans.Client.EventGameConnectedChatLeave.RemoveListener(HandleLeave);
		}

		public void Join(ClanData clan)
		{
			Clans.Client.JoinChatRoom(clan, delegate(ChatRoom result, bool error)
			{
				if (!error)
				{
					chatRoom = result;
				}
				else
				{
					Debug.LogWarning("Steam client responded with an IO error when attempting to join Clan chat for " + clan);
				}
			});
		}

		public void Leave()
		{
			if (InRoom)
			{
				chatRoom.Value.Leave();
				chatRoom = null;
			}
		}

		public void Send(string message)
		{
			if (InRoom)
			{
				chatRoom.Value.SendMessage(message);
			}
		}

		public void OpenInSteam()
		{
			if (InRoom)
			{
				chatRoom.Value.OpenChatWindowInSteam();
			}
		}

		private void HandleLeave(UserLeaveData arg0)
		{
			if (InRoom && arg0.room.id == chatRoom.Value.id)
			{
				evtLeave.Invoke(arg0);
			}
		}

		private void HandleJoined(ChatRoom arg0, UserData arg1)
		{
			if (InRoom && arg0.id == chatRoom.Value.id)
			{
				evtJoin.Invoke(arg0, arg1);
			}
		}

		private void HandleNewMessage(ClanChatMsg arg0)
		{
			if (InRoom && arg0.room.id == chatRoom.Value.id)
			{
				evtReceived.Invoke(arg0);
			}
		}
	}
}
