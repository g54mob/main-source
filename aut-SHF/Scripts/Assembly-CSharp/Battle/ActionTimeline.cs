using System;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	[Serializable]
	public class ActionTimeline<T> where T : Enum
	{
		public enum ActionSlotState
		{
			None = 0,
			Delay = 1,
			ActionWait = 2,
			Action = 3,
			WaitFinish = 4,
			Finish = 5
		}

		[Serializable]
		public class ActionSlot
		{
			[Label("ラベル")]
			public string label;

			[Label("アクション")]
			public List<T> state;

			[Label("開始ディレイ")]
			public float delay;

			[Label("アクション固定秒数維持")]
			[Tooltip("アクションが早く終わっても指定秒数保つ")]
			public float fixSecond;

			[Label("終了後待ち")]
			public float finishWaitTime;

			private T _prevState;

			private bool _isFinishDelay;

			private bool _isFinishAction;

			private ActionSlotState _nowSlotState;

			public float? InitFixSecond { get; private set; }

			public bool IsFinishDelay
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool IsFinishAction
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public ActionSlotState NowSlotState
			{
				get
				{
					return default(ActionSlotState);
				}
				set
				{
				}
			}

			public T ChoiceState()
			{
				return default(T);
			}

			public void CheckInit()
			{
			}

			public void ResetDefault()
			{
			}
		}

		[Serializable]
		public class Actions
		{
			public Action onceAction;

			public Action<double> updateAction;

			public Func<bool> cancelCondition;

			public Actions(Action onceAction = null, Action<double> updateAction = null, Action postAction = null, Func<bool> cancelCondition = null)
			{
			}
		}

		[SerializeField]
		public float firstDelay;

		public List<ActionSlot> timeline;

		public Action<int> FinishTurnAction;

		private bool _finishTrigger;

		private bool _startUpdateTrigger;

		private double _nextActionRap;

		private bool _applyFirstDelay;

		private ActionSlot _nowSlot;

		public int NowIndex { get; private set; }

		public int TurnCount { get; private set; }

		public Dictionary<T, Actions> ActionMap { get; private set; }

		public T NowState { get; private set; }

		public Queue<T> ReservedNextAction { get; private set; }

		public void RegisterAction(T key, Actions action)
		{
		}

		public void Update(double deltatime, double currentTime)
		{
		}

		public void CountUpRap(float addTime, double currentTime)
		{
		}

		public void SetNextSlotState(double nextGoalTime, ActionSlotState next)
		{
		}

		public bool CheckTimer(double currentTime)
		{
			return false;
		}

		public void StartUpdateTrigger()
		{
		}

		public void FinishActionTrigger()
		{
		}

		public void NextTurn()
		{
		}

		public void RegisterReserveAction(T action)
		{
		}

		public void ResetAll()
		{
		}
	}
}
