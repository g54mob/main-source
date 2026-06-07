using System;
using System.Collections;
using UnityEngine;

namespace Jundroo.Common.Coroutines
{
	public class RunOnceOnNextUpdate
	{
		private class RunOnceOnNextUpdateManager : MonoBehaviour
		{
		}

		private static RunOnceOnNextUpdateManager _manager;

		private Action _action;

		private MonoBehaviour _monoBehaviour;

		private bool _queued;

		public RunOnceOnNextUpdate(MonoBehaviour monoBehaviour, Action action)
		{
			_monoBehaviour = monoBehaviour;
			_action = action;
			_queued = false;
		}

		public void Queue()
		{
			if (!_queued)
			{
				_queued = true;
				GetManager().StartCoroutine(Coroutine());
			}
		}

		private static RunOnceOnNextUpdateManager GetManager()
		{
			if (_manager == null)
			{
				_manager = new GameObject("RunOnceOnNextUpdate_Manager").AddComponent<RunOnceOnNextUpdateManager>();
			}
			return _manager;
		}

		private IEnumerator Coroutine()
		{
			yield return null;
			while (_monoBehaviour != null && !_monoBehaviour.isActiveAndEnabled)
			{
				yield return null;
			}
			_queued = false;
			if (_monoBehaviour != null)
			{
				_action();
			}
		}
	}
}
