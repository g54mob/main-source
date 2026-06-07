using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Coherence.Transport.Web
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum ErrorType
	{
		Unknown = 0,
		[EnumMember(Value = "offerError")]
		OfferError = 1,
		[EnumMember(Value = "channelError")]
		ChannelError = 2
	}
}
