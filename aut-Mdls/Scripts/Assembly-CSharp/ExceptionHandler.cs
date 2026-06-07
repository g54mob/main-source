#define ENABLE_DEBUG_EXCEPTIONS
using System;
using System.Collections;
using Data.GameState;
using Data.SaveData;
using Events;
using Events.UI.Overlays;
using Logic.Factory;
using Presentation.UI;
using Presentation.UI.LoadingScreen;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using UnityEngine;
using Utils;
using Utils.Enums;
using Utils.SceneHandling;

public class ExceptionHandler : MonoBehaviour
{
	private static ExceptionHandler _instance;

	[SerializeField]
	private string _startScreenName = "StartScreen";

	[SerializeField]
	private LoadingScreenSO _loadingScreenSO;

	[SerializeField]
	private ShowMenuModalDialogEvent _showMenuModalDialogEvent;

	[SerializeField]
	protected PauseStateData _pauseState;

	[SerializeField]
	private FactoryClearer _factoryClearer;

	[SerializeField]
	private PersistentSOLibrary _persistentSoLibrary;

	[SerializeField]
	private BaseEvent _startLoadingSaveEvent;

	[SerializeField]
	private BaseEvent _loadingScreenDestroyedEvent;

	[SerializeField]
	private ExternalLink _externalLinkReport;

	private bool _loadingScreenIsOpen;

	private bool _isRecovering;

	private void Start()
	{
		if (_instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		_instance = this;
		base.transform.SetParent(null);
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		Application.logMessageReceived += OnLog;
		_startLoadingSaveEvent.Register(OnLoadingScreenCreated);
		_loadingScreenDestroyedEvent.Register(OnLoadingScreenDestroyed);
	}

	private void OnDestroy()
	{
		if (!(_instance != this))
		{
			_instance = null;
			Application.logMessageReceived -= OnLog;
			_startLoadingSaveEvent.UnRegister(OnLoadingScreenCreated);
			_loadingScreenDestroyedEvent.UnRegister(OnLoadingScreenDestroyed);
		}
	}

	private void OnLog(string condition, string stackTrace, LogType type)
	{
		if ((type == LogType.Exception || type == LogType.Assert) && _loadingScreenIsOpen && !_isRecovering)
		{
			StartCoroutine(RecoverCoroutine(condition, stackTrace));
		}
	}

	private void OnLoadingScreenCreated()
	{
		_loadingScreenIsOpen = true;
	}

	private void OnLoadingScreenDestroyed()
	{
		_loadingScreenIsOpen = false;
	}

	private IEnumerator RecoverCoroutine(string condition, string stackTrace)
	{
		_isRecovering = true;
		yield return null;
		yield return null;
		try
		{
			_factoryClearer.ClearLevel();
		}
		catch (Exception ex)
		{
			this.LogAssertion(ex.ToString(), "RecoverCoroutine", 91);
		}
		_pauseState.SetPauseState(active: false);
		_pauseState.SetPausedBuildMode(active: false);
		_loadingScreenSO.ShowLoadingScreen(showProgressBar: false);
		yield return SceneHandler.Instance.LoadSceneCoroutine(_startScreenName);
		_loadingScreenSO.DestroyLoadingScreen();
		try
		{
			_persistentSoLibrary.ResetPersistentSOs();
		}
		catch (Exception ex2)
		{
			this.LogAssertion(ex2.ToString(), "RecoverCoroutine", 107);
		}
		MenuModalDialogDto dto = new MenuModalDialogDto("ModalWarning.LoadingException", condition, Sizes.M, delegate
		{
			OnReportButtonClicked(condition, stackTrace);
		}, showCancelButton: true)
		{
			OverrideSuccessButtonTextKey = "ModalGeneric.ReportButton",
			OverrideCancelButtonTextKey = "ModalGeneric.CancelButton"
		};
		_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(dto));
		_isRecovering = false;
	}

	private void OnReportButtonClicked(string condition, string stackTrace)
	{
		MenuModalDialogDto dto = new MenuModalDialogDto(condition + "\n\n" + stackTrace, Sizes.M, null, showCancelButton: false, null, skipLocalization: true)
		{
			OverrideSuccessButtonTextKey = "ModalGeneric.ConfirmButton"
		};
		_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(dto));
		_externalLinkReport.OnButtonClicked();
	}
}
