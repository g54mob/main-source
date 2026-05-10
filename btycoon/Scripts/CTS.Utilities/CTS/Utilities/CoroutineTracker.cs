using System.Collections;
using UnityEngine;

namespace CTS.Utilities
{
	public class CoroutineTracker : CustomYieldInstruction
	{
		protected readonly MonoBehaviour Behaviour;

		private Coroutine _coroutine;

		public override bool keepWaiting => !IsCompleted;

		public bool IsCompleted => _coroutine == null;

		protected CoroutineTracker(MonoBehaviour behaviour)
		{
			Behaviour = behaviour;
		}

		protected virtual void Start(IEnumerator coroutine)
		{
			if (Behaviour.gameObject.scene.isLoaded)
			{
				StaticCoroutines.StartStaticCoroutine(Routine(Behaviour, coroutine));
			}
		}

		public static implicit operator Coroutine(CoroutineTracker tracker)
		{
			return tracker._coroutine;
		}

		public static CoroutineTracker Start(MonoBehaviour behaviour, IEnumerator coroutine)
		{
			CoroutineTracker coroutineTracker = new CoroutineTracker(behaviour);
			coroutineTracker.Start(coroutine);
			return coroutineTracker;
		}

		private IEnumerator Routine(MonoBehaviour behaviour, IEnumerator coroutine)
		{
			_coroutine = behaviour.StartCoroutine(coroutine);
			yield return _coroutine;
			OnStopped();
			_coroutine = null;
		}

		public void Stop()
		{
			if (_coroutine != null)
			{
				Behaviour.StopCoroutine(_coroutine);
			}
		}

		protected virtual void OnStopped()
		{
		}
	}
}
