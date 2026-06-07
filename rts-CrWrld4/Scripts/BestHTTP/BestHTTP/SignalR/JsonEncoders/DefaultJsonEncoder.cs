using System.Collections.Generic;

namespace BestHTTP.SignalR.JsonEncoders
{
	public sealed class DefaultJsonEncoder : IJsonEncoder
	{
		public string Encode(object obj)
		{
			return null;
		}

		public IDictionary<string, object> DecodeMessage(string json)
		{
			return null;
		}
	}
}
