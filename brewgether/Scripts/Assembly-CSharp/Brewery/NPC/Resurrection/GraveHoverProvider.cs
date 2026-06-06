using System.Collections.Generic;
using Brewery.Map;
using UnityEngine;

namespace Brewery.NPC.Resurrection
{
	public class GraveHoverProvider : MonoBehaviour, IMapIconHoverProvider
	{
		private GraveController graveController;

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
