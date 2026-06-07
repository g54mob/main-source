using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class EasingInt16KeyFrame : Int16KeyFrame
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

		internal new static EasingInt16KeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal EasingInt16KeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(EasingInt16KeyFrame obj)
		{
			return default(HandleRef);
		}

		public EasingInt16KeyFrame()
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
