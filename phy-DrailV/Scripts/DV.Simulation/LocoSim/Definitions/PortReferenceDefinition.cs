using System;

namespace LocoSim.Definitions
{
	[Serializable]
	public class PortReferenceDefinition
	{
		public PortValueType valueType;

		public string ID;

		public bool writeAllowed;

		public PortReferenceDefinition(PortValueType valueType, string iD, bool writeAllowed = false)
		{
			this.valueType = valueType;
			this.writeAllowed = writeAllowed;
			ID = iD;
		}
	}
}
