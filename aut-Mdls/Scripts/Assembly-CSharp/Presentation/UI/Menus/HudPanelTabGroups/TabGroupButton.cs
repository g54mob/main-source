using System;
using DG.Tweening;
using Presentation.UI.ButtonHelpers;
using Presentation.UI.Menus.MenuEvents;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Menus.HudPanelTabGroups
{
	public class TabGroupButton : ActivationButton
	{
		[SerializeField]
		private Button _closeButton;

		[SerializeField]
		private HideHudPanelEvent _hideHudPanelEvent;

		[SerializeField]
		private Image _background;

		[SerializeField]
		private Color _backgroundColorActive;

		[SerializeField]
		private Color _backgroundColorNormal;

		[SerializeField]
		private Color _backgroundColorHover;

		private ScriptableObject _SO;

		[HideInInspector]
		public Action<ScriptableObject> OnTabClick;

		private bool _isActive;

		public ScriptableObject SO
		{
			get
			{
				return _SO;
			}
			set
			{
				_SO = value;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			_closeButton.onClick.AddListener(OnCloseButtonClicked);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_closeButton.onClick.RemoveListener(OnCloseButtonClicked);
		}

		protected virtual void OnCloseButtonClicked()
		{
			if (_SO != null && _SO is TabGroupPanelSO)
			{
				_hideHudPanelEvent.Fire(_SO as TabGroupPanelSO);
			}
		}

		protected override void SetActive(bool active)
		{
			_isActive = active;
			_background.DOKill();
			_background.DOColor(active ? _backgroundColorActive : _backgroundColorNormal, 0.2f);
		}

		protected override void SetHover(bool hover)
		{
			_background.DOKill();
			_background.DOColor(hover ? _backgroundColorHover : (_isActive ? _backgroundColorActive : _backgroundColorNormal), 0.2f);
		}

		public void HideButton()
		{
			base.gameObject.SetActive(value: false);
		}

		public void ShowButton()
		{
			base.gameObject.SetActive(value: true);
		}

		public virtual void Cancel()
		{
		}

		protected override void OnButtonClick()
		{
			base.ActiveState = true;
			OnTabClick(_SO);
		}

		public virtual bool TryCanClose(Action successMethod = null)
		{
			successMethod?.Invoke();
			return true;
		}
	}
}
