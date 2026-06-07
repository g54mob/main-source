namespace JWT.Serializers
{
	public sealed class DefaultJsonSerializerFactory : IJsonSerializerFactory
	{
		private readonly IJsonSerializer _jsonSerializer;

		public IJsonSerializer Create()
		{
			return null;
		}
	}
}
