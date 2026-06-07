using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Cars
{
	public abstract class APoweredControlHandler : MonoBehaviour
	{
		[PortId(PortValueType.CONTROL, false)]
		public string controlId;

		[FuseId]
		public string powerFuseId;

		protected Fuse powerFuse;

		protected Port controlPort;

		public virtual void Init(TrainCar car, SimulationFlow simFlow)
		{
			if (simFlow.TryGetFuse(powerFuseId, out powerFuse, canBeNull: true))
			{
				powerFuse.StateUpdated += OnFuseChanged;
			}
			if (simFlow.TryGetPort(controlId, out controlPort))
			{
				OnControlChanged(controlPort.Value);
				controlPort.ValueUpdatedInternally += OnControlChanged;
			}
			else
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: APoweredControlHandler isn't initialized properly. Destroying self", this);
				Object.Destroy(this);
			}
		}

		protected virtual void OnDestroy()
		{
			if (powerFuse != null)
			{
				powerFuse.StateUpdated -= OnFuseChanged;
			}
			if (controlPort != null)
			{
				controlPort.ValueUpdatedInternally -= OnControlChanged;
			}
		}

		protected abstract void OnControlChanged(float controlValue);

		protected abstract void OnFuseChanged(bool state);
	}
}
