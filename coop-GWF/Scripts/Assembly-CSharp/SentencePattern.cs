using System;
using System.Collections.Generic;

[Serializable]
public class SentencePattern
{
	public string name;

	public List<PatternToken> tokens;

	public SentencePattern(string name, IEnumerable<PatternToken> toks)
	{
		this.name = name;
		tokens = new List<PatternToken>(toks);
	}
}
