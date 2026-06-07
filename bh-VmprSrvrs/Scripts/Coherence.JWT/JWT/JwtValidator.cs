using System;
using System.Collections.Generic;
using JWT.Algorithms;

namespace JWT
{
	public sealed class JwtValidator : IJwtValidator
	{
		private readonly IJsonSerializer _jsonSerializer;

		private readonly IDateTimeProvider _dateTimeProvider;

		private readonly IBase64UrlEncoder _urlEncoder;

		private readonly ValidationParameters _valParams;

		public JwtValidator(IJsonSerializer jsonSerializer, IDateTimeProvider dateTimeProvider)
		{
		}

		public JwtValidator(IJsonSerializer jsonSerializer, IDateTimeProvider dateTimeProvider, ValidationParameters valParams)
		{
		}

		public JwtValidator(IJsonSerializer jsonSerializer, IDateTimeProvider dateTimeProvider, ValidationParameters valParams, IBase64UrlEncoder urlEncoder)
		{
		}

		public void Validate(string decodedPayload, string signature, params string[] decodedSignatures)
		{
		}

		public void Validate(string decodedPayload, IAsymmetricAlgorithm alg, byte[] bytesToSign, byte[] decodedSignature)
		{
		}

		public bool TryValidate(string payloadJson, string signature, string decodedSignature, out Exception ex)
		{
			ex = null;
			return false;
		}

		public bool TryValidate(string payloadJson, string signature, string[] decodedSignature, out Exception ex)
		{
			ex = null;
			return false;
		}

		public bool TryValidate(string payloadJson, IAsymmetricAlgorithm alg, byte[] bytesToSign, byte[] decodedSignature, out Exception ex)
		{
			ex = null;
			return false;
		}

		public Exception GetValidationException(JwtParts parts)
		{
			return null;
		}

		public Exception GetValidationException(byte[] bytes)
		{
			return null;
		}

		private Exception GetValidationException(string payloadJson, string decodedCrypto, params string[] decodedSignatures)
		{
			return null;
		}

		private Exception GetValidationException(IAsymmetricAlgorithm alg, string payloadJson, byte[] bytesToSign, byte[] decodedSignature)
		{
			return null;
		}

		private Exception GetValidationException(string payloadJson)
		{
			return null;
		}

		private static bool AreAllDecodedSignaturesNullOrWhiteSpace(string[] decodedSignatures)
		{
			return false;
		}

		private static bool IsAnySignatureValid(string decodedCrypto, string[] decodedSignatures)
		{
			return false;
		}

		private static bool CompareCryptoWithSignature(string decodedCrypto, string decodedSignature)
		{
			return false;
		}

		private Exception ValidateExpClaim(IReadOnlyDictionary<string, object> payloadData, double secondsSinceEpoch)
		{
			return null;
		}

		private Exception ValidateNbfClaim(IReadOnlyDictionary<string, object> payloadData, double secondsSinceEpoch)
		{
			return null;
		}
	}
}
