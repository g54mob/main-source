using System;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : NoktaSingleton<PlayerManager>
{
	public PlayerInstance LocalPlayer;

	public List<PlayerInstance> PlayerInstances;

	public List<PlayerInstance> RemotePlayerInstaces;

	public Action<PlayerInstance> OnPlayerConnected;

	public Action<PlayerInstance> OnPlayerDisconnected;

	public Action<PlayerInstance> OnLocalPlayerUpdated;

	public PlayerInput PlayerInput;

	private HashSet<int> m_UsedSkins;

	public PlayerInstance FirstPlayer => null;

	public void OnStartedMovingFurniture_ActionLauncher(PlayerInstance playerInstance, bool value)
	{
	}

	public void SetLocalPlayer(PlayerInstance instance)
	{
	}

	public Player GetNetworkPlayerByNickname(string nickname)
	{
		return null;
	}

	private void Awake()
	{
	}

	public void HandleInputEvents(PlayerInstance newLocalPlayer, PlayerInstance oldLocalPlayer)
	{
	}

	public void SetupNewPlayer(PlayerInstance instance, bool isLocal)
	{
	}

	public bool IsLocalPlayer(PlayerInstance instance)
	{
		return false;
	}

	public void SetRemotePlayer(PlayerInstance instance)
	{
	}

	public PlayerInstance GetUnownedPlayer()
	{
		return null;
	}

	public List<PhotonView> GetAllPhotonViews()
	{
		return null;
	}

	public PlayerInstance GetPlayerInstanceByUserID(string userID)
	{
		return null;
	}

	public Player GetNetworkPlayerByUserID(string userID)
	{
		return null;
	}

	public List<Transform> AllActivePlayerInstances()
	{
		return null;
	}

	private int GetAvailableSkinIndex()
	{
		return 0;
	}

	private void AssignSkin(PlayerInstance instance)
	{
	}

	public void BanPlayer(string userId)
	{
	}

	public void Kick(string userId)
	{
	}
}
