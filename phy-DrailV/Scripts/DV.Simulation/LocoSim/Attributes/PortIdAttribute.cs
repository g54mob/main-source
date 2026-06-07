using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Attributes
{
	public class PortIdAttribute : PropertyAttribute
	{
		public PortType[] typeFilters;

		public PortValueType[] valueTypeFilters;

		public bool local;

		public PortIdAttribute(PortType[] typeFilters = null, PortValueType[] valueTypeFilters = null, bool local = false)
		{
			this.typeFilters = typeFilters;
			this.valueTypeFilters = valueTypeFilters;
			this.local = local;
		}

		public PortIdAttribute(PortType typeFilter, PortValueType valueTypeFilter, bool local = false)
		{
			typeFilters = new PortType[1] { typeFilter };
			valueTypeFilters = new PortValueType[1] { valueTypeFilter };
			this.local = local;
		}

		public PortIdAttribute(PortType typeFilter, bool local = false)
		{
			typeFilters = new PortType[1] { typeFilter };
			valueTypeFilters = null;
			this.local = local;
		}

		public PortIdAttribute(PortValueType valueTypeFilter, bool local = false)
		{
			typeFilters = null;
			valueTypeFilters = new PortValueType[1] { valueTypeFilter };
			this.local = local;
		}
	}
}
