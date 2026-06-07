using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Integration.UnityUI;
using UnityEngine;
using UnityEngine.SceneManagement;
using VampireSurvivors.App.Data;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.Framework
{
	public class MultiplayerManager : IInitializable, IDisposable, ITickable
	{
		public delegate void OnPlayerStateChange(Player p);

		public delegate void OnControllerStateChange(Player p);

		public delegate void OnRefresh();

		[Inject]
		private PlayerOptions _playerOptions;

		[Inject]
		private SignalBus _signalBus;

		[Inject]
		private CoopConfig _coopConfig;

		public int? PartySize;

		public bool PartyModeEnabled;

		private const string POPUP_ID_PREFIX = "ControllerDisconnect-";

		private List<Player> _rewiredPlayersToRemove;

		private Player _previousUIControllingPlayer;

		private static MultiplayerManager s_instance;

		private List<CoopSlotData> _slotsSelections;

		private List<Player> _rewiredPlayersWithSlotsCache;

		private List<Player> _disconnectedPlayers;

		public bool AllowPlayerJoining;

		public bool AllowPlayerRemoval;

		public bool AllowP1Reassign;

		private bool _hasForcedPauseForDisconnect;

		private bool _backButtonListening;

		private RewiredStandaloneInputModule _inputModule;

		private int _selectedPlayerIndex;

		private List<Player> _freeRewiredPlayers;

		public List<Player> RewiredPlayersWithSlots => null;

		public static MultiplayerManager Instance => null;

		public bool IsMultiplayer => false;

		public bool IsLocalMultiplayer => false;

		public bool IsOnlineMultiplayer => false;

		public CoopConfig CoopConfig => null;

		public bool IsAwaitingControllerReconnect => false;

		private RewiredStandaloneInputModule InputModule => null;

		public bool IsUIBeingBlocked => false;

		public List<FollowerData> AICharacters => null;

		public event OnControllerStateChange ControllerDisconnected
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnRefresh RefreshUI
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public bool DoesRewiredPlayerHaveASlot(Player player)
		{
			return false;
		}

		public void Initialize()
		{
		}

		private void ResetSlotSelections()
		{
		}

		public void Dispose()
		{
		}

		public void Tick()
		{
		}

		private void ResetToSinglePlayerMode()
		{
		}

		private void OnPlayerControllerAdded(ControllerAssignmentChangedEventArgs args)
		{
		}

		private void OnPlayerControllerRemoved(ControllerAssignmentChangedEventArgs args)
		{
		}

		public void StartPartyMode(int partySize)
		{
		}

		public void AddDisconnectedPlayer(Player player)
		{
		}

		public void AddPlayerForRemoval(Player p)
		{
		}

		public void ClearAllExtraPlayers()
		{
		}

		public void RemoveDisconnectedPlayer(Player player)
		{
		}

		private void SetInitialPlayers()
		{
		}

		private void StopVibrationOnSceneUnload(Scene s)
		{
		}

		private void StopVibrationOnSceneLoad(Scene s, LoadSceneMode mode)
		{
		}

		public void SetControllerAssignedToPlayer1(bool value)
		{
		}

		public void AddRewiredPlayer(Player p)
		{
		}

		public int FindSlotIndexContainingRewiredPlayer(Player p)
		{
			return 0;
		}

		private int FindNextFreeSlotForARewiredPlayer()
		{
			return 0;
		}

		public void UpdatePlayerControllerColour(Player player, Color color)
		{
		}

		public void ResetPlayerControllerColor(Player player)
		{
		}

		public void RemoveRewiredPlayer(Player p)
		{
		}

		public void DebugResetSystem()
		{
		}

		public void ResetMultiplayerSelections()
		{
		}

		public Color GetSlotColor(int playerSlot)
		{
			return default(Color);
		}

		public bool IsCharacterTypeInGame(CharacterType t)
		{
			return false;
		}

		public int GetPlayerCount()
		{
			return 0;
		}

		public int GetLocalPlayerCount()
		{
			return 0;
		}

		public List<CoopSlotData> GetLocalPlayerSlots()
		{
			return null;
		}

		public CoopSlotData GetSlotInfo(int index)
		{
			return null;
		}

		public Player GetPotentialRewiredPlayer(int slotIndex)
		{
			return null;
		}

		public Player GetCurrentUIPlayer()
		{
			return null;
		}

		public void PlayerControlOverride(Player p)
		{
		}

		public void DisableAllUIInteraction()
		{
		}

		public void EnableAllUIInteraction()
		{
		}

		public void SelectPlayerOneToControlUI(bool exclusiveUIControl = false, bool vibrate = true)
		{
		}

		public void AllowAllPlayersToUseUI()
		{
		}

		public void AddPlayerToUIControl(Player player)
		{
		}

		public Player GetRewiredPlayerOne()
		{
			return null;
		}

		public List<CharacterType> GetCharacterSelections()
		{
			return null;
		}

		public void SelectSlot(int slot)
		{
		}

		public void SelectPlayerToControlUI(Player p, bool exclusiveUIControl = false, bool vibrate = true, float vibrationMS = 200f)
		{
		}

		public void Refresh()
		{
		}

		public void PreviousPlayer(bool exclusiveUIControl = true, bool vibrate = true)
		{
		}

		public Player GetSelectedPlayer()
		{
			return null;
		}

		public int GetSelectedPlayerIndex()
		{
			return 0;
		}

		public List<VampireSurvivors.Objects.Characters.CharacterController> GetAllCharacters()
		{
			return null;
		}

		public Color GetRewiredPlayerColour(Player player)
		{
			return default(Color);
		}

		public Color GetUIControlColour()
		{
			return default(Color);
		}

		public void EnsurePlayableCharacters()
		{
		}
	}
}
