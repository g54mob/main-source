using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class BulletDecorator : Decorator
	{
		public static DependencyProperty BackgroundProperty => null;

		public Brush Background
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public UIElement Bullet
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static BulletDecorator CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal BulletDecorator(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(BulletDecorator obj)
		{
			return default(HandleRef);
		}

		public BulletDecorator()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
