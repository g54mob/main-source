using System.Collections.Generic;
using MiscUtil.Collections;

namespace MiscUtil.Text
{
	public static class UnicodeRange
	{
		private static readonly List<Range<char>> allRanges = new List<Range<char>>();

		private static readonly Range<char> basicLatin = CreateRange('\0', '\u007f');

		private static readonly Range<char> latin1Supplement = CreateRange('\u0080', 'ÿ');

		private static readonly Range<char> latinExtendedA = CreateRange('Ā', 'ſ');

		private static readonly Range<char> latinExtendedB = CreateRange('ƀ', 'ɏ');

		private static readonly Range<char> ipaExtensions = CreateRange('ɐ', 'ʯ');

		private static readonly Range<char> spacingModifierLetters = CreateRange('ʰ', '\u02ff');

		private static readonly Range<char> combiningDiacriticalMarks = CreateRange('\u0300', '\u036f');

		private static readonly Range<char> greekAndCoptic = CreateRange('Ͱ', 'Ͽ');

		private static readonly Range<char> cyrillic = CreateRange('Ѐ', 'ӿ');

		private static readonly Range<char> cyrillicSupplement = CreateRange('Ԁ', 'ԯ');

		private static readonly Range<char> armenian = CreateRange('\u0530', '֏');

		private static readonly Range<char> hebrew = CreateRange('\u0590', '\u05ff');

		private static readonly Range<char> arabic = CreateRange('\u0600', 'ۿ');

		private static readonly Range<char> syriac = CreateRange('܀', 'ݏ');

		private static readonly Range<char> thaana = CreateRange('ހ', '\u07bf');

		private static readonly Range<char> devangari = CreateRange('\u0900', 'ॿ');

		private static readonly Range<char> bengali = CreateRange('ঀ', '\u09ff');

		private static readonly Range<char> gurmukhi = CreateRange('\u0a00', '\u0a7f');

		private static readonly Range<char> gujarati = CreateRange('\u0a80', '\u0aff');

		private static readonly Range<char> oriya = CreateRange('\u0b00', '\u0b7f');

		private static readonly Range<char> tamil = CreateRange('\u0b80', '\u0bff');

		private static readonly Range<char> telugu = CreateRange('\u0c00', '౿');

		private static readonly Range<char> kannada = CreateRange('ಀ', '\u0cff');

		private static readonly Range<char> malayalam = CreateRange('\u0d00', 'ൿ');

		private static readonly Range<char> sinhala = CreateRange('\u0d80', '\u0dff');

		private static readonly Range<char> thai = CreateRange('\u0e00', '\u0e7f');

		private static readonly Range<char> lao = CreateRange('\u0e80', '\u0eff');

		private static readonly Range<char> tibetan = CreateRange('ༀ', '\u0fff');

		private static readonly Range<char> myanmar = CreateRange('က', '႟');

		private static readonly Range<char> georgian = CreateRange('Ⴀ', 'ჿ');

		private static readonly Range<char> hangulJamo = CreateRange('ᄀ', 'ᇿ');

		private static readonly Range<char> ethiopic = CreateRange('ሀ', '\u137f');

		private static readonly Range<char> cherokee = CreateRange('Ꭰ', '\u13ff');

		private static readonly Range<char> unifiedCanadianAboriginalSyllabics = CreateRange('᐀', 'ᙿ');

		private static readonly Range<char> ogham = CreateRange('\u1680', '\u169f');

		private static readonly Range<char> runic = CreateRange('ᚠ', '\u16ff');

		private static readonly Range<char> tagalog = CreateRange('ᜀ', 'ᜟ');

		private static readonly Range<char> hanunoo = CreateRange('ᜠ', '\u173f');

		private static readonly Range<char> buhid = CreateRange('ᝀ', '\u175f');

		private static readonly Range<char> tagbanwa = CreateRange('ᝠ', '\u177f');

		private static readonly Range<char> khmer = CreateRange('ក', '\u17ff');

		private static readonly Range<char> mongolian = CreateRange('᠀', '\u18af');

		private static readonly Range<char> limbu = CreateRange('ᤀ', '᥏');

		private static readonly Range<char> taiLe = CreateRange('ᥐ', '\u197f');

		private static readonly Range<char> khmerSymbols = CreateRange('᧠', '᧿');

		private static readonly Range<char> phoneticExtensions = CreateRange('ᴀ', 'ᵿ');

		private static readonly Range<char> latinExtendedAdditional = CreateRange('Ḁ', 'ỿ');

		private static readonly Range<char> greekExtended = CreateRange('ἀ', '\u1fff');

		private static readonly Range<char> generalPunctuation = CreateRange('\u2000', '\u206f');

		private static readonly Range<char> superscriptsandSubscripts = CreateRange('⁰', '\u209f');

		private static readonly Range<char> currencySymbols = CreateRange('₠', '\u20cf');

		private static readonly Range<char> combiningDiacriticalMarksforSymbols = CreateRange('\u20d0', '\u20ff');

		private static readonly Range<char> letterlikeSymbols = CreateRange('℀', '⅏');

		private static readonly Range<char> numberForms = CreateRange('⅐', '\u218f');

		private static readonly Range<char> arrows = CreateRange('←', '⇿');

		private static readonly Range<char> mathematicalOperators = CreateRange('∀', '⋿');

		private static readonly Range<char> miscellaneousTechnical = CreateRange('⌀', '⏿');

		private static readonly Range<char> controlPictures = CreateRange('␀', '\u243f');

		private static readonly Range<char> opticalCharacterRecognition = CreateRange('⑀', '\u245f');

		private static readonly Range<char> enclosedAlphanumerics = CreateRange('①', '⓿');

		private static readonly Range<char> boxDrawing = CreateRange('─', '╿');

		private static readonly Range<char> blockElements = CreateRange('▀', '▟');

		private static readonly Range<char> geometricShapes = CreateRange('■', '◿');

		private static readonly Range<char> miscellaneousSymbols = CreateRange('☀', '⛿');

		private static readonly Range<char> dingbats = CreateRange('✀', '➿');

		private static readonly Range<char> miscellaneousMathematicalSymbolsA = CreateRange('⟀', '⟯');

		private static readonly Range<char> supplementalArrowsA = CreateRange('⟰', '⟿');

		private static readonly Range<char> braillePatterns = CreateRange('⠀', '⣿');

		private static readonly Range<char> supplementalArrowsB = CreateRange('⤀', '⥿');

		private static readonly Range<char> miscellaneousMathematicalSymbolsB = CreateRange('⦀', '⧿');

		private static readonly Range<char> supplementalMathematicalOperators = CreateRange('⨀', '⫿');

		private static readonly Range<char> miscellaneousSymbolsandArrows = CreateRange('⬀', '⯿');

		private static readonly Range<char> cjkRadicalsSupplement = CreateRange('⺀', '\u2eff');

		private static readonly Range<char> kangxiRadicals = CreateRange('⼀', '\u2fdf');

		private static readonly Range<char> ideographicDescriptionCharacters = CreateRange('⿰', '⿿');

		private static readonly Range<char> cjkSymbolsandPunctuation = CreateRange('\u3000', '〿');

		private static readonly Range<char> hiragana = CreateRange('\u3040', 'ゟ');

		private static readonly Range<char> katakana = CreateRange('゠', 'ヿ');

		private static readonly Range<char> bopomofo = CreateRange('\u3100', 'ㄯ');

		private static readonly Range<char> hangulCompatibilityJamo = CreateRange('\u3130', '\u318f');

		private static readonly Range<char> kanbun = CreateRange('㆐', '㆟');

		private static readonly Range<char> bopomofoExtended = CreateRange('ㆠ', 'ㆿ');

		private static readonly Range<char> katakanaPhoneticExtensions = CreateRange('ㇰ', 'ㇿ');

		private static readonly Range<char> enclosedCjkLettersandMonths = CreateRange('㈀', '㋿');

		private static readonly Range<char> cjkCompatibility = CreateRange('㌀', '㏿');

		private static readonly Range<char> cjkUnifiedIdeographsExtensionA = CreateRange('㐀', '䶿');

		private static readonly Range<char> yijingHexagramSymbols = CreateRange('䷀', '䷿');

		private static readonly Range<char> cjkUnifiedIdeographs = CreateRange('一', '鿿');

		private static readonly Range<char> yiSyllables = CreateRange('ꀀ', '\ua48f');

		private static readonly Range<char> yiRadicals = CreateRange('꒐', '\ua4cf');

		private static readonly Range<char> hangulSyllables = CreateRange('가', '\ud7af');

		private static readonly Range<char> highSurrogates = CreateRange('\ud800', '\udb7f');

		private static readonly Range<char> highPrivateUseSurrogates = CreateRange('\udb80', '\udbff');

		private static readonly Range<char> lowSurrogates = CreateRange('\udc00', '\udfff');

		private static readonly Range<char> privateUse = CreateRange('\ue000', '\uf8ff');

		private static readonly Range<char> privateUseArea = CreateRange('豈', '\ufaff');

		private static readonly Range<char> cjkCompatibilityIdeographs = CreateRange('ﬀ', 'ﭏ');

		private static readonly Range<char> alphabeticPresentationForms = CreateRange('ﭐ', '﷿');

		private static readonly Range<char> arabicPresentationFormsA = CreateRange('\ufe00', '\ufe0f');

		private static readonly Range<char> variationSelectors = CreateRange('\ufe20', '\ufe2f');

		private static readonly Range<char> combiningHalfMarks = CreateRange('︰', '\ufe4f');

		private static readonly Range<char> cjkCompatibilityForms = CreateRange('﹐', '\ufe6f');

		private static readonly Range<char> smallFormVariants = CreateRange('ﹰ', '\ufeff');

		private static readonly Range<char> arabicPresentationFormsB = CreateRange('\uff00', '\uffef');

		private static readonly Range<char> halfwidthandFullwidthForms = CreateRange('\ufff0', '\uffff');

		public static Range<char> BasicLatin => basicLatin;

		public static Range<char> Latin1Supplement => latin1Supplement;

		public static Range<char> LatinExtendedA => latinExtendedA;

		public static Range<char> LatinExtendedB => latinExtendedB;

		public static Range<char> IpaExtensions => ipaExtensions;

		public static Range<char> SpacingModifierLetters => spacingModifierLetters;

		public static Range<char> CombiningDiacriticalMarks => combiningDiacriticalMarks;

		public static Range<char> GreekAndCoptic => greekAndCoptic;

		public static Range<char> Cyrillic => cyrillic;

		public static Range<char> CyrillicSupplement => cyrillicSupplement;

		public static Range<char> Armenian => armenian;

		public static Range<char> Hebrew => hebrew;

		public static Range<char> Arabic => arabic;

		public static Range<char> Syriac => syriac;

		public static Range<char> Thaana => thaana;

		public static Range<char> Devangari => devangari;

		public static Range<char> Bengali => bengali;

		public static Range<char> Gurmukhi => gurmukhi;

		public static Range<char> Gujarati => gujarati;

		public static Range<char> Oriya => oriya;

		public static Range<char> Tamil => tamil;

		public static Range<char> Telugu => telugu;

		public static Range<char> Kannada => kannada;

		public static Range<char> Malayalam => malayalam;

		public static Range<char> Sinhala => sinhala;

		public static Range<char> Thai => thai;

		public static Range<char> Lao => lao;

		public static Range<char> Tibetan => tibetan;

		public static Range<char> Myanmar => myanmar;

		public static Range<char> Georgian => georgian;

		public static Range<char> HangulJamo => hangulJamo;

		public static Range<char> Ethiopic => ethiopic;

		public static Range<char> Cherokee => cherokee;

		public static Range<char> UnifiedCanadianAboriginalSyllabics => unifiedCanadianAboriginalSyllabics;

		public static Range<char> Ogham => ogham;

		public static Range<char> Runic => runic;

		public static Range<char> Tagalog => tagalog;

		public static Range<char> Hanunoo => hanunoo;

		public static Range<char> Buhid => buhid;

		public static Range<char> Tagbanwa => tagbanwa;

		public static Range<char> Khmer => khmer;

		public static Range<char> Mongolian => mongolian;

		public static Range<char> Limbu => limbu;

		public static Range<char> TaiLe => taiLe;

		public static Range<char> KhmerSymbols => khmerSymbols;

		public static Range<char> PhoneticExtensions => phoneticExtensions;

		public static Range<char> LatinExtendedAdditional => latinExtendedAdditional;

		public static Range<char> GreekExtended => greekExtended;

		public static Range<char> GeneralPunctuation => generalPunctuation;

		public static Range<char> SuperscriptsandSubscripts => superscriptsandSubscripts;

		public static Range<char> CurrencySymbols => currencySymbols;

		public static Range<char> CombiningDiacriticalMarksforSymbols => combiningDiacriticalMarksforSymbols;

		public static Range<char> LetterlikeSymbols => letterlikeSymbols;

		public static Range<char> NumberForms => numberForms;

		public static Range<char> Arrows => arrows;

		public static Range<char> MathematicalOperators => mathematicalOperators;

		public static Range<char> MiscellaneousTechnical => miscellaneousTechnical;

		public static Range<char> ControlPictures => controlPictures;

		public static Range<char> OpticalCharacterRecognition => opticalCharacterRecognition;

		public static Range<char> EnclosedAlphanumerics => enclosedAlphanumerics;

		public static Range<char> BoxDrawing => boxDrawing;

		public static Range<char> BlockElements => blockElements;

		public static Range<char> GeometricShapes => geometricShapes;

		public static Range<char> MiscellaneousSymbols => miscellaneousSymbols;

		public static Range<char> Dingbats => dingbats;

		public static Range<char> MiscellaneousMathematicalSymbolsA => miscellaneousMathematicalSymbolsA;

		public static Range<char> SupplementalArrowsA => supplementalArrowsA;

		public static Range<char> BraillePatterns => braillePatterns;

		public static Range<char> SupplementalArrowsB => supplementalArrowsB;

		public static Range<char> MiscellaneousMathematicalSymbolsB => miscellaneousMathematicalSymbolsB;

		public static Range<char> SupplementalMathematicalOperators => supplementalMathematicalOperators;

		public static Range<char> MiscellaneousSymbolsandArrows => miscellaneousSymbolsandArrows;

		public static Range<char> CjkRadicalsSupplement => cjkRadicalsSupplement;

		public static Range<char> KangxiRadicals => kangxiRadicals;

		public static Range<char> IdeographicDescriptionCharacters => ideographicDescriptionCharacters;

		public static Range<char> CjkSymbolsandPunctuation => cjkSymbolsandPunctuation;

		public static Range<char> Hiragana => hiragana;

		public static Range<char> Katakana => katakana;

		public static Range<char> Bopomofo => bopomofo;

		public static Range<char> HangulCompatibilityJamo => hangulCompatibilityJamo;

		public static Range<char> Kanbun => kanbun;

		public static Range<char> BopomofoExtended => bopomofoExtended;

		public static Range<char> KatakanaPhoneticExtensions => katakanaPhoneticExtensions;

		public static Range<char> EnclosedCjkLettersandMonths => enclosedCjkLettersandMonths;

		public static Range<char> CjkCompatibility => cjkCompatibility;

		public static Range<char> CjkUnifiedIdeographsExtensionA => cjkUnifiedIdeographsExtensionA;

		public static Range<char> YijingHexagramSymbols => yijingHexagramSymbols;

		public static Range<char> CjkUnifiedIdeographs => cjkUnifiedIdeographs;

		public static Range<char> YiSyllables => yiSyllables;

		public static Range<char> YiRadicals => yiRadicals;

		public static Range<char> HangulSyllables => hangulSyllables;

		public static Range<char> HighSurrogates => highSurrogates;

		public static Range<char> HighPrivateUseSurrogates => highPrivateUseSurrogates;

		public static Range<char> LowSurrogates => lowSurrogates;

		public static Range<char> PrivateUse => privateUse;

		public static Range<char> PrivateUseArea => privateUseArea;

		public static Range<char> CjkCompatibilityIdeographs => cjkCompatibilityIdeographs;

		public static Range<char> AlphabeticPresentationForms => alphabeticPresentationForms;

		public static Range<char> ArabicPresentationFormsA => arabicPresentationFormsA;

		public static Range<char> VariationSelectors => variationSelectors;

		public static Range<char> CombiningHalfMarks => combiningHalfMarks;

		public static Range<char> CjkCompatibilityForms => cjkCompatibilityForms;

		public static Range<char> SmallFormVariants => smallFormVariants;

		public static Range<char> ArabicPresentationFormsB => arabicPresentationFormsB;

		public static Range<char> HalfwidthandFullwidthForms => halfwidthandFullwidthForms;

		private static Range<char> CreateRange(char from, char to)
		{
			Range<char> range = new Range<char>(from, to);
			allRanges.Add(range);
			return range;
		}

		public static Range<char> GetRange(char c)
		{
			foreach (Range<char> allRange in allRanges)
			{
				if (allRange.Contains(c))
				{
					return allRange;
				}
			}
			return null;
		}
	}
}
