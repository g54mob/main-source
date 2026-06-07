using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class PowerFunction : SimComponent
	{
		private readonly float multiplier;

		private readonly float exponent;

		private readonly PortReference input;

		private readonly Port output;

		public PowerFunction(PowerFunctionDefinition pfDef)
			: base(pfDef.ID)
		{
			multiplier = pfDef.multiplier;
			exponent = pfDef.exponent;
			input = AddPortReference(pfDef.input);
			output = AddPort(pfDef.output);
		}

		public override void InitializationAfterConnecting()
		{
			input.port.ValueUpdatedInternally += OnInPortUpdated;
		}

		public override void Tick(float delta)
		{
		}

		private void OnInPortUpdated(float newValue)
		{
			output.Value = multiplier * Mathf.Pow(newValue, exponent);
		}
	}
}
