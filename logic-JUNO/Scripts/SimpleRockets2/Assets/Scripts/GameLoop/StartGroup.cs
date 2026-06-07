using System;
using System.Collections.Generic;
using ModApi.GameLoop.Interfaces;
using UnityEngine;

namespace Assets.Scripts.GameLoop
{
	internal class StartGroup<T> : UpdateGroupBase<T> where T : class, IGameLoopItem
	{
		public StartGroup(IGameLoop gameLoop)
			: base(gameLoop)
		{
		}

		public static void UpdateMultiple<T1, T2>(StartGroup<T1> group1, Action<T1> action1, StartGroup<T2> group2, Action<T2> action2, string description) where T1 : class, IGameLoopItem where T2 : class, IGameLoopItem
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
						T1 val = subset.Items[i];
						try
						{
							action1(val);
						}
						catch (Exception exception)
						{
							Debug.LogException(exception);
						}
						val.StartMethodCalled = true;
					}
					subset = ((++num < count) ? values[num] : null);
					continue;
				}
				group2._debugCallback?.Invoke(description, parallel: false, subset2.ExecutionOrder, subset2.GetRegisteredItems());
				int count4 = subset2.Count;
				for (int j = 0; j < count4; j++)
				{
					T2 val2 = subset2.Items[j];
					try
					{
						action2(val2);
					}
					catch (Exception exception2)
					{
						Debug.LogException(exception2);
					}
					val2.StartMethodCalled = true;
				}
				subset2 = ((++num2 < count2) ? values2[num2] : null);
			}
		}

		public override void EndUpdate()
		{
			_executing = false;
			_debugCallback = null;
			IList<Subset> values = _subsets.Values;
			int count = values.Count;
			int num = 0;
			for (int i = 0; i < count; i++)
			{
				Subset subset = values[i];
				subset.ClearRegisteredItems();
				subset.ProcessPendingRegistrations();
				num += subset.Count;
			}
			if (count > 0 && num == 0)
			{
				_subsets.Clear();
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
					T val = subset.Items[j];
					try
					{
						action(val);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
					val.StartMethodCalled = true;
				}
			}
		}
	}
}
