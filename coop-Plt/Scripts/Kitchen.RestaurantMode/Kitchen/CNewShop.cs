using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CNewShop : IComponentData
	{
		public ShoppingTags Tags;

		public bool IsFree;

		public bool FixedLocation;

		public Vector3 Location;

		public bool StartOpen;
	}
}
