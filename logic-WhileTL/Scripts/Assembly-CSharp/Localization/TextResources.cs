using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using App.Data;
using Unity.Components.Events;

namespace Localization
{
	internal static class TextResources
	{
		public delegate bool TryGetText(string key, out TextInGame value);

		public static WeakEvent TextsUpdated = new WeakEvent();

		private static Model model;

		private const string DEFAULT_VALUE = "$NO_TEXT$";

		private static TryGetText _resourcesHandler;

		public static Dictionary<string, string> texts = new Dictionary<string, string>();

		public static string ExampleText => GetString("ExampleText");

		public static bool IsReady { get; private set; }

		public static void SetResourcesAccessHandler(TryGetText handler, Model mod)
		{
			_resourcesHandler = handler;
			IsReady = true;
			model = mod;
			UpdateTexts();
		}

		public static bool IsKeyExists(string key)
		{
			TextInGame value;
			return _resourcesHandler(key, out value);
		}

		private static string GetUntaggedString(string str)
		{
			if (str.Length > 2)
			{
				return str.Substring(1, str.Length - 2);
			}
			return str;
		}

		private static string GetStringMatchEvaluator(Match match)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (match.Groups[2].Value != "")
			{
				stringBuilder.Append(GetUntaggedString(match.Groups[1].Value));
				stringBuilder.Append(__GetString__(match.Groups[2].Value));
			}
			else
			{
				stringBuilder.Append(GetUntaggedString(match.Groups[3].Value));
			}
			return stringBuilder.ToString();
		}

		public static string GetString(string key)
		{
			if (texts.ContainsKey(key))
			{
				return texts[key];
			}
			string text = Regex.Replace(key, "(^|<[^<>]*>)([^<>]+)|($|<[^<>]*>)", GetStringMatchEvaluator);
			texts.Add(key, text);
			return text;
		}

		private static string GetLocalizedString(string original, string defalult)
		{
			string text = original;
			if (string.IsNullOrEmpty(text))
			{
				text = defalult;
			}
			else if (string.IsNullOrWhiteSpace(text))
			{
				text = defalult;
			}
			else if (original.ToUpper() == "$NO_LOCALIZATION$".ToUpper())
			{
				text = defalult;
			}
			return text.Replace("\\n", "\n");
		}

		private static string __GetString__(string key)
		{
			if (_resourcesHandler == null)
			{
				return "$NO_TEXT$";
			}
			if (key == "GREEN" && model.globalSaves.IsSet(SaveFlags.ColorBlind))
			{
				key = "YELLOW";
			}
			if (!_resourcesHandler(key, out var value))
			{
				return $"${key}_NO_TEXT$";
			}
			if (model == null)
			{
				return value.en.Replace("\\n", "\n");
			}
			string result = "";
			switch (model.globalSaves.lang)
			{
			case 0:
				result = GetLocalizedString(value.en, value.en);
				break;
			case 1:
				result = GetLocalizedString(value.ru, value.en);
				break;
			case 2:
				result = GetLocalizedString(value.zh_ch, value.en);
				break;
			case 3:
				result = GetLocalizedString(value.zh_tw, GetLocalizedString(value.zh_ch, value.en));
				break;
			case 4:
				result = GetLocalizedString(value.kr, value.en);
				break;
			case 5:
				result = GetLocalizedString(value.gr, value.en);
				break;
			case 6:
				result = GetLocalizedString(value.pt_br, value.en);
				break;
			case 7:
				result = GetLocalizedString(value.de, value.en);
				break;
			case 8:
				result = GetLocalizedString(value.pl, value.en);
				break;
			case 9:
				result = GetLocalizedString(value.fr, value.en);
				break;
			case 10:
				result = GetLocalizedString(value.hu, value.en);
				break;
			case 11:
				result = GetLocalizedString(value.cz, value.en);
				break;
			case 12:
				result = GetLocalizedString(value.fin, value.en);
				break;
			case 13:
				result = GetLocalizedString(value.he, value.en);
				break;
			case 14:
				result = GetLocalizedString(value.it, value.en);
				break;
			case 15:
				result = GetLocalizedString(value.jp, value.en);
				break;
			case 16:
				result = GetLocalizedString(value.sp, value.en);
				break;
			case 17:
				result = GetLocalizedString(value.dn, value.en);
				break;
			case 18:
				result = GetLocalizedString(value.tur, value.en);
				break;
			case 19:
				result = GetLocalizedString(value.dut, value.en);
				break;
			case 20:
				result = GetLocalizedString(value.uk, value.en);
				break;
			case 21:
				result = GetLocalizedString(value.uk, GetLocalizedString(value.ru, value.en));
				break;
			case 22:
				result = GetLocalizedString(value.en_us, value.en);
				break;
			case 23:
				result = GetLocalizedString(value.viet, value.en);
				break;
			case 24:
				result = GetLocalizedString(value.kr_gpt, value.en);
				break;
			case 25:
				result = GetLocalizedString(value.gr_gpt, value.en);
				break;
			case 26:
				result = GetLocalizedString(value.pt_br_gpt, value.en);
				break;
			case 27:
				result = GetLocalizedString(value.de_gpt, value.en);
				break;
			case 28:
				result = GetLocalizedString(value.pl_gpt, value.en);
				break;
			case 29:
				result = GetLocalizedString(value.fr_gpt, value.en);
				break;
			case 30:
				result = GetLocalizedString(value.hu_gpt, value.en);
				break;
			case 31:
				result = GetLocalizedString(value.cz_gpt, value.en);
				break;
			case 32:
				result = GetLocalizedString(value.fin_gpt, value.en);
				break;
			case 33:
				result = GetLocalizedString(value.he_gpt, value.en);
				break;
			case 34:
				result = GetLocalizedString(value.it_gpt, value.en);
				break;
			case 35:
				result = GetLocalizedString(value.jp_gpt, value.en);
				break;
			case 36:
				result = GetLocalizedString(value.sp_gpt, value.en);
				break;
			case 37:
				result = GetLocalizedString(value.dn_gpt, value.en);
				break;
			case 38:
				result = GetLocalizedString(value.tur_gpt, value.en);
				break;
			case 39:
				result = GetLocalizedString(value.dut_gpt, value.en);
				break;
			case 40:
				result = GetLocalizedString(value.uk_gpt, value.en);
				break;
			case 41:
				result = GetLocalizedString(value.viet_gpt, value.en);
				break;
			case 42:
				result = GetLocalizedString(value.ar_gpt, value.en);
				break;
			case 43:
				result = GetLocalizedString(value.id_gpt, value.en);
				break;
			case 44:
				result = GetLocalizedString(value.sv_gpt, value.en);
				break;
			case 45:
				result = GetLocalizedString(value.ro_gpt, value.en);
				break;
			case 46:
				result = GetLocalizedString(value.me_gpt, value.en);
				break;
			case 47:
				result = GetLocalizedString(value.port_gpt, value.en);
				break;
			case 48:
				result = GetLocalizedString(value.bg_gpt, value.en);
				break;
			case 49:
				result = GetLocalizedString(value.no_gpt, value.en);
				break;
			case 50:
				result = GetLocalizedString(value.th_gpt, value.en);
				break;
			}
			return result;
		}

		public static void DropCachedTexts()
		{
			texts.Clear();
		}

		public static void UpdateTexts()
		{
			try
			{
				TextsUpdated.Invoke();
			}
			catch
			{
			}
		}
	}
}
