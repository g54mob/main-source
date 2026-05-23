using System.Collections.Generic;

public class MessagePanelLogic
{
	private Book book;

	private string message;

	public MessagePanelLogic(Book book_)
	{
		book = book_;
	}

	public void Show(string message_)
	{
		message = message_;
		book.OpenPopup("MessagePanel");
	}

	public void Refresh(Dictionary<string, PageItem> items)
	{
		items["message"].text = message;
	}
}
