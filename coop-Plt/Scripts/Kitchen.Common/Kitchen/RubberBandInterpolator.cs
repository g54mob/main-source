using Kitchen.NetworkSupport;

namespace Kitchen
{
	public class RubberBandInterpolator<T> : Interpolator<T>
	{
		public override T GetUpdate(T current)
		{
			if (!(ValueInterpolator.Distance(current, base.Value) > 0.5f))
			{
				return ValueInterpolator.Lerp(current, base.Value, 0.5f);
			}
			return base.Value;
		}

		public override void Report(T value, RemoteTime time, bool force = false)
		{
			UpdateValue(value, time);
		}

		public RubberBandInterpolator(IValueInterpolator<T> value_interpolator)
			: base(value_interpolator)
		{
		}
	}
}
