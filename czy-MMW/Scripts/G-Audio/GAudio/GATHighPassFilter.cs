namespace GAudio
{
	public class GATHighPassFilter : AGATBiQuad
	{
		protected override void CalcBiquad()
		{
			double num = 1.0 / (1.0 + _K / _Q + _KSq);
			_a0 = _K / _Q * num;
			_a1 = 0.0;
			_a2 = 0.0 - _a0;
			_b1 = 2.0 * (_KSq - 1.0) * num;
			_b2 = (1.0 - _K / _Q + _KSq) * num;
		}

		static GATHighPassFilter()
		{
			AGATMonoFilter.RegisterMonoFilter("High Pass", typeof(GATHighPassFilter));
		}
	}
}
