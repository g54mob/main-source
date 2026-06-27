using System;
using DG.Tweening;
using Restory.EventSystems;
using Restory.PostProcessing;
using Restory.UserInterface.ConfirmationDialogues;
using Restory.Utils;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface.SettingsMenu
{
	public class GUI_SettingsMenu : GUI_ScreenObjectBase
	{
		[SerializeField]
		private GUI_SettingsTabsGroup tabsGroup;

		[SerializeField]
		private GUI_GameplaySettingPanel gameplaySettingPanel;

		[SerializeField]
		private GUI_SoundSettingPanel soundSettingPanel;

		[SerializeField]
		private GUI_GraphicsSettingPanel graphicsSettingPanel;

		[SerializeField]
		private GUI_ControlsSettingPanel controlSettingPanel;

		[SerializeField]
		private Button hideMenuButton;

		[SerializeField]
		private GameObject confirmationDialogPrefab;

		[SerializeField]
		private PostProcessingEffectType effect = PostProcessingEffectType.MainSceneBlurred;

		[SerializeField]
		private float effectSwitchDuration = 0.5f;

		private PostProcessingEffectsService postProcessingEffectsService;

		private GUI_ConfirmationDialog confirmationDialog;

		private ActiveSelectionService activeSelectionService;

		private GameObject lastSelection;

		public GUI_GameplaySettingPanel GameplaySettingPanel => gameplaySettingPanel;

		public GUI_ControlsSettingPanel ControlSettingPanel => controlSettingPanel;

		protected override void Init()
		{
			base.Init();
			gameplaySettingPanel.Init();
			soundSettingPanel.Init();
			graphicsSettingPanel.Init();
			controlSettingPanel.Init();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			UnsubscribeChildren();
		}

		[Inject]
		private void Construct([InjectOptional] PostProcessingEffectsService postProcessingEffectsService, TweenSequencesService tweenSequences, ActiveSelectionService activeSelectionService)
		{
			this.postProcessingEffectsService = postProcessingEffectsService;
			base.tweenSequences = tweenSequences;
			this.activeSelectionService = activeSelectionService;
		}

		public override void Show()
		{
			SubscribeChildren();
			if (postProcessingEffectsService != null)
			{
				postProcessingEffectsService.TurnOnEffectAnimated(effect, effectSwitchDuration);
			}
			gameplaySettingPanel.UpdateView();
			soundSettingPanel.UpdateView();
			graphicsSettingPanel.UpdateView();
			controlSettingPanel.UpdateView();
			tabsGroup.OpenDefaultTab();
			base.Show();
		}

		public override void Close()
		{
			UnsubscribeChildren();
			if (postProcessingEffectsService != null)
			{
				postProcessingEffectsService.TurnOffEffectAnimated(effect, effectSwitchDuration);
			}
			tabsGroup.ActiveTab?.Panel?.Hide();
			base.Close();
		}

		public override void Hide()
		{
			UnsubscribeChildren();
			if (postProcessingEffectsService != null)
			{
				postProcessingEffectsService.TurnOffEffectAnimated(effect, effectSwitchDuration);
			}
			tabsGroup.ActiveTab?.Panel?.Hide();
			base.Hide();
		}

		protected override void ShowAnimation()
		{
			if (mainSequence.IsActive())
			{
				mainSequence.Kill();
			}
			mainSequence = tweenSequences.Create();
			mainSequence.Append(base.WindowRectTransform.DOScale(1f, fadeDuration).SetEase(showEaseTween)).SetUpdate(isIndependentUpdate: true).OnComplete(delegate
			{
				canvasGroup.interactable = true;
			});
		}

		protected override void HideAnimation()
		{
			if (mainSequence.IsActive())
			{
				mainSequence.Kill();
			}
			canvasGroup.interactable = false;
			mainSequence = tweenSequences.Create();
			mainSequence.Append(base.WindowRectTransform.DOScale(0f, fadeDuration).SetEase(closeEaseTween)).OnStart(delegate
			{
				canvasGroup.interactable = false;
			}).SetUpdate(isIndependentUpdate: true);
		}

		private void SubscribeChildren()
		{
			hideMenuButton.onClick.AddListener(hideMenuButton_onClick);
		}

		private void UnsubscribeChildren()
		{
			hideMenuButton.onClick.RemoveListener(hideMenuButton_onClick);
		}

		private void hideMenuButton_onClick()
		{
			TryHide();
		}

		public void TryHide()
		{
			CheckHasChangesAndInvoke(delegate
			{
				Hide();
			});
		}

		public void CheckHasChangesAndInvoke(Action action)
		{
			if (tabsGroup.ActiveTab == null || activeSelectionService == null)
			{
				action();
			}
			else if (tabsGroup.ActiveTab.Panel is GUI_BaseSettingPanel { HasChanges: not false } gUI_BaseSettingPanel)
			{
				gUI_BaseSettingPanel.ConfirmApply(delegate
				{
					action();
				});
			}
			else
			{
				action();
			}
		}
	}
}
