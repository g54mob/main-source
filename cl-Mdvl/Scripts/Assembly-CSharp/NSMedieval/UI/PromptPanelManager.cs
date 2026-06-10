using System;
using System.Collections.Generic;
using System.Linq;
using Controller;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class PromptPanelManager : PanelBase
	{
		[SerializeField]
		private TMP_Text description;

		[SerializeField]
		private LayoutGroupView buttonGroup;

		[SerializeField]
		private GameObject blur;

		[SerializeField]
		private ButtonLayoutItemView wishlistButtonPrefab;

		private List<ButtonLayoutItemView> buttons = new List<ButtonLayoutItemView>();

		private ButtonLayoutItemView wishlistButton;

		private bool handleInput = true;

		protected override bool SubscribeToEscapeKey => false;

		protected override PanelGroupType GetGroupType()
		{
			return PanelGroupType.Info;
		}

		public void OpenPanel(PromptPanelData data, bool handleInput = true)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(21, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\PromptPanelManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Showing prompt panel ");
				messageBuilder.AppendFormatted(data.PromptTextKey);
			}
			Log.Trace(messageBuilder);
			Show();
			if (MonoSingleton<GameplayPauseManager>.IsInstantiated())
			{
				MonoSingleton<GameplayPauseManager>.Instance.Register(this);
			}
			this.handleInput = handleInput;
			if (this.handleInput && MonoSingleton<GlobalKeybindingManager>.IsInstantiated())
			{
				if (MonoSingleton<GlobalKeybindingManager>.IsInstantiated())
				{
					MonoSingleton<GlobalKeybindingManager>.Instance.BlockEscapeKey(block: true);
				}
				if (MonoSingleton<InputManager>.IsInstantiated())
				{
					MonoSingleton<InputManager>.Instance.SetInputEnabled(value: false);
				}
			}
			blur.SetActive(data.BlurBackground);
			description.SetText(MonoSingleton<LocalizationController>.Instance.GetText(data.PromptTextKey));
			foreach (ButtonLayoutItemView button2 in buttons)
			{
				button2.Button.onClick.RemoveAllListeners();
				button2.gameObject.SetActive(value: false);
			}
			wishlistButton?.gameObject.SetActive(value: false);
			buttonGroup.gameObject.SetActive(value: false);
			if (data.ButtonActions == null || data.ButtonActions.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<string, Action> item in data.ButtonActions)
			{
				ButtonLayoutItemView button = GetButton();
				button.TextObject.SetText(MonoSingleton<LocalizationController>.Instance.GetText(item.Key));
				button.Button.onClick.RemoveAllListeners();
				button.Button.onClick.AddListener(delegate
				{
					OnButtonClick(item.Value);
				});
			}
			buttonGroup.gameObject.SetActive(value: true);
		}

		public void OpenCustomPanel(PromptPanelData data, bool handleInput = true)
		{
			Show();
			if (MonoSingleton<GameplayPauseManager>.IsInstantiated())
			{
				MonoSingleton<GameplayPauseManager>.Instance.Register(this);
			}
			this.handleInput = handleInput;
			if (this.handleInput && MonoSingleton<GlobalKeybindingManager>.IsInstantiated())
			{
				if (MonoSingleton<GlobalKeybindingManager>.IsInstantiated())
				{
					MonoSingleton<GlobalKeybindingManager>.Instance.BlockEscapeKey(block: true);
				}
				if (MonoSingleton<InputManager>.IsInstantiated())
				{
					MonoSingleton<InputManager>.Instance.SetInputEnabled(value: false);
				}
			}
			blur.SetActive(data.BlurBackground);
			description.SetText(MonoSingleton<LocalizationController>.Instance.GetText(data.PromptTextKey));
			foreach (ButtonLayoutItemView button2 in buttons)
			{
				button2.Button.onClick.RemoveAllListeners();
				button2.gameObject.SetActive(value: false);
			}
			wishlistButton?.gameObject.SetActive(value: false);
			buttonGroup.gameObject.SetActive(value: false);
			if (data.CustomButtonActions == null || data.CustomButtonActions.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<string, CustomButtonAction> item in data.CustomButtonActions)
			{
				if (item.Key == "lb_wishlist")
				{
					if (wishlistButton == null)
					{
						wishlistButton = UnityEngine.Object.Instantiate(wishlistButtonPrefab, buttonGroup.transform).GetComponent<ButtonLayoutItemView>();
					}
					wishlistButton.gameObject.SetActive(value: true);
					wishlistButton.TextObject.SetText(MonoSingleton<LocalizationController>.Instance.GetText(item.Key));
					wishlistButton.Button.onClick.RemoveAllListeners();
					wishlistButton.Button.onClick.AddListener(delegate
					{
						OnCustomButtonClick(item.Value);
					});
				}
				else
				{
					ButtonLayoutItemView button = GetButton();
					button.TextObject.SetText(MonoSingleton<LocalizationController>.Instance.GetText(item.Key));
					button.Button.onClick.RemoveAllListeners();
					button.Button.onClick.AddListener(delegate
					{
						OnCustomButtonClick(item.Value);
					});
				}
			}
			buttonGroup.gameObject.SetActive(value: true);
		}

		public void UpdateDescriptionText(string text)
		{
			description.SetText(text);
		}

		public void ClosePanel()
		{
			if (MonoSingleton<GameplayPauseManager>.IsInstantiated())
			{
				MonoSingleton<GameplayPauseManager>.Instance.Unregister(this);
			}
			if (handleInput)
			{
				if (MonoSingleton<InputManager>.IsInstantiated())
				{
					MonoSingleton<InputManager>.Instance.SetInputEnabled(value: true);
				}
				if (MonoSingleton<GlobalKeybindingManager>.IsInstantiated())
				{
					MonoSingleton<GlobalKeybindingManager>.Instance.BlockEscapeKey(block: false);
				}
			}
			Hide();
		}

		protected override void UpdatePanel()
		{
		}

		private void OnButtonClick(Action callbackAction)
		{
			callbackAction?.Invoke();
			ClosePanel();
		}

		private void OnCustomButtonClick(CustomButtonAction callbackAction)
		{
			if (callbackAction != null)
			{
				callbackAction.Action?.Invoke();
				if (!callbackAction.ClosePrompt)
				{
					return;
				}
			}
			ClosePanel();
		}

		private ButtonLayoutItemView GetButton()
		{
			ButtonLayoutItemView buttonLayoutItemView = buttons.FirstOrDefault((ButtonLayoutItemView item) => !item.gameObject.activeSelf);
			if (buttonLayoutItemView == null)
			{
				buttonLayoutItemView = UnityEngine.Object.Instantiate(buttonGroup.Prefab, buttonGroup.transform).GetComponent<ButtonLayoutItemView>();
				buttons.Add(buttonLayoutItemView);
			}
			buttonLayoutItemView.gameObject.SetActive(value: true);
			return buttonLayoutItemView;
		}
	}
}
