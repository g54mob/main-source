namespace Amazon.Util.Internal
{
	public class JsonSerializerContext
	{
		public JsonSerializerOptions Options { get; private set; }

		public static JsonSerializerContext Default { get; set; }

		public JsonSerializerContext()
		{
		}

		public JsonSerializerContext(JsonSerializerOptions defaultOptions)
		{
			Options = defaultOptions;
		}
	}
}
