#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

namespace TH20
{
	public class GameEvent_Base<T> where T : IGameEventCallback
	{
		private readonly List<T> _callbacks = new List<T>();

		[DontSave]
		private readonly List<T> _readonlyCallbacks = new List<T>();

		[Conditional("ASSERTS_ENABLED")]
		public void VerifyIsNull()
		{
			if (_callbacks.Count != 0)
			{
				Logging.Error("Event still has {0} registered callbacks upon being destroyed:\n\t{1}", _callbacks.Count, string.Join("\n\t", _callbacks.Select((T x) => x.ToString()).ToArray()));
			}
			if (_readonlyCallbacks.Count != 0)
			{
				Logging.Error("Event still has {0} registered readonly callbacks upon being destroyed:\n\t{1}.", _readonlyCallbacks.Count, string.Join("\n\t", _readonlyCallbacks.Select((T x) => x.ToString()).ToArray()));
			}
		}

		public void AddAndDontSave(T callback)
		{
			_readonlyCallbacks.Add(callback);
		}

		public void Add(T callback)
		{
			if (ShouldNotSaveCallback(callback))
			{
				_readonlyCallbacks.Add(callback);
			}
			else
			{
				_callbacks.Add(callback);
			}
		}

		private static bool ShouldNotSaveCallback(T callback)
		{
			if (callback.GetType().GetCustomAttributes(inherit: true).Any((object x) => x.GetType() == typeof(DontSaveAttribute)))
			{
				return true;
			}
			if (callback.GetType().IsSubclassOf(typeof(UnityEngine.Object)))
			{
				return true;
			}
			return false;
		}

		public void Remove(T callback)
		{
			_callbacks.Remove(callback);
			_readonlyCallbacks.Remove(callback);
		}

		protected void IterateCallbacks(Action<T> call)
		{
			for (int num = _callbacks.Count - 1; num >= 0; num--)
			{
				T obj = _callbacks[num];
				call(obj);
			}
			for (int num2 = _readonlyCallbacks.Count - 1; num2 >= 0; num2--)
			{
				T obj2 = _readonlyCallbacks[num2];
				call(obj2);
			}
		}
	}
}
