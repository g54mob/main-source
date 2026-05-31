using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class UI_PauseMenu : MonoSingleton<UI_PauseMenu>
	{
		[SerializeField]
		private LayerMask _layerMask;

		[SerializeField]
		private CanvasGroupController _canvasPanelGroup;

		private float _currentTimeScale;

		private bool _isInTheOptions;

		private bool _optionMenuIsShowed;

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		public void CloseBarParameters()
		{
			_canvasPanelGroup.QuickHide();
		}

		public void ShowOptions()
		{
			MonoSingleton<OptionsMenu>.Instance.Show();
			_optionMenuIsShowed = true;
		}

		public void BackToMainMenu()
		{
			MonoSingleton<MenusManager>.Instance.ShowMainMenu();
			MonoSingleton<MainCamera>.Instance.Movements.enabled = true;
			MonoSingleton<MainCamera>.Instance.CameraRotation.enabled = true;
			MonoSingleton<MainCamera>.Instance.MouseControls.enabled = true;
			MonoSingleton<MainCamera>.Instance.Zoom.enabled = true;
		}

		public void QuitTheGame()
		{
			Application.Quit();
		}
	}
}
