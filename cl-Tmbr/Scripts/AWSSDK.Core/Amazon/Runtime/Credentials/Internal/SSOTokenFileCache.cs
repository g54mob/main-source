using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;
using Amazon.Util.Internal;

namespace Amazon.Runtime.Credentials.Internal
{
	public class SSOTokenFileCache : ISSOTokenFileCache
	{
		private readonly Logger _logger = Logger.GetLogger(typeof(SSOTokenFileCache));

		private readonly ICryptoUtil _cryptoUtil;

		private readonly IFile _file;

		private readonly IDirectory _directory;

		private readonly string _defaultSSOCacheDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".aws", "sso", "cache");

		public SSOTokenFileCache(ICryptoUtil cryptoUtil, IFile file, IDirectory directory)
		{
			_cryptoUtil = cryptoUtil;
			_file = file;
			_directory = directory;
		}

		public bool Exists(CredentialProfileOptions options)
		{
			SSOTokenManagerGetTokenOptions getSsoTokenOptions = new SSOTokenManagerGetTokenOptions
			{
				StartUrl = options.SsoStartUrl,
				Session = options.SsoSession
			};
			SsoToken ssoToken;
			return TryGetSsoToken(getSsoTokenOptions, null, out ssoToken);
		}

		public bool TryGetSsoToken(SSOTokenManagerGetTokenOptions getSsoTokenOptions, string ssoCacheDirectory, out SsoToken ssoToken)
		{
			ssoToken = null;
			string text = BuildCacheFileFullPath(getSsoTokenOptions, ssoCacheDirectory);
			try
			{
				if (string.IsNullOrWhiteSpace(text) || !_file.Exists(text))
				{
					_logger.DebugFormat("No SSO Token cache to load from");
					return false;
				}
				string json = _file.ReadAllText(text);
				ssoToken = SsoTokenUtils.FromJson(json);
				_logger.DebugFormat("SSO Token loaded from cache");
				return true;
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "Unable to load token cache for start url: {0}", getSsoTokenOptions?.StartUrl);
				return false;
			}
		}

		public async Task<TryResponse<SsoToken>> TryGetSsoTokenAsync(SSOTokenManagerGetTokenOptions getSsoTokenOptions, string ssoCacheDirectory, CancellationToken cancellationToken = default(CancellationToken))
		{
			string text = BuildCacheFileFullPath(getSsoTokenOptions, ssoCacheDirectory);
			TryResponse<SsoToken> result = new TryResponse<SsoToken>
			{
				Success = false
			};
			try
			{
				if (string.IsNullOrWhiteSpace(text) || !_file.Exists(text))
				{
					_logger.DebugFormat("No SSO Token cache to load from");
					return result;
				}
				result.Value = SsoTokenUtils.FromJson(await _file.ReadAllTextAsync(text, cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
				result.Success = true;
				_logger.DebugFormat("SSO Token loaded from cache");
				return result;
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "Unable to load token cache for start url: {0}", getSsoTokenOptions?.StartUrl);
				return result;
			}
		}

		public async Task<List<SSOTokenFile>> ScanSsoTokensAsync(string ssoCacheDirectory, CancellationToken cancellationToken = default(CancellationToken))
		{
			List<SSOTokenFile> result = new List<SSOTokenFile>();
			if (string.IsNullOrWhiteSpace(ssoCacheDirectory))
			{
				ssoCacheDirectory = _defaultSSOCacheDirectory;
			}
			string[] files = _directory.GetFiles(ssoCacheDirectory, "*.json");
			string[] array = files;
			foreach (string cacheFilePath in array)
			{
				SsoToken ssoToken = SsoTokenUtils.FromJson(await _file.ReadAllTextAsync(cacheFilePath, cancellationToken).ConfigureAwait(continueOnCapturedContext: false), throwIfTokenInvalid: false);
				if (ssoToken != null)
				{
					result.Add(new SSOTokenFile
					{
						SsoToken = ssoToken,
						SsoTokenFilePath = cacheFilePath
					});
				}
			}
			_logger.DebugFormat("Number of cached sso tokens {0}", result.Count);
			return result;
		}

		public void SaveSsoToken(SsoToken token, string ssoCacheDirectory)
		{
			if (token == null)
			{
				return;
			}
			string text = BuildCacheFileFullPath(token, ssoCacheDirectory);
			try
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					string contents = SsoTokenUtils.ToJson(token);
					_directory.CreateDirectory(Path.GetDirectoryName(text));
					_file.WriteAllText(text, contents);
				}
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "Warning: Unable to save SSO Token Cache. Future retrieval will have to produce a token.");
			}
		}

		public async Task SaveSsoTokenAsync(SsoToken token, string ssoCacheDirectory, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (token == null)
			{
				return;
			}
			string text = BuildCacheFileFullPath(token, ssoCacheDirectory);
			try
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					string contents = SsoTokenUtils.ToJson(token);
					_directory.CreateDirectory(Path.GetDirectoryName(text));
					await _file.WriteAllTextAsync(text, contents, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "Warning: Unable to save SSO Token Cache. Future retrieval will have to produce a token.");
			}
		}

		public void DeleteSsoToken(SSOTokenManagerGetTokenOptions getSsoTokenOptions, string ssoCacheDirectory)
		{
			if (getSsoTokenOptions != null)
			{
				string filePath = BuildCacheFileFullPath(getSsoTokenOptions, ssoCacheDirectory);
				DeleteSsoToken(filePath);
			}
		}

		public void DeleteSsoToken(string filePath)
		{
			try
			{
				_file.Delete(filePath);
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "Unable to delete sso token file {0}", filePath);
			}
		}

		private string BuildCacheFileFullPath(SsoToken token, string ssoCacheDirectory)
		{
			return BuildCacheFileFullPath(token.StartUrl, token.Session, ssoCacheDirectory);
		}

		private string BuildCacheFileFullPath(SSOTokenManagerGetTokenOptions getSsoTokenOptions, string ssoCacheDirectory)
		{
			return BuildCacheFileFullPath(getSsoTokenOptions.StartUrl, getSsoTokenOptions.Session, ssoCacheDirectory);
		}

		private string BuildCacheFileFullPath(string startUrl, string session, string ssoCacheDirectory)
		{
			if (string.IsNullOrWhiteSpace(ssoCacheDirectory))
			{
				ssoCacheDirectory = _defaultSSOCacheDirectory;
			}
			string cacheFilename = GetCacheFilename(startUrl, session);
			return Path.Combine(ssoCacheDirectory, cacheFilename);
		}

		private string GetCacheFilename(string startUrl, string session)
		{
			return ((!string.IsNullOrEmpty(session)) ? GenerateSha1Hash(session) : GenerateSha1Hash(startUrl)) + ".json";
		}

		private string GenerateSha1Hash(string text)
		{
			return AWSSDKUtils.ToHex(_cryptoUtil.ComputeSHA1Hash(Encoding.UTF8.GetBytes(text ?? "")), lowercase: true);
		}

		public List<SSOTokenFile> ScanSsoTokens(string ssoCacheDirectory)
		{
			List<SSOTokenFile> list = new List<SSOTokenFile>();
			if (string.IsNullOrWhiteSpace(ssoCacheDirectory))
			{
				ssoCacheDirectory = _defaultSSOCacheDirectory;
			}
			string[] files = _directory.GetFiles(ssoCacheDirectory, "*.json");
			foreach (string text in files)
			{
				SsoToken ssoToken = SsoTokenUtils.FromJson(_file.ReadAllText(text), throwIfTokenInvalid: false);
				if (ssoToken != null)
				{
					list.Add(new SSOTokenFile
					{
						SsoToken = ssoToken,
						SsoTokenFilePath = text
					});
				}
			}
			_logger.DebugFormat("Number of cached sso tokens {0}", list.Count);
			return list;
		}
	}
}
