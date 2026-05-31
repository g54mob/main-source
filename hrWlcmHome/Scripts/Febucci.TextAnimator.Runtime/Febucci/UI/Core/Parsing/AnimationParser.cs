using System.Collections.Generic;
using System.Linq;
using System.Text;
using Febucci.UI.Effects;

namespace Febucci.UI.Core.Parsing
{
	public class AnimationParser<T> : TagParserBase where T : AnimationScriptableBase
	{
		public Database<T> database;

		private VisibilityMode visibilityMode;

		private char middleSymbol;

		private const char middleSymbolDefault = '\n';

		private Dictionary<string, AnimationRegion> _results;

		public AnimationRegion[] results => _results.Values.ToArray();

		public AnimationParser(char startSymbol, char closingSymbol, char endSymbol, VisibilityMode visibilityMode, Database<T> database)
			: base(startSymbol, closingSymbol, endSymbol)
		{
			this.visibilityMode = visibilityMode;
			this.database = database;
			middleSymbol = '\n';
		}

		public AnimationParser(char startSymbol, char closingSymbol, char middleSymbol, char endSymbol, VisibilityMode visibilityMode, Database<T> database)
			: base(startSymbol, closingSymbol, endSymbol)
		{
			this.visibilityMode = visibilityMode;
			this.database = database;
			this.middleSymbol = middleSymbol;
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
			_results = new Dictionary<string, AnimationRegion>();
			if ((bool)database)
			{
				database.BuildOnce();
			}
		}

		public override bool TryProcessingTag(string textInsideBrackets, int tagLength, ref int realTextIndex, StringBuilder finalTextBuilder, int internalOrder)
		{
			if (!database)
			{
				return false;
			}
			textInsideBrackets = textInsideBrackets.ToLower();
			database.BuildOnce();
			bool flag = textInsideBrackets[0] == closingSymbol;
			if (flag && tagLength == 1)
			{
				foreach (AnimationRegion value in _results.Values)
				{
					value.CloseAllOpenedRanges(realTextIndex);
				}
				return true;
			}
			int startIndex = (flag ? 1 : 0);
			string[] array = textInsideBrackets.Substring(startIndex).Split();
			string text = array[0];
			if (flag && array.Length > 1)
			{
				return false;
			}
			if (middleSymbol != '\n')
			{
				if (text[0] != middleSymbol)
				{
					return false;
				}
				text = text.Substring(1);
			}
			if (!database.ContainsKey(text))
			{
				return false;
			}
			if (flag)
			{
				if (_results.ContainsKey(text))
				{
					_results[text].TryClosingRange(realTextIndex);
				}
			}
			else
			{
				if (!_results.ContainsKey(text))
				{
					_results.Add(text, new AnimationRegion(text, visibilityMode, database[text]));
				}
				_results[text].OpenNewRange(realTextIndex, array);
			}
			return true;
		}
	}
}
