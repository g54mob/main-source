using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class KeySpline : Freezable
	{
		public Point ControlPoint1
		{
			get
			{
				return default(Point);
			}
			set
			{
			}
		}

		public Point ControlPoint2
		{
			get
			{
				return default(Point);
			}
			set
			{
			}
		}

		internal new static KeySpline CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal KeySpline(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(KeySpline obj)
		{
			return default(HandleRef);
		}

		public KeySpline()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public KeySpline(Point controlPoint1, Point controlPoint2)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public KeySpline(float controlPoint1X, float controlPoint1Y, float controlPoint2X, float controlPoint2Y)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public float GetSplineProgress(float linearProgress)
		{
			return 0f;
		}
	}
}
