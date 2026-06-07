using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class FrameworkPropertyMetadata : UIPropertyMetadata
	{
		public bool AffectsMeasure
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AffectsArrange
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AffectsParentMeasure
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AffectsParentArrange
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AffectsRender
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Inherits
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool OverridesInheritanceBehavior
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsNotDataBindable
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool BindsTwoWayByDefault
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Journal
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool SubPropertiesDoNotAffectRender
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public UpdateSourceTrigger DefaultUpdateSourceTrigger
		{
			get
			{
				return default(UpdateSourceTrigger);
			}
			set
			{
			}
		}

		internal new static FrameworkPropertyMetadata CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal FrameworkPropertyMetadata(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(FrameworkPropertyMetadata obj)
		{
			return default(HandleRef);
		}

		public FrameworkPropertyMetadata()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public FrameworkPropertyMetadata(PropertyChangedCallback propertyChangedCallback)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public FrameworkPropertyMetadata(PropertyChangedCallback propertyChangedCallback, CoerceValueCallback coerceValueCallback)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public FrameworkPropertyMetadata(object defaultValue)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public FrameworkPropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public FrameworkPropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback, CoerceValueCallback coerceValueCallback)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public FrameworkPropertyMetadata(object defaultValue, FrameworkPropertyMetadataOptions flags)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public FrameworkPropertyMetadata(object defaultValue, FrameworkPropertyMetadataOptions flags, PropertyChangedCallback propertyChangedCallback)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public FrameworkPropertyMetadata(object defaultValue, FrameworkPropertyMetadataOptions flags, PropertyChangedCallback propertyChangedCallback, CoerceValueCallback coerceValueCallback)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public FrameworkPropertyMetadata(object defaultValue, FrameworkPropertyMetadataOptions flags, PropertyChangedCallback propertyChangedCallback, CoerceValueCallback coerceValueCallback, bool isAnimationProhibited)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public FrameworkPropertyMetadata(object defaultValue, FrameworkPropertyMetadataOptions flags, PropertyChangedCallback propertyChangedCallback, CoerceValueCallback coerceValueCallback, bool isAnimationProhibited, UpdateSourceTrigger defaultUpdateSourceTrigger)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		private void TranslateFlags(FrameworkPropertyMetadataOptions flags)
		{
		}

		[PreserveSig]
		private static extern IntPtr Noesis_FrameworkPropertyMetadata_Create();
	}
}
