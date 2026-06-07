using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class SizeChangedInfo : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public Size NewSize => default(Size);

		public Size PreviousSize => default(Size);

		public bool WidthChanged => false;

		public bool HeightChanged => false;

		internal SizeChangedInfo(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(SizeChangedInfo obj)
		{
			return default(HandleRef);
		}

		~SizeChangedInfo()
		{
		}

		public virtual void Dispose()
		{
		}

		public SizeChangedInfo(UIElement element, Size previousSize, bool widthChanged, bool heightChanged)
		{
		}

		private static IntPtr CreateHelper(Size newSize, Size previousSize, bool widthChanged, bool heightChanged)
		{
			return (IntPtr)0;
		}

		public SizeChangedInfo()
		{
		}
	}
}
