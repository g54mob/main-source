using System;
using System.Collections.Generic;
using DV.Scenarios.Common;

namespace DV.Scenarios
{
	public class CollectionManager
	{
		public Dictionary<string, IThingCollection> Collections { get; } = new Dictionary<string, IThingCollection>();

		public void AddCollection(IThingCollection collection)
		{
			if (Collections.ContainsKey(collection.TypeName))
			{
				throw new ArgumentException("Collection for " + collection.TypeName + " already exists");
			}
			Collections.Add(collection.TypeName, collection);
		}

		public IThingCollection GetCollection(string typeName)
		{
			if (Collections.TryGetValue(typeName, out var value))
			{
				return value;
			}
			return null;
		}

		public ThingCollection<T> GetCollection<T>() where T : class, IScenariosThing
		{
			return (ThingCollection<T>)GetCollection(typeof(T).FullName);
		}

		public void FixData()
		{
			foreach (IThingCollection value in Collections.Values)
			{
				value.FixData();
			}
		}

		public void ClearAll()
		{
			foreach (IThingCollection value in Collections.Values)
			{
				value.Collection.Clear();
			}
		}

		public void SaveOriginalValues()
		{
			foreach (IThingCollection value in Collections.Values)
			{
				foreach (object item in value.Collection)
				{
					if (item is Thing thing)
					{
						thing.SaveSnapshot(recursive: false);
					}
				}
			}
		}

		public void SortByName()
		{
			foreach (IThingCollection value in Collections.Values)
			{
				if (value.ShouldSortByName)
				{
					value.SortByName();
				}
			}
		}
	}
}
