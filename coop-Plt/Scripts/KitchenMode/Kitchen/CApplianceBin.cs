using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CApplianceBin : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public int Capacity;

		[HideInInspector]
		public int CurrentAmount;

		public int EmptyBinItem;

		public float SelfEmptyTime;

		[HideInInspector]
		public float NextEmptyTime;
	}
}
