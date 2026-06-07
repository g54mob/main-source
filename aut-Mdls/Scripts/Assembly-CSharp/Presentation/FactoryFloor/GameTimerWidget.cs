using System;
using Data.SaveData.PersistentSOs;
using TMPro;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class GameTimerWidget : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _gameTimerTextField;

		[SerializeField]
		private SaveInfoPersistentSO _saveInfoPersistentSO;

		private Coroutine _coroutine;

		private void OnEnable()
		{
			TimeSpan timeSpan = TimeSpan.FromMinutes(_saveInfoPersistentSO.TotalPlayTimeMinsRealtime);
			_gameTimerTextField.SetText(string.Format(LocalizationUtility.GetLocalizedText("LoadSave.PlayTime"), (int)timeSpan.TotalHours, timeSpan.Minutes));
		}
	}
}
