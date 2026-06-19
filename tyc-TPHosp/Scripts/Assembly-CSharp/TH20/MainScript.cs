using Backtrace.Unity;
using FullInspector.Generated.SharedInstance;
using UnityConsole;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TH20
{
	public class MainScript : MonoBehaviour
	{
		[SerializeField]
		private GraphicRaycaster _graphicRaycaster;

		[SerializeField]
		private EventSystem _eventSystem;

		[SerializeField]
		private ConsoleUI _consoleUI;

		[SerializeField]
		private UnhandledErrorDialogue _unhandledErrorDialogue;

		[SerializeField]
		private ScreenFade _screenFade;

		[SerializeField]
		private LoadSaveProgressScreen _loadSaveProgressScreen;

		[SerializeField]
		private FullScreenVideoMenu _fullScreenVideoMenu;

		[SerializeField]
		private MessageBox _messageBox;

		[SerializeField]
		private BackupSaveBox _backupSaveBox;

		[SerializeField]
		private SoundTest _soundTest;

		[SerializeField]
		private BacktraceClient _backtraceClient;

		[SerializeField]
		private SharedInstance_TH20TH20_AppConfig _appConfig;

		private App _app;

		private void Start()
		{
			_app = new App(_graphicRaycaster, _eventSystem, this, _unhandledErrorDialogue, _consoleUI, _screenFade, _loadSaveProgressScreen, _fullScreenVideoMenu, _messageBox, _backupSaveBox, _soundTest, _backtraceClient, _appConfig);
		}

		private void Update()
		{
			if (_app != null)
			{
				_app.Update();
			}
		}

		private void LateUpdate()
		{
			if (_app != null)
			{
				_app.LateUpdate();
			}
		}

		private void OnDestroy()
		{
			if (_app != null)
			{
				_app.Destroy();
				_app = null;
			}
		}

		protected void OnApplicationFocus(bool focus)
		{
			if (_app != null)
			{
				_app.OnApplicationFocus(focus);
			}
		}

		private void OnGUI()
		{
			if (_app != null)
			{
				_app.OnGUI();
			}
		}

		private void OnDrawGizmos()
		{
			if (_app != null)
			{
				_app.OnDrawGizmos();
			}
		}

		private void OnApplicationQuit()
		{
			Application.Quit();
			if (_app != null && _app.ShouldQuitNow())
			{
				UnityEngine.Debug.Log("Application shutting down");
				_app.Destroy();
				_app = null;
			}
		}
	}
}
