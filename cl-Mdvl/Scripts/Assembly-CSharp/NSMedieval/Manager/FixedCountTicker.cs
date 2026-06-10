using System;
using System.Collections.Generic;
using NSEipix.Base;

namespace NSMedieval.Manager
{
	public class FixedCountTicker<T> : MonoSingleton<FixedCountTicker<T>>
	{
		private readonly List<T> entitiesToTick = new List<T>();

		private readonly Dictionary<T, Action> actionPerEntity = new Dictionary<T, Action>();

		private int tempCounter;

		private readonly object padlock = new object();

		private readonly List<Action> toExecute = new List<Action>();

		protected virtual int UpdateEntitiesPerFrame => 10;

		public virtual void Attach(T entity, Action callback)
		{
			lock (padlock)
			{
				if (!actionPerEntity.ContainsKey(entity))
				{
					entitiesToTick.Add(entity);
					actionPerEntity.Add(entity, callback);
				}
			}
		}

		public virtual void Detach(T entity)
		{
			lock (padlock)
			{
				if (actionPerEntity.ContainsKey(entity))
				{
					entitiesToTick.Remove(entity);
					actionPerEntity.Remove(entity);
				}
			}
		}

		public void Update()
		{
			lock (padlock)
			{
				int num = Math.Min(UpdateEntitiesPerFrame, entitiesToTick.Count);
				for (int i = 0; i < num; i++)
				{
					tempCounter %= entitiesToTick.Count;
					T val = entitiesToTick[tempCounter];
					tempCounter++;
					if (val != null && actionPerEntity.ContainsKey(val) && actionPerEntity[val] != null)
					{
						toExecute.Add(actionPerEntity[val]);
					}
				}
			}
			foreach (Action item in toExecute)
			{
				item?.Invoke();
			}
			toExecute.Clear();
		}

		protected override void OnDestroy()
		{
			entitiesToTick.Clear();
			actionPerEntity.Clear();
			toExecute.Clear();
			base.OnDestroy();
		}
	}
}
