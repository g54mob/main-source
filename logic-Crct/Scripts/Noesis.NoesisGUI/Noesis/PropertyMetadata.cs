using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class PropertyMetadata : BaseComponent
	{
		protected delegate void ManagedPropertyChangedCallback(IntPtr cPtr, IntPtr sender, IntPtr e);

		protected delegate IntPtr ManagedCoerceValueCallback(IntPtr cPtr, IntPtr d, IntPtr baseValue);

		private static ManagedPropertyChangedCallback _changed;

		protected static Dictionary<long, PropertyChangedCallback> _PropertyChangedCallback;

		private static ManagedCoerceValueCallback _coerce;

		protected static Dictionary<long, CoerceValueCallback> _CoerceValueCallback;

		public object DefaultValue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool HasDefaultValue => false;

		public PropertyChangedCallback PropertyChangedCallback
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CoerceValueCallback CoerceValueCallback
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static PropertyMetadata CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal PropertyMetadata(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(PropertyMetadata obj)
		{
			return default(HandleRef);
		}

		private IntPtr GetDefaultValueHelper()
		{
			return (IntPtr)0;
		}

		private void SetDefaultValueHelper(object value)
		{
		}

		public PropertyMetadata()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public PropertyMetadata(PropertyChangedCallback propertyChangedCallback)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public PropertyMetadata(object defaultValue)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public PropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public PropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback, CoerceValueCallback coerceValueCallback)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		[MonoPInvokeCallback(typeof(ManagedPropertyChangedCallback))]
		protected static void OnPropertyChanged(IntPtr cPtr, IntPtr d, IntPtr e)
		{
		}

		[MonoPInvokeCallback(typeof(ManagedCoerceValueCallback))]
		protected static IntPtr OnCoerceValue(IntPtr cPtr, IntPtr d, IntPtr baseValue)
		{
			return (IntPtr)0;
		}

		internal static void ClearCallbacks()
		{
		}

		[PreserveSig]
		private static extern IntPtr Noesis_PropertyMetadata_Create();

		[PreserveSig]
		private static extern void Noesis_PropertyMetadata_BindPropertyChangedCallback(HandleRef cPtr, ManagedPropertyChangedCallback callback);

		[PreserveSig]
		private static extern void Noesis_PropertyMetadata_UnbindPropertyChangedCallback(HandleRef cPtr, ManagedPropertyChangedCallback callback);

		[PreserveSig]
		private static extern void Noesis_PropertyMetadata_BindCoerceValueCallback(HandleRef cPtr, ManagedCoerceValueCallback callback);

		[PreserveSig]
		private static extern void Noesis_PropertyMetadata_UnbindCoerceValueCallback(HandleRef cPtr, ManagedCoerceValueCallback callback);
	}
}
