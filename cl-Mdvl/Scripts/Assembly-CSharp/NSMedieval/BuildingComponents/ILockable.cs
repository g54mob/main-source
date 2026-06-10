using System.Collections.Generic;
using NSMedieval.Enums;

namespace NSMedieval.BuildingComponents
{
	public interface ILockable
	{
		bool HasOrders { get; }

		BaseBuildingInstance OwnerBuilding { get; }

		List<LockStateData> LockStates { get; }

		LockState GetLockStateForOrder();
	}
}
