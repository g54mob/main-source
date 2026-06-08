using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP
{
	public class Clipboard
	{
		public StateList<ClipboardItem> items;

		public State<ClipboardItem> selectedItem;

		public FilePrefs filePrefs;

		public void AddItem(ClipboardItem item)
		{
		}

		public void RemoveItem(ClipboardItem item)
		{
		}

		public void Clear()
		{
		}

		public void LoadItems()
		{
		}

		public void PasteParts(ProjectPageView pageView)
		{
		}
	}
}
