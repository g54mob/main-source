using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class EasingSizeKeyFrame : SizeKeyFrame
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

		internal new static EasingSizeKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal EasingSizeKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(EasingSizeKeyFrame obj)
		{
			return default(HandleRef);
		}

		public EasingSizeKeyFrame()
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
