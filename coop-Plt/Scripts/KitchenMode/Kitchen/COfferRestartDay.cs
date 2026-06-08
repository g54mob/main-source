using System;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	public struct COfferRestartDay : IComponentData
	{
		public LossReason Reason;
	}
}
