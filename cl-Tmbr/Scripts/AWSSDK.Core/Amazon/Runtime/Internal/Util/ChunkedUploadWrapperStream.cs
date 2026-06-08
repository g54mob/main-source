using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.Auth;
using Amazon.Util;
using Amazon.Util.Internal;

namespace Amazon.Runtime.Internal.Util
{
	public class ChunkedUploadWrapperStream : WrapperStream
	{
		private enum ReadStrategy
		{
			ReadDirect = 0,
			ReadAndCopy = 1
		}

		public static readonly int DefaultChunkSize = 81920;

		private const string STREAM_NEWLINE = "\r\n";

		private const int NEWLINE_LENGTH = 2;

		private const int HEADER_ROW_PADDING_LENGTH = 3;

		private const string CHUNK_STRING_TO_SIGN_PREFIX = "AWS4-HMAC-SHA256-PAYLOAD";

		private const string CHUNK_SIGNATURE_HEADER = ";chunk-signature=";

		public const int V4_SIGNATURE_LENGTH = 64;

		public const int V4A_SIGNATURE_LENGTH = 144;

		private const string TRAILING_HEADER_SIGNATURE_KEY = "x-amz-trailer-signature";

		private const string TRAILING_HEADER_STRING_TO_SIGN_PREFIX = "AWS4-HMAC-SHA256-TRAILER";

		private byte[] _inputBuffer;

		private readonly byte[] _outputBuffer;

		private int _outputBufferPos = -1;

		private int _outputBufferDataLen = -1;

		private readonly int _wrappedStreamBufferSize;

		private bool _wrappedStreamConsumed;

		private CoreChecksumAlgorithm _trailingChecksum;

		private HashAlgorithm _hashAlgorithm;

		private IDictionary<string, string> _trailingHeaders;

		private string _trailingHeaderChunk;

		private int _trailingHeaderPos;

		private bool _trailingHeadersConsumed = true;

		private bool _outputBufferIsTerminatingChunk;

		private readonly ReadStrategy _readStrategy;

		private AWSSigningResultBase HeaderSigningResult { get; set; }

		private AWS4aSignerCRTWrapper Sigv4aSigner { get; set; }

		private string PreviousChunkSignature { get; set; }

		public override long Length
		{
			get
			{
				if (base.BaseStream == null)
				{
					return 0L;
				}
				return ComputeChunkedContentLength(base.BaseStream.Length, (HeaderSigningResult is AWS4aSigningResult) ? 144 : 64, _trailingHeaders, _trailingChecksum);
			}
		}

		public override bool CanSeek => false;

		internal override bool HasLength => HeaderSigningResult != null;

		internal ChunkedUploadWrapperStream(Stream stream, int wrappedStreamBufferSize, AWSSigningResultBase headerSigningResult)
			: base(stream)
		{
			if (!(headerSigningResult is AWS4aSigningResult) && !(headerSigningResult is AWS4SigningResult))
			{
				throw new AmazonClientException("ChunkedUploadWrapperStream was initialized without a SigV4 or SigV4a signing result.");
			}
			if (headerSigningResult is AWS4aSigningResult)
			{
				Sigv4aSigner = new AWS4aSignerCRTWrapper();
			}
			HeaderSigningResult = headerSigningResult;
			PreviousChunkSignature = headerSigningResult?.Signature;
			_wrappedStreamBufferSize = wrappedStreamBufferSize;
			_inputBuffer = new byte[DefaultChunkSize];
			_outputBuffer = new byte[CalculateChunkHeaderLength(DefaultChunkSize, (HeaderSigningResult is AWS4aSigningResult) ? 144 : 64)];
			if (SearchWrappedStream((Stream s) => s is EncryptUploadPartStream || s is EncryptStream) != null)
			{
				_readStrategy = ReadStrategy.ReadAndCopy;
			}
		}

		public ChunkedUploadWrapperStream(Stream stream, int wrappedStreamBufferSize, AWSSigningResultBase headerSigningResult, CoreChecksumAlgorithm trailingChecksum, IDictionary<string, string> trailingHeaders)
			: this(stream, wrappedStreamBufferSize, headerSigningResult)
		{
			if (trailingChecksum != CoreChecksumAlgorithm.NONE)
			{
				_trailingChecksum = trailingChecksum;
				_hashAlgorithm = CryptoUtilFactory.GetChecksumInstance(trailingChecksum);
			}
			_trailingHeadersConsumed = false;
			_trailingHeaders = trailingHeaders;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int bytesRead = 0;
			if (_outputBufferPos == -1)
			{
				if (_wrappedStreamConsumed && _outputBufferIsTerminatingChunk)
				{
					if (_trailingHeadersConsumed)
					{
						return 0;
					}
					return WriteTrailingHeaders(buffer, offset, count);
				}
				bytesRead = FillInputBuffer();
			}
			return AdjustBufferAfterReading(buffer, offset, count, bytesRead);
		}

		private int AdjustBufferAfterReading(byte[] buffer, int offset, int count, int bytesRead)
		{
			if (_outputBufferPos == -1)
			{
				ConstructOutputBufferChunk(bytesRead);
				_outputBufferIsTerminatingChunk = _wrappedStreamConsumed && bytesRead == 0;
			}
			int num = _outputBufferDataLen - _outputBufferPos;
			if (num < count)
			{
				count = num;
			}
			Buffer.BlockCopy(_outputBuffer, _outputBufferPos, buffer, offset, count);
			_outputBufferPos += count;
			if (_outputBufferPos >= _outputBufferDataLen)
			{
				_outputBufferPos = -1;
			}
			return count;
		}

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			int bytesRead = 0;
			if (_outputBufferPos == -1)
			{
				if (_wrappedStreamConsumed && _outputBufferIsTerminatingChunk)
				{
					if (_trailingHeadersConsumed)
					{
						return 0;
					}
					return WriteTrailingHeaders(buffer, offset, count);
				}
				bytesRead = await FillInputBufferAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			return AdjustBufferAfterReading(buffer, offset, count, bytesRead);
		}

		private async Task<int> FillInputBufferAsync(CancellationToken cancellationToken)
		{
			if (_wrappedStreamConsumed)
			{
				return 0;
			}
			int inputBufferPos = 0;
			if (_readStrategy == ReadStrategy.ReadDirect)
			{
				while (inputBufferPos < _inputBuffer.Length && !_wrappedStreamConsumed)
				{
					int num = _inputBuffer.Length - inputBufferPos;
					if (num > _wrappedStreamBufferSize)
					{
						num = _wrappedStreamBufferSize;
					}
					int num2 = await base.BaseStream.ReadAsync(_inputBuffer, inputBufferPos, num, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (num2 == 0)
					{
						_wrappedStreamConsumed = true;
					}
					else
					{
						inputBufferPos += num2;
					}
				}
			}
			else
			{
				byte[] readBuffer = new byte[_wrappedStreamBufferSize];
				while (inputBufferPos < _inputBuffer.Length && !_wrappedStreamConsumed)
				{
					int num3 = await base.BaseStream.ReadAsync(readBuffer, 0, _wrappedStreamBufferSize, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (num3 == 0)
					{
						_wrappedStreamConsumed = true;
						continue;
					}
					Buffer.BlockCopy(readBuffer, 0, _inputBuffer, inputBufferPos, num3);
					inputBufferPos += num3;
				}
			}
			return inputBufferPos;
		}

		private void ConstructOutputBufferChunk(int dataLen)
		{
			if (dataLen > 0 && dataLen < _inputBuffer.Length)
			{
				byte[] array = new byte[dataLen];
				Buffer.BlockCopy(_inputBuffer, 0, array, 0, dataLen);
				_inputBuffer = array;
			}
			bool flag = dataLen == 0;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(dataLen.ToString("X", CultureInfo.InvariantCulture));
			string text = "";
			if (HeaderSigningResult is AWS4aSigningResult headerSigningResult)
			{
				text = ((!flag) ? Sigv4aSigner.SignChunk(new MemoryStream(_inputBuffer), PreviousChunkSignature, headerSigningResult) : Sigv4aSigner.SignChunk(null, PreviousChunkSignature, headerSigningResult));
			}
			else if (HeaderSigningResult is AWS4SigningResult aWS4SigningResult)
			{
				string data = BuildChunkedStringToSign("AWS4-HMAC-SHA256-PAYLOAD", aWS4SigningResult.ISO8601DateTime, aWS4SigningResult.Scope, PreviousChunkSignature, dataLen, _inputBuffer);
				text = AWSSDKUtils.ToHex(AWS4Signer.SignBlob(aWS4SigningResult.GetSigningKey(), data), lowercase: true);
			}
			PreviousChunkSignature = text;
			if (HeaderSigningResult is AWS4aSigningResult)
			{
				stringBuilder.Append(";chunk-signature=" + text.PadRight(144, '*'));
			}
			else
			{
				stringBuilder.Append(";chunk-signature=" + text);
			}
			if (_hashAlgorithm != null)
			{
				_hashAlgorithm.TransformBlock(_inputBuffer, 0, dataLen, _inputBuffer, 0);
			}
			stringBuilder.Append("\r\n");
			try
			{
				byte[] bytes = Encoding.UTF8.GetBytes(stringBuilder.ToString());
				byte[] array2 = ArrayEx.Empty<byte>();
				if (flag)
				{
					IDictionary<string, string> trailingHeaders = _trailingHeaders;
					if (trailingHeaders != null && trailingHeaders.Count > 0)
					{
						goto IL_01a6;
					}
				}
				array2 = Encoding.UTF8.GetBytes("\r\n");
				goto IL_01a6;
				IL_01a6:
				int num = 0;
				Buffer.BlockCopy(bytes, 0, _outputBuffer, num, bytes.Length);
				num += bytes.Length;
				if (dataLen > 0)
				{
					Buffer.BlockCopy(_inputBuffer, 0, _outputBuffer, num, dataLen);
					num += dataLen;
				}
				Buffer.BlockCopy(array2, 0, _outputBuffer, num, array2.Length);
				_outputBufferPos = 0;
				_outputBufferDataLen = bytes.Length + dataLen + array2.Length;
			}
			catch (Exception ex)
			{
				throw new AmazonClientException("Unable to sign the chunked data. " + ex.Message, ex);
			}
		}

		private string ConstructSignedTrailersChunk()
		{
			if (_hashAlgorithm != null)
			{
				_hashAlgorithm.TransformFinalBlock(ArrayEx.Empty<byte>(), 0, 0);
				_trailingHeaders[ChecksumUtils.GetChecksumHeaderKey(_trailingChecksum)] = Convert.ToBase64String(_hashAlgorithm.Hash);
			}
			string text;
			if (HeaderSigningResult is AWS4SigningResult)
			{
				string data = AWS4Signer.CanonicalizeHeaders(AWS4Signer.SortAndPruneHeaders(_trailingHeaders));
				string data2 = "AWS4-HMAC-SHA256-TRAILER\n" + HeaderSigningResult.ISO8601DateTime + "\n" + HeaderSigningResult.Scope + "\n" + PreviousChunkSignature + "\n" + AWSSDKUtils.ToHex(AWS4Signer.ComputeHash(data), lowercase: true);
				text = AWSSDKUtils.ToHex(AWS4Signer.SignBlob(((AWS4SigningResult)HeaderSigningResult).GetSigningKey(), data2), lowercase: true);
			}
			else
			{
				text = Sigv4aSigner.SignTrailingHeaderChunk(_trailingHeaders, PreviousChunkSignature, (AWS4aSigningResult)HeaderSigningResult).PadRight(144, '*');
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> item in _trailingHeaders.OrderBy((KeyValuePair<string, string> kvp) => kvp.Key))
			{
				stringBuilder.Append(item.Key + ":" + item.Value + "\r\n");
			}
			stringBuilder.Append("x-amz-trailer-signature:" + text + "\r\n");
			stringBuilder.Append("\r\n");
			return stringBuilder.ToString();
		}

		private int WriteTrailingHeaders(byte[] buffer, int offset, int count)
		{
			if (string.IsNullOrEmpty(_trailingHeaderChunk))
			{
				_trailingHeaderChunk = ConstructSignedTrailersChunk();
			}
			int num = _trailingHeaderChunk.Length - _trailingHeaderPos;
			if (num == 0)
			{
				_trailingHeadersConsumed = true;
				return 0;
			}
			if (num <= count)
			{
				Buffer.BlockCopy(Encoding.Default.GetBytes(_trailingHeaderChunk), _trailingHeaderPos, buffer, offset, num);
				_trailingHeadersConsumed = true;
				return num;
			}
			Buffer.BlockCopy(Encoding.Default.GetBytes(_trailingHeaderChunk), _trailingHeaderPos, buffer, offset, count);
			_trailingHeaderPos += count;
			return count;
		}

		public static long ComputeChunkedContentLength(long originalLength, int signatureLength)
		{
			return ComputeChunkedContentLength(originalLength, signatureLength, null, CoreChecksumAlgorithm.NONE);
		}

		public static long ComputeChunkedContentLength(long originalLength, int signatureLength, IDictionary<string, string> trailingHeaders, CoreChecksumAlgorithm trailingChecksum)
		{
			if (originalLength < 0)
			{
				throw new ArgumentOutOfRangeException("originalLength", "Expected 0 or greater value for originalLength.");
			}
			int num = 0;
			long num2;
			if (originalLength == 0L)
			{
				num2 = CalculateChunkHeaderLength(0L, signatureLength);
			}
			else
			{
				long num3 = originalLength / DefaultChunkSize;
				long num4 = originalLength % DefaultChunkSize;
				num2 = num3 * CalculateChunkHeaderLength(DefaultChunkSize, signatureLength) + ((num4 > 0) ? CalculateChunkHeaderLength(num4, signatureLength) : 0) + CalculateChunkHeaderLength(0L, signatureLength);
			}
			if (trailingHeaders != null && trailingHeaders.Count > 0)
			{
				foreach (string key in trailingHeaders.Keys)
				{
					num = ((trailingChecksum == CoreChecksumAlgorithm.NONE || !(ChecksumUtils.GetChecksumHeaderKey(trailingChecksum) == key)) ? (num + (key.Length + trailingHeaders[key].Length + 3)) : (num + (key.Length + CryptoUtilFactory.GetChecksumBase64Length(trailingChecksum) + 3)));
				}
				num += "x-amz-trailer-signature".Length + signatureLength + 3;
			}
			return num2 + num;
		}

		public static string BuildChunkedStringToSign(string prefix, string dateTime, string scope, string previousSignature, int dataLength, byte[] inputBuffer)
		{
			return prefix + "\n" + dateTime + "\n" + scope + "\n" + previousSignature + "\n" + AWSSDKUtils.ToHex(AWS4Signer.ComputeHash(""), lowercase: true) + "\n" + ((dataLength > 0) ? AWSSDKUtils.ToHex(AWS4Signer.ComputeHash(inputBuffer), lowercase: true) : "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855");
		}

		private static long CalculateChunkHeaderLength(long chunkDataSize, int signatureLength)
		{
			return chunkDataSize.ToString("X", CultureInfo.InvariantCulture).Length + ";chunk-signature=".Length + signatureLength + 2 + chunkDataSize + 2;
		}

		private int FillInputBuffer()
		{
			if (_wrappedStreamConsumed)
			{
				return 0;
			}
			int num = 0;
			if (_readStrategy == ReadStrategy.ReadDirect)
			{
				while (num < _inputBuffer.Length && !_wrappedStreamConsumed)
				{
					int num2 = _inputBuffer.Length - num;
					if (num2 > _wrappedStreamBufferSize)
					{
						num2 = _wrappedStreamBufferSize;
					}
					int num3 = base.BaseStream.Read(_inputBuffer, num, num2);
					if (num3 == 0)
					{
						_wrappedStreamConsumed = true;
					}
					else
					{
						num += num3;
					}
				}
			}
			else
			{
				byte[] array = new byte[_wrappedStreamBufferSize];
				while (num < _inputBuffer.Length && !_wrappedStreamConsumed)
				{
					int num4 = base.BaseStream.Read(array, 0, _wrappedStreamBufferSize);
					if (num4 == 0)
					{
						_wrappedStreamConsumed = true;
						continue;
					}
					Buffer.BlockCopy(array, 0, _inputBuffer, num, num4);
					num += num4;
				}
			}
			return num;
		}
	}
}
