using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AWSSDK.Runtime.Internal.Util;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Util;
using Amazon.Util.Internal;

namespace Amazon.Util
{
	public static class EC2InstanceMetadata
	{
		private class IMDSDisabledException : InvalidOperationException
		{
		}

		public static readonly string LATEST = "/latest";

		public static readonly string AWS_EC2_METADATA_DISABLED = "AWS_EC2_METADATA_DISABLED";

		private static int DEFAULT_RETRIES = 3;

		private static int MIN_PAUSE_MS = 250;

		private static int DEFAULT_APITOKEN_TTL = 21600;

		private static Dictionary<string, string> _cache = new Dictionary<string, string>();

		private static ReaderWriterLockSlim metadataLock = new ReaderWriterLockSlim();

		private static readonly TimeSpan metadataLockTimeout = TimeSpan.FromMilliseconds(5000.0);

		private static readonly string _userAgent = InternalSDKUtils.BuildUserAgentString(string.Empty, string.Empty);

		public static string ServiceEndpoint
		{
			get
			{
				if (!string.IsNullOrEmpty(FallbackInternalConfigurationFactory.EC2MetadataServiceEndpoint))
				{
					return FallbackInternalConfigurationFactory.EC2MetadataServiceEndpoint;
				}
				if (FallbackInternalConfigurationFactory.EC2MetadataServiceEndpointMode == EC2MetadataServiceEndpointMode.IPv6)
				{
					return "http://[fd00:ec2::254]";
				}
				return "http://169.254.169.254";
			}
		}

		public static string EC2MetadataRoot => ServiceEndpoint + LATEST + "/meta-data";

		public static string EC2UserDataRoot => ServiceEndpoint + LATEST + "/user-data";

		public static string EC2DynamicDataRoot => ServiceEndpoint + LATEST + "/dynamic";

		public static string EC2ApiTokenUrl => ServiceEndpoint + LATEST + "/api/token";

		public static bool IsIMDSEnabled
		{
			get
			{
				string value = string.Empty;
				try
				{
					value = Environment.GetEnvironmentVariable(AWS_EC2_METADATA_DISABLED);
				}
				catch
				{
				}
				return !"true".Equals(value, StringComparison.OrdinalIgnoreCase);
			}
		}

		public static IWebProxy Proxy { get; set; }

		public static string AmiId => FetchData("/ami-id");

		public static string AmiLaunchIndex => FetchData("/ami-launch-index");

		public static string AmiManifestPath => FetchData("/ami-manifest-path");

		public static IEnumerable<string> AncestorAmiIds => GetItems("/ancestor-ami-ids");

		public static string Hostname => FetchData("/hostname");

		public static string InstanceAction => FetchData("/instance-action");

		public static string InstanceId => FetchData("/instance-id");

		public static string InstanceType => FetchData("/instance-type");

		public static string KernelId => GetData("kernel-id");

		public static string LocalHostname => FetchData("/local-hostname");

		public static string MacAddress => FetchData("/mac");

		public static string PrivateIpAddress => FetchData("/local-ipv4");

		public static string AvailabilityZone => FetchData("/placement/availability-zone");

		public static IEnumerable<string> ProductCodes => GetItems("/product-codes");

		public static string PublicKey => FetchData("/public-keys/0/openssh-key");

		public static string RamdiskId => FetchData("/ramdisk-id");

		public static RegionEndpoint Region
		{
			get
			{
				string identityDocument = IdentityDocument;
				if (!string.IsNullOrEmpty(identityDocument))
				{
					try
					{
						using JsonDocument jsonDocument = JsonDocument.Parse(identityDocument.ToString());
						if (jsonDocument.RootElement.TryGetProperty("region", out var value))
						{
							return RegionEndpoint.GetBySystemName(value.GetString());
						}
					}
					catch (Exception exception)
					{
						Logger.GetLogger(typeof(EC2InstanceMetadata)).Error(exception, "Error attempting to read region from instance metadata identity document");
					}
				}
				return null;
			}
		}

		public static string ReservationId => FetchData("/reservation-id");

		public static IEnumerable<string> SecurityGroups => GetItems("/security-groups");

		public static IAMInstanceProfileMetadata IAMInstanceProfileInfo
		{
			get
			{
				string data = GetData("/iam/info");
				if (data == null)
				{
					return null;
				}
				try
				{
					return JsonSerializerHelper.Deserialize<IAMInstanceProfileMetadata>(data, JsonSerializerContext.Default);
				}
				catch
				{
					return new IAMInstanceProfileMetadata
					{
						Code = "Failed",
						Message = "Could not parse response from metadata service."
					};
				}
			}
		}

		public static IDictionary<string, IAMSecurityCredentialMetadata> IAMSecurityCredentials => GetIAMSecurityCredentials();

		public static IDictionary<string, string> BlockDeviceMapping
		{
			get
			{
				IEnumerable<string> items = GetItems("/block-device-mapping");
				if (items == null)
				{
					return null;
				}
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				foreach (string item in items)
				{
					dictionary[item] = GetData("/block-device-mapping/" + item);
				}
				return dictionary;
			}
		}

		public static IEnumerable<NetworkInterfaceMetadata> NetworkInterfaces
		{
			get
			{
				IEnumerable<string> items = GetItems("/network/interfaces/macs/");
				if (items == null)
				{
					return null;
				}
				List<NetworkInterfaceMetadata> list = new List<NetworkInterfaceMetadata>();
				foreach (string item in items)
				{
					list.Add(new NetworkInterfaceMetadata(item.Trim(new char[1] { '/' })));
				}
				return list;
			}
		}

		public static string UserData => GetData(EC2UserDataRoot);

		public static string InstanceMonitoring => GetData(EC2DynamicDataRoot + "/fws/instance-monitoring");

		public static string IdentityDocument => GetData(EC2DynamicDataRoot + "/instance-identity/document");

		public static string IdentitySignature => GetData(EC2DynamicDataRoot + "/instance-identity/signature");

		public static string IdentityPkcs7 => GetData(EC2DynamicDataRoot + "/instance-identity/pkcs7");

		public static IDictionary<string, IAMSecurityCredentialMetadata> GetIAMSecurityCredentials()
		{
			IEnumerable<string> items = GetItems("/iam/security-credentials");
			if (items == null)
			{
				return null;
			}
			Dictionary<string, IAMSecurityCredentialMetadata> dictionary = new Dictionary<string, IAMSecurityCredentialMetadata>();
			foreach (string item in items)
			{
				string data = GetData("/iam/security-credentials/" + item);
				dictionary[item] = DeserializeCredentials(data);
			}
			return dictionary;
		}

		public static async Task<IDictionary<string, IAMSecurityCredentialMetadata>> GetIAMSecurityCredentialsAsync()
		{
			IEnumerable<string> enumerable = await GetItemsAsync("/iam/security-credentials").ConfigureAwait(continueOnCapturedContext: false);
			if (enumerable == null)
			{
				return null;
			}
			Dictionary<string, IAMSecurityCredentialMetadata> creds = new Dictionary<string, IAMSecurityCredentialMetadata>();
			foreach (string item in enumerable)
			{
				creds[item] = DeserializeCredentials(await GetDataAsync("/iam/security-credentials/" + item).ConfigureAwait(continueOnCapturedContext: false));
			}
			return creds;
		}

		private static IAMSecurityCredentialMetadata DeserializeCredentials(string json)
		{
			try
			{
				return JsonSerializerHelper.Deserialize<IAMSecurityCredentialMetadata>(json, JsonSerializerContext.Default);
			}
			catch
			{
				return new IAMSecurityCredentialMetadata
				{
					Code = "Failed",
					Message = "Could not parse response from metadata service."
				};
			}
		}

		public static IEnumerable<string> GetItems(string path)
		{
			return GetItems(path, DEFAULT_RETRIES, slurp: false);
		}

		public static async Task<IEnumerable<string>> GetItemsAsync(string path)
		{
			return await GetItemsAsync(path, DEFAULT_RETRIES, slurp: false).ConfigureAwait(continueOnCapturedContext: false);
		}

		public static string GetData(string path)
		{
			return GetData(path, DEFAULT_RETRIES);
		}

		public static async Task<string> GetDataAsync(string path)
		{
			return await GetDataAsync(path, DEFAULT_RETRIES).ConfigureAwait(continueOnCapturedContext: false);
		}

		public static string GetData(string path, int tries)
		{
			List<string> items = GetItems(path, tries, slurp: true);
			if (items != null && items.Count > 0)
			{
				return items[0];
			}
			return null;
		}

		public static async Task<string> GetDataAsync(string path, int tries)
		{
			List<string> list = await GetItemsAsync(path, tries, slurp: true).ConfigureAwait(continueOnCapturedContext: false);
			if (list != null && list.Count > 0)
			{
				return list[0];
			}
			return null;
		}

		public static IEnumerable<string> GetItems(string path, int tries)
		{
			return GetItems(path, tries, slurp: false);
		}

		private static string FetchData(string path)
		{
			return FetchData(path, force: false);
		}

		private static string FetchData(string path, bool force)
		{
			try
			{
				if (!force)
				{
					if (metadataLock.TryEnterReadLock(metadataLockTimeout))
					{
						try
						{
							if (_cache.ContainsKey(path))
							{
								return _cache[path];
							}
						}
						finally
						{
							metadataLock.ExitReadLock();
						}
					}
					else
					{
						Logger.GetLogger(typeof(EC2InstanceMetadata)).InfoFormat("Unable to acquire read lock to access cache.");
					}
				}
				if (metadataLock.TryEnterWriteLock(metadataLockTimeout))
				{
					try
					{
						if (force || !_cache.ContainsKey(path))
						{
							_cache[path] = GetData(path);
						}
					}
					finally
					{
						metadataLock.ExitWriteLock();
					}
				}
				else
				{
					Logger.GetLogger(typeof(EC2InstanceMetadata)).InfoFormat("Unable to acquire write lock to modify cache.");
				}
				if (metadataLock.TryEnterReadLock(metadataLockTimeout))
				{
					try
					{
						if (_cache.ContainsKey(path))
						{
							return _cache[path];
						}
						return null;
					}
					finally
					{
						metadataLock.ExitReadLock();
					}
				}
				Logger.GetLogger(typeof(EC2InstanceMetadata)).InfoFormat("Unable to acquire read lock to access cache.");
				return null;
			}
			catch
			{
				return null;
			}
		}

		public static string FetchApiToken()
		{
			return FetchApiToken(DEFAULT_RETRIES);
		}

		public static async Task<string> FetchApiTokenAsync()
		{
			return await FetchApiTokenAsync(DEFAULT_RETRIES).ConfigureAwait(continueOnCapturedContext: false);
		}

		private static string FetchApiToken(int tries)
		{
			for (int i = 1; i <= tries; i++)
			{
				if (!IsIMDSEnabled)
				{
					return null;
				}
				try
				{
					return AWSSDKUtils.ExecuteHttpRequest(new Uri(EC2ApiTokenUrl), headers: new Dictionary<string, string>
					{
						{ "User-Agent", _userAgent },
						{
							"x-aws-ec2-metadata-token-ttl-seconds",
							DEFAULT_APITOKEN_TTL.ToString(CultureInfo.InvariantCulture)
						}
					}, requestType: "PUT", content: null, timeout: TimeSpan.FromSeconds(5.0), proxy: Proxy).Trim();
				}
				catch (Exception ex)
				{
					HttpStatusCode? httpStatusCode = ExceptionUtils.DetermineHttpStatusCode(ex);
					if (httpStatusCode == HttpStatusCode.NotFound || httpStatusCode == HttpStatusCode.MethodNotAllowed || httpStatusCode == HttpStatusCode.Forbidden)
					{
						throw new InvalidOperationException("IMDS rejected request to get API token.");
					}
					if (i >= tries)
					{
						if (httpStatusCode == HttpStatusCode.BadRequest)
						{
							Logger.GetLogger(typeof(EC2InstanceMetadata)).Error(ex, "Unable to retrieve token for use in IMDSv2.");
							throw;
						}
						Logger.GetLogger(typeof(EC2InstanceMetadata)).Error(ex, "Unable to retrieve token for use in IMDSv2.");
						throw new InvalidOperationException("Unable to retrieve token for use in IMDSv2.");
					}
					PauseExponentially(i - 1);
				}
			}
			throw new InvalidOperationException("Unable to retrieve token for use in IMDSv2.");
		}

		private static async Task<string> FetchApiTokenAsync(int tries)
		{
			for (int retry = 1; retry <= tries; retry++)
			{
				if (!IsIMDSEnabled)
				{
					return null;
				}
				try
				{
					return (await AWSSDKUtils.ExecuteHttpRequestAsync(new Uri(EC2ApiTokenUrl), headers: new Dictionary<string, string>
					{
						{ "User-Agent", _userAgent },
						{
							"x-aws-ec2-metadata-token-ttl-seconds",
							DEFAULT_APITOKEN_TTL.ToString(CultureInfo.InvariantCulture)
						}
					}, requestType: "PUT", content: null, timeout: TimeSpan.FromSeconds(5.0), proxy: Proxy).ConfigureAwait(continueOnCapturedContext: false)).Trim();
				}
				catch (Exception ex)
				{
					HttpStatusCode? httpStatusCode = ExceptionUtils.DetermineHttpStatusCode(ex);
					if (httpStatusCode == HttpStatusCode.NotFound || httpStatusCode == HttpStatusCode.MethodNotAllowed || httpStatusCode == HttpStatusCode.Forbidden)
					{
						throw new InvalidOperationException("IMDS rejected request to get API token.");
					}
					if (retry >= tries)
					{
						if (httpStatusCode == HttpStatusCode.BadRequest)
						{
							Logger.GetLogger(typeof(EC2InstanceMetadata)).Error(ex, "Unable to retrieve token for use in IMDSv2.");
							throw;
						}
						Logger.GetLogger(typeof(EC2InstanceMetadata)).Error(ex, "Unable to retrieve token for use in IMDSv2.");
						throw new InvalidOperationException("Unable to retrieve token for use in IMDSv2.");
					}
					PauseExponentially(retry - 1);
				}
			}
			throw new InvalidOperationException("Unable to retrieve token for use in IMDSv2.");
		}

		private static List<string> GetItems(string relativeOrAbsolutePath, int tries, bool slurp)
		{
			return GetItems(relativeOrAbsolutePath, tries, slurp, null);
		}

		private static async Task<List<string>> GetItemsAsync(string relativeOrAbsolutePath, int tries, bool slurp)
		{
			return await GetItemsAsync(relativeOrAbsolutePath, tries, slurp, null).ConfigureAwait(continueOnCapturedContext: false);
		}

		private static List<string> GetItems(string relativeOrAbsolutePath, int tries, bool slurp, string token)
		{
			Logger.GetLogger(typeof(EC2InstanceMetadata)).DebugFormat("Attempting to get metadata for {0}", relativeOrAbsolutePath);
			List<string> list = new List<string>();
			if (token == null)
			{
				try
				{
					token = FetchApiToken(DEFAULT_RETRIES);
				}
				catch (InvalidOperationException ex)
				{
					Logger.GetLogger(typeof(EC2InstanceMetadata)).InfoFormat("Failed to retrieve IMDS data \"{0}\" because IMDS API token could not be retrieved: {1}", relativeOrAbsolutePath, ex.Message);
					return null;
				}
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("User-Agent", _userAgent);
			dictionary.Add("x-aws-ec2-metadata-token", token);
			try
			{
				if (!IsIMDSEnabled)
				{
					throw new IMDSDisabledException();
				}
				using StringReader stringReader = new StringReader(AWSSDKUtils.ExecuteHttpRequest(relativeOrAbsolutePath.StartsWith(ServiceEndpoint, StringComparison.Ordinal) ? new Uri(relativeOrAbsolutePath) : new Uri(EC2MetadataRoot + relativeOrAbsolutePath), "GET", null, TimeSpan.FromSeconds(5.0), Proxy, dictionary));
				if (slurp)
				{
					list.Add(stringReader.ReadToEnd());
				}
				else
				{
					string text;
					do
					{
						text = stringReader.ReadLine();
						if (text != null)
						{
							list.Add(text.Trim());
						}
					}
					while (text != null);
				}
			}
			catch (IMDSDisabledException)
			{
				Logger.GetLogger(typeof(EC2InstanceMetadata)).DebugFormat("IMDS is disabled");
				return null;
			}
			catch (Exception ex3)
			{
				HttpStatusCode? httpStatusCode = ExceptionUtils.DetermineHttpStatusCode(ex3);
				if (httpStatusCode == HttpStatusCode.NotFound)
				{
					Logger.GetLogger(typeof(EC2InstanceMetadata)).DebugFormat("EC2 Metadata service not found.");
					return null;
				}
				if (httpStatusCode == HttpStatusCode.Unauthorized)
				{
					Logger.GetLogger(typeof(EC2InstanceMetadata)).Error(ex3, "EC2 Metadata service returned unauthorized for token based secure data flow.");
					throw;
				}
				if (tries <= 1)
				{
					Logger.GetLogger(typeof(EC2InstanceMetadata)).Error(ex3, "Unable to contact EC2 Metadata service.");
					return null;
				}
				PauseExponentially(DEFAULT_RETRIES - tries);
				return GetItems(relativeOrAbsolutePath, tries - 1, slurp, token);
			}
			return list;
		}

		private static async Task<List<string>> GetItemsAsync(string relativeOrAbsolutePath, int tries, bool slurp, string token)
		{
			List<string> items = new List<string>();
			if (token == null)
			{
				try
				{
					token = await FetchApiTokenAsync(DEFAULT_RETRIES).ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (InvalidOperationException ex)
				{
					Logger.GetLogger(typeof(EC2InstanceMetadata)).InfoFormat("Failed to retrieve IMDS data \"{0}\" because IMDS API token could not be retrieved: {1}", relativeOrAbsolutePath, ex.Message);
					return null;
				}
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("User-Agent", _userAgent);
			dictionary.Add("x-aws-ec2-metadata-token", token);
			try
			{
				if (!IsIMDSEnabled)
				{
					throw new IMDSDisabledException();
				}
				using StringReader stringReader = new StringReader(await AWSSDKUtils.ExecuteHttpRequestAsync(relativeOrAbsolutePath.StartsWith(ServiceEndpoint, StringComparison.Ordinal) ? new Uri(relativeOrAbsolutePath) : new Uri(EC2MetadataRoot + relativeOrAbsolutePath), "GET", null, TimeSpan.FromSeconds(5.0), Proxy, dictionary).ConfigureAwait(continueOnCapturedContext: false));
				if (slurp)
				{
					items.Add(stringReader.ReadToEnd());
				}
				else
				{
					string text;
					do
					{
						text = stringReader.ReadLine();
						if (text != null)
						{
							items.Add(text.Trim());
						}
					}
					while (text != null);
				}
			}
			catch (IMDSDisabledException)
			{
				return null;
			}
			catch (Exception ex3)
			{
				HttpStatusCode? httpStatusCode = ExceptionUtils.DetermineHttpStatusCode(ex3);
				if (httpStatusCode == HttpStatusCode.NotFound)
				{
					return null;
				}
				if (httpStatusCode == HttpStatusCode.Unauthorized)
				{
					Logger.GetLogger(typeof(EC2InstanceMetadata)).Error(ex3, "EC2 Metadata service returned unauthorized for token based secure data flow.");
					throw;
				}
				if (tries <= 1)
				{
					Logger.GetLogger(typeof(EC2InstanceMetadata)).Error(ex3, "Unable to contact EC2 Metadata service.");
					return null;
				}
				PauseExponentially(DEFAULT_RETRIES - tries);
				return await GetItemsAsync(relativeOrAbsolutePath, tries - 1, slurp, token).ConfigureAwait(continueOnCapturedContext: false);
			}
			return items;
		}

		private static void PauseExponentially(int retry)
		{
			int num = (int)(Math.Pow(2.0, retry) * (double)MIN_PAUSE_MS);
			Thread.Sleep((num < MIN_PAUSE_MS) ? MIN_PAUSE_MS : num);
		}
	}
}
