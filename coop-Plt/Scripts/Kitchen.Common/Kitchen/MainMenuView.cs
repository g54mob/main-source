using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using JetBrains.Annotations;
using Kitchen.Modules;
using Kitchen.NetworkSupport;
using Platforms;
using TMPro;
using UnityEngine;
using WebSocketSharp;

namespace Kitchen
{
	public class MainMenuView : LocalMenuView<MenuAction>
	{
		[Header("References")]
		[SerializeField]
		private GameObject ErrorScreen;

		[SerializeField]
		private TextMeshPro ErrorText;

		private string PendingErrorText;

		[SerializeField]
		private GameObject SplashScreen;

		[SerializeField]
		private Animator Animator;

		[SerializeField]
		private MenuBackgroundItemScroller Background;

		[SerializeField]
		private CanvasGroup UsernameDisplayCanvasGroup;

		[SerializeField]
		private TMP_Text UsernameDisplayText;

		[Header("State")]
		private MainMenuState State;

		private MenuAction PostAnimationAction;

		private Type TransitionToMenu;

		private bool TransitionSkipStack;

		private bool TransitionRemoveSelfFromStack;

		private static readonly int FadeOut = Animator.StringToHash("FadeOut");

		private static readonly int Transition = Animator.StringToHash("Transition");

		public override void Start()
		{
			LocalInputSourceConsumers.Register(this);
		}

		public override void OnDestroy()
		{
			UnityEngine.Object.Destroy(Background.gameObject);
			LocalInputSourceConsumers.Remove(this);
		}

		protected override void Update()
		{
			base.Update();
			if (Session.NetworkedPlayState != NetworkedPlayState.NotInGame)
			{
				Hide();
			}
			else if (State == MainMenuState.ErrorScreen && PendingErrorText != null)
			{
				ErrorText.text = PendingErrorText;
				PendingErrorText = null;
				ErrorScreen.SetActive(value: true);
			}
		}

		public void BeginError(string text)
		{
			State = MainMenuState.ErrorScreen;
			PendingErrorText = text;
		}

		public void BeginSplash()
		{
			State = MainMenuState.SplashScreen;
			SplashScreen.SetActive(value: true);
		}

		public void OpenMultiplayerMenu()
		{
			if (ErrorScreen != null)
			{
				ErrorScreen.SetActive(value: false);
			}
			if (SplashScreen != null)
			{
				SplashScreen.SetActive(value: false);
			}
			CreateForPlayer(-1);
			State = MainMenuState.Menu;
			SetMenu(typeof(MultiplayerMainMenu));
		}

		protected override void SetupMenus()
		{
			Panel.gameObject.SetActive(value: false);
			Menus.Clear();
			AddMenu(typeof(StartMainMenu), new StartMainMenu(ButtonContainer, ModuleList));
			AddMenu(typeof(SingleplayerMainMenu), new SingleplayerMainMenu(ButtonContainer, ModuleList));
			AddMenu(typeof(MultiplayerMainMenu), new MultiplayerMainMenu(ButtonContainer, ModuleList));
			AddMenu(typeof(TextEntryMainMenu), new TextEntryMainMenu(ButtonContainer, ModuleList));
			AddMenu(typeof(OptionsMenu<MenuAction>), new OptionsMenu<MenuAction>(ButtonContainer, ModuleList, show_credits: true, show_language: true));
			AddMenu(typeof(CreditsMainMenu), new CreditsMainMenu(ButtonContainer, ModuleList));
			AddMenu(typeof(ErrorMenu<MenuAction>), new ErrorMenu<MenuAction>(ButtonContainer, ModuleList));
			AddMenu(typeof(MultiplayerLoadingMenu), new MultiplayerLoadingMenu(ButtonContainer, ModuleList, typeof(MultiplayerMainMenu)));
			AddMenu(typeof(DebuggingMainMenu), new DebuggingMainMenu(ButtonContainer, ModuleList));
			foreach (KeyValuePair<Type, Menu<MenuAction>> menu in Menus)
			{
				menu.Value.Style = ElementStyle.MainMenu;
			}
			SetMenu(typeof(StartMainMenu));
		}

		public override InputConsumerState TakeInput(int player_id, InputState state)
		{
			if (!state.IsAnyButtonHeldOrPressed)
			{
				return InputConsumerState.NotConsumed;
			}
			if (IsDismissed)
			{
				LocalInputSourceConsumers.Remove(this);
				return InputConsumerState.NotConsumed;
			}
			SetInteractingUser(player_id);
			switch (State)
			{
			case MainMenuState.SplashScreen:
				SplashScreen.SetActive(value: false);
				State = MainMenuState.Menu;
				CreateForPlayer(player_id);
				break;
			case MainMenuState.ErrorScreen:
				Session.SoftExit();
				break;
			case MainMenuState.Menu:
				ModuleList.HandleInteraction(state);
				if (state.MenuCancel == ButtonState.Pressed)
				{
					PerformAction(MainMenuAction.Back);
				}
				break;
			default:
				return InputConsumerState.NotConsumed;
			}
			return InputConsumerState.Consumed;
		}

		private void SetInteractingUser(int player_id)
		{
			if (ActivePlayer != player_id)
			{
				ActivePlayer = player_id;
				string displayName = Platform.Current.GetDisplayName(InputSourceIdentifier.Default.GetPlatformUser(ActivePlayer));
				if (!displayName.IsNullOrEmpty())
				{
					UsernameDisplayText.text = displayName;
					StartCoroutine(FadeInUsername());
				}
			}
		}

		private IEnumerator FadeInUsername()
		{
			UsernameDisplayCanvasGroup.alpha = 0f;
			UsernameDisplayCanvasGroup.gameObject.SetActive(value: true);
			yield return new WaitForSeconds(1f);
			while (UsernameDisplayCanvasGroup.alpha < 1f)
			{
				UsernameDisplayCanvasGroup.alpha += Time.deltaTime;
				yield return null;
			}
			UsernameDisplayCanvasGroup.alpha = 1f;
		}

		protected override void PerformAction(MenuAction action = default(MenuAction))
		{
			MainMenuAction action2 = action.Action;
			if (action.SkipAnimation)
			{
				TransitionToMenu = null;
			}
			if (PostAnimationAction.Action != MainMenuAction.Null || TransitionToMenu != null)
			{
				return;
			}
			switch (action2)
			{
			case MainMenuAction.Back:
				GoBack();
				return;
			case MainMenuAction.Quit:
				Session.SoftExit();
				Hide();
				return;
			case MainMenuAction.ClearNetworkError:
				GoBack();
				return;
			case MainMenuAction.Wiki:
				Application.OpenURL(PlatformSettings.WikiLandingPage);
				return;
			case MainMenuAction.Discord:
				Application.OpenURL(PlatformSettings.DiscordLandingPage);
				return;
			}
			PostAnimationAction = action;
			if (Animator != null)
			{
				Animator.SetBool(FadeOut, value: true);
			}
		}

		protected override void GoBack()
		{
			if (ActiveMenuStack.Count > 1)
			{
				base.GoBack();
			}
			else if (!(ActiveMenuStack.Peek() == typeof(StartMainMenu)))
			{
				Type key = ActiveMenuStack.Pop();
				if (Menus.TryGetValue(key, out var value))
				{
					value.TearDown();
				}
				if (InputSourceIdentifier.DefaultInputSource != null)
				{
					InputSourceIdentifier.DefaultInputSource.ReleaseLock(GlobalLock);
				}
				CreateForPlayer(ActivePlayer);
			}
		}

		protected override void SetMenu(Type menu_type, bool skip_stack = false, bool remove_current = false)
		{
			if (TransitionToMenu != null)
			{
				TransitionToMenu = menu_type;
				return;
			}
			if (Animator != null)
			{
				Animator.SetTrigger(Transition);
			}
			TransitionToMenu = menu_type;
			TransitionSkipStack = skip_stack;
			TransitionRemoveSelfFromStack = remove_current;
		}

		[UsedImplicitly]
		protected void PerformSetMenuPostTransition()
		{
			if (Animator != null)
			{
				Animator.ResetTrigger(Transition);
			}
			base.SetMenu(TransitionToMenu, TransitionSkipStack, TransitionRemoveSelfFromStack);
			TransitionToMenu = null;
		}

		[UsedImplicitly]
		protected void PerformActionPostAnimation()
		{
			Background.gameObject.SetActive(value: false);
			switch (PostAnimationAction.Action)
			{
			case MainMenuAction.StartSingleplayer:
				NetworkHelpers.CurrentNetworkPermissions = NetworkPermissions.Private;
				Session.CreateGame(allow_networking: false, retain_players: false);
				Hide();
				break;
			case MainMenuAction.StartMultiplayer:
				if (!PlatformSettings.AllowNonInviteOnlyGames && NetworkHelpers.CurrentNetworkPermissions == NetworkPermissions.Private)
				{
					NetworkHelpers.CurrentNetworkPermissions = NetworkPermissions.InviteOnly;
				}
				Session.CreateGame(allow_networking: true, retain_players: false);
				Hide();
				break;
			case MainMenuAction.JoinMultiplayer:
				Session.JoinGame(PostAnimationAction.Target);
				break;
			case MainMenuAction.Quit:
				Session.SoftExit();
				Hide();
				break;
			}
			PostAnimationAction = default(MenuAction);
		}

		protected override void SetPanelTarget(IModule target)
		{
			Panel.SetTarget(null);
		}
	}
}
