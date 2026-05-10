using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Ookii.Dialogs.Interop;

namespace Ookii.Dialogs
{
	[DefaultProperty("Text")]
	[DefaultEvent("DoWork")]
	[Description("Represents a dialog that can be used to report progress to the user.")]
	public class ProgressDialog : Component
	{
		private class ProgressChangedData
		{
			public string Text { get; set; }

			public string Description { get; set; }

			public object UserState { get; set; }
		}

		private string _windowTitle;

		private string _text;

		private string _description;

		private IProgressDialog _dialog;

		private string _cancellationText;

		private bool _useCompactPathsForText;

		private bool _useCompactPathsForDescription;

		private SafeModuleHandle _currentAnimationModuleHandle;

		private bool _cancellationPending;

		private IContainer components;

		private BackgroundWorker _backgroundWorker;

		[DefaultValue(null)]
		[Description("The text in the progress dialog's title bar.")]
		[Category("Appearance")]
		[Localizable(true)]
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

		[Description("A short description of the operation being carried out.")]
		[Category("Appearance")]
		[Localizable(true)]
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
		[DefaultValue(false)]
		[Description("Indicates whether path strings in the Text property should be compacted if they are too large to fit on one line.")]
		public bool UseCompactPathsForText
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Localizable(true)]
		[Category("Appearance")]
		[Description("Additional details about the operation being carried out.")]
		[DefaultValue(null)]
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

		[DefaultValue(false)]
		[Description("Indicates whether path strings in the Description property should be compacted if they are too large to fit on one line.")]
		[Category("Behavior")]
		public bool UseCompactPathsForDescription
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
		[Description("The text that will be shown after the Cancel button is pressed.")]
		[Category("Appearance")]
		[Localizable(true)]
		public string CancellationText
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[DefaultValue(false)]
		[Description("Indicates whether an estimate of the remaining time will be shown.")]
		[Category("Appearance")]
		public bool ShowTimeRemaining { get; set; }

		[Description("Indicates whether the dialog has a cancel button. Do not set to false unless absolutely necessary.")]
		[Category("Appearance")]
		[DefaultValue(true)]
		public bool ShowCancelButton { get; set; }

		[Description("Indicates whether the progress dialog has a minimize button.")]
		[Category("Window Style")]
		[DefaultValue(true)]
		public bool MinimizeBox { get; set; }

		[Browsable(false)]
		public bool CancellationPending => false;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public AnimationResource Animation { get; set; }

		[DefaultValue(ProgressBarStyle.ProgressBar)]
		[Description("Indicates the style of the progress bar.")]
		[Category("Appearance")]
		public ProgressBarStyle ProgressBarStyle { get; set; }

		[Browsable(false)]
		public bool IsBusy => false;

		public event DoWorkEventHandler DoWork
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

		public event RunWorkerCompletedEventHandler RunWorkerCompleted
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

		public event ProgressChangedEventHandler ProgressChanged
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

		public ProgressDialog()
		{
		}

		public ProgressDialog(IContainer container)
		{
		}

		public void Show()
		{
		}

		public void Show(object argument)
		{
		}

		public void ShowDialog()
		{
		}

		public void ShowDialog(IWin32Window owner)
		{
		}

		public void ShowDialog(IWin32Window owner, object argument)
		{
		}

		public void ReportProgress(int percentProgress)
		{
		}

		public void ReportProgress(int percentProgress, string text, string description)
		{
		}

		public void ReportProgress(int percentProgress, string text, string description, object userState)
		{
		}

		protected virtual void OnDoWork(DoWorkEventArgs e)
		{
		}

		protected virtual void OnRunWorkerCompleted(RunWorkerCompletedEventArgs e)
		{
		}

		protected virtual void OnProgressChanged(ProgressChangedEventArgs e)
		{
		}

		private void RunProgressDialog(IntPtr owner, object argument)
		{
		}

		private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
		}

		private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
		}

		private void _backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
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
