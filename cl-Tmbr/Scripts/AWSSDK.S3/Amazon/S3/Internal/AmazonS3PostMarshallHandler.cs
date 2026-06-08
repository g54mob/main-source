using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.UserAgent;
using Amazon.Runtime.Internal.Util;
using Amazon.S3.Model;
using Amazon.S3.Util;

namespace Amazon.S3.Internal
{
	public class AmazonS3PostMarshallHandler : PipelineHandler
	{
		public override void InvokeSync(IExecutionContext executionContext)
		{
			PreInvoke(executionContext);
			base.InvokeSync(executionContext);
		}

		public override Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			PreInvoke(executionContext);
			return base.InvokeAsync<T>(executionContext);
		}

		protected virtual void PreInvoke(IExecutionContext executionContext)
		{
			ProcessPreRequestHandlers(executionContext);
		}

		private static void ProcessPreRequestHandlers(IExecutionContext executionContext)
		{
			if (executionContext.RequestContext.Request.IsDirectoryBucket())
			{
				executionContext.RequestContext.UserAgentDetails.AddFeature(UserAgentFeatureId.S3_EXPRESS_BUCKET);
			}
			if (SetStreamChecksum(executionContext.RequestContext.OriginalRequest, executionContext.RequestContext.Request))
			{
				return;
			}
			ChecksumData checksumData = executionContext.RequestContext.Request.ChecksumData;
			bool flag = checksumData != null && (checksumData.IsMD5Checksum || checksumData.FallbackToMD5 == true);
			bool flag2 = checksumData != null && checksumData.SelectedChecksum != null;
			if (executionContext.RequestContext.Request.IsDirectoryBucket() && flag && !flag2)
			{
				if (executionContext.RequestContext.OriginalRequest is InitiateMultipartUploadRequest || executionContext.RequestContext.OriginalRequest is CompleteMultipartUploadRequest)
				{
					executionContext.RequestContext.Request.ChecksumData = null;
					return;
				}
				executionContext.RequestContext.Request.ChecksumData.SelectedChecksum = ChecksumAlgorithm.CRC32;
				executionContext.RequestContext.Request.ChecksumData.IsMD5Checksum = false;
				executionContext.RequestContext.Request.ChecksumData.FallbackToMD5 = false;
			}
		}

		private static bool SetStreamChecksum(AmazonWebServiceRequest originalRequest, IRequest request)
		{
			if (originalRequest is PutObjectRequest putObjectRequest)
			{
				SetStreamChecksum(putObjectRequest, request);
				return true;
			}
			if (originalRequest is UploadPartRequest uploadPartRequest)
			{
				SetStreamChecksum(uploadPartRequest, request);
				return true;
			}
			return false;
		}

		private static void SetStreamChecksum(UploadPartRequest uploadPartRequest, IRequest request)
		{
			if (uploadPartRequest.InputStream != null)
			{
				PartialWrapperStream partialWrapperStream = new PartialWrapperStream(uploadPartRequest.InputStream, uploadPartRequest.PartSize.GetValueOrDefault());
				if (partialWrapperStream.Length > 0 && uploadPartRequest.DisablePayloadSigning != true)
				{
					request.UseChunkEncoding = uploadPartRequest.UseChunkEncoding;
				}
				if (!request.Headers.ContainsKey("Content-Length"))
				{
					request.Headers.Add("Content-Length", partialWrapperStream.Length.ToString(CultureInfo.InvariantCulture));
				}
				request.DisablePayloadSigning = uploadPartRequest.DisablePayloadSigning;
				uploadPartRequest.InputStream = partialWrapperStream;
			}
			if (!(uploadPartRequest.DisableDefaultChecksumValidation ?? AWSConfigsS3.DisableDefaultChecksumValidation))
			{
				ChecksumUtils.SetChecksumData(request, uploadPartRequest.ChecksumAlgorithm, fallbackToMD5: false, isRequestChecksumRequired: false, S3Constants.AmzHeaderSdkChecksumAlgorithm);
			}
			request.ContentStream = uploadPartRequest.InputStream;
		}

		private static void SetStreamChecksum(PutObjectRequest putObjectRequest, IRequest request)
		{
			if (putObjectRequest.InputStream != null)
			{
				Stream streamWithLength = GetStreamWithLength(putObjectRequest.InputStream, putObjectRequest.Headers.ContentLength);
				if (streamWithLength.Length > 0 && putObjectRequest.DisablePayloadSigning != true)
				{
					request.UseChunkEncoding = putObjectRequest.UseChunkEncoding;
				}
				long num = streamWithLength.Length - streamWithLength.Position;
				if (!request.Headers.ContainsKey("Content-Length"))
				{
					request.Headers.Add("Content-Length", num.ToString(CultureInfo.InvariantCulture));
				}
				request.DisablePayloadSigning = putObjectRequest.DisablePayloadSigning;
				putObjectRequest.InputStream = streamWithLength;
			}
			if (!(putObjectRequest.DisableDefaultChecksumValidation ?? AWSConfigsS3.DisableDefaultChecksumValidation))
			{
				ChecksumUtils.SetChecksumData(request, putObjectRequest.ChecksumAlgorithm, fallbackToMD5: false, isRequestChecksumRequired: false, S3Constants.AmzHeaderSdkChecksumAlgorithm);
			}
			request.ContentStream = putObjectRequest.InputStream;
		}

		private static Stream GetStreamWithLength(Stream baseStream, long hintLength)
		{
			Stream result = baseStream;
			bool flag = false;
			long num = -1L;
			try
			{
				num = baseStream.Length - baseStream.Position;
			}
			catch (NotSupportedException)
			{
				flag = true;
				num = hintLength;
			}
			if (num < 0)
			{
				throw new AmazonS3Exception("Could not determine content length");
			}
			if (flag)
			{
				result = new PartialReadOnlyWrapperStream(baseStream, num);
			}
			return result;
		}
	}
}
