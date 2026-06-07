namespace Febucci.UI.Core.Parsing
{
	public class EventParser : TagParserBase
	{
		private const char eventSymbol = '?';

		private EventMarker[] _results;

		public EventMarker[] results => null;

		public EventParser(char openingBracket, char closingBracket, char closingTagSymbol)
		{
		}

		protected override void OnInitialize()
		{
		}

		public override bool TryProcessingTag(string textInsideBrackets, int tagLength, int realTextIndex, int internalOrder)
		{
			return false;
		}
	}
}
