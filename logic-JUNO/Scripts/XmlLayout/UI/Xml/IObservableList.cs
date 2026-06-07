using System;
using System.Collections.Generic;

namespace UI.Xml
{
	public interface IObservableList
	{
		string guid { get; set; }

		int Count { get; }

		object this[int index] { get; set; }

		Type itemType { get; }

		event Action<int, object, string> itemChanged;

		event Action<object> itemAdded;

		event Action<object> itemRemoved;

		string GetGUID(object item);

		void NotifyItemChanged(object item, string changedField = null);

		int IndexOf(object item);

		int GetIndexByGUID(string guid);

		object GetItemByGUID(string guid);

		List<object> GetItems();
	}
}
