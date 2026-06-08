using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using Timberborn.MechanicalSystem;
using Timberborn.TickSystem;

namespace Timberborn.WaterBuildings
{
	internal class WaterMoverPowerConsumptionSwitch : TickableComponent, IAwakableComponent, IFinishedStateListener
	{
		private MechanicalBuilding _mechanicalBuilding;

		private WaterMover _waterMover;

		public void Awake()
		{
			_mechanicalBuilding = GetComponent<MechanicalBuilding>();
			_waterMover = GetComponent<WaterMover>();
			DisableComponent();
		}

		public void OnEnterFinishedState()
		{
			EnableComponent();
		}

		public void OnExitFinishedState()
		{
			DisableComponent();
		}

		public override void StartTickable()
		{
			UpdatePowerConsumption();
		}

		public override void Tick()
		{
			UpdatePowerConsumption();
		}

		private void UpdatePowerConsumption()
		{
			_mechanicalBuilding.SetConsumptionDisabled(!_waterMover.IsWaterFlowPossible());
		}
	}
}
