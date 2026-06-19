using System;
using System.IO;
using System.Text;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[DontSaveAssetReference]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public struct LocalisedString
	{
		[SerializeField]
		private string _term;

		private static readonly string kDefaultLanguage = "English";

		private static readonly string[] kPluralCodes = new string[6] { "[i2p_Zero]", "[i2p_One]", "[i2p_Two]", "[i2p_Few]", "[i2p_Many]", "[i2p_Plural]" };

		public string Term
		{
			get
			{
				return _term;
			}
			set
			{
				_term = value;
			}
		}

		public string Translation => LocalizationManager.GetTranslation(_term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters: true);

		public LocalisedString(string term)
		{
			_term = term;
		}

		public override string ToString()
		{
			if (LocalizationManager.Sources.Count > 0)
			{
				if (!LocalizationManager.Sources[0].TryGetTranslation(_term, out var Translation, kDefaultLanguage))
				{
					return string.Empty;
				}
				return GetPluralString(1, Translation, kDefaultLanguage);
			}
			return string.Empty;
		}

		public string ToAnalyticsTermString(bool bReturnLeafTermOnly = true)
		{
			if (!bReturnLeafTermOnly)
			{
				return _term;
			}
			return Path.GetFileName(_term);
		}

		public string TranslationPlural(int count)
		{
			return GetTranslationPlural(Term, count);
		}

		public T GetAsset<T>() where T : UnityEngine.Object
		{
			if (Translation == null)
			{
				return null;
			}
			return LocalizationManager.FindAsset(Translation) as T;
		}

		public static string GetTranslationPlural(string term, int count)
		{
			string Translation = null;
			LocalizationManager.InitializeIfNeeded();
			int i = 0;
			for (int count2 = LocalizationManager.Sources.Count; i < count2; i++)
			{
				if (LocalizationManager.Sources[i].TryGetTranslation(term, out Translation))
				{
					Translation = GetPluralString(count, Translation, LocalizationManager.CurrentLanguageCode);
				}
			}
			return Translation;
		}

		private static string GetPluralString(int count, string translation, string languageCode)
		{
			ePluralType pluralType = GoogleLanguages.GetPluralType(languageCode, count);
			string text = kPluralCodes[(int)pluralType];
			int num = translation.IndexOf(text, StringComparison.OrdinalIgnoreCase);
			num = ((num >= 0) ? (num + text.Length) : 0);
			int num2 = translation.IndexOf("[i2p_", num + 1, StringComparison.OrdinalIgnoreCase);
			if (num2 < 0)
			{
				num2 = translation.Length;
			}
			return translation.Substring(num, num2 - num);
		}

		public static LocalisedString GetGenderLocalisedString(LocalisedString localisedStr, Character character)
		{
			string term = localisedStr.Term + ((character.Gender == Character.Sex.Male) ? "_M" : "_F");
			if (DoesTermExist(term))
			{
				return new LocalisedString(term);
			}
			return localisedStr;
		}

		public static LocalisedString CreateNewTerm(string term, string text)
		{
			term = I2Utils.RemoveNonASCII(term, allowCategory: true);
			LocalizationManager.Sources[0].AddTerm(term, eTermType.Text).Languages[0] = text;
			return new LocalisedString(term);
		}

		public static string Replace(string term, string search, string replace)
		{
			StringBuilder builder = StringBuilderPool.GlobalStringBuilderPool.GetBuilder(term.Length);
			builder.Append(term);
			builder.Replace(search, replace);
			string result = builder.ToString();
			StringBuilderPool.GlobalStringBuilderPool.ReturnBuilder(builder);
			return result;
		}

		public static string Replace(string term, SubPair[] pairs)
		{
			StringBuilder builder = StringBuilderPool.GlobalStringBuilderPool.GetBuilder(term.Length);
			builder.Append(term);
			for (int i = 0; i < pairs.Length; i++)
			{
				SubPair subPair = pairs[i];
				builder.Replace(subPair.Search, subPair.Replace);
			}
			string result = builder.ToString();
			StringBuilderPool.GlobalStringBuilderPool.ReturnBuilder(builder);
			return result;
		}

		public static bool DoesTermExist(string term)
		{
			return LocalizationManager.Sources[0].GetTermData(term) != null;
		}
	}
}
