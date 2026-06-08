using JetBrains.Annotations;
using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CCustomerSettings : IComponentData
	{
		public PatienceValues Patience;

		public PatienceValues BasePatience;

		public OrderingValues Ordering;

		public OrderingValues BaseOrdering;

		public float this[PatienceReason reason] => Patience[reason];

		public readonly void AddPatience(ref CPatience patience, float seconds, bool allow_over = false)
		{
			float num = seconds / Patience[patience.Reason];
			patience.RemainingTime += num;
			if (!allow_over)
			{
				patience.RemainingTime = Mathf.Clamp(patience.RemainingTime, 0f, patience.StartTime);
			}
			else
			{
				patience.StartTime = Mathf.Max(patience.RemainingTime, patience.StartTime);
			}
		}

		public readonly float RemainingSeconds(CPatience patience)
		{
			return patience.RemainingTime * Patience[patience.Reason];
		}

		[Pure]
		public CPatience NewPhase(PatienceReason reason)
		{
			if (reason switch
			{
				PatienceReason.Thinking => false, 
				PatienceReason.Eating => false, 
				PatienceReason.Seating => true, 
				PatienceReason.Service => true, 
				PatienceReason.WaitForFood => true, 
				PatienceReason.GetFoodDelivered => true, 
				PatienceReason.Queue => false, 
				_ => false, 
			})
			{
				return new CPatience(reason, 1f);
			}
			return new CPatience(reason);
		}
	}
}
