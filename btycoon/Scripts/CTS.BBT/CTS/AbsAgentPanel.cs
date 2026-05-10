using System;
using CTS.BBT.AI;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace CTS
{
	public abstract class AbsAgentPanel : MonoBehaviour
	{
		private RectTransform _rect;

		protected Agent _agent { get; private set; }

		public Agent Agent
		{
			get
			{
				return _agent;
			}
			set
			{
				if (_agent != value)
				{
					ClearAgentInfo();
					this.onAgentChanging?.Invoke();
				}
				_agent = value;
				if (_agent != null)
				{
					SetAgentInfo();
				}
			}
		}

		public RectTransform RectTransform
		{
			get
			{
				if (_rect == null)
				{
					_rect = GetComponent<RectTransform>();
				}
				return _rect;
			}
		}

		public event Action onAgentChanging;

		protected virtual void Awake()
		{
			LocalizationSettings.SelectedLocaleChanged += LocalizationSettings_SelectedLocaleChanged;
		}

		protected virtual void OnDestroy()
		{
			LocalizationSettings.SelectedLocaleChanged -= LocalizationSettings_SelectedLocaleChanged;
		}

		private void LocalizationSettings_SelectedLocaleChanged(Locale obj)
		{
			LocalizationChanged();
		}

		protected virtual void LocalizationChanged()
		{
		}

		public abstract void SetAgentInfo();

		public abstract void ClearAgentInfo();

		public void SetTopParent(AbsAgentPanel p_agentPanel)
		{
			SetPosition(p_agentPanel.RectTransform);
		}

		private void SetPosition(RectTransform p_topPanel)
		{
			RectTransform.anchoredPosition = p_topPanel.anchoredPosition - new Vector2(0f, p_topPanel.sizeDelta.y);
		}
	}
}
