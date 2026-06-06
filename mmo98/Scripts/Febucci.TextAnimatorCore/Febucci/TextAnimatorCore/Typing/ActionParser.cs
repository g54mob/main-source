using System;
using System.Collections.Generic;
using System.Text;
using Febucci.Parsing.Core;

namespace Febucci.TextAnimatorCore.Typing
{
	internal sealed class ActionParser : TagParserBase
	{
		public Dictionary<string, ITypewriterAction> database;

		private ActionMarker[] _results;

		public ActionMarker[] results => _results;

		public ActionParser(char openingBracket, char endSymbol, char closingBracket)
			: base(openingBracket, endSymbol, closingBracket)
		{
			database = new Dictionary<string, ITypewriterAction>();
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
			_results = new ActionMarker[0];
		}

		public override bool TryProcessingTag(string textInsideBrackets, int tagLength, ref int realTextIndex, StringBuilder finalTextBuilder, int internalOrder)
		{
			if (database == null)
			{
				return false;
			}
			int num = textInsideBrackets.IndexOf('=');
			string text = ((num == -1) ? textInsideBrackets : textInsideBrackets.Substring(0, num));
			text = text.ToLower();
			if (!database.ContainsKey(text))
			{
				return false;
			}
			ActionMarker actionMarker;
			if (num != -1)
			{
				string text2 = textInsideBrackets.Substring(num + 1);
				actionMarker = new ActionMarker(realTextIndex, text, text2.Replace(" ", "").Split(','), internalOrder);
			}
			else
			{
				actionMarker = new ActionMarker(realTextIndex, text, new string[0], internalOrder);
			}
			Array.Resize(ref _results, _results.Length + 1);
			_results[_results.Length - 1] = actionMarker;
			return true;
		}
	}
}
