using System;
using CTS.BBT.AI;
using CTS.Core;
using CTS.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CTS
{
	[RequireComponent(typeof(Button))]
	public abstract class InterfaceButton : InterfaceElement
	{
		protected Button _button;

		protected bool _shown;

		private Color _originalButtonColor;

		[SerializeField]
		protected CanvasGroupController canvasToShow;

		[SerializeField]
		protected CanvasGroupController[] canvasToHide;

		public static Agent CurrentSelectedAgent;

		public bool isEnable => _button.enabled;

		public event Action onButtonClick;

		protected override void Awake()
		{
			base.Awake();
			_button = GetComponent<Button>();
			_originalButtonColor = _button.colors.normalColor;
		}

		protected override void OnToggledOn()
		{
			EnableButton(p_enable: true);
		}

		protected override void OnToggledOff()
		{
			EnableButton(p_enable: false);
			if ((bool)canvasToShow)
			{
				canvasToShow.QuickHide();
			}
		}

		private void OnEnable()
		{
			if ((bool)_button)
			{
				_button.onClick.AddListener(OnButtonClick);
			}
			if ((bool)canvasToShow)
			{
				canvasToShow.CanvasShowning += OnCanvasShowChanged;
			}
		}

		private void OnDisable()
		{
			if ((bool)_button)
			{
				_button.onClick.RemoveListener(OnButtonClick);
			}
			if ((bool)canvasToShow)
			{
				canvasToShow.CanvasShowning -= OnCanvasShowChanged;
			}
		}

		private void OnCanvasShowChanged(bool value)
		{
			ColorBlock colors = _button.colors;
			colors.normalColor = (value ? Color.white : _originalButtonColor);
			_button.colors = colors;
		}

		protected virtual void OnButtonClick()
		{
			this.onButtonClick?.Invoke();
			MonoSingleton<UI_ConstructionSystem>.Instance.CloseBuildMode();
			if (canvasToShow != null)
			{
				if (canvasToShow.State == CanvasGroupController.CanvasGroupState.Shown)
				{
					canvasToShow.QuickHide();
				}
				else
				{
					if (CurrentSelectedAgent != null)
					{
						WorldSelector.Deselect(CurrentSelectedAgent.Selection.SelectableObject);
					}
					canvasToShow.QuickShow();
				}
				EventSystem.current.SetSelectedGameObject(null);
			}
			for (int i = 0; i < canvasToHide.Length; i++)
			{
				canvasToHide[i].QuickHide();
			}
			_shown = !_shown;
		}

		public void EnableButton(bool p_enable)
		{
			_button.enabled = p_enable;
		}

		public virtual void ForceHiding()
		{
			canvasToShow?.QuickHide();
		}
	}
}
