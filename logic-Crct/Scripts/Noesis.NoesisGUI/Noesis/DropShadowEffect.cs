using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DropShadowEffect : Effect
	{
		public static DependencyProperty BlurRadiusProperty => null;

		public static DependencyProperty ColorProperty => null;

		public static DependencyProperty DirectionProperty => null;

		public static DependencyProperty OpacityProperty => null;

		public static DependencyProperty ShadowDepthProperty => null;

		public float BlurRadius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Color Color
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public float Direction
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Opacity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ShadowDepth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal new static DropShadowEffect CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DropShadowEffect(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DropShadowEffect obj)
		{
			return default(HandleRef);
		}

		public DropShadowEffect()
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
