using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class VisualState : DependencyObject
	{
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

		public Storyboard Storyboard
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static VisualState CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal VisualState(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(VisualState obj)
		{
			return default(HandleRef);
		}

		public VisualState()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
