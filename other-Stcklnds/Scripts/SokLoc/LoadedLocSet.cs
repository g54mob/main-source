using System.Collections.Generic;
using UnityEngine;

public class LoadedLocSet
{
	public string Language;

	public Dictionary<string, SokTerm> TermLookup;

	public List<SokTerm> AllTerms;

	public LoadedLocSet(LocResources resources, string languageToLoad)
	{
		TermLookup = new Dictionary<string, SokTerm>();
		AllTerms = new List<SokTerm>();
		Language = languageToLoad;
		int languageColumnIndex = resources.GetLanguageColumnIndex(languageToLoad);
		if (languageColumnIndex == -1)
		{
			return;
		}
		for (int i = 1; i < resources.LocTable.Length; i++)
		{
			string term = resources.LocTable[i][0];
			string fullText = resources.LocTable[i][languageColumnIndex];
			term = term.Trim();
			term = term.ToLower();
			if (string.IsNullOrEmpty(term))
			{
				continue;
			}
			SokTerm sokTerm = new SokTerm(this, term, fullText);
			if (TermLookup.ContainsKey(term))
			{
				Debug.LogError("Term " + term + " has been found more then once in the localisation sheet. Using last item in sheet.");
				TermLookup[term] = sokTerm;
				AllTerms.RemoveAll((SokTerm x) => x.Id == term);
				AllTerms.Add(sokTerm);
			}
			else
			{
				AllTerms.Add(sokTerm);
				TermLookup.Add(term, sokTerm);
			}
		}
	}

	public bool ContainsTerm(string term)
	{
		term = term.ToLowerCached();
		return TermLookup.ContainsKey(term);
	}

	public SokTerm GetTerm(string term)
	{
		term = term.ToLowerCached();
		TermLookup.TryGetValue(term, out var value);
		return value;
	}

	public string TranslateTerm(string termId)
	{
		SokTerm term = GetTerm(termId);
		if (term == null)
		{
			return "---MISSING---";
		}
		return term.GetText();
	}

	public string TranslateTerm(string termId, params LocParam[] locParams)
	{
		SokTerm term = GetTerm(termId);
		if (term == null)
		{
			return "---MISSING---";
		}
		return FillInTerm(term, locParams);
	}

	private int GetPluralParam(LocParam[] locParams)
	{
		for (int i = 0; i < locParams.Length; i++)
		{
			if (locParams[i].PluralCount != -1)
			{
				return locParams[i].PluralCount;
			}
		}
		return -1;
	}

	public string FillInTerm(SokTerm term, params LocParam[] locParams)
	{
		int pluralParam = GetPluralParam(locParams);
		string s = ((pluralParam == -1) ? term.GetText() : term.GetText(pluralParam));
		return LocCache.FillInCached(s, locParams);
	}
}
