using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Factory;
using UnityEngine;

public class Locale
{
	public enum DaysOfTheWeek
	{
		Monday = 0,
		Tuesday = 1,
		Wednesday = 2,
		Thursday = 3,
		Friday = 4,
		Saturday = 5,
		Sunday = 6
	}

	private static readonly Dictionary<string, ControllerButton> ActionsToButtons = new Dictionary<string, ControllerButton>
	{
		{
			"Build",
			ControllerButton.FaceButtonBottom
		},
		{
			"ToggleDeleteMode",
			ControllerButton.FaceButtonTop
		},
		{
			"Delete",
			ControllerButton.FaceButtonRight
		},
		{
			"IncreaseGameSpeed",
			ControllerButton.ButtonRight
		},
		{
			"DecreaseGameSpeed",
			ControllerButton.ButtonLeft
		}
	};

	private IScope _scope;

	private Dictionary<string, List<string>> _stringTable;

	private PluralForm _pluralForm;

	private string _cannotStartLines;

	private string _cannotEndLines;

	private string _cannotSplit;

	private LocaleDatabase _database;

	public LocaleDatabase.LocaleId Id { get; private set; }

	public string Name { get; private set; }

	public bool IsComplete { get; private set; }

	public TextDirection TextDirection { get; private set; }

	public DigitGrouping DigitGrouping { get; private set; }

	public StartOfWeek StartOfWeek { get; private set; }

	public bool CapitaliseNouns { get; private set; }

	public string Charset { get; private set; }

	public bool IsSelectable => Name != null;

	public LineBreakRule LineBreakRule
	{
		get
		{
			if (_cannotStartLines != null || _cannotEndLines != null || _cannotSplit != null)
			{
				return LineBreakRule.EastAsian;
			}
			return LineBreakRule.Western;
		}
	}

	public bool TryGetRawStrings(string stringId, out List<string> strings)
	{
		if (Diagnostics.Verify(_stringTable.TryGetValue(stringId, out strings), "No string id for '{0}' in locale '{1}'", stringId, Id))
		{
			return true;
		}
		return false;
	}

	public LocalizedString GetString(StringKey key)
	{
		string stringId = key.GetStringId();
		int a = 0;
		if (key.IsPlural())
		{
			a = GetPluralForm(key.GetCount());
		}
		if (!_stringTable.ContainsKey(stringId))
		{
			Locale fallbackLocale = _database.FallbackLocale;
			if (fallbackLocale != null && fallbackLocale != this)
			{
				return fallbackLocale.GetString(key);
			}
			Diagnostics.FailAssert("Failed to retrieve a string with key {0}", key.GetStringId());
			return new LocalizedString(fallbackLocale, stringId.ToUpperInvariant());
		}
		List<string> list = _stringTable[stringId];
		string text = list[Mathf.Min(a, list.Count - 1)];
		if (string.IsNullOrEmpty(text))
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] != null && list[i].Length > 0)
				{
					text = list[i];
					break;
				}
			}
		}
		if (text == null)
		{
			return new LocalizedString(this, "");
		}
		IControllerButtonToSymbolService controllerButtonToSymbolService = _scope.Get<IControllerButtonToSymbolService>();
		foreach (KeyValuePair<string, ControllerButton> actionsToButton in ActionsToButtons)
		{
			string text2 = "{ActionIcon=" + actionsToButton.Key + "}";
			for (int num = text.IndexOf(text2, StringComparison.InvariantCulture); num >= 0; num = text.IndexOf(text2, StringComparison.InvariantCulture))
			{
				string textMeshProSymbolTextForControllerButton = controllerButtonToSymbolService.GetTextMeshProSymbolTextForControllerButton(actionsToButton.Value);
				text = text.Substring(0, num) + textMeshProSymbolTextForControllerButton + text.Substring(num + text2.Length);
			}
		}
		if (key.GetParameters() == null)
		{
			return new LocalizedString(this, text);
		}
		foreach (KeyValuePair<string, string> parameter in key.GetParameters())
		{
			string text3 = "{" + parameter.Key + "}";
			int num2 = text.IndexOf(text3, StringComparison.InvariantCulture);
			string value = parameter.Value;
			while (num2 >= 0)
			{
				bool flag = false;
				if (value.Length > 0 && value[value.Length - 1] == '.')
				{
					int num3 = num2 + text3.Length;
					if (num3 < text.Length && text[num3] == '.')
					{
						flag = true;
					}
				}
				text = text.Substring(0, num2) + value + text.Substring(num2 + text3.Length + (flag ? 1 : 0));
				num2 = text.IndexOf(text3, num2 + value.Length, StringComparison.InvariantCulture);
			}
		}
		return new LocalizedString(this, text);
	}

	protected static bool IsCJK(int code)
	{
		if (code < 11904)
		{
			return false;
		}
		if (code >= 11904 && code <= 55215)
		{
			return true;
		}
		if (code >= 63744 && code <= 64255)
		{
			return true;
		}
		if (code >= 65072 && code <= 65103)
		{
			return true;
		}
		if (code >= 131072 && code <= 195103)
		{
			return true;
		}
		return false;
	}

	protected static bool IsThai(int code)
	{
		if (code >= 3584)
		{
			return code <= 3711;
		}
		return false;
	}

	protected static bool IsHindi(int code)
	{
		if (code >= 2304 && code <= 2431)
		{
			return true;
		}
		if (code >= 43232 && code <= 43263)
		{
			return true;
		}
		if (code >= 7376 && code <= 7423)
		{
			return true;
		}
		return false;
	}

	protected static bool IsToneMark(int code)
	{
		if (!IsThai(code))
		{
			return false;
		}
		switch (code)
		{
		default:
			if (code >= 3655)
			{
				return code <= 3662;
			}
			return false;
		case 3633:
		case 3636:
		case 3637:
		case 3638:
		case 3639:
		case 3640:
		case 3641:
		case 3642:
			return true;
		}
	}

	public string GetNoun(StringKey key)
	{
		LocalizedString localizedString = GetString(key);
		if (localizedString.localString == null)
		{
			return null;
		}
		if (CapitaliseNouns)
		{
			return localizedString.localString;
		}
		return localizedString.localString.ToLower();
	}

	public string DativeFormat(string noun)
	{
		if (Id == LocaleDatabase.LocaleId.hr || Id == LocaleDatabase.LocaleId.sr_Latin || Id == LocaleDatabase.LocaleId.sr || Id == LocaleDatabase.LocaleId.hu)
		{
			return ChangeEndingToDative(noun);
		}
		if (Id == LocaleDatabase.LocaleId.pl)
		{
			string[] array = noun.Split(' ');
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ChangeEndingToDative(array[i]);
			}
			return string.Join(" ", array);
		}
		return noun;
	}

	public string LocativeFormat(string noun)
	{
		if (Id == LocaleDatabase.LocaleId.hr || Id == LocaleDatabase.LocaleId.sr_Latin || Id == LocaleDatabase.LocaleId.sr)
		{
			return ChangeEndingToLocative(noun);
		}
		if (Id == LocaleDatabase.LocaleId.pl)
		{
			string[] array = noun.Split(' ');
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ChangeEndingToLocative(array[i]);
			}
			return string.Join(" ", array);
		}
		return noun;
	}

	public string IllativeFormat(string noun)
	{
		if (Id == LocaleDatabase.LocaleId.fi)
		{
			return ChangeEndingToIllative(noun);
		}
		return noun;
	}

	private string ChangeEndingToDative(string noun)
	{
		string text = noun;
		if (Id == LocaleDatabase.LocaleId.hr || Id == LocaleDatabase.LocaleId.sr_Latin)
		{
			if (noun.Length < 1)
			{
				return noun;
			}
			char c = noun[noun.Length - 1] switch
			{
				'a' => 'i', 
				'o' => 'u', 
				_ => ' ', 
			};
			text = ((c == ' ') ? (text + "u") : (noun.Remove(noun.Length - 1, 1) + c));
		}
		else if (Id == LocaleDatabase.LocaleId.sr)
		{
			if (noun.Length < 1)
			{
				return noun;
			}
			int num;
			switch (noun[noun.Length - 1])
			{
			default:
				num = 32;
				break;
			case 'a':
			case 'а':
				num = 1080;
				break;
			case 'o':
				num = 121;
				break;
			}
			char c2 = (char)num;
			text = ((c2 == ' ') ? (text + "y") : (noun.Remove(noun.Length - 1, 1) + c2));
		}
		else if (Id == LocaleDatabase.LocaleId.hu)
		{
			if (noun.Length < 1)
			{
				return noun;
			}
			char c3 = noun[noun.Length - 1];
			char c4 = ' ';
			switch (c3)
			{
			case 'a':
				c4 = 'á';
				break;
			case 'e':
				c4 = 'é';
				break;
			case 'i':
				c4 = 'í';
				break;
			case 'o':
				c4 = 'ó';
				break;
			case 'ö':
				c4 = 'ő';
				break;
			case 'u':
				c4 = 'ú';
				break;
			case 'ü':
				c4 = 'ű';
				break;
			}
			if (c4 != ' ')
			{
				text = text.Remove(text.Length - 1, 1) + c4;
			}
			char value = ' ';
			string text2 = "aáeéiíoöóőuüúű";
			string text3 = text.ToLower();
			for (int i = 0; i < text.Length; i++)
			{
				if (text2.IndexOf(text3[i]) != -1)
				{
					value = text3[i];
					break;
				}
			}
			text = (("eéuüúű".IndexOf(value) == -1) ? (text + "ban") : (text + "ben"));
		}
		else if (Id == LocaleDatabase.LocaleId.pl)
		{
			if (noun.Length < 1)
			{
				return noun;
			}
			switch (noun[noun.Length - 1])
			{
			case 'm':
			case 'n':
				text += "ie";
				break;
			case 'r':
				text += "ze";
				break;
			case 'g':
			case 'k':
			case 'l':
			case 'ż':
				text += "u";
				break;
			case 'y':
				text += "m";
				break;
			default:
			{
				if (noun.Length < 2)
				{
					return noun;
				}
				string text4 = noun.Substring(noun.Length - 2);
				if (text4 == "ka")
				{
					text = noun.Substring(0, noun.Length - 2) + "ce";
				}
				else if (text4 == "na")
				{
					text = noun.Substring(0, noun.Length - 2) + "nej";
				}
				break;
			}
			}
		}
		return text;
	}

	private string ChangeEndingToLocative(string noun)
	{
		string result = noun;
		if (Id == LocaleDatabase.LocaleId.hr || Id == LocaleDatabase.LocaleId.sr_Latin)
		{
			if (noun.Length < 2)
			{
				return noun;
			}
			if (noun.Substring(noun.Length - 2) == "in")
			{
				result = noun.Substring(0, noun.Length - 2) + "nom";
			}
		}
		else if (Id == LocaleDatabase.LocaleId.sr)
		{
			if (noun.Length < 2)
			{
				return noun;
			}
			if (noun.Substring(noun.Length - 2) == "ин")
			{
				result = noun.Substring(0, noun.Length - 2) + "ном";
			}
		}
		else if (Id == LocaleDatabase.LocaleId.pl)
		{
			return ChangeEndingToDative(noun);
		}
		return result;
	}

	private string ChangeEndingToIllative(string noun)
	{
		if (Id == LocaleDatabase.LocaleId.fi)
		{
			if (noun == null || noun.Length < 2)
			{
				return noun;
			}
			string text = noun;
			string text2 = noun.Substring(noun.Length - 1);
			switch (text2)
			{
			case "a":
			case "ä":
			case "e":
			case "i":
			case "o":
			case "ö":
			case "u":
			case "y":
				text = text + text2 + "n";
				break;
			default:
				text2 = noun.Substring(noun.Length - 2);
				if (text2 == "er")
				{
					text += "iin";
				}
				break;
			}
			return text;
		}
		return noun;
	}

	public string FormatNumber(int number)
	{
		return FormatNumber((long)number);
	}

	public string FormatNumber(long number)
	{
		string text = "";
		switch (DigitGrouping)
		{
		case DigitGrouping.SpaceThousands:
			return $"{number:#,###0}".Replace(',', ' ');
		case DigitGrouping.PeriodThousands:
			return $"{number:#,###0}".Replace(',', '.');
		case DigitGrouping.CommaTenThousands:
		{
			string text3 = number.ToString();
			StringBuilder stringBuilder2 = new StringBuilder();
			while (text3.Length > 4)
			{
				stringBuilder2.Insert(0, text3.Substring(text3.Length - 4));
				stringBuilder2.Insert(0, ',');
				text3 = text3.Substring(0, text3.Length - 4);
			}
			stringBuilder2.Insert(0, text3);
			return stringBuilder2.ToString();
		}
		case DigitGrouping.CommaThousandsHundreds:
		{
			string text2 = number.ToString();
			StringBuilder stringBuilder = new StringBuilder();
			if (text2.Length > 3)
			{
				stringBuilder.Insert(0, text2.Substring(text2.Length - 3));
				stringBuilder.Insert(0, ',');
				text2 = text2.Substring(0, text2.Length - 3);
			}
			while (text2.Length > 2)
			{
				stringBuilder.Insert(0, text2.Substring(text2.Length - 2));
				stringBuilder.Insert(0, ',');
				text2 = text2.Substring(0, text2.Length - 2);
			}
			stringBuilder.Insert(0, text2);
			return stringBuilder.ToString();
		}
		default:
			return $"{number:#,###0}";
		}
	}

	public StringKey FormatMinutes(int numMinutes)
	{
		if (numMinutes < 120)
		{
			string value = FormatNumber(numMinutes);
			StringKey stringKey = _scope.Get<StringKey>();
			stringKey.InitWithString("Minutes", numMinutes, new Dictionary<string, string> { { "Num", value } });
			return stringKey;
		}
		int num = numMinutes / 60;
		string value2 = FormatNumber(num);
		StringKey stringKey2 = _scope.Get<StringKey>();
		stringKey2.InitWithString("Hours", num, new Dictionary<string, string> { { "Num", value2 } });
		return stringKey2;
	}

	public string FormatDate(DateTime date, bool formatForLocString = true)
	{
		return FormatDateTime(date, "d", formatForLocString);
	}

	public string FormatDateTime(DateTime dateTime, bool formatForLocString = true)
	{
		return FormatDateTime(dateTime, "g", formatForLocString);
	}

	public DaysOfTheWeek GetDayLabel(int index)
	{
		int num = ((StartOfWeek != StartOfWeek.Monday) ? 6 : 0);
		return (DaysOfTheWeek)(0 + (index + num) % 7);
	}

	public bool HasString(StringKey key)
	{
		return _stringTable.ContainsKey(key.GetStringId());
	}

	public string GetNextToken(string text, ref int nextCharIndex)
	{
		string text2 = "";
		if (LineBreakRule == LineBreakRule.EastAsian)
		{
			if (nextCharIndex < text.Length)
			{
				text2 += text[nextCharIndex];
				nextCharIndex++;
			}
			while (nextCharIndex < text.Length)
			{
				char c = text2[text2.Length - 1];
				char c2 = text[nextCharIndex];
				if ((_cannotEndLines == null || _cannotEndLines.IndexOf(c) == -1) & (_cannotStartLines == null || _cannotStartLines.IndexOf(c2) == -1) & (_cannotSplit == null || (_cannotSplit.IndexOf(c) == -1 && _cannotSplit.IndexOf(c2) == -1)) & (!char.IsNumber(c) || !char.IsNumber(c2)) & (!IsLatin(c) || !IsLatin(c2)))
				{
					return text2;
				}
				text2 += c2;
				nextCharIndex++;
			}
		}
		else
		{
			while (nextCharIndex < text.Length && text[nextCharIndex] != ' ' && text[nextCharIndex] != '\n')
			{
				text2 += text[nextCharIndex];
				nextCharIndex++;
				if (text[nextCharIndex - 1] == '-')
				{
					break;
				}
			}
		}
		return text2;
	}

	private static bool IsLatin(char character)
	{
		if (character >= 'A' && character <= 'Z')
		{
			return true;
		}
		if (character >= 'a' && character <= 'z')
		{
			return true;
		}
		return false;
	}

	public static Locale FromJSON(JSON.Dictionary jsonDictionary, LocaleDatabase creatingDatabase, IScope newScope)
	{
		string text = jsonDictionary.GetString("id");
		if (text == null)
		{
			return null;
		}
		Locale locale = new Locale(text, creatingDatabase, newScope);
		if (jsonDictionary.ContainsKey("isComplete"))
		{
			locale.IsComplete = jsonDictionary.GetBool("isComplete");
		}
		else
		{
			locale.IsComplete = true;
		}
		string text2 = jsonDictionary.GetString("textDirection");
		locale.TextDirection = ((text2 != null && text2 == "rtl") ? TextDirection.RightToLeft : TextDirection.LeftToRight);
		string text3 = jsonDictionary.GetString("digitGrouping");
		locale.DigitGrouping = ((text3 != null) ? ((DigitGrouping)Enum.Parse(typeof(DigitGrouping), text3)) : DigitGrouping.CommaThousands);
		string text4 = jsonDictionary.GetString("pluralForm");
		locale._pluralForm = ((text4 == null) ? PluralForm.Latin : ((PluralForm)Enum.Parse(typeof(PluralForm), text4)));
		string text5 = jsonDictionary.GetString("startOfWeek");
		locale.StartOfWeek = ((text5 != null) ? ((StartOfWeek)Enum.Parse(typeof(StartOfWeek), text5)) : StartOfWeek.Sunday);
		locale.CapitaliseNouns = jsonDictionary.ContainsKey("capitaliseNouns") && jsonDictionary.GetBool("capitaliseNouns");
		if (jsonDictionary.ContainsKey("charset"))
		{
			locale.Charset = jsonDictionary.GetString("charset");
		}
		else
		{
			locale.Charset = "latin";
		}
		string text6 = jsonDictionary.GetString("name");
		if (text6 != null)
		{
			locale.Name = text6;
		}
		JSON.Dictionary dictionary = jsonDictionary.GetDictionary("lineBreakRules");
		if (dictionary != null)
		{
			locale._cannotStartLines = dictionary.GetString("cannotStartLines");
			locale._cannotEndLines = dictionary.GetString("cannotEndLines");
			locale._cannotSplit = dictionary.GetString("cannotSplit");
		}
		JSON.Dictionary dictionary2 = jsonDictionary.GetDictionary("stringTable");
		if (dictionary2 == null)
		{
			return null;
		}
		foreach (string key in dictionary2.Keys)
		{
			object obj = dictionary2[key];
			if (obj == null)
			{
				continue;
			}
			List<string> list = new List<string>();
			if (obj is string)
			{
				list.Add(obj as string);
			}
			else if (obj is JSON.Array && obj is JSON.Array array)
			{
				for (int i = 0; i < array.Count; i++)
				{
					string text7 = array.GetString(i);
					if (text7 != null)
					{
						list.Add(text7);
					}
				}
			}
			if (list.Count != 0)
			{
				locale._stringTable[key] = list;
			}
		}
		return locale;
	}

	private Locale(string newId, LocaleDatabase newDatabase, IScope newScope)
	{
		LocaleDatabase.LocaleId result = LocaleDatabase.LocaleId.Unknown;
		Enum.TryParse<LocaleDatabase.LocaleId>(newId, out result);
		Id = result;
		_stringTable = new Dictionary<string, List<string>>();
		_database = newDatabase;
		_scope = newScope;
	}

	private int GetPluralForm(int n)
	{
		int num = 0;
		switch (_pluralForm)
		{
		case PluralForm.Asian:
			return 0;
		default:
			return (n != 1) ? 1 : 0;
		case PluralForm.French:
			return (n > 1) ? 1 : 0;
		case PluralForm.Czech:
		{
			int result;
			switch (n)
			{
			default:
				result = 3;
				break;
			case 2:
			case 3:
			case 4:
				result = 1;
				break;
			case 1:
				result = 0;
				break;
			}
			return result;
		}
		case PluralForm.Polish:
			return (n != 1) ? ((n % 10 >= 2 && n % 10 <= 4 && (n % 100 < 12 || n % 100 > 14)) ? 1 : ((n % 10 == 0 || n % 10 == 1 || (n % 10 >= 5 && n % 10 <= 9) || (n % 100 >= 12 && n % 100 <= 14)) ? 2 : 3)) : 0;
		case PluralForm.Serbian:
			return (n % 10 != 1 || n % 100 == 11) ? ((n % 10 >= 2 && n % 10 <= 4 && (n % 100 < 10 || n % 100 >= 20)) ? 1 : 2) : 0;
		case PluralForm.Romanian:
			return (n != 1) ? ((n % 100 <= 19 && (n % 100 != 0 || n == 0)) ? 1 : 2) : 0;
		case PluralForm.Ukrainian:
			return (n % 10 != 1 || n % 100 == 11) ? ((n % 10 >= 2 && n % 10 <= 4 && (n % 100 < 12 || n % 100 > 14)) ? 1 : ((n % 10 == 0 || (n % 10 >= 5 && n % 10 <= 9) || (n % 100 >= 11 && n % 100 <= 14)) ? 2 : 3)) : 0;
		case PluralForm.Russian:
			return (n % 10 != 1 || n % 100 == 11) ? ((n % 10 >= 2 && n % 10 <= 4 && (n % 100 < 12 || n % 100 > 14)) ? 1 : ((n % 10 == 0 || (n % 10 >= 5 && n % 10 <= 9) || (n % 100 >= 11 && n % 100 <= 14)) ? 2 : 3)) : 0;
		case PluralForm.Slovenian:
			return (n % 100 == 1) ? 1 : ((n % 100 == 2) ? 2 : ((n % 100 == 3 || n % 100 == 4) ? 3 : 0));
		case PluralForm.Gaelic:
			return (n != 1) ? ((n == 2) ? 1 : ((n < 7) ? 2 : ((n < 11) ? 3 : 4))) : 0;
		case PluralForm.Welsh:
			return n switch
			{
				6 => 4, 
				3 => 3, 
				2 => 2, 
				1 => 1, 
				0 => 0, 
				_ => 5, 
			};
		case PluralForm.Arabic:
			return n switch
			{
				2 => 2, 
				1 => 1, 
				0 => 0, 
				_ => (n % 100 >= 3 && n % 100 <= 10) ? 3 : ((n % 100 >= 11 && n % 100 <= 99) ? 4 : 5), 
			};
		}
	}

	private string FormatDateTime(DateTime timestamp, string formatCode, bool formatRtlForLocString)
	{
		string text = Id.ToString().Replace('_', '-');
		bool flag = false;
		if (text == "ar")
		{
			flag = true;
			text = "ar-EG";
		}
		CultureInfo cultureInfo = null;
		if (text == "en-US")
		{
			CultureInfo currentCulture = CultureInfo.CurrentCulture;
			if (currentCulture.TwoLetterISOLanguageName == "en")
			{
				cultureInfo = currentCulture;
			}
		}
		if (cultureInfo == null)
		{
			cultureInfo = new CultureInfo(text);
		}
		string text2 = timestamp.ToString(formatCode, cultureInfo);
		if (flag)
		{
			if (formatRtlForLocString)
			{
				if (text2.Contains("م"))
				{
					text2 = text2.Replace("م", "").Trim();
					text2 = "ﻡ " + text2;
				}
				if (text2.Contains("ص"))
				{
					text2 = text2.Replace("ص", "").Trim();
					text2 = "ﺹ " + text2;
				}
			}
			else
			{
				text2 = text2.Replace("م", "ﻡ");
				text2 = text2.Replace("ص", "ﺹ");
			}
		}
		return text2;
	}
}
