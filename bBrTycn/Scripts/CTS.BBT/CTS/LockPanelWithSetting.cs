using System.Collections;
using CTS.Core;
using CTS.ScriptableSettings;
using CTS.UI;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CTS
{
	public class LockPanelWithSetting : CTSBehaviour
	{
		[SerializeField]
		private SettingObject<bool> _boolSetting;

		[SerializeField]
		[Inject(false)]
		private ISelectable _selectable;

		[SerializeField]
		private float _timebeforeShowingEndPanel;

		[SerializeField]
		private UI_EndDemo _endDemo;

		[SerializeField]
		[Scene]
		private int _endDemoScene;

		private bool _unlocked;

		private bool _showed;

		protected override void OnAwake()
		{
			_showed = false;
			base.OnAwake();
			_boolSetting.ValueChanged += OnSettingChanged;
			LoadingScreen.EndLoadingScreen += EndLoadingScreen;
		}

		private void EndLoadingScreen()
		{
			if (!_showed && SceneManager.GetActiveScene().buildIndex == _endDemoScene && _unlocked)
			{
				StartCoroutine(WaitBeforeShowendPanel());
				LoadingScreen.EndLoadingScreen -= EndLoadingScreen;
			}
		}

		private void ShowEndPanel(Scene arg0, LoadSceneMode arg1)
		{
			if (arg0 == SceneManager.GetSceneByBuildIndex(3) && !_showed && _unlocked)
			{
				StartCoroutine(WaitBeforeShowendPanel());
				_showed = true;
			}
		}

		private IEnumerator WaitBeforeShowendPanel()
		{
			yield return new WaitForSecondsRealtime(_timebeforeShowingEndPanel);
			_endDemo.ShowPanel();
		}

		private void OnDestroy()
		{
			_boolSetting.ValueChanged -= OnSettingChanged;
			LoadingScreen.EndLoadingScreen -= EndLoadingScreen;
		}

		private void OnSettingChanged(bool isOn)
		{
			_unlocked = isOn;
		}
	}
}
