using System.Collections.Generic;
using DG.Tweening;
using Steamworks;
using UnityEngine;
using UnityEngine.UI;

public class LobbiesListManager : Singleton<LobbiesListManager>
{
	public GameObject lobbyDataItemPrefab;

	public GameObject lobbyListContect;

	public Button lobbiesButton;

	public Button hostButton;

	public Button refreshButton;

	public List<GameObject> listOfLobbies = new List<GameObject>();

	public CanvasGroup lobbyPanel;

	public HashSet<ulong> currentLobbyIDs = new HashSet<ulong>();

	private void Start()
	{
		lobbiesButton.onClick.AddListener(GetListOfLobbies);
		refreshButton.onClick.AddListener(RefreshLobbies);
	}

	public void GetListOfLobbies()
	{
		lobbyPanel.DOKill();
		lobbyPanel.DOFade(1f, 0.2f).OnComplete(delegate
		{
			lobbyPanel.blocksRaycasts = true;
			lobbyPanel.interactable = true;
		});
		DestroyLobbies();
		Singleton<SteamLobby>.Instance.GetLobbiesList();
	}

	public void RefreshLobbies()
	{
		DestroyLobbies();
		Singleton<SteamLobby>.Instance.GetLobbiesList();
	}

	public void DisplayLobbies(List<CSteamID> lobbyIDs, LobbyDataUpdate_t result)
	{
		for (int i = 0; i < lobbyIDs.Count; i++)
		{
			if (lobbyIDs[i].m_SteamID == result.m_ulSteamIDLobby && !currentLobbyIDs.Contains(lobbyIDs[i].m_SteamID))
			{
				GameObject gameObject = Object.Instantiate(lobbyDataItemPrefab, lobbyListContect.transform);
				LobbyListItem component = gameObject.GetComponent<LobbyListItem>();
				component.lobbyID = (CSteamID)lobbyIDs[i].m_SteamID;
				component.lobbyName = SteamMatchmaking.GetLobbyData((CSteamID)lobbyIDs[i].m_SteamID, "name");
				component.SetLobby();
				component.transform.SetParent(lobbyListContect.transform);
				component.transform.localScale = Vector3.one;
				component.transform.SetAsFirstSibling();
				listOfLobbies.Add(gameObject);
				currentLobbyIDs.Add(lobbyIDs[i].m_SteamID);
			}
		}
	}

	public void DestroyLobbies()
	{
		foreach (GameObject listOfLobby in listOfLobbies)
		{
			if (listOfLobby != null)
			{
				Object.Destroy(listOfLobby);
			}
		}
		listOfLobbies.Clear();
		currentLobbyIDs.Clear();
	}
}
