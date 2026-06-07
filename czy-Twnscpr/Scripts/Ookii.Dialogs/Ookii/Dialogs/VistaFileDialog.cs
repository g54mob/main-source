using System;
using System.ComponentModel;
using System.Windows.Forms;
using Ookii.Dialogs.Interop;

namespace Ookii.Dialogs
{
	public abstract class VistaFileDialog : CommonDialog
	{
		private FileDialog _downlevelDialog;

		private NativeMethods.FOS _options;

		private string _filter;

		private int _filterIndex;

		private string[] _fileNames;

		private string _defaultExt;

		private bool _addExtension;

		private string _initialDirectory;

		private bool _showHelp;

		private string _title;

		private bool _supportMultiDottedExtensions;

		private IntPtr _hwndOwner;

		private static readonly object EventFileOk;

		public static bool IsVistaFileDialogSupported => false;

		[Category]
		[Description]
		public bool AddExtension
		{
			set
			{
			}
		}

		[Category]
		[Description]
		public virtual bool CheckFileExists
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Category]
		[Description]
		public bool CheckPathExists
		{
			set
			{
			}
		}

		[Category]
		[Description]
		public string DefaultExt
		{
			set
			{
			}
		}

		[Category]
		[Description]
		public string FileName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Description]
		public string[] FileNames => null;

		[Description]
		[Category]
		public string Filter
		{
			set
			{
			}
		}

		[Description]
		[Category]
		public int FilterIndex
		{
			set
			{
			}
		}

		[Description]
		[Category]
		public string Title
		{
			set
			{
			}
		}

		protected FileDialog DownlevelDialog
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal string[] FileNamesInternal
		{
			private get
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

		internal void SetOption(NativeMethods.FOS option, bool value)
		{
		}

		internal bool GetOption(NativeMethods.FOS option)
		{
			return false;
		}

		internal virtual void GetResult(IFileDialog dialog)
		{
		}

		protected virtual void OnFileOk(CancelEventArgs e)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		internal bool PromptUser(string text, MessageBoxButtons buttons, MessageBoxIcon icon)
		{
			return false;
		}

		internal virtual void SetDialogProperties(IFileDialog dialog)
		{
		}

		internal abstract IFileDialog CreateFileDialog();

		internal void DoHelpRequest()
		{
		}

		internal bool DoFileOk(IFileDialog dialog)
		{
			return false;
		}

		private bool RunFileDialog(IntPtr hwndOwner)
		{
			return false;
		}

		private void DownlevelDialog_HelpRequest(object sender, EventArgs e)
		{
		}

		private void DownlevelDialog_FileOk(object sender, CancelEventArgs e)
		{
		}
	}
}
