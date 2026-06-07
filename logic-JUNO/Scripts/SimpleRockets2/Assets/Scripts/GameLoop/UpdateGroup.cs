using System;
using System.Collections.Generic;
using Assets.Scripts.Jobs;
using ModApi.GameLoop.Interfaces;
using Unity.Jobs;
using UnityEngine;

namespace Assets.Scripts.GameLoop
{
	[Serializable]
	internal class UpdateGroup<T> : UpdateGroupBase<T>, IJobParallelFor where T : class, IGameLoopItem
	{
		private Action<T> _parallelAction;

		public UpdateGroup(IGameLoop gameLoop)
			: base(gameLoop)
		{
		}

		public static void UpdateMultiple<T1, T2>(UpdateGroup<T1> group1, Action<T1> action1, UpdateGroup<T2> group2, Action<T2> action2, string description) where T1 : class, IGameLoopItem where T2 : class, IGameLoopItem
		{
			IList<UpdateGroupBase<T1>.Subset> values = group1._subsets.Values;
			IList<UpdateGroupBase<T2>.Subset> values2 = group2._subsets.Values;
			int count = values.Count;
			int count2 = values2.Count;
			if (count == 0)
			{
				if (count2 != 0)
				{
					group2.Update(action2, description);
				}
				return;
			}
			if (count2 == 0)
			{
				group1.Update(action1, description);
				return;
			}
			int num = 0;
			int num2 = 0;
			UpdateGroupBase<T1>.Subset subset = values[0];
			UpdateGroupBase<T2>.Subset subset2 = values2[0];
			while (subset != null || subset2 != null)
			{
				if (subset2 == null || (subset != null && subset.ExecutionOrder <= subset2.ExecutionOrder))
				{
					group1._debugCallback?.Invoke(description, parallel: false, subset.ExecutionOrder, subset.GetRegisteredItems());
					int count3 = subset.Count;
					for (int i = 0; i < count3; i++)
					{
						try
						{
							action1(subset.Items[i]);
						}
						catch (Exception exception)
						{
							Debug.LogException(exception);
						}
					}
					subset = ((++num < count) ? values[num] : null);
					continue;
				}
				group2._debugCallback?.Invoke(description, parallel: false, subset2.ExecutionOrder, subset2.GetRegisteredItems());
				int count4 = subset2.Count;
				for (int j = 0; j < count4; j++)
				{
					try
					{
						action2(subset2.Items[j]);
					}
					catch (Exception exception2)
					{
						Debug.LogException(exception2);
					}
				}
				subset2 = ((++num2 < count2) ? values2[num2] : null);
			}
		}

		public static void UpdateMultiple<T1, T2, TLoop>(UpdateGroup<T1> group1, Action<T1> action1, UpdateGroup<T2> group2, Action<T2> action2, string description, TLoop loop, ExecuteSubsetCallback<TLoop> beforeSubsetCallback, ExecuteSubsetCallback<TLoop> afterSubsetCallback) where T1 : class, IGameLoopItem where T2 : class, IGameLoopItem where TLoop : IGameLoop
		{
			IList<UpdateGroupBase<T1>.Subset> values = group1._subsets.Values;
			IList<UpdateGroupBase<T2>.Subset> values2 = group2._subsets.Values;
			int count = values.Count;
			int count2 = values2.Count;
			if (count == 0)
			{
				if (count2 != 0)
				{
					group2.Update(action2, description, loop, beforeSubsetCallback, afterSubsetCallback);
				}
				return;
			}
			if (count2 == 0)
			{
				group1.Update(action1, description, loop, beforeSubsetCallback, afterSubsetCallback);
				return;
			}
			int num = 0;
			int num2 = 0;
			UpdateGroupBase<T1>.Subset subset = values[0];
			UpdateGroupBase<T2>.Subset subset2 = values2[0];
			while (subset != null || subset2 != null)
			{
				if (subset2 == null || (subset != null && subset.ExecutionOrder <= subset2.ExecutionOrder))
				{
					group1._debugCallback?.Invoke(description, parallel: false, subset.ExecutionOrder, subset.GetRegisteredItems());
					beforeSubsetCallback?.Invoke(loop, group1, subset.ExecutionOrder);
					int count3 = subset.Count;
					for (int i = 0; i < count3; i++)
					{
						try
						{
							action1(subset.Items[i]);
						}
						catch (Exception exception)
						{
							Debug.LogException(exception);
						}
					}
					afterSubsetCallback?.Invoke(loop, group1, subset.ExecutionOrder);
					subset = ((++num < count) ? values[num] : null);
					continue;
				}
				group2._debugCallback?.Invoke(description, parallel: false, subset2.ExecutionOrder, subset2.GetRegisteredItems());
				beforeSubsetCallback?.Invoke(loop, group2, subset2.ExecutionOrder);
				int count4 = subset2.Count;
				for (int j = 0; j < count4; j++)
				{
					try
					{
						action2(subset2.Items[j]);
					}
					catch (Exception exception2)
					{
						Debug.LogException(exception2);
					}
				}
				afterSubsetCallback?.Invoke(loop, group2, subset2.ExecutionOrder);
				subset2 = ((++num2 < count2) ? values2[num2] : null);
			}
		}

		public override void EndUpdate()
		{
			_executing = false;
			_debugCallback = null;
			IList<Subset> values = _subsets.Values;
			int count = values.Count;
			for (int i = 0; i < count; i++)
			{
				Subset subset = values[i];
				subset.ProcessPendingRegistrations();
				subset.ProcessPendingUnregistrations();
			}
		}

		void IJobParallelFor.Execute(int index)
		{
			_parallelAction(_subset.Items[index]);
		}

		public void ParallelUpdateAndComplete(int threshold, int batchSize, Action<T> action, string description)
		{
			int count = _subsets.Count;
			if (count == 0)
			{
				return;
			}
			IList<Subset> values = _subsets.Values;
			for (int i = 0; i < count; i++)
			{
				Subset subset = values[i];
				if (subset.Count < threshold)
				{
					Update(action, description);
					continue;
				}
				_debugCallback?.Invoke(description, parallel: true, subset.ExecutionOrder, subset.GetRegisteredItems());
				_subset = subset;
				_parallelAction = action;
				ManagedJobParallelFor.RunToCompletion(this, subset.Count, batchSize);
				_parallelAction = null;
				_subset = null;
			}
		}

		public void Update(Action<T> action, string description)
		{
			int count = _subsets.Count;
			if (count == 0)
			{
				return;
			}
			IList<Subset> values = _subsets.Values;
			for (int i = 0; i < count; i++)
			{
				Subset subset = values[i];
				_debugCallback?.Invoke(description, parallel: false, subset.ExecutionOrder, subset.GetRegisteredItems());
				int count2 = subset.Count;
				for (int j = 0; j < count2; j++)
				{
					try
					{
						action(subset.Items[j]);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
		}

		public void Update<TLoop>(Action<T> action, string description, TLoop loop, ExecuteSubsetCallback<TLoop> beforeSubsetCallback, ExecuteSubsetCallback<TLoop> afterSubsetCallback) where TLoop : IGameLoop
		{
			int count = _subsets.Count;
			if (count == 0)
			{
				return;
			}
			IList<Subset> values = _subsets.Values;
			for (int i = 0; i < count; i++)
			{
				Subset subset = values[i];
				_debugCallback?.Invoke(description, parallel: false, subset.ExecutionOrder, subset.GetRegisteredItems());
				beforeSubsetCallback?.Invoke(loop, this, subset.ExecutionOrder);
				int count2 = subset.Count;
				for (int j = 0; j < count2; j++)
				{
					try
					{
						action(subset.Items[j]);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
				afterSubsetCallback?.Invoke(loop, this, subset.ExecutionOrder);
			}
		}
	}
}
