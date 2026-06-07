using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Adorner : FrameworkElement
	{
		public UIElement AdornedElement => null;

		public bool IsClipEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal new static Adorner CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Adorner(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Adorner obj)
		{
			return default(HandleRef);
		}

		public Adorner(UIElement adornedElement)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public virtual Matrix4 GetDesiredTransform(Matrix4 transform)
		{
			return default(Matrix4);
		}

		private void SetAdornedElement(UIElement adornedElement)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
