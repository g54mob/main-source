using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class AdornerLayer : FrameworkElement
	{
		internal new static AdornerLayer CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal AdornerLayer(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(AdornerLayer obj)
		{
			return default(HandleRef);
		}

		public AdornerLayer()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public static AdornerLayer GetAdornerLayer(Visual visual)
		{
			return null;
		}

		public void Add(Adorner adorner)
		{
		}

		public void Remove(Adorner adorner)
		{
		}

		public void Update()
		{
		}

		public void Update(UIElement element)
		{
		}
	}
}
