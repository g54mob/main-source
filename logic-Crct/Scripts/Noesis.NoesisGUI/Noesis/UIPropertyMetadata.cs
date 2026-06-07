using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class UIPropertyMetadata : PropertyMetadata
	{
		internal new static UIPropertyMetadata CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal UIPropertyMetadata(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(UIPropertyMetadata obj)
		{
			return default(HandleRef);
		}

		public UIPropertyMetadata()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public UIPropertyMetadata(PropertyChangedCallback propertyChangedCallback)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public UIPropertyMetadata(object defaultValue)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public UIPropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public UIPropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback, CoerceValueCallback coerceValueCallback)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public UIPropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback, CoerceValueCallback coerceValueCallback, bool isAnimationProhibited)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		[PreserveSig]
		private static extern IntPtr Noesis_UIPropertyMetadata_Create();
	}
}
