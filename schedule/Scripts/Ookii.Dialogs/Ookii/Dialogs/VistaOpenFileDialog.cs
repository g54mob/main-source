using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Ookii.Dialogs.Interop;

namespace Ookii.Dialogs
{
	[ToolboxBitmap(typeof(OpenFileDialog), "OpenFileDialog.bmp")]
	[Description("Prompts the user to open a file.")]
	public class VistaOpenFileDialog : VistaFileDialog
	{
		private bool _showReadOnly;

		private bool _readOnlyChecked;

		private const int _openDropDownId = 16386;

		private const int _openItemId = 16387;

		private const int _readOnlyItemId = 16388;

		[DefaultValue(true)]
		[Description("A value indicating whether the dialog box displays a warning if the user specifies a file name that does not exist.")]
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

		[Description("A value indicating whether the dialog box allows multiple files to be selected.")]
		[Category("Behavior")]
		[DefaultValue(false)]
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

		[DefaultValue(false)]
		[Category("Behavior")]
		[Description("A value indicating whether the dialog box contains a read-only check box.")]
		public bool ShowReadOnly
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Description("A value indicating whether the read-only check box is selected.")]
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool ReadOnlyChecked
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public VistaOpenFileDialog()
		{
		}

		public VistaOpenFileDialog(bool forceDownlevel)
		{
		}

		public override void Reset()
		{
		}

		public Stream OpenFile()
		{
			return null;
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
