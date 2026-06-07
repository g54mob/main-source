using LocoSim.Implementations;

namespace DV.Simulation.Controllers
{
	public class ControlsBlockController : ARefreshableChildrenController<ControlBlocker>
	{
		public void Init(SimulationFlow simFlow)
		{
			ControlBlocker[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Init(simFlow);
			}
		}

		private void OnDestroy()
		{
			ControlBlocker[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Deinit();
			}
		}

		public void MUSlaveBlockAllControls(bool block)
		{
			ControlBlocker[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].MUSlaveBlock = block;
			}
		}

		public ControlBlocker GetBlockDefinition(string portId)
		{
			ControlBlocker[] array = entries;
			foreach (ControlBlocker controlBlocker in array)
			{
				if (controlBlocker.blockedControlPortId == portId)
				{
					return controlBlocker;
				}
			}
			return null;
		}
	}
}
