using System.Collections.Generic;

namespace JWT
{
	public interface IJwtEncoder
	{
		string Encode(IDictionary<string, object> extraHeaders, object payload, byte[] key);
	}
}
