using System;
using System.Text;
using HeathenEngineering.SteamworksIntegration.API;
using UnityEngine;

namespace HeathenEngineering.SteamworksIntegration.UI
{
	[Obsolete("Features merged into LobbyManager")]
	[HelpURL("https://kb.heathen.group/assets/steamworks/unity-engine/ui-components/lobby-chat-director")]
	[RequireComponent(typeof(LobbyManager))]
	public class LobbyChatDirector : MonoBehaviour
	{
		private LobbyManager manager;

		public LobbyChatMsgEvent evtMessageRecieved;

		public bool HasLobby
		{
			get
			{
				if (manager != null)
				{
					return manager.HasLobby;
				}
				return false;
			}
		}

		public bool Send(string message)
		{
			return manager.Lobby.SendChatMessage(message);
		}

		public bool Send(byte[] data)
		{
			return manager.Lobby.SendChatMessage(data);
		}

		public bool Send(object jsonObject)
		{
			return Send(Encoding.UTF8.GetBytes(JsonUtility.ToJson(jsonObject)));
		}

		public void SendString(string message)
		{
			Send(message);
		}

		private void Awake()
		{
			manager = GetComponent<LobbyManager>();
		}

		private void Start()
		{
			Matchmaking.Client.EventLobbyChatMsg.AddListener(HandleChatMessage);
		}

		private void HandleChatMessage(LobbyChatMsg message)
		{
			if (message.lobby == manager.Lobby)
			{
				evtMessageRecieved.Invoke(message);
			}
		}
	}
}
