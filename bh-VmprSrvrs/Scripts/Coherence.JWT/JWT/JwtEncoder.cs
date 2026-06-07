using System.Collections.Generic;
using JWT.Algorithms;

namespace JWT
{
	public sealed class JwtEncoder : IJwtEncoder
	{
		private readonly IAlgorithmFactory _algFactory;

		private readonly IJsonSerializer _jsonSerializer;

		private readonly IBase64UrlEncoder _urlEncoder;

		public JwtEncoder(IAlgorithmFactory algFactory, IJsonSerializer jsonSerializer, IBase64UrlEncoder urlEncoder)
		{
		}

		public JwtEncoder(IJwtAlgorithm algorithm, IJsonSerializer jsonSerializer, IBase64UrlEncoder urlEncoder)
		{
		}

		public string Encode(IDictionary<string, object> extraHeaders, object payload, byte[] key)
		{
			return null;
		}

		private string GetSignatureSegment(IJwtAlgorithm algorithm, byte[] key, byte[] bytesToSign)
		{
			return null;
		}
	}
}
