using System.Collections.Generic;

namespace JWT.Builder
{
	public class JwtData
	{
		public IDictionary<string, object> Header { get; }

		public IDictionary<string, object> Payload { get; }

		public JwtData()
		{
		}

		public JwtData(IDictionary<string, object> payload)
		{
		}

		public JwtData(IDictionary<string, object> header, IDictionary<string, object> payload)
		{
		}

		public JwtData(string token)
		{
		}
	}
}
