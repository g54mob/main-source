using UnityEngine;

namespace Brewery.Items
{
	[CreateAssetMenu(fileName = "BreweryMaterial", menuName = "Brewery/Items/Brewery Material")]
	public class BreweryMaterialItem : BreweryItem
	{
		private void OnEnable()
		{
		}

		public override bool CanBeUsedInStation(StationType stationType)
		{
			return false;
		}
	}
}
