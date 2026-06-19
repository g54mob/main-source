using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace TH20
{
	public static class KeyboardLayout
	{
		public enum LayoutFamily
		{
			QWERTY = 0,
			QWERTZ = 1,
			AZERTY = 2
		}

		private enum WinKeyboardLayout
		{
			Unknown = 0,
			Albanian = 1,
			Arabi_101 = 2,
			Arabic_102 = 3,
			Arabic_102_Azerty = 4,
			Armenian_Eastern = 5,
			Armenian_Western = 6,
			Assamese_Inscript = 7,
			Azeri_Cyrillic = 8,
			Azeri_Latin = 9,
			Bashkir = 10,
			Belarusian = 11,
			Belgian_French = 12,
			Belgian_period = 13,
			Belgian_comma = 14,
			Bengali = 15,
			Bengali_inscript_legacy = 16,
			Bengali_inscript = 17,
			Bosnian_cyrillic = 18,
			Bulgarian = 19,
			Bulgarian_typewriter = 20,
			Bulgarian_latin = 21,
			Bulgarian_phonetic = 22,
			Bulgarian_phonetic_traditional = 23,
			Canada_Multilingual = 24,
			Canada_French = 25,
			Canada_French_legacy = 26,
			Chinese_traditional_us_keyboard = 27,
			Chinese_simplified_us_keyboard = 28,
			Chinese_traditional_hong_kong_sar_us_keyboard = 29,
			Chinese_simplified_singapore_us_keyboard = 30,
			Chinese_traditional_macao_sar_us_keyboard = 31,
			Czech = 32,
			Czech_programmers = 33,
			Czech_qwerty = 34,
			Croatian = 35,
			Devanagari_inscript = 36,
			Danish = 37,
			Divehi_phonetic = 38,
			Divehi_typewriter = 39,
			Dutch = 40,
			Estonian = 41,
			Faeroese = 42,
			Finnish = 43,
			Finnish_with_sami = 44,
			French = 45,
			Gaelic = 46,
			Georgian = 47,
			Georgian_ergonomic = 48,
			Georgian_qwerty = 49,
			German = 50,
			German_ibm = 51,
			Greenlandic = 52,
			Hawaiian = 53,
			Hausa = 54,
			Hebrew = 55,
			Hindi_traditional = 56,
			Greek = 57,
			Greek_220 = 58,
			Greek_220_latin = 59,
			Greek_319 = 60,
			Greek_319_latin = 61,
			Greek_latin = 62,
			Greek_polyonic = 63,
			Gujarati = 64,
			Hungarian = 65,
			Hungarian_101_key = 66,
			Icelandic = 67,
			Igbo = 68,
			Inuktitut_latin = 69,
			Inuktitut_naqittaut = 70,
			Irish = 71,
			Italian = 72,
			Italian_142 = 73,
			Japanese = 74,
			Kannada = 75,
			Kazakh = 76,
			Khmer = 77,
			Korean = 78,
			Kyrgyz_cyrillic = 79,
			Lao = 80,
			Latin_america = 81,
			Latvian = 82,
			Latvian_qwerty = 83,
			Lithuanian = 84,
			Lithuanian_ibm = 85,
			Lithuanian_standard = 86,
			Luxembourgish = 87,
			Macedonian_fyrom = 88,
			Macedonian_fyrom_standard = 89,
			Malayalam = 90,
			Maltese_47_key = 91,
			Maltese_48_key = 92,
			Marathi = 93,
			Maroi = 94,
			Mongolian_cyrillic = 95,
			Mongolian_mongolian_script = 96,
			Nepali = 97,
			Norwegian = 98,
			Norwegian_with_sami = 99,
			Odia = 100,
			Pashto_afghanistan = 101,
			Persian = 102,
			Polish_programmers = 103,
			Polish_214 = 104,
			Portuguese = 105,
			Portuguese_brazillian_abnt = 106,
			Portuguese_brazillian_abnt2 = 107,
			Punjabi = 108,
			Romanian_standard = 109,
			Romanian_legacy = 110,
			Romanian_programmers = 111,
			Russian = 112,
			Russian_typewriter = 113,
			Sami_extended_finland_sweden = 114,
			Sami_extended_norway = 115,
			Serbian_cyrillic = 116,
			Serbian_latin = 117,
			Sesotho_sa_Leboa = 118,
			Setswana = 119,
			Sinhala = 120,
			Sinhala_Wij_9 = 121,
			Slovak = 122,
			Slovak_qwerty = 123,
			Slovenian = 124,
			Sorbian_extended = 125,
			Sorbian_standard = 126,
			Sorbian_standard_legacy = 127,
			Spanish = 128,
			Spanish_variation = 129,
			Swedish = 130,
			Swedish_with_sami = 131,
			Swiss_german = 132,
			Swiss_french = 133,
			Syriac = 134,
			Syriac_phonetic = 135,
			Tajik = 136,
			Tamil = 137,
			Tatar = 138,
			Telugu = 139,
			Thai_Kedmanee = 140,
			Thai_Kedmanee_non_shiftlock = 141,
			Thai_Pattachote = 142,
			Thai_Pattachote_non_shiftlock = 143,
			Tibetan_prc = 144,
			Turkish_F = 145,
			Turkish_Q = 146,
			Turkmen = 147,
			Ukrainian = 148,
			Ukrainian_enhanced = 149,
			United_Kingdom = 150,
			United_Kingdom_Extended = 151,
			United_States = 152,
			United_States_dvorak = 153,
			United_States_dvorak_left_hand = 154,
			United_States_dvorak_right_hand = 155,
			English_India = 156,
			United_States_international = 157,
			Urdu = 158,
			Uyghur = 159,
			Uyghur_legacy = 160,
			Uzbek_cyrillic = 161,
			Vietnamese = 162,
			Sakha = 163,
			Yoruba = 164,
			Wolof = 165
		}

		private const int KL_NAMELENGTH = 9;

		public static LayoutFamily GetCurrentLayoutFamily()
		{
			return GetLayoutFamily(MapLayout(GetLayoutCode()));
		}

		public static KeyCode MapKeyCode(KeyCode keyCode, LayoutFamily layoutFamily)
		{
			return layoutFamily switch
			{
				LayoutFamily.QWERTZ => QWERTY_to_QWERTZ(keyCode), 
				LayoutFamily.AZERTY => QWERTY_to_AZERTY(keyCode), 
				_ => keyCode, 
			};
		}

		private static KeyCode QWERTY_to_QWERTZ(KeyCode keyCode)
		{
			return keyCode switch
			{
				KeyCode.Y => KeyCode.Z, 
				KeyCode.Z => KeyCode.Y, 
				_ => keyCode, 
			};
		}

		private static KeyCode QWERTY_to_AZERTY(KeyCode keyCode)
		{
			return keyCode switch
			{
				KeyCode.Q => KeyCode.A, 
				KeyCode.W => KeyCode.Z, 
				KeyCode.A => KeyCode.Q, 
				KeyCode.Z => KeyCode.W, 
				_ => keyCode, 
			};
		}

		[DllImport("user32.dll")]
		private static extern long GetKeyboardLayoutName(StringBuilder pwszKLID);

		private static string GetLayoutCode()
		{
			StringBuilder stringBuilder = new StringBuilder(9);
			GetKeyboardLayoutName(stringBuilder);
			return stringBuilder.ToString();
		}

		private static WinKeyboardLayout MapLayout(string code)
		{
			if (code.IsNullOrEmpty())
			{
				return WinKeyboardLayout.Unknown;
			}
			return code switch
			{
				"0000041C" => WinKeyboardLayout.Albanian, 
				"00000401" => WinKeyboardLayout.Arabi_101, 
				"00010401" => WinKeyboardLayout.Arabic_102, 
				"00020401" => WinKeyboardLayout.Arabic_102_Azerty, 
				"0000042B" => WinKeyboardLayout.Armenian_Eastern, 
				"0001042B" => WinKeyboardLayout.Armenian_Western, 
				"0000044D" => WinKeyboardLayout.Assamese_Inscript, 
				"0000082C" => WinKeyboardLayout.Azeri_Cyrillic, 
				"0000042C" => WinKeyboardLayout.Azeri_Latin, 
				"0000046D" => WinKeyboardLayout.Bashkir, 
				"00000423" => WinKeyboardLayout.Belarusian, 
				"0000080C" => WinKeyboardLayout.Belgian_French, 
				"00000813" => WinKeyboardLayout.Belgian_period, 
				"0001080C" => WinKeyboardLayout.Belgian_comma, 
				"00000445" => WinKeyboardLayout.Bengali, 
				"00010445" => WinKeyboardLayout.Bengali_inscript_legacy, 
				"00020445" => WinKeyboardLayout.Bengali_inscript, 
				"0000201A" => WinKeyboardLayout.Bosnian_cyrillic, 
				"00030402" => WinKeyboardLayout.Bulgarian, 
				"00000402" => WinKeyboardLayout.Bulgarian_typewriter, 
				"00010402" => WinKeyboardLayout.Bulgarian_latin, 
				"00020402" => WinKeyboardLayout.Bulgarian_phonetic, 
				"00040402" => WinKeyboardLayout.Bulgarian_phonetic_traditional, 
				"00011009" => WinKeyboardLayout.Canada_Multilingual, 
				"00001009" => WinKeyboardLayout.Canada_French, 
				"00000C0C" => WinKeyboardLayout.Canada_French_legacy, 
				"00000404" => WinKeyboardLayout.Chinese_traditional_us_keyboard, 
				"00000804" => WinKeyboardLayout.Chinese_simplified_us_keyboard, 
				"00000C04" => WinKeyboardLayout.Chinese_traditional_hong_kong_sar_us_keyboard, 
				"00001004" => WinKeyboardLayout.Chinese_simplified_singapore_us_keyboard, 
				"00001404" => WinKeyboardLayout.Chinese_traditional_macao_sar_us_keyboard, 
				"00000405" => WinKeyboardLayout.Czech, 
				"00020405" => WinKeyboardLayout.Czech_programmers, 
				"00010405" => WinKeyboardLayout.Czech_qwerty, 
				"0000041A" => WinKeyboardLayout.Croatian, 
				"00000439" => WinKeyboardLayout.Devanagari_inscript, 
				"00000406" => WinKeyboardLayout.Danish, 
				"00000465" => WinKeyboardLayout.Divehi_phonetic, 
				"00010465" => WinKeyboardLayout.Divehi_typewriter, 
				"00000413" => WinKeyboardLayout.Dutch, 
				"00000425" => WinKeyboardLayout.Estonian, 
				"00000438" => WinKeyboardLayout.Faeroese, 
				"0000040B" => WinKeyboardLayout.Finnish, 
				"0001083B" => WinKeyboardLayout.Finnish_with_sami, 
				"0000040C" => WinKeyboardLayout.French, 
				"00011809" => WinKeyboardLayout.Gaelic, 
				"00000437" => WinKeyboardLayout.Georgian, 
				"00020437" => WinKeyboardLayout.Georgian_ergonomic, 
				"00010437" => WinKeyboardLayout.Georgian_qwerty, 
				"00000407" => WinKeyboardLayout.German, 
				"00010407" => WinKeyboardLayout.German_ibm, 
				"0000046F" => WinKeyboardLayout.Greenlandic, 
				"00000475" => WinKeyboardLayout.Hawaiian, 
				"00000468" => WinKeyboardLayout.Hausa, 
				"0000040D" => WinKeyboardLayout.Hebrew, 
				"00010439" => WinKeyboardLayout.Hindi_traditional, 
				"00000408" => WinKeyboardLayout.Greek, 
				"00010408" => WinKeyboardLayout.Greek_220, 
				"00030408" => WinKeyboardLayout.Greek_220_latin, 
				"00020408" => WinKeyboardLayout.Greek_319, 
				"00040408" => WinKeyboardLayout.Greek_319_latin, 
				"00050408" => WinKeyboardLayout.Greek_latin, 
				"00060408" => WinKeyboardLayout.Greek_polyonic, 
				"00000447" => WinKeyboardLayout.Gujarati, 
				"0000040E" => WinKeyboardLayout.Hungarian, 
				"0001040E" => WinKeyboardLayout.Hungarian_101_key, 
				"0000040F" => WinKeyboardLayout.Icelandic, 
				"00000470" => WinKeyboardLayout.Igbo, 
				"0000085D" => WinKeyboardLayout.Inuktitut_latin, 
				"0001045D" => WinKeyboardLayout.Inuktitut_naqittaut, 
				"00001809" => WinKeyboardLayout.Irish, 
				"00000410" => WinKeyboardLayout.Italian, 
				"00010410" => WinKeyboardLayout.Italian_142, 
				"00000411" => WinKeyboardLayout.Japanese, 
				"0000044B" => WinKeyboardLayout.Kannada, 
				"0000043F" => WinKeyboardLayout.Kazakh, 
				"00000453" => WinKeyboardLayout.Khmer, 
				"00000412" => WinKeyboardLayout.Korean, 
				"00000440" => WinKeyboardLayout.Kyrgyz_cyrillic, 
				"00000454" => WinKeyboardLayout.Lao, 
				"0000080A" => WinKeyboardLayout.Latin_america, 
				"00000426" => WinKeyboardLayout.Latvian, 
				"00010426" => WinKeyboardLayout.Latvian_qwerty, 
				"00010427" => WinKeyboardLayout.Lithuanian, 
				"00000427" => WinKeyboardLayout.Lithuanian_ibm, 
				"00020427" => WinKeyboardLayout.Lithuanian_standard, 
				"0000046E" => WinKeyboardLayout.Luxembourgish, 
				"0000042F" => WinKeyboardLayout.Macedonian_fyrom, 
				"0001042F" => WinKeyboardLayout.Macedonian_fyrom_standard, 
				"0000044C" => WinKeyboardLayout.Malayalam, 
				"0000043A" => WinKeyboardLayout.Maltese_47_key, 
				"0001043A" => WinKeyboardLayout.Maltese_48_key, 
				"0000044E" => WinKeyboardLayout.Marathi, 
				"00000481" => WinKeyboardLayout.Maroi, 
				"00000450" => WinKeyboardLayout.Mongolian_cyrillic, 
				"00000850" => WinKeyboardLayout.Mongolian_mongolian_script, 
				"00000461" => WinKeyboardLayout.Nepali, 
				"00000414" => WinKeyboardLayout.Norwegian, 
				"0000043B" => WinKeyboardLayout.Norwegian_with_sami, 
				"00000448" => WinKeyboardLayout.Odia, 
				"00000463" => WinKeyboardLayout.Pashto_afghanistan, 
				"00000429" => WinKeyboardLayout.Persian, 
				"00000415" => WinKeyboardLayout.Polish_programmers, 
				"00010415" => WinKeyboardLayout.Polish_214, 
				"00000816" => WinKeyboardLayout.Portuguese, 
				"00000416" => WinKeyboardLayout.Portuguese_brazillian_abnt, 
				"00010416" => WinKeyboardLayout.Portuguese_brazillian_abnt2, 
				"00000446" => WinKeyboardLayout.Punjabi, 
				"00010418" => WinKeyboardLayout.Romanian_standard, 
				"00000418" => WinKeyboardLayout.Romanian_legacy, 
				"00020418" => WinKeyboardLayout.Romanian_programmers, 
				"00000419" => WinKeyboardLayout.Russian, 
				"00010419" => WinKeyboardLayout.Russian_typewriter, 
				"0002083B" => WinKeyboardLayout.Sami_extended_finland_sweden, 
				"0001043B" => WinKeyboardLayout.Sami_extended_norway, 
				"00000C1A" => WinKeyboardLayout.Serbian_cyrillic, 
				"0000081A" => WinKeyboardLayout.Serbian_latin, 
				"0000046C" => WinKeyboardLayout.Sesotho_sa_Leboa, 
				"00000432" => WinKeyboardLayout.Setswana, 
				"0000045B" => WinKeyboardLayout.Sinhala, 
				"0001045B" => WinKeyboardLayout.Sinhala_Wij_9, 
				"0000041B" => WinKeyboardLayout.Slovak, 
				"0001041B" => WinKeyboardLayout.Slovak_qwerty, 
				"00000424" => WinKeyboardLayout.Slovenian, 
				"0001042E" => WinKeyboardLayout.Sorbian_extended, 
				"0002042E" => WinKeyboardLayout.Sorbian_standard, 
				"0000042E" => WinKeyboardLayout.Sorbian_standard_legacy, 
				"0000040A" => WinKeyboardLayout.Spanish, 
				"0001040A" => WinKeyboardLayout.Spanish_variation, 
				"0000041D" => WinKeyboardLayout.Swedish, 
				"0000083B" => WinKeyboardLayout.Swedish_with_sami, 
				"00000807" => WinKeyboardLayout.Swiss_german, 
				"0000100C" => WinKeyboardLayout.Swiss_french, 
				"0000045A" => WinKeyboardLayout.Syriac, 
				"0001045A" => WinKeyboardLayout.Syriac_phonetic, 
				"00000428" => WinKeyboardLayout.Tajik, 
				"00000449" => WinKeyboardLayout.Tamil, 
				"00000444" => WinKeyboardLayout.Tatar, 
				"0000044A" => WinKeyboardLayout.Telugu, 
				"0000041E" => WinKeyboardLayout.Thai_Kedmanee, 
				"0002041E" => WinKeyboardLayout.Thai_Kedmanee_non_shiftlock, 
				"0001041E" => WinKeyboardLayout.Thai_Pattachote, 
				"0003041E" => WinKeyboardLayout.Thai_Pattachote_non_shiftlock, 
				"00000451" => WinKeyboardLayout.Tibetan_prc, 
				"0001041F" => WinKeyboardLayout.Turkish_F, 
				"0000041F" => WinKeyboardLayout.Turkish_Q, 
				"00000442" => WinKeyboardLayout.Turkmen, 
				"00000422" => WinKeyboardLayout.Ukrainian, 
				"00020422" => WinKeyboardLayout.Ukrainian_enhanced, 
				"00000809" => WinKeyboardLayout.United_Kingdom, 
				"00000452" => WinKeyboardLayout.United_Kingdom_Extended, 
				"00000409" => WinKeyboardLayout.United_States, 
				"00010409" => WinKeyboardLayout.United_States_dvorak, 
				"00030409" => WinKeyboardLayout.United_States_dvorak_left_hand, 
				"00050409" => WinKeyboardLayout.United_States_dvorak_right_hand, 
				"00004009" => WinKeyboardLayout.English_India, 
				"00020409" => WinKeyboardLayout.United_States_international, 
				"00000420" => WinKeyboardLayout.Urdu, 
				"00010480" => WinKeyboardLayout.Uyghur, 
				"00000480" => WinKeyboardLayout.Uyghur_legacy, 
				"00000843" => WinKeyboardLayout.Uzbek_cyrillic, 
				"0000042A" => WinKeyboardLayout.Vietnamese, 
				"00000485" => WinKeyboardLayout.Sakha, 
				"0000046A" => WinKeyboardLayout.Yoruba, 
				"00000488" => WinKeyboardLayout.Wolof, 
				_ => WinKeyboardLayout.Unknown, 
			};
		}

		private static LayoutFamily GetLayoutFamily(WinKeyboardLayout code)
		{
			switch (code)
			{
			case WinKeyboardLayout.Albanian:
				return LayoutFamily.QWERTZ;
			case WinKeyboardLayout.Arabi_101:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Arabic_102:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Arabic_102_Azerty:
				return LayoutFamily.AZERTY;
			case WinKeyboardLayout.Armenian_Eastern:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Armenian_Western:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Assamese_Inscript:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Azeri_Cyrillic:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Azeri_Latin:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Bashkir:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Belarusian:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Belgian_French:
				return LayoutFamily.AZERTY;
			case WinKeyboardLayout.Belgian_period:
				return LayoutFamily.AZERTY;
			case WinKeyboardLayout.Belgian_comma:
				return LayoutFamily.AZERTY;
			case WinKeyboardLayout.Bengali:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Bengali_inscript_legacy:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Bengali_inscript:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Bosnian_cyrillic:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Bulgarian_typewriter:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Bulgarian_latin:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Bulgarian_phonetic:
				return LayoutFamily.QWERTZ;
			case WinKeyboardLayout.Bulgarian_phonetic_traditional:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Canada_Multilingual:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Canada_French:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Canada_French_legacy:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Chinese_traditional_us_keyboard:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Chinese_simplified_us_keyboard:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Chinese_traditional_hong_kong_sar_us_keyboard:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Chinese_simplified_singapore_us_keyboard:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Chinese_traditional_macao_sar_us_keyboard:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Czech:
				return LayoutFamily.QWERTZ;
			case WinKeyboardLayout.Czech_programmers:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Czech_qwerty:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Croatian:
				return LayoutFamily.QWERTZ;
			case WinKeyboardLayout.Devanagari_inscript:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Danish:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Divehi_phonetic:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Divehi_typewriter:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Dutch:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Estonian:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Faeroese:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Finnish:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Finnish_with_sami:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.French:
				return LayoutFamily.AZERTY;
			case WinKeyboardLayout.Gaelic:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Georgian:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Georgian_ergonomic:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Georgian_qwerty:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.German:
				return LayoutFamily.QWERTZ;
			case WinKeyboardLayout.German_ibm:
				return LayoutFamily.QWERTZ;
			case WinKeyboardLayout.Greenlandic:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Hausa:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Hawaiian:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Hebrew:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Hindi_traditional:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Greek:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Greek_220:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Greek_220_latin:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Greek_319:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Greek_319_latin:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Greek_latin:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Greek_polyonic:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Gujarati:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Hungarian:
				return LayoutFamily.QWERTZ;
			case WinKeyboardLayout.Hungarian_101_key:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Icelandic:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Igbo:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Inuktitut_latin:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Inuktitut_naqittaut:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Irish:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Italian:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Italian_142:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Japanese:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Kannada:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Kazakh:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Khmer:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Korean:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Kyrgyz_cyrillic:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Lao:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Latin_america:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Latvian:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Latvian_qwerty:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Lithuanian:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Lithuanian_ibm:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Lithuanian_standard:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Luxembourgish:
				return LayoutFamily.QWERTZ;
			case WinKeyboardLayout.Macedonian_fyrom:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Macedonian_fyrom_standard:
				return LayoutFamily.QWERTZ;
			case WinKeyboardLayout.Malayalam:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Maltese_47_key:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Maltese_48_key:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Marathi:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Maroi:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Mongolian_cyrillic:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Mongolian_mongolian_script:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Nepali:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Norwegian:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Norwegian_with_sami:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Odia:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Pashto_afghanistan:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Persian:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Polish_programmers:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Polish_214:
				return LayoutFamily.QWERTZ;
			case WinKeyboardLayout.Portuguese:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Portuguese_brazillian_abnt:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Portuguese_brazillian_abnt2:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Punjabi:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Romanian_standard:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Romanian_legacy:
				return LayoutFamily.QWERTZ;
			case WinKeyboardLayout.Romanian_programmers:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Russian:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Russian_typewriter:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Sami_extended_finland_sweden:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Sami_extended_norway:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Serbian_cyrillic:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Serbian_latin:
				return LayoutFamily.QWERTZ;
			case WinKeyboardLayout.Sesotho_sa_Leboa:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Setswana:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Sinhala:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Sinhala_Wij_9:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Slovak:
				return LayoutFamily.QWERTZ;
			case WinKeyboardLayout.Slovak_qwerty:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Slovenian:
				return LayoutFamily.QWERTZ;
			case WinKeyboardLayout.Sorbian_extended:
				return LayoutFamily.QWERTZ;
			case WinKeyboardLayout.Sorbian_standard:
				return LayoutFamily.QWERTZ;
			case WinKeyboardLayout.Sorbian_standard_legacy:
				return LayoutFamily.QWERTZ;
			case WinKeyboardLayout.Spanish:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Spanish_variation:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Swedish:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Swedish_with_sami:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Swiss_german:
				return LayoutFamily.QWERTZ;
			case WinKeyboardLayout.Swiss_french:
				return LayoutFamily.QWERTZ;
			case WinKeyboardLayout.Syriac:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Syriac_phonetic:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Tajik:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Tamil:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Tatar:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Telugu:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Thai_Kedmanee:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Thai_Kedmanee_non_shiftlock:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Thai_Pattachote:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Thai_Pattachote_non_shiftlock:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Tibetan_prc:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Turkish_F:
			case WinKeyboardLayout.Turkish_Q:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Turkmen:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Ukrainian:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Ukrainian_enhanced:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.United_Kingdom:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.United_Kingdom_Extended:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.United_States:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.English_India:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.United_States_international:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Urdu:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Uyghur:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Uyghur_legacy:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Uzbek_cyrillic:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Vietnamese:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Sakha:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Yoruba:
				return LayoutFamily.QWERTY;
			case WinKeyboardLayout.Wolof:
				return LayoutFamily.AZERTY;
			default:
				return LayoutFamily.QWERTY;
			}
		}

		private static string GetWinLayoutName(WinKeyboardLayout code)
		{
			return code switch
			{
				WinKeyboardLayout.Albanian => "Albanian", 
				WinKeyboardLayout.Arabi_101 => "Arabic (101)", 
				WinKeyboardLayout.Arabic_102 => "Arabic (102)", 
				WinKeyboardLayout.Arabic_102_Azerty => "Arabic (102) Azerty", 
				WinKeyboardLayout.Armenian_Eastern => "Armenian eastern", 
				WinKeyboardLayout.Armenian_Western => "Armenian Western", 
				WinKeyboardLayout.Assamese_Inscript => "Assamese - inscript", 
				WinKeyboardLayout.Azeri_Cyrillic => "Azeri Cyrillic", 
				WinKeyboardLayout.Azeri_Latin => "Azeri Latin", 
				WinKeyboardLayout.Bashkir => "Bashkir", 
				WinKeyboardLayout.Belarusian => "Belarusian", 
				WinKeyboardLayout.Belgian_French => "Belgian French", 
				WinKeyboardLayout.Belgian_period => "Belgian (period)", 
				WinKeyboardLayout.Belgian_comma => "Belgian (comma)", 
				WinKeyboardLayout.Bengali => "Bengali", 
				WinKeyboardLayout.Bengali_inscript_legacy => "Bengali - inscript (legacy)", 
				WinKeyboardLayout.Bengali_inscript => "Bengali - inscript", 
				WinKeyboardLayout.Bosnian_cyrillic => "Bosnian (cyrillic)", 
				WinKeyboardLayout.Bulgarian => "Bulgarian", 
				WinKeyboardLayout.Bulgarian_typewriter => "Bulgarian(typewriter)", 
				WinKeyboardLayout.Bulgarian_latin => "Bulgarian (latin)", 
				WinKeyboardLayout.Bulgarian_phonetic => "Bulgarian (phonetic)", 
				WinKeyboardLayout.Bulgarian_phonetic_traditional => "Bulgarian (phonetic traditional)", 
				WinKeyboardLayout.Canada_Multilingual => "Canada Multilingual", 
				WinKeyboardLayout.Canada_French => "Canada French", 
				WinKeyboardLayout.Canada_French_legacy => "Canada French (legacy)", 
				WinKeyboardLayout.Chinese_traditional_us_keyboard => "Chinese (traditional) - us keyboard", 
				WinKeyboardLayout.Chinese_simplified_us_keyboard => "Chinese (simplified) -us keyboard", 
				WinKeyboardLayout.Chinese_traditional_hong_kong_sar_us_keyboard => "Chinese (traditional, hong kong s.a.r.) - us keyboard", 
				WinKeyboardLayout.Chinese_simplified_singapore_us_keyboard => "Chinese (simplified, singapore) - us keyboard", 
				WinKeyboardLayout.Chinese_traditional_macao_sar_us_keyboard => "Chinese (traditional, macao s.a.r.) - us keyboard", 
				WinKeyboardLayout.Czech => "Czech", 
				WinKeyboardLayout.Czech_programmers => "Czech programmers", 
				WinKeyboardLayout.Czech_qwerty => "Czech (qwerty)", 
				WinKeyboardLayout.Croatian => "Croatian", 
				WinKeyboardLayout.Devanagari_inscript => "Devanagari - inscript", 
				WinKeyboardLayout.Danish => "Danish", 
				WinKeyboardLayout.Divehi_phonetic => "Divehi phonetic", 
				WinKeyboardLayout.Divehi_typewriter => "Divehi typewriter", 
				WinKeyboardLayout.Dutch => "Dutch", 
				WinKeyboardLayout.Estonian => "Estonian", 
				WinKeyboardLayout.Faeroese => "Faeroese", 
				WinKeyboardLayout.Finnish => "Finnish", 
				WinKeyboardLayout.Finnish_with_sami => "Finnish with sami", 
				WinKeyboardLayout.French => "French", 
				WinKeyboardLayout.Gaelic => "Gaelic", 
				WinKeyboardLayout.Georgian => "Georgian", 
				WinKeyboardLayout.Georgian_ergonomic => "Georgian (ergonomic)", 
				WinKeyboardLayout.Georgian_qwerty => "Georgian (qwerty)", 
				WinKeyboardLayout.German => "German", 
				WinKeyboardLayout.German_ibm => "German (ibm)", 
				WinKeyboardLayout.Greenlandic => "Greenlandic", 
				WinKeyboardLayout.Hausa => "Hausa", 
				WinKeyboardLayout.Hawaiian => "Hawaiian", 
				WinKeyboardLayout.Hebrew => "Hebrew", 
				WinKeyboardLayout.Hindi_traditional => "Hindi traditional", 
				WinKeyboardLayout.Greek => "Greek", 
				WinKeyboardLayout.Greek_220 => "Greek (220)", 
				WinKeyboardLayout.Greek_220_latin => "Greek (220) latin", 
				WinKeyboardLayout.Greek_319 => "Greek (319)", 
				WinKeyboardLayout.Greek_319_latin => "Greek (319) latin", 
				WinKeyboardLayout.Greek_latin => "Greek latin", 
				WinKeyboardLayout.Greek_polyonic => "Greek polyonic", 
				WinKeyboardLayout.Gujarati => "Gujarati", 
				WinKeyboardLayout.Hungarian => "Hungarian", 
				WinKeyboardLayout.Hungarian_101_key => "Hungarian 101 key", 
				WinKeyboardLayout.Icelandic => "Icelandic", 
				WinKeyboardLayout.Igbo => "Igbo", 
				WinKeyboardLayout.Inuktitut_latin => "Inuktitut - latin", 
				WinKeyboardLayout.Inuktitut_naqittaut => "Inuktitut - naqittaut", 
				WinKeyboardLayout.Irish => "Irish", 
				WinKeyboardLayout.Italian => "Italian", 
				WinKeyboardLayout.Italian_142 => "Italian (142)", 
				WinKeyboardLayout.Japanese => "Japanese", 
				WinKeyboardLayout.Kannada => "Kannada", 
				WinKeyboardLayout.Kazakh => "Kazakh", 
				WinKeyboardLayout.Khmer => "Khmer", 
				WinKeyboardLayout.Korean => "Korean", 
				WinKeyboardLayout.Kyrgyz_cyrillic => "Kyrgyz cyrillic", 
				WinKeyboardLayout.Lao => "Lao", 
				WinKeyboardLayout.Latin_america => "Latin america", 
				WinKeyboardLayout.Latvian => "Latvian", 
				WinKeyboardLayout.Latvian_qwerty => "Latvian (qwerty)", 
				WinKeyboardLayout.Lithuanian => "Lithuanian", 
				WinKeyboardLayout.Lithuanian_ibm => "Lithuanian ibm", 
				WinKeyboardLayout.Lithuanian_standard => "Lithuanian standard", 
				WinKeyboardLayout.Luxembourgish => "Luxembourgish", 
				WinKeyboardLayout.Macedonian_fyrom => "Macedonian (fyrom)", 
				WinKeyboardLayout.Macedonian_fyrom_standard => "Macedonian (fyrom) - standard", 
				WinKeyboardLayout.Malayalam => "Malayalam", 
				WinKeyboardLayout.Maltese_47_key => "Maltese 47-key", 
				WinKeyboardLayout.Maltese_48_key => "Maltese 48-key", 
				WinKeyboardLayout.Marathi => "Marathi", 
				WinKeyboardLayout.Maroi => "Maroi", 
				WinKeyboardLayout.Mongolian_cyrillic => "Mongolian cyrillic", 
				WinKeyboardLayout.Mongolian_mongolian_script => "Mongolian (mongolian script)", 
				WinKeyboardLayout.Nepali => "Nepali", 
				WinKeyboardLayout.Norwegian => "Norwegian", 
				WinKeyboardLayout.Norwegian_with_sami => "Norwegian with sami", 
				WinKeyboardLayout.Odia => "Odia", 
				WinKeyboardLayout.Pashto_afghanistan => "Pashto (afghanistan)", 
				WinKeyboardLayout.Persian => "Persian", 
				WinKeyboardLayout.Polish_programmers => "Polish (programmers)", 
				WinKeyboardLayout.Polish_214 => "Polish (214)", 
				WinKeyboardLayout.Portuguese => "Portuguese", 
				WinKeyboardLayout.Portuguese_brazillian_abnt => "Portuguese (brazillian abnt)", 
				WinKeyboardLayout.Portuguese_brazillian_abnt2 => "Portuguese (brazillian abnt2)", 
				WinKeyboardLayout.Punjabi => "Punjabi", 
				WinKeyboardLayout.Romanian_standard => "Romanian (standard)", 
				WinKeyboardLayout.Romanian_legacy => "Romanian (legacy)", 
				WinKeyboardLayout.Romanian_programmers => "Romanian (programmers)", 
				WinKeyboardLayout.Russian => "Russian", 
				WinKeyboardLayout.Russian_typewriter => "Russian (typewriter)", 
				WinKeyboardLayout.Sami_extended_finland_sweden => "Sami extended finland-sweden", 
				WinKeyboardLayout.Sami_extended_norway => "Sami extended norway", 
				WinKeyboardLayout.Serbian_cyrillic => "Serbian (cyrillic)", 
				WinKeyboardLayout.Serbian_latin => "Serbian (latin)", 
				WinKeyboardLayout.Sesotho_sa_Leboa => "Sesotho sa Leboa", 
				WinKeyboardLayout.Setswana => "Setswana", 
				WinKeyboardLayout.Sinhala => "Sinhala", 
				WinKeyboardLayout.Sinhala_Wij_9 => "Sinhala -Wij 9", 
				WinKeyboardLayout.Slovak => "Slovak", 
				WinKeyboardLayout.Slovak_qwerty => "Slovak (qwerty)", 
				WinKeyboardLayout.Slovenian => "Slovenian", 
				WinKeyboardLayout.Sorbian_extended => "Sorbian extended", 
				WinKeyboardLayout.Sorbian_standard => "Sorbian standard", 
				WinKeyboardLayout.Sorbian_standard_legacy => "Sorbian standard (legacy)", 
				WinKeyboardLayout.Spanish => "Spanish", 
				WinKeyboardLayout.Spanish_variation => "Spanish variation", 
				WinKeyboardLayout.Swedish => "Swedish", 
				WinKeyboardLayout.Swedish_with_sami => "Swedish with sami", 
				WinKeyboardLayout.Swiss_german => "Swiss german", 
				WinKeyboardLayout.Swiss_french => "Swiss french", 
				WinKeyboardLayout.Syriac => "Syriac", 
				WinKeyboardLayout.Syriac_phonetic => "Syriac phonetic", 
				WinKeyboardLayout.Tajik => "Tajik", 
				WinKeyboardLayout.Tamil => "Tamil", 
				WinKeyboardLayout.Tatar => "Tatar", 
				WinKeyboardLayout.Telugu => "Telugu", 
				WinKeyboardLayout.Thai_Kedmanee => "Thai Kedmanee", 
				WinKeyboardLayout.Thai_Kedmanee_non_shiftlock => "Thai Kedmanee (non-shiftlock)", 
				WinKeyboardLayout.Thai_Pattachote => "Thai Pattachote", 
				WinKeyboardLayout.Thai_Pattachote_non_shiftlock => "Thai Pattachote (non-shiftlock)", 
				WinKeyboardLayout.Tibetan_prc => "Tibetan (prc)", 
				WinKeyboardLayout.Turkish_F => "Turkish F", 
				WinKeyboardLayout.Turkish_Q => "Turkish Q", 
				WinKeyboardLayout.Turkmen => "Turkmen", 
				WinKeyboardLayout.Ukrainian => "Ukrainian", 
				WinKeyboardLayout.Ukrainian_enhanced => "Ukrainian (enhanced)", 
				WinKeyboardLayout.United_Kingdom => "United Kingdom", 
				WinKeyboardLayout.United_Kingdom_Extended => "United Kingdom Extended", 
				WinKeyboardLayout.United_States => "United States", 
				WinKeyboardLayout.United_States_dvorak => "United States - dvorak", 
				WinKeyboardLayout.United_States_dvorak_left_hand => "United States - dvorak left hand", 
				WinKeyboardLayout.United_States_dvorak_right_hand => "United States - dvorak right hand", 
				WinKeyboardLayout.English_India => "English (India)", 
				WinKeyboardLayout.United_States_international => "United States - international", 
				WinKeyboardLayout.Urdu => "Urdu", 
				WinKeyboardLayout.Uyghur => "Uyghur", 
				WinKeyboardLayout.Uyghur_legacy => "Uyghur (legacy)", 
				WinKeyboardLayout.Uzbek_cyrillic => "Uzbek cyrillic", 
				WinKeyboardLayout.Vietnamese => "Vietnamese", 
				WinKeyboardLayout.Sakha => "Sakha", 
				WinKeyboardLayout.Yoruba => "Yoruba", 
				WinKeyboardLayout.Wolof => "Wolof", 
				_ => "unknown", 
			};
		}
	}
}
