#define ENABLE_DEBUG_LOGS
using System.Collections;
using Data.GameState;
using Data.Variables;
using Events.AutoSave;
using NaughtyAttributes;
using UnityEngine;
using Utils;

namespace Logic.Factory
{
	public class AutoSaver : MonoBehaviour
	{
		[SerializeField]
		private FactorySaver _factorySaver;

		[SerializeField]
		private FloatVariableSO _autoSaveIntervalDuration;

		[SerializeField]
		private PauseStateData _pauseStateData;

		[SerializeField]
		private AutoSaveEvent _autoSaveEvent;

		[SerializeField]
		private BoolVariableSO _autoSaveFlag;

		[SerializeField]
		private AutoSaveService _autoSaveService;

		private Coroutine _coroutine;

		private int _autoSaveCount;

		private readonly WaitForSeconds _waitFor3QuarterSecond = new WaitForSeconds(0.75f);

		private readonly WaitForSeconds _waitForSecond = new WaitForSeconds(1f);

		private void Start()
		{
			HandleAutoSaveFlagChanged(_autoSaveFlag.Value);
			_autoSaveFlag.ValueChanged += HandleAutoSaveFlagChanged;
		}

		private void HandleAutoSaveFlagChanged(bool value)
		{
			if (value)
			{
				if (_coroutine != null)
				{
					StopCoroutine(_coroutine);
				}
				_coroutine = StartCoroutine(WaitForAutoSave());
			}
			else if (_coroutine != null)
			{
				StopCoroutine(_coroutine);
			}
		}

		private void OnDestroy()
		{
			_autoSaveFlag.ValueChanged -= HandleAutoSaveFlagChanged;
			if (_coroutine != null)
			{
				StopCoroutine(_coroutine);
			}
		}

		private IEnumerator WaitForAutoSave()
		{
			double timeInSeconds = 0.0;
			while (true)
			{
				this.Log("Starting Autosave Interval!", "WaitForAutoSave", 67);
				while (timeInSeconds < (double)(_autoSaveIntervalDuration.Value * 60f))
				{
					yield return _waitForSecond;
					if (!_pauseStateData.IsPaused)
					{
						timeInSeconds += 1.0;
					}
				}
				if (!_autoSaveFlag.Value)
				{
					break;
				}
				timeInSeconds = 0.0;
				_autoSaveEvent.Fire(_autoSaveCount);
				yield return _waitFor3QuarterSecond;
				_autoSaveCount++;
				AutoSave();
			}
			this.Log("Stopping Autosave Interval!", "WaitForAutoSave", 81);
			StopCoroutine(_coroutine);
		}

		[Button(null, EButtonEnableMode.Always)]
		private void AutoSave()
		{
			_autoSaveService.AutoSave();
		}
	}
}
