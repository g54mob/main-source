using System.Collections.Generic;
using Brewery.Thief;
using UnityEngine;

namespace Brewery.Map
{
	public class WagonHoverProvider : MonoBehaviour, IMapIconHoverProvider
	{
		private WagonBurnTarget burnTarget;

		private void Awake()
		{
		}

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
