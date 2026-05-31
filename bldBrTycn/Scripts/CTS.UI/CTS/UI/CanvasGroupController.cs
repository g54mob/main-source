using System;
using System.Collections.Generic;
using CTS.Core;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.UI
{
	[DefaultExecutionOrder(-1)]
	public class CanvasGroupController : CTSBehaviour, ILockable
	{
		public enum CanvasGroupState
		{
			Shown = 0,
			Showing = 1,
			Hidding = 2,
			Hidden = 3
		}

		[SerializeField]
		[Inject(false)]
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private StringKey _canvasKey;

		[SerializeField]
		private bool _shownByDefault;

		[SerializeField]
		private bool _inPauseAnimation = true;

		private CanvasGroupState _stateBeforeDisabled;

		public StringKey IdKey => _canvasKey;

		public CanvasGroup CanvasGroup => _canvasGroup;

		public RectTransform RectTransform { get; private set; }

		[field: SerializeField]
		public bool CanBeGloballyHidden { get; private set; } = true;

		[field: SerializeField]
		public bool StayInteractable { get; private set; }

		public CanvasGroupState State { get; private set; }

		public bool IsShown => State != CanvasGroupState.Hidden;

		public bool IsHidden => State == CanvasGroupState.Hidden;

		public List<CanvasGroupTweenEffect> Effects { get; private set; } = new List<CanvasGroupTweenEffect>();

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public static event Action<CanvasGroupController, bool> SlidingPanel;

		public static event Action<CanvasGroupController, bool> PanelSlided;

		public event Action<bool> CanvasShowning;

		public event Action<bool> CanvasShowned;

		protected override void OnAwake()
		{
			RectTransform = _canvasGroup.GetComponent<RectTransform>();
			if (_canvasKey.IsValid())
			{
				MonoSingleton<CanvasGroupManager>.Instance.AddController(_canvasKey, this);
			}
			if (ObjectLock.IsLocked())
			{
				_stateBeforeDisabled = ((!_shownByDefault) ? CanvasGroupState.Hidden : CanvasGroupState.Shown);
			}
			else
			{
				State = ((!_shownByDefault) ? CanvasGroupState.Hidden : CanvasGroupState.Shown);
			}
		}

		private void Start()
		{
			PrepareCanvasGroup(_shownByDefault);
		}

		private void OnDestroy()
		{
			if (MonoSingleton<CanvasGroupManager>.InstanceExists() && _canvasKey.IsValid())
			{
				MonoSingleton<CanvasGroupManager>.Instance.RemoveController(_canvasKey);
			}
		}

		private void PrepareCanvasGroup(bool show)
		{
			if (!StayInteractable)
			{
				_canvasGroup.interactable = show;
				_canvasGroup.blocksRaycasts = show;
			}
			if (Effects.Count == 0)
			{
				_canvasGroup.alpha = (_shownByDefault ? 1f : 0f);
				return;
			}
			foreach (CanvasGroupTweenEffect effect in Effects)
			{
				effect.SetToResult(show);
			}
		}

		private void SetFinalState(bool shown)
		{
			State = ((!shown) ? CanvasGroupState.Hidden : CanvasGroupState.Shown);
			if (Effects.Count == 0)
			{
				_canvasGroup.alpha = (shown ? 1f : 0f);
			}
			this.CanvasShowned?.Invoke(shown);
			CanvasGroupController.PanelSlided?.Invoke(this, shown);
		}

		private void SetTransitionState(bool showing)
		{
			State = (showing ? CanvasGroupState.Showing : CanvasGroupState.Hidding);
		}

		public Tween ShowCanvasGroup(bool show, float duration = 0f, bool bypassLock = false)
		{
			if (!bypassLock && ObjectLock.IsLocked())
			{
				_stateBeforeDisabled = ((!show) ? CanvasGroupState.Hidden : CanvasGroupState.Shown);
				return null;
			}
			if (show)
			{
				CanvasGroupState state = State;
				if (state == CanvasGroupState.Shown || state == CanvasGroupState.Showing)
				{
					return null;
				}
			}
			if (!show)
			{
				CanvasGroupState state = State;
				if (state == CanvasGroupState.Hidden || state == CanvasGroupState.Hidding)
				{
					return null;
				}
			}
			_canvasGroup.DOKill();
			RectTransform.DOKill();
			SetTransitionState(show);
			this.CanvasShowning?.Invoke(show);
			CanvasGroupController.SlidingPanel?.Invoke(this, show);
			if (!StayInteractable)
			{
				_canvasGroup.interactable = show;
				_canvasGroup.blocksRaycasts = show;
			}
			Sequence sequence = DOTween.Sequence().SetUpdate(_inPauseAnimation);
			foreach (CanvasGroupTweenEffect effect in Effects)
			{
				if (duration > 0f)
				{
					sequence.Join(effect.PlayEffect(show));
					continue;
				}
				sequence.AppendCallback(delegate
				{
					effect.SetToResult(show);
				});
			}
			sequence.AppendCallback(delegate
			{
				SetFinalState(show);
			});
			return sequence.Play();
		}

		public void QuickHide()
		{
			ShowCanvasGroup(show: false, 0.25f);
		}

		public void QuickShow()
		{
			ShowCanvasGroup(show: true, 0.25f);
		}

		public Tween QuickHideWithTween()
		{
			return ShowCanvasGroup(show: false, 0.25f);
		}

		public Tween QuickShowWithTween()
		{
			return ShowCanvasGroup(show: true, 0.25f);
		}

		public void InstantHide()
		{
			ShowCanvasGroup(show: false);
		}

		public void InstantShow()
		{
			ShowCanvasGroup(show: true);
		}

		public void QuickChangeVisibility(bool visible)
		{
			if (visible)
			{
				QuickShow();
			}
			else
			{
				QuickHide();
			}
		}

		[Button(null, EButtonEnableMode.Playmode)]
		private void Toggle()
		{
			switch (State)
			{
			case CanvasGroupState.Shown:
			case CanvasGroupState.Showing:
				QuickHide();
				break;
			case CanvasGroupState.Hidding:
			case CanvasGroupState.Hidden:
				QuickShow();
				break;
			}
		}

		void ILockable.OnLocked()
		{
			_stateBeforeDisabled = State;
			ShowCanvasGroup(show: false, 0.25f, bypassLock: true);
		}

		void ILockable.OnUnlocked()
		{
			CanvasGroupState stateBeforeDisabled = _stateBeforeDisabled;
			if (stateBeforeDisabled == CanvasGroupState.Shown || stateBeforeDisabled == CanvasGroupState.Showing)
			{
				QuickShow();
			}
		}
	}
}
