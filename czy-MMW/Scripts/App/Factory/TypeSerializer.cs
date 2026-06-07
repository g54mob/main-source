using System;

namespace Factory
{
	public class TypeSerializer<T> : CompositeSerializer, ITypeSerializer, ISerializer where T : class
	{
		public Type Type { get; private set; }

		public int TypeId { get; private set; }

		public int Version { get; private set; }

		public TypeSerializer()
			: base(typeof(T))
		{
			Type = typeof(T);
			TypeId = TypeUtilities.GetTypeId(Type);
			SerializableAttribute customAttribute = TypeUtilities.GetCustomAttribute<SerializableAttribute>(Type);
			Version = customAttribute.Version;
		}
	}
}
