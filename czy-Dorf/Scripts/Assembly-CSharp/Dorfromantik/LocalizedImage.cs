using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik
{
	public class LocalizedImage : MonoBehaviour
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<ImageByLanguage, bool> _003C_003E9__8_0;

			public static Func<ImageByLanguage, bool> _003C_003E9__8_1;

			internal bool _003CUpdateLanguage_003Eb__8_0(ImageByLanguage x)
			{
				return x.language == LocalizationManager.Instance.Language;
			}

			internal bool _003CUpdateLanguage_003Eb__8_1(ImageByLanguage x)
			{
				return x.language == LocalizationManager.Instance.Language;
			}
		}

		[SerializeField]
		private List<ImageByLanguage> replacedImages;

		private bool subscribed;

		private Sprite defaultImage;

		private Image image;

		private SpriteRenderer spriteRenderer;

		private void OnEnable()
		{
			if (!subscribed && (bool)LocalizationManager.Instance)
			{
				LocalizationManager.Instance.OnLanguageChanged += UpdateLanguage;
				subscribed = true;
			}
		}

		private void OnDisable()
		{
			if (subscribed && (bool)LocalizationManager.Instance)
			{
				LocalizationManager.Instance.OnLanguageChanged -= UpdateLanguage;
				subscribed = false;
			}
		}

		private void Start()
		{
			if (!subscribed)
			{
				LocalizationManager.Instance.OnLanguageChanged += UpdateLanguage;
				subscribed = true;
			}
			image = GetComponent<Image>();
			spriteRenderer = GetComponent<SpriteRenderer>();
			if ((bool)image)
			{
				defaultImage = image.sprite;
			}
			else if ((bool)spriteRenderer)
			{
				defaultImage = spriteRenderer.sprite;
			}
			UpdateLanguage();
		}

		private void UpdateLanguage()
		{
			Sprite sprite = defaultImage;
			if (Enumerable.Count(replacedImages, (ImageByLanguage x) => x.language == LocalizationManager.Instance.Language) > 0)
			{
				sprite = Enumerable.First(replacedImages, (ImageByLanguage x) => x.language == LocalizationManager.Instance.Language).sprite;
			}
			if ((bool)image)
			{
				image.sprite = sprite;
			}
			else if ((bool)spriteRenderer)
			{
				spriteRenderer.sprite = sprite;
			}
		}
	}
}
