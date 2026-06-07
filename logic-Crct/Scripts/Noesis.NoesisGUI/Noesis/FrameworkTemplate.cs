using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class FrameworkTemplate : BaseComponent
	{
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

		public Visual VisualTree
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool CanSeal => false;

		public bool IsSealed => false;

		internal new static FrameworkTemplate CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal FrameworkTemplate(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(FrameworkTemplate obj)
		{
			return default(HandleRef);
		}

		protected FrameworkTemplate()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public object FindName(string name, FrameworkElement templatedParent)
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

		public void Seal()
		{
		}
	}
}
