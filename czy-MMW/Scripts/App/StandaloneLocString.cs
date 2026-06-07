using System;
using System.Collections.Generic;
using Factory;
using Factory.Pools;

public class StandaloneLocString : IReusable, IReleasedFromScopeHandler
{
	[Dependency]
	protected LocaleDatabase _localeDatabase;

	protected StringKey _localizedKey;

	protected LocalizedString _localizedString;

	public Locale Locale
	{
		get
		{
			if (_localizedString != null)
			{
				return _localizedString.locale;
			}
			return null;
		}
	}

	public void Init(StringKey newKey)
	{
		_localizedKey = newKey;
	}

	public virtual void ChangeLocale(Locale newLocale)
	{
		if (Diagnostics.Verify(newLocale != null, "Can't change to a null locale!"))
		{
			_localizedString = newLocale.GetString(_localizedKey);
		}
	}

	public override string ToString()
	{
		if (_localizedKey == null)
		{
			return "";
		}
		if (_localizedString == null || _localizedString.locale == null)
		{
			_localizedString = _localeDatabase.CurrentLocale.GetString(_localizedKey);
		}
		if (IsRightToLeft())
		{
			return ReverseLeftToRightText(_localizedString.ToString());
		}
		return _localizedString.ToString();
	}

	public virtual bool IsRightToLeft()
	{
		if (_localizedString != null && _localizedString.locale != null)
		{
			return _localizedString.locale.TextDirection == TextDirection.RightToLeft;
		}
		return false;
	}

	public void OnReleasedFromScope(IScope scope)
	{
		if (_localizedKey != null)
		{
			scope.Release(_localizedKey);
		}
	}

	public void Reset()
	{
		_localizedKey = null;
		_localizedString = null;
	}

	public static StandaloneLocString CreateString(IScope scope, StringKey key)
	{
		StandaloneLocString standaloneLocString = scope.Get<StandaloneLocString>();
		standaloneLocString.Init(key);
		return standaloneLocString;
	}

	public static StandaloneLocString CreateString(IScope scope, StringId fromKey)
	{
		StringKey stringKey = scope.Get<StringKey>();
		stringKey.InitWithStringId(fromKey);
		return CreateString(scope, stringKey);
	}

	public static StandaloneLocString CreateString(IScope scope, string fromKey)
	{
		StringKey stringKey = scope.Get<StringKey>();
		stringKey.InitWithString(fromKey);
		return CreateString(scope, stringKey);
	}

	public static StandaloneLocString CreateNonLocalizedString(IScope scope, string nonLocalizedString)
	{
		StringKey stringKey = scope.Get<StringKey>();
		stringKey.InitWithNonLocalizedString(nonLocalizedString);
		return CreateString(scope, stringKey);
	}

	public static StandaloneLocString CreateLocalizedNumberString(IScope scope, int number)
	{
		StringKey stringKey = scope.Get<StringKey>();
		string nonLocalizedString = scope.Get<LocaleDatabase>().CurrentLocale.FormatNumber(number);
		stringKey.InitWithNonLocalizedString(nonLocalizedString);
		return CreateString(scope, stringKey);
	}

	private static string ReverseLeftToRightText(string originalString)
	{
		if (originalString.Length == 0)
		{
			return originalString;
		}
		bool flag = originalString[0] == '<';
		List<string> list = new List<string>();
		int num = 0;
		for (int i = 1; i < originalString.Length; i++)
		{
			if (flag)
			{
				if (originalString[i] == '>')
				{
					list.Add(originalString.Substring(num, i - num + 1));
					num = i + 1;
					flag = false;
				}
			}
			else if (originalString[i] == '<')
			{
				list.Add(originalString.Substring(num, i - num));
				num = i;
				flag = true;
			}
		}
		if (num < originalString.Length)
		{
			list.Add(originalString.Substring(num, originalString.Length - num));
		}
		string text = "";
		foreach (string item in list)
		{
			if (item.Length == 0)
			{
				continue;
			}
			if (item[0] == '<')
			{
				text += item;
				continue;
			}
			int num2 = 0;
			int num3 = -1;
			bool flag2 = IsArabic(item[0]) || IsNeutralCharacter(item[0]);
			for (int j = 1; j < item.Length; j++)
			{
				if (IsNeutralCharacter(item[j]))
				{
					if (num3 == -1)
					{
						num3 = j;
					}
					continue;
				}
				if (flag2 && !IsArabic(item[j]))
				{
					text += item.Substring(num2, j - num2);
					num2 = j;
					flag2 = false;
				}
				else if (!flag2 && IsArabic(item[j]))
				{
					int num4 = ((num3 == -1) ? j : num3);
					text += ReverseString(item.Substring(num2, num4 - num2));
					num2 = num4;
					flag2 = true;
				}
				num3 = -1;
			}
			if (flag2)
			{
				text += item.Substring(num2);
				continue;
			}
			if (num3 == -1)
			{
				text += ReverseString(item.Substring(num2));
				continue;
			}
			text += ReverseString(item.Substring(num2, num3 - num2));
			text += ReverseString(item.Substring(num3));
		}
		return text.Replace("\u200f", "");
	}

	private static string ReverseString(string s)
	{
		char[] array = s.ToCharArray();
		Array.Reverse(array);
		return new string(array);
	}

	private static bool IsNeutralCharacter(int code)
	{
		if (code >= 0 && code <= 47)
		{
			return true;
		}
		if (code >= 58 && code <= 64)
		{
			return true;
		}
		return false;
	}

	private static bool IsArabic(int code)
	{
		if (code < 1536)
		{
			return false;
		}
		if (code >= 1536 && code <= 1791)
		{
			return true;
		}
		if (code >= 1872 && code <= 1919)
		{
			return true;
		}
		if (code >= 2208 && code <= 2303)
		{
			return true;
		}
		if (code >= 64336 && code <= 65023)
		{
			return true;
		}
		if (code >= 65136 && code <= 65279)
		{
			return true;
		}
		return false;
	}
}
