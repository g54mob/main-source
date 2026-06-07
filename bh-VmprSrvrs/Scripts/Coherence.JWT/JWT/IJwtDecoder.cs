using System;

namespace JWT
{
	public interface IJwtDecoder
	{
		string DecodeHeader(string token);

		T DecodeHeader<T>(JwtParts jwt);

		string Decode(JwtParts jwt, bool verify);

		string Decode(JwtParts jwt, byte[] key, bool verify);

		string Decode(JwtParts jwt, byte[][] keys, bool verify);

		object DecodeToObject(Type type, JwtParts jwt, bool verify);

		object DecodeToObject(Type type, JwtParts jwt, byte[] key, bool verify);

		object DecodeToObject(Type type, JwtParts jwt, byte[][] keys, bool verify);
	}
}
