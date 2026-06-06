using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.SmartFormat.Core.Extensions;
using UnityEngine.Localization.SmartFormat.Core.Formatting;
using UnityEngine.Localization.SmartFormat.Core.Parsing;
using UnityEngine.Localization.SmartFormat.Extensions;
using UnityEngine.Localization.SmartFormat.Utilities;
using UnityEngine.ResourceManagement.AsyncOperations;

[Serializable]
public class PluralDefaultLocalizationFormatter : PluralLocalizationFormatter
{
	[SerializeField]
	public int defaultValue;

	[SerializeField]
	public char parameterDelimiter = ',';

	public override bool TryEvaluateFormat(IFormattingInfo formattingInfo)
	{
		Format format = formattingInfo.Format;
		object currentValue = formattingInfo.CurrentValue;
		(int value, string ruleLanguage) tuple = ParseFormatterOptions(formattingInfo);
		decimal num = tuple.value;
		string item = tuple.ruleLanguage;
		if (format == null || format.baseString[format.startIndex] == ':')
		{
			return false;
		}
		IList<Format> list = format.Split('|');
		if (list.Count == 1)
		{
			return false;
		}
		if (currentValue is IConvertible convertible && !(currentValue is DateTime) && !(currentValue is string) && !(currentValue is bool) && !(currentValue is Enum))
		{
			num = convertible.ToDecimal(null);
		}
		else if (currentValue is IEnumerable<object> source)
		{
			num = source.Count();
		}
		PluralRules.PluralRuleDelegate pluralRuleDefaults = GetPluralRuleDefaults(formattingInfo, item);
		if (pluralRuleDefaults == null)
		{
			return false;
		}
		int count = list.Count;
		int num2 = pluralRuleDefaults(num, count);
		if (num2 >= count)
		{
			num2 = count - 1;
		}
		if (num2 == 0 && num != 0m && count >= 3)
		{
			num2 = count - 1;
		}
		if (num2 < 0)
		{
			throw new FormattingException(format, "Invalid number of plural parameters", list.Last().endIndex);
		}
		Format format2 = list[num2];
		formattingInfo.Write(format2, currentValue);
		return true;
	}

	private PluralRules.PluralRuleDelegate GetPluralRuleDefaults(IFormattingInfo formattingInfo, string ruleParameter)
	{
		if (!string.IsNullOrEmpty(ruleParameter))
		{
			return PluralRules.GetPluralRule(ruleParameter);
		}
		IFormatProvider formatProvider = formattingInfo.FormatDetails.Provider;
		CustomPluralRuleProvider customPluralRuleProvider = (CustomPluralRuleProvider)(formatProvider?.GetFormat(typeof(CustomPluralRuleProvider)));
		if (customPluralRuleProvider != null)
		{
			return customPluralRuleProvider.GetPluralRule();
		}
		if (formatProvider is Locale { Identifier: var identifier })
		{
			formatProvider = identifier.CultureInfo;
		}
		if (formatProvider is CultureInfo cultureInfo)
		{
			return PluralRules.GetPluralRule(cultureInfo.TwoLetterISOLanguageName);
		}
		Locale locale2 = null;
		AsyncOperationHandle<Locale> selectedLocaleAsync = LocalizationSettings.SelectedLocaleAsync;
		if (selectedLocaleAsync.IsValid() && selectedLocaleAsync.IsDone)
		{
			locale2 = selectedLocaleAsync.Result;
		}
		if ((bool)locale2)
		{
			CultureInfo cultureInfo2 = locale2.Identifier.CultureInfo;
			string twoLetterIsoLanguageName;
			if (cultureInfo2 != null)
			{
				twoLetterIsoLanguageName = cultureInfo2.TwoLetterISOLanguageName;
			}
			else
			{
				twoLetterIsoLanguageName = locale2.Identifier.Code;
				if (locale2.Identifier.Code.Length > 2)
				{
					twoLetterIsoLanguageName = locale2.Identifier.Code.Substring(0, 2);
				}
			}
			PluralRules.PluralRuleDelegate pluralRule = PluralRules.GetPluralRule(twoLetterIsoLanguageName);
			if (pluralRule != null)
			{
				return pluralRule;
			}
		}
		return PluralRules.GetPluralRule(base.DefaultTwoLetterISOLanguageName);
	}

	private (int value, string ruleLanguage) ParseFormatterOptions(IFormattingInfo formattingInfo)
	{
		string[] array = formattingInfo.FormatterOptions.Split(parameterDelimiter);
		switch (array.Length)
		{
		case 0:
			return (value: defaultValue, ruleLanguage: null);
		case 1:
		{
			if (int.TryParse(array[0], out var result3))
			{
				return (value: result3, ruleLanguage: null);
			}
			return (value: defaultValue, ruleLanguage: null);
		}
		case 2:
		{
			if (int.TryParse(array[0], out var result))
			{
				return (value: result, ruleLanguage: array[1]);
			}
			if (int.TryParse(array[1], out var result2))
			{
				return (value: result2, ruleLanguage: array[0]);
			}
			break;
		}
		}
		return (value: defaultValue, ruleLanguage: null);
	}
}
