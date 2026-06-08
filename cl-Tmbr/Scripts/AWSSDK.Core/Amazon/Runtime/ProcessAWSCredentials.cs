using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.UserAgent;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;
using Amazon.Util.Internal;

namespace Amazon.Runtime
{
	public class ProcessAWSCredentials : RefreshingAWSCredentials
	{
		private const string _versionString = "Version";

		private string _accountId;

		private Logger _logger = Logger.GetLogger(typeof(ProcessAWSCredentials));

		private readonly ProcessStartInfo _processStartInfo;

		private static JsonDocumentOptions _options = new JsonDocumentOptions
		{
			AllowTrailingCommas = true
		};

		public ProcessAWSCredentials(string processCredentialInfo)
			: this(processCredentialInfo, null)
		{
		}

		public ProcessAWSCredentials(string processCredentialInfo, string accountId)
		{
			processCredentialInfo = processCredentialInfo.Trim();
			string fileName = "cmd.exe";
			string arguments = "/c " + processCredentialInfo;
			_accountId = accountId;
			if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				fileName = "sh";
				string text = processCredentialInfo.Replace("\\", "\\\\").Replace("\"", "\\\"");
				arguments = "-c \"" + text + "\"";
			}
			_processStartInfo = new ProcessStartInfo
			{
				FileName = fileName,
				Arguments = arguments,
				UseShellExecute = false,
				RedirectStandardError = true,
				RedirectStandardOutput = true,
				CreateNoWindow = true
			};
			base.PreemptExpiryTime = TimeSpan.FromMinutes(15.0);
			base.FeatureIdSources.Add(UserAgentFeatureId.CREDENTIALS_PROCESS);
		}

		protected override CredentialsRefreshState GenerateNewCredentials()
		{
			return DetermineProcessCredential();
		}

		protected override Task<CredentialsRefreshState> GenerateNewCredentialsAsync()
		{
			return DetermineProcessCredentialAsync();
		}

		public CredentialsRefreshState DetermineProcessCredential()
		{
			try
			{
				ProcessExecutionResult credentialsRefreshState = AWSSDKUtils.RunProcess(_processStartInfo);
				return SetCredentialsRefreshState(credentialsRefreshState);
			}
			catch (ProcessAWSCredentialException)
			{
				throw;
			}
			catch (Exception ex2)
			{
				_logger.DebugFormat("Process recorded exception - {0}", ex2);
				throw new ProcessAWSCredentialException(string.Format(CultureInfo.CurrentCulture, "AWS credential process terminated with {0}", ex2.GetType()), ex2);
			}
		}

		public async Task<CredentialsRefreshState> DetermineProcessCredentialAsync()
		{
			try
			{
				return SetCredentialsRefreshState(await AWSSDKUtils.RunProcessAsync(_processStartInfo).ConfigureAwait(continueOnCapturedContext: false));
			}
			catch (ProcessAWSCredentialException)
			{
				throw;
			}
			catch (Exception ex2)
			{
				_logger.DebugFormat("Process recorded exception - {0}", ex2);
				throw new ProcessAWSCredentialException(string.Format(CultureInfo.CurrentCulture, "AWS credential process terminated with {0}", ex2.GetType()), ex2);
			}
		}

		private CredentialsRefreshState SetCredentialsRefreshState(ProcessExecutionResult processInfo)
		{
			_logger.InfoFormat("Process ends with exitcode - {0}", processInfo.ExitCode);
			if (processInfo.ExitCode == 0)
			{
				try
				{
					using JsonDocument jsonDocument = JsonDocument.Parse(processInfo.StandardOutput, _options);
					JsonElement rootElement = jsonDocument.RootElement;
					if ((from x in rootElement.EnumerateObject()
						select x.NameEquals("Version")) == null || !rootElement.TryGetProperty("Version", out var _))
					{
						throw new ProcessAWSCredentialException("Missing required parameter - Version in JSON Payload");
					}
					int @int = rootElement.GetProperty("Version").GetInt32();
					if (@int != 1)
					{
						throw new ProcessAWSCredentialException(string.Format(CultureInfo.CurrentCulture, "Unsupported credential version: {0}" + @int));
					}
					ProcessCredentialVersion1 processCredentialVersion = null;
					try
					{
						processCredentialVersion = JsonSerializerHelper.Deserialize<ProcessCredentialVersion1>(processInfo.StandardOutput, JsonSerializerContext.Default);
						if (processCredentialVersion.Expiration == DateTime.MaxValue && processCredentialVersion.Expiration.Kind != DateTimeKind.Utc)
						{
							processCredentialVersion.Expiration = DateTime.SpecifyKind(processCredentialVersion.Expiration, DateTimeKind.Utc);
						}
						else
						{
							processCredentialVersion.Expiration = processCredentialVersion.Expiration.ToUniversalTime();
						}
					}
					catch (Exception inner)
					{
						throw new ProcessAWSCredentialException("The response back from the process credential provider returned back a malformed JSON document.", inner);
					}
					string accountId = ((processCredentialVersion.AccountId == null) ? _accountId : processCredentialVersion.AccountId);
					return new CredentialsRefreshState(new ImmutableCredentials(processCredentialVersion.AccessKeyId, processCredentialVersion.SecretAccessKey, processCredentialVersion.SessionToken, accountId), processCredentialVersion.Expiration);
				}
				catch (JsonException inner2)
				{
					throw new ProcessAWSCredentialException("The response back from the process credential provider returned back a malformed JSON document.", inner2);
				}
			}
			ProcessAWSCredentialException ex = new ProcessAWSCredentialException(string.Format(CultureInfo.CurrentCulture, "Command returned non-zero exit value {0} with the error - {1}", processInfo.ExitCode, processInfo.StandardError));
			_logger.DebugFormat("Process {0} recorded exception - {1}", _processStartInfo.FileName, ex);
			throw ex;
		}
	}
}
