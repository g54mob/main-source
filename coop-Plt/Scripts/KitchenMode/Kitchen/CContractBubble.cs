using System;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	public struct CContractBubble : IComponentData
	{
		public int Contract;
	}
}
