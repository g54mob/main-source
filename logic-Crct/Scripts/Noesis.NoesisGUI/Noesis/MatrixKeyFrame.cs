using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class MatrixKeyFrame : Freezable
	{
		public static DependencyProperty KeyTimeProperty => null;

		public static DependencyProperty ValueProperty => null;

		public KeyTime KeyTime
		{
			get
			{
				return default(KeyTime);
			}
			set
			{
			}
		}

		public Matrix Value
		{
			get
			{
				return default(Matrix);
			}
			set
			{
			}
		}

		internal new static MatrixKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal MatrixKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(MatrixKeyFrame obj)
		{
			return default(HandleRef);
		}

		protected MatrixKeyFrame()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
