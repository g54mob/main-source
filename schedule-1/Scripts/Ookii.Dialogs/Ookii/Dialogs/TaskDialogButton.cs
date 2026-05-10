using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;

namespace Ookii.Dialogs
{
	public class TaskDialogButton : TaskDialogItem
	{
		private ButtonType _type;

		private bool _elevationRequired;

		private bool _default;

		private string _commandLinkNote;

		[Category("Appearance")]
		[DefaultValue(ButtonType.Custom)]
		[Description("The type of the button.")]
		public ButtonType ButtonType
		{
			get
			{
				return default(ButtonType);
			}
			set
			{
			}
		}

		[Localizable(true)]
		[Category("Appearance")]
		[Description("The text of the note associated with a command link button.")]
		[DefaultValue(null)]
		[Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		public string CommandLinkNote
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Indicates if the button is the default button on the dialog.")]
		public bool Default
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[DefaultValue(false)]
		[Description("Indicates whether the Task Dialog button or command link should have a User Account Control (UAC) shield icon (in other words, whether the action invoked by the button requires elevation).")]
		[Category("Behavior")]
		public bool ElevationRequired
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal override int Id
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal NativeMethods.TaskDialogCommonButtonFlags ButtonFlag => default(NativeMethods.TaskDialogCommonButtonFlags);

		protected override IEnumerable ItemCollection => null;

		public TaskDialogButton()
		{
		}

		public TaskDialogButton(ButtonType type)
		{
		}

		public TaskDialogButton(IContainer container)
		{
		}

		public TaskDialogButton(string text)
		{
		}

		internal override void AutoAssignId()
		{
		}

		internal override void CheckDuplicate(TaskDialogItem itemToExclude)
		{
		}

		private void CheckDuplicateButton(ButtonType type, TaskDialogItem itemToExclude)
		{
		}
	}
}
