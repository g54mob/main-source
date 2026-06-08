using System;
using System.Collections.Generic;
using Amazon.Runtime.Internal.Util;
using Amazon.Util.Internal;

namespace Amazon.Runtime.CredentialManagement.Internal
{
	public class SAMLRoleSessionManager
	{
		private SettingsManager settingsManager;

		public static bool IsAvailable => SettingsManager.IsAvailable;

		public SAMLRoleSessionManager()
		{
			settingsManager = new SettingsManager("RoleSessions");
		}

		public void Clear()
		{
			foreach (string item in settingsManager.ListUniqueKeys())
			{
				settingsManager.UnregisterObject(item);
			}
		}

		public bool TryGetRoleSession(string roleSessionName, out SAMLImmutableCredentials credentials)
		{
			credentials = null;
			if (settingsManager.TryGetObject(roleSessionName, out var properties))
			{
				try
				{
					credentials = SAMLImmutableCredentials.FromJson(properties["RoleSession"]);
				}
				catch (Exception exception)
				{
					Logger.GetLogger(typeof(SAMLRoleSessionManager)).Error(exception, "Unable to load SAML role session '{0}'.", roleSessionName);
				}
			}
			return credentials != null;
		}

		public void RegisterRoleSession(string roleSessionName, SAMLImmutableCredentials credentials)
		{
			Dictionary<string, string> properties = new Dictionary<string, string> { 
			{
				"RoleSession",
				credentials.ToJson()
			} };
			settingsManager.RegisterObject(roleSessionName, properties);
		}

		public void UnregisterRoleSession(string roleSessionName)
		{
			settingsManager.UnregisterObject(roleSessionName);
		}
	}
}
