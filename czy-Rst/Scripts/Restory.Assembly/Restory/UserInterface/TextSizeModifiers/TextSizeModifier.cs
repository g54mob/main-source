using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface.TextSizeModifiers
{
	public class TextSizeModifier
	{
		public class Factory : PlaceholderFactory<TextSizeModifier>
		{
		}

		private const float MIN_FONT_SIZE = 40f;

		[Inject]
		private TextSizeModifiersService service;

		private TMP_Text textMeshPro;

		private Text text;

		private TextUpperCaseSetter textUpperCaseSetter;

		private TextSizeProfile profile;

		private float originalSize;

		private FontStyles originalFontStyle;

		private bool ignoreSizeChangesAndOnlyApplyUppercase;

		public event Action OnUpdated = delegate
		{
		};

		public void Setup(TMP_Text textMeshPro, Text text, bool ignoreSizeChangesAndOnlyApplyUppercase = false, TextSizeProfile profile = null)
		{
			this.ignoreSizeChangesAndOnlyApplyUppercase = ignoreSizeChangesAndOnlyApplyUppercase;
			this.textMeshPro = textMeshPro;
			this.text = text;
			this.profile = profile;
			if (text != null)
			{
				text.TryGetComponent<TextUpperCaseSetter>(out textUpperCaseSetter);
			}
			if (profile == null)
			{
				this.profile = service.DefaultProfile;
			}
			SetupSelf();
		}

		private void SetupSelf()
		{
			originalSize = GetSize();
			originalFontStyle = GetFontStyle();
		}

		public string GetDebugString()
		{
			return $"Current: {GetSize()}, Original: {originalSize}";
		}

		public void OnEnable()
		{
			service.TextSizeSettingsChanged -= OnTextSizeSettingsChanged;
			service.TextSizeSettingsChanged += OnTextSizeSettingsChanged;
			UpdateView();
		}

		public void OnDisable()
		{
			if ((bool)service)
			{
				service.TextSizeSettingsChanged -= OnTextSizeSettingsChanged;
			}
		}

		public void Dispose()
		{
			if ((bool)service)
			{
				service.TextSizeSettingsChanged -= OnTextSizeSettingsChanged;
			}
			service = null;
			this.OnUpdated = null;
		}

		private void OnTextSizeSettingsChanged()
		{
			UpdateView();
		}

		private void UpdateView()
		{
			if (!ignoreSizeChangesAndOnlyApplyUppercase)
			{
				UpdateTextSize();
			}
			UpdateFontStyle();
		}

		private void UpdateTextSize()
		{
			if ((!(text != null) || !((float)text.fontSize <= 40f)) && (!(textMeshPro != null) || !(textMeshPro.fontSize <= 40f)))
			{
				float size = originalSize;
				if (service.IsSizeModified)
				{
					float percentage = profile.Percentage;
					size = originalSize * percentage;
				}
				SetSize(size);
			}
		}

		private void UpdateFontStyle()
		{
			if (ShouldSwitchTextMeshProStyle())
			{
				if (service.IsSizeModified)
				{
					textMeshPro.fontStyle |= FontStyles.UpperCase;
				}
				else
				{
					textMeshPro.fontStyle = originalFontStyle;
				}
			}
			else if (ShouldSwitchTextStyle())
			{
				textUpperCaseSetter.ForceUpperCase = service.IsSizeModified;
			}
		}

		private bool ShouldSwitchTextStyle()
		{
			if (text != null && (float)text.fontSize <= 40f)
			{
				return textUpperCaseSetter != null;
			}
			return false;
		}

		private bool ShouldSwitchTextMeshProStyle()
		{
			if (textMeshPro != null && textMeshPro.fontSize <= 40f)
			{
				return (originalFontStyle & FontStyles.UpperCase) == 0;
			}
			return false;
		}

		private float GetSize()
		{
			if ((bool)textMeshPro)
			{
				return textMeshPro.fontSize;
			}
			if ((bool)text)
			{
				return text.fontSize;
			}
			return 0f;
		}

		private void SetSize(float size)
		{
			if ((bool)textMeshPro)
			{
				if (!Mathf.Approximately(textMeshPro.fontSize, size))
				{
					textMeshPro.fontSize = size;
					this.OnUpdated?.Invoke();
				}
			}
			else if ((bool)text)
			{
				int num = Mathf.RoundToInt(size);
				if (text.fontSize != num)
				{
					text.fontSize = num;
					this.OnUpdated?.Invoke();
				}
			}
		}

		private FontStyles GetFontStyle()
		{
			if (!(textMeshPro == null))
			{
				return textMeshPro.fontStyle;
			}
			return FontStyles.Normal;
		}
	}
}
