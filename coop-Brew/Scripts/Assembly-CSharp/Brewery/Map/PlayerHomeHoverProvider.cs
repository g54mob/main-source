using System.Collections.Generic;
using UnityEngine;

namespace Brewery.Map
{
	public class PlayerHomeHoverProvider : MonoBehaviour, IMapIconHoverProvider
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
