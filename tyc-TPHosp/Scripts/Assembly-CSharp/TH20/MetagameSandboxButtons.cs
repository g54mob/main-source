using System;
using TH20.UI;
using UnityEngine;

namespace TH20
{
	public class MetagameSandboxButtons : AnimatedMenuBase
	{
		[SerializeField]
		private DynamicButton _optionsButton;

		private App _app;

		private HUD _hud;

		private bool _registeredEvents;

		public void Setup(App app)
		{
			_app = app;
			_hud = app.MetagameMap.HUD;
			if (!_registeredEvents)
			{
				_optionsButton.onPrimaryDown.AddListener(OnOptionsPressed);
				_registeredEvents = true;
			}
		}

		public override void Destroy()
		{
			if (_registeredEvents)
			{
				_optionsButton.onPrimaryDown.RemoveListener(OnOptionsPressed);
				_registeredEvents = false;
			}
		}

		public override void OpenMenu()
		{
			base.OpenMenu();
			_optionsButton.interactable = true;
		}

		public override void CloseMenu()
		{
			base.CloseMenu();
			_optionsButton.interactable = false;
		}

		protected override void Update()
		{
			base.Update();
			if (_app.InputManager.GetKeyDown(KeyCode.Escape))
			{
				OnOptionsPressed();
			}
		}

		public void OnOptionsPressed()
		{
			if (IsClosing() || _app.PreferencesScreen.isActiveAndEnabled || _hud.AreAnyMenusPreventingOpenPauseMenu() || _app.MessageBox.IsVisibleOrClosing)
			{
				return;
			}
			if (_hud.FindMenu<OptionsMenu>() == null)
			{
				CloseMenu();
				SandboxMenu sandboxMenu = _hud.FindMenu<SandboxMenu>();
				if (sandboxMenu != null)
				{
					sandboxMenu.CloseMenu();
				}
				OptionsMenu optionsMenu = _hud.CreateMenu<OptionsMenu>();
				optionsMenu.Setup(_app, _app.MetagameMap, _app.SaveSystem, _app.UserPreferences, _app.MessageBox, _app.Save, _app.Load, _app.QuickSaveDeferred, _app.QuickLoad);
				optionsMenu.OnClosed = (Action)Delegate.Combine(optionsMenu.OnClosed, new Action(CloseOptions));
			}
			else
			{
				CloseOptions();
			}
		}

		private void CloseOptions()
		{
			OptionsMenu optionsMenu = _hud.FindMenu<OptionsMenu>();
			if (!optionsMenu.IsClosed() && !optionsMenu.IsClosing())
			{
				optionsMenu.CloseMenu();
			}
			optionsMenu.OnClosed = (Action)Delegate.Remove(optionsMenu.OnClosed, new Action(CloseOptions));
			OpenMenus();
		}

		private void OpenMenus()
		{
			OpenMenu();
			_optionsButton.interactable = true;
			SandboxMenu sandboxMenu = _hud.FindMenu<SandboxMenu>();
			if (sandboxMenu != null)
			{
				sandboxMenu.OpenMenu();
				return;
			}
			sandboxMenu = _hud.CreateMenu<SandboxMenu>(recycle: true);
			bool everConnectedToPrime = _app.UserProfile?.PrimeGamingRefreshToken != null && !_app.UserProfile.PrimeGamingRefreshToken.IsNullOrEmpty();
			sandboxMenu.Setup(_app.SandboxSettingsConfig, _app.MetagameMap, _app.SandboxSaveManager, everConnectedToPrime);
		}
	}
}
