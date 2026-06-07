namespace UI.Xml
{
	internal interface IObservableListTagHandler
	{
		bool IsHandlingList(IObservableList list);

		void RemoveListItem(IObservableList list, object item, string listName);

		void AddListItem(IObservableList list, object item, string listName);

		void UpdateListItem(IObservableList list, int index, object item, string listName, string changedField = null);
	}
}
