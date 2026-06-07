using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TextBlock : FrameworkElement
	{
		public static DependencyProperty BackgroundProperty => null;

		public static DependencyProperty CharacterSpacingProperty => null;

		public static DependencyProperty FontFamilyProperty => null;

		public static DependencyProperty FontSizeProperty => null;

		public static DependencyProperty FontStretchProperty => null;

		public static DependencyProperty FontStyleProperty => null;

		public static DependencyProperty FontWeightProperty => null;

		public static DependencyProperty ForegroundProperty => null;

		public static DependencyProperty LineHeightProperty => null;

		public static DependencyProperty LineStackingStrategyProperty => null;

		public static DependencyProperty PaddingProperty => null;

		public static DependencyProperty StrokeProperty => null;

		public static DependencyProperty StrokeThicknessProperty => null;

		public static DependencyProperty TextAlignmentProperty => null;

		public static DependencyProperty TextDecorationsProperty => null;

		public static DependencyProperty TextProperty => null;

		public static DependencyProperty TextTrimmingProperty => null;

		public static DependencyProperty TextWrappingProperty => null;

		public Brush Background
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int CharacterSpacing
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public FontFamily FontFamily
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float FontSize
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public FontStretch FontStretch
		{
			get
			{
				return default(FontStretch);
			}
			set
			{
			}
		}

		public FontStyle FontStyle
		{
			get
			{
				return default(FontStyle);
			}
			set
			{
			}
		}

		public FontWeight FontWeight
		{
			get
			{
				return default(FontWeight);
			}
			set
			{
			}
		}

		public Brush Foreground
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public InlineCollection Inlines => null;

		public float LineHeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public LineStackingStrategy LineStackingStrategy
		{
			get
			{
				return default(LineStackingStrategy);
			}
			set
			{
			}
		}

		public Thickness Padding
		{
			get
			{
				return default(Thickness);
			}
			set
			{
			}
		}

		public Brush Stroke
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float StrokeThickness
		{
			get
			{
				return 0f;
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

		public TextDecorations TextDecorations
		{
			get
			{
				return default(TextDecorations);
			}
			set
			{
			}
		}

		public TextTrimming TextTrimming
		{
			get
			{
				return default(TextTrimming);
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

		internal new static TextBlock CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TextBlock(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(TextBlock obj)
		{
			return default(HandleRef);
		}

		public override string ToString()
		{
			return null;
		}

		public TextBlock()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public TextBlock(string text)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		private string ToStringHelper()
		{
			return null;
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
