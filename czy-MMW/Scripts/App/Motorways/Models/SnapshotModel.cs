using System.Collections.Generic;
using Factory;
using Factory.Pools;
using Server;

namespace Motorways.Models
{
	public class SnapshotModel : IModel, IReusable, IReleasedFromScopeHandler
	{
		public List<VehicleDispatchRecord> vehicleDispatches = new List<VehicleDispatchRecord>();

		public void Reset()
		{
			vehicleDispatches.Clear();
		}

		public void OnReleasedFromScope(IScope scope)
		{
			foreach (VehicleDispatchRecord vehicleDispatch in vehicleDispatches)
			{
				scope.Release(vehicleDispatch);
			}
			vehicleDispatches.Clear();
		}

		public void Inspect()
		{
		}
	}
}
