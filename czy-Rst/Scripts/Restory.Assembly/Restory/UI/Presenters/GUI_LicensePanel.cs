using System;
using Restory.EventSystems.ExitEvents;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Presenters
{
	public class GUI_LicensePanel : MonoBehaviour, IExitablePanel
	{
		[SerializeField]
		private Button closeButton;

		[SerializeField]
		private Image manufacturerLogo;

		[SerializeField]
		private Image deviceIcon;

		[SerializeField]
		private TextMeshProUGUI deviceModel;

		public bool IsVisible { get; private set; }

		public event Action OnIsVisibleChanged;

		public event Action OnClosePanelRequested;

		private void OnEnable()
		{
			closeButton.onClick.AddListener(ResolveCloseButtonClick);
			IsVisible = true;
			this.OnIsVisibleChanged?.Invoke();
		}

		private void OnDisable()
		{
			closeButton.onClick.RemoveListener(ResolveCloseButtonClick);
			IsVisible = false;
			this.OnIsVisibleChanged?.Invoke();
		}

		public void Init(Sprite manufacturerLogo, Sprite deviceIcon, string deviceModel)
		{
			this.manufacturerLogo.sprite = manufacturerLogo;
			this.deviceIcon.sprite = deviceIcon;
			this.deviceModel.text = deviceModel;
		}

		public void OnExitEvent()
		{
			this.OnClosePanelRequested?.Invoke();
		}

		private void ResolveCloseButtonClick()
		{
			this.OnClosePanelRequested?.Invoke();
		}
	}
}
