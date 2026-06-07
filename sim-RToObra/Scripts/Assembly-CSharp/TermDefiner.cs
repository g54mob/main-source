using System.Collections.Generic;

public class TermDefiner
{
	private Book book;

	private BookSpec.GlossaryEntry glossaryEntry;

	public TermDefiner(Book book_)
	{
		book = book_;
	}

	public void Show(BookSpec.GlossaryEntry glossaryEntry_)
	{
		glossaryEntry = glossaryEntry_;
		book.OpenPopup("DefineTerm");
	}

	public void Refresh(Dictionary<string, PageItem> items)
	{
		items["name"].text = glossaryEntry.name;
		items["definition"].text = glossaryEntry.definition;
	}
}
