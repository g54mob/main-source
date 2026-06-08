using System;
using CsvHelper.Configuration.Attributes;

namespace KitchenData
{
	public class LocalisationRow
	{
		[Name("SourceID")]
		public int SourceID { get; set; }

		[Name("SourceName")]
		public string SourceName { get; set; }

		[Name("Key")]
		public string Key { get; set; }

		[Name("English")]
		public string English { get; set; }

		[Name("IsChanged")]
		[BooleanFalseValues("")]
		public bool IsChanged { get; set; }

		[Name("French")]
		public string French { get; set; }

		[Name("German")]
		public string German { get; set; }

		[Name("Spanish")]
		public string Spanish { get; set; }

		[Name("Polish")]
		public string Polish { get; set; }

		[Name("Russian")]
		public string Russian { get; set; }

		[Name("PortugueseBrazil")]
		public string PortugueseBrazil { get; set; }

		[Name("Japanese")]
		public string Japanese { get; set; }

		[Name("ChineseSimplified")]
		public string ChineseSimplified { get; set; }

		[Name("ChineseTraditional")]
		public string ChineseTraditional { get; set; }

		[Name("Korean")]
		public string Korean { get; set; }

		[Name("Turkish")]
		public string Turkish { get; set; }

		public (int, string) HashKey()
		{
			return (SourceID, Key);
		}

		public bool TranslationsEqual(LocalisationRow other)
		{
			if (NullEqual(English, other.English) && NullEqual(French, other.French) && NullEqual(German, other.German) && NullEqual(Spanish, other.Spanish) && NullEqual(Polish, other.Polish) && NullEqual(Russian, other.Russian) && NullEqual(PortugueseBrazil, other.PortugueseBrazil) && NullEqual(Japanese, other.Japanese) && NullEqual(ChineseSimplified, other.ChineseSimplified) && NullEqual(ChineseTraditional, other.ChineseTraditional) && NullEqual(Korean, other.Korean))
			{
				return NullEqual(Turkish, other.Turkish);
			}
			return false;
		}

		private static bool NullEqual(string a, string b)
		{
			if (a == null)
			{
				a = "";
			}
			if (b == null)
			{
				b = "";
			}
			return a.Replace("\r\n", "\n").Trim() == b.Replace("\r\n", "\n").Trim();
		}

		public string Get(Locale l)
		{
			return l switch
			{
				Locale.Default => English, 
				Locale.English => English, 
				Locale.BlankText => English, 
				Locale.French => French, 
				Locale.German => German, 
				Locale.Spanish => Spanish, 
				Locale.Polish => Polish, 
				Locale.Russian => Russian, 
				Locale.PortugueseBrazil => PortugueseBrazil, 
				Locale.Japanese => Japanese, 
				Locale.ChineseSimplified => ChineseSimplified, 
				Locale.ChineseTraditional => ChineseTraditional, 
				Locale.Korean => Korean, 
				Locale.Turkish => Turkish, 
				_ => throw new ArgumentOutOfRangeException("l", l, null), 
			};
		}

		public void Set(Locale l, string text)
		{
			switch (l)
			{
			case Locale.Default:
				English = text;
				break;
			case Locale.English:
				English = text;
				break;
			case Locale.BlankText:
				English = text;
				break;
			case Locale.French:
				French = text;
				break;
			case Locale.German:
				German = text;
				break;
			case Locale.Spanish:
				Spanish = text;
				break;
			case Locale.Polish:
				Polish = text;
				break;
			case Locale.Russian:
				Russian = text;
				break;
			case Locale.PortugueseBrazil:
				PortugueseBrazil = text;
				break;
			case Locale.Japanese:
				Japanese = text;
				break;
			case Locale.ChineseSimplified:
				ChineseSimplified = text;
				break;
			case Locale.ChineseTraditional:
				ChineseTraditional = text;
				break;
			case Locale.Korean:
				Korean = text;
				break;
			case Locale.Turkish:
				Turkish = text;
				break;
			default:
				throw new ArgumentOutOfRangeException("l", l, null);
			}
		}

		public static LocalisationRow CreateEmpty(int id, string name, string key)
		{
			return new LocalisationRow
			{
				SourceID = id,
				SourceName = name,
				Key = key
			};
		}
	}
}
