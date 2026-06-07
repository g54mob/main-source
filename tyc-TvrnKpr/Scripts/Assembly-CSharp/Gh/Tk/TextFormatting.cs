using System;
using System.Collections.Generic;
using System.Text;

namespace Gh.Tk
{
	public static class TextFormatting
	{
		public struct TextProcessor
		{
			public string prefix;

			public string suffix;

			public bool isLateProcessor;

			public Func<string, string> processorFunction;

			public Func<string, string> processForSpeechFunction;
		}

		public const string currencySymbol = "<sprite name=\"currency_gold\">";

		internal static string _positiveMoneyColour;

		internal static string _negativeMoneyColour;

		private static float _traitIconTextSize;

		public const string HandBookLinkCodexPrefix = "handbook-link:";

		public const float LargeSpacing = 0.64f;

		public const float StandardSpacing = 0.425f;

		public const float SmallSpacing = 0.3f;

		public const int MODIFIERLINE_MAX_CHEVRONS = 3;

		public const int MODIFIERLINE_MIN_CHEVRONS = 1;

		private const int MODIFIERLINE_NUMERICAL_MAX_LENGTH = 6;

		private static readonly List<TextProcessor> _textProcessors;

		static TextFormatting()
		{
		}

		public static string SetSpoiler(string text)
		{
			return null;
		}

		public static string SetBold(string text)
		{
			return null;
		}

		public static string SetItalic(string text)
		{
			return null;
		}

		public static string GetStarsIcons(float stars)
		{
			return null;
		}

		public static string FormatCurrency(float amount, bool withColour = false, bool invertColors = false)
		{
			return null;
		}

		public static string FormatColor(string text, string color)
		{
			return null;
		}

		public static string FormatCurrency(int amount, bool withColour = false)
		{
			return null;
		}

		public static string FormatTimestamp(float timestamp)
		{
			return null;
		}

		public static string FormatTime(int hour, int minute)
		{
			return null;
		}

		public static string CreateInlineIcon(string icon, string prefabId = null, string buttonId = null)
		{
			return null;
		}

		public static string CreateInlineStars(float stars)
		{
			return null;
		}

		public static void AppendInlineStars(this StringBuilder sb, float stars)
		{
		}

		public static void AppendInlineStars(this StringBuilderPool.DisposableStringBuilder sb, float stars)
		{
		}

		public static string CreateInlineTraitIcon(string icon, string traitPrefabName, float progressPecentage = -1f, string color = null, string codexTooltipOverride = null)
		{
			return null;
		}

		public static string CreateInlineProgressBar(int progress, string color = null)
		{
			return null;
		}

		public static string CreateProgressBarBlock(int progress, int bonusMalus)
		{
			return null;
		}

		public static string CreateProgressBarBlock(int progress, int bonusMalus, (int position, string codex)[] gauges, string color = "green")
		{
			return null;
		}

		public static string CreateInlineBindingVisual(string actionPath, int bindingIndex = 0)
		{
			return null;
		}

		public static string CreateInlineCheckbox(bool isChecked, string style = "check")
		{
			return null;
		}

		public static string FormatHandbookLinkTextKey(string linkNameKey)
		{
			return null;
		}

		private static string CreateHandbookLink(string topicId)
		{
			return null;
		}

		public static string GetProgressColor(float value)
		{
			return null;
		}

		public static void SanitizeNewLineEndings(StringBuilderPool.DisposableStringBuilder sb)
		{
		}

		public static string SanitizeNewLineEndings(string text)
		{
			return null;
		}

		public static Dictionary<string, string> ParseTagAttributes(string attributeText)
		{
			return null;
		}

		public static string FormatSpacing(string text, float spacingSize = 0.425f, int leftPadding = 0, int rightPadding = 0)
		{
			return null;
		}

		public static string FormatCharSpacing(string text, float spacingSize = 0.425f, int leftPadding = 0, int rightPadding = 0)
		{
			return null;
		}

		public static string FormatPercentage(string value)
		{
			return null;
		}

		public static string FormatModifierLine(int chevronAmount, float value, string valuePrefix, string valueSuffix, string description)
		{
			return null;
		}

		public static string FormatModifierLine(int chevronAmount, float value, string valuePrefix, string valueSuffix, string description, bool isPositive, bool showPositiveSignedValue)
		{
			return null;
		}

		public static void RegisterKeywordTextReplacement(string keyword, Func<string, string> processFunc, Func<string, string> processForSpeechFunction, bool isLateProcessor = false, bool hasParameters = true)
		{
		}

		public static void RegisterRichTextTag(string tag, string prefixReplacement, string suffixReplacement, bool isLateProcessor = false)
		{
		}

		public static string ProcessText(string text, bool forSpeech = false)
		{
			return null;
		}

		public static StringBuilder ProcessText(StringBuilder sb, bool forSpeech = false)
		{
			return null;
		}

		public static StringBuilder LateProcessText(StringBuilder sb, bool forSpeech = false)
		{
			return null;
		}

		private static StringBuilder ProcessTextInternal(StringBuilder sb, bool forSpeech, bool useLateProcessors)
		{
			return null;
		}

		public static StringBuilder ApplyTextProcessor(StringBuilder sb, TextProcessor processor, bool forSpeech)
		{
			return null;
		}

		public static StringBuilder ProcessKeyWord(StringBuilder sb, string keyword, Func<string, string> processor)
		{
			return null;
		}

		public static StringBuilder ProcessTextReplacement(StringBuilder sb, string prefix, string suffix, Func<string, string> replacementProcessor)
		{
			return null;
		}

		public static string FormatCreatorName(string creatorName)
		{
			return null;
		}

		public static string FormatCreatorTagLine(string creatorName)
		{
			return null;
		}
	}
}
