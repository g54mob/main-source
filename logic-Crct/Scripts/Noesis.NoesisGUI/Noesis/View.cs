using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class View : DispatcherObject
	{
		internal delegate void RaiseRenderingCallback(IntPtr cPtr, IntPtr sender);

		private delegate int TimerEventCallback(IntPtr cPtr, int timerId);

		private static RaiseRenderingCallback _raiseRendering;

		internal static Dictionary<long, RenderingEventHandler> _Rendering;

		private static TimerEventCallback _timerEvent;

		private Dictionary<int, TimerCallback> _timers;

		[ThreadStatic]
		private static HandleRef sContentPtr;

		[ThreadStatic]
		private static View sCreatingView;

		public Renderer Renderer => null;

		public FrameworkElement Content => null;

		internal HandleRef CPtr => default(HandleRef);

		public event RenderingEventHandler Rendering
		{
			add
			{
			}
			remove
			{
			}
		}

		public static View Find(BaseComponent node)
		{
			return null;
		}

		public void SetScale(float scale)
		{
		}

		public void SetSize(int width, int height)
		{
		}

		public void SetTessellationMaxPixelError(TessellationMaxPixelError maxError)
		{
		}

		public TessellationMaxPixelError GetTessellationMaxPixelError()
		{
			return default(TessellationMaxPixelError);
		}

		public void SetFlags(RenderFlags flags)
		{
		}

		public RenderFlags GetFlags()
		{
			return default(RenderFlags);
		}

		public void SetHoldingTimeThreshold(uint milliseconds)
		{
		}

		public void SetHoldingDistanceThreshold(uint pixels)
		{
		}

		public void SetDoubleTapTimeThreshold(uint milliseconds)
		{
		}

		public void SetDoubleTapDistanceThreshold(uint pixels)
		{
		}

		public void SetProjectionMatrix(Matrix4 projection)
		{
		}

		public void SetEmulateTouch(bool emulate)
		{
		}

		public void Activate()
		{
		}

		public void Deactivate()
		{
		}

		public bool MouseMove(int x, int y)
		{
			return false;
		}

		public bool MouseButtonDown(int x, int y, MouseButton button)
		{
			return false;
		}

		public bool MouseButtonUp(int x, int y, MouseButton button)
		{
			return false;
		}

		public bool MouseDoubleClick(int x, int y, MouseButton button)
		{
			return false;
		}

		public bool MouseWheel(int x, int y, int wheelRotation)
		{
			return false;
		}

		public bool MouseHWheel(int x, int y, int wheelRotation)
		{
			return false;
		}

		public bool Scroll(float value)
		{
			return false;
		}

		public bool HScroll(float value)
		{
			return false;
		}

		public bool TouchMove(int x, int y, ulong touchId)
		{
			return false;
		}

		public bool TouchDown(int x, int y, ulong touchId)
		{
			return false;
		}

		public bool TouchUp(int x, int y, ulong touchId)
		{
			return false;
		}

		public bool KeyDown(Key key)
		{
			return false;
		}

		public bool KeyUp(Key key)
		{
			return false;
		}

		public bool Char(uint ch)
		{
			return false;
		}

		public bool Update(double timeInSeconds)
		{
			return false;
		}

		[MonoPInvokeCallback(typeof(RaiseRenderingCallback))]
		private static void RaiseRendering(IntPtr cPtr, IntPtr sender)
		{
		}

		public ViewStats GetStats()
		{
			return default(ViewStats);
		}

		public int CreateTimer(int interval, TimerCallback callback)
		{
			return 0;
		}

		public void RestartTimer(int timerId, int interval)
		{
		}

		public void CancelTimer(int timerId)
		{
		}

		[MonoPInvokeCallback(typeof(TimerEventCallback))]
		private static int OnTimerEvent(IntPtr cPtr, int timerId)
		{
			return 0;
		}

		internal View(FrameworkElement content)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal View(IntPtr cPtr, bool ownMemory)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal new static View CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		private View(HandleRef content)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		private static HandleRef RegisterContent(FrameworkElement content)
		{
			return default(HandleRef);
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern IntPtr Noesis_View_Find(HandleRef node);

		[PreserveSig]
		private static extern IntPtr Noesis_View_Create(HandleRef content);

		[PreserveSig]
		private static extern IntPtr Noesis_View_GetContent(HandleRef view);

		[PreserveSig]
		private static extern void Noesis_View_SetScale(HandleRef view, float scale);

		[PreserveSig]
		private static extern void Noesis_View_SetSize(HandleRef view, int width, int height);

		[PreserveSig]
		private static extern void Noesis_View_SetTessellationMaxPixelError(HandleRef view, float maxError);

		[PreserveSig]
		private static extern float Noesis_View_GetTessellationMaxPixelError(HandleRef view);

		[PreserveSig]
		private static extern void Noesis_View_SetFlags(HandleRef view, int flags);

		[PreserveSig]
		private static extern int Noesis_View_GetFlags(HandleRef view);

		[PreserveSig]
		private static extern void Noesis_View_SetHoldingTimeThreshold(HandleRef view, uint milliseconds);

		[PreserveSig]
		private static extern void Noesis_View_SetHoldingDistanceThreshold(HandleRef view, uint pixels);

		[PreserveSig]
		private static extern void Noesis_View_SetDoubleTapTimeThreshold(HandleRef view, uint milliseconds);

		[PreserveSig]
		private static extern void Noesis_View_SetDoubleTapDistanceThreshold(HandleRef view, uint pixels);

		[PreserveSig]
		private static extern void Noesis_View_SetProjectionMatrix(HandleRef view, ref Matrix4 projection);

		[PreserveSig]
		private static extern void Noesis_View_SetEmulateTouch(HandleRef view, bool emulate);

		[PreserveSig]
		private static extern void Noesis_View_Activate(HandleRef view);

		[PreserveSig]
		private static extern void Noesis_View_Deactivate(HandleRef view);

		[PreserveSig]
		private static extern bool Noesis_View_MouseMove(HandleRef view, int x, int y);

		[PreserveSig]
		private static extern bool Noesis_View_MouseButtonDown(HandleRef view, int x, int y, int button);

		[PreserveSig]
		private static extern bool Noesis_View_MouseButtonUp(HandleRef view, int x, int y, int button);

		[PreserveSig]
		private static extern bool Noesis_View_MouseDoubleClick(HandleRef view, int x, int y, int button);

		[PreserveSig]
		private static extern bool Noesis_View_MouseWheel(HandleRef view, int x, int y, int wheelRotation);

		[PreserveSig]
		private static extern bool Noesis_View_MouseHWheel(HandleRef view, int x, int y, int wheelRotation);

		[PreserveSig]
		private static extern bool Noesis_View_Scroll(HandleRef view, float value);

		[PreserveSig]
		private static extern bool Noesis_View_HScroll(HandleRef view, float value);

		[PreserveSig]
		private static extern bool Noesis_View_TouchMove(HandleRef view, int x, int y, ulong touchId);

		[PreserveSig]
		private static extern bool Noesis_View_TouchDown(HandleRef view, int x, int y, ulong touchId);

		[PreserveSig]
		private static extern bool Noesis_View_TouchUp(HandleRef view, int x, int y, ulong touchId);

		[PreserveSig]
		private static extern bool Noesis_View_KeyDown(HandleRef view, int key);

		[PreserveSig]
		private static extern bool Noesis_View_KeyUp(HandleRef view, int key);

		[PreserveSig]
		private static extern bool Noesis_View_Char(HandleRef view, uint ch);

		[PreserveSig]
		private static extern bool Noesis_View_Update(HandleRef view, double timeInSeconds);

		[PreserveSig]
		private static extern IntPtr Noesis_View_GetRenderer(HandleRef view);

		[PreserveSig]
		private static extern void Noesis_View_BindRenderingEvent(HandleRef view, RaiseRenderingCallback callback);

		[PreserveSig]
		private static extern void Noesis_View_UnbindRenderingEvent(HandleRef view, RaiseRenderingCallback callback);

		[PreserveSig]
		private static extern void Noesis_View_GetStats(HandleRef view, ref ViewStats stats);

		[PreserveSig]
		private static extern int Noesis_View_CreateTimer(HandleRef view, int interval, TimerEventCallback callback);

		[PreserveSig]
		private static extern void Noesis_View_RestartTimer(HandleRef view, int timerId, int interval);

		[PreserveSig]
		private static extern void Noesis_View_CancelTimer(HandleRef view, int timerId);
	}
}
