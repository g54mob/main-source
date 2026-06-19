using System;
using System.Collections.Generic;
using FullSerializer.Internal;

namespace FullInspector.Internal
{
	public static class fiInstalledSerializerManager
	{
		public const string GeneratedTypeName = "fiLoadedSerializers";

		private static fiISerializerMetadata _defaultMetadata;

		public static List<fiISerializerMetadata> LoadedMetadata { get; private set; }

		public static fiISerializerMetadata DefaultMetadata
		{
			get
			{
				if (_defaultMetadata == null)
				{
					throw new InvalidOperationException("Please register a default serializer. You should see a popup window on the next serialization reload.");
				}
				return _defaultMetadata;
			}
		}

		public static bool HasDefault => _defaultMetadata != null;

		public static Type[] SerializationOptInAnnotations { get; private set; }

		public static Type[] SerializationOptOutAnnotations { get; private set; }

		private static fiISerializerMetadata GetProvider(Type type)
		{
			return (fiISerializerMetadata)Activator.CreateInstance(type);
		}

		public static bool TryGetLoadedSerializerType(out fiILoadedSerializers serializers)
		{
			fsTypeCache.Reset();
			Type type = fsTypeCache.GetType("FullInspector.Internal.fiLoadedSerializers");
			if (type == null)
			{
				serializers = null;
				return false;
			}
			serializers = (fiILoadedSerializers)Activator.CreateInstance(type);
			return true;
		}

		static fiInstalledSerializerManager()
		{
			List<Type> list = new List<Type>();
			List<Type> list2 = new List<Type>();
			LoadedMetadata = new List<fiISerializerMetadata>();
			if (TryGetLoadedSerializerType(out var serializers))
			{
				_defaultMetadata = GetProvider(serializers.DefaultSerializerProvider);
				Type[] allLoadedSerializerProviders = serializers.AllLoadedSerializerProviders;
				for (int i = 0; i < allLoadedSerializerProviders.Length; i++)
				{
					fiISerializerMetadata provider = GetProvider(allLoadedSerializerProviders[i]);
					LoadedMetadata.Add(provider);
					list.AddRange(provider.SerializationOptInAnnotationTypes);
					list2.AddRange(provider.SerializationOptOutAnnotationTypes);
				}
			}
			foreach (Type item in fiRuntimeReflectionUtility.AllSimpleTypesDerivingFrom(typeof(fiISerializerMetadata)))
			{
				fiISerializerMetadata provider2 = GetProvider(item);
				LoadedMetadata.Add(provider2);
				list.AddRange(provider2.SerializationOptInAnnotationTypes);
				list2.AddRange(provider2.SerializationOptOutAnnotationTypes);
			}
			SerializationOptInAnnotations = list.ToArray();
			SerializationOptOutAnnotations = list2.ToArray();
		}

		public static bool IsLoaded(Guid serializerGuid)
		{
			if (LoadedMetadata == null)
			{
				return false;
			}
			for (int i = 0; i < LoadedMetadata.Count; i++)
			{
				if (LoadedMetadata[i].SerializerGuid == serializerGuid)
				{
					return true;
				}
			}
			return false;
		}
	}
}
