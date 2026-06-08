using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Dorfromantik.UI.Components;
using UnityEngine;

namespace Dorfromantik
{
	public class UndoTracker : MonoBehaviour
	{
		private sealed class _003CDisableUndoUntilEndOfFrame_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UndoTracker _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			public _003CDisableUndoUntilEndOfFrame_003Ed__29(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = _003C_003E1__state;
				UndoTracker undoTracker = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					undoTracker.undoEnabled = false;
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					undoTracker.undoEnabled = true;
					return false;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		private sealed class _003C_003Ec__DisplayClass35_0
		{
			public WatchedSessionQuest watchedChallenge;

			internal bool _003CUndo_003Eb__0(ChallengeData_002 x)
			{
				return x.id == watchedChallenge.SessionQuest.id;
			}

			internal bool _003CUndo_003Eb__1(ChallengeData_002 x)
			{
				return x.id == watchedChallenge.SessionQuest.id;
			}
		}

		[SerializeField]
		private int maxUndoTurns = 1;

		[SerializeField]
		private UiIconButton undoButton;

		[SerializeField]
		private float undoMinDelay = 0.1f;

		[SerializeField]
		private VfxConfiguration undoTileEffect;

		[SerializeField]
		private World world;

		[SerializeField]
		private SessionQuestWatcher sessionQuestWatcher;

		[SerializeField]
		private TileStack tileStack;

		[SerializeField]
		private TilePlacer tilePlacer;

		[SerializeField]
		private TilePlacementEventBroadcaster tilePlacementEventBroadcaster;

		[SerializeField]
		private InputRouter inputRouter;

		[SerializeField]
		private QuestManager questManager;

		[SerializeField]
		private RewardSystem rewardSystem;

		[SerializeField]
		private RewardLibrary rewardLibrary;

		[SerializeField]
		private PreplacedTileSectionManager preplacedTileSectionManager;

		[SerializeField]
		private TileGenerator tileGenerator;

		[SerializeField]
		private VfxManager vfxManager;

		[SerializeField]
		private AudioClipOptions undoSound;

		[SerializeField]
		private List<TurnData> turns = new List<TurnData>();

		private List<Vector2Int> connectedPreplacedSectionPositions = new List<Vector2Int>();

		private float lastUndoTime;

		private bool undoEnabled = true;

		public List<TurnData> Turns => turns;

		public event Action<Tile> OnUndo;

		private void Awake()
		{
			tilePlacementEventBroadcaster.OnTilePlaced_BoardPlacement += StoreTile;
			tilePlacementEventBroadcaster.OnTilePlaced_Finalized += StoreTurn;
			inputRouter.OnUndo += Undo;
			inputRouter.OnMenuCancel += SkipUndoThisFrame;
			rewardSystem.OnPreplacedTileConnected += StorePreplacedTileConnection;
			tilePlacer.OnTileDiscarded += DiscardTile;
		}

		private void DiscardTile(bool refillStack)
		{
			if (turns.Count != 0)
			{
				List<TurnData> list = turns;
				int index = list.Count - 1;
				list[index].discardedTileCount++;
			}
		}

		private void SkipUndoThisFrame()
		{
			StartCoroutine(DisableUndoUntilEndOfFrame());
		}

		private IEnumerator DisableUndoUntilEndOfFrame()
		{
			return new _003CDisableUndoUntilEndOfFrame_003Ed__29(0)
			{
				_003C_003E4__this = this
			};
		}

		private void StorePreplacedTileConnection(PreplacedTileHint preplacedTileHint)
		{
			connectedPreplacedSectionPositions.Add(preplacedTileHint.SectionGridPos);
		}

		private void OnEnable()
		{
			OverwritingSingleton<GameSession>.Instance.OnWorldWasSetup += StoreInitialTurn;
		}

		private void StoreInitialTurn()
		{
			turns.Add(new TurnData(null, tileStack, rewardSystem, questManager, sessionQuestWatcher, connectedPreplacedSectionPositions));
			List<TurnData> list = turns;
			int index = list.Count - 1;
			list[index].generatedTileCount = tileGenerator.GeneratedTileCount;
			List<TurnData> list2 = turns;
			index = list2.Count - 1;
			list2[index].generatedQuestCount = tileGenerator.GeneratedQuestCount;
			undoButton.SetVisualStateDisabled(turns.Count < 2);
		}

		private void StoreTile(Tile placedTile, bool placedByPlayer)
		{
			if (placedByPlayer)
			{
				turns.Add(new TurnData(placedTile));
			}
		}

		private void StoreTurn(Tile placedTile, bool placedByPlayer)
		{
			if (placedByPlayer)
			{
				List<TurnData> list = turns;
				int index = list.Count - 1;
				list[index].AddData(tileStack, rewardSystem, questManager, sessionQuestWatcher, connectedPreplacedSectionPositions);
				List<TurnData> list2 = turns;
				index = list2.Count - 1;
				list2[index].generatedTileCount = tileGenerator.GeneratedTileCount;
				List<TurnData> list3 = turns;
				index = list3.Count - 1;
				list3[index].generatedQuestCount = tileGenerator.GeneratedQuestCount;
				List<TurnData> list4 = turns;
				index = list4.Count - 1;
				list4[index].StoreStackedTiles(tileStack);
				connectedPreplacedSectionPositions.Clear();
				if (maxUndoTurns > -1 && turns.Count > maxUndoTurns + 1)
				{
					turns.RemoveAt(0);
				}
				undoButton.SetVisualStateDisabled(turns.Count < 2);
				lastUndoTime = Time.time;
			}
		}

		private void Undo()
		{
			if (!undoEnabled || Time.time < lastUndoTime + undoMinDelay || turns.Count < 2)
			{
				return;
			}
			TurnData turnData = turns[turns.Count - 1];
			TurnData turnData2 = turns[turns.Count - 2];
			foreach (int[] connectedPreplacedTilePosition in turnData.connectedPreplacedTilePositions)
			{
				Debug.Log($"Undo Connection of Preplaced Tile {connectedPreplacedTilePosition}");
				PreplacedTileHint preplacedTileHint = ((Section_PreplacedTile)preplacedTileSectionManager.GetSectionAtSectionPos(new Vector2Int(connectedPreplacedTilePosition[0], connectedPreplacedTilePosition[1]))).PreplacedTileHint;
				Tile tile = world.GetTile(preplacedTileHint.GridPos);
				tilePlacer.DestroyTile(tile);
				preplacedTileHint.RevertToPreviewState();
			}
			rewardSystem.SetStats(turnData2.rewardSystemData);
			tilePlacer.RemoveCurrentTile();
			Tile tile2 = world.GetTile(new Vector2Int(turnData.placedTileData.gridPos[0], turnData.placedTileData.gridPos[1]));
			if (tile2 == null)
			{
				Debug.LogError($"tries to undo placed tile at {new Vector2Int(turnData.placedTileData.gridPos[0], turnData.placedTileData.gridPos[1])}, but tile is null");
				return;
			}
			this.OnUndo?.Invoke(tile2);
			Vector3 position = tile2.transform.position;
			AudioManager.Instance.PlaySoundAtPosition(undoSound, position);
			vfxManager.SpawnEffectAtPosition(undoTileEffect, position);
			tileStack.SetHeight(Mathf.Clamp(turnData2.tileStackHeight - 1, 0, int.MaxValue), revertGeneratedTileCount: true);
			if (turnData.discardedTileCount > 0)
			{
				for (int i = 0; i < turnData.stackedTiles.Count; i++)
				{
					tileStack.ReplaceStackedTile(i, tileGenerator.CreateTileFromSaveData(turnData.stackedTiles[i]), randomizeSeed: false, generateDuplicate: false);
				}
				tileGenerator.SetGeneratedTileCount(turnData.generatedTileCount, turnData.generatedQuestCount);
			}
			Tile newTile = tileGenerator.CreateTileFromSaveData(turnData.placedTileData);
			tileStack.InsertTile(0, newTile, generateDuplicate: false);
			tilePlacer.DestroyTile(tile2);
			tilePlacer.ShowPreviewTileAt(tilePlacer.CurrentTileSlot);
			foreach (QuestWatcherState questWatcherState in turnData2.questWatcherStates)
			{
				Tile tile3 = world.GetTile(new Vector2Int(questWatcherState.questTileGridPos[0], questWatcherState.questTileGridPos[1]));
				if (tile3 is QuestTile { QuestWatcher: var questWatcher })
				{
					if (questWatcher == null)
					{
						Debug.LogError($"Undo: Quest Watcher not found at position {tile3.GridPos} on {tile3}", tile3);
					}
					else if (questWatcher.Watching != questWatcherState.watching || questWatcher.CurrentQuestIndex != questWatcherState.questQueueIndex)
					{
						questWatcher.SetState(questWatcherState);
					}
				}
			}
			using (List<WatchedSessionQuest>.Enumerator enumerator3 = sessionQuestWatcher.watchedSessionQuests.GetEnumerator())
			{
				while (enumerator3.MoveNext())
				{
					_003C_003Ec__DisplayClass35_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass35_0();
					CS_0024_003C_003E8__locals7.watchedChallenge = enumerator3.Current;
					if (Enumerable.Count(turnData2.challengeStates, (ChallengeData_002 x) => x.id == CS_0024_003C_003E8__locals7.watchedChallenge.SessionQuest.id) == 0)
					{
						Debug.Log($"no previous data on challenge {CS_0024_003C_003E8__locals7.watchedChallenge.SessionQuest.id}");
						continue;
					}
					ChallengeData_002 challengeData_ = Enumerable.First(turnData2.challengeStates, (ChallengeData_002 x) => x.id == CS_0024_003C_003E8__locals7.watchedChallenge.SessionQuest.id);
					if (CS_0024_003C_003E8__locals7.watchedChallenge.SessionQuest.CurrentLevelIndex != challengeData_.currentLevel || CS_0024_003C_003E8__locals7.watchedChallenge.SessionQuest.GetCurrentProgress() != challengeData_.currentProgress)
					{
						SessionQuest sessionQuest = CS_0024_003C_003E8__locals7.watchedChallenge.SessionQuest;
						sessionQuest.LoadFromData(challengeData_);
						rewardLibrary.RestoreRewardsFromChallenge(sessionQuest);
						sessionQuest.OverwriteSaveState();
					}
				}
			}
			if (rewardSystem.IsGameOver)
			{
				rewardSystem.UndoGameOver();
			}
			turns.RemoveAt(turns.Count - 1);
			undoButton.SetVisualStateDisabled(turns.Count < 2);
			tilePlacementEventBroadcaster.BroadcastTurnUndone(position);
		}

		private void OnDestroy()
		{
			if ((bool)OverwritingSingleton<GameSession>.Instance)
			{
				OverwritingSingleton<GameSession>.Instance.OnWorldWasSetup -= StoreInitialTurn;
			}
			tilePlacementEventBroadcaster.OnTilePlaced_BoardPlacement -= StoreTile;
			tilePlacementEventBroadcaster.OnTilePlaced_Finalized -= StoreTurn;
			inputRouter.OnUndo -= Undo;
			inputRouter.OnMenuCancel -= SkipUndoThisFrame;
			rewardSystem.OnPreplacedTileConnected -= StorePreplacedTileConnection;
			tilePlacer.OnTileDiscarded -= DiscardTile;
		}
	}
}
