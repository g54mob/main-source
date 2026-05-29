using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class ComponentCredentials
	{
		[JsonProperty(PropertyName = "username")]
		[DataMember(Name = "username", EmitDefaultValue = false)]
		public string Username { get; set; }

		[DataMember(Name = "token", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "token")]
		public string Token { get; set; }

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
