using System;
using FullInspector.Serializers.FullSerializer;
using JetBrains.Annotations;

namespace FullInspector.Internal
{
	[UsedImplicitly]
	public class fiLoadedSerializers : fiILoadedSerializers
	{
		public Type DefaultSerializerProvider => typeof(FullSerializerMetadata);

		public Type[] AllLoadedSerializerProviders => new Type[1] { typeof(FullSerializerMetadata) };
	}
}
