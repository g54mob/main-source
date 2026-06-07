using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Threading;
using Assets.Source.UI;
using UnityEngine;

namespace Assets.Source.Util
{
	public class Translation
	{
		public const string DefaultLanguage = "en-US";

		public const bool TestMode = false;

		private const string OverrideLanguageFile = "language.ini";

		private static Translation _default;

		private static Translation _current;

		private static Regex _comment = new Regex("^\\s*;");

		private static Regex _line = new Regex("^\\s*(.+?)\\s*=(.*)");

		private static string _highlightPlaceholder = UIHelper.HighlightText("$1");

		private static Dictionary<string, Translation> _languages;

		private Dictionary<string, string> _lines = new Dictionary<string, string>();

		public static Translation Current => _current;

		public static string CurrentLocale => _current.Locale;

		public static IEnumerable<Translation> All => _languages.Values;

		public string Locale { get; private set; }

		public string DisplayName { get; private set; }

		public Translation(TextReader reader)
		{
			using (reader)
			{
				string input;
				while ((input = reader.ReadLine()) != null)
				{
					if (!_comment.IsMatch(input))
					{
						Match match = _line.Match(input);
						if (match.Success)
						{
							_lines[match.Groups[1].Value] = match.Groups[2].Value.Trim();
						}
					}
				}
			}
			Locale = _lines["locale"];
			DisplayName = _lines["display"];
		}

		public string Get(string key)
		{
			_lines.TryGetValue(key, out var value);
			return value;
		}

		public void Apply()
		{
			_current = this;
			Thread.CurrentThread.CurrentCulture = new CultureInfo(Locale);
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(Locale);
		}

		public static void Init()
		{
			if (_default != null)
			{
				return;
			}
			_languages = new Dictionary<string, Translation>();
			TextAsset[] array = Resources.LoadAll<TextAsset>("Language/");
			for (int i = 0; i < array.Length; i++)
			{
				Translation translation = new Translation(new StringReader(array[i].text));
				_languages[translation.Locale] = translation;
			}
			_default = _languages["en-US"];
			FileInfo fileInfo = new FileInfo("language.ini");
			string key;
			if (fileInfo.Exists)
			{
				_languages["override"] = new Translation(fileInfo.OpenText());
				key = "override";
			}
			else
			{
				string text = PlayerPrefs.GetString("Locale");
				if (string.IsNullOrEmpty(text))
				{
					string text2 = "en-US";
					key = ((!_languages.ContainsKey(text2)) ? "en-US" : text2);
				}
				else
				{
					key = text;
				}
			}
			_languages[key].Apply();
		}

		public static void Clear()
		{
			_current = null;
			_default = null;
		}

		public static void UpdateLocale(Translation locale)
		{
			Init();
			PlayerPrefs.SetString("Locale", locale.Locale);
			locale.Apply();
		}

		public static string TranslateOnly(string text, params object[] values)
		{
			Init();
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}
			if (text[0] == '@')
			{
				string text2 = text.Substring(1);
				text = _current?.Get(text2);
				if (text == null)
				{
					text = _default?.Get(text2);
					if (text == null)
					{
						Debug.LogWarning("Failed to translate string: @" + text2);
						text = "@" + text2;
					}
					else
					{
						Debug.LogWarning("String not present in current language, falling back on default language: @" + text2);
					}
				}
			}
			if (values != null && values.Length != 0)
			{
				for (int i = 0; i < values.Length; i++)
				{
					if (values[i] is string { Length: >0 } text3 && text3[0] == '@')
					{
						values[i] = Translate(text3);
					}
					else if (values[i] is BigInteger number)
					{
						values[i] = GameMath.FormatNumber(number);
					}
					else if (values[i] is double num)
					{
						values[i] = GameMath.FormatNumber(num);
					}
					else if (values[i] is float num2)
					{
						values[i] = GameMath.FormatNumber(num2);
					}
					else if (values[i] is int num3)
					{
						values[i] = GameMath.FormatNumber((BigInteger)num3);
					}
				}
				text = string.Format(text, values);
			}
			return text;
		}

		public static string Translate(string text, params object[] values)
		{
			return Regex.Replace(TranslateOnly(text, values), "#(.*?)#", _highlightPlaceholder);
		}

		public static string Highlight(string text, string color, params object[] values)
		{
			return Regex.Replace(TranslateOnly(text, values), "#(.*?)#", "<color=" + color + ">$1</color>");
		}
	}
}
