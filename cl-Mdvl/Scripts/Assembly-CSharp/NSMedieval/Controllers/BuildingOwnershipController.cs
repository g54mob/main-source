using System;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.State;

namespace NSMedieval.Controllers
{
	public class BuildingOwnershipController : MonoSingleton<BuildingOwnershipController>
	{
		public event Action<BaseBuildingInstance> BuildingOwnerRegisteredRefactoredEvent;

		public event Action<BaseBuildingInstance, HumanoidInstance> BuildingOwnerUnregisteredRefactoredEvent;

		public void BuildingOwnerRegistered(BaseBuildingInstance building)
		{
			this.BuildingOwnerRegisteredRefactoredEvent?.Invoke(building);
		}

		public void BuildingOwnerUnregistered(BaseBuildingInstance building, HumanoidInstance owner)
		{
			this.BuildingOwnerUnregisteredRefactoredEvent?.Invoke(building, owner);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.BuildingOwnerRegisteredRefactoredEvent = null;
			this.BuildingOwnerUnregisteredRefactoredEvent = null;
		}
	}
}
