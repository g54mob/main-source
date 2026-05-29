using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Ookii.Dialogs
{
	[DefaultProperty("MainInstruction")]
	[DefaultEvent("ButtonClicked")]
	[Description("A dialog that allows the user to input a single text value.")]
	public class InputDialog : Component, IBindableComponent, IComponent, IDisposable
	{
		private string _mainInstruction;

		private string _content;

		private string _windowTitle;

		private string _input;

		private int _maxLength;

		private bool _usePasswordMasking;

		private BindingContext _context;

		private ControlBindingsCollection _bindings;

		private IContainer components;

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

		[Category("Appearance")]
		[Localizable(true)]
		[Description("The dialog's primary content.")]
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
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("The window title of the task dialog.")]
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

		[DefaultValue(null)]
		[Description("The text specified by the user.")]
		[Category("Appearance")]
		[Localizable(true)]
		public string Input
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Description("The maximum number of characters that can be entered into the input field of the dialog.")]
		[Category("Behavior")]
		[Localizable(true)]
		[DefaultValue(32767)]
		public int MaxLength
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[DefaultValue(false)]
		[Description("Indicates whether the input will be masked using the system password character.")]
		[Category("Behavior")]
		public bool UsePasswordMasking
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public BindingContext BindingContext
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Data")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[ParenthesizePropertyName(true)]
		public ControlBindingsCollection DataBindings => null;

		[Description("Event raised when the value of the Input property changes.")]
		[Category("Property Changed")]
		public event EventHandler InputChanged
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

		[Description("Event raised when the user clicks the OK button on the dialog.")]
		[Category("Action")]
		public event EventHandler<OkButtonClickedEventArgs> OkButtonClicked
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

		public InputDialog()
		{
		}

		public InputDialog(IContainer container)
		{
		}

		protected virtual void OnInputChanged(EventArgs e)
		{
		}

		protected virtual void OnOkButtonClicked(OkButtonClickedEventArgs e)
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

		private void InputBoxForm_OkButtonClicked(object sender, OkButtonClickedEventArgs e)
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
