using System.Collections.Generic;
using UnityEngine;

namespace Presentation.UI.Utils
{
	public class LanguageEnabler : MonoBehaviour
	{
		[SerializeField]
		private List<LanguageCode> _languagesToEnable;

		private void Awake()
		{
			LocalizationUtility.OnLanguageUpdate += OnLanguageUpdate;
			SetActiveState();
		}

		private void OnDestroy()
		{
			LocalizationUtility.OnLanguageUpdate -= OnLanguageUpdate;
		}

		private void SetActiveState()
		{
			for (int i = 0; i < _languagesToEnable.Count; i++)
			{
				base.gameObject.SetActive(LocalizationUtility.CurrentLanguage == _languagesToEnable[i]);
			}
		}

		private void OnLanguageUpdate()
		{
			SetActiveState();
		}
	}
}
