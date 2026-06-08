using System;
using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	public struct CTableSetIndicator : IComponentData
	{
		public int Count;

		public DecorationValues Decoration;

		public bool InteractionTarget;
	}
}
