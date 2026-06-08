using Timberborn.BaseComponentSystem;
using Timberborn.Localization;
using Timberborn.StatusSystem;
using Timberborn.WaterObjects;

namespace Timberborn.WaterBuildingsUI
{
	internal class FloodedBuildingStatus : BaseComponent, IAwakableComponent, IStartableComponent
	{
		private static readonly string FloodedLocKey = "Status.Buildings.Flooded";

		private static readonly string FloodedShortLocKey = "Status.Buildings.Flooded.Short";

		private readonly ILoc _loc;

		private StatusToggle _statusToggle;

		public FloodedBuildingStatus(ILoc loc)
		{
			_loc = loc;
		}

		public void Awake()
		{
			_statusToggle = StatusToggle.CreateNormalStatusWithAlertAndFloatingIcon("FloodedBuilding", _loc.T(FloodedLocKey), _loc.T(FloodedShortLocKey));
			GetComponent<FloodableObject>().Flooded += delegate
			{
				_statusToggle.Activate();
			};
			GetComponent<FloodableObject>().Unflooded += delegate
			{
				_statusToggle.Deactivate();
			};
		}

		public void Start()
		{
			GetComponent<StatusSubject>().RegisterStatus(_statusToggle);
		}
	}
}
