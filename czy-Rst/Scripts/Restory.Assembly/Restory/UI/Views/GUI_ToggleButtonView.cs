using System;
using Restory.ObjectPools;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UI.Views
{
	public sealed class GUI_ToggleButtonView : UIBehaviour, ICleanableComponent
	{
		[SerializeField]
		private ToggleButton button;

		[SerializeField]
		private Image mainIcon;

		[SerializeField]
		private TMP_Text mainText;

		public ToggleButton ToggleButton => button;

		public event Action OnButtonClicked;

		protected override void OnEnable()
		{
			base.OnEnable();
			button.onClick.AddListener(ResolveButtonClicked);
		}

		protected override void OnDisable()
		{
			if ((bool)button)
			{
				button.onClick.RemoveListener(ResolveButtonClicked);
			}
			base.OnDisable();
		}

		void ICleanableComponent.Clean()
		{
			button.onClick.RemoveListener(ResolveButtonClicked);
			if ((bool)mainIcon)
			{
				mainIcon.overrideSprite = null;
			}
			if ((bool)mainText)
			{
				mainText.text = string.Empty;
			}
		}

		public void SetInfo(Sprite icon, string text)
		{
			if ((bool)mainIcon)
			{
				mainIcon.overrideSprite = icon;
			}
			if ((bool)mainText)
			{
				mainText.text = text;
			}
		}

		private void ResolveButtonClicked()
		{
			this.OnButtonClicked?.Invoke();
		}
	}
}
