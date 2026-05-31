using System;
using CTS.Core;
using CTS.UI;
using DG.Tweening;
using UnityEngine;

namespace CTS
{
	[RequireComponent(typeof(CanvasGroup), typeof(CanvasGroupController))]
	public class MenuScreen : MonoBehaviour, ILockable
	{
		private CanvasGroupController _canvasGroupController;

		[SerializeField]
		private bool _visibleWhenUnlocked = true;

		private Tween _currentTween;

		private WaitForLock _waitForLock;

		private WaitForUnlock _waitForUnlock;

		[field: SerializeField]
		public float TransitionDuration { get; private set; } = 0.5f;

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public YieldInstruction WaitForTransition()
		{
			if (_currentTween == null || !_currentTween.active)
			{
				return null;
			}
			return _currentTween.WaitForCompletion();
		}

		public WaitForLock WaitForLock()
		{
			return _waitForLock ?? (_waitForLock = new WaitForLock(this));
		}

		public WaitForUnlock WaitForUnlock()
		{
			return _waitForUnlock ?? (_waitForUnlock = new WaitForUnlock(this));
		}

		protected virtual void Awake()
		{
			_canvasGroupController = GetComponent<CanvasGroupController>();
		}

		public Tween Show(bool show)
		{
			return Show(show, TransitionDuration);
		}

		public Tween Show(bool show, float duration)
		{
			Tween tween = _canvasGroupController.ShowCanvasGroup(show, duration);
			if (tween == null)
			{
				return null;
			}
			Sequence sequence = DOTween.Sequence(_canvasGroupController).SetUpdate(isIndependentUpdate: true);
			sequence.Append(tween);
			if (show)
			{
				sequence.Append(OnShow());
			}
			else
			{
				sequence.Append(OnHide());
			}
			_currentTween = sequence;
			return sequence;
		}

		protected virtual Tween OnShow()
		{
			return DOTween.Sequence().SetUpdate(isIndependentUpdate: true);
		}

		protected virtual Tween OnHide()
		{
			return DOTween.Sequence().SetUpdate(isIndependentUpdate: true);
		}

		void ILockable.OnLocked()
		{
			Show(!_visibleWhenUnlocked);
		}

		void ILockable.OnUnlocked()
		{
			Show(_visibleWhenUnlocked);
		}
	}
}
