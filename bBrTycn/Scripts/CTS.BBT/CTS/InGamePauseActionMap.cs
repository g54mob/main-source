using System;
using CTS.Core;
using CTS.UI;
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CTS
{
	public class InGamePauseActionMap : CTSBehaviour
	{
		[SerializeField]
		private SceneReference _mainMenu;

		private bool _isActive = true;

		protected override void OnAwake()
		{
			base.OnAwake();
			CanvasGroupController.SlidingPanel += OnPanelSlide;
			WorldSelector.SelectionChanged += OnSelectionChanged;
			UI_ConstructionSystem.OnOpenBuildMode += OnConstructionOpened;
			UI_ConstructionSystem.OnCloseBuildMode += OnConstructionOpened;
			UIWallMenu.OnMenuOpen += OnWallMenuOpened;
		}

		private void Start()
		{
			Recalculate();
		}

		private void OnDestroy()
		{
			CanvasGroupController.SlidingPanel -= OnPanelSlide;
			WorldSelector.SelectionChanged -= OnSelectionChanged;
			UI_ConstructionSystem.OnOpenBuildMode -= OnConstructionOpened;
			UI_ConstructionSystem.OnCloseBuildMode -= OnConstructionOpened;
			UIWallMenu.OnMenuOpen -= OnWallMenuOpened;
		}

		private void OnWallMenuOpened(bool obj)
		{
			Recalculate();
		}

		private void OnConstructionOpened()
		{
			Recalculate();
		}

		private void OnPanelSlide(CanvasGroupController arg1, bool arg2)
		{
			Recalculate();
		}

		private void OnSelectionChanged(WorldSelector obj)
		{
			Recalculate();
		}

		private void Recalculate()
		{
			Scene activeScene = SceneManager.GetActiveScene();
			string text = activeScene.name;
			bool flag;
			if (text.Contains("MainMenu", StringComparison.InvariantCulture) || text.Contains("Start", StringComparison.InvariantCulture))
			{
				flag = false;
			}
			else if (activeScene.name.Contains("Selection"))
			{
				flag = MonoSingleton<CanvasGroupManager>.Instance.OpenedControllers.Count <= 0;
			}
			else
			{
				flag = MonoSingleton<CanvasGroupManager>.Instance.OpenedControllers.Count <= 0 && !WorldSelector.IsAnythingSelected();
				if (MonoSingleton<UI_ConstructionSystem>.Instance.IsOpen)
				{
					flag = false;
				}
				if (MonoSingleton<UIWallMenu>.Instance.IsOpen)
				{
					flag = false;
				}
			}
			if (flag != _isActive)
			{
				_isActive = flag;
				if (_isActive)
				{
					InputManager.ingamepause.Unlock(p_recursive: true);
				}
				else
				{
					InputManager.ingamepause.Lock(p_recursive: true);
				}
			}
		}
	}
}
