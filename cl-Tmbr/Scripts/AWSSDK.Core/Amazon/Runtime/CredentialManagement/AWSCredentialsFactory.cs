using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Amazon.Runtime.CredentialManagement.Internal;
using Amazon.Runtime.Credentials.Internal;
using Amazon.Runtime.Internal.Settings;
using Amazon.Runtime.Internal.UserAgent;
using Amazon.Util;
using Amazon.Util.Internal;

namespace Amazon.Runtime.CredentialManagement
{
	public static class AWSCredentialsFactory
	{
		private static HashSet<CredentialProfileType> CallbackProfileTypes = new HashSet<CredentialProfileType>
		{
			CredentialProfileType.SAMLRoleUserIdentity,
			CredentialProfileType.AssumeRoleExternalMFA,
			CredentialProfileType.AssumeRoleMFA,
			CredentialProfileType.SSO
		};

		private const string RoleSessionNamePrefix = "aws-dotnet-sdk-session-";

		public static AWSCredentials GetAWSCredentials(CredentialProfile profile, ICredentialProfileSource profileSource)
		{
			return GetAWSCredentials(profile.Name, profileSource, profile.Options, profile.Region, nonCallbackOnly: false);
		}

		public static AWSCredentials GetAWSCredentials(CredentialProfileOptions options, ICredentialProfileSource profileSource)
		{
			return GetAWSCredentials(null, profileSource, options, null, nonCallbackOnly: false);
		}

		public static AWSCredentials GetAWSCredentials(CredentialProfile profile, ICredentialProfileSource profileSource, bool nonCallbackOnly)
		{
			return GetAWSCredentials(profile.Name, profileSource, profile.Options, profile.Region, nonCallbackOnly);
		}

		public static AWSCredentials GetAWSCredentials(CredentialProfileOptions options, ICredentialProfileSource profileSource, bool nonCallbackOnly)
		{
			return GetAWSCredentials(null, profileSource, options, null, nonCallbackOnly);
		}

		public static bool TryGetAWSCredentials(CredentialProfile profile, ICredentialProfileSource profileSource, out AWSCredentials credentials)
		{
			credentials = GetAWSCredentialsInternal(profile.Name, profile.ProfileType, profile.Options, profile.Region, profileSource, throwIfInvalid: false);
			return credentials != null;
		}

		public static bool TryGetAWSCredentials(CredentialProfileOptions options, ICredentialProfileSource profileSource, out AWSCredentials credentials)
		{
			CredentialProfileType? profileType = CredentialProfileTypeDetector.DetectProfileType(options);
			credentials = GetAWSCredentialsInternal(null, profileType, options, null, profileSource, throwIfInvalid: false);
			return credentials != null;
		}

		internal static bool IsCallbackRequired(CredentialProfileType? profileType)
		{
			if (profileType.HasValue)
			{
				return CallbackProfileTypes.Contains(profileType.Value);
			}
			return false;
		}

		private static AWSCredentials GetAWSCredentials(string profileName, ICredentialProfileSource profileSource, CredentialProfileOptions options, RegionEndpoint stsRegion, bool nonCallbackOnly)
		{
			SSOTokenFileCache sSOTokenFileCache = new SSOTokenFileCache(CryptoUtilFactory.CryptoInstance, new FileRetriever(), new DirectoryRetriever());
			CredentialProfileType? credentialProfileType = CredentialProfileTypeDetector.DetectProfileType(options);
			if (nonCallbackOnly && credentialProfileType.HasValue && IsCallbackRequired(credentialProfileType.Value))
			{
				if (credentialProfileType == CredentialProfileType.AssumeRoleExternalMFA || credentialProfileType == CredentialProfileType.AssumeRoleMFA)
				{
					throw new InvalidOperationException((profileName == null) ? "The credential options represent AssumeRoleAWSCredentials that require an MFA.  This is not allowed here.  Please use credential options for AssumeRoleAWSCredentials that don't require an MFA, or a different type of credentials." : string.Format(CultureInfo.InvariantCulture, "The profile [{0}] is an assume role profile that requires an MFA.  This type of profile is not allowed here.  Please use an assume role profile that doesn't require an MFA, or a different type of profile.", profileName));
				}
				if (credentialProfileType == CredentialProfileType.SSO && !sSOTokenFileCache.Exists(options))
				{
					throw new InvalidOperationException((profileName == null) ? "The credential options represent SSOAWSCredentials.  This is not allowed here.  Please use a different type of credentials." : string.Format(CultureInfo.InvariantCulture, "The profile [{0}] is an SSO profile.  This type of profile is not allowed here.  Please use a different type of profile.", profileName));
				}
				if (credentialProfileType == CredentialProfileType.SAMLRoleUserIdentity)
				{
					throw new InvalidOperationException((profileName == null) ? "The credential options represent FederatedAWSCredentials that specify a user identity.  This is not allowed here.  Please use credential options for FederatedAWSCredentials without an explicit user identity, or a different type of credentials." : string.Format(CultureInfo.InvariantCulture, "The profile [{0}] is a SAML role profile that specifies a user identity.  This type of profile is not allowed here.  Please use a SAML role profile without an explicit user identity, or a different type of profile.", profileName));
				}
			}
			return GetAWSCredentialsInternal(profileName, credentialProfileType, options, stsRegion, profileSource, throwIfInvalid: true);
		}

		private static AWSCredentials GetAWSCredentialsInternal(string profileName, CredentialProfileType? profileType, CredentialProfileOptions options, RegionEndpoint stsRegion, ICredentialProfileSource profileSource, bool throwIfInvalid, HashSet<string> profileLoopAvoidance = null)
		{
			if (profileType.HasValue)
			{
				AWSCredentials aWSCredentials = null;
				switch (profileType)
				{
				case CredentialProfileType.Basic:
					aWSCredentials = new BasicAWSCredentials(options.AccessKey, options.SecretKey, options.AwsAccountId);
					aWSCredentials.FeatureIdSources.Remove(UserAgentFeatureId.CREDENTIALS_CODE);
					aWSCredentials.FeatureIdSources.Add(UserAgentFeatureId.CREDENTIALS_PROFILE);
					break;
				case CredentialProfileType.Session:
					aWSCredentials = new SessionAWSCredentials(options.AccessKey, options.SecretKey, options.Token, options.AwsAccountId);
					break;
				case CredentialProfileType.AssumeRole:
				case CredentialProfileType.AssumeRoleExternal:
				case CredentialProfileType.AssumeRoleExternalMFA:
				case CredentialProfileType.AssumeRoleMFA:
				case CredentialProfileType.AssumeRoleSessionName:
				case CredentialProfileType.AssumeRoleExternalSessionName:
				case CredentialProfileType.AssumeRoleExternalMFASessionName:
				case CredentialProfileType.AssumeRoleMFASessionName:
				{
					if (profileName != null)
					{
						if (profileLoopAvoidance == null)
						{
							profileLoopAvoidance = new HashSet<string>();
						}
						else if (profileLoopAvoidance.Contains(profileName))
						{
							return ThrowOrReturnNull(string.Format(CultureInfo.InvariantCulture, "Error reading profile [{0}]: the source profile definition is cyclical.", profileName), null, throwIfInvalid);
						}
						profileLoopAvoidance.Add(profileName);
					}
					AWSCredentials sourceAWSCredentials;
					try
					{
						sourceAWSCredentials = GetSourceAWSCredentials(options.SourceProfile, profileSource, throwIfInvalid, profileLoopAvoidance);
					}
					catch (InvalidDataException innerException)
					{
						return ThrowOrReturnNull((profileName == null) ? string.Format(CultureInfo.InvariantCulture, "Error reading source profile [{0}] for the credential options provided.", options.SourceProfile) : string.Format(CultureInfo.InvariantCulture, "Error reading source profile [{0}] for profile [{1}].", options.SourceProfile, profileName), innerException, throwIfInvalid);
					}
					string roleSessionName = options.RoleSessionName ?? ("aws-dotnet-sdk-session-" + AWSSDKUtils.CorrectedUtcNow.Ticks);
					AssumeRoleAWSCredentialsOptions options2 = new AssumeRoleAWSCredentialsOptions
					{
						ExternalId = options.ExternalID,
						MfaSerialNumber = options.MfaSerial
					};
					aWSCredentials = new AssumeRoleAWSCredentials(sourceAWSCredentials, options.RoleArn, roleSessionName, options2);
					aWSCredentials.FeatureIdSources.Add(UserAgentFeatureId.CREDENTIALS_PROFILE_SOURCE_PROFILE);
					break;
				}
				case CredentialProfileType.AssumeRoleCredentialSource:
				case CredentialProfileType.AssumeRoleCredentialSourceSessionName:
				{
					AWSCredentials sourceAWSCredentials;
					try
					{
						sourceAWSCredentials = GetCredentialSourceAWSCredentials(options.CredentialSource, throwIfInvalid);
					}
					catch (InvalidDataException innerException2)
					{
						return ThrowOrReturnNull((profileName == null) ? string.Format(CultureInfo.InvariantCulture, "Error reading credential source [{0}] for the credential options provided.", options.CredentialSource) : string.Format(CultureInfo.InvariantCulture, "Error reading credential source [{0}] for profile [{1}].", options.CredentialSource, profileName), innerException2, throwIfInvalid);
					}
					string roleSessionName = options.RoleSessionName ?? ("aws-dotnet-sdk-session-" + AWSSDKUtils.CorrectedUtcNow.Ticks);
					AssumeRoleAWSCredentialsOptions options2 = new AssumeRoleAWSCredentialsOptions();
					aWSCredentials = new AssumeRoleAWSCredentials(sourceAWSCredentials, options.RoleArn, roleSessionName, options2);
					aWSCredentials.FeatureIdSources.Add(UserAgentFeatureId.CREDENTIALS_PROFILE_NAMED_PROVIDER);
					break;
				}
				case CredentialProfileType.AssumeRoleWithWebIdentity:
				case CredentialProfileType.AssumeRoleWithWebIdentitySessionName:
					aWSCredentials = new AssumeRoleWithWebIdentityCredentials(options.WebIdentityTokenFile, options.RoleArn, options.RoleSessionName);
					aWSCredentials.FeatureIdSources.Add(UserAgentFeatureId.CREDENTIALS_PROFILE_STS_WEB_ID_TOKEN);
					break;
				case CredentialProfileType.SSO:
				{
					SSOAWSCredentialsOptions sSOAWSCredentialsOptions = new SSOAWSCredentialsOptions();
					sSOAWSCredentialsOptions.SessionName = options.SsoSession;
					sSOAWSCredentialsOptions.Scopes = (from p in options.SsoRegistrationScopes?.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries)
						select p.Trim()).ToList();
					SSOAWSCredentialsOptions options4 = sSOAWSCredentialsOptions;
					bool flag = string.IsNullOrEmpty(options.SsoSession);
					aWSCredentials = new SSOAWSCredentials(options.SsoAccountId, options.SsoRegion, options.SsoRoleName, options.SsoStartUrl, options4);
					aWSCredentials.FeatureIdSources.Add(flag ? UserAgentFeatureId.CREDENTIALS_PROFILE_SSO_LEGACY : UserAgentFeatureId.CREDENTIALS_PROFILE_SSO);
					break;
				}
				case CredentialProfileType.SAMLRole:
				case CredentialProfileType.SAMLRoleUserIdentity:
					if (UserCrypto.IsUserCryptAvailable)
					{
						FederatedAWSCredentialsOptions options3 = new FederatedAWSCredentialsOptions
						{
							STSRegion = stsRegion,
							UserIdentity = options.UserIdentity,
							ProfileName = profileName
						};
						aWSCredentials = new FederatedAWSCredentials(new SAMLEndpointManager().GetEndpoint(options.EndpointName), options.RoleArn, options3);
						break;
					}
					return ThrowOrReturnNull("Federated credentials are not available on this platform.", null, throwIfInvalid);
				case CredentialProfileType.CredentialProcess:
					aWSCredentials = new ProcessAWSCredentials(options.CredentialProcess, options.AwsAccountId);
					aWSCredentials.FeatureIdSources.Add(UserAgentFeatureId.CREDENTIALS_PROFILE_PROCESS);
					break;
				default:
					return ThrowOrReturnNull((profileName == null) ? string.Format(CultureInfo.InvariantCulture, "Invalid ProfileType {0} for the credential options provided.", profileType) : string.Format(CultureInfo.InvariantCulture, "Invalid ProfileType {0} for credential profile [{1}].", profileType, profileName), null, throwIfInvalid);
				}
				if (profileSource is NetSDKCredentialsFile)
				{
					aWSCredentials.FeatureIdSources.Add(UserAgentFeatureId.CREDENTIALS_AWS_SDK_STORE);
				}
				return aWSCredentials;
			}
			return ThrowInvalidOrReturnNull(profileName, throwIfInvalid);
		}

		private static AWSCredentials GetCredentialSourceAWSCredentials(string credentialSourceType, bool throwIfInvalid)
		{
			CredentialSourceType credentialSourceType2;
			try
			{
				credentialSourceType2 = (CredentialSourceType)Enum.Parse(typeof(CredentialSourceType), credentialSourceType, ignoreCase: true);
			}
			catch
			{
				return ThrowOrReturnNull(string.Format(CultureInfo.InvariantCulture, "Credential source [{0}] is invalid.", credentialSourceType), null, throwIfInvalid);
			}
			switch (credentialSourceType2)
			{
			case CredentialSourceType.Ec2InstanceMetadata:
				return DefaultInstanceProfileAWSCredentials.Instance;
			case CredentialSourceType.Environment:
				return new EnvironmentVariablesAWSCredentials();
			case CredentialSourceType.EcsContainer:
			{
				string environmentVariable = Environment.GetEnvironmentVariable("AWS_CONTAINER_CREDENTIALS_RELATIVE_URI");
				string environmentVariable2 = Environment.GetEnvironmentVariable("AWS_CONTAINER_CREDENTIALS_FULL_URI");
				if (string.IsNullOrEmpty(environmentVariable) && string.IsNullOrEmpty(environmentVariable2))
				{
					return ThrowOrReturnNull("Cannot fetch credentials from container - neither AWS_CONTAINER_CREDENTIALS_RELATIVE_URI or AWS_CONTAINER_CREDENTIALS_FULL_URI environment variables are set.", null, throwIfInvalid);
				}
				return new GenericContainerCredentials();
			}
			default:
				return ThrowOrReturnNull(string.Format(CultureInfo.InvariantCulture, "Credential source [{0}] is not implemented.", credentialSourceType), null, throwIfInvalid);
			}
		}

		private static AWSCredentials GetSourceAWSCredentials(string sourceProfileName, ICredentialProfileSource profileSource, bool throwIfInvalid, HashSet<string> profileLoopAvoidance = null)
		{
			CredentialProfile profile = null;
			if (profileSource.TryGetProfile(sourceProfileName, out profile))
			{
				if (profile.CanCreateAWSCredentials)
				{
					AWSCredentials aWSCredentialsInternal = GetAWSCredentialsInternal(profile.Name, profile.ProfileType, profile.Options, profile.Region, profileSource, throwIfInvalid, profileLoopAvoidance);
					if (aWSCredentialsInternal == null)
					{
						return ThrowOrReturnNull(string.Format(CultureInfo.InvariantCulture, "Could not get credentials from source profile [{0}].", sourceProfileName), null, throwIfInvalid);
					}
					return aWSCredentialsInternal;
				}
				return ThrowInvalidOrReturnNull(sourceProfileName, throwIfInvalid);
			}
			return ThrowOrReturnNull(string.Format(CultureInfo.InvariantCulture, "Source profile [{0}] was not found.", sourceProfileName), null, throwIfInvalid);
		}

		private static BasicAWSCredentials ThrowInvalidOrReturnNull(string profileName, bool doThrow)
		{
			return ThrowOrReturnNull((profileName == null) ? "The credential options provided are not valid.  Please ensure the options contain a valid combination of properties." : string.Format(CultureInfo.InvariantCulture, "Credential profile [{0}] is not valid.  Please ensure the profile contains a valid combination of properties.", profileName), null, doThrow);
		}

		private static BasicAWSCredentials ThrowOrReturnNull(string message, Exception innerException, bool doThrow)
		{
			if (doThrow)
			{
				throw new InvalidDataException(message, innerException);
			}
			return null;
		}
	}
}
