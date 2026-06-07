using System;
using System.Collections.Generic;
using Steamworks;
using UnityEngine;

namespace Heathen.SteamworksIntegration
{
	[Serializable]
	public class SearchArguments
	{
		[Tooltip("If less than or equal to 0 then we wont use the open slot filter")]
		public int slots = -1;

		[Tooltip("The distance from the searching user that should be considered when searching")]
		public ELobbyDistanceFilter distance = ELobbyDistanceFilter.k_ELobbyDistanceFilterDefault;

		[Tooltip("Metadata values that should be used to sort the results e.g. values `closer` to these values will be weighted higher in the resutls")]
		public List<NearFilter> nearValues = new List<NearFilter>();

		[Tooltip("Metadata values that should be compared as numeric values e.g. should follow typical maths rules for concepts such as less than, greater than, etc.")]
		public List<NumericFilter> numericFilters = new List<NumericFilter>();

		[Tooltip("Metadata values that should be compared as strings")]
		public List<StringFilter> stringFilters = new List<StringFilter>();
	}
}
