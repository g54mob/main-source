using System;
using System.ComponentModel;
using System.Windows.Forms;
using Ookii.Dialogs.Interop;

namespace Ookii.Dialogs
{
	[Description]
	public sealed class VistaFolderBrowserDialog : CommonDialog
	{
		private FolderBrowserDialog _downlevelDialog;

		private string _description;

		private bool _useDescriptionForTitle;

		private string _selectedPath;

		private Environment.SpecialFolder _rootFolder;

		private bool _showNewFolderButton;

		public static bool IsVistaFolderDialogSupported => false;

		[Category]
		[Description]
		public string Description
		{
			set
			{
			}
		}

		[Description]
		[Category]
		public string SelectedPath
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override void Reset()
		{
		}

		protected override bool RunDialog(IntPtr hwndOwner)
		{
			return false;
		}

		protected override void Dispose(bool disposing)
		{
		}

		private void SetDialogProperties(IFileDialog dialog)
		{
		}

		private void GetResult(IFileDialog dialog)
		{
		}
	}
}
