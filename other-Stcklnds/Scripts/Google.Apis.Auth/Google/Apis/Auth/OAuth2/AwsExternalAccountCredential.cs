using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Http;
using Google.Apis.Json;
using Google.Apis.Util;
using Newtonsoft.Json;

namespace Google.Apis.Auth.OAuth2
{
	public sealed class AwsExternalAccountCredential : ExternalAccountCredential, IGoogleCredential, ICredential, IConfigurableHttpClientInitializer, ITokenAccess, ITokenAccessWithHeaders, IHttpExecuteInterceptor
	{
		internal sealed class AwsMetadataServerClient
		{
			private const string AwsMetadataServerHostV4 = "169.254.169.254";

			private const string AwsMetadataServerHostV6 = "fd00:ec2::254";

			private const string ImdsV2SessionTokenTtlHeaderName = "X-aws-ec2-metadata-token-ttl-seconds";

			private const string ImdsV2SessionTokenTtlSeconds = "3600";

			private const string MetatadaServerRequestImdsV2SessionTokenHeaderName = "X-aws-ec2-metadata-token";

			private readonly string _imdsV2SessionTokenUrl;

			private readonly Lazy<Task<string>> _imdsV2SessionToken;

			private readonly HttpClient _httpClient;

			private readonly CancellationToken _cancellationToken;

			internal AwsMetadataServerClient(string imdsV2SessionTokenUrl, HttpClient httpClient, CancellationToken cancellationToken)
			{
				_httpClient = httpClient.ThrowIfNull("httpClient");
				_imdsV2SessionTokenUrl = imdsV2SessionTokenUrl;
				_imdsV2SessionToken = new Lazy<Task<string>>(FetchImdsV2SessionTokenAsync);
				_cancellationToken = cancellationToken;
			}

			internal async Task<string> FetchImdsV2SessionTokenAsync()
			{
				if (string.IsNullOrEmpty(_imdsV2SessionTokenUrl))
				{
					return null;
				}
				HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, _imdsV2SessionTokenUrl)
				{
					Headers = { { "X-aws-ec2-metadata-token-ttl-seconds", "3600" } }
				};
				HttpResponseMessage obj = await _httpClient.SendAsync(request, _cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				obj.EnsureSuccessStatusCode();
				return await obj.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
			}

			internal async Task<string> FetchMetadataAsync(string metadataUrl)
			{
				HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, metadataUrl);
				string text = await _imdsV2SessionToken.Value.ConfigureAwait(continueOnCapturedContext: false);
				if (text != null)
				{
					request.Headers.Add("X-aws-ec2-metadata-token", text);
				}
				HttpResponseMessage obj = await _httpClient.SendAsync(request, _cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				obj.EnsureSuccessStatusCode();
				return await obj.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
			}

			internal static void ValidateMetadataServerUrlIfAny(string url, string nameOfData)
			{
				if (!string.IsNullOrEmpty(url))
				{
					Uri uri = new Uri(url);
					if (uri.Host != "169.254.169.254" && uri.Host != "fd00:ec2::254")
					{
						throw new InvalidOperationException("The host of the URL given for fetching the " + nameOfData + " does not match one of the expected hosts. Given URL: " + url + " Expected hosts: 169.254.169.254 or fd00:ec2::254");
					}
				}
			}
		}

		internal sealed class AwsRegion
		{
			private static readonly string[] OrderedRegionEnvVars = new string[2] { "AWS_REGION", "AWS_DEFAULT_REGION" };

			internal string Region { get; }

			internal AwsRegion(string region)
			{
				Region = region;
			}

			internal static async Task<AwsRegion> FetchAsync(AwsMetadataServerClient metadataClient, string regionUrl)
			{
				AwsRegion awsRegion = MaybeFromEnvVars();
				if (awsRegion == null)
				{
					awsRegion = (await MaybeFromMetadataAsync(metadataClient, regionUrl).ConfigureAwait(continueOnCapturedContext: false)) ?? throw new InvalidOperationException("Couldn't determine the AWS region. None of the following environment variables have been set: " + string.Join(",", OrderedRegionEnvVars) + ". And the RegionUrl was not specified in the credential configuration or a region value couldn't be fetched from it.");
				}
				return awsRegion;
			}

			internal static AwsRegion MaybeFromEnvVars()
			{
				string[] orderedRegionEnvVars = OrderedRegionEnvVars;
				for (int i = 0; i < orderedRegionEnvVars.Length; i++)
				{
					string nonEmptyEnvVarValue = GetNonEmptyEnvVarValue(orderedRegionEnvVars[i]);
					if (nonEmptyEnvVarValue != null)
					{
						return new AwsRegion(nonEmptyEnvVarValue);
					}
				}
				return null;
			}

			internal static async Task<AwsRegion> MaybeFromMetadataAsync(AwsMetadataServerClient metadataClient, string regionUrl)
			{
				bool flag = !string.IsNullOrEmpty(regionUrl);
				string text = default(string);
				if (flag)
				{
					text = await metadataClient.FetchMetadataAsync(regionUrl).ConfigureAwait(continueOnCapturedContext: false);
					flag = text != null;
				}
				if (flag && text != "")
				{
					return new AwsRegion(text.Substring(0, text.Length - 1));
				}
				return null;
			}
		}

		internal sealed class AwsSecurityCredentials
		{
			private struct AwsSecurityCredentialsResponse
			{
				internal const string SuccessStatusCode = "Success";

				[JsonIgnore]
				public bool IsSuccess => Code?.Equals("Success", StringComparison.OrdinalIgnoreCase) ?? false;

				[JsonProperty("Code")]
				public string Code { get; set; }

				[JsonProperty("AccessKeyId")]
				public string AccessKeyId { get; set; }

				[JsonProperty("SecretAccessKey")]
				public string SecretAccessKey { get; set; }

				[JsonProperty("Token")]
				public string Token { get; set; }
			}

			private const string AccessKeyIdEnvVar = "AWS_ACCESS_KEY_ID";

			private const string SecretAccessKeyEnvVar = "AWS_SECRET_ACCESS_KEY";

			private const string TokenEnvVar = "AWS_SESSION_TOKEN";

			internal string AccessKeyId { get; }

			internal string SecretAccessKey { get; }

			internal string Token { get; }

			internal AwsSecurityCredentials(string accessKeyId, string secretAccessKey, string token)
			{
				AccessKeyId = accessKeyId;
				SecretAccessKey = secretAccessKey;
				Token = token;
			}

			internal static async Task<AwsSecurityCredentials> FetchAsync(AwsMetadataServerClient metadataClient, string credentialUrl)
			{
				AwsSecurityCredentials awsSecurityCredentials = MaybeFromEnvVars();
				if (awsSecurityCredentials == null)
				{
					awsSecurityCredentials = (await MaybeFromMetadataAsync(metadataClient, credentialUrl).ConfigureAwait(continueOnCapturedContext: false)) ?? throw new InvalidOperationException("Couldn't determine the AWS security credentials. At least one of the following environment variables was not set: AWS_ACCESS_KEY_ID, AWS_SECRET_ACCESS_KEY. And the SecurityCredentialsUrl was not specified in the credential configuration or no security credentials could be obtained from it.");
				}
				return awsSecurityCredentials;
			}

			internal static AwsSecurityCredentials MaybeFromEnvVars()
			{
				string nonEmptyEnvVarValue = GetNonEmptyEnvVarValue("AWS_ACCESS_KEY_ID");
				if (nonEmptyEnvVarValue != null)
				{
					string nonEmptyEnvVarValue2 = GetNonEmptyEnvVarValue("AWS_SECRET_ACCESS_KEY");
					if (nonEmptyEnvVarValue2 != null)
					{
						return new AwsSecurityCredentials(nonEmptyEnvVarValue, nonEmptyEnvVarValue2, GetNonEmptyEnvVarValue("AWS_SESSION_TOKEN"));
					}
				}
				return null;
			}

			internal static async Task<AwsSecurityCredentials> MaybeFromMetadataAsync(AwsMetadataServerClient metadataClient, string credentialUrl)
			{
				bool flag = !string.IsNullOrEmpty(credentialUrl);
				string credentialEndpoint = default(string);
				if (flag)
				{
					credentialEndpoint = await BuildSecurityCredentialsEndpointAsync().ConfigureAwait(continueOnCapturedContext: false);
					flag = credentialEndpoint != null;
				}
				bool flag2 = flag;
				string credentialJson = default(string);
				if (flag2)
				{
					credentialJson = await metadataClient.FetchMetadataAsync(credentialEndpoint).ConfigureAwait(continueOnCapturedContext: false);
					flag2 = credentialJson != null;
				}
				if (flag2 && credentialJson != "")
				{
					AwsSecurityCredentialsResponse awsSecurityCredentialsResponse = NewtonsoftJsonSerializer.Instance.Deserialize<AwsSecurityCredentialsResponse>(credentialJson);
					if (awsSecurityCredentialsResponse.IsSuccess && !string.IsNullOrEmpty(awsSecurityCredentialsResponse.AccessKeyId) && !string.IsNullOrEmpty(awsSecurityCredentialsResponse.SecretAccessKey))
					{
						return new AwsSecurityCredentials(awsSecurityCredentialsResponse.AccessKeyId, awsSecurityCredentialsResponse.SecretAccessKey, (awsSecurityCredentialsResponse.Token == "") ? null : awsSecurityCredentialsResponse.Token);
					}
					throw new InvalidOperationException("The request to the metadata server security credentials endpoint " + credentialEndpoint + " was not successful. The response was " + credentialJson);
				}
				return null;
				async Task<string> BuildSecurityCredentialsEndpointAsync()
				{
					string text = await metadataClient.FetchMetadataAsync(credentialUrl).ConfigureAwait(continueOnCapturedContext: false);
					if (text != null)
					{
						using StringReader reader = new StringReader(text);
						string text2 = await reader.ReadLineAsync().ConfigureAwait(continueOnCapturedContext: false);
						if (text2 != null && text2 != "")
						{
							return credentialUrl.EndsWith("/", StringComparison.Ordinal) ? (credentialUrl + text2) : (credentialUrl + "/" + text2);
						}
					}
					return null;
				}
			}
		}

		internal sealed class AwsSignedSubjectToken
		{
			public sealed class AwsSignedSubjectTokenHeader
			{
				[JsonProperty("key")]
				public string Key { get; set; }

				[JsonProperty("value")]
				public string Value { get; set; }

				public AwsSignedSubjectTokenHeader()
				{
				}

				internal AwsSignedSubjectTokenHeader(string key, string value)
				{
					Key = key;
					Value = value;
				}
			}

			private const string StVerificationHttpMethod = "POST";

			private const string BasicFormatIso8601 = "yyyyMMdd'T'HHmmss'Z'";

			private const string ShortDateFormat = "yyyyMMdd";

			private const string AwsRequestType = "aws4_request";

			private const string AwsSha256Designation = "AWS4-HMAC-SHA256";

			[JsonProperty("url")]
			public string Url { get; set; }

			[JsonProperty("method")]
			public string HttpMethod { get; set; }

			[JsonProperty("body")]
			public string Body { get; set; }

			[JsonProperty("headers")]
			public AwsSignedSubjectTokenHeader[] Headers { get; set; }

			public AwsSignedSubjectToken()
			{
			}

			private AwsSignedSubjectToken(string url, string httpMethod, string body, AwsSignedSubjectTokenHeader[] headers)
			{
				Url = url;
				HttpMethod = httpMethod;
				Body = body;
				Headers = headers;
			}

			internal static AwsSignedSubjectToken Create(AwsSecurityCredentials credentials, AwsRegion region, Uri verificationRequestUrl, string audience, IClock clock)
			{
				credentials.ThrowIfNull("credentials");
				region.ThrowIfNull("region");
				verificationRequestUrl.ThrowIfNull("verificationRequestUrl");
				audience.ThrowIfNull("audience");
				clock.ThrowIfNull("clock");
				DateTime utcNow = clock.UtcNow;
				string host = verificationRequestUrl.Host;
				string serviceName = host.Split(new char[1] { '.' })[0];
				IDictionary<string, string> source = CreateCanonicalHeaders();
				IOrderedEnumerable<KeyValuePair<string, string>> sortedHeaders = source.OrderBy((KeyValuePair<string, string> pair) => pair.Key, StringComparer.Ordinal);
				string signedHeaders = string.Join(";", sortedHeaders.Select((KeyValuePair<string, string> pair) => pair.Key));
				string credentialScope = utcNow.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + "/" + region.Region + "/" + serviceName + "/aws4_request";
				string hashedCanonicalRequest = GetHashedCanonicalRequest();
				string stringToSign = GetStringToSign();
				string signature = GetSignature();
				string value = GetAuthorizationHeader();
				return new AwsSignedSubjectToken(verificationRequestUrl.ToString(), "POST", "", source.Select((KeyValuePair<string, string> pair) => new AwsSignedSubjectTokenHeader(pair.Key, pair.Value)).Concat(Enumerable.Repeat(new AwsSignedSubjectTokenHeader("Authorization", value), 1)).ToArray());
				IDictionary<string, string> CreateCanonicalHeaders()
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>
					{
						{ "host", host },
						{
							"x-amz-date",
							utcNow.ToString("yyyyMMdd'T'HHmmss'Z'", CultureInfo.InvariantCulture)
						},
						{
							"x-goog-cloud-target-resource",
							audience.Trim()
						}
					};
					if (credentials.Token != null)
					{
						dictionary["x-amz-security-token"] = credentials.Token;
					}
					return dictionary;
				}
				string GetAuthorizationHeader()
				{
					StringBuilder stringBuilder = new StringBuilder("AWS4-HMAC-SHA256").Append(" ");
					stringBuilder.Append("Credential=");
					stringBuilder.Append(credentials.AccessKeyId).Append("/");
					stringBuilder.Append(credentialScope).Append(", ");
					stringBuilder.Append("SignedHeaders=");
					stringBuilder.Append(signedHeaders).Append(", ");
					stringBuilder.Append("Signature=");
					stringBuilder.Append(signature);
					return stringBuilder.ToString();
				}
				string GetHashedCanonicalRequest()
				{
					StringBuilder stringBuilder = new StringBuilder("POST").Append("\n");
					stringBuilder.Append(verificationRequestUrl.GetPathForAwsCanonicalRequest()).Append("\n");
					stringBuilder.Append(verificationRequestUrl.GetQueryStringForAwsCanonicalRequest()).Append("\n");
					foreach (KeyValuePair<string, string> item in sortedHeaders)
					{
						stringBuilder.Append(item.Key);
						stringBuilder.Append(":");
						stringBuilder.Append(item.Value);
						stringBuilder.Append("\n");
					}
					stringBuilder.Append("\n");
					stringBuilder.Append(signedHeaders).Append("\n");
					stringBuilder.Append("e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855");
					return GetHexEncodedSha256Hash(stringBuilder.ToString());
				}
				string GetSignature()
				{
					return FormatHex(GetHmacSha256Hash(GetHmacSha256Hash(GetHmacSha256Hash(GetHmacSha256Hash(GetHmacSha256Hash(Encoding.UTF8.GetBytes("AWS4" + credentials.SecretAccessKey), utcNow.ToString("yyyyMMdd", CultureInfo.InvariantCulture)), region.Region), serviceName), "aws4_request"), stringToSign));
				}
				string GetStringToSign()
				{
					StringBuilder stringBuilder = new StringBuilder("AWS4-HMAC-SHA256").Append("\n");
					stringBuilder.Append(utcNow.ToString("yyyyMMdd'T'HHmmss'Z'", CultureInfo.InvariantCulture)).Append("\n");
					stringBuilder.Append(credentialScope).Append("\n");
					stringBuilder.Append(hashedCanonicalRequest);
					return stringBuilder.ToString();
				}
			}

			private static byte[] GetHmacSha256Hash(byte[] key, string value)
			{
				using HMACSHA256 hMACSHA = new HMACSHA256(key);
				return hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(value));
			}

			private static string GetHexEncodedSha256Hash(string value)
			{
				using SHA256 sHA = SHA256.Create();
				return FormatHex(sHA.ComputeHash(Encoding.UTF8.GetBytes(value)));
			}

			private static string FormatHex(byte[] value)
			{
				char[] array = new char[value.Length * 2];
				for (int i = 0; i < value.Length; i++)
				{
					array[i * 2] = "0123456789abcdef"[value[i] >> 4];
					array[i * 2 + 1] = "0123456789abcdef"[value[i] & 0xF];
				}
				return new string(array);
			}
		}

		internal new class Initializer : ExternalAccountCredential.Initializer
		{
			internal string RegionUrl { get; set; }

			internal string RegionalCredentialVerificationUrl { get; }

			internal string SecurityCredentialsUrl { get; set; }

			internal string ImdsV2SessionTokenUrl { get; set; }

			internal Initializer(string tokenUrl, string audience, string subjectTokenType, string regionalCredentialVerificationUrl)
				: base(tokenUrl, audience, subjectTokenType)
			{
				RegionalCredentialVerificationUrl = regionalCredentialVerificationUrl.ThrowIfNull("regionalCredentialVerificationUrl");
			}

			internal Initializer(Initializer other)
				: base(other)
			{
				RegionUrl = other.RegionUrl;
				RegionalCredentialVerificationUrl = other.RegionalCredentialVerificationUrl;
				SecurityCredentialsUrl = other.SecurityCredentialsUrl;
				ImdsV2SessionTokenUrl = other.ImdsV2SessionTokenUrl;
			}

			internal Initializer(AwsExternalAccountCredential other)
				: base(other)
			{
				RegionUrl = other.RegionUrl;
				RegionalCredentialVerificationUrl = other.RegionalCredentialVerificationUrl;
				SecurityCredentialsUrl = other.SecurityCredentialsUrl;
				ImdsV2SessionTokenUrl = other.ImdsV2SessionTokenUrl;
			}
		}

		internal const string SupportedVersion = "aws1";

		private const string RegionalCredentialVerificationUrlRegionPlaceholder = "{region}";

		internal string RegionUrl { get; }

		internal string RegionalCredentialVerificationUrl { get; }

		internal string SecurityCredentialsUrl { get; }

		internal string ImdsV2SessionTokenUrl { get; }

		string IGoogleCredential.QuotaProject => base.QuotaProject;

		bool IGoogleCredential.HasExplicitScopes => base.HasExplicitScopes;

		bool IGoogleCredential.SupportsExplicitScopes => base.SupportsExplicitScopes;

		internal AwsExternalAccountCredential(Initializer initializer)
			: base(initializer)
		{
			AwsMetadataServerClient.ValidateMetadataServerUrlIfAny(initializer.ImdsV2SessionTokenUrl, "IMDS V2 Session Token");
			AwsMetadataServerClient.ValidateMetadataServerUrlIfAny(initializer.RegionUrl, "Region");
			AwsMetadataServerClient.ValidateMetadataServerUrlIfAny(initializer.SecurityCredentialsUrl, "Security Credentials");
			RegionUrl = initializer.RegionUrl;
			RegionalCredentialVerificationUrl = initializer.RegionalCredentialVerificationUrl;
			SecurityCredentialsUrl = initializer.SecurityCredentialsUrl;
			ImdsV2SessionTokenUrl = initializer.ImdsV2SessionTokenUrl;
		}

		private protected override GoogleCredential WithoutImpersonationConfigurationImpl()
		{
			if (base.ServiceAccountImpersonationUrl != null)
			{
				return new GoogleCredential(new AwsExternalAccountCredential(new Initializer(this)
				{
					ServiceAccountImpersonationUrl = null
				}));
			}
			return new GoogleCredential(this);
		}

		protected override async Task<string> GetSubjectTokenAsyncImpl(CancellationToken taskCancellationToken)
		{
			AwsMetadataServerClient metadataClient = new AwsMetadataServerClient(ImdsV2SessionTokenUrl, base.HttpClient, taskCancellationToken);
			AwsRegion awsRegion = await AwsRegion.FetchAsync(metadataClient, RegionUrl).ConfigureAwait(continueOnCapturedContext: false);
			AwsSecurityCredentials credentials = await AwsSecurityCredentials.FetchAsync(metadataClient, SecurityCredentialsUrl).ConfigureAwait(continueOnCapturedContext: false);
			string uriString = RegionalCredentialVerificationUrl.Replace("{region}", awsRegion.Region);
			AwsSignedSubjectToken obj = AwsSignedSubjectToken.Create(credentials, awsRegion, new Uri(uriString), base.Audience, base.Clock);
			return Uri.EscapeDataString(NewtonsoftJsonSerializer.Instance.Serialize(obj));
		}

		IGoogleCredential IGoogleCredential.WithQuotaProject(string quotaProject)
		{
			return new AwsExternalAccountCredential(new Initializer(this)
			{
				QuotaProject = quotaProject
			});
		}

		IGoogleCredential IGoogleCredential.MaybeWithScopes(IEnumerable<string> scopes)
		{
			return new AwsExternalAccountCredential(new Initializer(this)
			{
				Scopes = scopes
			});
		}

		IGoogleCredential IGoogleCredential.WithUserForDomainWideDelegation(string user)
		{
			return WithUserForDomainWideDelegation(user);
		}

		IGoogleCredential IGoogleCredential.WithHttpClientFactory(IHttpClientFactory httpClientFactory)
		{
			return new AwsExternalAccountCredential(new Initializer(this)
			{
				HttpClientFactory = httpClientFactory
			});
		}

		private static string GetNonEmptyEnvVarValue(string envVar)
		{
			string environmentVariable = Environment.GetEnvironmentVariable(envVar);
			if (environmentVariable != null && environmentVariable != "")
			{
				return environmentVariable;
			}
			return null;
		}
	}
}
