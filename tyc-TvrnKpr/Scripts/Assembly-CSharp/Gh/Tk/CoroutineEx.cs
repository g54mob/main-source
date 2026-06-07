using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class CoroutineEx : IStateProvider
	{
		protected class SetCurrentCoroutine : IDisposable
		{
			private CoroutineEx _previous;

			public SetCurrentCoroutine(CoroutineEx current)
			{
			}

			public void Dispose()
			{
			}
		}

		private static List<CoroutineEx> _routines;

		[ThreadStatic]
		private static CoroutineEx _current;

		internal static Dictionary<string, DataStore> _routinesStateData;

		private List<Tuple<string, int>> _tweenKeys;

		private DataStore _stateData;

		private IEnumerator _routine;

		private CoroutineState _state;

		public Action onFinish;

		private static System.Random _lazySeedRandomizer;

		public static CoroutineEx Current => null;

		public List<Tuple<string, int>> TweenKeys => null;

		protected DataStore StateData => null;

		public CoroutineEx Parent { get; private set; }

		public string StorageId { get; private set; }

		internal int LazySeed => 0;

		public T GetStateVariable<T>(string key)
		{
			return default(T);
		}

		public T GetOrSetStateVariable<T>(string key, T fallback)
		{
			return default(T);
		}

		public T GetStateVariable<T>(string key, T fallback)
		{
			return default(T);
		}

		public bool HasStateVariable(string key)
		{
			return false;
		}

		public void SetStateVariable<T>(string key, T value)
		{
		}

		public void RemoveStateVariable(string key)
		{
		}

		public bool IsPartActiveOrSet(int value, string key = "default")
		{
			return false;
		}

		public static void UpdateRoutines()
		{
		}

		public CoroutineEx(IEnumerator routine, string storageId = null)
		{
		}

		private bool HandleCurrent()
		{
			return false;
		}

		public void Update()
		{
		}

		public static CoroutineExWaitFor WaitForSeconds(float duration, Func<bool> abortCondition = null, string instanceId = null, bool unscaledTime = false)
		{
			return null;
		}

		public static CoroutineExWaitFor WaitFor(Func<bool> endCondition)
		{
			return null;
		}

		public static CoroutineExWaitFor WaitForTweensToFinish(params Transform[] targets)
		{
			return null;
		}

		internal static void AbortAll()
		{
		}
	}
}
