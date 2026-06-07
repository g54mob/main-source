using System;
using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class MultiplePortDecoderEncoderDefinition : SimComponentDefinition
	{
		[Serializable]
		public class FloatArray
		{
			public float[] array = Array.Empty<float>();

			public float this[int i]
			{
				get
				{
					return array[i];
				}
				set
				{
					array[i] = value;
				}
			}
		}

		public int combinations;

		public float defaultOutputValue;

		public bool useDefaultValueOnMatchNotFound = true;

		public bool matchClosestOutputValue;

		public FloatArray[] values = Array.Empty<FloatArray>();

		public PortDefinition[] inputPorts = Array.Empty<PortDefinition>();

		public PortDefinition outputPort;

		public bool saveState;

		public override SimComponent InstantiateImplementation()
		{
			return new MultiplePortDecoderEncoder(this);
		}
	}
}
