using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class Paginator
	{
		[JsonProperty(PropertyName = "num_pages")]
		[DataMember(Name = "num_pages", EmitDefaultValue = false)]
		public int? NumPages { get; set; }

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
