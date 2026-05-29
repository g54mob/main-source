using System.ComponentModel;

namespace Ookii.Dialogs
{
	public class TaskDialogItemClickedEventArgs : CancelEventArgs
	{
		private readonly TaskDialogItem _item;

		public TaskDialogItem Item => null;

		public TaskDialogItemClickedEventArgs(TaskDialogItem item)
		{
		}
	}
}
