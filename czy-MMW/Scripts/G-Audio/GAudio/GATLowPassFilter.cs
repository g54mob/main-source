namespace GAudio
{
	public class GATLowPassFilter : AGATBiQuad
	{
		protected override void CalcBiquad()
		{
			double num = 1.0 / (1.0 + _K / _Q + _KSq);
			_a0 = _KSq * num;
			_a1 = 2.0 * _a0;
			_a2 = _a0;
			_b1 = 2.0 * (_KSq - 1.0) * num;
			_b2 = (1.0 - _K / _Q + _KSq) * num;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
		}

		static GATLowPassFilter()
		{
			AGATMonoFilter.RegisterMonoFilter("Low Pass", typeof(GATLowPassFilter));
		}
	}
}
