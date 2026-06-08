using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Amazon.Runtime.Internal.Transform;
using Amazon.Util;

namespace Amazon.Runtime.Internal.Util
{
	public static class ChecksumUtils
	{
		private const string _checksumHeaderPrefix = "x-amz-checksum-";

		private static readonly List<CoreChecksumAlgorithm> _responseChecksumsInPriorityOrder = new List<CoreChecksumAlgorithm>
		{
			CoreChecksumAlgorithm.CRC32,
			CoreChecksumAlgorithm.SHA1,
			CoreChecksumAlgorithm.SHA256
		};

		public static CoreChecksumAlgorithm DefaultAlgorithm => CoreChecksumAlgorithm.CRC32;

		internal static string GetChecksumHeaderKey(CoreChecksumAlgorithm checksumAlgorithm)
		{
			return "x-amz-checksum-" + checksumAlgorithm.ToString().ToLower();
		}

		public static void SetRequestChecksumV2(IRequest request, IClientConfig clientConfig)
		{
			if (request == null)
			{
				throw new ArgumentNullException("request");
			}
			if (request.ChecksumData == null)
			{
				throw new ArgumentException("Request checksum data cannot be null", "request");
			}
			if (request.Headers.Any((KeyValuePair<string, string> h) => h.Key.StartsWith("x-amz-checksum-", StringComparison.OrdinalIgnoreCase)))
			{
				return;
			}
			CoreChecksumAlgorithm coreChecksumAlgorithm = ConvertToCoreChecksumAlgorithm(request.ChecksumData.SelectedChecksum);
			if (coreChecksumAlgorithm == CoreChecksumAlgorithm.NONE)
			{
				if (request.ChecksumData.FallbackToMD5 == true)
				{
					SetRequestChecksumMD5(request);
					return;
				}
				coreChecksumAlgorithm = DefaultAlgorithm;
			}
			if (clientConfig != null && (clientConfig.RequestChecksumCalculation != RequestChecksumCalculation.WHEN_REQUIRED || request.ChecksumData.IsRequestChecksumRequired))
			{
				string checksumHeaderKey = GetChecksumHeaderKey(coreChecksumAlgorithm);
				request.SelectedChecksum = coreChecksumAlgorithm;
				if (request.UseChunkEncoding || request.DisablePayloadSigning == true)
				{
					request.TrailingHeaders[checksumHeaderKey] = string.Empty;
				}
				else
				{
					request.Headers[checksumHeaderKey] = CalculateChecksumForRequest(CryptoUtilFactory.GetChecksumInstance(coreChecksumAlgorithm), request);
				}
				string headerName = request.ChecksumData.HeaderName;
				if (!string.IsNullOrEmpty(headerName) && !request.Headers.TryGetValue(headerName, out var _))
				{
					request.Headers[headerName] = coreChecksumAlgorithm.ToString();
				}
			}
		}

		public static void SetRequestChecksumMD5(IRequest request)
		{
			if (!request.Headers.TryGetValue("Content-MD5", out var value) || string.IsNullOrEmpty(value))
			{
				request.Headers["Content-MD5"] = ((request.ContentStream != null) ? AWSSDKUtils.GenerateMD5ChecksumForStream(request.ContentStream) : AWSSDKUtils.GenerateChecksumForBytes(request.Content, fBase64Encode: true));
			}
		}

		private static string CalculateChecksumForRequest(HashAlgorithm algorithm, IRequest request)
		{
			if (request.ContentStream != null)
			{
				Stream stream = WrapperStream.SearchWrappedStream(request.ContentStream, (Stream s) => s.CanSeek);
				if (stream != null)
				{
					long position = stream.Position;
					byte[] inArray = algorithm.ComputeHash(stream);
					stream.Seek(position, SeekOrigin.Begin);
					return Convert.ToBase64String(inArray);
				}
				throw new ArgumentException("Request must have a seekable content stream to calculate checksum");
			}
			if (request.Content != null)
			{
				return Convert.ToBase64String(algorithm.ComputeHash(request.Content));
			}
			return string.Empty;
		}

		public static CoreChecksumAlgorithm SelectChecksumForResponseValidation(ICollection<CoreChecksumAlgorithm> operationSupportedChecksums, IWebResponseData responseData)
		{
			if (operationSupportedChecksums == null || operationSupportedChecksums.Count == 0 || responseData == null)
			{
				return CoreChecksumAlgorithm.NONE;
			}
			foreach (CoreChecksumAlgorithm item in _responseChecksumsInPriorityOrder)
			{
				if (operationSupportedChecksums.Contains(item))
				{
					string checksumHeaderKey = GetChecksumHeaderKey(item);
					if (responseData.IsHeaderPresent(checksumHeaderKey) && !IsChecksumValueMultipartGet(responseData.GetHeaderValue(checksumHeaderKey)))
					{
						return item;
					}
				}
			}
			return CoreChecksumAlgorithm.NONE;
		}

		private static bool IsChecksumValueMultipartGet(string checksumValue)
		{
			if (string.IsNullOrEmpty(checksumValue))
			{
				return false;
			}
			int num = checksumValue.LastIndexOf('-');
			if (num == -1)
			{
				return false;
			}
			if (!int.TryParse(checksumValue.Substring(num + 1), out var result))
			{
				return false;
			}
			if (result >= 1 && result <= 10000)
			{
				return true;
			}
			return false;
		}

		private static CoreChecksumAlgorithm ConvertToCoreChecksumAlgorithm(string selectedServiceChecksum)
		{
			if (string.IsNullOrEmpty(selectedServiceChecksum))
			{
				return CoreChecksumAlgorithm.NONE;
			}
			if (!Enum.TryParse<CoreChecksumAlgorithm>(selectedServiceChecksum, ignoreCase: true, out var result))
			{
				throw new AmazonClientException("Attempted to sign a request with an unknown checksum algorithm " + selectedServiceChecksum);
			}
			return result;
		}

		public static void SetChecksumData(IRequest request, string checksumAlgorithm, bool fallbackToMD5, bool isRequestChecksumRequired)
		{
			SetChecksumData(request, checksumAlgorithm, fallbackToMD5, isRequestChecksumRequired, null);
		}

		public static void SetChecksumData(IRequest request, string checksumAlgorithm, bool fallbackToMD5, bool isRequestChecksumRequired, string headerName)
		{
			request.ChecksumData = new ChecksumData(checksumAlgorithm, MD5Checksum: false, fallbackToMD5, isRequestChecksumRequired, headerName);
		}

		public static void SetChecksumData(IRequest request)
		{
			request.ChecksumData = new ChecksumData(null, MD5Checksum: true, null, isRequestChecksumRequired: true, null);
		}
	}
}
