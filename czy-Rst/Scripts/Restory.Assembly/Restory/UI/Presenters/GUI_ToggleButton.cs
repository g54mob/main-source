using System;
using Restory.ObjectPools;
using Restory.UI.Views;
using UnityEngine;

namespace Restory.UI.Presenters
{
	public class GUI_ToggleButton : MonoBehaviour, ICleanableComponent
	{
		[SerializeField]
		private GUI_ToggleButtonView view;

		public ToggleButton ToggleButton => view.ToggleButton;

		public event Action<GUI_ToggleButton> OnButtonClicked;

		private void OnEnable()
		{
			view.OnButtonClicked += ResolveButtonClicked;
		}

		private void OnDisable()
		{
			if ((bool)view)
			{
				view.OnButtonClicked -= ResolveButtonClicked;
			}
		}

		void ICleanableComponent.Clean()
		{
			view.OnButtonClicked -= ResolveButtonClicked;
		}

		public void SetInfo(Sprite icon = null, string text = null)
		{
			view.SetInfo(icon, text);
		}

		private void ResolveButtonClicked()
		{
			this.OnButtonClicked?.Invoke(this);
		}
	}
}
