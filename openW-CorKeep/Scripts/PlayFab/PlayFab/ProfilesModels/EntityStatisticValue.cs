using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ProfilesModels
{
	[Serializable]
	public class EntityStatisticValue : PlayFabBaseModel
	{
		public Dictionary<string, EntityStatisticAttributeValue> AttributeStatistics;

		public string Metadata;

		public string Name;

		public List<string> Scores;

		public int? Value;

		public int Version;
	}
}
