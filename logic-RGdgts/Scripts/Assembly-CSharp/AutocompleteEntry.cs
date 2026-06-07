using System;

[Serializable]
public class AutocompleteEntry
{
	public string name;

	public AutocompleteEntryKind kind;

	public string type;

	public bool deprecated;

	public bool wrongIndexType;

	public TypeCorrectKind typeCorrect;

	public string documentationSymbol;

	public ParenthesesRecommendation parens;
}
