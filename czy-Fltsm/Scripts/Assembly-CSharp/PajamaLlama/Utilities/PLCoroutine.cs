using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PajamaLlama.Utilities
{
	public class PLCoroutine
	{
		private static Stack<PLCoroutine> _pool = new Stack<PLCoroutine>();

		private static List<PLCoroutine> _coroutinesToValidate = new List<PLCoroutine>();

		private Coroutine _coroutine;

		private MonoBehaviour _motor;

		private Stack<IEnumerator> _routines = new Stack<IEnumerator>();

		public UnityEvent<PLCoroutine, bool> Completed { get; } = new UnityEvent<PLCoroutine, bool>();

		private PLCoroutine()
		{
		}

		public static PLCoroutine Start(IEnumerator routine, MonoBehaviour motor = null)
		{
			if (!_pool.TryPop(out var result))
			{
				result = new PLCoroutine();
			}
			result._motor = motor;
			if (motor == null)
			{
				result._coroutine = motor.StartCoroutine(result.Run(routine));
			}
			else
			{
				result._coroutine = CoroutineMotor.StartRoutine(result.Run(routine));
			}
			return result;
		}

		public static void Stop(MonoBehaviour motor)
		{
			foreach (PLCoroutine item in _coroutinesToValidate)
			{
				if (item._motor == motor)
				{
					item.Stop();
				}
			}
		}

		public static bool HasActiveCoroutines(MonoBehaviour motor)
		{
			foreach (PLCoroutine item in _coroutinesToValidate)
			{
				if (item._motor == motor)
				{
					return true;
				}
			}
			return false;
		}

		public static void ValidateCoroutines()
		{
			int count = _coroutinesToValidate.Count;
			while (0 < count--)
			{
				_coroutinesToValidate[count].Validate();
			}
		}

		public void Stop()
		{
			if (_coroutine != null)
			{
				if ((bool)_motor)
				{
					_motor.StopCoroutine(_coroutine);
				}
				else
				{
					CoroutineMotor.StopRoutine(_coroutine);
				}
				OnCompleted(stopped: true);
			}
		}

		private IEnumerator Run(IEnumerator routine)
		{
			_routines.Push(routine);
			if ((bool)_motor)
			{
				_coroutinesToValidate.AddUnique(this);
			}
			while (_routines.Count > 0)
			{
				bool flag;
				try
				{
					flag = routine.MoveNext();
				}
				catch (Exception innerException)
				{
					Debug.LogException(new Exception("Coroutine Exception", innerException));
					flag = false;
				}
				IEnumerator result;
				if (flag)
				{
					if (routine.Current is IEnumerator enumerator)
					{
						_routines.Push(routine);
						routine = enumerator;
					}
					else
					{
						yield return routine.Current;
					}
				}
				else if (_routines.TryPop(out result))
				{
					routine = result;
				}
			}
			OnCompleted();
		}

		private void Validate()
		{
			if (!_motor || !_motor.gameObject.activeSelf)
			{
				OnCompleted(stopped: true);
			}
		}

		private void OnCompleted(bool stopped = false)
		{
			Completed.Invoke(this, stopped);
			Completed.RemoveAllListeners();
			_coroutine = null;
			_motor = null;
			_coroutinesToValidate.Remove(this);
			_pool.Push(this);
		}
	}
}
