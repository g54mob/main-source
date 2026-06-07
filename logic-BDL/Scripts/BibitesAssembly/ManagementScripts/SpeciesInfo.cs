using SimulationScripts.BibiteScripts;
using UnityEngine;

namespace ManagementScripts
{
	public struct SpeciesInfo
	{
		[SerializeField]
		public long species;

		[SerializeField]
		public float energy;

		[SerializeField]
		public int count;

		public SpeciesInfo(Species speciesToLog)
		{
			species = speciesToLog.speciesID;
			energy = speciesToLog.energy;
			count = speciesToLog.count;
		}
	}
}
