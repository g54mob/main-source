using System;
using System.Collections.Generic;

namespace MoreMountains.Tools
{
	public struct MMReferenceHolder<T> : IDisposable where T : class
	{
		private static List<WeakReference<T>> _instances = new List<WeakReference<T>>(2);

		private WeakReference<T> _instance;

		public static T Any
		{
			get
			{
				if (_instances == null || _instances.Count <= 0 || !_instances[0].TryGetTarget(out var target))
				{
					return null;
				}
				return target;
			}
		}

		public static IEnumerator<T> All
		{
			get
			{
				if (_instances == null)
				{
					yield break;
				}
				foreach (WeakReference<T> instance in _instances)
				{
					if (instance.TryGetTarget(out var target))
					{
						yield return target;
					}
				}
			}
		}

		public void Reference(T instance, bool cleanUp = false)
		{
			_instances = _instances ?? new List<WeakReference<T>>(1);
			if (cleanUp)
			{
				CleanUp();
			}
			if (instance != null)
			{
				_instance = new WeakReference<T>(instance);
				_instances.Add(_instance);
			}
		}

		public void Dispose()
		{
			if (_instance != null)
			{
				_instances?.Remove(_instance);
			}
		}

		public static void CleanUp()
		{
			RepackNonNullReferences();
		}

		private static void RepackNonNullReferences()
		{
			if (_instances == null)
			{
				return;
			}
			for (int num = _instances.Count - 1; num >= 0; num--)
			{
				if (!_instances[num].TryGetTarget(out var _))
				{
					_instances.RemoveAt(num);
				}
			}
		}

		public static T First(Func<T, bool> selector)
		{
			if (_instances == null)
			{
				return null;
			}
			if (selector == null)
			{
				return Any;
			}
			foreach (WeakReference<T> instance in _instances)
			{
				if (instance.TryGetTarget(out var target) && selector(target))
				{
					return target;
				}
			}
			return null;
		}
	}
}
