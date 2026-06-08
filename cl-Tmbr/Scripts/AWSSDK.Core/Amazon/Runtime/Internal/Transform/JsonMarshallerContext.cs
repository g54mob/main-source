using System.Text.Json;

namespace Amazon.Runtime.Internal.Transform
{
	public class JsonMarshallerContext : MarshallerContext
	{
		public Utf8JsonWriter Writer { get; private set; }

		public JsonMarshallerContext(IRequest request, Utf8JsonWriter writer)
			: base(request)
		{
			Writer = writer;
		}
	}
}
