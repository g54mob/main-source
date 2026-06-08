using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Serialization.Formatters.Binary;
using Castle.DynamicProxy.Generators;

namespace Castle.DynamicProxy.Serialization
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
	[CLSCompliant(false)]
	public class CacheMappingsAttribute : Attribute
	{
		private static readonly ConstructorInfo constructor = typeof(CacheMappingsAttribute).GetConstructor(new Type[1] { typeof(byte[]) });

		private readonly byte[] serializedCacheMappings;

		public byte[] SerializedCacheMappings => serializedCacheMappings;

		public CacheMappingsAttribute(byte[] serializedCacheMappings)
		{
			this.serializedCacheMappings = serializedCacheMappings;
		}

		[Obsolete("Exposes a component that is intended for internal use only.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Dictionary<CacheKey, string> GetDeserializedMappings()
		{
			using MemoryStream serializationStream = new MemoryStream(SerializedCacheMappings);
			return (Dictionary<CacheKey, string>)new BinaryFormatter().Deserialize(serializationStream);
		}

		[Obsolete("Exposes a component that is intended for internal use only.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ApplyTo(AssemblyBuilder assemblyBuilder, Dictionary<CacheKey, string> mappings)
		{
			using MemoryStream memoryStream = new MemoryStream();
			new BinaryFormatter().Serialize(memoryStream, mappings);
			byte[] array = memoryStream.ToArray();
			CustomAttributeBuilder customAttribute = new CustomAttributeBuilder(constructor, new object[1] { array });
			assemblyBuilder.SetCustomAttribute(customAttribute);
		}
	}
}
