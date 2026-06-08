using System;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	public struct CStarIncreasePopup : IComponentData
	{
		public int StarCount;
	}
}
