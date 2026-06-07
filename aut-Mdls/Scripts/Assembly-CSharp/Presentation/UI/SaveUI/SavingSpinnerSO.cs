using Events;
using NaughtyAttributes;
using UnityEngine;

namespace Presentation.UI.SaveUI
{
	[CreateAssetMenu(menuName = "UI/SavingSpinnerSO", fileName = "SavingSpinnerSO", order = 0)]
	public class SavingSpinnerSO : ScriptableObject
	{
		[SerializeField]
		private SavingSpinnerUI _savingSpinnerPrefab;

		[SerializeField]
		private BaseEvent _finishedSavingEvent;

		private SavingSpinnerUI _savingSpinner;

		[Button(null, EButtonEnableMode.Always)]
		public void ShowSavingSpinner()
		{
			DestroySavingSpinner();
			_savingSpinner = Object.Instantiate(_savingSpinnerPrefab, null);
			_finishedSavingEvent.Register(HideSavingSpinner);
		}

		[Button(null, EButtonEnableMode.Always)]
		private void HideSavingSpinner()
		{
			DestroySavingSpinner();
			_finishedSavingEvent.UnRegister(HideSavingSpinner);
		}

		private void DestroySavingSpinner()
		{
			if (_savingSpinner != null)
			{
				_savingSpinner.DestroySpinner();
				_savingSpinner = null;
			}
		}
	}
}
