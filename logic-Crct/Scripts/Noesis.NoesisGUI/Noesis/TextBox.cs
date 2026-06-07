using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TextBox : TextBoxBase
	{
		public static DependencyProperty MaxLengthProperty => null;

		public static DependencyProperty MaxLinesProperty => null;

		public static DependencyProperty MinLinesProperty => null;

		public static DependencyProperty PlaceholderProperty => null;

		public static DependencyProperty TextAlignmentProperty => null;

		public static DependencyProperty TextProperty => null;

		public static DependencyProperty TextWrappingProperty => null;

		public int CaretIndex
		{
			get
			{
				return 0;
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

		public int MaxLines
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int MinLines
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public string SelectedText
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int SelectionLength
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int SelectionStart
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public TextAlignment TextAlignment
		{
			get
			{
				return default(TextAlignment);
			}
			set
			{
			}
		}

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

		public TextWrapping TextWrapping
		{
			get
			{
				return default(TextWrapping);
			}
			set
			{
			}
		}

		public Visual TextView => null;

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

		internal new static TextBox CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TextBox(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(TextBox obj)
		{
			return default(HandleRef);
		}

		public TextBox()
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

		public void Select(int start, int length)
		{
		}

		public void Clear()
		{
		}

		public int GetCharacterIndexFromPoint(Point point, bool snapToText)
		{
			return 0;
		}

		public int GetCharacterIndexFromLineIndex(int lineIndex)
		{
			return 0;
		}

		public int GetLineIndexFromCharacterIndex(int charIndex)
		{
			return 0;
		}

		public int GetLineLength(int lineIndex)
		{
			return 0;
		}

		public int GetFirstVisibleLineIndex()
		{
			return 0;
		}

		public int GetLastVisibleLineIndex()
		{
			return 0;
		}

		public void ScrollToLine(int lineIndex)
		{
		}

		public Rect GetRangeBounds(uint start, uint end)
		{
			return default(Rect);
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
