using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Util;
using Amazon.Util.Internal;

namespace Amazon.Runtime.Internal.Util
{
	public class TrailingHeadersWrapperStream : WrapperStream
	{
		private const string STREAM_NEWLINE = "\r\n";

		private const string EMPTY_CHUNK = "0\r\n";

		private const int NEWLINE_LENGTH = 2;

		private const int EMPTY_CHUNK_LENGTH = 3;

		private const int HEADER_ROW_PADDING_LENGTH = 3;

		private Stream _baseStream;

		private HashAlgorithm _hashAlgorithm;

		private IDictionary<string, string> _trailingHeaders;

		private CoreChecksumAlgorithm _checksumAlgorithm;

		private string _prefix;

		private string _suffix;

		private bool _haveFinishedPrefix;

		private bool _haveFinishedStream;

		private bool _haveFinishedSuffix;

		private int _prefixPosition;

		private int _suffixPosition;

		public override long Length => CalculateLength(_trailingHeaders, _checksumAlgorithm, _baseStream.Length);

		public override bool CanSeek => false;

		internal override bool HasLength
		{
			get
			{
				if (_baseStream == null)
				{
					return _trailingHeaders != null;
				}
				return true;
			}
		}

		public TrailingHeadersWrapperStream(Stream baseStream, IDictionary<string, string> trailingHeaders)
			: base(baseStream)
		{
			if (trailingHeaders == null || trailingHeaders.Count == 0)
			{
				throw new AmazonClientException("TrailingHeadersWrapperStream was initialized without any trailing headers.");
			}
			_baseStream = baseStream;
			_trailingHeaders = trailingHeaders;
			_prefix = GenerateContentChunkLength();
		}

		public TrailingHeadersWrapperStream(Stream baseStream, IDictionary<string, string> trailingHeaders, CoreChecksumAlgorithm checksumAlgorithm)
			: this(baseStream, trailingHeaders)
		{
			if (checksumAlgorithm != CoreChecksumAlgorithm.NONE)
			{
				_checksumAlgorithm = checksumAlgorithm;
				_hashAlgorithm = CryptoUtilFactory.GetChecksumInstance(checksumAlgorithm);
			}
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return ReadInternal(buffer, offset, count, useAsyncRead: false, CancellationToken.None).GetAwaiter().GetResult();
		}

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return await ReadInternal(buffer, offset, count, useAsyncRead: true, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		private async Task<int> ReadInternal(byte[] buffer, int offset, int count, bool useAsyncRead, CancellationToken cancellationToken)
		{
			int countRemainingForThisRead = count;
			int countFromPrefix = 0;
			int num = 0;
			int countFromSuffix = 0;
			if (countRemainingForThisRead > 0 && !_haveFinishedPrefix)
			{
				countFromPrefix = ReadFromPrefix(buffer, offset, countRemainingForThisRead);
				offset += countFromPrefix;
				countRemainingForThisRead -= countFromPrefix;
			}
			if (countRemainingForThisRead > 0 && !_haveFinishedStream)
			{
				byte[] thisBuffer = new byte[countRemainingForThisRead];
				num = (useAsyncRead ? (await base.ReadAsync(thisBuffer, 0, countRemainingForThisRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false)) : base.Read(thisBuffer, 0, countRemainingForThisRead));
				if (num != 0)
				{
					if (_hashAlgorithm != null)
					{
						_hashAlgorithm.TransformBlock(thisBuffer, 0, num, thisBuffer, 0);
					}
					Buffer.BlockCopy(thisBuffer, 0, buffer, offset, num);
				}
				else
				{
					if (_hashAlgorithm != null)
					{
						_hashAlgorithm.TransformFinalBlock(ArrayEx.Empty<byte>(), 0, 0);
					}
					_haveFinishedStream = true;
					_suffix = GenerateTrailingHeaderChunk();
				}
				offset += num;
				countRemainingForThisRead -= num;
			}
			if (countRemainingForThisRead > 0 && _haveFinishedStream && !_haveFinishedSuffix)
			{
				countFromSuffix = ReadFromSuffix(buffer, offset, countRemainingForThisRead);
			}
			return countFromPrefix + num + countFromSuffix;
		}

		private string GenerateContentChunkLength()
		{
			return _baseStream.Length.ToString("X", CultureInfo.InvariantCulture) + "\r\n";
		}

		private int ReadFromPrefix(byte[] buffer, int offset, int countRemainingForThisRead)
		{
			int num = _prefix.Length - _prefixPosition;
			if (num <= countRemainingForThisRead)
			{
				Encoding.Default.GetBytes(_prefix, _prefixPosition, num, buffer, offset);
				_haveFinishedPrefix = true;
				return num;
			}
			Encoding.Default.GetBytes(_prefix, _prefixPosition, countRemainingForThisRead, buffer, offset);
			_prefixPosition += countRemainingForThisRead;
			return countRemainingForThisRead;
		}

		private string GenerateTrailingHeaderChunk()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("\r\n");
			stringBuilder.Append("0\r\n");
			foreach (KeyValuePair<string, string> item in _trailingHeaders.OrderBy((KeyValuePair<string, string> kvp) => kvp.Key))
			{
				if (_checksumAlgorithm != CoreChecksumAlgorithm.NONE && ChecksumUtils.GetChecksumHeaderKey(_checksumAlgorithm) == item.Key)
				{
					stringBuilder.Append(item.Key + ":" + Convert.ToBase64String(_hashAlgorithm.Hash) + "\r\n");
				}
				else
				{
					stringBuilder.Append(item.Key + ":" + item.Value + "\r\n");
				}
			}
			stringBuilder.Append("\r\n");
			return stringBuilder.ToString();
		}

		private int ReadFromSuffix(byte[] buffer, int offset, int countRemainingForThisRead)
		{
			int num = _suffix.Length - _suffixPosition;
			if (num <= countRemainingForThisRead)
			{
				Encoding.Default.GetBytes(_suffix, _suffixPosition, num, buffer, offset);
				_haveFinishedSuffix = true;
				return num;
			}
			Encoding.Default.GetBytes(_suffix, _suffixPosition, countRemainingForThisRead, buffer, offset);
			_suffixPosition += countRemainingForThisRead;
			return countRemainingForThisRead;
		}

		public static long CalculateLength(IDictionary<string, string> trailingHeaders, CoreChecksumAlgorithm checksumAlgorithm, long baseStreamLength)
		{
			int length = baseStreamLength.ToString("X", CultureInfo.InvariantCulture).Length;
			int num = 0;
			if (trailingHeaders != null)
			{
				foreach (string key in trailingHeaders.Keys)
				{
					num = ((checksumAlgorithm == CoreChecksumAlgorithm.NONE || !(ChecksumUtils.GetChecksumHeaderKey(checksumAlgorithm) == key)) ? (num + (key.Length + trailingHeaders[key].Length + 3)) : (num + (key.Length + CryptoUtilFactory.GetChecksumBase64Length(checksumAlgorithm) + 3)));
				}
			}
			return length + 2 + baseStreamLength + 2 + 3 + num + 2;
		}
	}
}
