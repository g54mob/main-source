using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DockPanel : Panel
	{
		public static DependencyProperty DockProperty => null;

		public static DependencyProperty LastChildFillProperty => null;

		public bool LastChildFill
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal new static DockPanel CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DockPanel(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DockPanel obj)
		{
			return default(HandleRef);
		}

		public DockPanel()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public static Dock GetDock(DependencyObject element)
		{
			return default(Dock);
		}

		public static void SetDock(DependencyObject element, Dock dock)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
