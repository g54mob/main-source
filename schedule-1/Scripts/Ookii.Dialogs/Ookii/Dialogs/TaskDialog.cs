using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Ookii.Dialogs
{
	[Description("Displays a task dialog.")]
	[DefaultEvent("ButtonClicked")]
	[DefaultProperty("MainInstruction")]
	[Designer(typeof(TaskDialogDesigner))]
	public class TaskDialog : Component, IWin32Window
	{
		private TaskDialogItemCollection<TaskDialogButton> _buttons;

		private TaskDialogItemCollection<TaskDialogRadioButton> _radioButtons;

		private NativeMethods.TASKDIALOGCONFIG _config;

		private TaskDialogIcon _mainIcon;

		private Icon _customMainIcon;

		private Icon _customFooterIcon;

		private TaskDialogIcon _footerIcon;

		private Dictionary<int, TaskDialogButton> _buttonsById;

		private Dictionary<int, TaskDialogRadioButton> _radioButtonsById;

		private IntPtr _handle;

		private int _progressBarMarqueeAnimationSpeed;

		private int _progressBarMinimimum;

		private int _progressBarMaximum;

		private int _progressBarValue;

		private ProgressBarState _progressBarState;

		private int _inEventHandler;

		private bool _updatePending;

		private object _tag;

		private Icon _windowIcon;

		private IContainer components;

		public static bool OSSupportsTaskDialogs => false;

		[Localizable(true)]
		[Category("Appearance")]
		[Description("A list of the buttons on the Task Dialog.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TaskDialogItemCollection<TaskDialogButton> Buttons => null;

		[Localizable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Appearance")]
		[Description("A list of the radio buttons on the Task Dialog.")]
		public TaskDialogItemCollection<TaskDialogRadioButton> RadioButtons => null;

		[DefaultValue(null)]
		[Description("The window title of the task dialog.")]
		[Localizable(true)]
		[Category("Appearance")]
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
		[Category("Appearance")]
		[Description("The dialog's main instruction.")]
		[DefaultValue(null)]
		[Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
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

		[DefaultValue(null)]
		[Localizable(true)]
		[Category("Appearance")]
		[Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		[Description("The dialog's primary content.")]
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

		[Category("Appearance")]
		[Description("The icon to be used in the title bar of the dialog. Used only when the dialog is shown as a modeless dialog.")]
		[DefaultValue(null)]
		[Localizable(true)]
		public Icon WindowIcon
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
		[Category("Appearance")]
		[Description("The icon to display in the task dialog.")]
		[DefaultValue(TaskDialogIcon.Custom)]
		public TaskDialogIcon MainIcon
		{
			get
			{
				return default(TaskDialogIcon);
			}
			set
			{
			}
		}

		[DefaultValue(null)]
		[Description("A custom icon to display in the dialog.")]
		[Localizable(true)]
		[Category("Appearance")]
		public Icon CustomMainIcon
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[DefaultValue(TaskDialogIcon.Custom)]
		[Description("The icon to display in the footer area of the task dialog.")]
		[Category("Appearance")]
		[Localizable(true)]
		public TaskDialogIcon FooterIcon
		{
			get
			{
				return default(TaskDialogIcon);
			}
			set
			{
			}
		}

		[Localizable(true)]
		[Description("A custom icon to display in the footer area of the task dialog.")]
		[DefaultValue(null)]
		[Category("Appearance")]
		public Icon CustomFooterIcon
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
		[Description("Indicates whether custom buttons should be displayed as normal buttons or command links.")]
		[DefaultValue(TaskDialogButtonStyle.Standard)]
		public TaskDialogButtonStyle ButtonStyle
		{
			get
			{
				return default(TaskDialogButtonStyle);
			}
			set
			{
			}
		}

		[Localizable(true)]
		[Category("Appearance")]
		[Description("The label for the verification checkbox.")]
		[DefaultValue(null)]
		public string VerificationText
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
		[Description("Indicates whether the verification checkbox is checked ot not.")]
		[DefaultValue(false)]
		public bool IsVerificationChecked
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
		[Localizable(true)]
		[Description("Additional information to be displayed on the dialog.")]
		[DefaultValue(null)]
		[Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		public string ExpandedInformation
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
		[Description("The text to use for the control for collapsing the expandable information.")]
		[DefaultValue(null)]
		[Localizable(true)]
		public string ExpandedControlText
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
		[Category("Appearance")]
		[Description("The text to use for the control for expanding the expandable information.")]
		[DefaultValue(null)]
		public string CollapsedControlText
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
		[DefaultValue(null)]
		[Description("The text to be used in the footer area of the task dialog.")]
		[Category("Appearance")]
		[Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		public string Footer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[DefaultValue(0)]
		[Description("the width of the task dialog's client area in DLU's. If 0, task dialog will calculate the ideal width.")]
		[Category("Appearance")]
		[Localizable(true)]
		public int Width
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Description("Indicates whether hyperlinks are allowed for the Content, ExpandedInformation and Footer properties.")]
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool EnableHyperlinks
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
		[Description("Indicates that the dialog should be able to be closed using Alt-F4, Escape and the title bar's close button even if no cancel button is specified.")]
		[DefaultValue(false)]
		public bool AllowDialogCancellation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Description("Indicates that the string specified by the ExpandedInformation property should be displayed at the bottom of the dialog's footer area instead of immediately after the dialog's content.")]
		[DefaultValue(false)]
		[Category("Behavior")]
		public bool ExpandFooterArea
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
		[Description("Indicates that the string specified by the ExpandedInformation property should be displayed by default.")]
		[DefaultValue(false)]
		public bool ExpandedByDefault
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
		[Description("Indicates whether the Timer event is raised periodically while the dialog is visible.")]
		[DefaultValue(false)]
		public bool RaiseTimerEvent
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Description("Indicates whether the dialog is centered in the parent window instead of the screen.")]
		[DefaultValue(false)]
		[Category("Layout")]
		public bool CenterParent
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
		[Description("Indicates whether text is displayed right to left.")]
		[DefaultValue(false)]
		[Category("Appearance")]
		public bool RightToLeft
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Description("Indicates whether the dialog has a minimize box on its caption bar.")]
		[DefaultValue(false)]
		[Category("Window Style")]
		public bool MinimizeBox
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Description("The type of progress bar displayed on the dialog.")]
		[DefaultValue(ProgressBarStyle.None)]
		[Category("Behavior")]
		public ProgressBarStyle ProgressBarStyle
		{
			get
			{
				return default(ProgressBarStyle);
			}
			set
			{
			}
		}

		[Category("Behavior")]
		[Description("The marquee animation speed of the progress bar in milliseconds.")]
		[DefaultValue(100)]
		public int ProgressBarMarqueeAnimationSpeed
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Category("Behavior")]
		[Description("The lower bound of the range of the task dialog's progress bar.")]
		[DefaultValue(0)]
		public int ProgressBarMinimum
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Category("Behavior")]
		[DefaultValue(100)]
		[Description("The upper bound of the range of the task dialog's progress bar.")]
		public int ProgressBarMaximum
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[DefaultValue(0)]
		[Description("The current value of the task dialog's progress bar.")]
		[Category("Behavior")]
		public int ProgressBarValue
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[DefaultValue(ProgressBarState.Normal)]
		[Category("Behavior")]
		[Description("The state of the task dialog's progress bar.")]
		public ProgressBarState ProgressBarState
		{
			get
			{
				return default(ProgressBarState);
			}
			set
			{
			}
		}

		[Description("User-defined data about the component.")]
		[Category("Data")]
		[DefaultValue(null)]
		public object Tag
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private bool IsDialogRunning => false;

		[Browsable(false)]
		public IntPtr Handle => (IntPtr)0;

		[Category("Behavior")]
		[Description("Event raised when the task dialog has been created.")]
		public event EventHandler Created
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

		[Category("Behavior")]
		[Description("Event raised when the task dialog has been destroyed.")]
		public event EventHandler Destroyed
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

		[Description("Event raised when the user clicks a button.")]
		[Category("Action")]
		public event EventHandler<TaskDialogItemClickedEventArgs> ButtonClicked
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

		[Category("Action")]
		[Description("Event raised when the user clicks a button.")]
		public event EventHandler<TaskDialogItemClickedEventArgs> RadioButtonClicked
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

		[Category("Action")]
		[Description("Event raised when the user clicks a hyperlink.")]
		public event EventHandler<HyperlinkClickedEventArgs> HyperlinkClicked
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

		[Category("Action")]
		[Description("Event raised when the user clicks the verification check box.")]
		public event EventHandler VerificationClicked
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

		[Description("Event raised periodically while the dialog is displayed.")]
		[Category("Behavior")]
		public event EventHandler<TimerEventArgs> Timer
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

		[Category("Action")]
		[Description("Event raised when the user clicks the expand button on the task dialog.")]
		public event EventHandler<ExpandButtonClickedEventArgs> ExpandButtonClicked
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

		[Category("Action")]
		[Description("Event raised when the user presses F1 while the dialog has focus.")]
		public event EventHandler HelpRequested
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

		public TaskDialog()
		{
		}

		public TaskDialog(IContainer container)
		{
		}

		public TaskDialogButton Show()
		{
			return null;
		}

		public TaskDialogButton ShowDialog()
		{
			return null;
		}

		public TaskDialogButton ShowDialog(IWin32Window owner)
		{
			return null;
		}

		public void ClickVerification(bool checkState, bool setFocus)
		{
		}

		protected virtual void OnHyperlinkClicked(HyperlinkClickedEventArgs e)
		{
		}

		protected virtual void OnButtonClicked(TaskDialogItemClickedEventArgs e)
		{
		}

		protected virtual void OnRadioButtonClicked(TaskDialogItemClickedEventArgs e)
		{
		}

		protected virtual void OnVerificationClicked(EventArgs e)
		{
		}

		protected virtual void OnCreated(EventArgs e)
		{
		}

		protected virtual void OnTimer(TimerEventArgs e)
		{
		}

		protected virtual void OnDestroyed(EventArgs e)
		{
		}

		protected virtual void OnExpandButtonClicked(ExpandButtonClickedEventArgs e)
		{
		}

		protected virtual void OnHelpRequested(EventArgs e)
		{
		}

		internal void SetItemEnabled(TaskDialogItem item)
		{
		}

		internal void SetButtonElevationRequired(TaskDialogButton button)
		{
		}

		internal void ClickItem(TaskDialogItem item)
		{
		}

		private TaskDialogButton ShowDialog(IntPtr owner)
		{
			return null;
		}

		internal void UpdateDialog()
		{
		}

		private void SetElementText(NativeMethods.TaskDialogElements element, string text)
		{
		}

		private void SetupIcon()
		{
		}

		private void SetupIcon(TaskDialogIcon icon, Icon customIcon, NativeMethods.TaskDialogFlags flag)
		{
		}

		private static void CleanUpButtons(ref IntPtr buttons, ref uint count)
		{
		}

		private static void MarshalButtons(List<NativeMethods.TASKDIALOG_BUTTON> buttons, out IntPtr buttonsPtr, out uint count)
		{
			buttonsPtr = default(IntPtr);
			count = default(uint);
		}

		private List<NativeMethods.TASKDIALOG_BUTTON> SetupButtons()
		{
			return null;
		}

		private List<NativeMethods.TASKDIALOG_BUTTON> SetupRadioButtons()
		{
			return null;
		}

		private void SetFlag(NativeMethods.TaskDialogFlags flag, bool value)
		{
		}

		private bool GetFlag(NativeMethods.TaskDialogFlags flag)
		{
			return false;
		}

		private uint TaskDialogCallback(IntPtr hwnd, uint uNotification, IntPtr wParam, IntPtr lParam, IntPtr dwRefData)
		{
			return 0u;
		}

		private void DialogCreated()
		{
		}

		private void UpdateProgressBarStyle()
		{
		}

		private void UpdateProgressBarMarqueeSpeed()
		{
		}

		private void UpdateProgressBarRange()
		{
		}

		private void UpdateProgressBarValue()
		{
		}

		private void UpdateProgressBarState()
		{
		}

		private void CheckCrossThreadCall()
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
