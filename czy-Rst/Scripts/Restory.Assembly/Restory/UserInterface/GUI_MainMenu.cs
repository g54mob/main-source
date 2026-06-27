using DG.Tweening;
using Restory.EventSystems;
using Restory.UserInterface.CommonElements;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface
{
	public class GUI_MainMenu : GUI_ScreenObjectBase, IInitializable
	{
		[Header("Main menu settings")]
		[Space]
		[SerializeField]
		private Button optionsButton;

		[Space]
		[SerializeField]
		private GUI_SaveSystemWarning saveSystemWarning;

		[SerializeField]
		private GUI_QuitGameButton quitGameButton;

		[Header("View settings")]
		[SerializeField]
		private int startPosX = -500;

		[SerializeField]
		private GUI_FindFirstNavigationSetter firstNavigationSetter;

		[SerializeField]
		private GUI_ConcreteNavigation continueStoryNavigation;

		[SerializeField]
		private GUI_ConcreteNavigation newStoryNavigation;

		[SerializeField]
		private GUI_ConcreteNavigation optionsNavigation;

		[SerializeField]
		private GUI_ConcreteNavigation exitNavigation;

		private GUI_GroupNavigationFinder mainMenuNavigationFinder;

		private ActiveSelectionService activeSelectionService;

		[Inject]
		private void Construct(ActiveSelectionService activeSelectionService)
		{
			this.activeSelectionService = activeSelectionService;
		}

		public void Initialize()
		{
			optionsButton.onClick.AddListener(ShowSettingsMenu);
			saveSystemWarning.OnWarningShown += Hide;
			saveSystemWarning.OnWarningClosed += Show;
			saveSystemWarning.Check();
			quitGameButton.OnQuitShown += DisableNavigation;
			quitGameButton.OnQuitClosed += EnableNavigation;
			InitializeNavigation();
			base.IsOpen = base.gameObject.activeInHierarchy;
			if (base.IsOpen)
			{
				OnShown.Invoke();
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			optionsButton.onClick.RemoveAllListeners();
			saveSystemWarning.OnWarningShown -= Hide;
			saveSystemWarning.OnWarningClosed -= Show;
			quitGameButton.OnQuitShown -= DisableNavigation;
			quitGameButton.OnQuitClosed -= EnableNavigation;
		}

		public void InitializeNavigation()
		{
			mainMenuNavigationFinder = new GUI_GroupNavigationFinder(continueStoryNavigation, newStoryNavigation, optionsNavigation, exitNavigation);
			InitializeNavigationButton(continueStoryNavigation);
			InitializeNavigationButton(newStoryNavigation);
			InitializeNavigationButton(optionsNavigation);
			InitializeNavigationButton(exitNavigation);
			firstNavigationSetter.FindFunction = GetFirstNavigation;
		}

		private void InitializeNavigationButton(GUI_ConcreteNavigation button)
		{
			button.Navigation.SetNoneAll();
			button.Navigation.SelectOnUp.SetAutomatic();
			button.Navigation.SelectOnUp.WrapAround = true;
			button.Navigation.SelectOnDown.SetAutomatic();
			button.Navigation.SelectOnDown.WrapAround = true;
			button.Finder = mainMenuNavigationFinder;
		}

		private GameObject GetFirstNavigation()
		{
			if (continueStoryNavigation.isActiveAndEnabled)
			{
				return continueStoryNavigation.gameObject;
			}
			if (newStoryNavigation.isActiveAndEnabled)
			{
				return newStoryNavigation.gameObject;
			}
			return optionsNavigation.gameObject;
		}

		private void ShowSettingsMenu()
		{
		}

		protected override void ShowAnimation()
		{
			base.WindowRectTransform.DOKill();
			base.WindowRectTransform.anchoredPosition = new Vector2(startPosX, 0f);
			base.WindowRectTransform.DOAnchorPosX(0f, 0.25f).SetUpdate(isIndependentUpdate: true).OnComplete(delegate
			{
				SetInteractable();
				activeSelectionService.Select(firstNavigationSetter.TargetNavigation);
			});
			base.WindowRectTransform.localScale = Vector3.one;
		}

		protected override void HideAnimation()
		{
			base.WindowRectTransform.DOKill();
			base.WindowRectTransform.DOAnchorPosX(startPosX, 0.25f).SetUpdate(isIndependentUpdate: true).OnStart(SetNotInteractable)
				.OnComplete(delegate
				{
					base.WindowRectTransform.localScale = Vector3.zero;
				});
		}

		private void SetNotInteractable()
		{
			canvasGroup.interactable = false;
		}

		private void SetInteractable()
		{
			canvasGroup.interactable = true;
		}

		private void EnableNavigation()
		{
			SetInteractable();
			firstNavigationSetter.Register();
		}

		private void DisableNavigation()
		{
			firstNavigationSetter.Unregister();
			SetNotInteractable();
		}
	}
}
