using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Febucci.Parsing.Core;

namespace Febucci.Parsing.Regions
{
	public class RegionParser<TDataType> : RegionParser<TDataType, TDataType>
	{
		public RegionParser(char openingBracket, char closingBracket, char endSymbol, Dictionary<string, TDataType> tagsLookup, bool isCaseSensitive)
			: base(openingBracket, closingBracket, endSymbol, tagsLookup, isCaseSensitive)
		{
		}

		public RegionParser(char openingBracket, char closingBracket, char middleSymbol, char endSymbol, Dictionary<string, TDataType> tagsLookup, bool isCaseSensitive)
			: base(openingBracket, closingBracket, middleSymbol, endSymbol, tagsLookup, isCaseSensitive)
		{
		}

		protected override TDataType CreatePlayer(string tagId, TDataType preset, RegionParameters parameters)
		{
			return preset;
		}
	}
	public abstract class RegionParser<TDataType, TRegionContent> : TagParserBase
	{
		private readonly bool isCaseSensitive;

		private bool hasAnyTag;

		public char MiddleSymbol;

		private Dictionary<PlayerKey, TextRegion<TRegionContent>> playerPool;

		private Dictionary<string, Stack<PlayerKey>> openRangesByTag;

		public Dictionary<string, TDataType> TagsLookup { get; private set; }

		public TextRegion<TRegionContent>[] Results { get; private set; }

		public RegionParser(char openingBracket, char closingBracket, char endSymbol, Dictionary<string, TDataType> tagsLookup, bool isCaseSensitive)
			: base(openingBracket, endSymbol, closingBracket)
		{
			TagsLookup = new Dictionary<string, TDataType>();
			AssignLookup(tagsLookup);
			MiddleSymbol = '\0';
			this.isCaseSensitive = isCaseSensitive;
			playerPool = new Dictionary<PlayerKey, TextRegion<TRegionContent>>();
			openRangesByTag = new Dictionary<string, Stack<PlayerKey>>();
			Results = Array.Empty<TextRegion<TRegionContent>>();
		}

		public RegionParser(char openingBracket, char closingBracket, char middleSymbol, char endSymbol, Dictionary<string, TDataType> tagsLookup, bool isCaseSensitive)
			: base(openingBracket, endSymbol, closingBracket)
		{
			TagsLookup = new Dictionary<string, TDataType>();
			AssignLookup(tagsLookup);
			MiddleSymbol = middleSymbol;
			this.isCaseSensitive = isCaseSensitive;
			playerPool = new Dictionary<PlayerKey, TextRegion<TRegionContent>>();
			openRangesByTag = new Dictionary<string, Stack<PlayerKey>>();
			Results = Array.Empty<TextRegion<TRegionContent>>();
		}

		public void ClearLookup()
		{
			TagsLookup.Clear();
		}

		public void AssignLookup(Dictionary<string, TDataType> tagsLookup, bool additive = false)
		{
			if (additive)
			{
				foreach (KeyValuePair<string, TDataType> item in tagsLookup)
				{
					TagsLookup.TryAdd(item.Key, item.Value);
				}
			}
			else
			{
				ClearLookup();
				if (tagsLookup != null)
				{
					TagsLookup = tagsLookup;
				}
			}
			hasAnyTag = TagsLookup.Count > 0;
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
			playerPool.Clear();
			openRangesByTag.Clear();
			Results = Array.Empty<TextRegion<TRegionContent>>();
		}

		protected virtual void CloseAllOpenedRanges(int realTextIndex)
		{
			foreach (TextRegion<TRegionContent> value in playerPool.Values)
			{
				value.CloseAllOpenedRanges(realTextIndex);
			}
			openRangesByTag.Clear();
		}

		public override bool TryProcessingTag(string textInsideBrackets, int tagLength, ref int realTextIndex, StringBuilder finalTextBuilder, int internalOrder)
		{
			if (!hasAnyTag || TagsLookup == null)
			{
				return false;
			}
			if (!isCaseSensitive)
			{
				textInsideBrackets = textInsideBrackets.ToLowerInvariant();
			}
			bool flag = textInsideBrackets[0] == EndSymbol;
			if (flag && tagLength == 1)
			{
				CloseAllOpenedRanges(realTextIndex);
				return true;
			}
			int startIndex = (flag ? 1 : 0);
			string text = textInsideBrackets.Substring(startIndex);
			string[] array = text.Split();
			string text2 = array[0];
			if (flag && array.Length > 1)
			{
				return false;
			}
			if (MiddleSymbol != 0)
			{
				if (text2[0] != MiddleSymbol)
				{
					return false;
				}
				text2 = text2.Substring(1);
			}
			if (!TagsLookup.TryGetValue(text2, out var value))
			{
				return false;
			}
			if (flag)
			{
				CloseRange(text2, value, realTextIndex);
			}
			else
			{
				OpenRange(text2, value, realTextIndex, array);
			}
			return true;
		}

		protected abstract TRegionContent CreatePlayer(string tagId, TDataType preset, RegionParameters parameters);

		protected virtual void OpenRange(string tagId, TDataType data, int realTextIndex, string[] words)
		{
			RegionParameters parameters = new RegionParameters(words);
			PlayerKey playerKey = new PlayerKey(tagId, parameters);
			if (!playerPool.TryGetValue(playerKey, out var value))
			{
				TRegionContent val = CreatePlayer(tagId, data, parameters);
				if (val == null)
				{
					return;
				}
				value = new TextRegion<TRegionContent>(tagId, val);
				playerPool.Add(playerKey, value);
			}
			if (!openRangesByTag.TryGetValue(tagId, out var value2))
			{
				value2 = new Stack<PlayerKey>();
				openRangesByTag.Add(tagId, value2);
			}
			value2.Push(playerKey);
			value.OpenNewRange(realTextIndex, words);
		}

		protected virtual void CloseRange(string tagId, TDataType data, int realTextIndex)
		{
			if (openRangesByTag.TryGetValue(tagId, out var value) && value.Count != 0)
			{
				PlayerKey key = value.Pop();
				if (playerPool.TryGetValue(key, out var value2))
				{
					value2.TryClosingRange(realTextIndex);
				}
			}
		}

		protected override void OnFinishParsing()
		{
			Results = playerPool.Values.ToArray();
		}
	}
}
