using System;
using System.Collections;
using Motorways.Audio;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Motorways.UI
{
	[RequireComponent(typeof(RectTransform))]
	[AddComponentMenu("UI/Touch Toggle", 35)]
	public class TouchToggle : VariableDeviceSelectable, IPointerDownHandler, IEventSystemHandler, ICanvasElement
	{
		public enum ToggleTransition
		{
			None = 0,
			Fade = 1
		}

		[Serializable]
		public class ToggleEvent : UnityEvent<bool>
		{
		}

		public ToggleTransition toggleTransition = ToggleTransition.Fade;

		public Graphic graphic;

		[SerializeField]
		private ToggleButtonGroup _group;

		public ToggleEvent onValueChanged = new ToggleEvent();

		[SerializeField]
		private Button.ButtonClickedEvent _onSelected = new Button.ButtonClickedEvent();

		[SerializeField]
		[FormerlySerializedAs("m_IsActive")]
		[Tooltip("Is the toggle currently on or off?")]
		private bool _isOn;

		public ToggleButtonGroup Group
		{
			get
			{
				return _group;
			}
			set
			{
				_group = value;
				PlayEffect(instant: true);
			}
		}

		public bool IsOn
		{
			get
			{
				return _isOn;
			}
			set
			{
				Set(value);
			}
		}

		Transform ICanvasElement.transform => base.transform;

		protected TouchToggle()
		{
		}

		public virtual void Rebuild(CanvasUpdate executing)
		{
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			PlayEffect(instant: true);
		}

		public void AddOnSelectedEvent(UnityAction newEvent)
		{
			_onSelected.AddListener(newEvent);
		}

		public override void OnSelect(BaseEventData eventData)
		{
			base.OnSelect(eventData);
			_onSelected.Invoke();
			_audioSystem.ScheduleEvent(AudioEvent.CreateUIEvent(UIEventType.MouseOver, _audioProfile));
		}

		public void Set(bool value, bool sendCallback = true)
		{
			if (_isOn != value)
			{
				_isOn = value;
				if (_group != null && IsActive() && (_isOn || (!_group.AnyTogglesOn() && !_group.allowSwitchOff)))
				{
					_group.NotifyToggleOn(this);
					_isOn = true;
				}
				PlayEffect(toggleTransition == ToggleTransition.None);
				if (sendCallback)
				{
					onValueChanged.Invoke(_isOn);
				}
			}
		}

		private void PlayEffect(bool instant)
		{
			if (!(graphic == null))
			{
				graphic.CrossFadeAlpha(_isOn ? 1f : 0f, instant ? 0f : 0.1f, ignoreTimeScale: true);
				if ((bool)graphic.GetComponent<CanvasGroup>())
				{
					graphic.GetComponent<CanvasGroup>().alpha = (_isOn ? 1f : 0f);
				}
			}
		}

		protected override void Start()
		{
			PlayEffect(instant: true);
		}

		private void InternalToggle(PointerEventData data = null)
		{
			if (IsActive() && IsInteractable())
			{
				IsOn = !IsOn;
				_audioSystem.ScheduleEvent(AudioEvent.CreateUIEvent(IsOn ? UIEventType.CheckboxChecked : UIEventType.CheckboxUnchecked, _audioProfile, -1f, condition: true, data));
				if (_feedbackGenerator != null)
				{
					_feedbackGenerator.GenerateFeedback(HapticFeedbackType.Selection);
				}
			}
		}

		protected override void DoStateTransition(SelectionState state, bool instant)
		{
			if (base.DeviceInputType == DeviceInputType.Touch && state == SelectionState.Highlighted)
			{
				state = SelectionState.Normal;
			}
			base.DoStateTransition(state, instant);
		}

		public override void DoPressedAnimation()
		{
			DoStateTransition(SelectionState.Pressed, instant: true);
			StartCoroutine(OnFinishSubmit());
		}

		private IEnumerator OnFinishSubmit()
		{
			float fadeTime = base.colors.fadeDuration;
			float elapsedTime = 0f;
			while (elapsedTime < fadeTime)
			{
				elapsedTime += Time.unscaledDeltaTime;
				yield return null;
			}
			DoStateTransition(SelectionState.Normal, instant: false);
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
			InternalToggle(eventData);
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			_audioSystem.ScheduleEvent(AudioEvent.CreateUIEvent(UIEventType.MouseOver, _audioProfile, -1f, condition: true, eventData));
		}

		public override void OnSubmit(BaseEventData eventData)
		{
			InternalToggle();
		}

		public void LayoutComplete()
		{
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			base.OnPointerExit(eventData);
			DoStateTransition(SelectionState.Normal, instant: false);
		}

		public void GraphicUpdateComplete()
		{
		}
	}
}
