using Brewery.Data;
using UnityEngine;

namespace Brewery.Items
{
	[CreateAssetMenu(fileName = "Catalyst", menuName = "Brewery/Items/Catalyst")]
	public class CatalystItem : BreweryItem
	{
		[Header("Catalyst Reference")]
		[SerializeField]
		private CatalystData catalystData;

		public CatalystData CatalystData => null;

		public override string GetDisplayName()
		{
			return null;
		}

		public override string GetLocalizedDescription()
		{
			return null;
		}

		private void OnEnable()
		{
		}

		public override bool CanBeUsedInStation(StationType stationType)
		{
			return false;
		}
	}
}
