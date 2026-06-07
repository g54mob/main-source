using System.Collections;
using System.ComponentModel;

namespace Ookii.Dialogs
{
	[DefaultEvent("Click")]
	[DefaultProperty("Text")]
	[DesignTimeVisible(false)]
	[ToolboxItem(false)]
	public abstract class TaskDialogItem : Component
	{
		private TaskDialog _owner;

		private int _id;

		private bool _enabled;

		private string _text;

		private IContainer components;

		[Browsable(false)]
		public TaskDialog Owner
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		[Localizable(true)]
		[Description("The text of the item.")]
		[DefaultValue(null)]
		[Category("Appearance")]
		public string Text
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
		[Description("Indicates whether the item is enabled.")]
		[DefaultValue(true)]
		public bool Enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Category("Data")]
		[Description("The id of the item.")]
		[DefaultValue(0)]
		internal virtual int Id
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected abstract IEnumerable ItemCollection { get; }

		protected TaskDialogItem()
		{
		}

		protected TaskDialogItem(IContainer container)
		{
		}

		internal TaskDialogItem(int id)
		{
		}

		public void Click()
		{
		}

		protected void UpdateOwner()
		{
		}

		internal virtual void CheckDuplicate(TaskDialogItem itemToExclude)
		{
		}

		internal virtual void AutoAssignId()
		{
		}

		private void CheckDuplicateId(TaskDialogItem itemToExclude, int id)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
