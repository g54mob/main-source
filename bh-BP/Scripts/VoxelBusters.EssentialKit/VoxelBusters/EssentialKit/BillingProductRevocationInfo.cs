using System;

namespace VoxelBusters.EssentialKit
{
	public class BillingProductRevocationInfo
	{
		public DateTime Date { get; }

		public DateTime DateUTC { get; }

		public BillingProductRevocationReason Reason { get; }

		public BillingProductRevocationInfo(DateTime dateUTC, BillingProductRevocationReason reason)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
