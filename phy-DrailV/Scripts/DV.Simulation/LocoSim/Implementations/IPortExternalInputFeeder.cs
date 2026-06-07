using System;

namespace LocoSim.Implementations
{
	public interface IPortExternalInputFeeder
	{
		event Action<float> InputChanged;

		void Init(float initValue);

		void PropagateSimValue(float simValue);
	}
}
