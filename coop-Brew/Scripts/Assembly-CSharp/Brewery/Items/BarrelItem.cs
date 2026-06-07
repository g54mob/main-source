using UnityEngine;

namespace Brewery.Items
{
	[CreateAssetMenu(fileName = "Barrel", menuName = "Brewery/Items/Barrel")]
	public class BarrelItem : BreweryItem
	{
		[Header("Barrel Settings")]
		[SerializeField]
		private int maxBottleCapacity;

		public int MaxBottleCapacity => 0;

		public override bool IsSellable => false;

		private void OnEnable()
		{
		}

		public override bool RequiresMetadata()
		{
			return false;
		}
	}
}
