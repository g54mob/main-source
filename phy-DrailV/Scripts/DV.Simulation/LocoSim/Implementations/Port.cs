using System;
using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class Port
	{
		public readonly string id;

		public readonly PortType type;

		public readonly PortValueType valueType;

		private float value;

		private float prevValue;

		private Port connectedPort;

		public bool IsConnectedPort => connectedPort != null;

		public float Value
		{
			get
			{
				return value;
			}
			set
			{
				prevValue = this.value;
				this.value = value;
				if (this.value != prevValue)
				{
					this.ValueUpdatedInternally?.Invoke(this.value);
				}
				if ((type == PortType.OUT || type == PortType.FORWARD_OUT) && connectedPort != null)
				{
					connectedPort.Value = value;
				}
			}
		}

		public float Diff => value - prevValue;

		public event Action<float> ValueUpdatedInternally;

		public event Action<bool> PortConnectionChanged;

		public void ExternalValueUpdate(float newValue)
		{
			if (type != PortType.EXTERNAL_IN)
			{
				Debug.LogError($"Unexpected state: Attempted to externally feed port that isn't {PortType.EXTERNAL_IN}! Ignoring request");
			}
			else
			{
				Value = newValue;
			}
		}

		public Port(string compId, PortDefinition portDef, float defaultValue = 0f)
		{
			id = SimConsts.GetFullId(compId, portDef.ID);
			type = portDef.type;
			valueType = portDef.valueType;
			value = defaultValue;
			prevValue = defaultValue;
		}

		public void ConnectPort(Port port)
		{
			if (connectedPort != null)
			{
				Debug.LogError("Unexpexted state: Can't connect [" + id + "] to [" + port.id + "], because it's already connected to [" + connectedPort.id + "]. Check connection setup!");
			}
			else
			{
				connectedPort = port;
				this.PortConnectionChanged?.Invoke(obj: true);
				port.connectedPort = this;
				port.PortConnectionChanged?.Invoke(obj: true);
			}
		}

		public void DisconnectPort()
		{
			if (connectedPort == null)
			{
				Debug.LogError("Unexpexted state: Can't disconnect [" + id + "] port, because it's already disconnected.");
				return;
			}
			if (type != PortType.FORWARD_OUT)
			{
				Debug.LogError($"Unexpected state: Attempted to disconnect port that isn't {PortType.FORWARD_OUT}! Ignoring request");
				return;
			}
			connectedPort.connectedPort = null;
			connectedPort.PortConnectionChanged?.Invoke(obj: false);
			Value = 0f;
			connectedPort.Value = 0f;
			connectedPort = null;
			this.PortConnectionChanged?.Invoke(obj: false);
		}
	}
}
