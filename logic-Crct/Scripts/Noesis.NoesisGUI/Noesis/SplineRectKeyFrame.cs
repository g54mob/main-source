using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class SplineRectKeyFrame : RectKeyFrame
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

		internal new static SplineRectKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal SplineRectKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(SplineRectKeyFrame obj)
		{
			return default(HandleRef);
		}

		public SplineRectKeyFrame()
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
