using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using Timberborn.MechanicalSystem;
using Timberborn.TickSystem;
using Timberborn.WorkSystem;

namespace Timberborn.Workshops
{
	public class WorkplacePowerConsumptionSwitch : TickableComponent, IAwakableComponent, IFinishedStateListener
	{
		private MechanicalBuilding _mechanicalBuilding;

		private Workplace _workplace;

		public void Awake()
		{
			_mechanicalBuilding = GetComponent<MechanicalBuilding>();
			_workplace = GetComponent<Workplace>();
			DisableComponent();
		}

		public void OnEnterFinishedState()
		{
			if ((bool)_mechanicalBuilding)
			{
				EnableComponent();
			}
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
			_mechanicalBuilding.SetConsumptionDisabled(!_workplace.AnyWorkerHasJobRunning());
		}
	}
}
