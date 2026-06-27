using System;
using System.Collections.Generic;
using Restory.Data.PC;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters
{
	public sealed class GUI_PcWindowsXpStartMenu : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private GameObject buttonPrefab;

		[SerializeField]
		private Transform buttonsContainer;

		private readonly List<GUI_PcAppStartMenuButton> appButtons = new List<GUI_PcAppStartMenuButton>();

		private DiContainer diContainer;

		public bool IsVisible
		{
			get
			{
				if ((bool)canvasGroup)
				{
					return canvasGroup.interactable;
				}
				return false;
			}
		}

		public event Action<PcAppInfo> OnAppButtonClicked;

		[Inject]
		private void Construct(DiContainer diContainer)
		{
			this.diContainer = diContainer;
		}

		private void OnEnable()
		{
			foreach (GUI_PcAppStartMenuButton appButton in appButtons)
			{
				appButton.OnClicked += ResolveAppButtonClicked;
			}
		}

		private void OnDisable()
		{
			foreach (GUI_PcAppStartMenuButton appButton in appButtons)
			{
				appButton.OnClicked -= ResolveAppButtonClicked;
			}
		}

		public void Show()
		{
			canvasGroup.blocksRaycasts = true;
			canvasGroup.interactable = true;
			canvasGroup.alpha = 1f;
		}

		public void Hide()
		{
			canvasGroup.blocksRaycasts = false;
			canvasGroup.interactable = false;
			canvasGroup.alpha = 0f;
		}

		public void CreateAppButton(PcAppInfo appInfo)
		{
			GUI_PcAppStartMenuButton component = diContainer.InstantiatePrefab(buttonPrefab, buttonsContainer).GetComponent<GUI_PcAppStartMenuButton>();
			component.Init(appInfo);
			component.OnClicked += ResolveAppButtonClicked;
			appButtons.Add(component);
		}

		public void RemoveAppButton(PcAppInfo appInfo)
		{
			for (int num = appButtons.Count - 1; num >= 0; num--)
			{
				GUI_PcAppStartMenuButton gUI_PcAppStartMenuButton = appButtons[num];
				if (gUI_PcAppStartMenuButton == null)
				{
					appButtons.RemoveAt(num);
				}
				else if (!(gUI_PcAppStartMenuButton.AppInfo != appInfo))
				{
					gUI_PcAppStartMenuButton.OnClicked -= ResolveAppButtonClicked;
					appButtons.RemoveAt(num);
					UnityEngine.Object.Destroy(gUI_PcAppStartMenuButton.gameObject);
				}
			}
		}

		private void ResolveAppButtonClicked(GUI_PcAppStartMenuButton appButton)
		{
			this.OnAppButtonClicked?.Invoke(appButton.AppInfo);
		}
	}
}
