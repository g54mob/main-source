using System.ComponentModel;
using Ookii.Dialogs.Interop;

namespace Ookii.Dialogs
{
	[Description]
	public class VistaSaveFileDialog : VistaFileDialog
	{
		[Category]
		[Description]
		public bool CreatePrompt => false;

		[Description]
		[Category]
		public bool OverwritePrompt
		{
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

		protected override void OnFileOk(CancelEventArgs e)
		{
		}

		internal override IFileDialog CreateFileDialog()
		{
			return null;
		}
	}
}
