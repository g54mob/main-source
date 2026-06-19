using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ProfilesModels
{
	[Serializable]
	public class EntityStatisticAttributeValue : PlayFabBaseModel
	{
		public string Metadata;

		public string Name;

		public List<string> Scores;
	}
}
