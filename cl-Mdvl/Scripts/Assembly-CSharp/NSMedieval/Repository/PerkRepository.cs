using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;

namespace NSMedieval.Repository
{
	public class PerkRepository : DynamicJsonRepository<PerkRepository, Perk>
	{
		private bool dictionaryInitialized;

		private Dictionary<string, List<Perk>> allFromPerkCategory;

		private IEnumerable<Perk> perks;

		private IEnumerable<Perk> Perks
		{
			get
			{
				if (perks != null && perks.Any())
				{
					return perks;
				}
				return perks = GetAllItems();
			}
		}

		public bool GetPerk(string perkId, IEnumerable<Perk> forbidden, IEnumerable<WorkerCharacteristicType> ignoreTypes, out Perk perk)
		{
			perk = GetAvailablePerks(forbidden, ignoreTypes).FirstOrDefault((Perk p) => p.GetID().Equals(perkId));
			return perk != null;
		}

		public Perk GetRandomPerk(IEnumerable<Perk> forbidden, IEnumerable<WorkerCharacteristicType> ignoreTypes)
		{
			List<Perk> list = GetAvailablePerks(forbidden, ignoreTypes).ToPooledList();
			if (list.Count > 0)
			{
				Perk random = list.GetRandom();
				ListPool<Perk>.Return(list);
				return random;
			}
			ListPool<Perk>.Return(list);
			Log.Info("Couldn't find available Perks. Returning null", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Repo\\PerkRepository.cs");
			return null;
		}

		public List<Perk> GetAllFromCategory(Perk selectedPerk)
		{
			if (!dictionaryInitialized)
			{
				dictionaryInitialized = true;
				allFromPerkCategory = new Dictionary<string, List<Perk>>();
			}
			if (allFromPerkCategory.TryGetValue(selectedPerk.GetID(), out var value))
			{
				return value;
			}
			List<Perk> list = new List<Perk>();
			foreach (Perk allItem in GetAllItems())
			{
				if (selectedPerk.ConflictsWith.Contains(allItem.GetID()))
				{
					list.Add(allItem);
				}
			}
			allFromPerkCategory[selectedPerk.GetID()] = list;
			return list;
		}

		protected override string JsonFile()
		{
			return "Worker/Perk.json";
		}

		private IEnumerable<Perk> GetAvailablePerks(IEnumerable<Perk> forbidden, IEnumerable<WorkerCharacteristicType> ignoreTypes)
		{
			List<Perk> list = new List<Perk>();
			List<string> list2 = forbidden.Select((Perk forbiddenPerk) => forbiddenPerk.GetID()).ToList();
			foreach (Perk allItem in GetAllItems())
			{
				if (!allItem.IgnoreCharacteristicType.Intersect(ignoreTypes).Any() && !list2.Contains(allItem.GetID()) && !list2.Any(allItem.ConflictsWith.Contains))
				{
					list.Add(allItem);
				}
			}
			return list;
		}

		public IEnumerable<Perk> GetAvailableOnStartPerks()
		{
			List<Perk> list = new List<Perk>();
			foreach (Perk allItem in GetAllItems())
			{
				if (!allItem.ForbidOnStart)
				{
					list.Add(allItem);
				}
			}
			return list;
		}
	}
}
