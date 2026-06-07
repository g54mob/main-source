using System.Linq;

namespace UI.Xml.Examples.MVVM.FilteredList
{
	public class MVVMExampleFilteredListViewModel : XmlLayoutViewModel
	{
		public ObservableList<MVVMExampleFilteredListControllerItem> items { get; set; }

		public ObservableList<MVVMExampleFilteredListControllerItem> ownedItems => items.Where((MVVMExampleFilteredListControllerItem i) => i.selected).ToObservableList();

		public ObservableList<MVVMExampleFilteredListControllerItem> unownedItems => items.Where((MVVMExampleFilteredListControllerItem i) => !i.selected).ToObservableList();
	}
}
