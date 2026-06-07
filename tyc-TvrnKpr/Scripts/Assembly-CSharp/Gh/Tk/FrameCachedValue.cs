using System;

namespace Gh.Tk
{
	public class FrameCachedValue<T>
	{
		private T _cache;

		private Func<T> _evaluate;

		private int _previousFrameNumber;

		public bool IsCached => false;

		public T Value => default(T);

		public FrameCachedValue(Func<T> evaluate)
		{
		}

		public void Invalidate()
		{
		}

		public static implicit operator T(FrameCachedValue<T> v)
		{
			return default(T);
		}
	}
}
