using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class VisualTransition : DependencyObject
	{
		public string From
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string To
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Duration GeneratedDuration
		{
			get
			{
				return default(Duration);
			}
			set
			{
			}
		}

		public EasingFunctionBase GeneratedEasingFunction
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

		internal new static VisualTransition CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal VisualTransition(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(VisualTransition obj)
		{
			return default(HandleRef);
		}

		public VisualTransition()
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
