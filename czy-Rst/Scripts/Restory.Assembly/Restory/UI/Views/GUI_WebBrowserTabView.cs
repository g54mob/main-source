using System;
using Restory.UI.Presenters.Shops;
using Restory.UserInterface.ElementPresets;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UI.Views
{
	public class GUI_WebBrowserTabView : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		[SerializeField]
		private string webAddress = "https://size.com";

		[SerializeField]
		private GUI_WebBrowserPageBase browserPage;

		[SerializeField]
		private GUI_PresetSwitcher presetSwitcher;

		[SerializeField]
		private PresetName disabledPreset = PresetName.Disabled;

		[SerializeField]
		private PresetName selectedPreset = PresetName.Selected;

		public string WebAddress => webAddress;

		public event Action<GUI_WebBrowserTabView> OnTabClick;

		public void OnPointerClick(PointerEventData eventData)
		{
			this.OnTabClick?.Invoke(this);
		}

		public void Activate()
		{
			presetSwitcher.ActivatePreset(selectedPreset);
			browserPage.Show();
		}

		public void Deactivate()
		{
			presetSwitcher.ActivatePreset(disabledPreset);
			browserPage.Hide();
		}
	}
}
