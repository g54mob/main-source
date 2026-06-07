namespace LocoSim.Implementations
{
	public class PIDController
	{
		private float prevError;

		public float ProportionalGain { get; set; }

		public float DifferentialGain { get; set; }

		public float IntegralGain { get; set; }

		public float IntegralMax { get; set; }

		public float IntegralMin { get; set; }

		public float Integral { get; set; }

		public float ProportionalTerm { get; set; }

		public float DerivativeTerm { get; set; }

		public float IntegralTerm { get; set; }

		private float Clamp(float value, float min, float max)
		{
			if (!(value < min))
			{
				if (!(value > max))
				{
					return value;
				}
				return max;
			}
			return min;
		}

		public float Update(float setPoint, float processVariable, float delta)
		{
			float num = setPoint - processVariable;
			ProportionalTerm = ProportionalGain * num;
			Integral = Clamp(Integral + num * delta, IntegralMin / IntegralGain, IntegralMax / IntegralGain);
			IntegralTerm = IntegralGain * Integral;
			DerivativeTerm = DifferentialGain * (num - prevError) / delta;
			prevError = num;
			return ProportionalTerm + IntegralTerm + DerivativeTerm;
		}

		public override string ToString()
		{
			return $"Pg={ProportionalGain},Ig={IntegralGain}[{IntegralMin},{IntegralMax}],Dg={DifferentialGain}," + $"P={ProportionalTerm},I={IntegralTerm}={IntegralGain}*{Integral}),D={DerivativeTerm}";
		}
	}
}
