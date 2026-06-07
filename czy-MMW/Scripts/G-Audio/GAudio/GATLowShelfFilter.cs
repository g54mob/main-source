namespace GAudio
{
	public class GATLowShelfFilter : AGATBiQuadPeak
	{
		protected override void CalcBiquad()
		{
			if (_peakGain >= 0f)
			{
				double num = 1.0 / (1.0 + 1.414213562373095 * _K + _KSq);
				_a0 = (1.0 + _sqrt2V * _K + _V * _K * _K) * num;
				_a1 = 2.0 * (_V * _K * _K - 1.0) * num;
				_a2 = (1.0 - _sqrt2V * _K + _V * _KSq) * num;
				_b1 = 2.0 * (_KSq - 1.0) * num;
				_b2 = (1.0 - 1.414213562373095 * _K + _KSq) * num;
			}
			else
			{
				double num = 1.0 / (1.0 + _sqrt2V * _K + _V * _KSq);
				_a0 = (1.0 + 1.414213562373095 * _K + _KSq) * num;
				_a1 = 2.0 * (_K * _K - 1.0) * num;
				_a2 = (1.0 - 1.414213562373095 * _K + _KSq) * num;
				_b1 = 2.0 * (_V * _K * _K - 1.0) * num;
				_b2 = (1.0 - _sqrt2V * _K + _V * _KSq) * num;
			}
		}

		static GATLowShelfFilter()
		{
			AGATMonoFilter.RegisterMonoFilter("Low Shelf", typeof(GATLowShelfFilter));
		}
	}
}
