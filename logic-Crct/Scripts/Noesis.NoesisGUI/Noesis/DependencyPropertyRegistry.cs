using System;
using System.Collections.Generic;

namespace Noesis
{
	internal class DependencyPropertyRegistry
	{
		private struct WeakType : IEquatable<WeakType>
		{
			private readonly int hashCode;

			private readonly WeakReference weakReference;

			public Type Type => null;

			public WeakType(Type type)
			{
				hashCode = 0;
				weakReference = null;
			}

			public bool Equals(WeakType other)
			{
				return false;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		private struct PropertyEntry
		{
			public readonly string Name;

			public readonly MetadataEntry Metadata;

			private WeakReference weakProperty;

			private WeakReference weakType;

			public DependencyProperty Property => null;

			public Type Type => null;

			public PropertyEntry(string name, DependencyProperty property, Type type, PropertyMetadata metadata)
			{
				Name = null;
				Metadata = default(MetadataEntry);
				weakProperty = null;
				weakType = null;
			}
		}

		private struct MetadataEntry
		{
			private enum MetadataType
			{
				Base = 0,
				UI = 1,
				Framework = 2
			}

			public readonly string PropertyName;

			private readonly object DefaultValue;

			private readonly PropertyChangedCallback PropertyChangedCallback;

			private readonly CoerceValueCallback CoerceValueCallback;

			private readonly MetadataType type;

			private readonly FrameworkPropertyMetadataOptions options;

			public MetadataEntry(DependencyProperty property, PropertyMetadata metadata)
			{
				PropertyName = null;
				DefaultValue = null;
				PropertyChangedCallback = null;
				CoerceValueCallback = null;
				type = default(MetadataType);
				options = default(FrameworkPropertyMetadataOptions);
			}

			public PropertyMetadata Create()
			{
				return null;
			}
		}

		private static readonly Dictionary<WeakType, List<PropertyEntry>> _typeProperties;

		private static readonly Dictionary<WeakType, List<MetadataEntry>> _typePropertyOverrides;

		public static void Register(DependencyProperty dp, string name, Type propertyType, Type ownerType, PropertyMetadata metadata)
		{
		}

		public static void Override(DependencyProperty dp, Type forType, PropertyMetadata metadata)
		{
		}

		public static void Restore(Type type)
		{
		}

		private static void RestoreDependencyProperties(Type ownerType)
		{
		}

		private static void RestoreDependencyPropertyOverrides(Type forType)
		{
		}
	}
}
