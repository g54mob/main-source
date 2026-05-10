using System;
using System.Collections.Generic;
using System.Linq;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.BBT
{
	[DefaultExecutionOrder(-5)]
	public sealed class ChoreList : MonoSingleton<ChoreList>, ILockable
	{
		private Dictionary<ChoreCategory, List<WorkerChore>> _choresByCategory = new Dictionary<ChoreCategory, List<WorkerChore>>();

		private readonly List<WorkerChore> _chores = new List<WorkerChore>();

		[SerializeField]
		private SerializableDictionary<ChoreCategory, ChoreCategoryCalculation> _specificCalculations = new SerializableDictionary<ChoreCategory, ChoreCategoryCalculation>();

		[SerializeField]
		[Inject(false)]
		private DefaultChoreSearch _defaultChoreSearch;

		[field: SerializeField]
		public bool Debug { get; private set; }

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		protected override void SingletonAwake()
		{
			_choresByCategory.Initialize();
			_choresByCategory.Remove(ChoreCategory.Default);
		}

		protected override void OnSingletonDestroy()
		{
		}

		private ChoreCategoryCalculation GetSearchMethod(ChoreCategory category)
		{
			if (_specificCalculations.TryGetValue(category, out var value))
			{
				return value;
			}
			if (!_defaultChoreSearch)
			{
				_defaultChoreSearch = base.gameObject.AddComponent<DefaultChoreSearch>();
			}
			return _defaultChoreSearch;
		}

		public bool TryGetSpecificChore<TChore>(out TChore p_outChore) where TChore : WorkerChore
		{
			foreach (WorkerChore chore in _chores)
			{
				if (chore is TChore val)
				{
					p_outChore = val;
					RemoveChore(chore);
					return true;
				}
			}
			p_outChore = null;
			return false;
		}

		public bool TryGetChore(Worker worker, List<ChoreCategory> sortedPriorities, Dictionary<ChoreCategory, bool> prioritiesStatus, out WorkerChore outChore, int maxPriority)
		{
			outChore = null;
			if (ObjectLock.IsLocked())
			{
				return false;
			}
			for (int i = 0; i < sortedPriorities.Count && i < maxPriority; i++)
			{
				ChoreCategory choreCategory = sortedPriorities[i];
				if (prioritiesStatus[choreCategory] && choreCategory != ChoreCategory.Default && _choresByCategory[choreCategory].Count > 0 && GetSearchMethod(choreCategory).TryGetChore(worker, _choresByCategory[choreCategory], out outChore))
				{
					RemoveChore(outChore);
					return true;
				}
			}
			return false;
		}

		public bool HasAny<TChore>(Worker p_worker) where TChore : WorkerChore
		{
			foreach (WorkerChore chore in _chores)
			{
				if (chore is TChore && !chore.IsOnCooldown() && chore.CanBePerformed(p_worker))
				{
					return true;
				}
			}
			return false;
		}

		public bool TryGetFirst<TChore>(Worker p_worker, out TChore p_chore) where TChore : WorkerChore
		{
			foreach (WorkerChore chore in _chores)
			{
				if (chore is TChore val && !chore.IsOnCooldown() && chore.CanBePerformed(p_worker))
				{
					p_chore = val;
					return true;
				}
			}
			p_chore = null;
			return false;
		}

		public void RemoveChore(WorkerChore p_chore)
		{
			if (_chores.Contains(p_chore))
			{
				_choresByCategory[p_chore.Category].Remove(p_chore);
				_chores.Remove(p_chore);
			}
		}

		public bool IsChoreInList(WorkerChore chore)
		{
			return _choresByCategory[chore.Category].Contains(chore);
		}

		public void AddToList(WorkerChore p_chore)
		{
			if (!_chores.Contains(p_chore))
			{
				_chores.Add(p_chore);
				_choresByCategory[p_chore.Category].Add(p_chore);
			}
		}

		public void ReinsertChore(WorkerChore p_chore)
		{
			if (_chores.Contains(p_chore))
			{
				return;
			}
			ChoreCategory category = p_chore.Category;
			double time = (float)p_chore.CreationTime;
			using (IEnumerator<WorkerChore> enumerator = _chores.Where((WorkerChore storedChore) => time <= (double)(float)storedChore.CreationTime).GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					WorkerChore current = enumerator.Current;
					_chores.Insert(_chores.IndexOf(current), p_chore);
				}
			}
			if (!_chores.Contains(p_chore))
			{
				_chores.Add(p_chore);
			}
			using (IEnumerator<WorkerChore> enumerator = _choresByCategory[category].Where((WorkerChore storedChore) => time < (double)(float)storedChore.CreationTime).GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					WorkerChore current2 = enumerator.Current;
					_choresByCategory[category].Insert(_choresByCategory[category].IndexOf(current2), p_chore);
				}
			}
			if (!_choresByCategory[category].Contains(p_chore))
			{
				_choresByCategory[category].Add(p_chore);
			}
		}

		void ILockable.OnLocked()
		{
		}

		void ILockable.OnUnlocked()
		{
		}
	}
}
