using UnityEngine;

namespace Brewery.Items
{
	[CreateAssetMenu(fileName = "GroundCorn", menuName = "Brewery/Items/Ground Corn")]
	public class GroundCornItem : BreweryItem
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
