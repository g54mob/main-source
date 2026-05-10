using System.Collections;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS
{
	public class Localization_Reload_HorizontalLayout : MonoBehaviour
	{
		[SerializeField]
		private HorizontalLayoutGroup _horizontalLayoutGroup;

		private void OnEnable()
		{
			LocalizationSettings.SelectedLocaleChanged += CallUpdateSize;
		}

		private void OnDisable()
		{
			LocalizationSettings.SelectedLocaleChanged -= CallUpdateSize;
		}

		private void CallUpdateSize(Locale value)
		{
			StartCoroutine(UpdateSize());
		}

		private IEnumerator UpdateSize()
		{
			yield return new WaitForEndOfFrame();
			_horizontalLayoutGroup.CalculateLayoutInputHorizontal();
			_horizontalLayoutGroup.SetLayoutHorizontal();
			yield return null;
		}
	}
}
