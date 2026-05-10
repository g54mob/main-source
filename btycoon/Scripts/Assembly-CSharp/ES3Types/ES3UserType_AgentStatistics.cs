using System.Collections.Generic;
using CTS;
using CTS.Core.StatisticsSystem;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_role", "_dailyRefreshes", "SaveData" })]
	public class ES3UserType_AgentStatistics : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_AgentStatistics()
			: base(typeof(AgentStatistics))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			AgentStatistics agentStatistics = (AgentStatistics)obj;
			Dictionary<EAgentStatistics, float> dictionary = new Dictionary<EAgentStatistics, float>();
			foreach (KeyValuePair<EAgentStatistics, NumericStatistic> getAllStatistic in agentStatistics.GetAllStatistics)
			{
				getAllStatistic.Deconstruct(out var key, out var value);
				EAgentStatistics key2 = key;
				NumericStatistic numericStatistic = value;
				dictionary[key2] = numericStatistic.Value;
			}
			writer.WriteProperty("Stats", dictionary);
			writer.WriteProperty("Paused", agentStatistics.Paused);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			AgentStatistics agentStatistics = (AgentStatistics)obj;
			agentStatistics.LoadStatistics();
			foreach (string property in reader.Properties)
			{
				if (!(property == "Stats"))
				{
					if (property == "Paused")
					{
						agentStatistics.Paused = reader.Read<bool>();
					}
					else
					{
						reader.Skip();
					}
					continue;
				}
				foreach (var (statToChange, newValue) in reader.Read<Dictionary<EAgentStatistics, float>>())
				{
					agentStatistics.SetStatisticValue(statToChange, newValue);
				}
			}
		}
	}
}
