using System;
using System.Runtime.InteropServices;
using Dissonance;
using Mirror;
using Mirror.RemoteCalls;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SteamLobbyTutorial
{
	public class PlayerLobbyHandler : NetworkBehaviour
	{
		[SyncVar(hook = "OnReadyStatusChanged")]
		public bool isReady;

		public Button readyButton;

		public TextMeshProUGUI nameText;

		public GameObject readyTick;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_isReady;

		public bool NetworkisReady
		{
			get
			{
				return isReady;
			}
			[param: In]
			set
			{
				GeneratedSyncVarSetter(value, ref isReady, 1uL, _Mirror_SyncVarHookDelegate_isReady);
			}
		}

		private void Start()
		{
			if (NetworkServer.active)
			{
				LobbyUIManager.Instance?.Invoke("CheckAllPlayersReady", 0.5f);
			}
			readyButton.interactable = base.isLocalPlayer;
			UnityEngine.Object.FindObjectOfType<DissonanceComms>().LocalPlayerName = SteamFriends.GetPersonaName();
		}

		public override void OnStartLocalPlayer()
		{
			base.OnStartLocalPlayer();
			readyButton.interactable = true;
			NetworkisReady = false;
		}

		public override void OnStartClient()
		{
			base.OnStartClient();
			LobbyUIManager.Instance.RegisterPlayer(this);
		}

		[Command]
		private void CmdSetReady()
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			SendCommandInternal("System.Void SteamLobbyTutorial.PlayerLobbyHandler::CmdSetReady()", 682044391, writer, 0);
			NetworkWriterPool.Return(writer);
		}

		public void OnReadyButtonClicked()
		{
			CmdSetReady();
		}

		private void SetSelectedButtonColor(Color color)
		{
		}

		private void OnReadyStatusChanged(bool oldValue, bool newValue)
		{
			if (NetworkServer.active)
			{
				LobbyUIManager.Instance?.CheckAllPlayersReady();
			}
			if (isReady)
			{
				readyTick.SetActive(value: true);
			}
			else
			{
				readyTick.SetActive(value: false);
			}
		}

		public PlayerLobbyHandler()
		{
			_Mirror_SyncVarHookDelegate_isReady = OnReadyStatusChanged;
		}

		public override bool Weaved()
		{
			return true;
		}

		protected void UserCode_CmdSetReady()
		{
			NetworkisReady = !isReady;
			OnReadyStatusChanged(!isReady, isReady);
		}

		protected static void InvokeUserCode_CmdSetReady(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkServer.active)
			{
				Debug.LogError("Command CmdSetReady called on client.");
			}
			else
			{
				((PlayerLobbyHandler)obj).UserCode_CmdSetReady();
			}
		}

		static PlayerLobbyHandler()
		{
			RemoteProcedureCalls.RegisterCommand(typeof(PlayerLobbyHandler), "System.Void SteamLobbyTutorial.PlayerLobbyHandler::CmdSetReady()", InvokeUserCode_CmdSetReady, requiresAuthority: true);
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
			base.SerializeSyncVars(writer, forceAll);
			if (forceAll)
			{
				writer.WriteBool(isReady);
				return;
			}
			writer.WriteVarULong(syncVarDirtyBits);
			if ((syncVarDirtyBits & 1L) != 0L)
			{
				writer.WriteBool(isReady);
			}
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
			base.DeserializeSyncVars(reader, initialState);
			if (initialState)
			{
				GeneratedSyncVarDeserialize(ref isReady, _Mirror_SyncVarHookDelegate_isReady, reader.ReadBool());
				return;
			}
			long num = (long)reader.ReadVarULong();
			if ((num & 1L) != 0L)
			{
				GeneratedSyncVarDeserialize(ref isReady, _Mirror_SyncVarHookDelegate_isReady, reader.ReadBool());
			}
		}
	}
}
