using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class UGCRoomItemDefinitionDatabase
	{
		private Dictionary<string, Sprite> _icons = new Dictionary<string, Sprite>();

		private Dictionary<string, int> _costs = new Dictionary<string, int>();

		private Dictionary<string, int> _silverCosts = new Dictionary<string, int>();

		public void SetIcon(string contentID, Sprite icon)
		{
			_icons[contentID] = icon;
		}

		public bool TryGetIcon(string contentID, out Sprite icon)
		{
			return _icons.TryGetValue(contentID, out icon);
		}

		public void SetCost(string contentID, int cost)
		{
			_costs[contentID] = cost;
		}

		public void SetSilverCost(string contentID, int silverCost)
		{
			_silverCosts[contentID] = silverCost;
		}

		public bool TryGetCost(string contentID, out int cost)
		{
			return _costs.TryGetValue(contentID, out cost);
		}

		public bool TryGetSilverCost(string contentID, out int silverCost)
		{
			return _silverCosts.TryGetValue(contentID, out silverCost);
		}
	}
}
