using System;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	[Serializable]
	public class ActionState<T> where T : struct, IComparable, IConvertible
	{
		[Serializable]
		public struct HpAction
		{
			[Range(0f, 1f)]
			[Label("HP割合(%)")]
			[Tooltip("大きい順に登録")]
			public float actionHp;

			[Label("移行アクション")]
			public T actionType;

			public bool IsFinish { get; private set; }

			public bool IsReached(float currentHp, float maxHp)
			{
				return false;
			}
		}

		[Serializable]
		public class TransitionTime
		{
			[SerializeField]
			private string label;

			public T nowAction;

			public T nextAction;

			public double time;
		}

		public HpAction[] hpActions;

		[Label("アクション遷移時間")]
		[Tooltip("今のアクションから次のアクションに移行するまでの時間")]
		public List<TransitionTime> transitionTime;

		private T _nextAction;

		private T _nowAction;

		private T _prevAction;

		private double _nextActionTime;

		public T NextAction
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public T NowAction
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public T PrevAction
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public void ChangeState()
		{
		}

		public void RegisterNextAction(double waitTime, T nextAction)
		{
		}

		public void RegisterNextAction(T nextAction, double noMatchTime = 0.0)
		{
		}

		public void StopNextActionTime(double deltatime)
		{
		}

		public bool CheckActionTime()
		{
			return false;
		}

		public void CheckHpAction(int maxHp, int nowHp)
		{
		}
	}
}
