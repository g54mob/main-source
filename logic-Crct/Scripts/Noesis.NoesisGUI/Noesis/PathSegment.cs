using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class PathSegment : Animatable
	{
		public static DependencyProperty IsSmoothJoinProperty => null;

		public static DependencyProperty IsStrokedProperty => null;

		public bool IsSmoothJoin
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsStroked
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal new static PathSegment CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal PathSegment(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(PathSegment obj)
		{
			return default(HandleRef);
		}

		protected PathSegment()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
