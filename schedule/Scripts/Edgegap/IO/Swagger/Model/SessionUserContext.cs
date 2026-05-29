using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class SessionUserContext
	{
		[DataMember(Name = "session_users", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "session_users")]
		public List<SessionUser> SessionUsers { get; set; }

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
