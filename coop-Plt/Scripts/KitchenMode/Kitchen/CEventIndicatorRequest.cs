using System;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	public struct CEventIndicatorRequest : IComponentData
	{
		public EventType Event;
	}
}
