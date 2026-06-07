namespace GAudio
{
	public class GATPeakFilter : AGATBiQuadPeak
	{
		protected override void CalcBiquad()
		{
			if (_peakGain >= 0f)
			{
				double num = 1.0 / (1.0 + 1.0 / _Q * _K + _KSq);
				_a0 = (1.0 + _V / _Q * _K + _KSq) * num;
				_a1 = 2.0 * (_KSq - 1.0) * num;
				_a2 = (1.0 - _V / _Q * _K + _KSq) * num;
				_b1 = _a1;
				_b2 = (1.0 - 1.0 / _Q * _K + _KSq) * num;
			}
			else
			{
				double num = 1.0 / (1.0 + _V / _Q * _K + _KSq);
				_a0 = (1.0 + 1.0 / _Q * _K + _KSq) * num;
				_a1 = 2.0 * (_KSq - 1.0) * num;
				_a2 = (1.0 - 1.0 / _Q * _K + _KSq) * num;
				_b1 = _a1;
				_b2 = (1.0 - _V / _Q * _K + _KSq) * num;
			}
		}

		static GATPeakFilter()
		{
			AGATMonoFilter.RegisterMonoFilter("Peak", typeof(GATPeakFilter));
		}
	}
}
