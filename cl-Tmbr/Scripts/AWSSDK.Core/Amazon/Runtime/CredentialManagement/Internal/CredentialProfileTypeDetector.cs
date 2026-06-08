using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Amazon.Runtime.CredentialManagement.Internal
{
	public static class CredentialProfileTypeDetector
	{
		private const string BasicCredentials = "Basic";

		private const string SessionCredentials = "Session";

		private const string AssumeRoleCredentials = "Assume Role";

		private const string AssumeRoleWithWebIdentityCredentials = "Assume Role with OIDC Web Identity";

		private const string SAMLCredentials = "SAML";

		private const string Services = "Services";

		private const string AccessKey = "AccessKey";

		private const string CredentialSource = "CredentialSource";

		private const string EndpointName = "EndpointName";

		private const string ExternalID = "ExternalID";

		private const string MfaSerial = "MfaSerial";

		private const string RoleArn = "RoleArn";

		private const string RoleSessionName = "RoleSessionName";

		private const string SecretKey = "SecretKey";

		private const string SourceProfile = "SourceProfile";

		private const string Token = "Token";

		private const string WebIdentityTokenFile = "WebIdentityTokenFile";

		private const string UserIdentity = "UserIdentity";

		private const string CredentialProcess = "CredentialProcess";

		private const string EndpointUrl = "EndpointUrl";

		private const string AwsAccountId = "AwsAccountId";

		private const string SsoAccountId = "SsoAccountId";

		private const string SsoRegion = "SsoRegion";

		private const string SsoRegistrationScopes = "SsoRegistrationScopes";

		private const string SsoRoleName = "SsoRoleName";

		private const string SsoStartUrl = "SsoStartUrl";

		private const string SsoSession = "SsoSession";

		private static HashSet<string> SsoProperties = new HashSet<string>(new string[6] { "SsoAccountId", "SsoRegion", "SsoRegistrationScopes", "SsoRoleName", "SsoStartUrl", "SsoSession" }, StringComparer.OrdinalIgnoreCase);

		private static Dictionary<CredentialProfileType, List<HashSet<string>>> TypePropertyDictionary = new Dictionary<CredentialProfileType, List<HashSet<string>>>
		{
			{
				CredentialProfileType.CredentialProcess,
				new List<HashSet<string>>
				{
					new HashSet<string> { "CredentialProcess" },
					new HashSet<string> { "CredentialProcess", "AwsAccountId" }
				}
			},
			{
				CredentialProfileType.AssumeRole,
				new List<HashSet<string>>
				{
					new HashSet<string> { "RoleArn", "SourceProfile" },
					new HashSet<string> { "RoleArn", "SourceProfile", "AwsAccountId" },
					new HashSet<string> { "RoleArn", "SourceProfile", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" },
					new HashSet<string> { "RoleArn", "SourceProfile", "AwsAccountId", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" }
				}
			},
			{
				CredentialProfileType.AssumeRoleCredentialSource,
				new List<HashSet<string>>
				{
					new HashSet<string> { "RoleArn", "CredentialSource" },
					new HashSet<string> { "RoleArn", "CredentialSource", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" },
					new HashSet<string> { "RoleArn", "CredentialSource", "AwsAccountId" },
					new HashSet<string> { "RoleArn", "CredentialSource", "AwsAccountId", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" }
				}
			},
			{
				CredentialProfileType.AssumeRoleExternal,
				new List<HashSet<string>>
				{
					new HashSet<string> { "ExternalID", "RoleArn", "SourceProfile" },
					new HashSet<string> { "ExternalID", "RoleArn", "SourceProfile", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" },
					new HashSet<string> { "ExternalID", "RoleArn", "SourceProfile", "AwsAccountId" },
					new HashSet<string> { "ExternalID", "RoleArn", "SourceProfile", "AwsAccountId", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" }
				}
			},
			{
				CredentialProfileType.AssumeRoleExternalMFA,
				new List<HashSet<string>>
				{
					new HashSet<string> { "ExternalID", "RoleArn", "SourceProfile", "MfaSerial" },
					new HashSet<string> { "ExternalID", "RoleArn", "SourceProfile", "MfaSerial", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" }
				}
			},
			{
				CredentialProfileType.AssumeRoleWithWebIdentity,
				new List<HashSet<string>>
				{
					new HashSet<string> { "RoleArn", "WebIdentityTokenFile" },
					new HashSet<string> { "RoleArn", "WebIdentityTokenFile", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" },
					new HashSet<string> { "RoleArn", "WebIdentityTokenFile", "CredentialSource" },
					new HashSet<string> { "RoleArn", "WebIdentityTokenFile", "CredentialSource", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" },
					new HashSet<string> { "RoleArn", "WebIdentityTokenFile", "CredentialSource", "AwsAccountId" },
					new HashSet<string> { "RoleArn", "WebIdentityTokenFile", "CredentialSource", "AwsAccountId", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" }
				}
			},
			{
				CredentialProfileType.AssumeRoleWithWebIdentitySessionName,
				new List<HashSet<string>>
				{
					new HashSet<string> { "RoleArn", "WebIdentityTokenFile", "RoleSessionName" },
					new HashSet<string> { "RoleArn", "WebIdentityTokenFile", "RoleSessionName", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" },
					new HashSet<string> { "RoleArn", "WebIdentityTokenFile", "RoleSessionName", "AwsAccountId" },
					new HashSet<string> { "RoleArn", "WebIdentityTokenFile", "RoleSessionName", "AwsAccountId", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" }
				}
			},
			{
				CredentialProfileType.AssumeRoleMFA,
				new List<HashSet<string>>
				{
					new HashSet<string> { "MfaSerial", "RoleArn", "SourceProfile" },
					new HashSet<string> { "MfaSerial", "RoleArn", "SourceProfile", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" },
					new HashSet<string> { "MfaSerial", "RoleArn", "SourceProfile", "AwsAccountId" },
					new HashSet<string> { "MfaSerial", "RoleArn", "SourceProfile", "AwsAccountId", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" }
				}
			},
			{
				CredentialProfileType.Basic,
				new List<HashSet<string>>
				{
					new HashSet<string> { "AccessKey", "SecretKey" },
					new HashSet<string> { "AccessKey", "SecretKey", "AwsAccountId" }
				}
			},
			{
				CredentialProfileType.SAMLRole,
				new List<HashSet<string>>
				{
					new HashSet<string> { "EndpointName", "RoleArn" },
					new HashSet<string> { "EndpointName", "RoleArn", "AwsAccountId" }
				}
			},
			{
				CredentialProfileType.SAMLRoleUserIdentity,
				new List<HashSet<string>>
				{
					new HashSet<string> { "EndpointName", "RoleArn", "UserIdentity" }
				}
			},
			{
				CredentialProfileType.Session,
				new List<HashSet<string>>
				{
					new HashSet<string> { "AccessKey", "SecretKey", "Token" },
					new HashSet<string> { "AccessKey", "SecretKey", "Token", "AwsAccountId" }
				}
			},
			{
				CredentialProfileType.AssumeRoleSessionName,
				new List<HashSet<string>>
				{
					new HashSet<string> { "RoleArn", "SourceProfile", "RoleSessionName" },
					new HashSet<string> { "RoleArn", "SourceProfile", "RoleSessionName", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" },
					new HashSet<string> { "RoleArn", "SourceProfile", "RoleSessionName", "AwsAccountId" },
					new HashSet<string> { "RoleArn", "SourceProfile", "RoleSessionName", "AwsAccountId", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" }
				}
			},
			{
				CredentialProfileType.AssumeRoleCredentialSourceSessionName,
				new List<HashSet<string>>
				{
					new HashSet<string> { "RoleArn", "CredentialSource", "RoleSessionName" },
					new HashSet<string> { "RoleArn", "CredentialSource", "RoleSessionName", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" },
					new HashSet<string> { "RoleArn", "CredentialSource", "RoleSessionName", "AwsAccountId" },
					new HashSet<string> { "RoleArn", "CredentialSource", "RoleSessionName", "AwsAccountId", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" }
				}
			},
			{
				CredentialProfileType.AssumeRoleExternalSessionName,
				new List<HashSet<string>>
				{
					new HashSet<string> { "ExternalID", "RoleArn", "SourceProfile", "RoleSessionName" },
					new HashSet<string> { "ExternalID", "RoleArn", "SourceProfile", "RoleSessionName", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" },
					new HashSet<string> { "ExternalID", "RoleArn", "SourceProfile", "RoleSessionName", "AwsAccountId" },
					new HashSet<string> { "ExternalID", "RoleArn", "SourceProfile", "RoleSessionName", "AwsAccountId", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" }
				}
			},
			{
				CredentialProfileType.AssumeRoleExternalMFASessionName,
				new List<HashSet<string>>
				{
					new HashSet<string> { "ExternalID", "MfaSerial", "RoleArn", "SourceProfile", "RoleSessionName" },
					new HashSet<string> { "ExternalID", "MfaSerial", "RoleArn", "SourceProfile", "RoleSessionName", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" },
					new HashSet<string> { "ExternalID", "MfaSerial", "RoleArn", "SourceProfile", "RoleSessionName", "AwsAccountId" },
					new HashSet<string> { "ExternalID", "MfaSerial", "RoleArn", "SourceProfile", "RoleSessionName", "AwsAccountId", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" }
				}
			},
			{
				CredentialProfileType.SSO,
				new List<HashSet<string>>
				{
					new HashSet<string> { "SsoAccountId", "SsoRegion", "SsoRegistrationScopes", "SsoRoleName", "SsoStartUrl", "SsoSession" }
				}
			},
			{
				CredentialProfileType.AssumeRoleMFASessionName,
				new List<HashSet<string>>
				{
					new HashSet<string> { "MfaSerial", "RoleArn", "SourceProfile", "RoleSessionName" },
					new HashSet<string> { "MfaSerial", "RoleArn", "SourceProfile", "RoleSessionName", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" },
					new HashSet<string> { "MfaSerial", "RoleArn", "SourceProfile", "RoleSessionName", "AwsAccountId" },
					new HashSet<string> { "MfaSerial", "RoleArn", "SourceProfile", "RoleSessionName", "AwsAccountId", "SsoSession", "SsoRegion", "SsoRegistrationScopes", "SsoStartUrl" }
				}
			}
		};

		private static Dictionary<CredentialProfileType, string> CredentialTypeDictionary = new Dictionary<CredentialProfileType, string>
		{
			{
				CredentialProfileType.AssumeRole,
				"Assume Role"
			},
			{
				CredentialProfileType.AssumeRoleExternal,
				"Assume Role"
			},
			{
				CredentialProfileType.AssumeRoleExternalMFA,
				"Assume Role"
			},
			{
				CredentialProfileType.AssumeRoleMFA,
				"Assume Role"
			},
			{
				CredentialProfileType.AssumeRoleWithWebIdentity,
				"Assume Role with OIDC Web Identity"
			},
			{
				CredentialProfileType.AssumeRoleWithWebIdentitySessionName,
				"Assume Role with OIDC Web Identity"
			},
			{
				CredentialProfileType.AssumeRoleSessionName,
				"Assume Role"
			},
			{
				CredentialProfileType.AssumeRoleExternalSessionName,
				"Assume Role"
			},
			{
				CredentialProfileType.AssumeRoleExternalMFASessionName,
				"Assume Role"
			},
			{
				CredentialProfileType.AssumeRoleMFASessionName,
				"Assume Role"
			},
			{
				CredentialProfileType.Basic,
				"Basic"
			},
			{
				CredentialProfileType.SAMLRole,
				"SAML"
			},
			{
				CredentialProfileType.SAMLRoleUserIdentity,
				"SAML"
			},
			{
				CredentialProfileType.Session,
				"Session"
			},
			{
				CredentialProfileType.CredentialProcess,
				"CredentialProcess"
			}
		};

		public static string GetUserFriendlyCredentialType(CredentialProfileType? profileType)
		{
			if (profileType.HasValue)
			{
				return CredentialTypeDictionary[profileType.Value];
			}
			return null;
		}

		public static CredentialProfileType? DetectProfileType(CredentialProfileOptions profileOptions)
		{
			CredentialProfileType? result = null;
			HashSet<string> propertyNames = GetPropertyNames(profileOptions);
			if (propertyNames.Contains("SsoAccountId") || propertyNames.Contains("SsoRoleName"))
			{
				return CredentialProfileType.SSO;
			}
			foreach (KeyValuePair<CredentialProfileType, List<HashSet<string>>> item in TypePropertyDictionary)
			{
				foreach (HashSet<string> item2 in item.Value)
				{
					if (item2.SetEquals(propertyNames))
					{
						result = item.Key;
					}
				}
			}
			return result;
		}

		public static HashSet<string> GetPropertiesForProfileType(CredentialProfileType profileType)
		{
			return new HashSet<string>(TypePropertyDictionary[profileType].FirstOrDefault());
		}

		private static HashSet<string> GetPropertyNames(CredentialProfileOptions profileOptions)
		{
			HashSet<string> hashSet = new HashSet<string>();
			PropertyInfo[] properties = typeof(CredentialProfileOptions).GetProperties();
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (!string.IsNullOrEmpty((string)propertyInfo.GetValue(profileOptions, null)))
				{
					hashSet.Add(propertyInfo.Name);
				}
			}
			return hashSet;
		}
	}
}
