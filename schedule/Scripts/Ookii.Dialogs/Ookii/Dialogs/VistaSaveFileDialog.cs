using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Ookii.Dialogs.Interop;

namespace Ookii.Dialogs
{
	[Description("Prompts the user to open a file.")]
	[Designer("System.Windows.Forms.Design.SaveFileDialogDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[ToolboxBitmap(typeof(SaveFileDialog), "SaveFileDialog.bmp")]
	public class VistaSaveFileDialog : VistaFileDialog
	{
		[DefaultValue(false)]
		[Category("Behavior")]
		[Description("A value indicating whether the dialog box prompts the user for permission to create a file if the user specifies a file that does not exist.")]
		public bool CreatePrompt
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("A value indicating whether the Save As dialog box displays a warning if the user specifies a file name that already exists.")]
		public bool OverwritePrompt
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public VistaSaveFileDialog()
		{
		}

		public VistaSaveFileDialog(bool forceDownlevel)
		{
		}

		public override void Reset()
		{
		}

		public Stream OpenFile()
		{
			return null;
		}

		protected override void OnFileOk(CancelEventArgs e)
		{
		}

		internal override IFileDialog CreateFileDialog()
		{
			return null;
		}
	}
}
