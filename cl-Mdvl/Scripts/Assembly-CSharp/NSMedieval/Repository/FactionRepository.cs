using System.Collections.Generic;
using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class FactionRepository : DynamicJsonRepository<FactionRepository, Faction>
	{
		private bool initDictionaryDone;

		private Dictionary<string, List<Faction>> factionsByFactionType;

		protected override string JsonFile()
		{
			return "Faction/FactionRepository.json";
		}

		public List<Faction> GetFactions(string factionType)
		{
			LazyInitDictionary();
			if (!factionsByFactionType.ContainsKey(factionType))
			{
				return null;
			}
			return factionsByFactionType[factionType];
		}

		private void LazyInitDictionary()
		{
			if (initDictionaryDone)
			{
				return;
			}
			factionsByFactionType = new Dictionary<string, List<Faction>>();
			initDictionaryDone = true;
			foreach (Faction item in repository)
			{
				string key = item.FactionType.ToString();
				if (!factionsByFactionType.ContainsKey(key))
				{
					factionsByFactionType.Add(key, new List<Faction>());
				}
				factionsByFactionType[key].Add(item);
			}
		}
	}
}
