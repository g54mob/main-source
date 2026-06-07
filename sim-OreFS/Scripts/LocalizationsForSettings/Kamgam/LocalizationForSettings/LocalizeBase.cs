using UnityEngine;

namespace Kamgam.LocalizationForSettings
{
	public abstract class LocalizeBase : MonoBehaviour
	{
		public LocalizationProvider LocalizationProvider;

		public string Term;

		[Tooltip("Translates the given term and sets the text of the TMPro Textfield.\n\nA string.Format(format) string can be specified. The translated text will always be appended as an additional LAST parameter to the parameters list.\n\nExample Format: {0} %")]
		public string Format;

		[Tooltip("EDITOR ONLY: If enabled then the inspector will try to find the term based on the content of the textfield.\nThis is done ONLY at edit-time NOT at runtime. It's a convenience feature only.\nIf you want to dynamically update the localization then please set the 'Term' property and then call 'Localize()'.")]
		public bool UpdateTermFromText = true;

		protected object[] _lastUsedParameters;

		protected string _lastUsedFormat;

		public virtual void Awake()
		{
			if (LocalizationProvider != null && LocalizationProvider.HasLocalization())
			{
				LocalizationProvider.GetLocalization()?.AddOnLanguageChangedListener(onLanguageChanged);
			}
		}

		protected virtual void onLanguageChanged(string language)
		{
			Localize();
		}

		public virtual void OnEnable()
		{
			if (!(LocalizationProvider == null) && LocalizationProvider.HasLocalization())
			{
				Clear();
				if (Term == null)
				{
					Term = GetText();
				}
				Localize(Term, null);
			}
		}

		public virtual void OnDisable()
		{
		}

		public abstract string GetText();

		public abstract void SetText(string text);

		public virtual void Clear()
		{
			_lastUsedFormat = null;
			_lastUsedParameters = null;
		}

		public virtual void Localize()
		{
			Localize(Term, _lastUsedFormat, _lastUsedParameters);
		}

		public virtual void Localize(string term, string format = null, params object[] parameters)
		{
			if (string.IsNullOrEmpty(term))
			{
				term = Term;
			}
			if (string.IsNullOrEmpty(term))
			{
				return;
			}
			ILocalization localization = LocalizationProvider.GetLocalization();
			if (localization == null)
			{
				return;
			}
			string text = localization.Get(term);
			if (format == null)
			{
				format = Format;
			}
			if (!string.IsNullOrEmpty(format))
			{
				if (parameters == null || parameters.Length == 0)
				{
					text = string.Format(format, text);
				}
				else
				{
					object[] array = new object[parameters.Length + 1];
					array[0] = text;
					for (int i = 0; i < parameters.Length; i++)
					{
						array[i + 1] = parameters[i];
					}
					text = string.Format(format, array);
				}
			}
			SetText(text);
		}
	}
}
