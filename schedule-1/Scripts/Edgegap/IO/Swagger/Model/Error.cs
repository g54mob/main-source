using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class Error
	{
		[JsonProperty(PropertyName = "message")]
		[DataMember(Name = "message", EmitDefaultValue = false)]
		public string Message { get; set; }

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
