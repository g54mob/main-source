using Infrastructure.Services.LocalizationService;
using TMPro;
using UnityEngine;

namespace Assets.SimpleLocalization.Scripts
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class LocalizedTextMeshPro : MonoBehaviour
	{
		public string LocalizationKey;

		public void Awake()
		{
			Localize();
		}

		public void Start()
		{
			LocalizationManager.OnLocalizationChanged += Localize;
		}

		public void OnDestroy()
		{
			LocalizationManager.OnLocalizationChanged -= Localize;
		}

		private void OnEnable()
		{
			Localize();
		}

		private void Localize()
		{
			GetComponent<TextMeshProUGUI>().text = LocalizationManager.Localize(LocalizationKey);
		}
	}
}
