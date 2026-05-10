using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.BBT.AI
{
	public sealed class WorkerChoreAssigner : CTSBehaviour, ILockable
	{
		private Worker _workerRef;

		public const string VarName_Priorities = "_priorities";

		public const string VarName_PrioritiesStatus = "_prioritiesStatus";

		[SerializeField]
		private List<ChoreCategory> _priorities = new List<ChoreCategory>();

		private readonly Dictionary<ChoreCategory, bool> _prioritiesStatus = new Dictionary<ChoreCategory, bool>();

		private LockToggle _toggle;

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public bool IsLocked => _toggle.Locked;

		public static event Action<Worker, ChoreCategory, int> OnPriorityChanged;

		public static event Action<Worker, ChoreCategory, bool> OnPriorityStatusChanged;

		public event Action<ChoreCategory, bool> PriorityStatusChanged;

		public static event Action<Worker, bool> OnAutonomyActive;

		public event Action SelfLockChanged;

		public void SetActive(bool value)
		{
			bool flag = !value;
			if (flag != IsLocked)
			{
				_toggle.SetLock(flag);
				this.SelfLockChanged?.Invoke();
			}
		}

		protected override void OnAwake()
		{
			_toggle = new LockToggle(this);
			_workerRef = GetComponent<Worker>();
			List<ChoreCategory> list = new List<ChoreCategory>();
			foreach (ChoreCategory priority in _priorities)
			{
				if (priority != ChoreCategory.Default && !list.Contains(priority))
				{
					list.Add(priority);
					_prioritiesStatus.Add(priority, value: true);
				}
			}
			_priorities = list;
			ChoreCategory[] array = (ChoreCategory[])Enum.GetValues(typeof(ChoreCategory));
			foreach (ChoreCategory choreCategory in array)
			{
				if (choreCategory != ChoreCategory.Default && !_priorities.Contains(choreCategory))
				{
					_priorities.Add(choreCategory);
					_prioritiesStatus.Add(choreCategory, value: false);
				}
			}
		}

		public void AddPriority(ChoreCategory cat, int index = 0)
		{
			if (!_priorities.Contains(cat))
			{
				_priorities.Insert(index, cat);
			}
		}

		public void RemovePriority(ChoreCategory cat)
		{
			_priorities.Remove(cat);
		}

		public bool TryGetPriority(ChoreCategory cat, out bool selfEnabled, out int priority)
		{
			if (_priorities.Contains(cat))
			{
				selfEnabled = _prioritiesStatus[cat];
				priority = _priorities.IndexOf(cat);
				return true;
			}
			selfEnabled = false;
			priority = -1;
			return false;
		}

		public bool TryGetPrioritySelfActive(ChoreCategory cat, out bool selfEnabled)
		{
			if (_priorities.Contains(cat))
			{
				selfEnabled = _prioritiesStatus[cat];
				return true;
			}
			selfEnabled = false;
			return false;
		}

		public bool TryGetPriorityGloballyActive(ChoreCategory cat, out bool globalEnabled)
		{
			if (_priorities.Contains(cat))
			{
				globalEnabled = _prioritiesStatus[cat] && Worker.CVarAutonomyEnabled.GetCurrentValue() && ObjectLock.IsUnlocked();
				globalEnabled = true;
				return true;
			}
			globalEnabled = false;
			return false;
		}

		public void ToggleAllPriorities(bool value)
		{
			foreach (ChoreCategory key in new Dictionary<ChoreCategory, bool>(_prioritiesStatus).Keys)
			{
				TogglePriority(key, value);
			}
		}

		public bool IsAutonomyActive()
		{
			if (IsLocked)
			{
				return false;
			}
			return Worker.GlobalAutonomyEnabled;
		}

		public void TogglePriority(ChoreCategory cat, bool value)
		{
			if (!_prioritiesStatus.ContainsKey(cat) || _prioritiesStatus[cat] == value)
			{
				return;
			}
			_prioritiesStatus[cat] = value;
			WorkerChoreAssigner.OnPriorityStatusChanged?.Invoke(_workerRef, cat, value);
			this.PriorityStatusChanged?.Invoke(cat, value);
			if (value)
			{
				return;
			}
			int num;
			for (num = _workerRef.ActionPlayer.ActionQueue.Count - 1; num >= 0; num--)
			{
				num = num.ClampIndex(_workerRef.ActionPlayer.ActionQueue);
				if (num < 0)
				{
					break;
				}
				if (_workerRef.ActionPlayer.ActionQueue[num] is WorkerChore workerChore && workerChore.Category == cat && workerChore.Priority < EActionPriority.Player)
				{
					workerChore.CancelAction("cancelled from togglepriority");
				}
			}
		}

		public int SetCategoryPriority(ChoreCategory cat, int index)
		{
			if (!_priorities.Contains(cat))
			{
				return -1;
			}
			int num = _priorities.IndexOf(cat);
			index = Math.Clamp(index, 0, _priorities.Count - 1);
			_priorities.Remove(cat);
			_priorities.Insert(index, cat);
			int num2 = _priorities.IndexOf(cat);
			if (num != num2)
			{
				WorkerChoreAssigner.OnPriorityChanged?.Invoke(_workerRef, cat, num2);
			}
			return num2;
		}

		public bool TryGetChore(out WorkerChore p_outChore, int maxPriority = int.MaxValue)
		{
			p_outChore = null;
			if (ObjectLock.IsLocked() || !Worker.CVarAutonomyEnabled.GetCurrentValue())
			{
				return false;
			}
			return MonoSingleton<ChoreList>.Instance.TryGetChore(_workerRef, _priorities, _prioritiesStatus, out p_outChore, maxPriority);
		}

		void ILockable.OnLocked()
		{
			int num;
			for (num = _workerRef.ActionPlayer.ActionQueue.Count - 1; num >= 0; num--)
			{
				num = num.ClampIndex(_workerRef.ActionPlayer.ActionQueue);
				if (num < 0)
				{
					return;
				}
				AgentAction agentAction = _workerRef.ActionPlayer.ActionQueue[num];
				if (agentAction is WorkerChore && agentAction.Priority < EActionPriority.Player)
				{
					agentAction.CancelAction("cancelled by autonomy stopped");
				}
			}
			WorkerChoreAssigner.OnAutonomyActive?.Invoke(_workerRef, arg2: false);
		}

		void ILockable.OnUnlocked()
		{
			WorkerChoreAssigner.OnAutonomyActive?.Invoke(_workerRef, arg2: true);
		}
	}
}
