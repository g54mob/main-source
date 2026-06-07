using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DependencyProperty : BaseComponent
	{
		internal static IntPtr UnsetValuePtr;

		public static object UnsetValue;

		private static Type NullableType;

		private static Type IntType;

		private static Dictionary<Type, Type> _validTypes;

		public Type OwnerType => null;

		public Type PropertyType => null;

		public PropertyMetadata Metadata => null;

		public string Name => null;

		public bool ReadOnly => false;

		private Type OriginalPropertyType { get; set; }

		internal new static DependencyProperty CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DependencyProperty(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DependencyProperty obj)
		{
			return default(HandleRef);
		}

		protected DependencyProperty()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public PropertyMetadata GetMetadata(Type forType)
		{
			return null;
		}

		private static object GetUnsetValue()
		{
			return null;
		}

		private IntPtr GetOwnerTypeHelper()
		{
			return (IntPtr)0;
		}

		private IntPtr GetPropertyTypeHelper()
		{
			return (IntPtr)0;
		}

		private PropertyMetadata GetMetadataHelper(IntPtr type)
		{
			return null;
		}

		public static DependencyProperty Register(string name, Type propertyType, Type ownerType)
		{
			return null;
		}

		public static DependencyProperty Register(string name, Type propertyType, Type ownerType, PropertyMetadata typeMetadata)
		{
			return null;
		}

		public static DependencyProperty RegisterAttached(string name, Type propertyType, Type ownerType)
		{
			return null;
		}

		public static DependencyProperty RegisterAttached(string name, Type propertyType, Type ownerType, PropertyMetadata defaultMetadata)
		{
			return null;
		}

		public DependencyProperty AddOwner(Type ownerType)
		{
			return null;
		}

		public DependencyProperty AddOwner(Type ownerType, PropertyMetadata metadata)
		{
			return null;
		}

		public void OverrideMetadata(Type forType, PropertyMetadata typeMetadata)
		{
		}

		internal static DependencyProperty RegisterCommon(string name, Type propertyType, Type ownerType, PropertyMetadata propertyMetadata, DependencyProperty existingProperty = null)
		{
			return null;
		}

		private static void ValidateParams(string name, Type propertyType, Type ownerType)
		{
		}

		private static void ValidateMetadata(string name, Type type, Type owner, ref PropertyMetadata metadata)
		{
		}

		private static object GenerateDefaultValue(Type type)
		{
			return null;
		}

		private static void ValidateDefaultValue(string name, Type type, Type owner, object value)
		{
		}

		private static bool IsValidType(object value, Type type)
		{
			return false;
		}

		private static IntPtr ValidatePropertyType(ref Type propertyType)
		{
			return (IntPtr)0;
		}

		private static Dictionary<Type, Type> CreateValidTypes()
		{
			return null;
		}

		[PreserveSig]
		private static extern bool Noesis_ExistsDependencyProperty(IntPtr ownerType, string propertyName);

		[PreserveSig]
		private static extern IntPtr Noesis_RegisterDependencyProperty(IntPtr ownerType, string propertyName, IntPtr propertyType, HandleRef propertyMetadata);

		[PreserveSig]
		private static extern IntPtr Noesis_AddOwnerDependencyProperty(HandleRef source, IntPtr ownerType, HandleRef propertyMetadata);

		[PreserveSig]
		private static extern void Noesis_OverrideMetadata(IntPtr forType, HandleRef dependencyProperty, HandleRef propertyMetadata);
	}
}
