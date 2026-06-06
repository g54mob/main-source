using System;
using System.Text;
using Febucci.Parsing.Core;

namespace Febucci.TextAnimatorCore.Typing
{
	internal class EventParser : TagParserBase
	{
		private const char eventSymbol = '?';

		private EventMarker[] _results;

		public EventMarker[] results => _results;

		public EventParser(char openingBracket, char closingTagSymbol, char closingBracket)
			: base(openingBracket, closingTagSymbol, closingBracket)
		{
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
			_results = new EventMarker[0];
		}

		public override bool TryProcessingTag(string textInsideBrackets, int tagLength, ref int realTextIndex, StringBuilder finalTextBuilder, int internalOrder)
		{
			if (textInsideBrackets[0] != '?')
			{
				return false;
			}
			int num = textInsideBrackets.IndexOf('=');
			EventMarker eventMarker;
			if (num != -1)
			{
				string name = textInsideBrackets.Substring(1, num - 1);
				string text = textInsideBrackets.Substring(num + 1);
				eventMarker = new EventMarker(realTextIndex, name, text.Replace(" ", "").Split(','), internalOrder);
			}
			else
			{
				eventMarker = new EventMarker(realTextIndex, textInsideBrackets.Substring(1), Array.Empty<string>(), internalOrder);
			}
			Array.Resize(ref _results, _results.Length + 1);
			_results[_results.Length - 1] = eventMarker;
			return true;
		}
	}
}
