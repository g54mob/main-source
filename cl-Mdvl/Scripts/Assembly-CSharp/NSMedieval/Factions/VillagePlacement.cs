using System;
using UnityEngine;

namespace NSMedieval.Factions
{
	[Serializable]
	public class VillagePlacement
	{
		[SerializeField]
		private int factionCount;

		[SerializeField]
		private string factionType;

		[SerializeField]
		private int villagesCountPerFaction;

		public int FactionCount => factionCount;

		public string FactionType => factionType;

		public int VillagesCountPerFaction => villagesCountPerFaction;
	}
}
