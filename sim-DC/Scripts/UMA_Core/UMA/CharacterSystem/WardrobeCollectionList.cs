using System;
using System.Collections.Generic;

namespace UMA.CharacterSystem
{
	[Serializable]
	public class WardrobeCollectionList
	{
		public List<WardrobeSet> sets;

		public List<WardrobeSettings> this[string key]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Clear()
		{
		}

		public bool Contains(string race)
		{
			return false;
		}

		public void Add(string race)
		{
		}

		public void Add(string race, List<WardrobeSettings> settings)
		{
		}

		public void Remove(string race)
		{
		}

		public List<string> GetAllRacesInCollection()
		{
			return null;
		}

		public List<string> GetAllRecipeNamesInCollection(string forRace = "")
		{
			return null;
		}

		protected List<WardrobeSettings> GetValue(string key)
		{
			return null;
		}

		protected void SetValue(string key, List<WardrobeSettings> value)
		{
		}
	}
}
