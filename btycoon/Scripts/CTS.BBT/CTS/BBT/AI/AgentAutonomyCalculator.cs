using System;
using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS.BBT.AI
{
	public sealed class AgentAutonomyCalculator : CTSBehaviour, ILockable
	{
		[SerializeField]
		private int _priorityOverActionQueueThreshold = 100;

		[SerializeField]
		private AgentAutonomyList _autonomyList;

		[SerializeField]
		private bool _debug;

		[SerializeField]
		private EActionPriority _defaultPriority = EActionPriority.Autonomous;

		private readonly Dictionary<StringKey, AgentAutonomousAction> _autonomousActions = new Dictionary<StringKey, AgentAutonomousAction>();

		private readonly Dictionary<StringKey, AgentAction> _actionInstances = new Dictionary<StringKey, AgentAction>();

		[Inject(false)]
		private Agent _agentRef;

		private bool _paused;

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public bool Paused
		{
			get
			{
				if (!_paused)
				{
					return ObjectLock.IsLocked();
				}
				return true;
			}
			set
			{
				_paused = value;
			}
		}

		protected override void OnAwake()
		{
			base.OnAwake();
			HandleList(_autonomyList);
			void HandleList(AgentAutonomyList autonomyList)
			{
				foreach (var (key, value) in autonomyList.Actions)
				{
					_autonomousActions.TryAdd(key, value);
				}
				foreach (AgentAutonomyList fallback in autonomyList.Fallbacks)
				{
					HandleList(fallback);
				}
			}
		}

		public bool TryGetAutonomousAction(out AgentAction outAction)
		{
			outAction = null;
			StringKey key = default(StringKey);
			if (Paused)
			{
				return false;
			}
			int num = 0;
			foreach (var (stringKey2, agentAutonomousAction2) in _autonomousActions)
			{
				if ((object)agentAutonomousAction2 != null && (agentAutonomousAction2.CanBeExecutedWhenBusy || !(_agentRef is Customer customer) || !customer.Business.IsLocked))
				{
					if (!_actionInstances.TryGetValue(stringKey2, out var value))
					{
						value = agentAutonomousAction2.CreateAction(_agentRef);
						_actionInstances[stringKey2] = value;
					}
					int num2 = agentAutonomousAction2.CalculateScore(_agentRef, value);
					if (num2 > num && value.CanBePerformed(_agentRef))
					{
						num = num2;
						outAction = value;
						key = stringKey2;
					}
				}
			}
			if (outAction != null && (_agentRef.ActionPlayer.ActionQueue.Count <= 0 || num > _priorityOverActionQueueThreshold))
			{
				outAction.Priority = ((outAction.Priority > _defaultPriority) ? outAction.Priority : _defaultPriority);
				_actionInstances.Remove(key);
				return true;
			}
			outAction = null;
			return false;
		}

		void ILockable.OnLocked()
		{
		}

		void ILockable.OnUnlocked()
		{
		}
	}
}
