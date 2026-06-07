using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Toolkit;
using Coherence.Toolkit.Bindings;
using Coherence.Toolkit.ReplicationServer;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using Zenject;

namespace VampireSurvivors
{
	public class OnlineStageManager : MonoBehaviour
	{
		private class GlimmerQueueEntry
		{
			public CoherenceSync Player;

			public bool IsActiveEquipment;

			public int WeaponIndex;

			public GlimmerQueueEntry(CoherenceSync player, bool isActiveEquipment, int weaponIndex)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CIterateSeats_003Ed__77 : IEnumerable<PlayerInfo>, IEnumerable, IEnumerator<PlayerInfo>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private PlayerInfo _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public OnlineStageManager _003C_003E4__this;

			PlayerInfo IEnumerator<PlayerInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CIterateSeats_003Ed__77(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<PlayerInfo> IEnumerable<PlayerInfo>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003C_WaitToStartOnline_003Ed__94 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public OnlineStageManager _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003C_WaitToStartOnline_003Ed__94(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public Action<int, PlayerInfo> OnSeatAssigned;

		public Action OnBecomeAuthority;

		[NonSerialized]
		[Sync]
		[OnValueSynced("OnSeatAssignedRemotely")]
		public uint _firstSeat;

		[NonSerialized]
		[Sync]
		[OnValueSynced("OnSeatAssignedRemotely")]
		public uint _secondSeat;

		[NonSerialized]
		[Sync]
		[OnValueSynced("OnSeatAssignedRemotely")]
		public uint _thirdSeat;

		[NonSerialized]
		[Sync]
		[OnValueSynced("OnSeatAssignedRemotely")]
		public uint _fourthSeat;

		private CoherenceSync _sync;

		private bool _signalledGameStart;

		private bool _signalledInitializeGameSession;

		private bool _signalledInitStage;

		private bool _isResumingGame;

		private Coherence.Log.Logger _logger;

		private IReplicationServer _replicationServer;

		private List<byte[]> _powerUpChunks;

		private Unity.Mathematics.Random _minorArcanasRng;

		private Unity.Mathematics.Random _survarotsRng;

		private Unity.Mathematics.Random _uiPageRng;

		private SignalBus _signalBus;

		private long _lastCalculatedSimulationFrame;

		private bool _sentOpenTerrace;

		private static OnlineStageManager _instance;

		private bool _sentPauseRequest;

		public static OnlineStageManager Instance => null;

		public bool IsHost => false;

		public CoherenceSync Sync => null;

		public int NumberOfConnectedPlayers => 0;

		public List<WeaponType> ChosenLevelUpWeapons { get; private set; }

		public List<ItemType> ChosenLevelUpItems { get; private set; }

		public List<VampireSurvivors.Objects.Characters.CharacterController> ChosenAmuletTargets { get; private set; }

		public List<WeightedLimitBreak> ChosenLimitBreaks { get; private set; }

		public bool ListenForHostDisconnection { get; set; }

		[Sync(DefaultSyncMode = SyncMode.CreationOnly)]
		public uint RandomEventsSeed { get; set; }

		[Sync(DefaultSyncMode = SyncMode.CreationOnly)]
		public uint MinorArcanasSeed { get; set; }

		[Sync(DefaultSyncMode = SyncMode.CreationOnly)]
		public uint SurvarotsSeed { get; set; }

		[Sync(DefaultSyncMode = SyncMode.CreationOnly)]
		public uint UiPageSeed { get; set; }

		public Unity.Mathematics.Random MinorArcanasRng => default(Unity.Mathematics.Random);

		public Unity.Mathematics.Random SurvarotsRng => default(Unity.Mathematics.Random);

		[Sync]
		public int StageEventSpawned
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Sync]
		public bool ControlTimeScale
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Inject]
		private void Construct(SignalBus signalBus)
		{
		}

		public int NextUiPageInt()
		{
			return 0;
		}

		[IteratorStateMachine(typeof(_003CIterateSeats_003Ed__77))]
		public IEnumerable<PlayerInfo> IterateSeats()
		{
			return null;
		}

		public static bool IsHostInTheGame()
		{
			return false;
		}

		public List<VampireSurvivors.Objects.Characters.CharacterController> GetPlayerCharacters()
		{
			return null;
		}

		public int GetSeatNumberForCharacter(VampireSurvivors.Objects.Characters.CharacterController characterController)
		{
			return 0;
		}

		public PlayerInfo GetPlayerInfoForCharacter(VampireSurvivors.Objects.Characters.CharacterController characterController)
		{
			return null;
		}

		public VampireSurvivors.Objects.Characters.CharacterController GetCharacterForSeatNumber(int seatNumber)
		{
			return null;
		}

		public List<CharacterType> GetCharacterSelections()
		{
			return null;
		}

		public List<VampireSurvivors.Objects.Characters.CharacterController> GetOrderedCharacterControllers()
		{
			return null;
		}

		public int GetMySeatNumber()
		{
			return 0;
		}

		public PlayerInfo GetMyPlayerInfo()
		{
			return null;
		}

		public PlayerInfo GetHostPlayerInfo()
		{
			return null;
		}

		public int GetHighestAverageLatencyMs()
		{
			return 0;
		}

		public long GetStartingOnlineClientFrame()
		{
			return 0L;
		}

		public bool IsHostClientConnection(CoherenceClientConnection clientConn)
		{
			return false;
		}

		public void InjectDeps(IReplicationServer replicationServer)
		{
		}

		public bool AreAllPlayersInsideGameplayUi(int uiPageId)
		{
			return false;
		}

		public void SendLoadGameplayScene()
		{
		}

		[IteratorStateMachine(typeof(_003C_WaitToStartOnline_003Ed__94))]
		private IEnumerator _WaitToStartOnline()
		{
			return null;
		}

		[Command]
		public void ReloadCurrentScene()
		{
		}

		[Command]
		public void LockOnlineUI()
		{
		}

		[Command]
		public void LoadGameplayScene()
		{
		}

		[Command]
		public void InitializeGameSession(long startingSimulationFrame)
		{
		}

		[Command]
		public void InitializeStageLogic(long startingSimulationFrame)
		{
		}

		[Command]
		public void StartGameplay(long startingSimulationFrame)
		{
		}

		private void SubscribeToSignals()
		{
		}

		public void SendOpenTreasureCommand()
		{
		}

		[Command]
		public void OpenTreasure(long startingSimFrame)
		{
		}

		public void SendClaimTreasureRequestCommand()
		{
		}

		[Command]
		public void ClaimTreasureRequest()
		{
		}

		public void SendClaimTreasureCommand()
		{
		}

		[Command(defaultRouting = MessageTarget.AuthorityOnly)]
		public void ClaimTreasure(long startingSimFrame)
		{
		}

		public void SendOnlineLevelUpCommand(bool shouldSwapToLevelUpUi, bool adjustXpFactors, List<WeaponType> chosenWeapons, List<ItemType> chosenItems, List<VampireSurvivors.Objects.Characters.CharacterController> amuletTargets, List<WeightedLimitBreak> limitBreaks)
		{
		}

		private static List<(string, object)> BuildLevelUpLogArgs(OnlineLevelUpData levelUpData)
		{
			return null;
		}

		[Command]
		public void OnlineLevelUp(long startingSimFrame, bool shouldSwapToLevelUpUi, bool adjustXpFactors, CoherenceSync activeCharacter, byte[] chosenWeapons, byte[] chosenItems, bool hasAmuletTargets, byte[] limitBreaks)
		{
		}

		public void ProcessOnlineLevelUpData(OnlineLevelUpData levelUpData)
		{
		}

		public void SendLevelUpWithoutScreen()
		{
		}

		[Command]
		public void LevelUpWithoutScreen(long startingSimFrame)
		{
		}

		public void SendFinishLevelUpCommand(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		[Command]
		public void FinishLevelUp(long startingSimFrame, int weaponType, CoherenceSync receivingCharacter)
		{
		}

		public void SendFinishLevelUpWithItemCommand(ItemType itemType, VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		[Command]
		public void FinishLevelUpWithItem(long startingSimFrame, int itemType, CoherenceSync receivingCharacter)
		{
		}

		public void SendFinishLevelupWithFriendshipAmuletCommand()
		{
		}

		[Command]
		public void FinishLevelUpWithFriendshipAmulet(long startingSimFrame)
		{
		}

		public void SendFinishLevelUpWithLimitBreak(int limitBreakIndex, bool alwaysRandomLimitBreak, VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		[Command]
		public void FinishLevelUpWithLimitBreak(long startingSimFrame, int limitBreakIndex, bool alwaysRandomLimitBreak, CoherenceSync receivingCharacter)
		{
		}

		public void SendBanishWeaponCommand(WeaponType weaponType)
		{
		}

		[Command]
		public void BanishWeaponOnline(long startingSimFrame, int weaponType)
		{
		}

		public void SendRequestLevelUpReRoll()
		{
		}

		[Command(defaultRouting = MessageTarget.AuthorityOnly)]
		public void RequestLevelUpReRoll()
		{
		}

		public void SendLevelUpReRollOnline(List<WeaponType> chosenWeapons)
		{
		}

		[Command]
		public void LevelUpReRollOnline(byte[] chosenWeapons)
		{
		}

		public void SendLevelUpSkipOnline()
		{
		}

		[Command]
		public void LevelUpSkipOnline(long startingSimFrame)
		{
		}

		public void SendRequestLevelUpPassOnline()
		{
		}

		[Command(defaultRouting = MessageTarget.AuthorityOnly)]
		public void RequestLevelUpPassOnline()
		{
		}

		public void SendLevelUpPassOnline(VampireSurvivors.Objects.Characters.CharacterController activePlayer, bool showStats)
		{
		}

		[Command]
		public void LevelUpPassOnline(CoherenceSync activePlayer, bool showStats)
		{
		}

		public void StartFriendshipAmulet()
		{
		}

		[Command(defaultRouting = MessageTarget.AuthorityOnly)]
		public void RequestFriendshipAmulet()
		{
		}

		public void SendFriendshipAmuletLevelUpWeaponForCharacter(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		[Command]
		public void FriendshipAmuletLevelUpWeaponForCharacter(long simFrame, int weaponType, CoherenceSync player)
		{
		}

		public void SendMerchantPurchase(WeaponType weapon, ItemType item, int index, int price, VampireSurvivors.Objects.Characters.CharacterController purchasingPlayer)
		{
		}

		[Command]
		public void MerchantPurchase(long simFrame, int weaponType, int itemType, int index, int price, CoherenceSync player)
		{
		}

		public void SendCloseMerchant()
		{
		}

		[Command]
		public void CloseMerchant(long simFrame)
		{
		}

		public void SendCloseItemFoundPage(bool discard)
		{
		}

		[Command]
		public void CloseItemFoundPage(long startingSimFrame, bool discard)
		{
		}

		public void SendSelectArcana(ArcanaType arcanaType)
		{
		}

		[Command]
		public void SelectArcana(long startingSimFrame, int selectedArcana)
		{
		}

		public void SendSelectCharacterCard(ArcanaType arcanaType, SkillCardEdition edition, ArcanaType? subCardType)
		{
		}

		[Command]
		public void SelectCharacterCard(long startingSimFrame, int selectedArcana, int edition, int subCardType)
		{
		}

		public void SendReRollMinorArcanas()
		{
		}

		[Command]
		public void ReRollMinorArcanas()
		{
		}

		public void SendReRollCharacterCards()
		{
		}

		[Command]
		public void ReRollCharacterCards()
		{
		}

		public void SendBoosterSurvarots()
		{
		}

		[Command]
		public void BoosterSurvarots()
		{
		}

		public void SendSkipMinorArcanas()
		{
		}

		[Command]
		public void SkipMinorArcanas(long startingSimFrame)
		{
		}

		public void SendSkipSurvarots()
		{
		}

		[Command]
		public void SkipSurvarots(long startingSimFrame)
		{
		}

		public void SendSkipTreasureAnimation()
		{
		}

		[Command]
		public void SkipTreasureAnimation(long startingSimFrame)
		{
		}

		public void SendTpWeaponSkip()
		{
		}

		[Command]
		public void TpWeaponSkip(long startingSimFrame)
		{
		}

		public void SendTpWeaponSelection(WeaponType weapon)
		{
		}

		[Command]
		public void SelectTpWeapon(long startingSimFrame, int weaponType)
		{
		}

		public void SendCandyBoxWeaponSelection(WeaponType weapon)
		{
		}

		[Command]
		public void SelectWeaponFromCandyBox(long startingSimFrame, int weaponType)
		{
		}

		public void SendCandyBoxSkip()
		{
		}

		public void SendLevelUpBonusSelection(PowerUpType levelUpBonus)
		{
		}

		[Command]
		public void LevelUpBonusSelection(long startingSimFrame, int powerUpBonus)
		{
		}

		[Command]
		public void CandyBoxSkip(long startingSimFrame)
		{
		}

		public void SendLevelBonusSelectionSkip()
		{
		}

		[Command]
		public void LevelBonusSelectionSkip(long startingSimFrame)
		{
		}

		public void SendOpenPiano(VampireSurvivors.Objects.Characters.CharacterController nearestPlayer)
		{
		}

		[Command]
		public void OpenPiano(long startingSimFrame, CoherenceSync nearestPlayer)
		{
		}

		public void SendSuccessfulPiano()
		{
		}

		[Command]
		public void SuccessfulPiano(long startingSimFrame)
		{
		}

		public void SendExitPiano()
		{
		}

		[Command]
		public void ExitPiano(long startingSimFrame)
		{
		}

		public void SendRightCoffinOpened()
		{
		}

		[Command]
		public void RightCoffinOpened(long startingSimFrame)
		{
		}

		public void SendTouchedPianoKey(int key)
		{
		}

		[Command]
		public void TouchedPianoKey(int touchedPianoKey)
		{
		}

		public void SendRevealCharacter()
		{
		}

		[Command]
		public void RevealCharacter()
		{
		}

		public void SendCollectCharacter()
		{
		}

		[Command]
		public void CollectCharacter(long startingSimFrame)
		{
		}

		public void SendSelectDirecterTooEasy()
		{
		}

		[Command]
		public void SelectDirecterTooEasy(long startingSimFrame)
		{
		}

		public void SendSelectDirecterTooHard()
		{
		}

		[Command]
		public void SelectDirecterTooHard(long startingSimFrame)
		{
		}

		public void SendSelectDirecterOkButton()
		{
		}

		[Command]
		public void SelectDirecterOkButton(long startingSimFrame)
		{
		}

		public void SendSetMadMoonSymbols(string serializedSymbols)
		{
		}

		[Command]
		public void SetMadMoonSymbols(string serializedSymbols, long startingSimFrame)
		{
		}

		public void SendDirecterStageSwitch(int newStage)
		{
		}

		[Command]
		public void DirecterStageSwitch(long startingSimFrame, int newStage)
		{
		}

		public void SendEnterTheBossi()
		{
		}

		[Command]
		public void EnterTheBossi(long startingSimFrame)
		{
		}

		public void SendWestwoodsSpin()
		{
		}

		[Command]
		public void WestwoodsSpin(long startingSimFrame, int seed)
		{
		}

		public void SendPauseRequest(VampireSurvivors.Objects.Characters.CharacterController pausingPlayer)
		{
		}

		[Command(defaultRouting = MessageTarget.AuthorityOnly)]
		public void PauseRequest(CoherenceSync pausingPlayer)
		{
		}

		[Command]
		public void GenericPause(long startingSimFrame, CoherenceSync pausingPlayer)
		{
		}

		public void SendFreezeMyPlayer(bool freeze)
		{
		}

		[Command]
		public void FreezePlayer(long startingSimFrame, bool freeze, CoherenceSync resumingPlayer)
		{
		}

		public void SendForceCloseUi()
		{
		}

		[Command]
		public void ForceCloseUi(long startingSimFrame)
		{
		}

		public void SendTransitionToHolyForbidden()
		{
		}

		[Command]
		public void TransitionToHolyForbidden(long startingSimFrame)
		{
		}

		public void SendTransitionTP_ADV_001_Stage_DEATHFIGHT()
		{
		}

		[Command]
		public void TransitionTP_ADV_001_Stage_DEATHFIGHT(long startingSimFrame)
		{
		}

		private void TransitionToTP_ADV_001_Stage_DEATHFIGHT()
		{
		}

		public void SendTransitionToFoscari2()
		{
		}

		[Command]
		public void TransitionToFoscari2(long startingSimFrame)
		{
		}

		public void SendOpenMainArcanaPage()
		{
		}

		[Command]
		public void OpenMainArcanaPage(long startingSimFrame)
		{
		}

		public void SendArcanaModeTransition()
		{
		}

		[Command]
		public void ArcanaModeTransition(long startingSimFrame)
		{
		}

		public void SendBackground3GRAZIELLAUnlock()
		{
		}

		[Command]
		public void Background3GRAZIELLAUnlock(long startingSimFrame)
		{
		}

		public void SendBackground1NeoUnlock()
		{
		}

		[Command]
		public void SendBackground1NeoUnlock(long startingSimFrame)
		{
		}

		public void SendAdvanceDevilRoomLevel()
		{
		}

		[Command]
		public void AdvanceDevilRoomLevel(long startingSimFrame)
		{
		}

		public void SendDarkassoCutscene(VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		[Command]
		public void DarkassoCutscene(long startingSimFrame, CoherenceSync player)
		{
		}

		public void SendGift(Vector2 startPosition, Vector2 endPosition, ItemType itemType, WeaponType weaponType)
		{
		}

		[Command]
		public void ProcessGift(Vector2 startPosition, Vector2 endPosition, int itemType, int weaponType)
		{
		}

		public void SendStartSabotagion(float duration, int chosenEventTarget, Vector2 targetLocation, string newsFeedText, bool isPickleRush)
		{
		}

		[Command]
		public void StartSabotagion(float duration, int chosenEventTarget, Vector2 targetLocation, string newsFeedText, bool isPickleRush)
		{
		}

		public void SendStartCoopGaeaEvent()
		{
		}

		[Command]
		public void StartCoopGaeaEvent(long startingSimFrame)
		{
		}

		public void SendCoopSetFirstEnmemyKilled()
		{
		}

		[Command]
		public void CoopSetFirstEnmemyKilled(long startingSimFrame)
		{
		}

		public void SendOpenTerrace()
		{
		}

		[Command]
		public void OpenTerrace()
		{
		}

		public void SendMazerellaUnlockTorinoSecret()
		{
		}

		[Command]
		public void MazerellaUnlockTorinoSecret()
		{
		}

		[Command]
		public void OnlineSetEnemyFollowerData(short enemyType, bool wasCartRider)
		{
		}

		[Command]
		public void OnlineSetRecycledEnemyFollowerData(short enemyType, bool wasCartRider, CoherenceSync followedCharacterSync)
		{
		}

		public void SendTurnOnVaccuum(VampireSurvivors.Objects.Characters.CharacterController target)
		{
		}

		[Command]
		public void TurnOnVaccuum(CoherenceSync target)
		{
		}

		public void SendSnapYellows(PickupWeapon gRing, PickupWeapon sRing, PickupWeapon lMeta, PickupWeapon rMeta, VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		[Command]
		public void SnapYellows(CoherenceSync gRing, CoherenceSync sRing, CoherenceSync lMeta, CoherenceSync rMeta, CoherenceSync player)
		{
		}

		public void FireSyncTimer(long startingSimFrame, Action onSyncedTimer, bool canBePaused = true)
		{
		}

		private void TransitionToHolyForbidden()
		{
		}

		private void PerformGenericPause(CoherenceSync pausingPlayer)
		{
		}

		private void OnEnteredUi()
		{
		}

		private void OnStageSelectedRemotely(int oldStage, int newStage)
		{
		}

		private void OnSeatAssignedRemotely(uint oldId, uint newId)
		{
		}

		private PlayerInfo ReturnPlayerInfoForSeat(uint seat)
		{
			return null;
		}

		private void Awake()
		{
		}

		private void InitRngs()
		{
		}

		public void ResetGameSession()
		{
		}

		private void Update()
		{
		}

		private void SignalInitGameSession()
		{
		}

		private void SignalInitStage()
		{
		}

		private void SignalGameStart()
		{
		}

		private void OnStateAuthority()
		{
		}

		private void ReassignSeats()
		{
		}

		private void OnDisconnected(CoherenceBridge _, ConnectionCloseReason __)
		{
		}

		private void OnDestroy()
		{
		}

		private void OnClientDisconnected(CoherenceClientConnection clientConn)
		{
		}

		private void OnClientJoined(CoherenceClientConnection clientConn)
		{
		}

		private bool TryToAssignSeat(ref uint seat, uint newClient, int seatNumber, PlayerInfo playerInfo)
		{
			return false;
		}

		private void OnApplicationQuit()
		{
		}

		private void ShutDown()
		{
		}
	}
}
