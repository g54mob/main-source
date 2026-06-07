using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class UIElement : Visual
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RenderBaseCallback(HandleRef cPtr, HandleRef context);

		internal RenderBaseCallback OnRenderBase;

		public static DependencyProperty AllowDropProperty => null;

		public static DependencyProperty ClipProperty => null;

		public static DependencyProperty ClipToBoundsProperty => null;

		public static DependencyProperty EffectProperty => null;

		public static DependencyProperty FocusableProperty => null;

		public static DependencyProperty IsEnabledProperty => null;

		public static DependencyProperty IsFocusedProperty => null;

		public static DependencyProperty IsHitTestVisibleProperty => null;

		public static DependencyProperty IsKeyboardFocusedProperty => null;

		public static DependencyProperty IsKeyboardFocusWithinProperty => null;

		public static DependencyProperty IsMouseCapturedProperty => null;

		public static DependencyProperty IsMouseCaptureWithinProperty => null;

		public static DependencyProperty IsMouseDirectlyOverProperty => null;

		public static DependencyProperty IsMouseOverProperty => null;

		public static DependencyProperty IsManipulationEnabledProperty => null;

		public static DependencyProperty IsTapEnabledProperty => null;

		public static DependencyProperty IsDoubleTapEnabledProperty => null;

		public static DependencyProperty IsHoldingEnabledProperty => null;

		public static DependencyProperty IsRightTapEnabledProperty => null;

		public static DependencyProperty IsVisibleProperty => null;

		public static DependencyProperty OpacityMaskProperty => null;

		public static DependencyProperty OpacityProperty => null;

		public static DependencyProperty RenderTransformOriginProperty => null;

		public static DependencyProperty RenderTransformProperty => null;

		public static DependencyProperty Transform3DProperty => null;

		public static DependencyProperty VisibilityProperty => null;

		public static RoutedEvent GotFocusEvent => null;

		public static RoutedEvent GotKeyboardFocusEvent => null;

		public static RoutedEvent GotMouseCaptureEvent => null;

		public static RoutedEvent KeyDownEvent => null;

		public static RoutedEvent KeyUpEvent => null;

		public static RoutedEvent LostFocusEvent => null;

		public static RoutedEvent LostKeyboardFocusEvent => null;

		public static RoutedEvent LostMouseCaptureEvent => null;

		public static RoutedEvent MouseDownEvent => null;

		public static RoutedEvent MouseEnterEvent => null;

		public static RoutedEvent MouseLeaveEvent => null;

		public static RoutedEvent MouseLeftButtonDownEvent => null;

		public static RoutedEvent MouseLeftButtonUpEvent => null;

		public static RoutedEvent MouseMoveEvent => null;

		public static RoutedEvent MouseRightButtonDownEvent => null;

		public static RoutedEvent MouseRightButtonUpEvent => null;

		public static RoutedEvent MouseUpEvent => null;

		public static RoutedEvent MouseWheelEvent => null;

		public static RoutedEvent TouchDownEvent => null;

		public static RoutedEvent TouchMoveEvent => null;

		public static RoutedEvent TouchUpEvent => null;

		public static RoutedEvent TouchEnterEvent => null;

		public static RoutedEvent TouchLeaveEvent => null;

		public static RoutedEvent GotTouchCaptureEvent => null;

		public static RoutedEvent LostTouchCaptureEvent => null;

		public static RoutedEvent PreviewTouchDownEvent => null;

		public static RoutedEvent PreviewTouchMoveEvent => null;

		public static RoutedEvent PreviewTouchUpEvent => null;

		public static RoutedEvent ManipulationStartingEvent => null;

		public static RoutedEvent ManipulationStartedEvent => null;

		public static RoutedEvent ManipulationDeltaEvent => null;

		public static RoutedEvent ManipulationInertiaStartingEvent => null;

		public static RoutedEvent ManipulationCompletedEvent => null;

		public static RoutedEvent TappedEvent => null;

		public static RoutedEvent DoubleTappedEvent => null;

		public static RoutedEvent HoldingEvent => null;

		public static RoutedEvent RightTappedEvent => null;

		public static RoutedEvent PreviewGotKeyboardFocusEvent => null;

		public static RoutedEvent PreviewKeyDownEvent => null;

		public static RoutedEvent PreviewKeyUpEvent => null;

		public static RoutedEvent PreviewLostKeyboardFocusEvent => null;

		public static RoutedEvent PreviewMouseDownEvent => null;

		public static RoutedEvent PreviewMouseLeftButtonDownEvent => null;

		public static RoutedEvent PreviewMouseLeftButtonUpEvent => null;

		public static RoutedEvent PreviewMouseMoveEvent => null;

		public static RoutedEvent PreviewMouseRightButtonDownEvent => null;

		public static RoutedEvent PreviewMouseRightButtonUpEvent => null;

		public static RoutedEvent PreviewMouseUpEvent => null;

		public static RoutedEvent PreviewMouseWheelEvent => null;

		public static RoutedEvent PreviewTextInputEvent => null;

		public static RoutedEvent QueryCursorEvent => null;

		public static RoutedEvent TextInputEvent => null;

		public static RoutedEvent PreviewQueryContinueDragEvent => null;

		public static RoutedEvent QueryContinueDragEvent => null;

		public static RoutedEvent PreviewGiveFeedbackEvent => null;

		public static RoutedEvent GiveFeedbackEvent => null;

		public static RoutedEvent PreviewDragEnterEvent => null;

		public static RoutedEvent DragEnterEvent => null;

		public static RoutedEvent PreviewDragOverEvent => null;

		public static RoutedEvent DragOverEvent => null;

		public static RoutedEvent PreviewDragLeaveEvent => null;

		public static RoutedEvent DragLeaveEvent => null;

		public static RoutedEvent PreviewDropEvent => null;

		public static RoutedEvent DropEvent => null;

		public bool AllowDrop
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Geometry Clip
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool ClipToBounds
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Effect Effect
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool Focusable
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsFocused => false;

		public bool IsHitTestVisible
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsKeyboardFocused => false;

		public bool IsKeyboardFocusWithin => false;

		public bool IsMouseCaptured => false;

		public bool IsMouseCaptureWithin => false;

		public bool IsMouseDirectlyOver => false;

		public bool IsMouseOver => false;

		public bool IsManipulationEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsTapEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsDoubleTapEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsHoldingEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsRightTapEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsVisible => false;

		public Brush OpacityMask
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float Opacity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Point RenderTransformOrigin
		{
			get
			{
				return default(Point);
			}
			set
			{
			}
		}

		public Transform RenderTransform
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Transform3D Transform3D
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Visibility Visibility
		{
			get
			{
				return default(Visibility);
			}
			set
			{
			}
		}

		public CommandBindingCollection CommandBindings => null;

		public InputBindingCollection InputBindings => null;

		public Size DesiredSize => default(Size);

		public Size RenderSize => default(Size);

		public Mouse Mouse => null;

		public Keyboard Keyboard => null;

		public event RoutedEventHandler GotFocus
		{
			add
			{
			}
			remove
			{
			}
		}

		public event RoutedEventHandler LostFocus
		{
			add
			{
			}
			remove
			{
			}
		}

		public event MouseEventHandler GotMouseCapture
		{
			add
			{
			}
			remove
			{
			}
		}

		public event MouseEventHandler LostMouseCapture
		{
			add
			{
			}
			remove
			{
			}
		}

		public event MouseEventHandler MouseEnter
		{
			add
			{
			}
			remove
			{
			}
		}

		public event MouseEventHandler MouseLeave
		{
			add
			{
			}
			remove
			{
			}
		}

		public event MouseEventHandler PreviewMouseMove
		{
			add
			{
			}
			remove
			{
			}
		}

		public event MouseEventHandler MouseMove
		{
			add
			{
			}
			remove
			{
			}
		}

		public event MouseButtonEventHandler PreviewMouseDown
		{
			add
			{
			}
			remove
			{
			}
		}

		public event MouseButtonEventHandler MouseDown
		{
			add
			{
			}
			remove
			{
			}
		}

		public event MouseButtonEventHandler PreviewMouseUp
		{
			add
			{
			}
			remove
			{
			}
		}

		public event MouseButtonEventHandler MouseUp
		{
			add
			{
			}
			remove
			{
			}
		}

		public event MouseButtonEventHandler PreviewMouseLeftButtonDown
		{
			add
			{
			}
			remove
			{
			}
		}

		public event MouseButtonEventHandler MouseLeftButtonDown
		{
			add
			{
			}
			remove
			{
			}
		}

		public event MouseButtonEventHandler PreviewMouseLeftButtonUp
		{
			add
			{
			}
			remove
			{
			}
		}

		public event MouseButtonEventHandler MouseLeftButtonUp
		{
			add
			{
			}
			remove
			{
			}
		}

		public event MouseButtonEventHandler PreviewMouseRightButtonDown
		{
			add
			{
			}
			remove
			{
			}
		}

		public event MouseButtonEventHandler MouseRightButtonDown
		{
			add
			{
			}
			remove
			{
			}
		}

		public event MouseButtonEventHandler PreviewMouseRightButtonUp
		{
			add
			{
			}
			remove
			{
			}
		}

		public event MouseButtonEventHandler MouseRightButtonUp
		{
			add
			{
			}
			remove
			{
			}
		}

		public event MouseWheelEventHandler PreviewMouseWheel
		{
			add
			{
			}
			remove
			{
			}
		}

		public event MouseWheelEventHandler MouseWheel
		{
			add
			{
			}
			remove
			{
			}
		}

		public event QueryCursorEventHandler QueryCursor
		{
			add
			{
			}
			remove
			{
			}
		}

		public event KeyboardFocusChangedEventHandler PreviewGotKeyboardFocus
		{
			add
			{
			}
			remove
			{
			}
		}

		public event KeyboardFocusChangedEventHandler GotKeyboardFocus
		{
			add
			{
			}
			remove
			{
			}
		}

		public event KeyboardFocusChangedEventHandler PreviewLostKeyboardFocus
		{
			add
			{
			}
			remove
			{
			}
		}

		public event KeyboardFocusChangedEventHandler LostKeyboardFocus
		{
			add
			{
			}
			remove
			{
			}
		}

		public event KeyEventHandler PreviewKeyDown
		{
			add
			{
			}
			remove
			{
			}
		}

		public event KeyEventHandler KeyDown
		{
			add
			{
			}
			remove
			{
			}
		}

		public event KeyEventHandler PreviewKeyUp
		{
			add
			{
			}
			remove
			{
			}
		}

		public event KeyEventHandler KeyUp
		{
			add
			{
			}
			remove
			{
			}
		}

		public event TextCompositionEventHandler PreviewTextInput
		{
			add
			{
			}
			remove
			{
			}
		}

		public event TextCompositionEventHandler TextInput
		{
			add
			{
			}
			remove
			{
			}
		}

		public event TouchEventHandler GotTouchCapture
		{
			add
			{
			}
			remove
			{
			}
		}

		public event TouchEventHandler LostTouchCapture
		{
			add
			{
			}
			remove
			{
			}
		}

		public event TouchEventHandler PreviewTouchMove
		{
			add
			{
			}
			remove
			{
			}
		}

		public event TouchEventHandler TouchMove
		{
			add
			{
			}
			remove
			{
			}
		}

		public event TouchEventHandler TouchEnter
		{
			add
			{
			}
			remove
			{
			}
		}

		public event TouchEventHandler TouchLeave
		{
			add
			{
			}
			remove
			{
			}
		}

		public event TouchEventHandler PreviewTouchDown
		{
			add
			{
			}
			remove
			{
			}
		}

		public event TouchEventHandler TouchDown
		{
			add
			{
			}
			remove
			{
			}
		}

		public event TouchEventHandler PreviewTouchUp
		{
			add
			{
			}
			remove
			{
			}
		}

		public event TouchEventHandler TouchUp
		{
			add
			{
			}
			remove
			{
			}
		}

		public event TappedEventHandler Tapped
		{
			add
			{
			}
			remove
			{
			}
		}

		public event DoubleTappedEventHandler DoubleTapped
		{
			add
			{
			}
			remove
			{
			}
		}

		public event HoldingEventHandler Holding
		{
			add
			{
			}
			remove
			{
			}
		}

		public event RightTappedEventHandler RightTapped
		{
			add
			{
			}
			remove
			{
			}
		}

		public event ManipulationStartingEventHandler ManipulationStarting
		{
			add
			{
			}
			remove
			{
			}
		}

		public event ManipulationStartedEventHandler ManipulationStarted
		{
			add
			{
			}
			remove
			{
			}
		}

		public event ManipulationDeltaEventHandler ManipulationDelta
		{
			add
			{
			}
			remove
			{
			}
		}

		public event ManipulationInertiaStartingEventHandler ManipulationInertiaStarting
		{
			add
			{
			}
			remove
			{
			}
		}

		public event ManipulationCompletedEventHandler ManipulationCompleted
		{
			add
			{
			}
			remove
			{
			}
		}

		public event QueryContinueDragEventHandler PreviewQueryContinueDrag
		{
			add
			{
			}
			remove
			{
			}
		}

		public event QueryContinueDragEventHandler QueryContinueDrag
		{
			add
			{
			}
			remove
			{
			}
		}

		public event GiveFeedbackEventHandler PreviewGiveFeedback
		{
			add
			{
			}
			remove
			{
			}
		}

		public event GiveFeedbackEventHandler GiveFeedback
		{
			add
			{
			}
			remove
			{
			}
		}

		public event DragEventHandler PreviewDragOver
		{
			add
			{
			}
			remove
			{
			}
		}

		public event DragEventHandler DragOver
		{
			add
			{
			}
			remove
			{
			}
		}

		public event DragEventHandler PreviewDragEnter
		{
			add
			{
			}
			remove
			{
			}
		}

		public event DragEventHandler DragEnter
		{
			add
			{
			}
			remove
			{
			}
		}

		public event DragEventHandler PreviewDragLeave
		{
			add
			{
			}
			remove
			{
			}
		}

		public event DragEventHandler DragLeave
		{
			add
			{
			}
			remove
			{
			}
		}

		public event DragEventHandler PreviewDrop
		{
			add
			{
			}
			remove
			{
			}
		}

		public event DragEventHandler Drop
		{
			add
			{
			}
			remove
			{
			}
		}

		public event DependencyPropertyChangedEventHandler FocusableChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		public event DependencyPropertyChangedEventHandler IsEnabledChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		public event DependencyPropertyChangedEventHandler IsHitTestVisibleChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		public event DependencyPropertyChangedEventHandler IsVisibleChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		public event DependencyPropertyChangedEventHandler IsMouseCapturedChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		public event DependencyPropertyChangedEventHandler IsMouseCaptureWithinChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		public event DependencyPropertyChangedEventHandler IsMouseDirectlyOverChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		public event DependencyPropertyChangedEventHandler IsKeyboardFocusedChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		public event DependencyPropertyChangedEventHandler IsKeyboardFocusWithinChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static UIElement CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal UIElement(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(UIElement obj)
		{
			return default(HandleRef);
		}

		public void AddHandler(RoutedEvent routedEvent, Delegate handler)
		{
		}

		protected void AddHandler(IntPtr routedEventPtr, Delegate handler)
		{
		}

		public void RemoveHandler(RoutedEvent routedEvent, Delegate handler)
		{
		}

		protected void RemoveHandler(IntPtr routedEventPtr, Delegate handler)
		{
		}

		protected void AddEventHandler(string eventId, Delegate handler)
		{
		}

		protected void RemoveEventHandler(string eventId, Delegate handler)
		{
		}

		public void BeginAnimation(DependencyProperty dp, AnimationTimeline animation)
		{
		}

		public void BeginAnimation(DependencyProperty dp, AnimationTimeline animation, HandoffBehavior handoffBehavior)
		{
		}

		protected internal virtual void OnRender(DrawingContext context)
		{
		}

		public Point TranslatePoint(Point point, UIElement relativeTo)
		{
			return default(Point);
		}

		public bool CaptureTouch(TouchDevice touchDevice)
		{
			return false;
		}

		public bool ReleaseTouchCapture(TouchDevice touchDevice)
		{
			return false;
		}

		public UIElement()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public bool CaptureMouse()
		{
			return false;
		}

		public void ReleaseMouseCapture()
		{
		}

		private bool CaptureTouch(ulong touchDevice)
		{
			return false;
		}

		private bool ReleaseTouchCapture(ulong touchDevice)
		{
			return false;
		}

		public void ReleaseAllTouchCaptures()
		{
		}

		public UIElement GetTouchCaptured(ulong touchDevice)
		{
			return null;
		}

		public bool Focus()
		{
			return false;
		}

		public bool Focus(bool engage)
		{
			return false;
		}

		public void InvalidateMeasure()
		{
		}

		public bool IsMeasureValid()
		{
			return false;
		}

		public void Measure(Size availableSize)
		{
		}

		public void InvalidateArrange()
		{
		}

		public bool IsArrangeValid()
		{
			return false;
		}

		public void Arrange(Rect finalRect)
		{
		}

		public void InvalidateVisual()
		{
		}

		public void UpdateLayout()
		{
		}

		public virtual bool MoveFocus(TraversalRequest request)
		{
			return false;
		}

		public virtual DependencyObject PredictFocus(FocusNavigationDirection direction)
		{
			return null;
		}

		public void RaiseEvent(RoutedEventArgs e)
		{
		}

		protected void IgnoreLayout(bool ignore)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
