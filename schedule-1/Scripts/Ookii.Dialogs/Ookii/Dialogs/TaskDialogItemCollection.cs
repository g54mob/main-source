using System.Collections.ObjectModel;

namespace Ookii.Dialogs
{
	public class TaskDialogItemCollection<T> : Collection<T> where T : TaskDialogItem
	{
		private TaskDialog _owner;

		internal TaskDialogItemCollection(TaskDialog owner)
		{
		}

		protected override void ClearItems()
		{
		}

		protected override void InsertItem(int index, T item)
		{
		}

		protected override void RemoveItem(int index)
		{
		}

		protected override void SetItem(int index, T item)
		{
		}
	}
}
