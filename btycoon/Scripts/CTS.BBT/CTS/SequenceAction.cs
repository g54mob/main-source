using System;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public abstract class SequenceAction : CTSBehaviour
	{
		[SerializeField]
		[MinMaxSlider(0f, 20f)]
		private Vector2 _startDelay = Vector2.zero;

		[SerializeField]
		[ShowIf("HasDelay")]
		private bool _unscaledTimedDelay;

		private bool HasDelay => _startDelay.x > 0f;

		public float StartDelay => UnityEngine.Random.Range(_startDelay.x, _startDelay.y);

		public bool IsUnscaledTimeDelay => _unscaledTimedDelay;

		public event Action<bool> Stopped;

		public event Action<bool> Started;

		public abstract bool IsValid();

		public abstract void Play(ActionSequence sequence);

		protected void SendStartEvent(bool started)
		{
			this.Started?.Invoke(started);
		}

		protected void FinishAction(bool wasSuccessful)
		{
			this.Stopped?.Invoke(wasSuccessful);
		}
	}
}
