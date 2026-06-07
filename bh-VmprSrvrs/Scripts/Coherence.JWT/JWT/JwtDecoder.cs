using System;
using JWT.Algorithms;

namespace JWT
{
	public sealed class JwtDecoder : IJwtDecoder
	{
		private readonly IJsonSerializer _jsonSerializer;

		private readonly IJwtValidator _jwtValidator;

		private readonly IBase64UrlEncoder _urlEncoder;

		private readonly IAlgorithmFactory _algFactory;

		public JwtDecoder(IJsonSerializer jsonSerializer, IBase64UrlEncoder urlEncoder)
		{
		}

		public JwtDecoder(IJsonSerializer jsonSerializer, IJwtValidator jwtValidator, IBase64UrlEncoder urlEncoder, IAlgorithmFactory algFactory)
		{
		}

		public JwtDecoder(IJsonSerializer jsonSerializer, IJwtValidator jwtValidator, IBase64UrlEncoder urlEncoder, IJwtAlgorithm algorithm)
		{
		}

		public string DecodeHeader(string token)
		{
			return null;
		}

		public T DecodeHeader<T>(JwtParts jwt)
		{
			return default(T);
		}

		public string Decode(JwtParts jwt, bool verify)
		{
			return null;
		}

		public string Decode(JwtParts jwt, byte[] key, bool verify)
		{
			return null;
		}

		public string Decode(JwtParts jwt, byte[][] keys, bool verify)
		{
			return null;
		}

		public object DecodeToObject(Type type, JwtParts jwt, bool verify)
		{
			return null;
		}

		public object DecodeToObject(Type type, JwtParts jwt, byte[] key, bool verify)
		{
			return null;
		}

		public object DecodeToObject(Type type, JwtParts jwt, byte[][] keys, bool verify)
		{
			return null;
		}

		public void Validate(string[] parts, byte[] key)
		{
		}

		public void Validate(string[] parts, params byte[][] keys)
		{
		}

		public void Validate(JwtParts jwt, params byte[][] keys)
		{
		}

		private string Decode(JwtParts jwt)
		{
			return null;
		}

		private void ValidSymmetricAlgorithm(byte[][] keys, string decodedPayload, IJwtAlgorithm algorithm, byte[] bytesToSign, byte[] decodedSignature)
		{
		}

		private static bool AllKeysHaveValues(byte[][] keys)
		{
			return false;
		}

		private void ValidateNoneAlgorithm(JwtParts jwt)
		{
		}
	}
}
