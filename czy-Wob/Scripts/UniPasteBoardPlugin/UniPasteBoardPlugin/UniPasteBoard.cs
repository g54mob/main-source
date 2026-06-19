using System.Windows.Forms;

namespace UniPasteBoardPlugin
{
	public class UniPasteBoard
	{
		public static string GetClipBoardString()
		{
			return Clipboard.GetText();
		}

		public static void SetClipBoardString(string text)
		{
			Clipboard.SetText(text);
		}
	}
}
