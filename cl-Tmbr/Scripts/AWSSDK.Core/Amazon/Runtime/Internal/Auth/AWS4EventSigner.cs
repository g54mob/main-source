using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime.EventStreams;
using Amazon.Util;

namespace Amazon.Runtime.Internal.Auth
{
	public class AWS4EventSigner : IEventSigner
	{
		private const string Sha256Payload = "AWS4-HMAC-SHA256-PAYLOAD";

		private const string HeaderDate = ":date";

		private const string HeaderChunkSignature = ":chunk-signature";

		private readonly AWSCredentials _credentials;

		private readonly string _region;

		private readonly string _service;

		private string _previousSignature;

		public AWS4EventSigner(AWSCredentials credentials, string region, string service, string requestSignature)
		{
			_credentials = credentials;
			_region = region;
			_service = service;
			_previousSignature = requestSignature;
		}

		public async Task<byte[]> SignEventAsync(byte[] eventBytes)
		{
			string secretKey = (await _credentials.GetCredentialsAsync().ConfigureAwait(continueOnCapturedContext: false)).SecretKey;
			DateTime correctedUtcNow = AWSSDKUtils.CorrectedUtcNow;
			List<IEventStreamHeader> list = new List<IEventStreamHeader>();
			EventStreamHeader eventStreamHeader = new EventStreamHeader(":date")
			{
				HeaderType = EventStreamHeaderType.String
			};
			eventStreamHeader.SetTimestamp(correctedUtcNow);
			list.Add(eventStreamHeader);
			byte[] array = new byte[15];
			eventStreamHeader.WriteToBuffer(array, 0);
			string value = correctedUtcNow.ToString("yyyyMMddTHHmmssZ");
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("AWS4-HMAC-SHA256-PAYLOAD");
			stringBuilder.Append("\n");
			stringBuilder.Append(value);
			stringBuilder.Append("\n");
			stringBuilder.Append(correctedUtcNow.ToString("yyyyMMdd") + "/" + _region + "/" + _service + "/aws4_request");
			stringBuilder.Append("\n");
			stringBuilder.Append(_previousSignature);
			stringBuilder.Append("\n");
			stringBuilder.Append(AWSSDKUtils.ToHex(CryptoUtilFactory.CryptoInstance.ComputeSHA256Hash(array), lowercase: true));
			stringBuilder.Append("\n");
			stringBuilder.Append(AWSSDKUtils.ToHex(CryptoUtilFactory.CryptoInstance.ComputeSHA256Hash(eventBytes), lowercase: true));
			byte[] array2 = AWS4Signer.ComputeKeyedHash(SigningAlgorithm.HmacSHA256, AWS4Signer.ComposeSigningKey(secretKey, _region, correctedUtcNow.ToString("yyyyMMdd"), _service), Encoding.UTF8.GetBytes(stringBuilder.ToString()));
			EventStreamHeader eventStreamHeader2 = new EventStreamHeader(":chunk-signature")
			{
				HeaderType = EventStreamHeaderType.String
			};
			eventStreamHeader2.SetByteBuf(array2);
			list.Add(eventStreamHeader2);
			byte[] result = new EventStreamMessage(list, eventBytes).ToByteArray();
			_previousSignature = AWSSDKUtils.ToHex(array2, lowercase: true);
			return result;
		}
	}
}
