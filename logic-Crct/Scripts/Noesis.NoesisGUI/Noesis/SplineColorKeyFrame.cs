using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class SplineColorKeyFrame : ColorKeyFrame
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

		internal new static SplineColorKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal SplineColorKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(SplineColorKeyFrame obj)
		{
			return default(HandleRef);
		}

		public SplineColorKeyFrame()
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
