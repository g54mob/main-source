using System;
using DG.Tweening;
using Dhs5.Utility.Updates;
using I2.Loc;
using Simulator;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_PaintingGameCircle : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		[Header("Disks")]
		[SerializeField]
		private RectTransform m_disksRoot;

		[SerializeField]
		private Image m_clickableDisk;

		[SerializeField]
		private Image m_insideDisk;

		[SerializeField]
		private Image m_movingDisk;

		[Header("Feedbacks")]
		[SerializeField]
		private SimulatorText m_feedbackText;

		[SerializeField]
		private Color m_successColor;

		[SerializeField]
		[TermsPopup("")]
		private string m_successTerm;

		[SerializeField]
		private Color m_failColor;

		[SerializeField]
		[TermsPopup("")]
		private string m_failTerm;

		private Action<bool, int> m_resultCallback;

		private float m_duration;

		private Vector2 m_range;

		private UpdateTimelineInstanceHandle m_handle;

		private int m_circlesPassed;

		private Sequence m_sequence;

		private Tween m_punch;

		private InputAction PaintAction => TransientManager<InputManager>.Instance.PaintInputAction;

		public void Init(RectTransform anchor, float duration, Vector2 range, Action<bool, int> resultCallback)
		{
			m_disksRoot.anchoredPosition = anchor.anchoredPosition;
			m_circlesPassed = 0;
			m_duration = duration;
			m_range = range;
			m_resultCallback = resultCallback;
			float x = m_insideDisk.rectTransform.rect.size.x;
			m_insideDisk.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x * m_range.x);
			m_insideDisk.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, x * m_range.x);
			float x2 = m_clickableDisk.rectTransform.rect.size.x;
			m_clickableDisk.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x2 * m_range.y);
			m_clickableDisk.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, x2 * m_range.y);
			Updater.CreateTimelineInstance(EUpdateChannel.CLASSIC, m_duration, out m_handle, loop: true);
			m_handle.Updated += OnUpdate;
			m_handle.EventTriggered += OnUpdateEventTriggered;
			m_handle.Play();
			PaintAction.started += OnSubmitAction;
		}

		private void OnUpdate(float deltaTime)
		{
			m_movingDisk.transform.localScale = Vector3.one * (1f - m_handle.NormalizedTime);
		}

		private void OnUpdateEventTriggered(EUpdateTimelineEventType eventType, ushort id)
		{
			if (eventType == EUpdateTimelineEventType.END)
			{
				m_circlesPassed++;
				if (m_circlesPassed >= PaintingSettings.PaintingGameMaxCirclesPassed)
				{
					SetResult(success: false);
				}
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			SetResult(m_range.Contains(1f - m_handle.NormalizedTime));
		}

		private void OnSubmitAction(InputAction.CallbackContext context)
		{
			SetResult(m_range.Contains(1f - m_handle.NormalizedTime));
			PaintAction.started -= OnSubmitAction;
		}

		private void SetResult(bool success)
		{
			if (m_sequence == null || !m_sequence.IsPlaying())
			{
				m_handle.Kill();
				m_feedbackText.enabled = true;
				m_feedbackText.SetTerm(success ? m_successTerm : m_failTerm);
				m_resultCallback?.Invoke(success, m_circlesPassed);
				m_sequence = DOTween.Sequence();
				m_sequence.Append(m_feedbackText.Text.DOColor(success ? m_successColor : m_failColor, 0.05f).SetEase(Ease.InCubic));
				m_sequence.Join(m_clickableDisk.DOColor(success ? m_successColor : m_failColor, 0.05f).SetEase(Ease.InCubic));
				m_punch = base.transform.DOPunchScale(Vector3.one / 2f, 0.3f, 0, 0.5f).SetEase(Ease.OutCubic);
				m_sequence.Append(m_feedbackText.Text.DOColor(Color.clear, 0.25f).SetEase(Ease.OutCubic));
				m_sequence.Join(m_clickableDisk.DOColor(Color.clear, 0.25f).SetEase(Ease.OutCubic));
				m_sequence.Join(m_movingDisk.DOColor(Color.clear, 0.25f).SetEase(Ease.OutCubic));
				m_sequence.SetUpdate(isIndependentUpdate: true);
				m_sequence.Play();
				m_sequence.OnComplete(delegate
				{
					UnityEngine.Object.Destroy(base.gameObject);
				});
			}
		}

		private void OnDestroy()
		{
			if (m_sequence.IsActive())
			{
				m_sequence.Kill();
			}
			if (m_punch.IsActive())
			{
				m_punch.Kill();
			}
			PaintAction.started -= OnSubmitAction;
		}

		public void Kill()
		{
			m_handle.Kill();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
