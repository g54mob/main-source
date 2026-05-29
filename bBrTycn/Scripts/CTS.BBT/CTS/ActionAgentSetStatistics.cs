using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class ActionAgentSetStatistics : InstantAction
	{
		[SerializeField]
		private SerializableDictionary<EAgentStatistics, float> _statisticsToSet;

		protected override bool PlayAction(ActionSequence sequence)
		{
			foreach (KeyValuePair<EAgentStatistics, float> item in _statisticsToSet)
			{
				sequence.PlayerAgent.Statistics.SetStatisticFromUnitInterval(item.Key, item.Value);
			}
			return true;
		}
	}
}
