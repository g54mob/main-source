using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class FrameworkElement : UIElement
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void LayoutBaseCallback(HandleRef cPtr, ref Size size, ref Size outSize);

		internal LayoutBaseCallback MeasureBase;

		internal LayoutBaseCallback ArrangeBase;

		public static DependencyProperty ActualHeightProperty => null;

		public static DependencyProperty ActualWidthProperty => null;

		public static DependencyProperty BlendingModeProperty => null;

		public static DependencyProperty ContextMenuProperty => null;

		public static DependencyProperty CursorProperty => null;

		public static DependencyProperty DataContextProperty => null;

		public static DependencyProperty DefaultStyleKeyProperty => null;

		public static DependencyProperty FlowDirectionProperty => null;

		public static DependencyProperty FocusVisualStyleProperty => null;

		public static DependencyProperty ForceCursorProperty => null;

		public static DependencyProperty HeightProperty => null;

		public static DependencyProperty HorizontalAlignmentProperty => null;

		public static DependencyProperty InputScopeProperty => null;

		public static DependencyProperty LayoutTransformProperty => null;

		public static DependencyProperty MarginProperty => null;

		public static DependencyProperty MaxHeightProperty => null;

		public static DependencyProperty MaxWidthProperty => null;

		public static DependencyProperty MinHeightProperty => null;

		public static DependencyProperty MinWidthProperty => null;

		public static DependencyProperty NameProperty => null;

		public static DependencyProperty OverridesDefaultStyleProperty => null;

		public static DependencyProperty PPAAModeProperty => null;

		public static DependencyProperty PPAAInProperty => null;

		public static DependencyProperty PPAAOutProperty => null;

		public static DependencyProperty StyleProperty => null;

		public static DependencyProperty TagProperty => null;

		public static DependencyProperty ToolTipProperty => null;

		public static DependencyProperty UseLayoutRoundingProperty => null;

		public static DependencyProperty VerticalAlignmentProperty => null;

		public static DependencyProperty WidthProperty => null;

		public static RoutedEvent ContextMenuClosingEvent => null;

		public static RoutedEvent ContextMenuOpeningEvent => null;

		public static RoutedEvent LoadedEvent => null;

		public static RoutedEvent ReloadedEvent => null;

		public static RoutedEvent RequestBringIntoViewEvent => null;

		public static RoutedEvent SizeChangedEvent => null;

		public static RoutedEvent ToolTipClosingEvent => null;

		public static RoutedEvent ToolTipOpeningEvent => null;

		public static RoutedEvent UnloadedEvent => null;

		public float ActualHeight => 0f;

		public float ActualWidth => 0f;

		public BlendingMode BlendingMode
		{
			get
			{
				return default(BlendingMode);
			}
			set
			{
			}
		}

		public ContextMenu ContextMenu
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Cursor Cursor
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public object DataContext
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Type DefaultStyleKey
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public FlowDirection FlowDirection
		{
			get
			{
				return default(FlowDirection);
			}
			set
			{
			}
		}

		public Style FocusVisualStyle
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool ForceCursor
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float Height
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public HorizontalAlignment HorizontalAlignment
		{
			get
			{
				return default(HorizontalAlignment);
			}
			set
			{
			}
		}

		public InputScope InputScope
		{
			get
			{
				return default(InputScope);
			}
			set
			{
			}
		}

		public bool IsInitialized => false;

		public bool IsLoaded => false;

		public Transform LayoutTransform
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Thickness Margin
		{
			get
			{
				return default(Thickness);
			}
			set
			{
			}
		}

		public float MaxHeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MaxWidth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MinHeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MinWidth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public string Name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool OverridesDefaultStyle
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public PPAAMode PPAAMode
		{
			get
			{
				return default(PPAAMode);
			}
			set
			{
			}
		}

		public float PPAAIn
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float PPAAOut
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Style Style
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

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

		public object ToolTip
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool UseLayoutRounding
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public VerticalAlignment VerticalAlignment
		{
			get
			{
				return default(VerticalAlignment);
			}
			set
			{
			}
		}

		public float Width
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public TriggerCollection Triggers => null;

		public FrameworkElement Parent => null;

		public FrameworkElement TemplatedParent => null;

		public ResourceDictionary Resources
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public event ContextMenuEventHandler ContextMenuClosing
		{
			add
			{
			}
			remove
			{
			}
		}

		public event ContextMenuEventHandler ContextMenuOpening
		{
			add
			{
			}
			remove
			{
			}
		}

		public event RoutedEventHandler Loaded
		{
			add
			{
			}
			remove
			{
			}
		}

		public event RoutedEventHandler Reloaded
		{
			add
			{
			}
			remove
			{
			}
		}

		public event RequestBringIntoViewEventHandler RequestBringIntoView
		{
			add
			{
			}
			remove
			{
			}
		}

		public event SizeChangedEventHandler SizeChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		public event ToolTipEventHandler ToolTipClosing
		{
			add
			{
			}
			remove
			{
			}
		}

		public event ToolTipEventHandler ToolTipOpening
		{
			add
			{
			}
			remove
			{
			}
		}

		public event RoutedEventHandler Unloaded
		{
			add
			{
			}
			remove
			{
			}
		}

		public event DependencyPropertyChangedEventHandler DataContextChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		public event EventHandler Initialized
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static FrameworkElement CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal FrameworkElement(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(FrameworkElement obj)
		{
			return default(HandleRef);
		}

		public FrameworkElement()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public static FlowDirection GetFlowDirection(DependencyObject d)
		{
			return default(FlowDirection);
		}

		public static void SetFlowDirection(DependencyObject d, FlowDirection flowDirection)
		{
		}

		public BindingExpression GetBindingExpression(DependencyProperty dp)
		{
			return null;
		}

		public BindingExpressionBase SetBinding(DependencyProperty dp, BindingBase binding)
		{
			return null;
		}

		public BindingExpression SetBinding(DependencyProperty dp, string path)
		{
			return null;
		}

		public void BringIntoView()
		{
		}

		public void BringIntoView(Rect targetRectangle)
		{
		}

		public bool ApplyTemplate()
		{
			return false;
		}

		public object GetTemplateChild(string name)
		{
			return null;
		}

		public object FindName(string name)
		{
			return null;
		}

		public void RegisterName(string name, object arg1)
		{
		}

		public void UnregisterName(string name)
		{
		}

		public void UpdateName(string name, object arg1)
		{
		}

		public sealed override bool MoveFocus(TraversalRequest request)
		{
			return false;
		}

		public sealed override DependencyObject PredictFocus(FocusNavigationDirection direction)
		{
			return null;
		}

		public static FrameworkElement FindTreeElement(object instance)
		{
			return null;
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}

		public object FindResource(object key)
		{
			return null;
		}

		public object TryFindResource(object key)
		{
			return null;
		}

		protected internal virtual Size MeasureOverride(Size availableSize)
		{
			return default(Size);
		}

		protected internal virtual Size ArrangeOverride(Size finalSize)
		{
			return default(Size);
		}

		protected internal virtual bool ConnectEvent(object source, string eventName, string handlerName)
		{
			return false;
		}

		public virtual void OnApplyTemplate()
		{
		}

		private object FindResourceHelper(string key)
		{
			return null;
		}

		[PreserveSig]
		private static extern IntPtr FrameworkElement_FindResourceHelper(HandleRef element, string key);
	}
}
