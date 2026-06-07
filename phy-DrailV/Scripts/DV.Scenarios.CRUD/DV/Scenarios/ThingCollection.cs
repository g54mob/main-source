using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV.Scenarios.Common;
using DV.Util;
using UnityEngine;

namespace DV.Scenarios
{
	public abstract class ThingCollection<T> : IThingCollection where T : class, IScenariosThing
	{
		protected string newThingName;

		public readonly Dictionary<string, string> localizationDictionary;

		public string TypeName => typeof(T).FullName;

		public ObservableCollectionExt<T> C { get; } = new ObservableCollectionExt<T>();

		public IList Collection => C;

		public CollectionManager Manager { get; private set; }

		public bool ShouldSortByName { get; private set; }

		public ThingCollection(string newThingName, CollectionManager manager, bool shouldSortByName, Dictionary<string, string> localizationDictionary)
		{
			this.newThingName = newThingName;
			Manager = manager;
			ShouldSortByName = shouldSortByName;
			this.localizationDictionary = localizationDictionary;
		}

		public abstract T Create();

		protected void _AfterCreate<T2>(T2 thing) where T2 : Thing
		{
			thing.Name = GetFirstAvailableName();
			thing.SyncState = SyncState.Fresh;
			thing.SaveSnapshot(recursive: false);
			C.Add(thing as T);
		}

		public string GetFirstAvailableName()
		{
			int num = 1;
			string potentialName;
			while (true)
			{
				potentialName = $"{newThingName} {num}";
				if (!C.Any((T t) => t.Name == potentialName))
				{
					break;
				}
				num++;
			}
			return potentialName;
		}

		public string GetAutoIncrementName(T existingThing)
		{
			if (existingThing.Name == null)
			{
				return GetFirstAvailableName();
			}
			return Util.GetAutoIncrement(existingThing.Name, C.Select((T t) => t.Name).ToList(), localizationDictionary);
		}

		public T GetOrCreate()
		{
			return C.FirstOrDefault() ?? Create();
		}

		public void Delete(T thing)
		{
			C.Remove(thing);
		}

		public T CreateCopyOf(T thing)
		{
			if (thing is Thing thing2)
			{
				IScenariosThing scenariosThing = thing2.Copy();
				T val = scenariosThing as T;
				SyncState syncState = scenariosThing.SyncState;
				scenariosThing.Name = GetAutoIncrementName(val);
				scenariosThing.SyncState = syncState;
				scenariosThing.SaveSnapshot();
				C.Insert(C.IndexOf(thing) + 1, val);
				return val;
			}
			Debug.LogError("Cannot copy '" + thing.Name + "' because it doesn't inherit from Thing");
			return null;
		}

		public void SortByName()
		{
			C.Reset(C.OrderBy((T t) => t.Name).ToList());
		}

		public virtual void FixData()
		{
			foreach (T item in C)
			{
				if (item is Thing thing)
				{
					_FixData(thing);
				}
				else
				{
					Debug.LogWarning("FixData will have no effect on " + item.Name + " because it doesn't inherit from Thing");
				}
			}
		}

		protected virtual void _FixData<T2>(T2 thing) where T2 : Thing
		{
			if (string.IsNullOrWhiteSpace(thing.Name))
			{
				thing._name = GetFirstAvailableName();
			}
			if (!thing.IsReadOnly)
			{
				thing.SyncState = ((thing.FileName != null) ? SyncState.Synced : SyncState.Fresh);
			}
		}
	}
}
