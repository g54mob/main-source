using System;
using CTS.BBT.AI;

namespace CTS
{
	public static class VampireThirst
	{
		public static int CalculateSuckedBloodQuantity(Agent vampire, Agent victim)
		{
			if (!vampire.Statistics.TryGetNumericStatistic(EAgentStatistics.Hunger, out var numericStatistic))
			{
				return 0;
			}
			return Math.Min((int)(numericStatistic.Max - numericStatistic.Value), victim.Health.CurrentHealth);
		}
	}
}
