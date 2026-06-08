using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class AutoPlacer : MonoBehaviour
{
	private sealed class _003CPlaceTilesRandomly_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AutoPlacer _003C_003E4__this;

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
		public _003CPlaceTilesRandomly_003Ed__29(int _003C_003E1__state)
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
			AutoPlacer autoPlacer = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				autoPlacer.running = true;
				break;
			case 1:
				_003C_003E1__state = -1;
				autoPlacer.tilePlacer.ShowPreviewTileAt(autoPlacer.tileSlotPreviewer.AllValidTileSlots[0]);
				autoPlacer.tilePlacer.PlaceCurrentTile(autoPlacer.tileSlotPreviewer.AllValidTileSlots[0]);
				break;
			}
			if (autoPlacer.running && autoPlacer.tileSlotPreviewer.AllValidTileSlots.Count > 0)
			{
				_003C_003E2__current = new WaitForSeconds(autoPlacer.interval);
				_003C_003E1__state = 1;
				return true;
			}
			autoPlacer.running = false;
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
			throw new NotSupportedException();
		}
	}

	private sealed class _003CPlaceTiles_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AutoPlacer _003C_003E4__this;

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
		public _003CPlaceTiles_003Ed__30(int _003C_003E1__state)
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
			AutoPlacer autoPlacer = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				autoPlacer.running = true;
				autoPlacer.stopWatch.Restart();
				goto IL_0124;
			case 1:
				_003C_003E1__state = -1;
				goto IL_0067;
			case 2:
				_003C_003E1__state = -1;
				_003C_003E2__current = autoPlacer.StartCoroutine(autoPlacer.EvaluateAllTileSlots());
				_003C_003E1__state = 3;
				return true;
			case 3:
				_003C_003E1__state = -1;
				autoPlacer.tilePlacer.ShowPreviewTileAt(autoPlacer.allTileSlotEvaluationDatas[0].tileSlot);
				_003C_003E2__current = new WaitForSeconds(0.1f);
				_003C_003E1__state = 4;
				return true;
			case 4:
				{
					_003C_003E1__state = -1;
					autoPlacer.tilePlacer.CurrentTile.RotateTo(autoPlacer.allTileSlotEvaluationDatas[0].rotation, animate: false);
					autoPlacer.tilePlacer.PlaceCurrentTile(autoPlacer.allTileSlotEvaluationDatas[0].tileSlot);
					goto IL_0124;
				}
				IL_0124:
				if (!autoPlacer.running || autoPlacer.tileSlotPreviewer.AllValidTileSlots.Count <= 0)
				{
					break;
				}
				if (autoPlacer.paused)
				{
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_0067;
				IL_0067:
				_003C_003E2__current = new WaitForSeconds(autoPlacer.interval);
				_003C_003E1__state = 2;
				return true;
			}
			autoPlacer.running = false;
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
			throw new NotSupportedException();
		}
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<TileSlotEvaluationData, float> _003C_003E9__32_0;

		internal float _003CEvaluateAllTileSlots_003Eb__32_0(TileSlotEvaluationData x)
		{
			return x.score;
		}
	}

	private sealed class _003CEvaluateAllTileSlots_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AutoPlacer _003C_003E4__this;

		private Tile _003CcurrentTile_003E5__2;

		private List<TileSlot>.Enumerator _003C_003E7__wrap2;

		private TileSlot _003CcurrentTileSlot_003E5__4;

		private int _003Ci_003E5__5;

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
		public _003CEvaluateAllTileSlots_003Ed__32(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				AutoPlacer autoPlacer = _003C_003E4__this;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					_003C_003E1__state = -3;
					autoPlacer.stopWatch.Reset();
					goto IL_0277;
				}
				_003C_003E1__state = -1;
				List<TileSlot> allValidTileSlots = autoPlacer.tileSlotPreviewer.AllValidTileSlots;
				autoPlacer.tileSlotValues.Clear();
				autoPlacer.allTileSlotEvaluationDatas.Clear();
				_003CcurrentTile_003E5__2 = autoPlacer.tilePlacer.CurrentTile;
				autoPlacer.inputRouter.MovePreviewTile(null);
				autoPlacer.questWatcherComparisonValues = autoPlacer.TakeQuestWatcherSnapshot();
				_003C_003E7__wrap2 = allValidTileSlots.GetEnumerator();
				_003C_003E1__state = -3;
				goto IL_02a9;
				IL_0296:
				if (_003Ci_003E5__5 < 6)
				{
					if (!autoPlacer.tileSlotValues[_003CcurrentTileSlot_003E5__4].ContainsKey(_003CcurrentTile_003E5__2.RotationIndex))
					{
						TileSlotEvaluationData tileSlotEvaluationData = new TileSlotEvaluationData
						{
							tileSlot = _003CcurrentTileSlot_003E5__4,
							rotation = _003CcurrentTile_003E5__2.RotationIndex
						};
						autoPlacer.EvaluateTileNeighbors(_003CcurrentTile_003E5__2, tileSlotEvaluationData);
						Dictionary<QuestWatcher, QuestWatcherEvaluationData> previewQuestWatcherData = autoPlacer.TakeQuestWatcherSnapshot();
						autoPlacer.EvaluateQuestWatchers(previewQuestWatcherData, autoPlacer.questWatcherComparisonValues, tileSlotEvaluationData);
						if (autoPlacer.tileStack.Height <= autoPlacer.tileStackCountToPrioritizeQuests)
						{
							tileSlotEvaluationData.score = (float)(autoPlacer.lowTileStack_scorePerPerfectEdge * tileSlotEvaluationData.perfectEdges + autoPlacer.lowTileStack_penaltyPerUnfittingEdge * (6 - tileSlotEvaluationData.perfectEdges - tileSlotEvaluationData.emptyEdges) + autoPlacer.lowTileStack_penaltyPerQuestFailed * tileSlotEvaluationData.questsFailed) + (float)autoPlacer.lowTileStack_scorePerQuestValue * tileSlotEvaluationData.questValue + (float)(autoPlacer.lowTileStack_scorePerQuestFulfilled * tileSlotEvaluationData.questsFulfilled);
						}
						else
						{
							tileSlotEvaluationData.score = (float)(autoPlacer.scorePerPerfectEdge * tileSlotEvaluationData.perfectEdges + autoPlacer.penaltyPerUnfittingEdge * (6 - tileSlotEvaluationData.perfectEdges - tileSlotEvaluationData.emptyEdges) + autoPlacer.penaltyPerQuestFailed * tileSlotEvaluationData.questsFailed) + (float)autoPlacer.scorePerQuestValue * tileSlotEvaluationData.questValue + (float)(autoPlacer.scorePerQuestFulfilled * tileSlotEvaluationData.questsFulfilled);
						}
						autoPlacer.tileSlotValues[_003CcurrentTileSlot_003E5__4].Add(_003CcurrentTile_003E5__2.RotationIndex, tileSlotEvaluationData);
						autoPlacer.allTileSlotEvaluationDatas.Add(tileSlotEvaluationData);
						if (autoPlacer.stopWatch.ElapsedMilliseconds > 15)
						{
							_003C_003E2__current = null;
							_003C_003E1__state = 1;
							return true;
						}
						goto IL_0277;
					}
					goto IL_0284;
				}
				_003CcurrentTileSlot_003E5__4 = null;
				goto IL_02a9;
				IL_0284:
				_003Ci_003E5__5++;
				goto IL_0296;
				IL_02a9:
				if (_003C_003E7__wrap2.MoveNext())
				{
					_003CcurrentTileSlot_003E5__4 = _003C_003E7__wrap2.Current;
					autoPlacer.tileSlotValues.Add(_003CcurrentTileSlot_003E5__4, new Dictionary<int, TileSlotEvaluationData>());
					autoPlacer.inputRouter.MovePreviewTile(_003CcurrentTileSlot_003E5__4);
					_003Ci_003E5__5 = 0;
					goto IL_0296;
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap2 = default(List<TileSlot>.Enumerator);
				autoPlacer.allTileSlotEvaluationDatas = Enumerable.ToList(Enumerable.OrderByDescending(autoPlacer.allTileSlotEvaluationDatas, (TileSlotEvaluationData x) => x.score));
				return false;
				IL_0277:
				autoPlacer.tilePlacer.RotatePreviewTile(1, animate: false);
				goto IL_0284;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			((IDisposable)_003C_003E7__wrap2/*cast due to .constrained prefix*/).Dispose();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[SerializeField]
	private float interval = 0.5f;

	[SerializeField]
	private TileSlotPreviewer tileSlotPreviewer;

	[SerializeField]
	private TilePlacer tilePlacer;

	[SerializeField]
	private TileStack tileStack;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private QuestManager questManager;

	[SerializeField]
	private int scorePerPerfectEdge;

	[SerializeField]
	private int penaltyPerUnfittingEdge;

	[SerializeField]
	private int scorePerQuestValue;

	[SerializeField]
	private int penaltyPerQuestFailed;

	[SerializeField]
	private int scorePerQuestFulfilled;

	[SerializeField]
	private int tileStackCountToPrioritizeQuests = 10;

	[SerializeField]
	private int lowTileStack_scorePerPerfectEdge;

	[SerializeField]
	private int lowTileStack_penaltyPerUnfittingEdge;

	[SerializeField]
	private int lowTileStack_scorePerQuestValue;

	[SerializeField]
	private int lowTileStack_penaltyPerQuestFailed;

	[SerializeField]
	private int lowTileStack_scorePerQuestFulfilled;

	[SerializeField]
	private List<TileSlotEvaluationData> allTileSlotEvaluationDatas = new List<TileSlotEvaluationData>();

	[SerializeField]
	private bool paused;

	[SerializeField]
	private float evaluationDelay = 1f;

	[SerializeField]
	private bool running;

	[SerializeField]
	private int tilesPlaced;

	private Dictionary<TileSlot, Dictionary<int, TileSlotEvaluationData>> tileSlotValues = new Dictionary<TileSlot, Dictionary<int, TileSlotEvaluationData>>();

	private Dictionary<QuestWatcher, QuestWatcherEvaluationData> questWatcherComparisonValues;

	private Stopwatch stopWatch = new Stopwatch();

	private void StartPlacement()
	{
		StartCoroutine(PlaceTiles());
	}

	public void ToggleRandomPlacement()
	{
		if (running)
		{
			StopPlacement();
		}
		else
		{
			StartRandomPlacement();
		}
	}

	public void StartRandomPlacement()
	{
		StartCoroutine(PlaceTilesRandomly());
	}

	public void StopPlacement()
	{
		running = false;
	}

	private IEnumerator PlaceTilesRandomly()
	{
		return new _003CPlaceTilesRandomly_003Ed__29(0)
		{
			_003C_003E4__this = this
		};
	}

	private IEnumerator PlaceTiles()
	{
		return new _003CPlaceTiles_003Ed__30(0)
		{
			_003C_003E4__this = this
		};
	}

	private void StartEvaluatingTileSlots()
	{
		StartCoroutine(EvaluateAllTileSlots());
	}

	private IEnumerator EvaluateAllTileSlots()
	{
		return new _003CEvaluateAllTileSlots_003Ed__32(0)
		{
			_003C_003E4__this = this
		};
	}

	private void EvaluateQuestWatchers(Dictionary<QuestWatcher, QuestWatcherEvaluationData> previewQuestWatcherData, Dictionary<QuestWatcher, QuestWatcherEvaluationData> originalQuestWatchersData, TileSlotEvaluationData tileSlotEvaluationData)
	{
		foreach (KeyValuePair<QuestWatcher, QuestWatcherEvaluationData> originalQuestWatchersDatum in originalQuestWatchersData)
		{
			QuestWatcherEvaluationData value = originalQuestWatchersDatum.Value;
			QuestWatcherEvaluationData questWatcherEvaluationData = previewQuestWatcherData[originalQuestWatchersDatum.Key];
			if (value.fulfillmentStatus != questWatcherEvaluationData.fulfillmentStatus || value.remainingCount != questWatcherEvaluationData.remainingCount)
			{
				if (questWatcherEvaluationData.fulfillmentStatus == FulfillmentStatus.Unfulfillable)
				{
					tileSlotEvaluationData.questsFailed++;
				}
				else if (questWatcherEvaluationData.fulfillmentStatus == FulfillmentStatus.Fulfilled)
				{
					tileSlotEvaluationData.questsFulfilled++;
				}
				else if (value.remainingCount != questWatcherEvaluationData.remainingCount)
				{
					tileSlotEvaluationData.questValue += (float)(value.remainingCount - questWatcherEvaluationData.remainingCount) * value.valuePerElement;
				}
			}
		}
	}

	private void EvaluateTileNeighbors(Tile currentTile, TileSlotEvaluationData tileSlotEvaluationData)
	{
		for (int i = 0; i < 6; i++)
		{
			Tile neighbor = currentTile.GetNeighbor(i, Space.World);
			if (neighbor == null)
			{
				tileSlotEvaluationData.emptyEdges++;
				continue;
			}
			List<GroupType> edgeTypes = currentTile.GetEdgeTypes(i, Space.World);
			List<GroupType> edgeTypes2 = neighbor.GetEdgeTypes((i + 3) % 6, Space.World);
			if (edgeTypes.Count == 0 && edgeTypes2.Count == 0)
			{
				tileSlotEvaluationData.perfectEdges++;
				continue;
			}
			if ((currentTile.GetHybridEdges(i, Space.World).Count > 0 && edgeTypes2.Count == 0) || (edgeTypes.Count == 0 && neighbor.GetHybridEdges((i + 3) % 6, Space.World).Count > 0))
			{
				tileSlotEvaluationData.perfectEdges++;
				continue;
			}
			foreach (GroupType item in edgeTypes)
			{
				if (edgeTypes2.Contains(item))
				{
					tileSlotEvaluationData.perfectEdges++;
					break;
				}
			}
		}
	}

	private Dictionary<QuestWatcher, QuestWatcherEvaluationData> TakeQuestWatcherSnapshot()
	{
		Dictionary<QuestWatcher, QuestWatcherEvaluationData> dictionary = new Dictionary<QuestWatcher, QuestWatcherEvaluationData>();
		foreach (QuestWatcher allQuestWatcher in questManager.AllQuestWatchers)
		{
			if (allQuestWatcher.State != TileState.topStackPreview)
			{
				dictionary.Add(allQuestWatcher, new QuestWatcherEvaluationData(allQuestWatcher));
			}
		}
		return dictionary;
	}
}
