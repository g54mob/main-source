using System;
using System.IO;
using System.Text;
using Amazon.Runtime.Internal.Util;
using Amazon.Util.Internal;
using ThirdParty.Ionic.Zlib;

namespace Amazon.Runtime.Internal.Transform
{
	public abstract class UnmarshallerContext : IDisposable
	{
		private bool disposed;

		protected bool MaintainResponseBody { get; set; }

		protected bool IsException { get; set; }

		protected CrcCalculatorStream CrcStream { get; set; }

		protected int Crc32Result { get; set; }

		protected CoreChecksumAlgorithm ChecksumAlgorithm { get; set; }

		protected HashStream FlexibleChecksumStream { get; set; }

		protected string ExpectedFlexibleChecksumResult { get; set; }

		protected IWebResponseData WebResponseData { get; set; }

		protected CachingWrapperStream WrappingStream { get; set; }

		public bool IsEmptyResponse { get; protected set; }

		public string ResponseBody
		{
			get
			{
				byte[] responseBodyBytes = GetResponseBodyBytes();
				return Encoding.UTF8.GetString(responseBodyBytes, 0, responseBodyBytes.Length);
			}
		}

		public IWebResponseData ResponseData => WebResponseData;

		public abstract string CurrentPath { get; }

		public abstract int CurrentDepth { get; }

		public abstract bool IsStartElement { get; }

		public abstract bool IsEndElement { get; }

		public abstract bool IsStartOfDocument { get; }

		public byte[] GetResponseBodyBytes()
		{
			if (IsException)
			{
				return WrappingStream.AllReadBytes.ToArray();
			}
			if (MaintainResponseBody)
			{
				return WrappingStream.LoggableReadBytes.ToArray();
			}
			return ArrayEx.Empty<byte>();
		}

		internal void ValidateCRC32IfAvailable()
		{
			if (CrcStream != null && CrcStream.Crc32 != Crc32Result)
			{
				throw new IOException("CRC value returned with response does not match the computed CRC value for the returned response body.");
			}
		}

		internal void ValidateFlexibleCheckumsIfAvailable(ResponseMetadata responseMetadata)
		{
			if (FlexibleChecksumStream == null)
			{
				return;
			}
			responseMetadata.ChecksumAlgorithm = ChecksumAlgorithm;
			responseMetadata.ChecksumValidationStatus = ChecksumValidationStatus.PENDING_RESPONSE_READ;
			if (FlexibleChecksumStream.CalculatedHash != null)
			{
				if (Convert.ToBase64String(FlexibleChecksumStream.CalculatedHash) != ExpectedFlexibleChecksumResult)
				{
					responseMetadata.ChecksumValidationStatus = ChecksumValidationStatus.INVALID;
					throw new AmazonClientException("Expected hash not equal to calculated hash");
				}
				responseMetadata.ChecksumValidationStatus = ChecksumValidationStatus.SUCCESSFUL;
			}
		}

		protected void SetupCRCStream(IWebResponseData responseData, Stream responseStream, long contentLength)
		{
			CrcStream = null;
			if (responseData != null && uint.TryParse(responseData.GetHeaderValue("x-amz-crc32"), out var result))
			{
				Crc32Result = (int)result;
				CrcStream = new CrcCalculatorStream(responseStream, contentLength);
			}
		}

		protected void SetupFlexibleChecksumStream(IWebResponseData responseData, Stream responseStream, long contentLength, IRequestContext requestContext)
		{
			CoreChecksumAlgorithm coreChecksumAlgorithm = ChecksumUtils.SelectChecksumForResponseValidation(requestContext?.OriginalRequest?.ChecksumResponseAlgorithms, responseData);
			if (coreChecksumAlgorithm != CoreChecksumAlgorithm.NONE)
			{
				ChecksumAlgorithm = coreChecksumAlgorithm;
				ExpectedFlexibleChecksumResult = responseData.GetHeaderValue(ChecksumUtils.GetChecksumHeaderKey(coreChecksumAlgorithm));
				byte[] expectedHash = Convert.FromBase64String(ExpectedFlexibleChecksumResult);
				switch (coreChecksumAlgorithm)
				{
				case CoreChecksumAlgorithm.CRC64NVME:
					FlexibleChecksumStream = new HashStream<HashingWrapperCRC64NVME>(responseStream, expectedHash, contentLength);
					break;
				case CoreChecksumAlgorithm.CRC32C:
					FlexibleChecksumStream = new HashStream<HashingWrapperCRC32C>(responseStream, expectedHash, contentLength);
					break;
				case CoreChecksumAlgorithm.CRC32:
					FlexibleChecksumStream = new HashStream<HashingWrapperCRC32>(responseStream, expectedHash, contentLength);
					break;
				case CoreChecksumAlgorithm.SHA256:
					FlexibleChecksumStream = new HashStream<HashingWrapperSHA256>(responseStream, expectedHash, contentLength);
					break;
				case CoreChecksumAlgorithm.SHA1:
					FlexibleChecksumStream = new HashStream<HashingWrapperSHA1>(responseStream, expectedHash, contentLength);
					break;
				default:
					throw new AmazonClientException($"Unsupported checksum algorithm {coreChecksumAlgorithm}");
				}
			}
		}

		public bool TestExpression(string expression)
		{
			return TestExpression(expression, CurrentPath);
		}

		public bool TestExpression(string expression, int startingStackDepth)
		{
			return TestExpression(expression, startingStackDepth, CurrentPath, CurrentDepth);
		}

		private static bool TestExpression(string expression, string currentPath)
		{
			if (expression.Equals("."))
			{
				return true;
			}
			return currentPath.EndsWith(expression, StringComparison.OrdinalIgnoreCase);
		}

		private static bool TestExpression(string expression, int startingStackDepth, string currentPath, int currentDepth)
		{
			if (expression.Equals("."))
			{
				return true;
			}
			int num = -1;
			while ((num = expression.IndexOf("/", num + 1, StringComparison.Ordinal)) > -1)
			{
				if (expression[0] != '@')
				{
					startingStackDepth++;
				}
			}
			if (startingStackDepth == currentDepth && currentPath.Length > expression.Length && currentPath[currentPath.Length - expression.Length - 1] == '/')
			{
				return currentPath.EndsWith(expression, StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposed)
			{
				return;
			}
			if (disposing)
			{
				if (CrcStream != null)
				{
					CrcStream.Dispose();
					CrcStream = null;
				}
				if (WrappingStream != null)
				{
					WrappingStream.Dispose();
					WrappingStream = null;
				}
			}
			disposed = true;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
