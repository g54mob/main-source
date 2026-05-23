using System;
using UnityEngine;
using Utils;

namespace Presentation.UI.LoadingScreen
{
	[CreateAssetMenu(menuName = "UI/LoadingScreenSO", fileName = "LoadingScreenSO", order = 0)]
	public class LoadingScreenSO : ScriptableObject
	{
		[SerializeField]
		private LoadingScreenUI _loadingScreenPrefab;

		[SerializeField]
		private LoadingScreenProgressVariableSO _loadingScreenProgressVariable;

		private LoadingScreenUI _loadingScreen;

		private SaveFile? _currentSaveFile;

		private Action<SaveFile?> _callback;

		public void ShowLoadingScreen(bool showProgressBar)
		{
			DestroyLoadingScreen();
			_loadingScreenProgressVariable.SetHiddenAndReset(!showProgressBar);
			_loadingScreen = UnityEngine.Object.Instantiate(_loadingScreenPrefab, null);
			_loadingScreen.SetSaveFileNameEmpty();
		}

		public void ShowLoadingScreen(Action<SaveFile?> callback, SaveFile? currentSaveFile, bool showProgressBar)
		{
			DestroyLoadingScreen();
			_currentSaveFile = currentSaveFile;
			_callback = callback;
			_loadingScreenProgressVariable.SetHiddenAndReset(!showProgressBar);
			_loadingScreen = UnityEngine.Object.Instantiate(_loadingScreenPrefab, null);
			LoadingScreenUI loadingScreen = _loadingScreen;
			loadingScreen.OnShowLoadingScreen = (Action)Delegate.Combine(loadingScreen.OnShowLoadingScreen, new Action(HandleCallBack));
			_loadingScreen.SetSaveFileName(currentSaveFile);
		}

		private void HandleCallBack()
		{
			LoadingScreenUI loadingScreen = _loadingScreen;
			loadingScreen.OnShowLoadingScreen = (Action)Delegate.Remove(loadingScreen.OnShowLoadingScreen, new Action(HandleCallBack));
			if (_currentSaveFile.HasValue)
			{
				_callback?.Invoke(_currentSaveFile.Value);
			}
			_callback = null;
			_currentSaveFile = null;
		}

		public void DestroyLoadingScreen()
		{
			if (_loadingScreen != null)
			{
				_loadingScreen.DestroyLoadingScreen();
				_loadingScreen = null;
			}
		}
	}
}
