using System.Collections.Generic;
using UnityEngine;

namespace SteamLobbyTutorial
{
	public class PanelSwapper : MonoBehaviour
	{
		public List<Panel> panels = new List<Panel>();

		public GameObject unableToJoinLobbyHolder;

		public void SwapPanel(string panelName)
		{
			unableToJoinLobbyHolder.SetActive(value: true);
			if (panelName == "LobbyPanel")
			{
				GameObject[] objectsToTurnOffWhenJoiningLobby = GetComponent<LobbyUIManager>().objectsToTurnOffWhenJoiningLobby;
				for (int i = 0; i < objectsToTurnOffWhenJoiningLobby.Length; i++)
				{
					objectsToTurnOffWhenJoiningLobby[i].SetActive(value: false);
				}
				objectsToTurnOffWhenJoiningLobby = GetComponent<LobbyUIManager>().objectsToTurnOnWhenJoiningLobby;
				for (int i = 0; i < objectsToTurnOffWhenJoiningLobby.Length; i++)
				{
					objectsToTurnOffWhenJoiningLobby[i].SetActive(value: true);
				}
				GetComponent<LobbyUIManager>().SetLoadingText();
			}
			foreach (Panel panel in panels)
			{
				if (panel.PanelName == panelName)
				{
					panel.gameObject.SetActive(value: true);
				}
				else
				{
					panel.gameObject.SetActive(value: false);
				}
			}
		}
	}
}
