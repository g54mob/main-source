using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Control : FrameworkElement
	{
		public static DependencyProperty BackgroundProperty => null;

		public static DependencyProperty BorderBrushProperty => null;

		public static DependencyProperty BorderThicknessProperty => null;

		public static DependencyProperty FontFamilyProperty => null;

		public static DependencyProperty FontSizeProperty => null;

		public static DependencyProperty FontStretchProperty => null;

		public static DependencyProperty FontStyleProperty => null;

		public static DependencyProperty FontWeightProperty => null;

		public static DependencyProperty ForegroundProperty => null;

		public static DependencyProperty HorizontalContentAlignmentProperty => null;

		public static DependencyProperty IsTabStopProperty => null;

		public static DependencyProperty PaddingProperty => null;

		public static DependencyProperty TabIndexProperty => null;

		public static DependencyProperty TemplateProperty => null;

		public static DependencyProperty VerticalContentAlignmentProperty => null;

		public static DependencyProperty IsFocusEngagedProperty => null;

		public static DependencyProperty IsFocusEngagementEnabledProperty => null;

		public static RoutedEvent MouseDoubleClickEvent => null;

		public static RoutedEvent PreviewMouseDoubleClickEvent => null;

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

		public Brush BorderBrush
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Thickness BorderThickness
		{
			get
			{
				return default(Thickness);
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

		public HorizontalAlignment HorizontalContentAlignment
		{
			get
			{
				return default(HorizontalAlignment);
			}
			set
			{
			}
		}

		public bool IsTabStop
		{
			get
			{
				return false;
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

		public int TabIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ControlTemplate Template
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public VerticalAlignment VerticalContentAlignment
		{
			get
			{
				return default(VerticalAlignment);
			}
			set
			{
			}
		}

		public bool IsFocusEngaged
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsFocusEngagementEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event MouseButtonEventHandler MouseDoubleClick
		{
			add
			{
			}
			remove
			{
			}
		}

		public event MouseButtonEventHandler PreviewMouseDoubleClick
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static Control CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Control(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Control obj)
		{
			return default(HandleRef);
		}

		public Control()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
