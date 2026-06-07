using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DrawingContext : BaseComponent
	{
		internal new static DrawingContext CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DrawingContext(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DrawingContext obj)
		{
			return default(HandleRef);
		}

		public DrawingContext()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public void DrawLine(Pen pen, Point p0, Point p1)
		{
		}

		public void DrawRectangle(Brush brush, Pen pen, Rect rect)
		{
		}

		public void DrawRoundedRectangle(Brush brush, Pen pen, Rect rect, float rX, float rY)
		{
		}

		public void DrawEllipse(Brush brush, Pen pen, Point center, float rX, float rY)
		{
		}

		public void DrawGeometry(Brush brush, Pen pen, Geometry geometry)
		{
		}

		public void DrawImage(ImageSource imageSource, Rect rect)
		{
		}

		public void DrawText(FormattedText formattedText, Rect bounds)
		{
		}

		public void Pop()
		{
		}

		public void PushClip(Geometry clipGeometry)
		{
		}

		public void PushTransform(Transform transform)
		{
		}
	}
}
