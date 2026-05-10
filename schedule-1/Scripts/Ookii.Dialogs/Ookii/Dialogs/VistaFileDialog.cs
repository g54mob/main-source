using System;
using System.ComponentModel;
using System.Windows.Forms;
using Ookii.Dialogs.Interop;

namespace Ookii.Dialogs
{
	[DefaultEvent("FileOk")]
	[DefaultProperty("FileName")]
	public abstract class VistaFileDialog : CommonDialog
	{
		internal const int HelpButtonId = 16385;

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

		[Browsable(false)]
		public static bool IsVistaFileDialogSupported => false;

		[Description("A value indicating whether the dialog box automatically adds an extension to a file name if the user omits the extension.")]
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool AddExtension
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Description("A value indicating whether the dialog box displays a warning if the user specifies a file name that does not exist.")]
		[DefaultValue(false)]
		[Category("Behavior")]
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

		[DefaultValue(true)]
		[Category("Behavior")]
		[Description("A value indicating whether the dialog box displays a warning if the user specifies a path that does not exist.")]
		public bool CheckPathExists
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[DefaultValue(null)]
		[Description("The default file name extension.")]
		[Category("Behavior")]
		public string DefaultExt
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Description("A value indicating whether the dialog box returns the location of the file referenced by the shortcut or whether it returns the location of the shortcut (.lnk).")]
		[DefaultValue(true)]
		[Category("Behavior")]
		public bool DereferenceLinks
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Description("A string containing the file name selected in the file dialog box.")]
		[Category("Data")]
		[DefaultValue(null)]
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[Description("The file names of all selected files in the dialog box.")]
		public string[] FileNames => null;

		[DefaultValue(null)]
		[Localizable(true)]
		[Category("Behavior")]
		[Description("The current file name filter string, which determines the choices that appear in the \"Save as file type\" or \"Files of type\" box in the dialog box.")]
		public string Filter
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
		[DefaultValue(1)]
		[Description("The index of the filter currently selected in the file dialog box.")]
		public int FilterIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Category("Data")]
		[Description("The initial directory displayed by the file dialog box.")]
		[DefaultValue(null)]
		public string InitialDirectory
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
		[Description("A value indicating whether the dialog box restores the current directory before closing.")]
		[DefaultValue(false)]
		public bool RestoreDirectory
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
		[DefaultValue(false)]
		[Description("A value indicating whether the Help button is displayed in the file dialog box.")]
		public bool ShowHelp
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Category("Appearance")]
		[Description("The file dialog box title.")]
		[Localizable(true)]
		[DefaultValue(null)]
		public string Title
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Description("Indicates whether the dialog box supports displaying and saving files that have multiple file name extensions.")]
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool SupportMultiDottedExtensions
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
		[Description("A value indicating whether the dialog box accepts only valid Win32 file names.")]
		[DefaultValue(true)]
		public bool ValidateNames
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Browsable(false)]
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

		public event CancelEventHandler FileOk
		{
			add
			{
			}
			remove
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
