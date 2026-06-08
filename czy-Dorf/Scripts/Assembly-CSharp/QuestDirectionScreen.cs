using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class QuestDirectionScreen : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<QuestDirectionMarker, bool> _003C_003E9__13_0;

		public static Func<QuestDirectionMarker, FulfillmentStatus> _003C_003E9__13_1;

		public static Func<QuestDirectionMarker, bool> _003C_003E9__13_2;

		public static Func<QuestDirectionMarker, int> _003C_003E9__13_3;

		internal bool _003CReorderQuestMarkersAtEndOfFrame_003Eb__13_0(QuestDirectionMarker x)
		{
			return x.Visible;
		}

		internal FulfillmentStatus _003CReorderQuestMarkersAtEndOfFrame_003Eb__13_1(QuestDirectionMarker x)
		{
			return x.FulfillmentStatus;
		}

		internal bool _003CReorderQuestMarkersAtEndOfFrame_003Eb__13_2(QuestDirectionMarker x)
		{
			return x.IsFlagQuestMarker;
		}

		internal int _003CReorderQuestMarkersAtEndOfFrame_003Eb__13_3(QuestDirectionMarker x)
		{
			return x.QuestCount;
		}
	}

	private sealed class _003CReorderQuestMarkersAtEndOfFrame_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public QuestDirectionScreen _003C_003E4__this;

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
		public _003CReorderQuestMarkersAtEndOfFrame_003Ed__13(int _003C_003E1__state)
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
			QuestDirectionScreen questDirectionScreen = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				questDirectionScreen.reorderPending = true;
				_003C_003E2__current = new WaitForEndOfFrame();
				_003C_003E1__state = 1;
				return true;
			case 1:
			{
				_003C_003E1__state = -1;
				List<QuestDirectionMarker> list = Enumerable.ToList(Enumerable.ThenByDescending(Enumerable.ThenByDescending(Enumerable.OrderBy(Enumerable.Where(questDirectionScreen.visibleMarkers.Values, (QuestDirectionMarker x) => x.Visible), (QuestDirectionMarker x) => x.FulfillmentStatus), (QuestDirectionMarker x) => x.IsFlagQuestMarker), (QuestDirectionMarker x) => x.QuestCount));
				for (int num2 = 0; num2 < list.Count; num2++)
				{
					list[num2].transform.SetSiblingIndex(num2);
				}
				questDirectionScreen.reorderPending = false;
				return false;
			}
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

	[SerializeField]
	private QuestManager questManager;

	[SerializeField]
	private QuestDirectionMarker questDirectionMarkerPrefab;

	[SerializeField]
	private InputRouter inputRouter;

	private Dictionary<QuestWatcher, QuestDirectionMarker> visibleMarkers = new Dictionary<QuestWatcher, QuestDirectionMarker>();

	private Camera mainCamera;

	private bool reorderPending;

	private void Awake()
	{
		visibleMarkers = new Dictionary<QuestWatcher, QuestDirectionMarker>();
	}

	private void Start()
	{
		foreach (QuestWatcher allQuestWatcher in questManager.AllQuestWatchers)
		{
			CreateMarkerForQuest(allQuestWatcher);
		}
		questManager.OnQuestAdded += CreateMarkerForQuest;
		questManager.OnQuestRemoved += RemoveMarker;
	}

	private void CreateMarkerForQuest(QuestWatcher questWatcher)
	{
		if (visibleMarkers.ContainsKey(questWatcher))
		{
			Debug.LogError($"trying to create duplicate quest marker for {questWatcher}", questWatcher);
			return;
		}
		QuestDirectionMarker questDirectionMarker = UnityEngine.Object.Instantiate(questDirectionMarkerPrefab, base.transform);
		questDirectionMarker.Setup(this, questWatcher);
		visibleMarkers.Add(questWatcher, questDirectionMarker);
	}

	private void RemoveMarker(QuestWatcher removedWatcher)
	{
		if (visibleMarkers.ContainsKey(removedWatcher))
		{
			visibleMarkers[removedWatcher].Destroy();
			visibleMarkers.Remove(removedWatcher);
		}
	}

	private void OnDisable()
	{
		inputRouter.HighlightQuests(newHighlight: false);
	}

	private void OnDestroy()
	{
		visibleMarkers.Clear();
		questManager.OnQuestAdded -= CreateMarkerForQuest;
		questManager.OnQuestRemoved -= RemoveMarker;
	}

	public void ReorderQuestMarkers()
	{
		if (!reorderPending)
		{
			StartCoroutine(ReorderQuestMarkersAtEndOfFrame());
		}
	}

	private IEnumerator ReorderQuestMarkersAtEndOfFrame()
	{
		return new _003CReorderQuestMarkersAtEndOfFrame_003Ed__13(0)
		{
			_003C_003E4__this = this
		};
	}
}
