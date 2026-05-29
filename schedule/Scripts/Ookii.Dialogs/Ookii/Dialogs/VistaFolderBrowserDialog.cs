using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using Ookii.Dialogs.Interop;

namespace Ookii.Dialogs
{
	[Description("Prompts the user to select a folder.")]
	[DefaultProperty("SelectedPath")]
	[Designer("System.Windows.Forms.Design.FolderBrowserDialogDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[DefaultEvent("HelpRequest")]
	public sealed class VistaFolderBrowserDialog : CommonDialog
	{
		private FolderBrowserDialog _downlevelDialog;

		private string _description;

		private bool _useDescriptionForTitle;

		private string _selectedPath;

		private Environment.SpecialFolder _rootFolder;

		private bool _showNewFolderButton;

		[Browsable(false)]
		public static bool IsVistaFolderDialogSupported => false;

		[Category("Folder Browsing")]
		[DefaultValue(null)]
		[Browsable(true)]
		[Description("The descriptive text displayed above the tree view control in the dialog box, or below the list view control in the Vista style dialog.")]
		[Localizable(true)]
		public string Description
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[DefaultValue(typeof(Environment.SpecialFolder), "Desktop")]
		[Browsable(true)]
		[Category("Folder Browsing")]
		[Description("The root folder where the browsing starts from. This property has no effect if the Vista style dialog is used.")]
		[Localizable(false)]
		public Environment.SpecialFolder RootFolder
		{
			get
			{
				return default(Environment.SpecialFolder);
			}
			set
			{
			}
		}

		[Description("The path selected by the user.")]
		[Category("Folder Browsing")]
		[Editor("System.Windows.Forms.Design.SelectedPathEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[Browsable(true)]
		[Localizable(true)]
		[DefaultValue(null)]
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

		[Localizable(false)]
		[Browsable(true)]
		[DefaultValue(true)]
		[Category("Folder Browsing")]
		[Description("A value indicating whether the New Folder button appears in the folder browser dialog box. This property has no effect if the Vista style dialog is used; in that case, the New Folder button is always shown.")]
		public bool ShowNewFolderButton
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Category("Folder Browsing")]
		[DefaultValue(false)]
		[Description("A value that indicates whether to use the value of the Description property as the dialog title for Vista style dialogs. This property has no effect on old style dialogs.")]
		public bool UseDescriptionForTitle
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
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler HelpRequest
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
