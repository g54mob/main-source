using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class SplineSizeKeyFrame : SizeKeyFrame
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

		internal new static SplineSizeKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal SplineSizeKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(SplineSizeKeyFrame obj)
		{
			return default(HandleRef);
		}

		public SplineSizeKeyFrame()
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
