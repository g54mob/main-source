using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TextElement : FrameworkElement
	{
		public static DependencyProperty BackgroundProperty => null;

		public static DependencyProperty CharacterSpacingProperty => null;

		public static DependencyProperty FontFamilyProperty => null;

		public static DependencyProperty FontSizeProperty => null;

		public static DependencyProperty FontStretchProperty => null;

		public static DependencyProperty FontStyleProperty => null;

		public static DependencyProperty FontWeightProperty => null;

		public static DependencyProperty ForegroundProperty => null;

		public static DependencyProperty StrokeProperty => null;

		public static DependencyProperty StrokeThicknessProperty => null;

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

		internal new static TextElement CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TextElement(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(TextElement obj)
		{
			return default(HandleRef);
		}

		public static FontFamily GetFontFamily(DependencyObject element)
		{
			return null;
		}

		public static void SetFontFamily(DependencyObject element, FontFamily family)
		{
		}

		public static float GetFontSize(DependencyObject element)
		{
			return 0f;
		}

		public static void SetFontSize(DependencyObject element, float size)
		{
		}

		public static FontStretch GetFontStretch(DependencyObject element)
		{
			return default(FontStretch);
		}

		public static void SetFontStretch(DependencyObject element, FontStretch stretch)
		{
		}

		public static FontStyle GetFontStyle(DependencyObject element)
		{
			return default(FontStyle);
		}

		public static void SetFontStyle(DependencyObject element, FontStyle style)
		{
		}

		public static FontWeight GetFontWeight(DependencyObject element)
		{
			return default(FontWeight);
		}

		public static void SetFontWeight(DependencyObject element, FontWeight weight)
		{
		}

		public static Brush GetForeground(DependencyObject element)
		{
			return null;
		}

		public static void SetForeground(DependencyObject element, Brush foreground)
		{
		}

		public static Brush GetStroke(DependencyObject element)
		{
			return null;
		}

		public static void SetStroke(DependencyObject element, Brush stroke)
		{
		}

		public static float GetStrokeThickness(DependencyObject element)
		{
			return 0f;
		}

		public static void SetStrokeThickness(DependencyObject element, float strokeThickness)
		{
		}

		public TextElement()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
