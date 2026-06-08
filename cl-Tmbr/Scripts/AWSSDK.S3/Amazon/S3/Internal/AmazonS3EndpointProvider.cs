using System;
using System.Collections.Generic;
using Amazon.Runtime;
using Amazon.Runtime.Endpoints;
using Amazon.Runtime.Internal.Endpoints.StandardLibrary;

namespace Amazon.S3.Internal
{
	public class AmazonS3EndpointProvider : IEndpointProvider
	{
		public Endpoint ResolveEndpoint(EndpointParameters parameters)
		{
			if (parameters == null)
			{
				throw new ArgumentNullException("parameters");
			}
			if (parameters["UseFIPS"] == null)
			{
				throw new AmazonClientException("UseFIPS parameter must be set for endpoint resolution");
			}
			if (parameters["UseDualStack"] == null)
			{
				throw new AmazonClientException("UseDualStack parameter must be set for endpoint resolution");
			}
			if (parameters["ForcePathStyle"] == null)
			{
				throw new AmazonClientException("ForcePathStyle parameter must be set for endpoint resolution");
			}
			if (parameters["Accelerate"] == null)
			{
				throw new AmazonClientException("Accelerate parameter must be set for endpoint resolution");
			}
			if (parameters["UseGlobalEndpoint"] == null)
			{
				throw new AmazonClientException("UseGlobalEndpoint parameter must be set for endpoint resolution");
			}
			if (parameters["DisableMultiRegionAccessPoints"] == null)
			{
				throw new AmazonClientException("DisableMultiRegionAccessPoints parameter must be set for endpoint resolution");
			}
			Dictionary<string, object> dictionary = new Dictionary<string, object>
			{
				["Bucket"] = parameters["Bucket"],
				["Region"] = parameters["Region"],
				["UseFIPS"] = parameters["UseFIPS"],
				["UseDualStack"] = parameters["UseDualStack"],
				["Endpoint"] = parameters["Endpoint"],
				["ForcePathStyle"] = parameters["ForcePathStyle"],
				["Accelerate"] = parameters["Accelerate"],
				["UseGlobalEndpoint"] = parameters["UseGlobalEndpoint"],
				["UseObjectLambdaEndpoint"] = parameters["UseObjectLambdaEndpoint"],
				["Key"] = parameters["Key"],
				["Prefix"] = parameters["Prefix"],
				["CopySource"] = parameters["CopySource"],
				["DisableAccessPoints"] = parameters["DisableAccessPoints"],
				["DisableMultiRegionAccessPoints"] = parameters["DisableMultiRegionAccessPoints"],
				["UseArnRegion"] = parameters["UseArnRegion"],
				["UseS3ExpressControlEndpoint"] = parameters["UseS3ExpressControlEndpoint"],
				["DisableS3ExpressSessionAuth"] = parameters["DisableS3ExpressSessionAuth"]
			};
			if (Fn.IsSet(dictionary["Region"]))
			{
				if (object.Equals(dictionary["Accelerate"], true) && object.Equals(dictionary["UseFIPS"], true))
				{
					throw new AmazonClientException("Accelerate cannot be used with FIPS");
				}
				if (object.Equals(dictionary["UseDualStack"], true) && Fn.IsSet(dictionary["Endpoint"]))
				{
					throw new AmazonClientException("Cannot set dual-stack in combination with a custom endpoint.");
				}
				if (Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["UseFIPS"], true))
				{
					throw new AmazonClientException("A custom endpoint cannot be combined with FIPS");
				}
				if (Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["Accelerate"], true))
				{
					throw new AmazonClientException("A custom endpoint cannot be combined with S3 Accelerate");
				}
				if (object.Equals(dictionary["UseFIPS"], true))
				{
					object obj = (dictionary["partitionResult"] = Fn.Partition((string)dictionary["Region"]));
					if (obj != null && object.Equals(Fn.GetAttr(dictionary["partitionResult"], "name"), "aws-cn"))
					{
						throw new AmazonClientException("Partition does not support FIPS");
					}
				}
				if (Fn.IsSet(dictionary["Bucket"]))
				{
					object obj = (dictionary["bucketSuffix"] = Fn.Substring((string)dictionary["Bucket"], 0, 6, reverse: true));
					if (obj != null && object.Equals(dictionary["bucketSuffix"], "--x-s3"))
					{
						if (object.Equals(dictionary["UseDualStack"], true))
						{
							throw new AmazonClientException("S3Express does not support Dual-stack.");
						}
						if (object.Equals(dictionary["Accelerate"], true))
						{
							throw new AmazonClientException("S3Express does not support S3 Accelerate.");
						}
						if (Fn.IsSet(dictionary["Endpoint"]))
						{
							obj = (dictionary["url"] = Fn.ParseURL((string)dictionary["Endpoint"]));
							if (obj != null)
							{
								if (Fn.IsSet(dictionary["DisableS3ExpressSessionAuth"]) && object.Equals(dictionary["DisableS3ExpressSessionAuth"], true))
								{
									if (object.Equals(Fn.GetAttr(dictionary["url"], "isIp"), true))
									{
										obj = (dictionary["uri_encoded_bucket"] = Fn.UriEncode((string)dictionary["Bucket"]));
										if (obj != null)
										{
											return new Endpoint(Fn.Interpolate("{url#scheme}://{url#authority}/{uri_encoded_bucket}{url#path}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
									}
									if (Fn.IsVirtualHostableS3Bucket((string)dictionary["Bucket"], allowSubDomains: false))
									{
										return new Endpoint(Fn.Interpolate("{url#scheme}://{Bucket}.{url#authority}{url#path}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
									throw new AmazonClientException("S3Express bucket name is not a valid virtual hostable name.");
								}
								if (object.Equals(Fn.GetAttr(dictionary["url"], "isIp"), true))
								{
									obj = (dictionary["uri_encoded_bucket"] = Fn.UriEncode((string)dictionary["Bucket"]));
									if (obj != null)
									{
										return new Endpoint(Fn.Interpolate("{url#scheme}://{url#authority}/{uri_encoded_bucket}{url#path}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
								}
								if (Fn.IsVirtualHostableS3Bucket((string)dictionary["Bucket"], allowSubDomains: false))
								{
									return new Endpoint(Fn.Interpolate("{url#scheme}://{Bucket}.{url#authority}{url#path}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								throw new AmazonClientException("S3Express bucket name is not a valid virtual hostable name.");
							}
						}
						if (Fn.IsSet(dictionary["UseS3ExpressControlEndpoint"]) && object.Equals(dictionary["UseS3ExpressControlEndpoint"], true))
						{
							obj = (dictionary["partitionResult"] = Fn.Partition((string)dictionary["Region"]));
							if (obj != null)
							{
								obj = (dictionary["uri_encoded_bucket"] = Fn.UriEncode((string)dictionary["Bucket"]));
								if (obj != null && !Fn.IsSet(dictionary["Endpoint"]))
								{
									if (object.Equals(dictionary["UseFIPS"], true))
									{
										return new Endpoint(Fn.Interpolate("https://s3express-control-fips.{Region}.{partitionResult#dnsSuffix}/{uri_encoded_bucket}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
									return new Endpoint(Fn.Interpolate("https://s3express-control.{Region}.{partitionResult#dnsSuffix}/{uri_encoded_bucket}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
							}
						}
						if (Fn.IsVirtualHostableS3Bucket((string)dictionary["Bucket"], allowSubDomains: false))
						{
							obj = (dictionary["partitionResult"] = Fn.Partition((string)dictionary["Region"]));
							if (obj != null)
							{
								if (Fn.IsSet(dictionary["DisableS3ExpressSessionAuth"]) && object.Equals(dictionary["DisableS3ExpressSessionAuth"], true))
								{
									obj = (dictionary["s3expressAvailabilityZoneId"] = Fn.Substring((string)dictionary["Bucket"], 6, 14, reverse: true));
									if (obj != null)
									{
										obj = (dictionary["s3expressAvailabilityZoneDelim"] = Fn.Substring((string)dictionary["Bucket"], 14, 16, reverse: true));
										if (obj != null && object.Equals(dictionary["s3expressAvailabilityZoneDelim"], "--"))
										{
											if (object.Equals(dictionary["UseFIPS"], true))
											{
												return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-fips-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
											}
											return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
									}
									obj = (dictionary["s3expressAvailabilityZoneId"] = Fn.Substring((string)dictionary["Bucket"], 6, 15, reverse: true));
									if (obj != null)
									{
										obj = (dictionary["s3expressAvailabilityZoneDelim"] = Fn.Substring((string)dictionary["Bucket"], 15, 17, reverse: true));
										if (obj != null && object.Equals(dictionary["s3expressAvailabilityZoneDelim"], "--"))
										{
											if (object.Equals(dictionary["UseFIPS"], true))
											{
												return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-fips-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
											}
											return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
									}
									obj = (dictionary["s3expressAvailabilityZoneId"] = Fn.Substring((string)dictionary["Bucket"], 6, 19, reverse: true));
									if (obj != null)
									{
										obj = (dictionary["s3expressAvailabilityZoneDelim"] = Fn.Substring((string)dictionary["Bucket"], 19, 21, reverse: true));
										if (obj != null && object.Equals(dictionary["s3expressAvailabilityZoneDelim"], "--"))
										{
											if (object.Equals(dictionary["UseFIPS"], true))
											{
												return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-fips-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
											}
											return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
									}
									obj = (dictionary["s3expressAvailabilityZoneId"] = Fn.Substring((string)dictionary["Bucket"], 6, 20, reverse: true));
									if (obj != null)
									{
										obj = (dictionary["s3expressAvailabilityZoneDelim"] = Fn.Substring((string)dictionary["Bucket"], 20, 22, reverse: true));
										if (obj != null && object.Equals(dictionary["s3expressAvailabilityZoneDelim"], "--"))
										{
											if (object.Equals(dictionary["UseFIPS"], true))
											{
												return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-fips-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
											}
											return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
									}
									obj = (dictionary["s3expressAvailabilityZoneId"] = Fn.Substring((string)dictionary["Bucket"], 6, 26, reverse: true));
									if (obj != null)
									{
										obj = (dictionary["s3expressAvailabilityZoneDelim"] = Fn.Substring((string)dictionary["Bucket"], 26, 28, reverse: true));
										if (obj != null && object.Equals(dictionary["s3expressAvailabilityZoneDelim"], "--"))
										{
											if (object.Equals(dictionary["UseFIPS"], true))
											{
												return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-fips-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
											}
											return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
									}
									throw new AmazonClientException("Unrecognized S3Express bucket name format.");
								}
								obj = (dictionary["s3expressAvailabilityZoneId"] = Fn.Substring((string)dictionary["Bucket"], 6, 14, reverse: true));
								if (obj != null)
								{
									obj = (dictionary["s3expressAvailabilityZoneDelim"] = Fn.Substring((string)dictionary["Bucket"], 14, 16, reverse: true));
									if (obj != null && object.Equals(dictionary["s3expressAvailabilityZoneDelim"], "--"))
									{
										if (object.Equals(dictionary["UseFIPS"], true))
										{
											return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-fips-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
										return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
								}
								obj = (dictionary["s3expressAvailabilityZoneId"] = Fn.Substring((string)dictionary["Bucket"], 6, 15, reverse: true));
								if (obj != null)
								{
									obj = (dictionary["s3expressAvailabilityZoneDelim"] = Fn.Substring((string)dictionary["Bucket"], 15, 17, reverse: true));
									if (obj != null && object.Equals(dictionary["s3expressAvailabilityZoneDelim"], "--"))
									{
										if (object.Equals(dictionary["UseFIPS"], true))
										{
											return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-fips-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
										return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
								}
								obj = (dictionary["s3expressAvailabilityZoneId"] = Fn.Substring((string)dictionary["Bucket"], 6, 19, reverse: true));
								if (obj != null)
								{
									obj = (dictionary["s3expressAvailabilityZoneDelim"] = Fn.Substring((string)dictionary["Bucket"], 19, 21, reverse: true));
									if (obj != null && object.Equals(dictionary["s3expressAvailabilityZoneDelim"], "--"))
									{
										if (object.Equals(dictionary["UseFIPS"], true))
										{
											return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-fips-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
										return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
								}
								obj = (dictionary["s3expressAvailabilityZoneId"] = Fn.Substring((string)dictionary["Bucket"], 6, 20, reverse: true));
								if (obj != null)
								{
									obj = (dictionary["s3expressAvailabilityZoneDelim"] = Fn.Substring((string)dictionary["Bucket"], 20, 22, reverse: true));
									if (obj != null && object.Equals(dictionary["s3expressAvailabilityZoneDelim"], "--"))
									{
										if (object.Equals(dictionary["UseFIPS"], true))
										{
											return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-fips-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
										return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
								}
								obj = (dictionary["s3expressAvailabilityZoneId"] = Fn.Substring((string)dictionary["Bucket"], 6, 26, reverse: true));
								if (obj != null)
								{
									obj = (dictionary["s3expressAvailabilityZoneDelim"] = Fn.Substring((string)dictionary["Bucket"], 26, 28, reverse: true));
									if (obj != null && object.Equals(dictionary["s3expressAvailabilityZoneDelim"], "--"))
									{
										if (object.Equals(dictionary["UseFIPS"], true))
										{
											return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-fips-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
										return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
								}
								throw new AmazonClientException("Unrecognized S3Express bucket name format.");
							}
						}
						throw new AmazonClientException("S3Express bucket name is not a valid virtual hostable name.");
					}
				}
				if (Fn.IsSet(dictionary["Bucket"]))
				{
					object obj = (dictionary["accessPointSuffix"] = Fn.Substring((string)dictionary["Bucket"], 0, 7, reverse: true));
					if (obj != null && object.Equals(dictionary["accessPointSuffix"], "--xa-s3"))
					{
						if (object.Equals(dictionary["UseDualStack"], true))
						{
							throw new AmazonClientException("S3Express does not support Dual-stack.");
						}
						if (object.Equals(dictionary["Accelerate"], true))
						{
							throw new AmazonClientException("S3Express does not support S3 Accelerate.");
						}
						if (Fn.IsSet(dictionary["Endpoint"]))
						{
							obj = (dictionary["url"] = Fn.ParseURL((string)dictionary["Endpoint"]));
							if (obj != null)
							{
								if (Fn.IsSet(dictionary["DisableS3ExpressSessionAuth"]) && object.Equals(dictionary["DisableS3ExpressSessionAuth"], true))
								{
									if (object.Equals(Fn.GetAttr(dictionary["url"], "isIp"), true))
									{
										obj = (dictionary["uri_encoded_bucket"] = Fn.UriEncode((string)dictionary["Bucket"]));
										if (obj != null)
										{
											return new Endpoint(Fn.Interpolate("{url#scheme}://{url#authority}/{uri_encoded_bucket}{url#path}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
									}
									if (Fn.IsVirtualHostableS3Bucket((string)dictionary["Bucket"], allowSubDomains: false))
									{
										return new Endpoint(Fn.Interpolate("{url#scheme}://{Bucket}.{url#authority}{url#path}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
									throw new AmazonClientException("S3Express bucket name is not a valid virtual hostable name.");
								}
								if (object.Equals(Fn.GetAttr(dictionary["url"], "isIp"), true))
								{
									obj = (dictionary["uri_encoded_bucket"] = Fn.UriEncode((string)dictionary["Bucket"]));
									if (obj != null)
									{
										return new Endpoint(Fn.Interpolate("{url#scheme}://{url#authority}/{uri_encoded_bucket}{url#path}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
								}
								if (Fn.IsVirtualHostableS3Bucket((string)dictionary["Bucket"], allowSubDomains: false))
								{
									return new Endpoint(Fn.Interpolate("{url#scheme}://{Bucket}.{url#authority}{url#path}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								throw new AmazonClientException("S3Express bucket name is not a valid virtual hostable name.");
							}
						}
						if (Fn.IsVirtualHostableS3Bucket((string)dictionary["Bucket"], allowSubDomains: false))
						{
							obj = (dictionary["partitionResult"] = Fn.Partition((string)dictionary["Region"]));
							if (obj != null)
							{
								if (Fn.IsSet(dictionary["DisableS3ExpressSessionAuth"]) && object.Equals(dictionary["DisableS3ExpressSessionAuth"], true))
								{
									obj = (dictionary["s3expressAvailabilityZoneId"] = Fn.Substring((string)dictionary["Bucket"], 7, 15, reverse: true));
									if (obj != null)
									{
										obj = (dictionary["s3expressAvailabilityZoneDelim"] = Fn.Substring((string)dictionary["Bucket"], 15, 17, reverse: true));
										if (obj != null && object.Equals(dictionary["s3expressAvailabilityZoneDelim"], "--"))
										{
											if (object.Equals(dictionary["UseFIPS"], true))
											{
												return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-fips-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
											}
											return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
									}
									obj = (dictionary["s3expressAvailabilityZoneId"] = Fn.Substring((string)dictionary["Bucket"], 7, 16, reverse: true));
									if (obj != null)
									{
										obj = (dictionary["s3expressAvailabilityZoneDelim"] = Fn.Substring((string)dictionary["Bucket"], 16, 18, reverse: true));
										if (obj != null && object.Equals(dictionary["s3expressAvailabilityZoneDelim"], "--"))
										{
											if (object.Equals(dictionary["UseFIPS"], true))
											{
												return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-fips-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
											}
											return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
									}
									obj = (dictionary["s3expressAvailabilityZoneId"] = Fn.Substring((string)dictionary["Bucket"], 7, 20, reverse: true));
									if (obj != null)
									{
										obj = (dictionary["s3expressAvailabilityZoneDelim"] = Fn.Substring((string)dictionary["Bucket"], 20, 22, reverse: true));
										if (obj != null && object.Equals(dictionary["s3expressAvailabilityZoneDelim"], "--"))
										{
											if (object.Equals(dictionary["UseFIPS"], true))
											{
												return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-fips-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
											}
											return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
									}
									obj = (dictionary["s3expressAvailabilityZoneId"] = Fn.Substring((string)dictionary["Bucket"], 7, 21, reverse: true));
									if (obj != null)
									{
										obj = (dictionary["s3expressAvailabilityZoneDelim"] = Fn.Substring((string)dictionary["Bucket"], 21, 23, reverse: true));
										if (obj != null && object.Equals(dictionary["s3expressAvailabilityZoneDelim"], "--"))
										{
											if (object.Equals(dictionary["UseFIPS"], true))
											{
												return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-fips-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
											}
											return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
									}
									obj = (dictionary["s3expressAvailabilityZoneId"] = Fn.Substring((string)dictionary["Bucket"], 7, 27, reverse: true));
									if (obj != null)
									{
										obj = (dictionary["s3expressAvailabilityZoneDelim"] = Fn.Substring((string)dictionary["Bucket"], 27, 29, reverse: true));
										if (obj != null && object.Equals(dictionary["s3expressAvailabilityZoneDelim"], "--"))
										{
											if (object.Equals(dictionary["UseFIPS"], true))
											{
												return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-fips-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
											}
											return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
									}
									throw new AmazonClientException("Unrecognized S3Express bucket name format.");
								}
								obj = (dictionary["s3expressAvailabilityZoneId"] = Fn.Substring((string)dictionary["Bucket"], 7, 15, reverse: true));
								if (obj != null)
								{
									obj = (dictionary["s3expressAvailabilityZoneDelim"] = Fn.Substring((string)dictionary["Bucket"], 15, 17, reverse: true));
									if (obj != null && object.Equals(dictionary["s3expressAvailabilityZoneDelim"], "--"))
									{
										if (object.Equals(dictionary["UseFIPS"], true))
										{
											return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-fips-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
										return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
								}
								obj = (dictionary["s3expressAvailabilityZoneId"] = Fn.Substring((string)dictionary["Bucket"], 7, 16, reverse: true));
								if (obj != null)
								{
									obj = (dictionary["s3expressAvailabilityZoneDelim"] = Fn.Substring((string)dictionary["Bucket"], 16, 18, reverse: true));
									if (obj != null && object.Equals(dictionary["s3expressAvailabilityZoneDelim"], "--"))
									{
										if (object.Equals(dictionary["UseFIPS"], true))
										{
											return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-fips-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
										return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
								}
								obj = (dictionary["s3expressAvailabilityZoneId"] = Fn.Substring((string)dictionary["Bucket"], 7, 20, reverse: true));
								if (obj != null)
								{
									obj = (dictionary["s3expressAvailabilityZoneDelim"] = Fn.Substring((string)dictionary["Bucket"], 20, 22, reverse: true));
									if (obj != null && object.Equals(dictionary["s3expressAvailabilityZoneDelim"], "--"))
									{
										if (object.Equals(dictionary["UseFIPS"], true))
										{
											return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-fips-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
										return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
								}
								obj = (dictionary["s3expressAvailabilityZoneId"] = Fn.Substring((string)dictionary["Bucket"], 7, 21, reverse: true));
								if (obj != null)
								{
									obj = (dictionary["s3expressAvailabilityZoneDelim"] = Fn.Substring((string)dictionary["Bucket"], 21, 23, reverse: true));
									if (obj != null && object.Equals(dictionary["s3expressAvailabilityZoneDelim"], "--"))
									{
										if (object.Equals(dictionary["UseFIPS"], true))
										{
											return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-fips-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
										return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
								}
								obj = (dictionary["s3expressAvailabilityZoneId"] = Fn.Substring((string)dictionary["Bucket"], 7, 27, reverse: true));
								if (obj != null)
								{
									obj = (dictionary["s3expressAvailabilityZoneDelim"] = Fn.Substring((string)dictionary["Bucket"], 27, 29, reverse: true));
									if (obj != null && object.Equals(dictionary["s3expressAvailabilityZoneDelim"], "--"))
									{
										if (object.Equals(dictionary["UseFIPS"], true))
										{
											return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-fips-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
										return new Endpoint(Fn.Interpolate("https://{Bucket}.s3express-{s3expressAvailabilityZoneId}.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4-s3express\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
								}
								throw new AmazonClientException("Unrecognized S3Express bucket name format.");
							}
						}
						throw new AmazonClientException("S3Express bucket name is not a valid virtual hostable name.");
					}
				}
				if (!Fn.IsSet(dictionary["Bucket"]) && Fn.IsSet(dictionary["UseS3ExpressControlEndpoint"]) && object.Equals(dictionary["UseS3ExpressControlEndpoint"], true))
				{
					object obj = (dictionary["partitionResult"] = Fn.Partition((string)dictionary["Region"]));
					if (obj != null)
					{
						if (Fn.IsSet(dictionary["Endpoint"]))
						{
							obj = (dictionary["url"] = Fn.ParseURL((string)dictionary["Endpoint"]));
							if (obj != null)
							{
								return new Endpoint(Fn.Interpolate("{url#scheme}://{url#authority}{url#path}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
							}
						}
						if (object.Equals(dictionary["UseFIPS"], true))
						{
							return new Endpoint(Fn.Interpolate("https://s3express-control-fips.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
						}
						return new Endpoint(Fn.Interpolate("https://s3express-control.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"backend\":\"S3Express\",\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3express\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
					}
				}
				if (Fn.IsSet(dictionary["Bucket"]))
				{
					object obj = (dictionary["hardwareType"] = Fn.Substring((string)dictionary["Bucket"], 49, 50, reverse: true));
					if (obj != null)
					{
						obj = (dictionary["regionPrefix"] = Fn.Substring((string)dictionary["Bucket"], 8, 12, reverse: true));
						if (obj != null)
						{
							obj = (dictionary["bucketAliasSuffix"] = Fn.Substring((string)dictionary["Bucket"], 0, 7, reverse: true));
							if (obj != null)
							{
								obj = (dictionary["outpostId"] = Fn.Substring((string)dictionary["Bucket"], 32, 49, reverse: true));
								if (obj != null)
								{
									obj = (dictionary["regionPartition"] = Fn.Partition((string)dictionary["Region"]));
									if (obj != null && object.Equals(dictionary["bucketAliasSuffix"], "--op-s3"))
									{
										if (Fn.IsValidHostLabel((string)dictionary["outpostId"], allowSubDomains: false))
										{
											if (object.Equals(dictionary["hardwareType"], "e"))
											{
												if (object.Equals(dictionary["regionPrefix"], "beta"))
												{
													if (!Fn.IsSet(dictionary["Endpoint"]))
													{
														throw new AmazonClientException("Expected a endpoint to be specified but no endpoint was found");
													}
													if (Fn.IsSet(dictionary["Endpoint"]))
													{
														obj = (dictionary["url"] = Fn.ParseURL((string)dictionary["Endpoint"]));
														if (obj != null)
														{
															return new Endpoint(Fn.Interpolate("https://{Bucket}.ec2.{url#authority}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4a\",\"signingName\":\"s3-outposts\",\"signingRegionSet\":[\"*\"]},{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3-outposts\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
														}
													}
												}
												return new Endpoint(Fn.Interpolate("https://{Bucket}.ec2.s3-outposts.{Region}.{regionPartition#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4a\",\"signingName\":\"s3-outposts\",\"signingRegionSet\":[\"*\"]},{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3-outposts\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
											}
											if (object.Equals(dictionary["hardwareType"], "o"))
											{
												if (object.Equals(dictionary["regionPrefix"], "beta"))
												{
													if (!Fn.IsSet(dictionary["Endpoint"]))
													{
														throw new AmazonClientException("Expected a endpoint to be specified but no endpoint was found");
													}
													if (Fn.IsSet(dictionary["Endpoint"]))
													{
														obj = (dictionary["url"] = Fn.ParseURL((string)dictionary["Endpoint"]));
														if (obj != null)
														{
															return new Endpoint(Fn.Interpolate("https://{Bucket}.op-{outpostId}.{url#authority}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4a\",\"signingName\":\"s3-outposts\",\"signingRegionSet\":[\"*\"]},{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3-outposts\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
														}
													}
												}
												return new Endpoint(Fn.Interpolate("https://{Bucket}.op-{outpostId}.s3-outposts.{Region}.{regionPartition#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4a\",\"signingName\":\"s3-outposts\",\"signingRegionSet\":[\"*\"]},{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3-outposts\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
											}
											throw new AmazonClientException(Fn.Interpolate("Unrecognized hardware type: \"Expected hardware type o or e but got {hardwareType}\"", dictionary));
										}
										throw new AmazonClientException("Invalid ARN: The outpost Id must only contain a-z, A-Z, 0-9 and `-`.");
									}
								}
							}
						}
					}
				}
				if (Fn.IsSet(dictionary["Bucket"]))
				{
					if (Fn.IsSet(dictionary["Endpoint"]) && !Fn.IsSet(Fn.ParseURL((string)dictionary["Endpoint"])))
					{
						throw new AmazonClientException(Fn.Interpolate("Custom endpoint `{Endpoint}` was not a valid URI", dictionary));
					}
					object obj;
					if (object.Equals(dictionary["ForcePathStyle"], false) && Fn.IsVirtualHostableS3Bucket((string)dictionary["Bucket"], allowSubDomains: false))
					{
						obj = (dictionary["partitionResult"] = Fn.Partition((string)dictionary["Region"]));
						if (obj != null)
						{
							if (Fn.IsValidHostLabel((string)dictionary["Region"], allowSubDomains: false))
							{
								if (object.Equals(dictionary["Accelerate"], true) && object.Equals(Fn.GetAttr(dictionary["partitionResult"], "name"), "aws-cn"))
								{
									throw new AmazonClientException("S3 Accelerate cannot be used in this region");
								}
								if (object.Equals(dictionary["UseDualStack"], true) && object.Equals(dictionary["UseFIPS"], true) && object.Equals(dictionary["Accelerate"], false) && !Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["Region"], "aws-global"))
								{
									return new Endpoint(Fn.Interpolate("https://{Bucket}.s3-fips.dualstack.us-east-1.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"us-east-1\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], true) && object.Equals(dictionary["UseFIPS"], true) && object.Equals(dictionary["Accelerate"], false) && !Fn.IsSet(dictionary["Endpoint"]) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], true))
								{
									return new Endpoint(Fn.Interpolate("https://{Bucket}.s3-fips.dualstack.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], true) && object.Equals(dictionary["UseFIPS"], true) && object.Equals(dictionary["Accelerate"], false) && !Fn.IsSet(dictionary["Endpoint"]) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], false))
								{
									return new Endpoint(Fn.Interpolate("https://{Bucket}.s3-fips.dualstack.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], false) && object.Equals(dictionary["UseFIPS"], true) && object.Equals(dictionary["Accelerate"], false) && !Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["Region"], "aws-global"))
								{
									return new Endpoint(Fn.Interpolate("https://{Bucket}.s3-fips.us-east-1.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"us-east-1\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], false) && object.Equals(dictionary["UseFIPS"], true) && object.Equals(dictionary["Accelerate"], false) && !Fn.IsSet(dictionary["Endpoint"]) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], true))
								{
									return new Endpoint(Fn.Interpolate("https://{Bucket}.s3-fips.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], false) && object.Equals(dictionary["UseFIPS"], true) && object.Equals(dictionary["Accelerate"], false) && !Fn.IsSet(dictionary["Endpoint"]) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], false))
								{
									return new Endpoint(Fn.Interpolate("https://{Bucket}.s3-fips.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], true) && object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["Accelerate"], true) && !Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["Region"], "aws-global"))
								{
									return new Endpoint(Fn.Interpolate("https://{Bucket}.s3-accelerate.dualstack.us-east-1.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"us-east-1\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], true) && object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["Accelerate"], true) && !Fn.IsSet(dictionary["Endpoint"]) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], true))
								{
									return new Endpoint(Fn.Interpolate("https://{Bucket}.s3-accelerate.dualstack.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], true) && object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["Accelerate"], true) && !Fn.IsSet(dictionary["Endpoint"]) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], false))
								{
									return new Endpoint(Fn.Interpolate("https://{Bucket}.s3-accelerate.dualstack.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], true) && object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["Accelerate"], false) && !Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["Region"], "aws-global"))
								{
									return new Endpoint(Fn.Interpolate("https://{Bucket}.s3.dualstack.us-east-1.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"us-east-1\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], true) && object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["Accelerate"], false) && !Fn.IsSet(dictionary["Endpoint"]) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], true))
								{
									return new Endpoint(Fn.Interpolate("https://{Bucket}.s3.dualstack.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], true) && object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["Accelerate"], false) && !Fn.IsSet(dictionary["Endpoint"]) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], false))
								{
									return new Endpoint(Fn.Interpolate("https://{Bucket}.s3.dualstack.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], false) && object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["Accelerate"], false) && Fn.IsSet(dictionary["Endpoint"]))
								{
									obj = (dictionary["url"] = Fn.ParseURL((string)dictionary["Endpoint"]));
									if (obj != null && object.Equals(Fn.GetAttr(dictionary["url"], "isIp"), true) && object.Equals(dictionary["Region"], "aws-global"))
									{
										return new Endpoint(Fn.Interpolate("{url#scheme}://{url#authority}{url#normalizedPath}{Bucket}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"us-east-1\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
								}
								if (object.Equals(dictionary["UseDualStack"], false) && object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["Accelerate"], false) && Fn.IsSet(dictionary["Endpoint"]))
								{
									obj = (dictionary["url"] = Fn.ParseURL((string)dictionary["Endpoint"]));
									if (obj != null && object.Equals(Fn.GetAttr(dictionary["url"], "isIp"), false) && object.Equals(dictionary["Region"], "aws-global"))
									{
										return new Endpoint(Fn.Interpolate("{url#scheme}://{Bucket}.{url#authority}{url#path}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"us-east-1\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
								}
								if (object.Equals(dictionary["UseDualStack"], false) && object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["Accelerate"], false) && Fn.IsSet(dictionary["Endpoint"]))
								{
									obj = (dictionary["url"] = Fn.ParseURL((string)dictionary["Endpoint"]));
									if (obj != null && object.Equals(Fn.GetAttr(dictionary["url"], "isIp"), true) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], true))
									{
										if (object.Equals(dictionary["Region"], "us-east-1"))
										{
											return new Endpoint(Fn.Interpolate("{url#scheme}://{url#authority}{url#normalizedPath}{Bucket}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
										return new Endpoint(Fn.Interpolate("{url#scheme}://{url#authority}{url#normalizedPath}{Bucket}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
								}
								if (object.Equals(dictionary["UseDualStack"], false) && object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["Accelerate"], false) && Fn.IsSet(dictionary["Endpoint"]))
								{
									obj = (dictionary["url"] = Fn.ParseURL((string)dictionary["Endpoint"]));
									if (obj != null && object.Equals(Fn.GetAttr(dictionary["url"], "isIp"), false) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], true))
									{
										if (object.Equals(dictionary["Region"], "us-east-1"))
										{
											return new Endpoint(Fn.Interpolate("{url#scheme}://{Bucket}.{url#authority}{url#path}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
										return new Endpoint(Fn.Interpolate("{url#scheme}://{Bucket}.{url#authority}{url#path}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
								}
								if (object.Equals(dictionary["UseDualStack"], false) && object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["Accelerate"], false) && Fn.IsSet(dictionary["Endpoint"]))
								{
									obj = (dictionary["url"] = Fn.ParseURL((string)dictionary["Endpoint"]));
									if (obj != null && object.Equals(Fn.GetAttr(dictionary["url"], "isIp"), true) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], false))
									{
										return new Endpoint(Fn.Interpolate("{url#scheme}://{url#authority}{url#normalizedPath}{Bucket}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
								}
								if (object.Equals(dictionary["UseDualStack"], false) && object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["Accelerate"], false) && Fn.IsSet(dictionary["Endpoint"]))
								{
									obj = (dictionary["url"] = Fn.ParseURL((string)dictionary["Endpoint"]));
									if (obj != null && object.Equals(Fn.GetAttr(dictionary["url"], "isIp"), false) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], false))
									{
										return new Endpoint(Fn.Interpolate("{url#scheme}://{Bucket}.{url#authority}{url#path}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
								}
								if (object.Equals(dictionary["UseDualStack"], false) && object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["Accelerate"], true) && !Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["Region"], "aws-global"))
								{
									return new Endpoint(Fn.Interpolate("https://{Bucket}.s3-accelerate.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"us-east-1\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], false) && object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["Accelerate"], true) && !Fn.IsSet(dictionary["Endpoint"]) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], true))
								{
									if (object.Equals(dictionary["Region"], "us-east-1"))
									{
										return new Endpoint(Fn.Interpolate("https://{Bucket}.s3-accelerate.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
									return new Endpoint(Fn.Interpolate("https://{Bucket}.s3-accelerate.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], false) && object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["Accelerate"], true) && !Fn.IsSet(dictionary["Endpoint"]) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], false))
								{
									return new Endpoint(Fn.Interpolate("https://{Bucket}.s3-accelerate.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], false) && object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["Accelerate"], false) && !Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["Region"], "aws-global"))
								{
									return new Endpoint(Fn.Interpolate("https://{Bucket}.s3.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"us-east-1\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], false) && object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["Accelerate"], false) && !Fn.IsSet(dictionary["Endpoint"]) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], true))
								{
									if (object.Equals(dictionary["Region"], "us-east-1"))
									{
										return new Endpoint(Fn.Interpolate("https://{Bucket}.s3.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
									return new Endpoint(Fn.Interpolate("https://{Bucket}.s3.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], false) && object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["Accelerate"], false) && !Fn.IsSet(dictionary["Endpoint"]) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], false))
								{
									return new Endpoint(Fn.Interpolate("https://{Bucket}.s3.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
							}
							throw new AmazonClientException("Invalid region: region was not a valid DNS name.");
						}
					}
					if (Fn.IsSet(dictionary["Endpoint"]))
					{
						obj = (dictionary["url"] = Fn.ParseURL((string)dictionary["Endpoint"]));
						if (obj != null && object.Equals(Fn.GetAttr(dictionary["url"], "scheme"), "http") && Fn.IsVirtualHostableS3Bucket((string)dictionary["Bucket"], allowSubDomains: true) && object.Equals(dictionary["ForcePathStyle"], false) && object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["UseDualStack"], false) && object.Equals(dictionary["Accelerate"], false))
						{
							obj = (dictionary["partitionResult"] = Fn.Partition((string)dictionary["Region"]));
							if (obj != null)
							{
								if (Fn.IsValidHostLabel((string)dictionary["Region"], allowSubDomains: false))
								{
									return new Endpoint(Fn.Interpolate("{url#scheme}://{Bucket}.{url#authority}{url#path}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								throw new AmazonClientException("Invalid region: region was not a valid DNS name.");
							}
						}
					}
					if (object.Equals(dictionary["ForcePathStyle"], false))
					{
						obj = (dictionary["bucketArn"] = Fn.ParseArn((string)dictionary["Bucket"]));
						if (obj != null)
						{
							obj = (dictionary["arnType"] = Fn.GetAttr(dictionary["bucketArn"], "resourceId[0]"));
							if (obj != null && !object.Equals(dictionary["arnType"], ""))
							{
								if (object.Equals(Fn.GetAttr(dictionary["bucketArn"], "service"), "s3-object-lambda"))
								{
									if (object.Equals(dictionary["arnType"], "accesspoint"))
									{
										obj = (dictionary["accessPointName"] = Fn.GetAttr(dictionary["bucketArn"], "resourceId[1]"));
										if (obj != null && !object.Equals(dictionary["accessPointName"], ""))
										{
											if (object.Equals(dictionary["UseDualStack"], true))
											{
												throw new AmazonClientException("S3 Object Lambda does not support Dual-stack");
											}
											if (object.Equals(dictionary["Accelerate"], true))
											{
												throw new AmazonClientException("S3 Object Lambda does not support S3 Accelerate");
											}
											if (!object.Equals(Fn.GetAttr(dictionary["bucketArn"], "region"), ""))
											{
												if (Fn.IsSet(dictionary["DisableAccessPoints"]) && object.Equals(dictionary["DisableAccessPoints"], true))
												{
													throw new AmazonClientException("Access points are not supported for this operation");
												}
												if (!Fn.IsSet(Fn.GetAttr(dictionary["bucketArn"], "resourceId[2]")))
												{
													if (Fn.IsSet(dictionary["UseArnRegion"]) && object.Equals(dictionary["UseArnRegion"], false) && !object.Equals(Fn.GetAttr(dictionary["bucketArn"], "region"), Fn.Interpolate("{Region}", dictionary)))
													{
														throw new AmazonClientException(Fn.Interpolate("Invalid configuration: region from ARN `{bucketArn#region}` does not match client region `{Region}` and UseArnRegion is `false`", dictionary));
													}
													obj = (dictionary["bucketPartition"] = Fn.Partition((string)Fn.GetAttr(dictionary["bucketArn"], "region")));
													if (obj != null)
													{
														obj = (dictionary["partitionResult"] = Fn.Partition((string)dictionary["Region"]));
														if (obj != null)
														{
															if (object.Equals(Fn.GetAttr(dictionary["bucketPartition"], "name"), Fn.GetAttr(dictionary["partitionResult"], "name")))
															{
																if (Fn.IsValidHostLabel((string)Fn.GetAttr(dictionary["bucketArn"], "region"), allowSubDomains: true))
																{
																	if (object.Equals(Fn.GetAttr(dictionary["bucketArn"], "accountId"), ""))
																	{
																		throw new AmazonClientException("Invalid ARN: Missing account id");
																	}
																	if (Fn.IsValidHostLabel((string)Fn.GetAttr(dictionary["bucketArn"], "accountId"), allowSubDomains: false))
																	{
																		if (Fn.IsValidHostLabel((string)dictionary["accessPointName"], allowSubDomains: false))
																		{
																			if (Fn.IsSet(dictionary["Endpoint"]))
																			{
																				obj = (dictionary["url"] = Fn.ParseURL((string)dictionary["Endpoint"]));
																				if (obj != null)
																				{
																					return new Endpoint(Fn.Interpolate("{url#scheme}://{accessPointName}-{bucketArn#accountId}.{url#authority}{url#path}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3-object-lambda\",\"signingRegion\":\"{bucketArn#region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
																				}
																			}
																			if (object.Equals(dictionary["UseFIPS"], true))
																			{
																				return new Endpoint(Fn.Interpolate("https://{accessPointName}-{bucketArn#accountId}.s3-object-lambda-fips.{bucketArn#region}.{bucketPartition#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3-object-lambda\",\"signingRegion\":\"{bucketArn#region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
																			}
																			return new Endpoint(Fn.Interpolate("https://{accessPointName}-{bucketArn#accountId}.s3-object-lambda.{bucketArn#region}.{bucketPartition#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3-object-lambda\",\"signingRegion\":\"{bucketArn#region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
																		}
																		throw new AmazonClientException(Fn.Interpolate("Invalid ARN: The access point name may only contain a-z, A-Z, 0-9 and `-`. Found: `{accessPointName}`", dictionary));
																	}
																	throw new AmazonClientException(Fn.Interpolate("Invalid ARN: The account id may only contain a-z, A-Z, 0-9 and `-`. Found: `{bucketArn#accountId}`", dictionary));
																}
																throw new AmazonClientException(Fn.Interpolate("Invalid region in ARN: `{bucketArn#region}` (invalid DNS name)", dictionary));
															}
															throw new AmazonClientException(Fn.Interpolate("Client was configured for partition `{partitionResult#name}` but ARN (`{Bucket}`) has `{bucketPartition#name}`", dictionary));
														}
													}
												}
												throw new AmazonClientException("Invalid ARN: The ARN may only contain a single resource component after `accesspoint`.");
											}
											throw new AmazonClientException("Invalid ARN: bucket ARN is missing a region");
										}
										throw new AmazonClientException("Invalid ARN: Expected a resource of the format `accesspoint:<accesspoint name>` but no name was provided");
									}
									throw new AmazonClientException(Fn.Interpolate("Invalid ARN: Object Lambda ARNs only support `accesspoint` arn types, but found: `{arnType}`", dictionary));
								}
								if (object.Equals(dictionary["arnType"], "accesspoint"))
								{
									obj = (dictionary["accessPointName"] = Fn.GetAttr(dictionary["bucketArn"], "resourceId[1]"));
									if (obj != null && !object.Equals(dictionary["accessPointName"], ""))
									{
										if (!object.Equals(Fn.GetAttr(dictionary["bucketArn"], "region"), "") && object.Equals(dictionary["arnType"], "accesspoint") && !object.Equals(Fn.GetAttr(dictionary["bucketArn"], "region"), ""))
										{
											if (Fn.IsSet(dictionary["DisableAccessPoints"]) && object.Equals(dictionary["DisableAccessPoints"], true))
											{
												throw new AmazonClientException("Access points are not supported for this operation");
											}
											if (!Fn.IsSet(Fn.GetAttr(dictionary["bucketArn"], "resourceId[2]")))
											{
												if (Fn.IsSet(dictionary["UseArnRegion"]) && object.Equals(dictionary["UseArnRegion"], false) && !object.Equals(Fn.GetAttr(dictionary["bucketArn"], "region"), Fn.Interpolate("{Region}", dictionary)))
												{
													throw new AmazonClientException(Fn.Interpolate("Invalid configuration: region from ARN `{bucketArn#region}` does not match client region `{Region}` and UseArnRegion is `false`", dictionary));
												}
												obj = (dictionary["bucketPartition"] = Fn.Partition((string)Fn.GetAttr(dictionary["bucketArn"], "region")));
												if (obj != null)
												{
													obj = (dictionary["partitionResult"] = Fn.Partition((string)dictionary["Region"]));
													if (obj != null)
													{
														if (object.Equals(Fn.GetAttr(dictionary["bucketPartition"], "name"), Fn.Interpolate("{partitionResult#name}", dictionary)))
														{
															if (Fn.IsValidHostLabel((string)Fn.GetAttr(dictionary["bucketArn"], "region"), allowSubDomains: true))
															{
																if (object.Equals(Fn.GetAttr(dictionary["bucketArn"], "service"), "s3"))
																{
																	if (Fn.IsValidHostLabel((string)Fn.GetAttr(dictionary["bucketArn"], "accountId"), allowSubDomains: false))
																	{
																		if (Fn.IsValidHostLabel((string)dictionary["accessPointName"], allowSubDomains: false))
																		{
																			if (object.Equals(dictionary["Accelerate"], true))
																			{
																				throw new AmazonClientException("Access Points do not support S3 Accelerate");
																			}
																			if (object.Equals(dictionary["UseFIPS"], true) && object.Equals(dictionary["UseDualStack"], true))
																			{
																				return new Endpoint(Fn.Interpolate("https://{accessPointName}-{bucketArn#accountId}.s3-accesspoint-fips.dualstack.{bucketArn#region}.{bucketPartition#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{bucketArn#region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
																			}
																			if (object.Equals(dictionary["UseFIPS"], true) && object.Equals(dictionary["UseDualStack"], false))
																			{
																				return new Endpoint(Fn.Interpolate("https://{accessPointName}-{bucketArn#accountId}.s3-accesspoint-fips.{bucketArn#region}.{bucketPartition#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{bucketArn#region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
																			}
																			if (object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["UseDualStack"], true))
																			{
																				return new Endpoint(Fn.Interpolate("https://{accessPointName}-{bucketArn#accountId}.s3-accesspoint.dualstack.{bucketArn#region}.{bucketPartition#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{bucketArn#region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
																			}
																			if (object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["UseDualStack"], false) && Fn.IsSet(dictionary["Endpoint"]))
																			{
																				obj = (dictionary["url"] = Fn.ParseURL((string)dictionary["Endpoint"]));
																				if (obj != null)
																				{
																					return new Endpoint(Fn.Interpolate("{url#scheme}://{accessPointName}-{bucketArn#accountId}.{url#authority}{url#path}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{bucketArn#region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
																				}
																			}
																			if (object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["UseDualStack"], false))
																			{
																				return new Endpoint(Fn.Interpolate("https://{accessPointName}-{bucketArn#accountId}.s3-accesspoint.{bucketArn#region}.{bucketPartition#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{bucketArn#region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
																			}
																		}
																		throw new AmazonClientException(Fn.Interpolate("Invalid ARN: The access point name may only contain a-z, A-Z, 0-9 and `-`. Found: `{accessPointName}`", dictionary));
																	}
																	throw new AmazonClientException(Fn.Interpolate("Invalid ARN: The account id may only contain a-z, A-Z, 0-9 and `-`. Found: `{bucketArn#accountId}`", dictionary));
																}
																throw new AmazonClientException(Fn.Interpolate("Invalid ARN: The ARN was not for the S3 service, found: {bucketArn#service}", dictionary));
															}
															throw new AmazonClientException(Fn.Interpolate("Invalid region in ARN: `{bucketArn#region}` (invalid DNS name)", dictionary));
														}
														throw new AmazonClientException(Fn.Interpolate("Client was configured for partition `{partitionResult#name}` but ARN (`{Bucket}`) has `{bucketPartition#name}`", dictionary));
													}
												}
											}
											throw new AmazonClientException("Invalid ARN: The ARN may only contain a single resource component after `accesspoint`.");
										}
										if (Fn.IsValidHostLabel((string)dictionary["accessPointName"], allowSubDomains: true))
										{
											if (object.Equals(dictionary["UseDualStack"], true))
											{
												throw new AmazonClientException("S3 MRAP does not support dual-stack");
											}
											if (object.Equals(dictionary["UseFIPS"], true))
											{
												throw new AmazonClientException("S3 MRAP does not support FIPS");
											}
											if (object.Equals(dictionary["Accelerate"], true))
											{
												throw new AmazonClientException("S3 MRAP does not support S3 Accelerate");
											}
											if (object.Equals(dictionary["DisableMultiRegionAccessPoints"], true))
											{
												throw new AmazonClientException("Invalid configuration: Multi-Region Access Point ARNs are disabled.");
											}
											obj = (dictionary["mrapPartition"] = Fn.Partition((string)dictionary["Region"]));
											if (obj != null)
											{
												if (object.Equals(Fn.GetAttr(dictionary["mrapPartition"], "name"), Fn.GetAttr(dictionary["bucketArn"], "partition")))
												{
													return new Endpoint(Fn.Interpolate("https://{accessPointName}.accesspoint.s3-global.{mrapPartition#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4a\",\"signingName\":\"s3\",\"signingRegionSet\":[\"*\"]}]}", dictionary), Fn.InterpolateJson("", dictionary));
												}
												throw new AmazonClientException(Fn.Interpolate("Client was configured for partition `{mrapPartition#name}` but bucket referred to partition `{bucketArn#partition}`", dictionary));
											}
										}
										throw new AmazonClientException("Invalid Access Point Name");
									}
									throw new AmazonClientException("Invalid ARN: Expected a resource of the format `accesspoint:<accesspoint name>` but no name was provided");
								}
								if (object.Equals(Fn.GetAttr(dictionary["bucketArn"], "service"), "s3-outposts"))
								{
									if (object.Equals(dictionary["UseDualStack"], true))
									{
										throw new AmazonClientException("S3 Outposts does not support Dual-stack");
									}
									if (object.Equals(dictionary["UseFIPS"], true))
									{
										throw new AmazonClientException("S3 Outposts does not support FIPS");
									}
									if (object.Equals(dictionary["Accelerate"], true))
									{
										throw new AmazonClientException("S3 Outposts does not support S3 Accelerate");
									}
									if (Fn.IsSet(Fn.GetAttr(dictionary["bucketArn"], "resourceId[4]")))
									{
										throw new AmazonClientException("Invalid Arn: Outpost Access Point ARN contains sub resources");
									}
									obj = (dictionary["outpostId"] = Fn.GetAttr(dictionary["bucketArn"], "resourceId[1]"));
									if (obj != null)
									{
										if (Fn.IsValidHostLabel((string)dictionary["outpostId"], allowSubDomains: false))
										{
											if (Fn.IsSet(dictionary["UseArnRegion"]) && object.Equals(dictionary["UseArnRegion"], false) && !object.Equals(Fn.GetAttr(dictionary["bucketArn"], "region"), Fn.Interpolate("{Region}", dictionary)))
											{
												throw new AmazonClientException(Fn.Interpolate("Invalid configuration: region from ARN `{bucketArn#region}` does not match client region `{Region}` and UseArnRegion is `false`", dictionary));
											}
											obj = (dictionary["bucketPartition"] = Fn.Partition((string)Fn.GetAttr(dictionary["bucketArn"], "region")));
											if (obj != null)
											{
												obj = (dictionary["partitionResult"] = Fn.Partition((string)dictionary["Region"]));
												if (obj != null)
												{
													if (object.Equals(Fn.GetAttr(dictionary["bucketPartition"], "name"), Fn.GetAttr(dictionary["partitionResult"], "name")))
													{
														if (Fn.IsValidHostLabel((string)Fn.GetAttr(dictionary["bucketArn"], "region"), allowSubDomains: true))
														{
															if (Fn.IsValidHostLabel((string)Fn.GetAttr(dictionary["bucketArn"], "accountId"), allowSubDomains: false))
															{
																obj = (dictionary["outpostType"] = Fn.GetAttr(dictionary["bucketArn"], "resourceId[2]"));
																if (obj != null)
																{
																	obj = (dictionary["accessPointName"] = Fn.GetAttr(dictionary["bucketArn"], "resourceId[3]"));
																	if (obj != null)
																	{
																		if (object.Equals(dictionary["outpostType"], "accesspoint"))
																		{
																			if (Fn.IsSet(dictionary["Endpoint"]))
																			{
																				obj = (dictionary["url"] = Fn.ParseURL((string)dictionary["Endpoint"]));
																				if (obj != null)
																				{
																					return new Endpoint(Fn.Interpolate("https://{accessPointName}-{bucketArn#accountId}.{outpostId}.{url#authority}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4a\",\"signingName\":\"s3-outposts\",\"signingRegionSet\":[\"*\"]},{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3-outposts\",\"signingRegion\":\"{bucketArn#region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
																				}
																			}
																			return new Endpoint(Fn.Interpolate("https://{accessPointName}-{bucketArn#accountId}.{outpostId}.s3-outposts.{bucketArn#region}.{bucketPartition#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4a\",\"signingName\":\"s3-outposts\",\"signingRegionSet\":[\"*\"]},{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3-outposts\",\"signingRegion\":\"{bucketArn#region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
																		}
																		throw new AmazonClientException(Fn.Interpolate("Expected an outpost type `accesspoint`, found {outpostType}", dictionary));
																	}
																	throw new AmazonClientException("Invalid ARN: expected an access point name");
																}
																throw new AmazonClientException("Invalid ARN: Expected a 4-component resource");
															}
															throw new AmazonClientException(Fn.Interpolate("Invalid ARN: The account id may only contain a-z, A-Z, 0-9 and `-`. Found: `{bucketArn#accountId}`", dictionary));
														}
														throw new AmazonClientException(Fn.Interpolate("Invalid region in ARN: `{bucketArn#region}` (invalid DNS name)", dictionary));
													}
													throw new AmazonClientException(Fn.Interpolate("Client was configured for partition `{partitionResult#name}` but ARN (`{Bucket}`) has `{bucketPartition#name}`", dictionary));
												}
											}
										}
										throw new AmazonClientException(Fn.Interpolate("Invalid ARN: The outpost Id may only contain a-z, A-Z, 0-9 and `-`. Found: `{outpostId}`", dictionary));
									}
									throw new AmazonClientException("Invalid ARN: The Outpost Id was not set");
								}
								throw new AmazonClientException(Fn.Interpolate("Invalid ARN: Unrecognized format: {Bucket} (type: {arnType})", dictionary));
							}
							throw new AmazonClientException("Invalid ARN: No ARN type specified");
						}
					}
					obj = (dictionary["arnPrefix"] = Fn.Substring((string)dictionary["Bucket"], 0, 4, reverse: false));
					if (obj != null && object.Equals(dictionary["arnPrefix"], "arn:") && !Fn.IsSet(Fn.ParseArn((string)dictionary["Bucket"])))
					{
						throw new AmazonClientException(Fn.Interpolate("Invalid ARN: `{Bucket}` was not a valid ARN", dictionary));
					}
					if (object.Equals(dictionary["ForcePathStyle"], true) && Fn.ParseArn((string)dictionary["Bucket"]) != null)
					{
						throw new AmazonClientException("Path-style addressing cannot be used with ARN buckets");
					}
					obj = (dictionary["uri_encoded_bucket"] = Fn.UriEncode((string)dictionary["Bucket"]));
					if (obj != null)
					{
						obj = (dictionary["partitionResult"] = Fn.Partition((string)dictionary["Region"]));
						if (obj != null)
						{
							if (object.Equals(dictionary["Accelerate"], false))
							{
								if (object.Equals(dictionary["UseDualStack"], true) && !Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["UseFIPS"], true) && object.Equals(dictionary["Region"], "aws-global"))
								{
									return new Endpoint(Fn.Interpolate("https://s3-fips.dualstack.us-east-1.{partitionResult#dnsSuffix}/{uri_encoded_bucket}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"us-east-1\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], true) && !Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["UseFIPS"], true) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], true))
								{
									return new Endpoint(Fn.Interpolate("https://s3-fips.dualstack.{Region}.{partitionResult#dnsSuffix}/{uri_encoded_bucket}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], true) && !Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["UseFIPS"], true) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], false))
								{
									return new Endpoint(Fn.Interpolate("https://s3-fips.dualstack.{Region}.{partitionResult#dnsSuffix}/{uri_encoded_bucket}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], false) && !Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["UseFIPS"], true) && object.Equals(dictionary["Region"], "aws-global"))
								{
									return new Endpoint(Fn.Interpolate("https://s3-fips.us-east-1.{partitionResult#dnsSuffix}/{uri_encoded_bucket}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"us-east-1\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], false) && !Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["UseFIPS"], true) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], true))
								{
									return new Endpoint(Fn.Interpolate("https://s3-fips.{Region}.{partitionResult#dnsSuffix}/{uri_encoded_bucket}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], false) && !Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["UseFIPS"], true) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], false))
								{
									return new Endpoint(Fn.Interpolate("https://s3-fips.{Region}.{partitionResult#dnsSuffix}/{uri_encoded_bucket}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], true) && !Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["Region"], "aws-global"))
								{
									return new Endpoint(Fn.Interpolate("https://s3.dualstack.us-east-1.{partitionResult#dnsSuffix}/{uri_encoded_bucket}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"us-east-1\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], true) && !Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["UseFIPS"], false) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], true))
								{
									return new Endpoint(Fn.Interpolate("https://s3.dualstack.{Region}.{partitionResult#dnsSuffix}/{uri_encoded_bucket}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], true) && !Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["UseFIPS"], false) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], false))
								{
									return new Endpoint(Fn.Interpolate("https://s3.dualstack.{Region}.{partitionResult#dnsSuffix}/{uri_encoded_bucket}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], false) && Fn.IsSet(dictionary["Endpoint"]))
								{
									obj = (dictionary["url"] = Fn.ParseURL((string)dictionary["Endpoint"]));
									if (obj != null && object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["Region"], "aws-global"))
									{
										return new Endpoint(Fn.Interpolate("{url#scheme}://{url#authority}{url#normalizedPath}{uri_encoded_bucket}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"us-east-1\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
								}
								if (object.Equals(dictionary["UseDualStack"], false) && Fn.IsSet(dictionary["Endpoint"]))
								{
									obj = (dictionary["url"] = Fn.ParseURL((string)dictionary["Endpoint"]));
									if (obj != null && object.Equals(dictionary["UseFIPS"], false) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], true))
									{
										if (object.Equals(dictionary["Region"], "us-east-1"))
										{
											return new Endpoint(Fn.Interpolate("{url#scheme}://{url#authority}{url#normalizedPath}{uri_encoded_bucket}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
										}
										return new Endpoint(Fn.Interpolate("{url#scheme}://{url#authority}{url#normalizedPath}{uri_encoded_bucket}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
								}
								if (object.Equals(dictionary["UseDualStack"], false) && Fn.IsSet(dictionary["Endpoint"]))
								{
									obj = (dictionary["url"] = Fn.ParseURL((string)dictionary["Endpoint"]));
									if (obj != null && object.Equals(dictionary["UseFIPS"], false) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], false))
									{
										return new Endpoint(Fn.Interpolate("{url#scheme}://{url#authority}{url#normalizedPath}{uri_encoded_bucket}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
								}
								if (object.Equals(dictionary["UseDualStack"], false) && !Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["Region"], "aws-global"))
								{
									return new Endpoint(Fn.Interpolate("https://s3.{partitionResult#dnsSuffix}/{uri_encoded_bucket}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"us-east-1\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], false) && !Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["UseFIPS"], false) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], true))
								{
									if (object.Equals(dictionary["Region"], "us-east-1"))
									{
										return new Endpoint(Fn.Interpolate("https://s3.{partitionResult#dnsSuffix}/{uri_encoded_bucket}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
									return new Endpoint(Fn.Interpolate("https://s3.{Region}.{partitionResult#dnsSuffix}/{uri_encoded_bucket}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								if (object.Equals(dictionary["UseDualStack"], false) && !Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["UseFIPS"], false) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], false))
								{
									return new Endpoint(Fn.Interpolate("https://s3.{Region}.{partitionResult#dnsSuffix}/{uri_encoded_bucket}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
							}
							throw new AmazonClientException("Path-style addressing cannot be used with S3 Accelerate");
						}
					}
				}
				if (Fn.IsSet(dictionary["UseObjectLambdaEndpoint"]) && object.Equals(dictionary["UseObjectLambdaEndpoint"], true))
				{
					object obj = (dictionary["partitionResult"] = Fn.Partition((string)dictionary["Region"]));
					if (obj != null)
					{
						if (Fn.IsValidHostLabel((string)dictionary["Region"], allowSubDomains: true))
						{
							if (object.Equals(dictionary["UseDualStack"], true))
							{
								throw new AmazonClientException("S3 Object Lambda does not support Dual-stack");
							}
							if (object.Equals(dictionary["Accelerate"], true))
							{
								throw new AmazonClientException("S3 Object Lambda does not support S3 Accelerate");
							}
							if (Fn.IsSet(dictionary["Endpoint"]))
							{
								obj = (dictionary["url"] = Fn.ParseURL((string)dictionary["Endpoint"]));
								if (obj != null)
								{
									return new Endpoint(Fn.Interpolate("{url#scheme}://{url#authority}{url#path}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3-object-lambda\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
							}
							if (object.Equals(dictionary["UseFIPS"], true))
							{
								return new Endpoint(Fn.Interpolate("https://s3-object-lambda-fips.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3-object-lambda\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
							}
							return new Endpoint(Fn.Interpolate("https://s3-object-lambda.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3-object-lambda\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
						}
						throw new AmazonClientException("Invalid region: region was not a valid DNS name.");
					}
				}
				if (!Fn.IsSet(dictionary["Bucket"]))
				{
					object obj = (dictionary["partitionResult"] = Fn.Partition((string)dictionary["Region"]));
					if (obj != null)
					{
						if (Fn.IsValidHostLabel((string)dictionary["Region"], allowSubDomains: true))
						{
							if (object.Equals(dictionary["UseFIPS"], true) && object.Equals(dictionary["UseDualStack"], true) && !Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["Region"], "aws-global"))
							{
								return new Endpoint(Fn.Interpolate("https://s3-fips.dualstack.us-east-1.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"us-east-1\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
							}
							if (object.Equals(dictionary["UseFIPS"], true) && object.Equals(dictionary["UseDualStack"], true) && !Fn.IsSet(dictionary["Endpoint"]) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], true))
							{
								return new Endpoint(Fn.Interpolate("https://s3-fips.dualstack.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
							}
							if (object.Equals(dictionary["UseFIPS"], true) && object.Equals(dictionary["UseDualStack"], true) && !Fn.IsSet(dictionary["Endpoint"]) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], false))
							{
								return new Endpoint(Fn.Interpolate("https://s3-fips.dualstack.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
							}
							if (object.Equals(dictionary["UseFIPS"], true) && object.Equals(dictionary["UseDualStack"], false) && !Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["Region"], "aws-global"))
							{
								return new Endpoint(Fn.Interpolate("https://s3-fips.us-east-1.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"us-east-1\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
							}
							if (object.Equals(dictionary["UseFIPS"], true) && object.Equals(dictionary["UseDualStack"], false) && !Fn.IsSet(dictionary["Endpoint"]) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], true))
							{
								return new Endpoint(Fn.Interpolate("https://s3-fips.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
							}
							if (object.Equals(dictionary["UseFIPS"], true) && object.Equals(dictionary["UseDualStack"], false) && !Fn.IsSet(dictionary["Endpoint"]) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], false))
							{
								return new Endpoint(Fn.Interpolate("https://s3-fips.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
							}
							if (object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["UseDualStack"], true) && !Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["Region"], "aws-global"))
							{
								return new Endpoint(Fn.Interpolate("https://s3.dualstack.us-east-1.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"us-east-1\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
							}
							if (object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["UseDualStack"], true) && !Fn.IsSet(dictionary["Endpoint"]) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], true))
							{
								return new Endpoint(Fn.Interpolate("https://s3.dualstack.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
							}
							if (object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["UseDualStack"], true) && !Fn.IsSet(dictionary["Endpoint"]) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], false))
							{
								return new Endpoint(Fn.Interpolate("https://s3.dualstack.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
							}
							if (object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["UseDualStack"], false) && Fn.IsSet(dictionary["Endpoint"]))
							{
								obj = (dictionary["url"] = Fn.ParseURL((string)dictionary["Endpoint"]));
								if (obj != null && object.Equals(dictionary["Region"], "aws-global"))
								{
									return new Endpoint(Fn.Interpolate("{url#scheme}://{url#authority}{url#path}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"us-east-1\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
							}
							if (object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["UseDualStack"], false) && Fn.IsSet(dictionary["Endpoint"]))
							{
								obj = (dictionary["url"] = Fn.ParseURL((string)dictionary["Endpoint"]));
								if (obj != null && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], true))
								{
									if (object.Equals(dictionary["Region"], "us-east-1"))
									{
										return new Endpoint(Fn.Interpolate("{url#scheme}://{url#authority}{url#path}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
									}
									return new Endpoint(Fn.Interpolate("{url#scheme}://{url#authority}{url#path}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
							}
							if (object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["UseDualStack"], false) && Fn.IsSet(dictionary["Endpoint"]))
							{
								obj = (dictionary["url"] = Fn.ParseURL((string)dictionary["Endpoint"]));
								if (obj != null && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], false))
								{
									return new Endpoint(Fn.Interpolate("{url#scheme}://{url#authority}{url#path}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
							}
							if (object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["UseDualStack"], false) && !Fn.IsSet(dictionary["Endpoint"]) && object.Equals(dictionary["Region"], "aws-global"))
							{
								return new Endpoint(Fn.Interpolate("https://s3.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"us-east-1\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
							}
							if (object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["UseDualStack"], false) && !Fn.IsSet(dictionary["Endpoint"]) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], true))
							{
								if (object.Equals(dictionary["Region"], "us-east-1"))
								{
									return new Endpoint(Fn.Interpolate("https://s3.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
								}
								return new Endpoint(Fn.Interpolate("https://s3.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
							}
							if (object.Equals(dictionary["UseFIPS"], false) && object.Equals(dictionary["UseDualStack"], false) && !Fn.IsSet(dictionary["Endpoint"]) && !object.Equals(dictionary["Region"], "aws-global") && object.Equals(dictionary["UseGlobalEndpoint"], false))
							{
								return new Endpoint(Fn.Interpolate("https://s3.{Region}.{partitionResult#dnsSuffix}", dictionary), Fn.InterpolateJson("{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"{Region}\"}]}", dictionary), Fn.InterpolateJson("", dictionary));
							}
						}
						throw new AmazonClientException("Invalid region: region was not a valid DNS name.");
					}
				}
			}
			throw new AmazonClientException("A region must be set when sending requests to S3.");
		}
	}
}
