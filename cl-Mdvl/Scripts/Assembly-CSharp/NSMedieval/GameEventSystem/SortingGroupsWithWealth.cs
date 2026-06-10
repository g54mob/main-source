using System;
using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.GameEventSystem
{
	[Serializable]
	public class SortingGroupsWithWealth
	{
		[SerializeField]
		private List<string> groups;

		[SerializeField]
		private int minimumWealth;

		[SerializeField]
		private string textKey;

		[SerializeField]
		private string descriptionTextKey;

		public List<string> Groups => groups;

		public int MinimumWealth => minimumWealth;

		public string TextKey => textKey;

		public string DescriptionTextKey => descriptionTextKey;
	}
}
