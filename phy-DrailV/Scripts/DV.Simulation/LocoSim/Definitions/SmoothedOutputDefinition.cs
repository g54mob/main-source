using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace LocoSim.Definitions
{
	public class SmoothedOutputDefinition : SimComponentDefinition
	{
		[Header("0 is treated as instant change")]
		public float smoothTime = 1f;

		[FuseId]
		public string powerFuseId;

		public readonly PortReferenceDefinition control = new PortReferenceDefinition(PortValueType.CONTROL, "CONTROL");

		public readonly PortDefinition outReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "OUTPUT");

		public override SimComponent InstantiateImplementation()
		{
			return new SmoothedOutput(this);
		}
	}
}
