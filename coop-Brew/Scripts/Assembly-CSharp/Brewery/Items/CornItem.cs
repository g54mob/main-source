using UnityEngine;

namespace Brewery.Items
{
	[CreateAssetMenu(fileName = "Corn", menuName = "Brewery/Items/Corn")]
	public class CornItem : BreweryItem
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
