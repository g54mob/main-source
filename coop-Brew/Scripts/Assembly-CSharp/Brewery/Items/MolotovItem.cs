using InventorySystem;
using UnityEngine;

namespace Brewery.Items
{
	[CreateAssetMenu(fileName = "Molotov", menuName = "Brewery/Items/Molotov")]
	public class MolotovItem : BreweryItem
	{
		[Header("Molotov Properties")]
		[Tooltip("Whether this item can be thrown like an empty bottle")]
		[SerializeField]
		private bool isThrowable;

		public bool IsThrowable => false;

		private void OnEnable()
		{
		}

		public override ItemCarryType GetCarryType()
		{
			return default(ItemCarryType);
		}
	}
}
