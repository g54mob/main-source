using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class EasingInt32KeyFrame : Int32KeyFrame
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

		internal new static EasingInt32KeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal EasingInt32KeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(EasingInt32KeyFrame obj)
		{
			return default(HandleRef);
		}

		public EasingInt32KeyFrame()
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
