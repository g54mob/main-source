using System;
using Unity.Entities;

namespace Kitchen
{
	public struct SLoadoutStatus : IComponentData
	{
		[Flags]
		public enum RequiredActions
		{
			None = 0,
			Check = 1,
			AddLayout = 2,
			AddDish = 4,
			DuplicateDishFranchise = 8,
			PickSaveSlot = 0x10
		}

		public RequiredActions Required;

		public bool IsReady => Required == RequiredActions.None;

		public static implicit operator RequiredActions(SLoadoutStatus status)
		{
			return status.Required;
		}

		public static implicit operator SLoadoutStatus(RequiredActions state)
		{
			return new SLoadoutStatus
			{
				Required = state
			};
		}
	}
}
