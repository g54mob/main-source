using Infrastructure.Services.LocalizationService;
using TMPro;
using UnityEngine;

namespace Assets.SimpleLocalization.Scripts
{
	[RequireComponent(typeof(TMP_Dropdown))]
	public class LocalizedDropdown : MonoBehaviour
	{
		public string[] LocalizationKeys;

		public void Start()
		{
			Localize();
			LocalizationManager.OnLocalizationChanged += Localize;
		}

		public void OnDestroy()
		{
			LocalizationManager.OnLocalizationChanged -= Localize;
		}

		private void Localize()
		{
			TMP_Dropdown component = GetComponent<TMP_Dropdown>();
			for (int i = 0; i < LocalizationKeys.Length; i++)
			{
				component.options[i].text = LocalizationManager.Localize(LocalizationKeys[i]);
			}
			if (component.value < LocalizationKeys.Length)
			{
				component.captionText.text = LocalizationManager.Localize(LocalizationKeys[component.value]);
			}
		}
	}
}
