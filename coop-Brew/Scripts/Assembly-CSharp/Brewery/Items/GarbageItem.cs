using UnityEngine;

namespace Brewery.Items
{
	[CreateAssetMenu(fileName = "Garbage", menuName = "Brewery/Items/Garbage")]
	public class GarbageItem : BreweryItem
	{
		[Header("Garbage Settings")]
		[Tooltip("Maximum number of empty bottles this garbage container can hold")]
		[SerializeField]
		private int maxBottleCapacity;

		public int MaxBottleCapacity => 0;

		private void OnEnable()
		{
		}

		public override bool RequiresMetadata()
		{
			return false;
		}
	}
}
