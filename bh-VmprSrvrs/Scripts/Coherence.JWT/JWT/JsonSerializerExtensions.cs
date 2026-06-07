namespace JWT
{
	public static class JsonSerializerExtensions
	{
		public static T Deserialize<T>(this IJsonSerializer jsonSerializer, string json)
		{
			return default(T);
		}
	}
}
