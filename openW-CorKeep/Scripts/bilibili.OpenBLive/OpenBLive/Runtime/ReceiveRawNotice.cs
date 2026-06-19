using Newtonsoft.Json.Linq;

namespace OpenBLive.Runtime
{
	public delegate void ReceiveRawNotice(string raw, JObject jObject);
}
