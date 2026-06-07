using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class PortReference
	{
		public readonly string id;

		internal Port port;

		private readonly float defaultValue;

		private readonly bool writeAllowed;

		public bool IsConnected => port != null;

		public float Value
		{
			get
			{
				if (port == null)
				{
					return defaultValue;
				}
				return port.Value;
			}
			set
			{
				if (!writeAllowed)
				{
					Debug.LogError("Write attempted, but not allowed on " + id + "! Skipping");
				}
				else
				{
					port?.ExternalValueUpdate(value);
				}
			}
		}

		public PortReference(string compId, PortReferenceDefinition portRefDef, float defaultValue = 0f)
		{
			id = SimConsts.GetFullId(compId, portRefDef.ID);
			writeAllowed = portRefDef.writeAllowed;
			this.defaultValue = defaultValue;
		}

		public void SetPortReference(Port port)
		{
			if (this.port != null)
			{
				Debug.LogError("Unexpected state: Can't connect [" + id + "] to [" + port.id + "], because it's already connected to [" + this.port.id + "]. Check connection setup!");
			}
			else
			{
				if (writeAllowed && port.type != PortType.EXTERNAL_IN)
				{
					Debug.LogError("Unexpected state: writeAllowed is possible only for PortType.EXTERNAL_IN!");
				}
				this.port = port;
			}
		}
	}
}
