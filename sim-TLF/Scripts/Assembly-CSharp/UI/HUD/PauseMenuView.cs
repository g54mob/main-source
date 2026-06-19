using System;
using DG.Tweening;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Observables;
using Loxodon.Framework.Views;
using UI.HUD.Settings.Controls;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Zenject;

namespace UI.HUD
{
	public class PauseMenuView : UIView
	{
		[SerializeField]
		private Volume _menuVolume;

		[SerializeField]
		private Button _settingsButton66;

		[SerializeField]
		private Button _controlsButton;

		[SerializeField]
		private ControlsSettingsView _controlsWindow;

		[SerializeField]
		private Button _resetPositionButton;

		[SerializeField]
		private Button _steamButton;

		[SerializeField]
		private Button _discordButton;

		[SerializeField]
		private Button _mainMenuButton;

		[SerializeField]
		private Button _exitButton;

		private Tween _menuTween;

		private ObservableProperty<bool> _pauseMenuOpened = new ObservableProperty<bool>();

		private PauseMenuViewModel _viewModel;

		[Inject]
		protected DiContainer _container;

		protected override void Awake()
		{
			_viewModel = _container.Instantiate<PauseMenuViewModel>();
			_pauseMenuOpened.ValueChanged += PauseMenuOpenValueChanged;
		}

		protected override void Start()
		{
			BindingSet<PauseMenuView, PauseMenuViewModel> bindingSet = this.CreateBindingSet<PauseMenuView, PauseMenuViewModel>();
			this.SetDataContext(_viewModel);
			bindingSet.Bind(_controlsButton).For((Button v) => v.onClick).To((PauseMenuViewModel vm) => vm.OpenControlsCommand)
				.OneWay();
			bindingSet.Bind().For((PauseMenuView v) => v.OnOpenControls).To((PauseMenuViewModel vm) => vm.OpenControlsRequest);
			bindingSet.Bind(_resetPositionButton).For((Button v) => v.onClick).To((PauseMenuViewModel vm) => vm.ResetPositionCommand)
				.OneWay();
			bindingSet.Bind(_discordButton).For((Button v) => v.onClick).To((PauseMenuViewModel vm) => vm.OpenDiscordCommand)
				.OneWay();
			bindingSet.Bind(_steamButton).For((Button v) => v.onClick).To((PauseMenuViewModel vm) => vm.OpenSteamCommand)
				.OneWay();
			bindingSet.Bind(_mainMenuButton).For((Button v) => v.onClick).To((PauseMenuViewModel vm) => vm.MainMenuCommand)
				.OneWay();
			bindingSet.Bind(_exitButton).For((Button v) => v.onClick).To((PauseMenuViewModel vm) => vm.ExitGameCommand)
				.OneWay();
			bindingSet.Bind(this).For((PauseMenuView v) => v._pauseMenuOpened).To((PauseMenuViewModel vm) => vm.PauseMenuOpened)
				.OneWay();
			bindingSet.Build();
			CloseMenu();
		}

		protected override void OnDestroy()
		{
			_viewModel.Destroy();
		}

		private void OnOpenControls(object sender, InteractionEventArgs args)
		{
			if (_controlsWindow != null)
			{
				_controlsWindow.Open();
			}
		}

		private void PauseMenuOpenValueChanged(object sender, EventArgs e)
		{
			if (_pauseMenuOpened.Value)
			{
				OpenMenu();
			}
			else
			{
				CloseMenu();
			}
		}

		private void OpenMenu()
		{
			base.gameObject.SetActive(value: true);
			Alpha = 1f;
			TweenMenuVolume(1f, 0.5f);
		}

		private void CloseMenu()
		{
			base.gameObject.SetActive(value: false);
			Alpha = 0f;
			TweenMenuVolume(0f, 0.5f);
		}

		private void TweenMenuVolume(float target, float time)
		{
			_menuTween?.Kill();
			_menuTween = DOTween.To(() => _menuVolume.weight, delegate(float x)
			{
				_menuVolume.weight = x;
			}, target, time).SetEase(Ease.OutCubic);
		}
	}
}
