using System;
using PlayFab.SharedModels;

namespace PlayFab.ProfilesModels
{
	[Serializable]
	public class EntityStatisticValue : PlayFabBaseModel
	{
		public string Metadata;

		public string Name;

		public int? Value;

		public int Version;
	}
}
