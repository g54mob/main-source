using System;
using System.Collections.Generic;
using UnityEngine;

namespace Social
{
	[Serializable]
	public class WeightedOutcome
	{
		[SerializeField]
		private string logId;

		[SerializeField]
		private List<string> effectorIds;

		[SerializeField]
		private int weight;

		[SerializeField]
		private string belief;

		public string LogId => logId;

		public int Weight => weight;

		public List<string> EffectorId => effectorIds;

		public string Belief => belief;
	}
}
