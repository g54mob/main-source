using System;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	public struct CApplianceInfo : IComponentData
	{
		public enum ApplianceInfoMode
		{
			Shop = 0,
			Garage = 1
		}

		public int ID;

		public ApplianceInfoMode Mode;

		public int Price;
	}
}
