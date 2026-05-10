using System;
using System.Collections;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.Utilities
{
	public abstract class MonoRoutine : MonoBehaviour
	{
		[SerializeField]
		[ShowIf("PlayOnEnable")]
		private bool _playOnce = true;

		[SerializeField]
		private bool _forceEnabled;

		private int _playCount;

		private Coroutine _running;

		[field: SerializeField]
		public bool PlayOnEnable { get; set; }

		protected virtual string Name => "Routine";

		public event Action OnComplete;

		private void OnEnable()
		{
			if (PlayOnEnable && (!_playOnce || _playCount <= 0))
			{
				Play();
			}
		}

		public Coroutine Play()
		{
			_playCount++;
			if (_forceEnabled)
			{
				if (!base.gameObject.activeSelf)
				{
					base.gameObject.SetActive(value: true);
				}
				_running = StartCoroutine(ThisRoutine());
				return _running;
			}
			if (base.gameObject.activeInHierarchy)
			{
				_running = StartCoroutine(ThisRoutine());
				return _running;
			}
			return null;
		}

		public void Stop()
		{
			if (_running != null)
			{
				StopCoroutine(_running);
				OnStop();
			}
		}

		protected virtual void OnStop()
		{
		}

		private IEnumerator ThisRoutine()
		{
			yield return Routine();
			_running = null;
			this.OnComplete?.Invoke();
		}

		protected abstract IEnumerator Routine();

		public void ResetPlayCount()
		{
			_playCount = 0;
		}
	}
}
