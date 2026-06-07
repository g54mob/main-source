using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Canvas : Panel
	{
		public static DependencyProperty BottomProperty => null;

		public static DependencyProperty LeftProperty => null;

		public static DependencyProperty RightProperty => null;

		public static DependencyProperty TopProperty => null;

		internal new static Canvas CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Canvas(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Canvas obj)
		{
			return default(HandleRef);
		}

		public Canvas()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public static float GetLeft(UIElement element)
		{
			return 0f;
		}

		public static void SetLeft(UIElement element, float left)
		{
		}

		public static float GetTop(UIElement element)
		{
			return 0f;
		}

		public static void SetTop(UIElement element, float top)
		{
		}

		public static float GetRight(UIElement element)
		{
			return 0f;
		}

		public static void SetRight(UIElement element, float right)
		{
		}

		public static float GetBottom(UIElement element)
		{
			return 0f;
		}

		public static void SetBottom(UIElement element, float bottom)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
