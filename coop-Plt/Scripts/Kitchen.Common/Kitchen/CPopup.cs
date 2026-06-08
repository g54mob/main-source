using System;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	public struct CPopup : IComponentData
	{
		public int Priority;

		public bool Dismiss;
	}
}
