using Kitchen.NetworkSupport;
using UnityEngine;

namespace Kitchen
{
	public abstract class Interpolator<T>
	{
		public IValueInterpolator<T> ValueInterpolator;

		public float MaxInterpolationTime = 1f;

		public RemoteTime LastUpdateRemote { get; protected set; }

		public float LastUpdateLocal { get; protected set; }

		public T Value { get; private set; }

		protected float TimeSinceLastLocal => Time.time - LastUpdateLocal;

		public Interpolator(IValueInterpolator<T> value_interpolator)
		{
			ValueInterpolator = value_interpolator;
		}

		public abstract T GetUpdate(T current);

		public abstract void Report(T value, RemoteTime time, bool force = false);

		protected void UpdateValue(T value, RemoteTime time)
		{
			Value = value;
			LastUpdateRemote = time;
			LastUpdateLocal = Time.time;
		}
	}
}
