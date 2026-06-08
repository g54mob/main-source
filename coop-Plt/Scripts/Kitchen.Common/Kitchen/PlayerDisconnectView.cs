using System.Collections.Generic;
using Controllers;
using KitchenData;
using TMPro;
using UnityEngine;

namespace Kitchen
{
	public class PlayerDisconnectView : MonoBehaviour
	{
		public int MissingPlayer;

		public InputLock.Lock GlobalLock;

		public GameObject Container;

		public Renderer Panel;

		public TextMeshPro Text;

		private List<int> DisconnectedPlayers = new List<int>();

		private static readonly int Highlight = Shader.PropertyToID("_Highlight");

		[SerializeField]
		private SwapOutDefaultButtonPrompt PromptSwapper;

		private ControllerIcons Icons => GameData.Main.GlobalLocalisation.ControllerIcons;

		public bool IsActive => MissingPlayer != 0;

		private MemoryManagerHandle MemoryManagerHandle => this;

		private void OnDestroy()
		{
			MemoryManagerHandle.Dispose();
		}

		private void Update()
		{
			if (InputSourceIdentifier.DefaultInputSource == null)
			{
				return;
			}
			if (!IsActive)
			{
				InputSourceIdentifier.DefaultInputSource.DisconnectedPlayers(DisconnectedPlayers);
				{
					foreach (int disconnectedPlayer in DisconnectedPlayers)
					{
						if (Players.Main.Has(disconnectedPlayer))
						{
							CreateForPlayer(disconnectedPlayer);
							break;
						}
					}
					return;
				}
			}
			if (!InputSourceIdentifier.DefaultInputSource.IsPlayerDisconnected(MissingPlayer))
			{
				Clear();
			}
			else if (InputSourceIdentifier.DefaultInputSource.AnyPlayerPressingMenu())
			{
				InputSourceIdentifier.DefaultInputSource.MakeRequest(MissingPlayer, GameStateRequest.Disconnect);
				Clear();
			}
		}

		private void CreateForPlayer(int player)
		{
			Text.text = GameData.Main.GlobalLocalisation.GetPlatformPrompt("DISCONNECTION_PROMPT");
			PlayerInfo playerInfo = Players.Main.Get(player);
			MemoryManagerHandle.Register(Panel.material).SetColor(Highlight, playerInfo.Profile.Colour);
			Container.SetActive(value: true);
			MissingPlayer = player;
			if (InputSourceIdentifier.DefaultInputSource != null)
			{
				InputSourceIdentifier.DefaultInputSource.MakeRequest(player, GameStateRequest.InLocalMenu);
				GlobalLock = InputSourceIdentifier.DefaultInputSource.SetLock(PlayerLockState.PauseAndLockMenu);
			}
		}

		private void Clear()
		{
			Container.SetActive(value: false);
			if (InputSourceIdentifier.DefaultInputSource != null)
			{
				InputSourceIdentifier.DefaultInputSource.ReleaseLock(GlobalLock);
			}
			MissingPlayer = 0;
		}
	}
}
