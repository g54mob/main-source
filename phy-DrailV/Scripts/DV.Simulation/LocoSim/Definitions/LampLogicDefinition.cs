using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace LocoSim.Definitions
{
	public class LampLogicDefinition : SimComponentDefinition
	{
		[Header("Behaviour setup")]
		public float offRangeMin;

		public float offRangeMax;

		[Space]
		public bool onRangeUsed;

		public float onRangeMin;

		public float onRangeMax;

		[Space]
		public bool blinkRangeUsed;

		public float blinkRangeMin;

		public float blinkRangeMax;

		[Space]
		public bool playAudioOnValueDrop;

		public bool playAudioOnValueRaise;

		[Space]
		public bool useAbsoluteInputValue;

		public PortReferenceDefinition inputReader = new PortReferenceDefinition(PortValueType.GENERIC, "INPUT");

		public readonly PortDefinition lampStateReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "LAMP_STATE");

		[Header("Optional")]
		[FuseId]
		public string powerFuseId;

		public override SimComponent InstantiateImplementation()
		{
			return new LampLogic(this);
		}
	}
}
