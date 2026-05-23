using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

namespace Barmetler.RoadSystem.Util
{
	public class AsyncUpdater<T>
	{
		private T _data;

		private readonly Func<T> _updater;

		private readonly MonoBehaviour _mb;

		private readonly object _dispatcherLock = new object();

		private readonly object _dataLock = new object();

		private bool _coroutineRunning;

		private bool _updateQueued;

		private readonly float _interval;

		private readonly Stopwatch _sw = new Stopwatch();

		public AsyncUpdater(MonoBehaviour mb, Func<T> updater, T initialData, float interval = 0f)
		{
			_mb = mb;
			_updater = updater;
			_interval = interval;
			_data = initialData;
		}

		public AsyncUpdater(MonoBehaviour mb, Func<T> updater)
		{
			_mb = mb;
			_updater = updater;
		}

		public void Update()
		{
			_updateQueued = true;
			MaybeDispatchCoroutine();
		}

		public T GetData()
		{
			lock (_dataLock)
			{
				return _data;
			}
		}

		private void MaybeDispatchCoroutine()
		{
			lock (_dispatcherLock)
			{
				if (!_coroutineRunning && _updateQueued)
				{
					_updateQueued = false;
					_coroutineRunning = true;
					_mb.StartCoroutine(CallUpdater());
				}
			}
		}

		private IEnumerator CallUpdater()
		{
			_sw.Restart();
			T newData = _updater();
			_sw.Stop();
			float num = (float)((double)_interval - (double)_sw.ElapsedMilliseconds / 1000000.0);
			if (num > 0f)
			{
				yield return new WaitForSeconds(num);
			}
			lock (_dataLock)
			{
				_data = newData;
			}
			_coroutineRunning = false;
			MaybeDispatchCoroutine();
			yield return null;
		}
	}
}
