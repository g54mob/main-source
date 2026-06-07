namespace GAudio
{
	public class GATNotchFilter : AGATBiQuad
	{
		protected override void CalcBiquad()
		{
			double num = 1.0 / (1.0 + _K / _Q + _KSq);
			_a0 = (1.0 + _KSq) * num;
			_a1 = 2.0 * (_KSq - 1.0) * num;
			_a2 = _a0;
			_b1 = _a1;
			_b2 = (1.0 - _K / _Q + _KSq) * num;
		}

		static GATNotchFilter()
		{
			AGATMonoFilter.RegisterMonoFilter("Notch", typeof(GATNotchFilter));
		}
	}
}
