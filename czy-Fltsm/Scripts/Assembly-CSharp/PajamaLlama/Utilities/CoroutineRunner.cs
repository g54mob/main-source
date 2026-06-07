using System.Collections;
using System.Collections.Generic;

namespace PajamaLlama.Utilities
{
	public class CoroutineRunner
	{
		private static CoroutineRunner _instance;

		private Stack<IEnumerator> _stack = new Stack<IEnumerator>();

		private IEnumerator _activeCoroutine;

		public static void RunCoroutine(IEnumerator coroutine)
		{
			if (_instance == null)
			{
				_instance = new CoroutineRunner();
			}
			_instance.Run(coroutine);
		}

		private void Run(IEnumerator coroutine)
		{
			_stack.Push(coroutine);
			while (_stack.TryPop(out _activeCoroutine))
			{
				while (_activeCoroutine.MoveNext())
				{
					if (_activeCoroutine.Current is IEnumerator activeCoroutine)
					{
						_stack.Push(_activeCoroutine);
						_activeCoroutine = activeCoroutine;
					}
				}
			}
			_activeCoroutine = null;
		}

		public static bool IsRunning(object obj)
		{
			if (_instance != null)
			{
				return _instance._activeCoroutine == obj;
			}
			return false;
		}
	}
}
