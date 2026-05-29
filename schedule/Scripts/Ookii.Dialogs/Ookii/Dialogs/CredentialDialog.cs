using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Ookii.Dialogs
{
	[DefaultProperty("MainInstruction")]
	[DefaultEvent("UserNameChanged")]
	[Description("Allows access to credential UI for generic credentials.")]
	public class CredentialDialog : Component
	{
		private string _confirmTarget;

		private NetworkCredential _credentials;

		private bool _isSaveChecked;

		private string _target;

		private static readonly Dictionary<string, NetworkCredential> _applicationInstanceCredentialCache;

		private string _caption;

		private string _text;

		private string _windowTitle;

		private IContainer components;

		[Category("Behavior")]
		[Description("Indicates whether to use the application instance credential cache.")]
		[DefaultValue(false)]
		public bool UseApplicationInstanceCredentialCache { get; set; }

		[DefaultValue(false)]
		[Description("Indicates whether the \"Save password\" checkbox is checked.")]
		[Category("Appearance")]
		public bool IsSaveChecked
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
		public string Password
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		[Browsable(false)]
		public NetworkCredential Credentials => null;

		[Browsable(false)]
		public string UserName
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		[Description("The target for the credentials, typically the server name prefixed by an application-specific identifier.")]
		[Category("Behavior")]
		[DefaultValue(null)]
		public string Target
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Description("The title of the credentials dialog.")]
		[Category("Appearance")]
		[Localizable(true)]
		[DefaultValue(null)]
		public string WindowTitle
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Localizable(true)]
		[Description("A brief message that will be displayed in the dialog box.")]
		[DefaultValue(null)]
		[Category("Appearance")]
		public string MainInstruction
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Category("Appearance")]
		[Localizable(true)]
		[Description("Additional text to display in the dialog.")]
		[Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		[DefaultValue(null)]
		public string Content
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Localizable(true)]
		[DefaultValue(DownlevelTextMode.MainInstructionAndContent)]
		[Description("Indicates how the text of the MainInstruction and Content properties is displayed on Windows XP.")]
		[Category("Appearance")]
		public DownlevelTextMode DownlevelTextMode { get; set; }

		[Category("Appearance")]
		[Description("Indicates whether a check box is shown on the dialog that allows the user to choose whether to save the credentials or not.")]
		[DefaultValue(false)]
		public bool ShowSaveCheckBox { get; set; }

		[Category("Behavior")]
		[Description("Indicates whether the dialog should be displayed even when saved credentials exist for the specified target.")]
		[DefaultValue(false)]
		public bool ShowUIForSavedCredentials { get; set; }

		public bool IsStoredCredential { get; private set; }

		[Category("Property Changed")]
		[Description("Event raised when the value of the UserName property changes.")]
		public event EventHandler UserNameChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[Description("Event raised when the value of the Password property changes.")]
		[Category("Property Changed")]
		public event EventHandler PasswordChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public CredentialDialog()
		{
		}

		public CredentialDialog(IContainer container)
		{
		}

		public DialogResult ShowDialog()
		{
			return default(DialogResult);
		}

		public DialogResult ShowDialog(IWin32Window owner)
		{
			return default(DialogResult);
		}

		public void ConfirmCredentials(bool confirm)
		{
		}

		public static void StoreCredential(string target, NetworkCredential credential)
		{
		}

		public static NetworkCredential RetrieveCredential(string target)
		{
			return null;
		}

		public static NetworkCredential RetrieveCredentialFromApplicationInstanceCache(string target)
		{
			return null;
		}

		public static bool DeleteCredential(string target)
		{
			return false;
		}

		protected virtual void OnUserNameChanged(EventArgs e)
		{
		}

		protected virtual void OnPasswordChanged(EventArgs e)
		{
		}

		private bool PromptForCredentialsCredUI(IntPtr owner, bool storedCredentials)
		{
			return false;
		}

		private bool PromptForCredentialsCredUIWin(IntPtr owner, bool storedCredentials)
		{
			return false;
		}

		private NativeMethods.CREDUI_INFO CreateCredUIInfo(IntPtr owner, bool downlevelText)
		{
			return default(NativeMethods.CREDUI_INFO);
		}

		private bool RetrieveCredentials()
		{
			return false;
		}

		private static byte[] EncryptPassword(string password)
		{
			return null;
		}

		private static string DecryptPassword(byte[] encrypted)
		{
			return null;
		}

		private bool RetrieveCredentialsFromApplicationInstanceCache()
		{
			return false;
		}

		protected override void Dispose(bool disposing)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
