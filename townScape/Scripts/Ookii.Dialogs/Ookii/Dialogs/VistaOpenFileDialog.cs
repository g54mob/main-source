using System.ComponentModel;
using Ookii.Dialogs.Interop;

namespace Ookii.Dialogs
{
	[Description]
	public class VistaOpenFileDialog : VistaFileDialog
	{
		private bool _showReadOnly;

		private bool _readOnlyChecked;

		[Description]
		public override bool CheckFileExists
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Description]
		[Category]
		public bool Multiselect
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Description]
		[Category]
		public bool ShowReadOnly => false;

		public VistaOpenFileDialog()
		{
		}

		public VistaOpenFileDialog(bool forceDownlevel)
		{
		}

		public override void Reset()
		{
		}

		internal override IFileDialog CreateFileDialog()
		{
			return null;
		}

		internal override void SetDialogProperties(IFileDialog dialog)
		{
		}

		internal override void GetResult(IFileDialog dialog)
		{
		}
	}
}
