using System;
using MessagePipe;
using R3;
using UnityEngine;
using UnityEngine.Localization;

[DefaultExecutionOrder(-99)]
public class UI : MonoSingleton<UI>, InputListener.IHandler
{
	[SerializeField]
	private UIRegistry registry;

	private IMainView _activeMainView;

	[SerializeField]
	private LocalizedString mainMenuConfirmationTitle;

	[SerializeField]
	private LocalizedString mainMenuConfirmationMessage;

	[SerializeField]
	private LocalizedString quitConfirmationTitle;

	[SerializeField]
	private LocalizedString quitConfirmationMessage;

	public int Priority => 100;

	public static UIRegistry Registry => MonoSingleton<UI>.Instance.registry;

	public static IMainView CurrentView => MonoSingleton<UI>.Instance._activeMainView;

	private void Awake()
	{
		EventHub.Scene.Subscribe(delegate
		{
			HandlePrestige();
		}, Array.Empty<MessageHandlerFilter<Prestiged>>()).AddTo(this);
		MonoSingleton<InputListener>.Instance.Register(this);
		Initializer.Context(Registry.taskbar.startMenu).AddListener(Registry.startMenu.menu.Toggle).Context(Registry.taskbar.dashboard)
			.AddListener(delegate
			{
				ShowView(Registry.view.dashboard);
			})
			.Context(Registry.taskbar.upgrades)
			.AddListener(delegate
			{
				ShowView(Registry.view.upgrades);
			})
			.Context(Registry.taskbar.world)
			.AddListener(delegate
			{
				ShowView(Registry.view.world);
			})
			.Context(Registry.taskbar.debugger)
			.AddListener(delegate
			{
				ShowView(Registry.view.debugger);
			})
			.Context(Registry.taskbar.auction)
			.AddListener(delegate
			{
				ShowView(Registry.view.auction);
			})
			.Context(Registry.taskbar.sequel)
			.AddListener(delegate
			{
				ShowView(Registry.view.sequel);
			})
			.Context(Registry.taskbar.research)
			.AddListener(delegate
			{
				ShowView(Registry.view.research);
			})
			.Context(Registry.startMenu.settings)
			.AddListener(Registry.popup.settings.ShowContent)
			.Context(Registry.startMenu.wishlist)
			.AddListener(ApplicationController.OpenStorePage)
			.Context(Registry.startMenu.discord)
			.AddListener(ApplicationController.OpenDiscord)
			.Context(Registry.startMenu.history)
			.AddListener(Registry.popup.history.ShowContent)
			.Context(Registry.startMenu.gallery)
			.AddListener(Registry.popup.gallery.ShowContent)
			.Context(Registry.startMenu.achievement)
			.AddListener(Registry.popup.achievement.ShowContent)
			.Context(Registry.startMenu.background)
			.AddListener(Registry.popup.customization.ShowContent)
			.Context(Registry.startMenu.minesweeper)
			.AddListener(Registry.popup.minesweeper.ShowContent)
			.Context(Registry.startMenu.mainMenu)
			.AddCancellablePopup(mainMenuConfirmationTitle, mainMenuConfirmationMessage, delegate
			{
				Database.Save();
				ApplicationController.LoadMainMenu();
			})
			.Context(Registry.startMenu.quit)
			.AddCancellablePopup(quitConfirmationTitle, quitConfirmationMessage, ApplicationController.Quit)
			.Invoke(Registry.view.dashboard.Initialize)
			.Invoke(Registry.view.upgrades.Initialize)
			.Invoke(Registry.view.world.Initialize)
			.Invoke(Registry.view.debugger.Initialize)
			.Invoke(Registry.view.auction.Initialize)
			.Invoke(Registry.view.sequel.Initialize)
			.Invoke(Registry.view.research.Initialize);
	}

	private void ShowView(IMainView view)
	{
		_activeMainView?.Hide();
		_activeMainView = ((_activeMainView != view) ? view : null);
		_activeMainView?.Show();
	}

	private void HandlePrestige()
	{
		MonoSingleton<TooltipVisualizer>.Instance.Hide();
		ShowView(Registry.view.dashboard);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (MonoSingleton<InputListener>.HasInstance)
		{
			MonoSingleton<InputListener>.Instance.Unregister(this);
		}
	}

	public void Handle(InputEvent ctx)
	{
		switch (ctx.Input)
		{
		case InputEvent.Key.Cancel:
			Registry.taskbar.startMenu.onClick?.Invoke();
			ctx.Consume();
			break;
		case InputEvent.Key.DashboardView:
			if (Registry.taskbar.dashboard.isActiveAndEnabled)
			{
				Registry.taskbar.dashboard.onClick?.Invoke();
			}
			ctx.Consume();
			break;
		case InputEvent.Key.UpgradesView:
			if (Registry.taskbar.upgrades.isActiveAndEnabled)
			{
				Registry.taskbar.upgrades.onClick?.Invoke();
			}
			ctx.Consume();
			break;
		case InputEvent.Key.DebuggerView:
			if (Registry.taskbar.debugger.isActiveAndEnabled)
			{
				Registry.taskbar.debugger.onClick?.Invoke();
			}
			ctx.Consume();
			break;
		case InputEvent.Key.WorldView:
			if (Registry.taskbar.world.isActiveAndEnabled)
			{
				Registry.taskbar.world.onClick?.Invoke();
			}
			ctx.Consume();
			break;
		case InputEvent.Key.AuctionView:
			if (Registry.taskbar.auction.isActiveAndEnabled)
			{
				Registry.taskbar.auction.onClick?.Invoke();
			}
			ctx.Consume();
			break;
		case InputEvent.Key.SequelView:
			if (Registry.taskbar.sequel.isActiveAndEnabled)
			{
				Registry.taskbar.sequel.onClick?.Invoke();
			}
			ctx.Consume();
			break;
		case InputEvent.Key.ResearchView:
			if (Registry.taskbar.research.isActiveAndEnabled)
			{
				Registry.taskbar.research.onClick?.Invoke();
			}
			ctx.Consume();
			break;
		case InputEvent.Key.LeftClick:
		case InputEvent.Key.RightClick:
		case InputEvent.Key.MiddleClick:
			break;
		}
	}
}
