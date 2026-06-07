using System.Collections.Generic;
using UnityEngine;

namespace Brewery.Map
{
	public class PortHoverProvider : MonoBehaviour, IMapIconHoverProvider
	{
		[Header("Display")]
		[SerializeField]
		private string portName;

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
