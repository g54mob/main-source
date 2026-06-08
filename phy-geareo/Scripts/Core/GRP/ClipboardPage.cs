using System.Collections.Generic;
using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP
{
	public class ClipboardPage : Page
	{
		[ListLoaderCrew]
		public StateSelector<List<ClipboardItemViewable>> items;

		public Clipboard clipboard;

		public ProjectPageView projectPageView;

		public override void OnContext()
		{
		}

		public override void OnContextDispose()
		{
		}

		public void SelectItem(ClipboardItem item)
		{
		}

		[CrewMethod]
		public void Back()
		{
		}

		[CrewMethod]
		public void Clear()
		{
		}
	}
}
