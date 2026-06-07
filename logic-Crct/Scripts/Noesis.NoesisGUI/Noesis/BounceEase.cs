using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class BounceEase : EasingFunctionBase
	{
		public static DependencyProperty BouncesProperty => null;

		public static DependencyProperty BouncinessProperty => null;

		public int Bounces
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float Bounciness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal new static BounceEase CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal BounceEase(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(BounceEase obj)
		{
			return default(HandleRef);
		}

		public BounceEase()
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
