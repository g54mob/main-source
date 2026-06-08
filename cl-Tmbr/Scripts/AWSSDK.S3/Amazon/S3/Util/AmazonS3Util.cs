using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Amazon.Runtime.Endpoints;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Util;
using Amazon.S3.Model;
using Amazon.S3.Model.Internal.MarshallTransformations;
using Amazon.Util;

namespace Amazon.S3.Util
{
	public static class AmazonS3Util
	{
		private static Dictionary<string, string> extensionToMime = new Dictionary<string, string>(200, StringComparer.OrdinalIgnoreCase)
		{
			{ ".ai", "application/postscript" },
			{ ".aif", "audio/x-aiff" },
			{ ".aifc", "audio/x-aiff" },
			{ ".aiff", "audio/x-aiff" },
			{ ".asc", "text/plain" },
			{ ".au", "audio/basic" },
			{ ".avi", "video/x-msvideo" },
			{ ".bcpio", "application/x-bcpio" },
			{ ".bin", "application/octet-stream" },
			{ ".c", "text/plain" },
			{ ".cc", "text/plain" },
			{ ".ccad", "application/clariscad" },
			{ ".cdf", "application/x-netcdf" },
			{ ".class", "application/octet-stream" },
			{ ".cpio", "application/x-cpio" },
			{ ".cpp", "text/plain" },
			{ ".cpt", "application/mac-compactpro" },
			{ ".cs", "text/plain" },
			{ ".csh", "application/x-csh" },
			{ ".css", "text/css" },
			{ ".csv", "text/csv" },
			{ ".dcr", "application/x-director" },
			{ ".dir", "application/x-director" },
			{ ".dms", "application/octet-stream" },
			{ ".doc", "application/msword" },
			{ ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
			{ ".dot", "application/msword" },
			{ ".drw", "application/drafting" },
			{ ".dvi", "application/x-dvi" },
			{ ".dwg", "application/acad" },
			{ ".dxf", "application/dxf" },
			{ ".dxr", "application/x-director" },
			{ ".eps", "application/postscript" },
			{ ".etx", "text/x-setext" },
			{ ".exe", "application/octet-stream" },
			{ ".ez", "application/andrew-inset" },
			{ ".f", "text/plain" },
			{ ".f90", "text/plain" },
			{ ".fli", "video/x-fli" },
			{ ".gif", "image/gif" },
			{ ".gtar", "application/x-gtar" },
			{ ".gz", "application/x-gzip" },
			{ ".h", "text/plain" },
			{ ".hdf", "application/x-hdf" },
			{ ".hh", "text/plain" },
			{ ".hqx", "application/mac-binhex40" },
			{ ".htm", "text/html" },
			{ ".html", "text/html" },
			{ ".ice", "x-conference/x-cooltalk" },
			{ ".ief", "image/ief" },
			{ ".iges", "model/iges" },
			{ ".igs", "model/iges" },
			{ ".ips", "application/x-ipscript" },
			{ ".ipx", "application/x-ipix" },
			{ ".jpe", "image/jpeg" },
			{ ".jpeg", "image/jpeg" },
			{ ".jpg", "image/jpeg" },
			{ ".js", "application/x-javascript" },
			{ ".json", "application/json" },
			{ ".kar", "audio/midi" },
			{ ".latex", "application/x-latex" },
			{ ".lha", "application/octet-stream" },
			{ ".lsp", "application/x-lisp" },
			{ ".lzh", "application/octet-stream" },
			{ ".m", "text/plain" },
			{ ".m3u8", "application/x-mpegURL" },
			{ ".man", "application/x-troff-man" },
			{ ".me", "application/x-troff-me" },
			{ ".mesh", "model/mesh" },
			{ ".mid", "audio/midi" },
			{ ".midi", "audio/midi" },
			{ ".mime", "www/mime" },
			{ ".mov", "video/quicktime" },
			{ ".movie", "video/x-sgi-movie" },
			{ ".mp2", "audio/mpeg" },
			{ ".mp3", "audio/mpeg" },
			{ ".mpe", "video/mpeg" },
			{ ".mpeg", "video/mpeg" },
			{ ".mpg", "video/mpeg" },
			{ ".mpga", "audio/mpeg" },
			{ ".ms", "application/x-troff-ms" },
			{ ".msi", "application/x-ole-storage" },
			{ ".msh", "model/mesh" },
			{ ".nc", "application/x-netcdf" },
			{ ".oda", "application/oda" },
			{ ".pbm", "image/x-portable-bitmap" },
			{ ".pdb", "chemical/x-pdb" },
			{ ".pdf", "application/pdf" },
			{ ".pgm", "image/x-portable-graymap" },
			{ ".pgn", "application/x-chess-pgn" },
			{ ".png", "image/png" },
			{ ".pnm", "image/x-portable-anymap" },
			{ ".pot", "application/mspowerpoint" },
			{ ".ppm", "image/x-portable-pixmap" },
			{ ".pps", "application/mspowerpoint" },
			{ ".ppt", "application/mspowerpoint" },
			{ ".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation" },
			{ ".ppz", "application/mspowerpoint" },
			{ ".pre", "application/x-freelance" },
			{ ".prt", "application/pro_eng" },
			{ ".ps", "application/postscript" },
			{ ".qt", "video/quicktime" },
			{ ".ra", "audio/x-realaudio" },
			{ ".ram", "audio/x-pn-realaudio" },
			{ ".ras", "image/cmu-raster" },
			{ ".rgb", "image/x-rgb" },
			{ ".rm", "audio/x-pn-realaudio" },
			{ ".roff", "application/x-troff" },
			{ ".rpm", "audio/x-pn-realaudio-plugin" },
			{ ".rtf", "text/rtf" },
			{ ".rtx", "text/richtext" },
			{ ".scm", "application/x-lotusscreencam" },
			{ ".set", "application/set" },
			{ ".sgm", "text/sgml" },
			{ ".sgml", "text/sgml" },
			{ ".sh", "application/x-sh" },
			{ ".shar", "application/x-shar" },
			{ ".silo", "model/mesh" },
			{ ".sit", "application/x-stuffit" },
			{ ".skd", "application/x-koan" },
			{ ".skm", "application/x-koan" },
			{ ".skp", "application/x-koan" },
			{ ".skt", "application/x-koan" },
			{ ".smi", "application/smil" },
			{ ".smil", "application/smil" },
			{ ".snd", "audio/basic" },
			{ ".sol", "application/solids" },
			{ ".spl", "application/x-futuresplash" },
			{ ".src", "application/x-wais-source" },
			{ ".step", "application/STEP" },
			{ ".stl", "application/SLA" },
			{ ".stp", "application/STEP" },
			{ ".sv4cpio", "application/x-sv4cpio" },
			{ ".sv4crc", "application/x-sv4crc" },
			{ ".svg", "image/svg+xml" },
			{ ".swf", "application/x-shockwave-flash" },
			{ ".t", "application/x-troff" },
			{ ".tar", "application/x-tar" },
			{ ".tcl", "application/x-tcl" },
			{ ".tex", "application/x-tex" },
			{ ".tif", "image/tiff" },
			{ ".tiff", "image/tiff" },
			{ ".tr", "application/x-troff" },
			{ ".ts", "video/MP2T" },
			{ ".tsi", "audio/TSP-audio" },
			{ ".tsp", "application/dsptype" },
			{ ".tsv", "text/tab-separated-values" },
			{ ".txt", "text/plain" },
			{ ".unv", "application/i-deas" },
			{ ".ustar", "application/x-ustar" },
			{ ".vcd", "application/x-cdlink" },
			{ ".vda", "application/vda" },
			{ ".vrml", "model/vrml" },
			{ ".wav", "audio/x-wav" },
			{ ".wrl", "model/vrml" },
			{ ".xbm", "image/x-xbitmap" },
			{ ".xlc", "application/vnd.ms-excel" },
			{ ".xll", "application/vnd.ms-excel" },
			{ ".xlm", "application/vnd.ms-excel" },
			{ ".xls", "application/vnd.ms-excel" },
			{ ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
			{ ".xlw", "application/vnd.ms-excel" },
			{ ".xml", "text/xml" },
			{ ".xpm", "image/x-xpixmap" },
			{ ".xwd", "image/x-xwindowdump" },
			{ ".xyz", "chemical/x-pdb" },
			{ ".zip", "application/zip" },
			{ ".m4v", "video/x-m4v" },
			{ ".webm", "video/webm" },
			{ ".ogv", "video/ogv" },
			{ ".xap", "application/x-silverlight-app" },
			{ ".mp4", "video/mp4" },
			{ ".wmv", "video/x-ms-wmv" }
		};

		private const string IPv4RegexPattern = "^[0-9]+\\.[0-9]+\\.[0-9]+\\.[0-9]+$";

		private const string LabelRegexPattern = "^[a-z0-9]([a-z0-9\\-]*[a-z0-9])?$";

		private static readonly Regex _ipV4Regex = new Regex("^[0-9]+\\.[0-9]+\\.[0-9]+\\.[0-9]+$");

		private static readonly Regex _labelRegex = new Regex("^[a-z0-9]([a-z0-9\\-]*[a-z0-9])?$");

		private const string OngoingRequestRegexPattern = "ongoing-request=\"(.+?)\"";

		private const string ExpiryDateRegexPattern = "expiry-date=\"(.+?)\"";

		private static readonly Regex _ongoingRequestRegex = new Regex("ongoing-request=\"(.+?)\"");

		private static readonly Regex _expiryDateRegex = new Regex("expiry-date=\"(.+?)\"");

		public static string FormattedCurrentTimestamp => AWSSDKUtils.FormattedCurrentTimestampGMT;

		public static string MimeTypeFromExtension(string ext)
		{
			if (extensionToMime.TryGetValue(ext, out var value))
			{
				return value;
			}
			return "application/octet-stream";
		}

		public static Stream MakeStreamSeekable(Stream input)
		{
			MemoryStream memoryStream = new MemoryStream();
			byte[] buffer = new byte[32768];
			int num = 0;
			using (input)
			{
				while ((num = input.Read(buffer, 0, 32768)) > 0)
				{
					memoryStream.Write(buffer, 0, num);
				}
			}
			memoryStream.Position = 0L;
			return memoryStream;
		}

		public static string GenerateMD5ChecksumForStream(Stream input)
		{
			return AWSSDKUtils.GenerateMD5ChecksumForStream(input);
		}

		public static string GenerateChecksumForContent(string content, bool fBase64Encode)
		{
			return AWSSDKUtils.GenerateChecksumForContent(content, fBase64Encode);
		}

		internal static string ComputeEncodedMD5FromEncodedString(string base64EncodedString)
		{
			byte[] data = Convert.FromBase64String(base64EncodedString);
			return Convert.ToBase64String(CryptoUtilFactory.CryptoInstance.ComputeMD5Hash(data));
		}

		internal static void SetMetadataHeaders(IRequest request, MetadataCollection metadata)
		{
			foreach (string key in metadata.Keys)
			{
				request.Headers[key] = (AWSConfigsS3.EnableUnicodeEncodingForObjectMetadata ? EscapeNonAscii(metadata[key]) : metadata[key]);
			}
		}

		private static string EscapeNonAscii(string text)
		{
			StringBuilder stringBuilder = new StringBuilder("");
			if (text != null)
			{
				for (int i = 0; i < text.Length; i++)
				{
					char c = text[i];
					stringBuilder.Append((c > '\u007f') ? Uri.EscapeDataString(c.ToString()) : c.ToString());
				}
			}
			return stringBuilder.ToString();
		}

		public static bool IsDirectoryBucket(this IRequest request)
		{
			object obj = request.EndpointAttributes["backend"];
			if (obj == null)
			{
				return false;
			}
			return (string)obj == "S3Express";
		}

		public static bool UseS3ExpressSessionAuth(this IRequest request)
		{
			IList list = (IList)request.EndpointAttributes["authSchemes"];
			if (list != null)
			{
				foreach (PropertyBag item in list)
				{
					if ((string)item["name"] == "sigv4-s3express")
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool ValidateV2Bucket(string bucketName)
		{
			if (string.IsNullOrEmpty(bucketName))
			{
				throw new ArgumentNullException("bucketName", "Please specify a bucket name");
			}
			if (bucketName.StartsWith("s3.amazonaws.com", StringComparison.Ordinal))
			{
				return false;
			}
			int num = bucketName.IndexOf(".s3.amazonaws.com", StringComparison.Ordinal);
			if (num > 0)
			{
				bucketName = bucketName.Substring(0, num);
			}
			if (bucketName.Length < 3 || bucketName.Length > 63 || bucketName.StartsWith(".", StringComparison.Ordinal) || bucketName.EndsWith(".", StringComparison.Ordinal))
			{
				return false;
			}
			if (IPv4Regex().IsMatch(bucketName))
			{
				return false;
			}
			string[] array = bucketName.Split("\\.".ToCharArray());
			foreach (string input in array)
			{
				if (!LabelRegex().IsMatch(input))
				{
					return false;
				}
			}
			return true;
		}

		private static Regex IPv4Regex()
		{
			return _ipV4Regex;
		}

		private static Regex LabelRegex()
		{
			return _labelRegex;
		}

		internal static void AddQueryStringParameter(StringBuilder queryString, string parameterName, string parameterValue)
		{
			AddQueryStringParameter(queryString, parameterName, parameterValue, null);
		}

		internal static void AddQueryStringParameter(StringBuilder queryString, string parameterName, string parameterValue, IDictionary<string, string> parameterMap)
		{
			if (queryString.Length > 0)
			{
				queryString.Append("&");
			}
			queryString.AppendFormat("{0}={1}", AWSSDKUtils.UrlEncode(parameterName, path: false), AWSSDKUtils.UrlEncode(parameterValue, path: false));
			parameterMap?.Add(parameterName, parameterValue);
		}

		internal static string TagSetToQueryString(List<Tag> tags)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Tag tag in tags)
			{
				AddQueryStringParameter(stringBuilder, tag.Key, tag.Value);
			}
			return stringBuilder.ToString();
		}

		internal static void SerializeTagToXml(XmlWriter xmlWriter, Tag tag)
		{
			xmlWriter.WriteStartElement("Tag");
			if (tag.IsSetKey())
			{
				xmlWriter.WriteElementString("Key", S3Transforms.ToXmlStringValue(tag.Key));
			}
			if (tag.IsSetValue())
			{
				xmlWriter.WriteElementString("Value", S3Transforms.ToXmlStringValue(tag.Value));
			}
			xmlWriter.WriteEndElement();
		}

		internal static void SerializeTagSetToXml(XmlWriter xmlWriter, List<Tag> tagset)
		{
			xmlWriter.WriteStartElement("TagSet");
			if (tagset != null && tagset.Count > 0)
			{
				foreach (Tag item in tagset)
				{
					SerializeTagToXml(xmlWriter, item);
				}
			}
			xmlWriter.WriteEndElement();
		}

		internal static string SerializeTaggingToXml(Tagging tagging)
		{
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				xmlWriter.WriteStartElement("Tagging", "http://s3.amazonaws.com/doc/2006-03-01/");
				if (tagging.TagSet != null)
				{
					SerializeTagSetToXml(xmlWriter, tagging.TagSet);
				}
				xmlWriter.WriteEndElement();
			}
			return xMLEncodedStringWriter.ToString();
		}

		private static Regex OngoingRequestRegex()
		{
			return _ongoingRequestRegex;
		}

		private static Regex ExpiryDateRegex()
		{
			return _expiryDateRegex;
		}

		internal static void ParseAmzRestoreHeader(string header, out bool restoreInProgress, out DateTime? restoreExpiration)
		{
			restoreExpiration = null;
			restoreInProgress = false;
			if (header != null)
			{
				Match match = OngoingRequestRegex().Match(header);
				if (match.Success && match.Groups[1].Success && bool.TryParse(match.Groups[1].Value, out var result))
				{
					restoreInProgress = result;
				}
				Match match2 = ExpiryDateRegex().Match(header);
				if (match2.Success && match2.Groups[1].Success && DateTime.TryParseExact(match2.Groups[1].Value, "ddd, dd MMM yyyy HH:mm:ss \\G\\M\\T", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out var result2))
				{
					restoreExpiration = result2;
				}
			}
		}

		internal static bool IsInstructionFile(string key)
		{
			if (!key.EndsWith("INSTRUCTION_SUFFIX", StringComparison.Ordinal))
			{
				return key.EndsWith(".instruction", StringComparison.Ordinal);
			}
			return true;
		}

		internal static bool ResourcePathContainsOutpostsResource(IRequest request)
		{
			char[] separators = new char[2] { '/', '?' };
			Func<string, bool> IsOutpostResource = (string p) => Arn.IsArn(p) && Arn.Parse(p).IsOutpostArn();
			if (!IsOutpostResource(request.ResourcePath.Trim().Trim(separators)))
			{
				return request.PathResources.Any((KeyValuePair<string, string> pr) => IsOutpostResource(pr.Value.Trim().Trim(separators)));
			}
			return true;
		}

		public static async Task<bool> DoesS3BucketExistV2Async(IAmazonS3 s3Client, string bucketName)
		{
			try
			{
				await s3Client.GetBucketAclAsync(new GetBucketAclRequest
				{
					BucketName = bucketName
				}).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (AmazonS3Exception ex)
			{
				switch (ex.ErrorCode)
				{
				case "AccessDenied":
				case "PermanentRedirect":
					return true;
				case "NoSuchBucket":
					return false;
				default:
					throw;
				}
			}
			return true;
		}

		public static Task DeleteS3BucketWithObjectsAsync(IAmazonS3 s3Client, string bucketName)
		{
			CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
			return DeleteS3BucketWithObjectsAsync(s3Client, bucketName, cancellationTokenSource.Token);
		}

		public static Task DeleteS3BucketWithObjectsAsync(IAmazonS3 s3Client, string bucketName, S3DeleteBucketWithObjectsOptions deleteOptions)
		{
			CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
			return DeleteS3BucketWithObjectsAsync(s3Client, bucketName, deleteOptions, cancellationTokenSource.Token);
		}

		public static Task DeleteS3BucketWithObjectsAsync(IAmazonS3 s3Client, string bucketName, CancellationToken token)
		{
			return DeleteS3BucketWithObjectsAsync(s3Client, bucketName, new S3DeleteBucketWithObjectsOptions
			{
				ContinueOnError = false,
				QuietMode = true
			}, token);
		}

		public static Task DeleteS3BucketWithObjectsAsync(IAmazonS3 s3Client, string bucketName, S3DeleteBucketWithObjectsOptions deleteOptions, CancellationToken token)
		{
			return DeleteS3BucketWithObjectsAsync(s3Client, bucketName, deleteOptions, null, token);
		}

		public static Task DeleteS3BucketWithObjectsAsync(IAmazonS3 s3Client, string bucketName, S3DeleteBucketWithObjectsOptions deleteOptions, Action<S3DeleteBucketWithObjectsUpdate> updateCallback, CancellationToken token)
		{
			return InvokeDeleteS3BucketWithObjects(new S3DeleteBucketWithObjectsRequest
			{
				BucketName = bucketName,
				DeleteOptions = deleteOptions,
				UpdateCallback = updateCallback,
				S3Client = s3Client
			}, token);
		}

		private static Task InvokeDeleteS3BucketWithObjects(object state, CancellationToken token)
		{
			S3DeleteBucketWithObjectsRequest s3DeleteBucketWithObjectsRequest = (S3DeleteBucketWithObjectsRequest)state;
			return DeleteS3BucketWithObjectsInternalAsync(s3DeleteBucketWithObjectsRequest.S3Client, s3DeleteBucketWithObjectsRequest.BucketName, s3DeleteBucketWithObjectsRequest.DeleteOptions, s3DeleteBucketWithObjectsRequest.UpdateCallback, token);
		}

		private static async Task DeleteS3BucketWithObjectsInternalAsync(IAmazonS3 s3Client, string bucketName, S3DeleteBucketWithObjectsOptions deleteOptions, Action<S3DeleteBucketWithObjectsUpdate> updateCallback, CancellationToken token)
		{
			if (s3Client == null)
			{
				throw new ArgumentNullException("s3Client", "The s3Client cannot be null!");
			}
			if (string.IsNullOrEmpty(bucketName))
			{
				throw new ArgumentNullException("bucketName", "The bucketName cannot be null or empty string!");
			}
			ListVersionsRequest listVersionsRequest = new ListVersionsRequest
			{
				BucketName = bucketName
			};
			ListObjectsV2Request listObjectsV2Request = new ListObjectsV2Request
			{
				BucketName = bucketName
			};
			ListVersionsResponse listVersionsResponse = null;
			ListObjectsV2Response listObjectsV2Response = null;
			bool isTruncated = false;
			do
			{
				if (token.IsCancellationRequested)
				{
					return;
				}
				List<KeyVersion> keyVersionList;
				try
				{
					listVersionsResponse = await s3Client.ListVersionsAsync(listVersionsRequest, token).ConfigureAwait(continueOnCapturedContext: false);
					if (listVersionsResponse.Versions == null || listVersionsResponse.Versions.Count == 0)
					{
						break;
					}
					keyVersionList = new List<KeyVersion>(listVersionsResponse.Versions.Count);
					for (int i = 0; i < listVersionsResponse.Versions.Count; i++)
					{
						keyVersionList.Add(new KeyVersion
						{
							Key = listVersionsResponse.Versions[i].Key,
							VersionId = listVersionsResponse.Versions[i].VersionId
						});
					}
					goto IL_0345;
				}
				catch (AmazonS3Exception ex)
				{
					if (ex.StatusCode != HttpStatusCode.NotImplemented)
					{
						throw;
					}
					listObjectsV2Response = await s3Client.ListObjectsV2Async(listObjectsV2Request).ConfigureAwait(continueOnCapturedContext: false);
					if (listObjectsV2Response.S3Objects != null && listObjectsV2Response.S3Objects.Count != 0)
					{
						keyVersionList = new List<KeyVersion>(listObjectsV2Response.S3Objects.Count);
						for (int j = 0; j < listObjectsV2Response.S3Objects.Count; j++)
						{
							keyVersionList.Add(new KeyVersion
							{
								Key = listObjectsV2Response.S3Objects[j].Key
							});
						}
						goto IL_0345;
					}
				}
				break;
				IL_0345:
				try
				{
					DeleteObjectsResponse deleteObjectsResponse = await s3Client.DeleteObjectsAsync(new DeleteObjectsRequest
					{
						BucketName = bucketName,
						Objects = keyVersionList,
						Quiet = deleteOptions.QuietMode
					}, token).ConfigureAwait(continueOnCapturedContext: false);
					if (!deleteOptions.QuietMode)
					{
						InvokeS3DeleteBucketWithObjectsUpdateCallback(updateCallback, new S3DeleteBucketWithObjectsUpdate
						{
							DeletedObjects = deleteObjectsResponse.DeletedObjects
						});
					}
				}
				catch (DeleteObjectsException ex2)
				{
					if (!deleteOptions.ContinueOnError)
					{
						throw;
					}
					InvokeS3DeleteBucketWithObjectsUpdateCallback(updateCallback, new S3DeleteBucketWithObjectsUpdate
					{
						DeletedObjects = ex2.Response.DeletedObjects,
						DeleteErrors = ex2.Response.DeleteErrors
					});
				}
				if (listVersionsResponse != null)
				{
					listVersionsRequest.KeyMarker = listVersionsResponse.NextKeyMarker;
					listVersionsRequest.VersionIdMarker = listVersionsResponse.NextVersionIdMarker;
					isTruncated = listVersionsResponse.IsTruncated == true;
				}
				if (listObjectsV2Response != null)
				{
					listObjectsV2Request.ContinuationToken = listObjectsV2Response.NextContinuationToken;
					isTruncated = listObjectsV2Response.IsTruncated == true;
				}
			}
			while (isTruncated);
			for (int k = 1; k <= 10; k++)
			{
				try
				{
					await s3Client.DeleteBucketAsync(new DeleteBucketRequest
					{
						BucketName = bucketName
					}, token).ConfigureAwait(continueOnCapturedContext: false);
					break;
				}
				catch (AmazonS3Exception ex3)
				{
					if (ex3.StatusCode != HttpStatusCode.Conflict || k == 10)
					{
						throw;
					}
					DefaultRetryPolicy.WaitBeforeRetry(k, 5000);
				}
			}
		}

		private static void InvokeS3DeleteBucketWithObjectsUpdateCallback(Action<S3DeleteBucketWithObjectsUpdate> updateCallback, S3DeleteBucketWithObjectsUpdate update)
		{
			updateCallback?.Invoke(update);
		}
	}
}
