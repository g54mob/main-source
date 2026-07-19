namespace UniJSON
{
	public static class JsonSchemaExtensions
	{
		public static string Serialize<T>(this JsonSchema s, T o, JsonSchemaValidationContext c = null)
		{
			JsonFormatter jsonFormatter = new JsonFormatter();
			s.Serialize(jsonFormatter, o, c);
			return jsonFormatter.ToString();
		}
	}
}
