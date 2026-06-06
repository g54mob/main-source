using Infrastructure.Services.LocalizationService;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.SimpleLocalization.Scripts
{
	[RequireComponent(typeof(Dropdown))]
	public class LocalizedDropdownOld : MonoBehaviour
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
			Dropdown component = GetComponent<Dropdown>();
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
