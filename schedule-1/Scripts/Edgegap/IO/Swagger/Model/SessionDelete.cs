using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class SessionDelete
	{
		[DataMember(Name = "message", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "message")]
		public string Message { get; set; }

		[DataMember(Name = "session_id", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "session_id")]
		public string SessionId { get; set; }

		[JsonProperty(PropertyName = "custom_id")]
		[DataMember(Name = "custom_id", EmitDefaultValue = false)]
		public string CustomId { get; set; }

		public override string ToString()
		{
			return null;
		}

		public string ToJson()
		{
			return null;
		}
	}
}
