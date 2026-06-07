using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Visual : DependencyObject
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate int ChildrenCountBaseCallback(HandleRef cPtr);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate IntPtr GetChildBaseCallback(HandleRef cPtr, int index);

		internal ChildrenCountBaseCallback ChildrenCountBase;

		internal GetChildBaseCallback GetChildBase;

		public View View => null;

		protected DependencyObject VisualParent => null;

		protected internal virtual int VisualChildrenCount => 0;

		internal new static Visual CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Visual(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Visual obj)
		{
			return default(HandleRef);
		}

		protected Visual()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected internal virtual Visual GetVisualChild(int index)
		{
			return null;
		}

		public bool IsAncestorOf(Visual visual)
		{
			return false;
		}

		public bool IsDescendantOf(Visual visual)
		{
			return false;
		}

		public Visual FindCommonVisualAncestor(Visual visual)
		{
			return null;
		}

		public Point PointFromScreen(Point point)
		{
			return default(Point);
		}

		public Point PointToScreen(Point point)
		{
			return default(Point);
		}

		public Matrix4 TransformToAncestor(Visual ancestor)
		{
			return default(Matrix4);
		}

		public Matrix4 TransformToDescendant(Visual descendant)
		{
			return default(Matrix4);
		}

		public Matrix4 TransformToVisual(Visual visual)
		{
			return default(Matrix4);
		}

		private IntPtr GetViewHelper()
		{
			return (IntPtr)0;
		}

		public void AddLayer(Visual layer)
		{
		}

		public void RemoveLayer(Visual layer)
		{
		}

		private DependencyObject GetVisualParentHelper()
		{
			return null;
		}

		protected void AddVisualChild(Visual child)
		{
		}

		protected void RemoveVisualChild(Visual child)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
