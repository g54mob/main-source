using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TranslateTransform : Transform
	{
		public static DependencyProperty XProperty => null;

		public static DependencyProperty YProperty => null;

		public float X
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Y
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal new static TranslateTransform CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TranslateTransform(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(TranslateTransform obj)
		{
			return default(HandleRef);
		}

		public TranslateTransform()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public TranslateTransform(float x, float y)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
