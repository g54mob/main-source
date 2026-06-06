using System;
using Synty.SidekickCharacters.Database;
using Synty.SidekickCharacters.Database.DTO;

namespace Synty.SidekickCharacters.Serialization
{
	[Serializable]
	public class SerializedColorSet
	{
		public int Species { get; set; }

		public string Name { get; set; }

		public string SourceColorPath { get; set; }

		public string SourceMetallicPath { get; set; }

		public string SourceSmoothnessPath { get; set; }

		public string SourceReflectionPath { get; set; }

		public string SourceEmissionPath { get; set; }

		public string SourceOpacityPath { get; set; }

		public void PopulateFromSidekickColorSet(SidekickColorSet colorSet, SidekickSpecies defaultSpecies)
		{
		}

		public SidekickColorSet CreateSidekickColorSet(DatabaseManager db)
		{
			return null;
		}
	}
}
