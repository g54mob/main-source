using JWT.Builder;

namespace JWT
{
	public class JwtDecoderContext
	{
		public JwtParts Token { get; set; }

		public JwtHeader Header { get; set; }

		public string Payload { get; set; }

		public static JwtDecoderContext Create(JwtHeader header, string decodedPayload, JwtParts jwt)
		{
			return null;
		}
	}
}
