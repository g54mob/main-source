using System;
using System.Collections;
using CTS.Core;
using CTS.Core.Pooling;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace CTS
{
	public class VFXTimer : MonoBehaviour, IPoolable, IPoolCallbackReceiver
	{
		[SerializeField]
		private bool _playOnEnable = true;

		[SerializeField]
		[HideIf("IsLoop")]
		private float _duration = 1f;

		[SerializeField]
		private bool _stopOnDisable = true;

		[SerializeField]
		private float _delayBeforeDestroy = 1f;

		[SerializeField]
		private bool _useStaticCoroutines;

		private Coroutine _timerRoutine;

		[field: SerializeField]
		public bool IsLoop { get; private set; }

		[field: Header("Events")]
		[field: SerializeField]
		public UnityEvent Started { get; private set; }

		[field: SerializeField]
		public UnityEvent Stopped { get; private set; }

		public bool IsPlaying { get; private set; }

		PoolGuid IPoolable.PoolGuid { get; set; }

		public event Action<VFXTimer> ReturnedToPool;

		private void OnEnable()
		{
			if (!IsPlaying && _playOnEnable)
			{
				Play();
			}
		}

		private void OnDisable()
		{
			if (_stopOnDisable)
			{
				Stop();
			}
		}

		void IPoolCallbackReceiver.OnPulled()
		{
		}

		void IPoolCallbackReceiver.OnPushed()
		{
			this.ReturnedToPool?.Invoke(this);
		}

		public void Play()
		{
			if (IsPlaying)
			{
				Stop();
			}
			IsPlaying = true;
			Started.Invoke();
			if (!IsLoop)
			{
				if (_useStaticCoroutines)
				{
					_timerRoutine = base.gameObject.scene.StartCoroutine(TimerRoutine());
				}
				else
				{
					_timerRoutine = StartCoroutine(TimerRoutine());
				}
			}
		}

		private IEnumerator TimerRoutine()
		{
			float endTime = Time.time + _duration;
			while (Time.time < endTime)
			{
				yield return null;
			}
			Stop();
		}

		public void Stop()
		{
			if (IsPlaying)
			{
				IsPlaying = false;
				Stopped.Invoke();
				if (_timerRoutine != null)
				{
					StopCoroutine(_timerRoutine);
					_timerRoutine = null;
				}
				if (_delayBeforeDestroy <= 0f)
				{
					Pooler.Push(this);
				}
				else if (_useStaticCoroutines)
				{
					base.gameObject.scene.StartCoroutine(DisableTimer());
				}
				else if (base.isActiveAndEnabled)
				{
					StartCoroutine(DisableTimer());
				}
				else
				{
					Pooler.Push(this);
				}
			}
		}

		private IEnumerator DisableTimer()
		{
			float endTime = Time.time + _delayBeforeDestroy;
			while (Time.time < endTime)
			{
				yield return null;
			}
			Pooler.Push(this);
		}
	}
}
