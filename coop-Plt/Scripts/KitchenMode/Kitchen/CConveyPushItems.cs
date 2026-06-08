using System;
using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	public struct CConveyPushItems : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public enum ConveyState
		{
			None = 0,
			Push = 1,
			Grab = 2
		}

		public float Delay;

		public bool Push;

		public bool Grab;

		public bool Reversed;

		public bool GrabSpecificType;

		[ReadOnly]
		public int SpecificType;

		[ReadOnly]
		public ItemList SpecificComponents;

		public bool IgnoreProcessingItems;

		[ReadOnly]
		public float Progress;

		[ReadOnly]
		public ConveyState State;
	}
}
