using System.Collections.Generic;
using Brewery.Map;
using UnityEngine;

namespace Brewery.Quest
{
	public class QuestMarkerHoverProvider : MonoBehaviour, IMapIconHoverProvider
	{
		public string GetHoverTitle()
		{
			return null;
		}

		public string GetHoverSubtitle()
		{
			return null;
		}

		public List<HoverInfoSection> GetHoverSections()
		{
			return null;
		}

		public bool ShouldShowHover()
		{
			return false;
		}
	}
}
