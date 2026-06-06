using UnityEngine;

namespace Brewery.Items
{
	[CreateAssetMenu(fileName = "New Backpack", menuName = "Brewery/Items/Backpack")]
	public class BackpackItem : BreweryItem
	{
		[Header("Backpack Configuration")]
		[Tooltip("Number of additional inventory slots when equipped")]
		[SerializeField]
		private int slotIncrease;

		public int SlotIncrease => 0;

		public override bool RequiresMetadata()
		{
			return false;
		}

		private void OnEnable()
		{
		}

		public override void Use()
		{
		}
	}
}
