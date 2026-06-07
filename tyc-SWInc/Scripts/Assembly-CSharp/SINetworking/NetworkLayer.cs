using System;
using System.Collections.Generic;
using UnityEngine;

namespace SINetworking
{
	public abstract class NetworkLayer : MonoBehaviour
	{
		[NonSerialized]
		public List<NetworkLobby> Lobbies = new List<NetworkLobby>();

		[NonSerialized]
		public NetworkLobby CurrentLobby;

		public static NetworkLayer Active
		{
			get
			{
				NetworkManager instance = NetworkManager.Instance;
				if ((object)instance == null)
				{
					return null;
				}
				return instance.Layer;
			}
		}

		public event EventHandler OnLobbyCreated;

		public event EventHandler<NetworkLobby> OnLobbyJoined;

		public event EventHandler OnLobbyQuery;

		protected virtual void Start()
		{
			if (!NetworkManager.Instance.InitLayer(this))
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
			else
			{
				UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			}
		}

		public abstract void SetLobbyMeta(NetworkLobby lobby, string var, string value);

		public abstract void CreateLobby(NetworkLobby lobby);

		public abstract void CleanPlayer(NetworkPlayer player);

		public abstract void JoinLobby(NetworkLobby lobby);

		public abstract void LeaveLobby();

		public abstract void UpdateNewPlayer(NetworkPlayer player);

		public abstract bool SendData(NetworkPlayer player, byte[] data, bool now);

		public abstract byte[] ReceiveData(out NetworkPlayer from);

		public abstract int GetMaxPacketSize();

		public abstract string Diagnostics(NetworkPlayer player);

		public abstract ValueTuple<string, string> GetNameAndIdentifier();

		public abstract bool IsLobbyValid();

		public abstract Texture2D GetPlayerAvatar(NetworkPlayer player, out bool completed);

		public abstract NetworkPlayer HandleReconnection(NetworkPlayer player, byte id);

		public abstract void UpdatePing(NetworkPlayer player);

		public abstract string GetBanInfo(NetworkPlayer player);

		public abstract string FilterMessage(string message, NetworkPlayer player);

		public abstract string FilterName(string name, NetworkPlayer player);

		public abstract bool FilterName(string name);

		public virtual object TransformConnection(object c)
		{
			return c;
		}

		public virtual void QueryLobbies()
		{
			Lobbies.Clear();
		}

		protected void InvokeLobbyCreated()
		{
			EventHandler eventHandler = this.OnLobbyCreated;
			if (eventHandler != null)
			{
				eventHandler(this, null);
			}
		}

		protected void InvokeLobbyJoined(NetworkLobby lobby)
		{
			CurrentLobby = lobby;
			EventHandler<NetworkLobby> eventHandler = this.OnLobbyJoined;
			if (eventHandler != null)
			{
				eventHandler(this, lobby);
			}
		}

		protected void InvokeLobbyQuery()
		{
			EventHandler eventHandler = this.OnLobbyQuery;
			if (eventHandler != null)
			{
				eventHandler(this, null);
			}
		}

		public abstract string GetLocalConnectionData();

		public abstract bool TryReconnection(NetworkPlayer newHost);

		public abstract void MakeHost();
	}
}
