using System;
using JWT.Algorithms;

namespace JWT
{
	public interface IJwtValidator
	{
		void Validate(string decodedPayload, string signature, params string[] decodedSignatures);

		void Validate(string decodedPayload, IAsymmetricAlgorithm alg, byte[] bytesToSign, byte[] decodedSignature);

		bool TryValidate(string payloadJson, string signature, string decodedSignature, out Exception ex);

		bool TryValidate(string payloadJson, string signature, string[] decodedSignature, out Exception ex);

		bool TryValidate(string payloadJson, IAsymmetricAlgorithm alg, byte[] bytesToSign, byte[] decodedSignature, out Exception ex);
	}
}
