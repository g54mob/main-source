using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class EasingInt64KeyFrame : Int64KeyFrame
	{
		public static DependencyProperty EasingFunctionProperty => null;

		public EasingFunctionBase EasingFunction
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static EasingInt64KeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal EasingInt64KeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(EasingInt64KeyFrame obj)
		{
			return default(HandleRef);
		}

		public EasingInt64KeyFrame()
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
