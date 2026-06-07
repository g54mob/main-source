using System;

namespace LocoSim.Definitions
{
	[Serializable]
	public class PortDefinition
	{
		public PortType type;

		public PortValueType valueType;

		public string ID;

		public PortDefinition(PortType type, PortValueType valueType, string iD)
		{
			this.type = type;
			this.valueType = valueType;
			ID = iD;
		}
	}
}
