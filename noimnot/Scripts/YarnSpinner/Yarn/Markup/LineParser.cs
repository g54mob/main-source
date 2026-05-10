using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Yarn.Markup
{
	internal class LineParser
	{
		public const string ReplacementMarkerContents = "contents";

		public const string CharacterAttribute = "character";

		public const string CharacterAttributeNameProperty = "name";

		public const string TrimWhitespaceProperty = "trimwhitespace";

		private static readonly Regex EndOfCharacterMarker;

		private static readonly Comparison<MarkupAttribute> AttributePositionComparison;

		private readonly Dictionary<string, IAttributeMarkerProcessor> markerProcessors;

		private string input;

		private StringReader stringReader;

		private int position;

		private int sourcePosition;

		internal LineParser()
		{
		}

		internal void RegisterMarkerProcessor(string attributeName, IAttributeMarkerProcessor markerProcessor)
		{
		}

		internal MarkupParseResult ParseMarkup(string input)
		{
			return default(MarkupParseResult);
		}

		private string ProcessReplacementMarker(MarkupAttributeMarker marker)
		{
			return null;
		}

		private string ParseRawTextUpToAttributeClose(string name)
		{
			return null;
		}

		private List<MarkupAttribute> BuildAttributesFromMarkers(List<MarkupAttributeMarker> markers)
		{
			return null;
		}

		private MarkupAttributeMarker ParseAttributeMarker()
		{
			return default(MarkupAttributeMarker);
		}

		private MarkupValue ParseValue()
		{
			return default(MarkupValue);
		}

		private bool Peek(char expectedCharacter)
		{
			return false;
		}

		private bool PeekWhitespace()
		{
			return false;
		}

		private bool PeekNumeric()
		{
			return false;
		}

		private int ParseInteger()
		{
			return 0;
		}

		private string ParseID()
		{
			return null;
		}

		private string ParseString()
		{
			return null;
		}

		private void ParseCharacter(char character)
		{
		}

		private void AssertNotEndOfInput(int value)
		{
		}

		private void ConsumeWhitespace(bool allowEndOfLine = false)
		{
		}
	}
}
