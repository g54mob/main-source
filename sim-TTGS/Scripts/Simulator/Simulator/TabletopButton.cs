using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

namespace Simulator
{
	public class TabletopButton : Button
	{
		[SerializeField]
		private bool m_holdToClick;

		[SerializeField]
		private float m_holdTime;

		[SerializeField]
		private Image m_holdFillerImage;

		private Tween m_delayCallTween;

		private bool m_canHold = true;

		public Action HoldCompleted;

		private bool m_cancelRegistered;

		private InputSystemUIInputModule UIInputModule => TransientManager<InputManager>.Instance.UIInputModule;

		private bool CanHold()
		{
			if (m_holdToClick && m_canHold)
			{
				return IsInteractable();
			}
			return false;
		}

		protected void SetCanHold(bool canHold)
		{
			m_canHold = canHold;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (m_holdToClick)
			{
				m_holdFillerImage.fillAmount = 0f;
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
			if (!CanHold())
			{
				base.OnPointerClick(eventData);
			}
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			if (CanHold())
			{
				StartDelay(eventData);
			}
			else
			{
				base.OnPointerDown(eventData);
			}
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
			if (CanHold())
			{
				KillDelayedCall();
				EventSystem current = EventSystem.current;
				if (current != null && current.currentSelectedGameObject == base.gameObject)
				{
					current.SetSelectedGameObject(null);
				}
			}
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			base.OnPointerExit(eventData);
			if (CanHold())
			{
				KillDelayedCall();
			}
		}

		public override void OnSubmit(BaseEventData eventData)
		{
			if (CanHold())
			{
				StartDelay(eventData);
			}
			else
			{
				base.OnSubmit(eventData);
			}
		}

		private void OnSubmitActionCanceled(InputAction.CallbackContext context)
		{
			KillDelayedCall();
		}

		public override void OnDeselect(BaseEventData eventData)
		{
			base.OnDeselect(eventData);
			if (CanHold())
			{
				KillDelayedCall();
			}
		}

		private void StartDelay(BaseEventData eventData)
		{
			KillDelayedCall();
			RegisterToCancel(register: true);
			m_delayCallTween = DOVirtual.Float(0f, 1f, m_holdTime, OnHoldProcess);
			m_delayCallTween.SetEase(Ease.Linear);
			m_delayCallTween.SetUpdate(isIndependentUpdate: true);
			m_delayCallTween.OnComplete(delegate
			{
				OnHoldComplete(eventData);
			});
			m_delayCallTween.OnKill(OnKillDelayedCall);
			m_delayCallTween.Play();
		}

		private void KillDelayedCall()
		{
			RegisterToCancel(register: false);
			m_delayCallTween?.Kill();
		}

		protected virtual void OnKillDelayedCall()
		{
			m_holdFillerImage.fillAmount = 0f;
			m_delayCallTween = null;
		}

		private void OnHoldProcess(float value)
		{
			m_holdFillerImage.fillAmount = value;
		}

		private void OnHoldComplete(BaseEventData eventData)
		{
			RegisterToCancel(register: false);
			if (eventData is PointerEventData eventData2)
			{
				base.OnPointerClick(eventData2);
			}
			else
			{
				OnSubmitHold(eventData);
			}
			HoldCompleted?.Invoke();
		}

		protected virtual void OnSubmitHold(BaseEventData eventData)
		{
			base.OnSubmit(eventData);
		}

		protected void RegisterToCancel(bool register)
		{
			if (m_cancelRegistered != register && UIInputModule != null)
			{
				m_cancelRegistered = register;
				if (register)
				{
					UIInputModule.submit.action.canceled += OnSubmitActionCanceled;
				}
				else
				{
					UIInputModule.submit.action.canceled -= OnSubmitActionCanceled;
				}
			}
		}
	}
}
