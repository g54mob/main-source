using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Simulator
{
	public class TabletopToggle : Toggle
	{
		public int index;

		[SerializeField]
		private TMP_Text m_textComponent;

		private Color m_defaultTextColor;

		[SerializeField]
		private Color m_toggleTextColor;

		[SerializeField]
		private Color m_disabledTextColor;

		public event Action<TabletopToggle> onSelect;

		protected override void Awake()
		{
			base.Awake();
			if (m_textComponent != null)
			{
				m_defaultTextColor = m_textComponent.color;
			}
		}

		protected override void Start()
		{
			base.Start();
			PlayColorEffect(instant: true);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (m_textComponent != null)
			{
				onValueChanged.AddListener(OnValueChanged_PlayTextColorEffect);
				PlayColorEffect(instant: true);
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (m_textComponent != null)
			{
				onValueChanged.RemoveListener(OnValueChanged_PlayTextColorEffect);
			}
		}

		public override void OnSelect(BaseEventData eventData)
		{
			base.OnSelect(eventData);
			this.onSelect?.Invoke(this);
		}

		private void OnValueChanged_PlayTextColorEffect(bool state)
		{
			PlayColorEffect(toggleTransition == ToggleTransition.None);
		}

		private void PlayColorEffect(bool instant)
		{
			if (!(m_textComponent == null))
			{
				Color targetColor = ((!base.interactable) ? m_disabledTextColor : (base.isOn ? m_toggleTextColor : m_defaultTextColor));
				m_textComponent.CrossFadeColor(targetColor, instant ? 0f : 0.1f, ignoreTimeScale: true, useAlpha: true);
			}
		}
	}
}
