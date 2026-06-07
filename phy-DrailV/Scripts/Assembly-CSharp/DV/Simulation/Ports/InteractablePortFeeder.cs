using DV.CabControls;
using DV.Simulation.Controllers;
using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Ports
{
	public class InteractablePortFeeder : MonoBehaviour
	{
		[PortId(PortType.EXTERNAL_IN, PortValueType.CONTROL, false)]
		public string portId;

		private ControlImplBase ctrl;

		private Port port;

		private ControlBlocker controlBlocker;

		public void Init(Port port, ControlBlocker controlBlocker)
		{
			ctrl = base.gameObject.GetComponent<ControlImplBase>();
			if (ctrl == null)
			{
				Debug.LogError("Can't find ControlImplBase on " + base.gameObject.name + ". Ignoring init");
				return;
			}
			this.port = port;
			this.controlBlocker = controlBlocker;
			ctrl.SetValue(port.Value);
			port.ValueUpdatedInternally += PropagateSimValue;
			if (controlBlocker != null)
			{
				controlBlocker.BlockStateChanged += OnBlockStateChanged;
				OnBlockStateChanged(controlBlocker.isBlocked, controlBlocker.resetToZeroOnBlock);
			}
		}

		public void Deinit()
		{
			if (port != null)
			{
				port.ValueUpdatedInternally -= PropagateSimValue;
				ctrl.ValueChanged -= OnControlChanged;
				if (controlBlocker != null)
				{
					controlBlocker.BlockStateChanged -= OnBlockStateChanged;
				}
			}
		}

		public void SetupControlChangedListeners()
		{
			if (port != null)
			{
				ctrl.ValueChanged += OnControlChanged;
			}
		}

		private void OnControlChanged(ValueChangedEventArgs v)
		{
			port.ExternalValueUpdate(v.newValue);
		}

		private void OnBlockStateChanged(bool isBlocked, bool resetToZeroOnBlock)
		{
			if (isBlocked && resetToZeroOnBlock && !controlBlocker.MUSlaveBlock)
			{
				ctrl.SetValue(0f);
			}
			ctrl.BlockControl(isBlocked);
		}

		private void PropagateSimValue(float simValue)
		{
			if (ctrl.Value != simValue)
			{
				ctrl.SetValue(simValue);
			}
		}
	}
}
