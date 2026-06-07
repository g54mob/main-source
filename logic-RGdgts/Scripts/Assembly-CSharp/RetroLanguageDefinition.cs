using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RetroLanguageDefinition : ScriptableObject
{
	[Serializable]
	public class KeywordsGroup
	{
		[TextArea]
		public string keywords;

		[NonSerialized]
		public string[] keywordsArray;

		public bool caseSensitive;

		public Color color;
	}

	[Serializable]
	public class Symbols
	{
		[TextArea]
		public string symbols;

		[NonSerialized]
		public HashSet<string> symbolsHashSet;

		public string[] symbolsArray;

		public Color color;
	}

	[Serializable]
	public class Numbers
	{
		public bool highlight;

		public Color color;
	}

	[Serializable]
	public class Comments
	{
		public string lineCommentStart;

		public string blockCommentStart;

		public string blockCommentEnd;

		public Color color;
	}

	[Serializable]
	public class Literals
	{
		public string singleLineLiterals;

		public string[] singleLineLiteralsArray;

		public string multilineLiteralStart;

		public string multilineLiteralEnd;

		public bool highlight;

		public Color color;
	}

	[Serializable]
	public class AutoIndentPrefixesGroup
	{
		[TextArea]
		public string keywords;

		[NonSerialized]
		public string[] keywordsArray;

		public bool caseSensitive;
	}

	public string language;

	[TextArea]
	public string delimiterSymbols;

	[NonSerialized]
	public HashSet<char> delimiterSymbolsArray;

	public List<KeywordsGroup> keywordGroups;

	public Symbols symbols;

	public Numbers numbers;

	public Comments comments;

	public Literals literal;

	public List<AutoIndentPrefixesGroup> autoIndentPrefixGroups;

	public void Init()
	{
	}
}
