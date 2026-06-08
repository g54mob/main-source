using Kitchen.NetworkSupport;

namespace Kitchen
{
	public class InstantInterpolator<T> : Interpolator<T>
	{
		public override T GetUpdate(T current)
		{
			return base.Value;
		}

		public override void Report(T value, RemoteTime time, bool force = false)
		{
			UpdateValue(value, time);
		}

		public InstantInterpolator(IValueInterpolator<T> value_interpolator)
			: base(value_interpolator)
		{
		}
	}
}
