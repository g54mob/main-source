using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class PasswordBox : Control
	{
		public static DependencyProperty CaretBrushProperty => null;

		public static DependencyProperty MaxLengthProperty => null;

		public static DependencyProperty PasswordCharProperty => null;

		public static DependencyProperty PlaceholderProperty => null;

		public static DependencyProperty SelectionBrushProperty => null;

		public static DependencyProperty SelectionOpacityProperty => null;

		public static RoutedEvent PasswordChangedEvent => null;

		public Brush CaretBrush
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

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

		public char PasswordChar
		{
			get
			{
				return '\0';
			}
			set
			{
			}
		}

		public string Password
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Brush SelectionBrush
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float SelectionOpacity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public string Placeholder
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public event RoutedEventHandler PasswordChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static PasswordBox CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal PasswordBox(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(PasswordBox obj)
		{
			return default(HandleRef);
		}

		public PasswordBox()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public void SelectAll()
		{
		}

		public void HideCaret()
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
