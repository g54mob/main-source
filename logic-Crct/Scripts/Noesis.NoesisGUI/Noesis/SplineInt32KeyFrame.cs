using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class SplineInt32KeyFrame : Int32KeyFrame
	{
		public static DependencyProperty KeySplineProperty => null;

		public KeySpline KeySpline
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static SplineInt32KeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal SplineInt32KeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(SplineInt32KeyFrame obj)
		{
			return default(HandleRef);
		}

		public SplineInt32KeyFrame()
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
