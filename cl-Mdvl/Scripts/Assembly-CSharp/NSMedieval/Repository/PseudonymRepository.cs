using System.Collections.Generic;
using System.Linq;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Repository
{
	public class PseudonymRepository : DynamicJsonRepository<PseudonymRepository, Pseudonym>
	{
		public List<Pseudonym> GetAvailablePseudonyms(List<WorkerCharacteristicType> ignoreTypes)
		{
			List<Pseudonym> list = new List<Pseudonym>();
			foreach (Pseudonym allItem in GetAllItems())
			{
				if (!allItem.IgnoreCharacteristicType.Intersect(ignoreTypes).Any())
				{
					list.Add(allItem);
				}
			}
			return list;
		}

		public string GetPseudonym(List<WorkerCharacteristicType> ignoreTypes, int religionAlignment)
		{
			List<Pseudonym> list = GetAvailablePseudonyms(ignoreTypes).FindAll((Pseudonym pseudonym2) => (religionAlignment == 1) ? (pseudonym2.ReligiousAlignment >= 0f) : (pseudonym2.ReligiousAlignment <= 0f));
			Pseudonym pseudonym = list[Random.Range(0, list.Count)];
			ignoreTypes.AddRange(pseudonym.AddCharacteristicTypeToIgnore);
			return pseudonym.GetID();
		}

		public Pseudonym GetPseudonym(string name)
		{
			foreach (Pseudonym allItem in GetAllItems())
			{
				if (allItem.GetID().Equals(name))
				{
					return allItem;
				}
			}
			return null;
		}

		protected override string JsonFile()
		{
			return "Worker/Pseudonym.json";
		}
	}
}
