using System.Text.RegularExpressions;

public class SokTerm
{
	public LoadedLocSet ParentLocSet;

	public string Id;

	public string FullText;

	public PluralForm PluralForm;

	private static Regex pluralRegex = new Regex("<.+?>");

	public bool HasPlural => PluralForm != null;

	public SokTerm(LoadedLocSet parentSet, string id, string fullText)
	{
		ParentLocSet = parentSet;
		Id = id;
		FullText = fullText;
		if (TextHasPlural(fullText))
		{
			PluralForm = CreatePluralForm(fullText);
		}
	}

	private PluralForm CreatePluralForm(string fullText)
	{
		PluralForm pluralForm = new PluralForm
		{
			One = PullTag(fullText, "one"),
			Many = PullTag(fullText, "many"),
			Other = PullTag(fullText, "other")
		};
		if (pluralForm.IsEmpty())
		{
			return null;
		}
		return pluralForm;
	}

	private bool TextHasPlural(string fullText)
	{
		return pluralRegex.IsMatch(fullText);
	}

	private string PullTag(string fullText, string s)
	{
		Match match = Regex.Match(fullText, "<" + s + ">(.*?)(<|$)");
		if (match.Groups.Count > 0)
		{
			return match.Groups[1].Value;
		}
		return null;
	}

	public string GetText()
	{
		if (HasPlural)
		{
			return PluralForm.Other;
		}
		return FullText;
	}

	public string GetText(int pluralCount)
	{
		if (string.IsNullOrEmpty(FullText))
		{
			return "";
		}
		if (!HasPlural)
		{
			return FullText;
		}
		return PluralForm.GetCorrectPluralForm(ParentLocSet.Language, pluralCount);
	}
}
