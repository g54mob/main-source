using System.Collections.Generic;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Types;

namespace NSMedieval.Repository
{
	public class DamageTakingAgentSettingsRepository : DynamicJsonRepository<DamageTakingAgentSettingsRepository, DamageTakingAgentSettings>
	{
		private Dictionary<DamageTakingAgentType, List<DamageTakingAgentSettings>> cache = new Dictionary<DamageTakingAgentType, List<DamageTakingAgentSettings>>();

		public List<DamageTakingAgentSettings> GetSettings(DamageTakingAgentType type)
		{
			if (cache.ContainsKey(type))
			{
				return cache[type];
			}
			List<DamageTakingAgentSettings> list = new List<DamageTakingAgentSettings>();
			foreach (DamageTakingAgentSettings allItem in GetAllItems())
			{
				if ((allItem.AgentType & type) != DamageTakingAgentType.None)
				{
					list.Add(allItem);
				}
			}
			cache[type] = list;
			return list;
		}

		public DamageTakingAgentSettings GetByAgentType(DamageTakingAgentType type)
		{
			return GetFirst((DamageTakingAgentSettings item) => item.AgentType == type);
		}

		protected override string JsonFile()
		{
			return "Combat/DamageTakingAgentSettings.json";
		}
	}
}
