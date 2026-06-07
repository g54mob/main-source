using System.Collections.Generic;
using Epic.OnlineServices.Lobby;

public class EOSLobbyUI : EOSLobby
{
	private string lobbyName;

	private bool showLobbyList;

	private bool showPlayerList;

	private List<LobbyDetails> foundLobbies;

	private List<Attribute> lobbyData;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnCreateLobbySuccess(List<Attribute> attributes)
	{
	}

	private void OnJoinLobbySuccess(List<Attribute> attributes)
	{
	}

	private void OnFindLobbiesSuccess(List<LobbyDetails> lobbiesFound)
	{
	}

	private void OnLeaveLobbySuccess()
	{
	}

	private void OnGUI()
	{
	}

	private void DrawMenuButtons()
	{
	}

	private void DrawLobbyList()
	{
	}

	private void DrawLobbyMenu()
	{
	}
}
