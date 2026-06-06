using UnityEngine;

namespace Brewery.Items
{
	[CreateAssetMenu(fileName = "WaterContainer", menuName = "Brewery/Items/Water Container")]
	public class WaterContainerItem : BreweryItem
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
