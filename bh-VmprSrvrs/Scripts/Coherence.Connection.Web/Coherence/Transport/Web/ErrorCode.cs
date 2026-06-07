using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Coherence.Transport.Web
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum ErrorCode
	{
		Unknown = 0,
		[EnumMember(Value = "err_invalid_challenge")]
		InvalidChallenge = 1,
		[EnumMember(Value = "err_room_not_found")]
		RoomNotFound = 2,
		[EnumMember(Value = "err_room_full")]
		RoomFull = 3
	}
}
