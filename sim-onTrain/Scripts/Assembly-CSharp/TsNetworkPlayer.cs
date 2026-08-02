using System;
using System.Collections;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using Steamworks;
using UnityEngine;

public class TsNetworkPlayer : NetworkBehaviour
{
	[SyncVar]
	public string playerName;

	public string NetworkplayerName
	{
		get
		{
			return playerName;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref playerName, 1uL, null);
		}
	}

	public override void OnStartServer()
	{
		NetworkplayerName = (string)base.connectionToClient.authenticationData;
		if (string.IsNullOrEmpty(playerName))
		{
			NetworkplayerName = "Player_" + base.connectionToClient.connectionId;
		}
		Debug.Log("TsNetworkPlayer.OnStartServer: playerName = " + playerName);
		NotifyTrainBuildManager();
	}

	[Command]
	private void CmdSetPlayerName(string newName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(newName);
		SendCommandInternal("System.Void TsNetworkPlayer::CmdSetPlayerName(System.String)", 1201608609, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public override void OnStartLocalPlayer()
	{
		string text = "";
		try
		{
			if (SteamManager.Initialized)
			{
				text = SteamFriends.GetPersonaName();
			}
		}
		catch (Exception ex)
		{
			Debug.LogWarning("Steam nickname alınamadı: " + ex.Message);
		}
		if (string.IsNullOrEmpty(text))
		{
			text = "Player";
		}
		CmdSetPlayerName(text);
		ChatUI.localPlayerName = text;
		ChatPanelController.localPlayerName = text;
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		if (!base.isServer)
		{
			StartCoroutine(NotifyTrainBuildManagerAfterDelay());
		}
	}

	private void NotifyTrainBuildManager()
	{
		if (base.isServer)
		{
			StartCoroutine(NotifyAfterSceneLoaded());
		}
	}

	private IEnumerator NotifyAfterSceneLoaded()
	{
		yield return new WaitForSeconds(1f);
		TrainBuildManager instance = TrainBuildManager.Instance;
		if (instance != null)
		{
			TSPlayerController component = GetComponent<TSPlayerController>();
			if (component != null)
			{
				instance.OnPlayerConnected(component);
				Debug.Log("Server: Oyuncu " + playerName + " TrainBuildManager'a bildirildi");
			}
		}
	}

	private IEnumerator NotifyTrainBuildManagerAfterDelay()
	{
		yield return new WaitForSeconds(2f);
		TrainBuildManager instance = TrainBuildManager.Instance;
		if (instance != null)
		{
			instance.CmdNotifyPlayerConnected();
			Debug.Log("Client: Oyuncu " + playerName + " bağlantı bildirimi gönderildi");
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdSetPlayerName__String(string newName)
	{
		if (!string.IsNullOrEmpty(newName))
		{
			NetworkplayerName = newName;
			Debug.Log("Player name updated to: " + playerName);
		}
	}

	protected static void InvokeUserCode_CmdSetPlayerName__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetPlayerName called on client.");
		}
		else
		{
			((TsNetworkPlayer)obj).UserCode_CmdSetPlayerName__String(reader.ReadString());
		}
	}

	static TsNetworkPlayer()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(TsNetworkPlayer), "System.Void TsNetworkPlayer::CmdSetPlayerName(System.String)", InvokeUserCode_CmdSetPlayerName__String, requiresAuthority: true);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteString(playerName);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteString(playerName);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref playerName, null, reader.ReadString());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref playerName, null, reader.ReadString());
		}
	}
}
