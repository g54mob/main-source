using System.Collections;
using System.ComponentModel;

namespace Ookii.Dialogs
{
	public class TaskDialogRadioButton : TaskDialogItem
	{
		private bool _checked;

		[DefaultValue(false)]
		[Category("Appearance")]
		[Description("Indicates whether the radio button is checked.")]
		public bool Checked
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected override IEnumerable ItemCollection => null;

		public TaskDialogRadioButton()
		{
		}

		public TaskDialogRadioButton(IContainer container)
		{
		}
	}
}
